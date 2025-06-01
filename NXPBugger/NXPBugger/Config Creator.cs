using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using System.Text;

namespace NXPBugger
{
    public partial class Config_Creator : Form
    {
        public Config_Creator()
        {
            InitializeComponent();
        }


        public static bool read_cfg = false;
        private void Config_Creator_Load(object sender, EventArgs e)
        {

            BootModeCB.Text = BootModeCB.Items[0].ToString();
            CAN1_BAUD_CB.Text = CAN1_BAUD_CB.Items[2].ToString();
            CAN2_BAUD_CB.Text = CAN2_BAUD_CB.Items[2].ToString();
            CAN3_BAUD_CB.Text = CAN3_BAUD_CB.Items[2].ToString();
            CAN4_BAUD_CB.Text = CAN4_BAUD_CB.Items[2].ToString();
            PRINTFDEBUGCB.Text = PRINTFDEBUGCB.Items[0].ToString();
            UARTBAUDCB.Text = UARTBAUDCB.Items[0].ToString();
            macalgorithmcb.Text = macalgorithmcb.Items[0].ToString();
            GenMacAddr.PerformClick();
        }

        private void GenerateCfg_Click(object sender, EventArgs e)
        {
            byte[] cfg_bytes = CreateCfg();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Config File|*.cfg";
            sfd.FilterIndex = 1;
            sfd.InitialDirectory = GeneralProgramClass.DefaultFileLocation;
            sfd.FileName = $"NXP_SW_VER_{MAJORVERSION.Value}_{MINORVERSION.Value}_{BUGFIXVERSION.Value}_COMPANY_{companynum.Value}_USER_{usernamenum.Value}_CFG_FILE";
            if (DialogResult.OK == sfd.ShowDialog())
            {
                GeneralProgramClass.DefaultFileLocation = sfd.FileName;
                File.WriteAllBytes(sfd.FileName, cfg_bytes);
                MessageBox.Show(sfd.FileName + " created!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return;
            }
        }

        private void AssembleBinFile_Click(object sender, EventArgs e)
        {
            byte[] cfg_bytes;
            DialogResult dr = MessageBox.Show("Do you want select config file from the external location? If you want add .cfg file to .bin file click OK." +
                "Else, if you click to other answers you are going to use config which have in application."
                , "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                OpenFileDialog ofd1 = new OpenFileDialog();
                ofd1.Title = "Select Config File For Assemble With Application";
                ofd1.Filter = "Config File |*.cfg";
                ofd1.FilterIndex = 1;
                ofd1.InitialDirectory = GeneralProgramClass.DefaultFileLocation;
                if (DialogResult.OK == ofd1.ShowDialog())
                {
                    cfg_bytes = File.ReadAllBytes(ofd1.FileName);
                }
                else
                {
                    return;
                }
            }
            else
            {
                cfg_bytes = CreateCfg();
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Application File For Assemble With Config";
            ofd.Filter = "Application File |*.bin";
            ofd.FilterIndex = 1;
            ofd.InitialDirectory = GeneralProgramClass.DefaultFileLocation;
            if (DialogResult.OK == ofd.ShowDialog())
            {
                GeneralProgramClass.DefaultFileLocation = ofd.FileName;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Select or Create Target Application File For Assemble With Config";
                sfd.Filter = "Application File |*.cwa";
                sfd.FilterIndex = 1;
                sfd.InitialDirectory = GeneralProgramClass.DefaultFileLocation;
                sfd.FileName = $"NXP_SW_VER_{MAJORVERSION.Value}_{MINORVERSION.Value}_{BUGFIXVERSION.Value}_COMPANY_{companynum.Value}_USER_{usernamenum.Value}_CWA_FILE";
                if (DialogResult.OK == sfd.ShowDialog())
                {
                    GeneralProgramClass.DefaultFileLocation = sfd.FileName;
                    File.WriteAllBytes(sfd.FileName, MergeByteArrays(cfg_bytes, File.ReadAllBytes(ofd.FileName)));
                    MessageBox.Show("Config file assembled with " + ofd.FileName + " to " + sfd.FileName + "!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        public static byte[] MergeByteArrays(byte[] array1, byte[] array2)
        {
            byte[] mergedArray = new byte[array1.Length + array2.Length];
            Buffer.BlockCopy(array1, 0, mergedArray, 0, array1.Length);
            Buffer.BlockCopy(array2, 0, mergedArray, array1.Length, array2.Length);
            return mergedArray;
        }

        public byte[] GenerateMacAddress(int algorithm)
        {
            int unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            byte[] hash;

            switch (algorithm)
            {
                case 0: // SHA-256
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(unixTimestamp.ToString()));
                    }
                    break;

                case 1: // MD5
                    using (MD5 md5 = MD5.Create())
                    {
                        hash = md5.ComputeHash(Encoding.UTF8.GetBytes(unixTimestamp.ToString()));
                    }
                    break;

                case 2: // HMAC-SHA256
                    using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes("SecretKey123!")))
                    {
                        hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(unixTimestamp.ToString()));
                    }
                    break;

                default:
                    MessageBox.Show("Invalid algorithm selection!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }

            byte[] mac = new byte[6];
            Array.Copy(hash, mac, 6);
            mac[0] = (byte)((mac[0] & 0xFE) | 0x02);
            macaddresstext.Text = "MAC : " + BitConverter.ToString(mac).Replace("-", ":");
            //MessageBox.Show("MAC Address: " + BitConverter.ToString(mac).Replace("-", ":"), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return mac;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public byte[] MAC_ADDR = new byte[6];
        private void GenMacAddr_Click(object sender, EventArgs e)
        {
            MAC_ADDR = GenerateMacAddress(macalgorithmcb.SelectedIndex);
        }

        private void cellsettings_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CELLSETTINGS_TextChanged(object sender, EventArgs e)
        {
            Control txtbox = (Control)sender;
            if (txtbox.Text == string.Empty)
            {
                txtbox.Text = "0";
            }
            if (Convert.ToInt32(txtbox.Text) > 65535)
            {
                txtbox.Text = "65535";
            }
            txtbox.Text = Convert.ToInt32(txtbox.Text).ToString();
        }

        public byte[] CreateCfg()
        {
            int unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            byte[] bytes = new byte[] { 
                //DATE
                (byte)(0xFF & (unixTimestamp >> (24 - (8 * 3)))),
                (byte)(0xFF & (unixTimestamp >> (24 - (8 * 2)))),
                (byte)(0xFF & (unixTimestamp >> (24 - (8 * 1)))),
                (byte)(0xFF & (unixTimestamp >> (24 - (8 * 0)))),//0x450000 - 0x450003 4BYTE
                //SYSTEM ID
                (byte)(SYSTEMID.Value), //0x450004 - 0x450005 1BYTE
                //SW VERSION
                (byte)(MAJORVERSION.Value), //0x450005 - 0x450006 1BYTE
                (byte)(MINORVERSION.Value), //0x450006 - 0x450007 1BYTE
                (byte)(BUGFIXVERSION.Value), //0x450007 - 0x450008 1BYTE
                //MAC ADDRESS
                (byte)(0xFF), // released
                MAC_ADDR[0],
                MAC_ADDR[1],
                MAC_ADDR[2],
                MAC_ADDR[3],
                MAC_ADDR[4],
                MAC_ADDR[5],
                (byte)(0xFF),
                //BOOT SETTINGS
                (byte)(BootModeCB.SelectedIndex + ((uint)(BOOTTIMEOUT.Value)<<1)),
                //CAN SETTINGS
                (byte)((CAN1_BAUD_CB.SelectedIndex)+(CAN2_BAUD_CB.SelectedIndex<<2) + (CAN3_BAUD_CB.SelectedIndex<<4) + (CAN4_BAUD_CB.SelectedIndex<<6)),
                //UART SETTINGS
                (byte)((UARTBAUDCB.SelectedIndex)+(PRINTFDEBUGCB.SelectedIndex<<1)+
                //COMPANY SETTING
                (uint)(companynum.Value)<<2),
                //USER SETTINGS
                (byte)(usernamenum.Value),
                //BMS SETTINGS
                (byte)(CELLCAPAH.Value),
                (byte)(SERIESCELLCOUNT.Value),
                (byte)(PARALLELCELLCOUNT.Value),
                (byte)(DAISYCHAINCOUNT.Value),
                //CELL SETTINGS
                (byte)((Convert.ToInt32(maxcellv.Text)) & 0xFF),
                (byte)((Convert.ToInt32(maxcellv.Text))>>8),
                (byte)((Convert.ToInt32(mincellv.Text)) & 0xFF),
                (byte)((Convert.ToInt32(mincellv.Text))>>8),
                (byte)((Convert.ToInt32(tempsensorb.Text)) & 0xFF),
                (byte)((Convert.ToInt32(tempsensorb.Text))>>8),
                (byte)(defaultsoc.Value),
                (byte)(defaultsoh.Value),
                (byte)(maxtemp.Value),
                (byte)(mintemp.Value),
                (byte)(tempsensorcount.Value),
                (byte)(0xFF),(byte)(0xFF),(byte)(0xFF),(byte)(0xFF),(byte)(0xFF), // padding bytes
                (byte)('!'),(byte)('C'),(byte)('F'),(byte)('G'),
                (byte)'E',(byte)'O',(byte)'C',(byte)';'
            };
            return bytes;
        }

        private void ReadCfg_Click(object sender, EventArgs e)
        {
            if (GeneralProgramClass.FormActive_CFG_Reader == false)
            {
                Config_Reader cr = new Config_Reader();
                cr.Show();
                GeneralProgramClass.FormActive_CFG_Reader = true;
            }
        }

        private void Config_Creator_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
