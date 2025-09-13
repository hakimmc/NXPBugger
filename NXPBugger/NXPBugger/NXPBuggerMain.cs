using Peak.Can.Basic;
using System.Diagnostics;
using System.IO.Ports;
using System.Security.Permissions;
using static NXPBugger.GeneralProgramClass;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace NXPBugger
{
    public partial class NXPBuggerv1 : Form
    {
        bool testwindow = true;
        public NXPBuggerv1()
        {
            InitializeComponent();
        }
        //string DefaultFileLocation;
        public bool flag = false;
        public int DoubleClickCounter = 0;
        Thread SW_UPD_TH;
        bool KILL_SW_UPD_TH = false;
        void StartUpgradeSW()
        {
            if (UartRadio.Checked)
            {
                UartClass.UartBootloaderStart(UartClass.SerialCom, GeneralProgramClass.DefaultFileLocation, SwUpdate_ProgressBar, Sw_UpdateStartButton, Sw_DuringTimeLabel, ref KILL_SW_UPD_TH);
            }
            else if (CanRadio.Checked)
            {
                CanbusClass.BOOT_ID = 0x5166;//+ Convert.ToUInt32(SYSTEMIDv2.Text);
                CanbusClass.BOOT_WAKE_ID = 0x5165;// + Convert.ToUInt32(SYSTEMIDv2.Text);
                CanbusClass.CanBootloaderStart(CanbusClass.channel, GeneralProgramClass.DefaultFileLocation, SwUpdate_ProgressBar, Sw_UpdateStartButton, Sw_DuringTimeLabel, ref KILL_SW_UPD_TH);
            }
        }
        void ReWriteDatas(string[] data)
        {

            if (data[0] == "UART")
            {
                CanRadio.Checked = false;
                UartRadio.Checked = true;
                BaudCombobox.Items.Clear();
                BaudCombobox.Items.AddRange(UartClass.baudrates);
                UART_COM_GB.Enabled = true;
                UartComportCombobox.Items.Clear();
                UartComportCombobox.Items.AddRange(SerialPort.GetPortNames());
            }
            else
            {
                UartRadio.Checked = false;
                CanRadio.Checked = true;
                BaudCombobox.Items.Clear();
                BaudCombobox.Items.AddRange(CanbusClass.baudrates);
                UART_COM_GB.Enabled = true;
                UartComportCombobox.Items.Clear();
                UartComportCombobox.Items.AddRange(Enum.GetNames(typeof(PcanChannel)));
            }
            foreach (string s in BaudCombobox.Items)
            {
                if (s == data[1])
                {
                    BaudCombobox.Text = data[1];
                    flag = true;
                    break;
                }
                continue;
            }
            if (!flag)
            {
                BaudCombobox.Text = Convert.ToString(BaudCombobox.Items[0]);
            }
            UartComportCombobox.Text = data[2];
            GeneralProgramClass.DefaultFileLocation = data[3];
        }
        string file = "set.csv";
        string sw_ver = "0.E";
        private void NXPBuggerv1_Load(object sender, EventArgs e)
        {
            this.Text += sw_ver;
            Control.CheckForIllegalCrossThreadCalls = false;
            Sw_UpdateStartButton.Enabled = false;
            SwUpdate_ProgressBar.Enabled = false;
            UartClass.SerialCom = new SerialPort();
            UartComportCombobox.Items.AddRange(SerialPort.GetPortNames());
            //this.Size = new Size(650, 390);
            SW_UPD_GB.Enabled = false;
            try
            {
                if (!File.Exists(file))
                {
                    FileStream fs = File.Create(file);
                    fs.Close();
                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        writer.Write("CAN,500K,Usb01,C:/");
                    }
                }
                using (StreamReader reader = new StreamReader(file))
                {
                    string data = reader.ReadToEnd();
                    ReWriteDatas(data.Split(','));
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CanbusClass.CanTXMessage = new PcanMessage();
        }
        private void OpenTest_Window_Button_Click(object sender, EventArgs e)
        {
            if (testwindow)
            {
                this.AutoSize = false;
                //this.Size = new Size(270, 390);
                testwindow = false;
                OpenTest_Window_Button.Text = "Open Test Window";
            }
            else
            {
                this.AutoSize = true;
                //this.Size = new Size(650, 390);
                testwindow = true;
                OpenTest_Window_Button.Text = "Close Test Window";
            }
        }
        private void NXPBuggerv1_FormClosing(object sender, FormClosingEventArgs e)
        {
            KILL_SW_UPD_TH = true;
            while (!KILL_SW_UPD_TH)
            {
                Thread.Sleep(10);
            }
            if (UartClass.SerialCom.IsOpen)
            {
                UartClass.SerialCom.Close();
            }
            if (CanbusClass.IsCanOpen)
            {
                CanbusClass.CanDisconnect(CanbusClass.channel);
            }
            using (StreamWriter writer = new StreamWriter(file))
            {
                string commod = UartRadio.Checked == true ? "UART" : "CAN";
                writer.Write($"{commod}," +
                    $"{BaudCombobox.Text}," +
                    $"{UartComportCombobox.Text}," +
                    $"{GeneralProgramClass.DefaultFileLocation}"
                    );
            }
        }
        private void UartRadio_CheckedChanged(object sender, EventArgs e)
        {
            BaudCombobox.Items.Clear();
            BaudCombobox.Items.AddRange(UartRadio.Checked == true ? UartClass.baudrates : CanbusClass.baudrates);
            BaudCombobox.Text = Convert.ToString(BaudCombobox.Items[0]);
            UartComportCombobox.Items.Clear();
            UartComportCombobox.Items.AddRange(UartRadio.Checked == true ? SerialPort.GetPortNames() : Enum.GetNames(typeof(PcanChannel)));
            if (UartRadio.Checked)
            {
                try
                {
                    UartComportCombobox.Text = (Convert.ToString(UartComportCombobox.Items[0]));
                }
                catch
                {
                    UartComportCombobox.Text = "ComPort Couldnt Find!";
                }

            }
            else
            {
                UartComportCombobox.Text = "Usb01";
            }

        }
        Thread InfCanTask;
        void InfiniteListenLoop()
        {
            while (GeneralProgramClass.ListenInfinite)
            {
                byte[] temp = new byte[8];
                CanbusClass.CanReceive(CanbusClass.channel, CanbusClass.BOOT_ID, CanbusClass.BOOT_MSGTYP, CanbusClass.BOOT_DLC, temp, 0, GeneralProgramClass.ListenInfinite);
            }
        }
        void Connect_Action()
        {
            if (ConnectButton.Text == "Connect to Device")
            {
                if (UartRadio.Checked)
                {
                    ConnectViaUart();
                }
                else
                {
                    ConnectViaCan();
                }
            }
            else
            {
                if (UartRadio.Checked)
                {
                    DisconnectUart();
                }
                else
                {
                    DisconnectCan();
                }
            }
        }
        void ConnectViaUart()
        {
            if (UartClass.UartConnect(UartClass.SerialCom, UartComportCombobox.Text, Convert.ToInt32(BaudCombobox.Text)))
            {
                SetGuiStateConnected();
            }
        }
        void ConnectViaCan()
        {
            uint timeout = 119; // 2 min
            string selectedText = UartComportCombobox.SelectedItem.ToString();
            DisableAllControlsTemporarily();

            if (Enum.TryParse(selectedText, out PcanChannel selectedChannel))
            {
                CanbusClass.channel = selectedChannel;
            }

            if (CanbusClass.CanConnect(CanbusClass.channel, BaudCombobox.Text))
            {
                CanbusClass.BOOT_ID = 0x5166;//+ Convert.ToUInt32(SYSTEMIDv2.Text);
                CanbusClass.BOOT_WAKE_ID = 0x5165;// + Convert.ToUInt32(SYSTEMIDv2.Text);

                ConnectButton.Text = "Trying to Connect Device";
                Thread.Sleep(100);
                //CanbusClass.CanTransmit(CanbusClass.channel, CanbusClass.BOOT_WAKE_ID, CanbusClass.BOOT_MSGTYP, CanbusClass.BOOT_DLC, CanbusClass.START_BL_TX);
                CanbusClass.CanTransmit(CanbusClass.channel, CanbusClass.BOOT_WAKE_ID, CanbusClass.BOOT_MSGTYP, CanbusClass.BOOT_DLC, CanbusClass.START_BL_TX);
                while (CanbusClass.WaitForMessage(CanbusClass.channel, CanbusClass.START_BL_RX, 1000) != CanMessageState.OK && timeout > 0)
                {
                    CanbusClass.CanTransmit(CanbusClass.channel, CanbusClass.BOOT_WAKE_ID, CanbusClass.BOOT_MSGTYP, CanbusClass.BOOT_DLC, CanbusClass.START_BL_TX);
                    timeout--;
                }
                if (timeout>0)
                {
                    ConnectButton.Text = "Disconnect from Device (Run)";
                    CanbusClass.IsCanOpen = true;
                    SetGuiStateConnected();
                    MessageBox.Show("Bootmode Activated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GeneralProgramClass.ListenInfinite = false;
                    InfCanTask = new Thread(InfiniteListenLoop);
                    InfCanTask.Start();
                }
                else
                {
                    DisconnectCan(); // Retry-safe
                }
            }
            else
            {
                DisconnectCan(); // Connection failed
            }
        }
        void DisconnectUart()
        {
            if (UartClass.UartDisconnect(UartClass.SerialCom))
            {
                SetGuiStateDisconnected();
            }
        }
        void DisconnectCan()
        {
            CanbusClass.JumpToApp();
            //CanbusClass.JumpToApp();
            if (CanbusClass.CanDisconnect(CanbusClass.channel))
            {
                GeneralProgramClass.ListenInfinite = false;
                CanbusClass.IsCanOpen = false;
                SetGuiStateDisconnected();
            }
            else
            {
                GeneralProgramClass.ListenInfinite = false;
                CanbusClass.IsCanOpen = false;
                SetGuiStateDisconnected();
            }
        }
        void SetGuiStateConnected()
        {
            ConnectButton.Text = "Disconnect from Device (Run)";
            COMM_MODE_GB.Enabled = false;
            BAUD_GB.Enabled = false;
            UART_COM_GB.Enabled = false;
            SW_UPD_GB.Enabled = true;
        }
        void SetGuiStateDisconnected()
        {
            ConnectButton.Text = "Connect to Device";
            COMM_MODE_GB.Enabled = true;
            BAUD_GB.Enabled = true;
            UART_COM_GB.Enabled = true;
            SW_UPD_GB.Enabled = false;
        }
        void DisableAllControlsTemporarily()
        {
            COMM_MODE_GB.Enabled = false;
            BAUD_GB.Enabled = false;
            UART_COM_GB.Enabled = false;
            SW_UPD_GB.Enabled = false;
        }
        Thread TH_CONNECT;
        bool connect_click_state = false;
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            //connect_click_state = true;
            TH_CONNECT = new Thread(Connect_Action);
            TH_CONNECT.Start();
        }
        private void NXPBuggerv1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoubleClickCounter++;
            if (DoubleClickCounter > 1)
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "https://www.linkedin.com/in/abdulhakim-calgin/",
                    UseShellExecute = true
                };
                Process.Start(psi);
                DoubleClickCounter = 0;
            }
        }
        private void select_file_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Application File |*.bin";
            ofd.FilterIndex = 0;
            ofd.InitialDirectory = GeneralProgramClass.DefaultFileLocation;
            if (DialogResult.OK == ofd.ShowDialog())
            {
                GeneralProgramClass.DefaultFileLocation = ofd.FileName;
                filename_label.Text = "Filename : " + ofd.SafeFileName;
                Sw_UpdateStartButton.Enabled = true;
                SwUpdate_ProgressBar.Maximum = Convert.ToInt32((new FileInfo(ofd.FileName).Length));
                if (filename_label.Text.EndsWith(".bin"))
                {
                    GeneralProgramClass.ModeForUpload = GeneralProgramClass.UploadMode.PROGRAM;
                }
                else // .cfg
                {
                    GeneralProgramClass.ModeForUpload = GeneralProgramClass.UploadMode.CONFIG;
                }
            }

        }
        private void Sw_UpdateStartButton_Click(object sender, EventArgs e)
        {
            SW_UPD_TH = new Thread(StartUpgradeSW);
            SW_UPD_TH.Start();
        }
        private void UartComportCombobox_Click(object sender, EventArgs e)
        {
            if (UartRadio.Checked)
            {
                string comport = UartComportCombobox.Text;
                UartComportCombobox.Items.Clear();
                UartComportCombobox.Items.AddRange(SerialPort.GetPortNames());
                foreach (string ports in UartComportCombobox.Items)
                {
                    if (comport == ports)
                    {
                        UartComportCombobox.Text = comport;
                        break;
                    }
                }
            }
        }
        bool debugbool = true;
        bool once_child_form = true;
        private void Create_Config_File_Click(object sender, EventArgs e)
        {
            if (debugbool)
            {
                if (!GeneralProgramClass.FormActive_CFG_Creator)
                {
                    Config_Creator cc = new Config_Creator();
                    cc.Show();
                    GeneralProgramClass.FormActive_CFG_Creator = true;
                }
            }
            else
            {
                LoginPage lp = new LoginPage();
                lp.Show();
                if (DialogResult.OK == lp.ShowDialog())
                {
                    if (!GeneralProgramClass.FormActive_CFG_Creator)
                    {
                        Config_Creator cc = new Config_Creator();
                        cc.Show();
                        GeneralProgramClass.FormActive_CFG_Creator = true;
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password is false", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void readconfig_Click(object sender, EventArgs e)
        {
            if (GeneralProgramClass.FormActive_CFG_Reader == false)
            {
                Config_Reader cr = new Config_Reader();
                cr.Show();
                GeneralProgramClass.FormActive_CFG_Reader = true;
            }
        }
    }
}
