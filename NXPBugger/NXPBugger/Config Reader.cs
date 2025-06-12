using Peak.Can.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NXPBugger.GeneralProgramClass;

namespace NXPBugger
{
    public partial class Config_Reader : Form
    {
        public Config_Reader()
        {
            InitializeComponent();
        }

        private void SelectCfgFromStorage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Config File For Show Configuration";
            ofd.Filter = "Config File |*.cfg";
            ofd.FilterIndex = 1;
            ofd.InitialDirectory = GeneralProgramClass.DefaultFileLocation;
            if (DialogResult.OK == ofd.ShowDialog())
            {
                byte[] filebyte = File.ReadAllBytes(ofd.FileName);
                ReadAndReplaceConfigFile(filebyte);
            }
        }

        public void ReadAndReplaceConfigFile(byte[] cfgfilebyte)
        {
            UInt32 unixtime = 0;
            for (int i = 0; i < 4; i++)
            {
                unixtime += (Convert.ToUInt32(cfgfilebyte[i]) << (i * 8));
            }
            date.Text = DateTimeOffset.FromUnixTimeSeconds(unixtime).LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            SYSTEMID.Value = cfgfilebyte[4];
            MAJORVERSION.Value = cfgfilebyte[5];
            MINORVERSION.Value = cfgfilebyte[6];
            BUGFIXVERSION.Value = cfgfilebyte[7];
            //cfgfilebyte[8] released!
            MAC_ADDR[0] = cfgfilebyte[9];
            MAC_ADDR[1] = cfgfilebyte[10];
            MAC_ADDR[2] = cfgfilebyte[11];
            MAC_ADDR[3] = cfgfilebyte[12];
            MAC_ADDR[4] = cfgfilebyte[13];
            MAC_ADDR[5] = cfgfilebyte[14];
            //cfgfilebyte[15] released!
            BootModeCB.SelectedIndex = cfgfilebyte[16] & 0x1;
            BOOTTIMEOUT.Value = (cfgfilebyte[16] & 0xFE)>>1;
            CAN1_BAUD_CB.SelectedIndex = cfgfilebyte[17] & 0x3;
            CAN2_BAUD_CB.SelectedIndex = (cfgfilebyte[17] & (0x3 << 2)) >> 2;
            CAN3_BAUD_CB.SelectedIndex = (cfgfilebyte[17] & (0x3 << 4)) >> 4;
            CAN4_BAUD_CB.SelectedIndex = (cfgfilebyte[17] & (0x3 << 6)) >> 6;
            UARTBAUDCB.SelectedIndex = cfgfilebyte[18] & 0x1;
            PRINTFDEBUGCB.SelectedIndex = (cfgfilebyte[18] & 0x2)>>1;
            companynum.Value = (cfgfilebyte[18] & 0xFC)>>2;
            usernamenum.Value = (cfgfilebyte[19]);
            CELLCAPAH.Value = cfgfilebyte[20];
            SERIESCELLCOUNT.Value = cfgfilebyte[21];
            PARALLELCELLCOUNT.Value = cfgfilebyte[22];
            DAISYCHAINCOUNT.Value = cfgfilebyte[23];
            maxcellv.Text = (((uint)(cfgfilebyte[25]) << 8) + cfgfilebyte[24]).ToString();
            mincellv.Text = (((uint)(cfgfilebyte[27]) << 8) + cfgfilebyte[26]).ToString();
            tempsensorb.Text = (((uint)(cfgfilebyte[29]) << 8) + cfgfilebyte[28]).ToString();
            defaultsoc.Value = cfgfilebyte[30]>100?100: cfgfilebyte[30];
            defaultsoh.Value = cfgfilebyte[31] > 100 ? 100 : cfgfilebyte[31];
            maxtemp.Value = cfgfilebyte[32];
            mintemp.Value = cfgfilebyte[33];
            tempsensorcount.Value = cfgfilebyte[34];
            //cfgfilebyte[35] released!
            //cfgfilebyte[36] '!'
            //cfgfilebyte[37] 'C'
            //cfgfilebyte[38] 'F'
            //cfgfilebyte[39] 'G'
            //cfgfilebyte[40] 'S'
            //cfgfilebyte[41] 'K'
            //cfgfilebyte[42] 'I'
            //cfgfilebyte[43] 'P'
            macaddresstext.Text = "MAC : " + BitConverter.ToString(MAC_ADDR).Replace("-", ":");
            MessageBox.Show("Config Read Success!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public byte[] MAC_ADDR = new byte[6];
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
            //MessageBox.Show("Config Write Success!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return bytes;
        }

        private void Config_Reader_Load(object sender, EventArgs e)
        {
            
            SYSTEMID.Value = SYSTEMID.Minimum;
            BOOTTIMEOUT.Value = BOOTTIMEOUT.Minimum;
            MAJORVERSION.Value = MAJORVERSION.Minimum;
            MINORVERSION.Value = MINORVERSION.Minimum;
            BUGFIXVERSION.Value = BUGFIXVERSION.Minimum;
            CELLCAPAH.Value = CELLCAPAH.Minimum;
            SERIESCELLCOUNT.Value = SERIESCELLCOUNT.Minimum;
            PARALLELCELLCOUNT.Value = PARALLELCELLCOUNT.Minimum;
            DAISYCHAINCOUNT.Value = DAISYCHAINCOUNT.Minimum;
            companynum.Value = companynum.Minimum;
            usernamenum.Value = usernamenum.Minimum;
            maxcellv.Text = "0";
            mincellv.Text = "0";
            tempsensorb.Text = "0";
            defaultsoc.Value = defaultsoc.Minimum;
            defaultsoh.Value = defaultsoh.Minimum;
            maxtemp.Value = maxtemp.Minimum;
            mintemp.Value = mintemp.Minimum;
            tempsensorcount.Value = tempsensorcount.Minimum;
            BootModeCB.SelectedIndex = 0;
            CAN1_BAUD_CB.SelectedIndex = 0;
            CAN2_BAUD_CB.SelectedIndex = 0;
            CAN3_BAUD_CB.SelectedIndex = 0;
            CAN4_BAUD_CB.SelectedIndex = 0;
            PRINTFDEBUGCB.SelectedIndex = 0;
            UARTBAUDCB.SelectedIndex = 0;
        }

        private void Config_Reader_FormClosing(object sender, FormClosingEventArgs e)
        {
            GeneralProgramClass.FormActive_CFG_Reader = false;
        }

        public static readonly byte[] READ_CFG_COMMAND_TX = Encoding.ASCII.GetBytes("READCFG0");
        public static readonly byte[] READ_CFG_COMMAND_RX = Encoding.ASCII.GetBytes("!CFGWRGT");
        private void ReadCfgFromDevice_Click(object sender, EventArgs e)
        {
            READ_CFG_COMMAND_TX[7] = (byte)(0);
            CanbusClass.CanTransmit(CanbusClass.channel, CanbusClass.BOOT_WAKE_ID, CanbusClass.BOOT_MSGTYP, CanbusClass.BOOT_DLC, READ_CFG_COMMAND_TX);
            /*if (CanbusClass.WaitForMessage(CanbusClass.channel, READ_CFG_COMMAND_RX, 5000) == CanMessageState.OK)
            {*/
                byte[] temp_cfg_array = new byte[8];
                byte[] cfg_array = new byte[48];
                for(int i = 0; i < 6; i++)
                {
                    Thread.Sleep(100);
                    if (!CanbusClass.CanReceive(CanbusClass.channel, CanbusClass.BOOT_ID, CanbusClass.BOOT_MSGTYP, CanbusClass.BOOT_DLC, temp_cfg_array, 5000))
                    {
                        MessageBox.Show("Timeout error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    for(int j=0; j<8; j++)
                    {
                        cfg_array[(i*8)+j] = temp_cfg_array[j];
                    }
                    READ_CFG_COMMAND_TX[7] = (byte)(i+1);
                    CanbusClass.CanTransmit(CanbusClass.channel, CanbusClass.BOOT_WAKE_ID, CanbusClass.BOOT_MSGTYP, CanbusClass.BOOT_DLC, READ_CFG_COMMAND_TX);
                }
                ReadAndReplaceConfigFile(cfg_array);
            /*}
            else
            {
                MessageBox.Show("Timeout error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
        private void SaveOutputCfgFile_Click(object sender, EventArgs e)
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

        private void Config_Reader_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeneralProgramClass.FormActive_CFG_Creator = false;
        }
    }
}
