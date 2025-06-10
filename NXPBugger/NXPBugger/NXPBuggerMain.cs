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
                CanbusClass.BOOT_ID = 0x5166 + Convert.ToUInt32(SYSTEMIDv2.Text);
                CanbusClass.BOOT_WAKE_ID = 0x5165 + Convert.ToUInt32(SYSTEMIDv2.Text);
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
            CanDatasTXID.Text = data[4];
            CanDatasTXDLC.Text = data[5];
            CanDatasTXD1.Text = data[6];
            CanDatasTXD2.Text = data[7];
            CanDatasTXD3.Text = data[8];
            CanDatasTXD4.Text = data[9];
            CanDatasTXD5.Text = data[10];
            CanDatasTXD6.Text = data[11];
            CanDatasTXD7.Text = data[12];
            CanDatasTXD8.Text = data[13];

            CanDatasRXID.Text = data[14];
            CanDatasRXDLC.Text = data[15];
            CanDatasRXD1.Text = data[16];
            CanDatasRXD2.Text = data[17];
            CanDatasRXD3.Text = data[18];
            CanDatasRXD4.Text = data[19];
            CanDatasRXD5.Text = data[20];
            CanDatasRXD6.Text = data[21];
            CanDatasRXD7.Text = data[22];
            CanDatasRXD8.Text = data[23];

            UartDatasTX.Text = data[24];
            UartDatasRX.Text = data[25];

            SYSTEMIDv2.Text = data[26];
        }
        string file = "set.csv";
        private void NXPBuggerv1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Sw_UpdateStartButton.Enabled = false;
            SwUpdate_ProgressBar.Enabled = false;
            UartClass.SerialCom = new SerialPort();
            UartComportCombobox.Items.AddRange(SerialPort.GetPortNames());
            //this.Size = new Size(650, 390);
            SW_UPD_GB.Enabled = false;
            TEST_GB.Enabled = false;
            try
            {
                if (!File.Exists(file))
                {
                    FileStream fs = File.Create(file);
                    fs.Close();
                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        writer.Write("CAN,500K,Usb01,C:/,10000000,8,1,2,3,4,5,6,7,8,10000000,8,9,A,B,C,D,E,F,G,UARTTX,UARTRX,0");
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
                this.Size = new Size(270, 390);
                testwindow = false;
                OpenTest_Window_Button.Text = "Open Side Window";
            }
            else
            {
                this.AutoSize = true;
                //this.Size = new Size(650, 390);
                testwindow = true;
                OpenTest_Window_Button.Text = "Close Side Window";
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
                    $"{GeneralProgramClass.DefaultFileLocation}," +
                    $"{CanDatasTXID.Text}," +
                    $"{CanDatasTXDLC.Text}," +
                    $"{CanDatasTXD1.Text}," +
                    $"{CanDatasTXD2.Text}," +
                    $"{CanDatasTXD3.Text}," +
                    $"{CanDatasTXD4.Text}," +
                    $"{CanDatasTXD5.Text}," +
                    $"{CanDatasTXD6.Text}," +
                    $"{CanDatasTXD7.Text}," +
                    $"{CanDatasTXD8.Text}," +
                    $"{CanDatasRXID.Text}," +
                    $"{CanDatasRXDLC.Text}," +
                    $"{CanDatasRXD1.Text}," +
                    $"{CanDatasRXD2.Text}," +
                    $"{CanDatasRXD3.Text}," +
                    $"{CanDatasRXD4.Text}," +
                    $"{CanDatasRXD5.Text}," +
                    $"{CanDatasRXD6.Text}," +
                    $"{CanDatasRXD7.Text}," +
                    $"{CanDatasRXD8.Text}," +
                    $"{UartDatasTX.Text}," +
                    $"{UartDatasRX.Text}," +
                    $"{SYSTEMIDv2.Text}"
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
        void Connect_Action()
        {
            //connect_click_state = false;
            if (ConnectButton.Text == "Connect to Device")
            {
                //uart
                if (UartRadio.Checked)
                {
                    if (UartClass.UartConnect(UartClass.SerialCom, UartComportCombobox.Text, Convert.ToInt32(BaudCombobox.Text)))
                    {
                        ConnectButton.Text = "Disconnect from Device";
                        COMM_MODE_GB.Enabled = false;
                        BAUD_GB.Enabled = false;
                        UART_COM_GB.Enabled = false;
                        SW_UPD_GB.Enabled = true;
                        TEST_GB.Enabled = true;
                        UART_TEST_GB.Enabled = true;
                        CAN_TEST_GB.Enabled = false;
                    }
                }
                //can
                else
                {
                    string selectedText = UartComportCombobox.SelectedItem.ToString();
                    COMM_MODE_GB.Enabled = false;
                    BAUD_GB.Enabled = false;
                    UART_COM_GB.Enabled = false;
                    SW_UPD_GB.Enabled = false;
                    TEST_GB.Enabled = false;
                    UART_TEST_GB.Enabled = false;
                    CAN_TEST_GB.Enabled = false;
                    if (Enum.TryParse(selectedText, out PcanChannel selectedChannel))
                    {
                        CanbusClass.channel = selectedChannel;
                    }
                    if (CanbusClass.CanConnect(CanbusClass.channel, BaudCombobox.Text))
                    {
                        CanbusClass.BOOT_ID = 0x5166 + Convert.ToUInt32(SYSTEMIDv2.Text);
                        CanbusClass.BOOT_WAKE_ID = 0x5165 + Convert.ToUInt32(SYSTEMIDv2.Text);
                        ConnectButton.Text = "Trying to Connect Device";
                        Thread.Sleep(100);
                        CanbusClass.CanTransmit(CanbusClass.channel, CanbusClass.BOOT_WAKE_ID, CanbusClass.BOOT_MSGTYP, CanbusClass.BOOT_DLC, CanbusClass.START_BL_TX);
                        if (CanbusClass.WaitForMessage(CanbusClass.channel, CanbusClass.START_BL_RX, 1000) == CanMessageState.OK)
                        {
                            /*if(connect_click_state)
                            {
                                return;
                            }*/
                            ConnectButton.Text = "Disconnect from Device";
                            CanbusClass.IsCanOpen = true;
                            COMM_MODE_GB.Enabled = false;
                            BAUD_GB.Enabled = false;
                            UART_COM_GB.Enabled = false;
                            SW_UPD_GB.Enabled = true;
                            TEST_GB.Enabled = true;
                            UART_TEST_GB.Enabled = true;
                            CAN_TEST_GB.Enabled = true;
                            MessageBox.Show("Bootmode Activated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GeneralProgramClass.ListenInfinite = false;
                            InfCanTask = new Thread(InfiniteListenLoop);
                            InfCanTask.Start();
                        }
                        else
                        {
                            if (CanbusClass.CanDisconnect(CanbusClass.channel))
                            {
                                GeneralProgramClass.ListenInfinite = false;
                                CanbusClass.IsCanOpen = false;
                                ConnectButton.Text = "Connect to Device";
                                COMM_MODE_GB.Enabled = true;
                                BAUD_GB.Enabled = true;
                                UART_COM_GB.Enabled = true;
                                SW_UPD_GB.Enabled = false;
                                TEST_GB.Enabled = false;
                                UART_TEST_GB.Enabled = false;
                                CAN_TEST_GB.Enabled = false;
                            }
                        }
                    }
                }
            }
            else
            {
                //uart disc
                if (UartRadio.Checked)
                {
                    if (UartClass.UartDisconnect(UartClass.SerialCom))
                    {
                        ConnectButton.Text = "Connect to Device";
                        COMM_MODE_GB.Enabled = true;
                        BAUD_GB.Enabled = true;
                        UART_COM_GB.Enabled = true;
                        SW_UPD_GB.Enabled = false;
                        TEST_GB.Enabled = false;
                        UART_TEST_GB.Enabled = false;
                        CAN_TEST_GB.Enabled = false;
                    }
                }
                //can disc
                else
                {
                    if (CanbusClass.CanDisconnect(CanbusClass.channel))
                    {
                        GeneralProgramClass.ListenInfinite = false;
                        CanbusClass.IsCanOpen = false;
                        ConnectButton.Text = "Connect to Device";
                        COMM_MODE_GB.Enabled = true;
                        BAUD_GB.Enabled = true;
                        UART_COM_GB.Enabled = true;
                        SW_UPD_GB.Enabled = false;
                        TEST_GB.Enabled = false;
                        UART_TEST_GB.Enabled = false;
                        CAN_TEST_GB.Enabled = false;
                    }
                }
            }
        }

        void InfiniteListenLoop()
        {
            while (GeneralProgramClass.ListenInfinite)
            {
                byte[] temp = new byte[8];
                CanbusClass.CanReceive(CanbusClass.channel, CanbusClass.BOOT_ID, CanbusClass.BOOT_MSGTYP, CanbusClass.BOOT_DLC, temp, 0, GeneralProgramClass.ListenInfinite);
            }
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
            ofd.Filter = "Application File |*.cwa| Config File|*.cfg";
            ofd.FilterIndex = 1;
            ofd.InitialDirectory = GeneralProgramClass.DefaultFileLocation;
            if (DialogResult.OK == ofd.ShowDialog())
            {
                GeneralProgramClass.DefaultFileLocation = ofd.FileName;
                filename_label.Text = "Filename : " + ofd.SafeFileName;
                Sw_UpdateStartButton.Enabled = true;
                SwUpdate_ProgressBar.Maximum = Convert.ToInt32((new FileInfo(ofd.FileName).Length));
                if (filename_label.Text.EndsWith(".cwa"))
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
        private void CanDatas_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == string.Empty)
            {
                textBox.Text = "0";
            }
            if (textBox != null)
            {
                string text = textBox.Text.ToUpper();
                string filteredText = new string(text.Where(c => "0123456789ABCDEF".Contains(c)).ToArray());
                if (text != filteredText)
                {
                    textBox.Text = filteredText;
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
            if (textBox == CanDatasTXDLC)
            {

                if (int.Parse(CanDatasTXDLC.Text, System.Globalization.NumberStyles.HexNumber) > 8)
                {
                    CanDatasTXDLC.Text = "8";
                }
                else if (int.Parse(CanDatasTXDLC.Text, System.Globalization.NumberStyles.HexNumber) < 1)
                {
                    CanDatasTXDLC.Text = "1";
                }
            }
            if (textBox == CanDatasRXDLC)
            {
                if (int.Parse(CanDatasRXDLC.Text, System.Globalization.NumberStyles.HexNumber) > 8)
                {
                    CanDatasRXDLC.Text = "8";
                }
                else if (int.Parse(CanDatasRXDLC.Text, System.Globalization.NumberStyles.HexNumber) < 1)
                {
                    CanDatasRXDLC.Text = "1";
                }
            }

            if (textBox == CanDatasTXID)
            {
                if (int.Parse(CanDatasTXID.Text, System.Globalization.NumberStyles.HexNumber) > 0x20000000)
                {
                    CanDatasTXID.Text = "20000000";
                }
                else if (int.Parse(CanDatasTXID.Text, System.Globalization.NumberStyles.HexNumber) < 1)
                {
                    CanDatasTXID.Text = "1";
                }
            }
            if (textBox == CanDatasRXID)
            {
                if (int.Parse(CanDatasRXID.Text, System.Globalization.NumberStyles.HexNumber) > 0x20000000)
                {
                    CanDatasRXID.Text = "20000000";
                }
                else if (int.Parse(CanDatasRXID.Text, System.Globalization.NumberStyles.HexNumber) < 1)
                {
                    CanDatasRXID.Text = "1";
                }
            }
        }
        private void SendData_Click(object sender, EventArgs e)
        {
            if (UartRadio.Checked)
            {
                UartClass.Serial_Transmit(UartClass.SerialCom, UartDatasTX.Text);
            }
            else
            {
                uint ID = uint.Parse(CanDatasTXID.Text, System.Globalization.NumberStyles.HexNumber);
                byte[] Data = new byte[8];
                Data[0] = byte.Parse(CanDatasTXD1.Text, System.Globalization.NumberStyles.HexNumber);
                Data[1] = byte.Parse(CanDatasTXD2.Text, System.Globalization.NumberStyles.HexNumber);
                Data[2] = byte.Parse(CanDatasTXD3.Text, System.Globalization.NumberStyles.HexNumber);
                Data[3] = byte.Parse(CanDatasTXD4.Text, System.Globalization.NumberStyles.HexNumber);
                Data[4] = byte.Parse(CanDatasTXD5.Text, System.Globalization.NumberStyles.HexNumber);
                Data[5] = byte.Parse(CanDatasTXD6.Text, System.Globalization.NumberStyles.HexNumber);
                Data[6] = byte.Parse(CanDatasTXD7.Text, System.Globalization.NumberStyles.HexNumber);
                Data[7] = byte.Parse(CanDatasTXD8.Text, System.Globalization.NumberStyles.HexNumber);
                CanbusClass.CanTransmit(CanbusClass.channel, ID, ID > 2047 ? MessageType.Extended : MessageType.Standard, Convert.ToUInt32(CanDatasTXDLC.Text), Data);
            }
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
        private void SYSTEMIDv2_Click(object sender, EventArgs e)
        {
            SYSTEMIDv2.Text = Convert.ToUInt32(SYSTEMIDv2.Text) > 255 ? 255.ToString() : SYSTEMIDv2.Text;
        }
    }
}
