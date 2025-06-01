using Microsoft.WindowsAPICodePack.Taskbar;
using Peak.Can.Basic;
using Peak.Can.Basic.BackwardCompatibility;
using System.Collections;
using System.Diagnostics;
using System.IO.Ports;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using static NXPBugger.GeneralProgramClass;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NXPBugger
{
    public static class CanbusClass
    {
        public static string[] baudrates = { "125K", "250K", "500K", "1000K" };
        public static PcanStatus result;
        public static PcanChannel channel = PcanChannel.Usb01;
        public static PcanMessage CanTXMessage = new PcanMessage();
        public static PcanMessage CanRXMessage = new PcanMessage();
        public static uint BOOT_ID = 0x5166;
        public static uint BOOT_WAKE_ID = 0x5165;
        public static MessageType BOOT_MSGTYP = MessageType.Extended;
        public static uint BOOT_DLC = 8;
        public static bool IsCanOpen = false;
        private static UInt16 BOOT_CCITT_KEY = 0xCEFA;
        private static byte[] BOOT_RECV_BYTE = new byte[8];
        public static readonly byte[] START_BL_TX = Encoding.ASCII.GetBytes("BSTT");
        public static readonly byte[] START_BL_RX = Encoding.ASCII.GetBytes("BSTD");
        private static readonly byte[] START_MSG_CFG = Encoding.ASCII.GetBytes("!CFG");
        private static readonly byte[] START_MSG_APP = Encoding.ASCII.GetBytes("!APP");
        private static readonly byte[] READY_MSG = Encoding.ASCII.GetBytes("!STR");
        private static readonly byte[] NEXT_MSG = Encoding.ASCII.GetBytes("!NXT");
        private static readonly byte[] END_MSG = Encoding.ASCII.GetBytes("!JMP");

        public static byte[] WakeUpData = new byte[8];


        public static bool CanConnect(PcanChannel PcanChannel, string BaudRate)
        {
            try
            {
                if (BaudRate == "125K")
                {
                    result = Api.Initialize(PcanChannel, Bitrate.Pcan125);
                }
                else if (BaudRate == "250K")
                {
                    result = Api.Initialize(PcanChannel, Bitrate.Pcan250);
                }
                else if (BaudRate == "500K")
                {
                    result = Api.Initialize(PcanChannel, Bitrate.Pcan500);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool CanDisconnect(PcanChannel PcanChannel)
        {
            try
            {
                Api.Uninitialize(PcanChannel);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool CanTransmit(PcanChannel PcanChannel, uint ID, MessageType MSG_FRMT, uint DLC, byte[] data)
        {
            CanTXMessage.ID = ID;
            CanTXMessage.MsgType = MSG_FRMT;
            CanTXMessage.DLC = (byte)DLC;
            for (int i = 0; i < DLC; i++)
            {
                CanTXMessage.Data[i] = data[i];
            }
            Api.Write(PcanChannel, CanTXMessage);
            return true;
        }

        public static void CanReplace(PcanMessage CANMSG, TextBox CAN_ID, TextBox CAN_DLC,
                              TextBox CAN_D1, TextBox CAN_D2, TextBox CAN_D3, TextBox CAN_D4,
                              TextBox CAN_D5, TextBox CAN_D6, TextBox CAN_D7, TextBox CAN_D8)
        {
            CAN_ID.Text = CANMSG.ID.ToString("X");
            CAN_DLC.Text = CANMSG.DLC.ToString();

            CAN_D1.Text = CANMSG.Data[0].ToString("X2");
            CAN_D2.Text = CANMSG.Data[1].ToString("X2");
            CAN_D3.Text = CANMSG.Data[2].ToString("X2");
            CAN_D4.Text = CANMSG.Data[3].ToString("X2");
            CAN_D5.Text = CANMSG.Data[4].ToString("X2");
            CAN_D6.Text = CANMSG.Data[5].ToString("X2");
            CAN_D7.Text = CANMSG.Data[6].ToString("X2");
            CAN_D8.Text = CANMSG.Data[7].ToString("X2");
        }

        public static bool CanReceive(PcanChannel PcanChannel, uint ID, MessageType MSG_FRMT, uint DLC, byte[] data, uint timeoutMs=0, bool InfiniteLoop = false)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            while (stopwatch.ElapsedMilliseconds < timeoutMs)
            {
                if (Api.Read(PcanChannel, out CanRXMessage) == PcanStatus.OK)
                {
                    if(InfiniteLoop) CanReplace(CanRXMessage, NXPBuggerv1.CanDatasRXID, NXPBuggerv1.CanDatasRXDLC, NXPBuggerv1.CanDatasRXD1, NXPBuggerv1.CanDatasRXD2, NXPBuggerv1.CanDatasRXD3, NXPBuggerv1.CanDatasRXD4, NXPBuggerv1.CanDatasRXD5, NXPBuggerv1.CanDatasRXD6, NXPBuggerv1.CanDatasRXD7, NXPBuggerv1.CanDatasRXD8);
                    if (CanRXMessage.ID != ID || CanRXMessage.MsgType != MSG_FRMT || CanRXMessage.DLC != DLC)
                        continue;

                    int length = Math.Min(CanRXMessage.DLC, data.Length);
                    Array.Copy(CanRXMessage.Data, data, length);
                    return true;
                }
                //Thread.Sleep(1);
            }
            return false;
        }

        public static bool CanBootloaderStart(PcanChannel PcanChannel, string filePath, ProgressBar pb, Button SW_UPD_BUTTON, Label TIME_LABEL, ref bool Kill_Thread_Status)
        {
            try
            {
                CanFastFlash canFastFlash = CanFastFlash.Disable;
                CanMode canMode = CanMode.Write;
                CanFlashArea canFlashArea = CanFlashArea.Config;
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                pb.Enabled = true;
                SW_UPD_BUTTON.Text = "Software Update Started!";
                SW_UPD_BUTTON.Enabled = false;
                switch (GeneralProgramClass.ModeForUpload)
                {
                    case GeneralProgramClass.UploadMode.CONFIG:
                        {
                            canFlashArea = CanFlashArea.Config;
                            WakeUpData = CreateBootMessage(canFastFlash, canMode, canFlashArea, 0, START_MSG_CFG);
                            CanTransmit(PcanChannel, BOOT_WAKE_ID, BOOT_MSGTYP, BOOT_DLC, WakeUpData);
                            if (WaitForMessage(PcanChannel, READY_MSG, 5000) != CanMessageState.OK)
                            {
                                return false;
                            }
                            SW_UPD_BUTTON.Text = "Software Update Mode : Config";
                            break;
                        }
                    case GeneralProgramClass.UploadMode.PROGRAM:
                        {
                            canFlashArea = CanFlashArea.Application;
                            WakeUpData = CreateBootMessage(canFastFlash, canMode, canFlashArea, 0, START_MSG_APP);
                            CanTransmit(PcanChannel, BOOT_WAKE_ID, BOOT_MSGTYP, BOOT_DLC, WakeUpData);
                            if (WaitForMessage(PcanChannel, READY_MSG, 5000) != CanMessageState.OK)
                            {
                                return false;
                            }
                            SW_UPD_BUTTON.Text = "Software Update Mode : Program";
                            break;
                        }
                }

                byte[][] fileChunks = ReadBinFile(filePath, canFastFlash, canMode, canFlashArea);
                int totalChunks = fileChunks.Length;

                for (int i = 0; i < totalChunks; i++)
                {
                    if (Kill_Thread_Status)
                    {
                        Kill_Thread_Status = false;
                        return false;
                    }

                    byte[] packet = fileChunks[i];
                    CanTransmit(PcanChannel, BOOT_ID, BOOT_MSGTYP, BOOT_DLC, packet);

                    if (WaitForMessage(PcanChannel, NEXT_MSG, 5000) != CanMessageState.OK)
                    {
                        return false;
                    }
                    pb.Value += 4;
                    TaskbarManager.Instance.SetProgressValue(pb.Value, pb.Maximum);

                    //SW_UPD_BUTTON.Text = pb.Value/4 + " / " + pb.Maximum/4 + "flashed!";
                }
                SW_UPD_BUTTON.Text = pb.Maximum / 4 + "flashed!";
                Thread.Sleep(20);
                SW_UPD_BUTTON.Text = "Software Update Done";
                Thread.Sleep(20);
                CanTransmit(PcanChannel, BOOT_ID, BOOT_MSGTYP, BOOT_DLC, END_MSG);
                SW_UPD_BUTTON.Text = "Software Update Start";
                SW_UPD_BUTTON.Enabled = true;
                pb.Enabled = false;
                pb.Value = 0;
                MessageBox.Show("Software Update Successful!", "Software Update Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
                MessageBox.Show("Software Update Error!", "Software Update Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                pb.Value = 0;
                pb.Enabled = false;
                SW_UPD_BUTTON.Text = "Software Update Start";
                SW_UPD_BUTTON.Enabled = true;
                Kill_Thread_Status = false;
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
            }
        }
        public static CanMessageState WaitForMessage(PcanChannel PcanChannel, byte[] expectedMsg, uint Timeout)
        {
            if (!CanReceive(PcanChannel, BOOT_ID, BOOT_MSGTYP, BOOT_DLC, BOOT_RECV_BYTE, Timeout, true))
            {
                return CanMessageState.TIMEOUT;
            }
            if (Compare(BOOT_RECV_BYTE, expectedMsg, 8))
            {
                return CanMessageState.OK;
            }
            else
            {
                return CanMessageState.ERROR;
            }
        }

        private static byte[][] ReadBinFile(string filePath, CanFastFlash FastFlash, CanMode FlashCmd, CanFlashArea FlashArea)
        {
            int DataIndexController = 0;
            byte[] fileData = File.ReadAllBytes(filePath);
            int chunkSize = 4;
            int totalChunks = (fileData.Length + chunkSize - 1) / chunkSize;

            byte[][] chunks = new byte[totalChunks][];

            for (int i = 0; i < totalChunks; i++)
            {
                byte[] chunk = fileData.Skip(i * chunkSize).Take(chunkSize).ToArray();

                if (chunk.Length < chunkSize)
                {
                    Array.Resize(ref chunk, chunkSize);
                }
                DataIndexController = DataIndexController > 1 ? 0 : 1;
                chunks[i] = CreateBootMessage(FastFlash, FlashCmd, FlashArea, DataIndexController, chunk);
            }
            return chunks;
        }

        public static byte[] CreateBootMessage(CanFastFlash FastFlash, CanMode FlashCmd, CanFlashArea FlashArea, int FlashIndex, byte[] FlashData)
        {
            byte CMD = (byte)((int)FastFlash + (((int)FlashCmd)<<1) + (((int)FlashArea)<<2) + 1<<7);
            byte[] data = new byte[8] { CMD, (byte)FlashIndex, FlashData[0], FlashData[1], FlashData[2], FlashData[3], 0x00, 0x00 };
            byte[] CRC = CalculateCRC(data, 6);
            data[6] = CRC[0]; 
            data[7] = CRC[1];
            return data;
        }
        private static byte[] CalculateCRC(byte[] data, uint Length)
        {
            const ushort poly = 4129;
            ushort[] table = new ushort[256];
            ushort initialValue = BOOT_CCITT_KEY;
            ushort temp, a;
            ushort crc = initialValue;
            for (int i = 0; i < table.Length; ++i)
            {
                temp = 0;
                a = (ushort)(i << 8);
                for (int j = 0; j < 8; ++j)
                {
                    if (((temp ^ a) & 0x8000) != 0)
                        temp = (ushort)((temp << 1) ^ poly);
                    else
                        temp <<= 1;
                    a <<= 1;
                }
                table[i] = temp;
            }
            for (int i = 0; i < Length; ++i)
            {
                crc = (ushort)((crc << 8) ^ table[((crc >> 8) ^ (0xFF & data[i]))]);
            }
            byte[] CRC_CCITT = new byte[2];
            CRC_CCITT[0] = (byte)(crc >> 8);
            CRC_CCITT[1] = (byte)(crc & 0xFF);
            return CRC_CCITT;
        }

        private static bool Compare(byte[] Value_1, byte[] Value_2, uint Length)
        {
            for(int i=0;i<Length;i++)
            {
                if (Value_1[i] != Value_2[i]) return false;
            }
            return true;
        }

    }
}
