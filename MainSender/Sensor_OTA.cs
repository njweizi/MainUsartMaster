using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MainSender
{
    class Sensor_OTA
    {

        private static byte   DELAY_TIME = 50;   //20*10 ms
        private static byte   OTA_ADDRESS = 0X26;
        private static byte   OTA_HEAD = 0XF5;
        private static byte   GET_RETRY_COUNT = 4;
        private static byte   UNIT_RETRY_COUNT = 1;
        private static ushort PACK_UINT_LENGTH = 256;

        private verify GetVerify = new verify();
        private ComFun mCom = new ComFun();
        public enum result { NO_ERROR = 0, FAIL = 1, IN_PROCESS = 2 }
        public static byte[] CMD_OTA_0X10 =     { OTA_HEAD ,OTA_ADDRESS ,0xBF ,0x00 ,0x1E ,0x84 ,0x00 ,0x00, 0x00, 0x01 ,               //9
                                                                         0x10, 0x03 ,0x00, 0x27, 0x10, 0x00 ,0x12 ,0x00 ,0x00 ,0x00 ,   //19
                                                                         0x00, 0x01 ,0x00 ,0x01 ,0x00, 0x00 ,0x00, 0xAA, 0xAA ,0xB9 ,   //29
                                                                         0x05 ,0x0E ,0x10 ,0x00 ,0x00, 0x00 };
        public static byte[] CMD_OTA_0X11 = { OTA_HEAD ,OTA_ADDRESS ,0xBF ,0x01 ,0x16 ,0x84 ,0x00 ,0x00, 0x00, 0x01 ,               //9
                                                                               0x11, 0x03 ,0x00, 0x0B, 0xB8, 0x01 ,0x0A ,0x00 ,0xAA ,0x00 ,   //19
                                                                               0x00, 0xFF ,0xFF ,0xAA ,0xAA };
        public static byte[] CMD_OTA_0X112 = new byte[512]; 
        public static byte[] CMD_OTA_QUERY =    { OTA_HEAD ,OTA_ADDRESS ,0xBF ,0x00 ,0x0C ,0xA4 ,0x00 ,0x00, 0x00, 0x01 ,0x11, 0x00, 
                                                                         0x00, 0x00, 0x00, 0x00, 0x00, 0x9C };

        private byte[] RDbuff = { 0 };
        private byte[] OTA_buff_uint = new byte[256] ;
        
        private UInt16 CRC_check;
        private static UInt16 Pack_Count_all = 0, Pack_Count_now = 0;
        private UInt32 file_length;
        private UInt16 pack_length , pack_length_all;
        private byte[] vrTemp;
        private byte   count;

        public void ota_task()
        {
            if (ota_0x10() < 0)
            {
                show_download_fail();
                return;
            }

            if (ota_0x11() < 0)
            {
                show_download_fail();
                return;
            }

        }


        public int ota_0x10()
        {
            CMD_OTA_0X10[5] = 0x84;
            //channal num
            CMD_OTA_0X10[11] = (byte)(PublicUartSet.temp_channal - 1);
            //version
            vrTemp = System.Text.Encoding.Default.GetBytes(PublicUartSet.OTA_Version);
            for (byte i = 0 ;i<4 ;i++)
                CMD_OTA_0X10[17 + i] = (byte)(vrTemp[i] - 0x30);
            //crc
            CRC_check = GetVerify.CRC16Caculate(PublicUartSet.OTA_Buff, PublicUartSet.OTA_Buff.Length);
            CMD_OTA_0X10[29] = (byte)(CRC_check >> 8);
            CMD_OTA_0X10[30] = (byte)(CRC_check);
            //pack len
            file_length = (UInt32)PublicUartSet.OTA_Buff.Length;
            CMD_OTA_0X10[25] = (byte)(file_length >> 24);
            CMD_OTA_0X10[26] = (byte)(file_length >> 16);
            CMD_OTA_0X10[27] = (byte)(file_length >> 8);
            CMD_OTA_0X10[28] = (byte)(file_length );
            CMD_OTA_0X10[35] = GetVerify.CheckSum(CMD_OTA_0X10, CMD_OTA_0X10.Length - 1);

            if (mCom.Usart_Send_And_Receive(CMD_OTA_0X10, ref RDbuff, DELAY_TIME) == 0)
            {
                if (RDbuff[RDbuff.Length - 1] != GetVerify.CheckSum(RDbuff, RDbuff.Length - 1))
                {
                    return -1;
                }
                if ((RDbuff[0] == OTA_HEAD) && (RDbuff[1] == OTA_ADDRESS))
                {
                    if (RDbuff[5] == 0xC4)
                    {
                        CMD_OTA_0X10[5] = 0xA4;
                        CMD_OTA_0X10[35] = GetVerify.CheckSum(CMD_OTA_0X10, CMD_OTA_0X10.Length - 1);
                        for (byte i = 0; i < GET_RETRY_COUNT + 10; i++)
                        {
                            Thread.Sleep(250);
                            if (mCom.Usart_Send_And_Receive(CMD_OTA_0X10, ref RDbuff, (byte)(DELAY_TIME)) < 0)
                                continue;
                            if (RDbuff[RDbuff.Length - 1] != GetVerify.CheckSum(RDbuff, RDbuff.Length - 1))
                                continue;
                            if (RDbuff[5] != 0xD4)
                                continue;
                            if(RDbuff[12] != (byte)(PublicUartSet.temp_channal - 1))
                                continue;
                            for(byte j = 0; j< RDbuff[34];j++)
                            {
                                if (RDbuff[35 + j] != 0X10)
                                    return -3;                                 
                            }
                            return 0;
                        }
                        return -2;
                    }
                    else
                        return -1;

                }
            }
            return -1;
        }

        public int ota_0x11()
        {
            //channal num
            CMD_OTA_0X11[11] = (byte)(PublicUartSet.temp_channal - 1);

            Pack_Count_all = (ushort)(PublicUartSet.OTA_Buff.Length / PACK_UINT_LENGTH);
            if (PublicUartSet.OTA_Buff.Length % PACK_UINT_LENGTH != 0)
                Pack_Count_all += 1;

            CMD_OTA_0X11[17] = (byte)(Pack_Count_all >> 8);
            CMD_OTA_0X11[18] = (byte)(Pack_Count_all);

            PublicUartSet.logs_task.Add("升级开始 ");
            PublicUartSet.logs_task.Add("升级总包数：" + Pack_Count_all.ToString());

            PublicUartSet.logs_task.Add("下载中...... ");
            
            for (byte i = 0; i < Pack_Count_all; i++)
            {
                for (count = 0; count < UNIT_RETRY_COUNT; count++)
                {
                    if (ota_0x11_uint() < 0)
                        continue;
                    Thread.Sleep(100);
                    Pack_Count_now++;
                    PublicUartSet.ProgressValue = (int) (float)Pack_Count_now * 100 / Pack_Count_all;
                    break;
                }
                if (count >= UNIT_RETRY_COUNT)
                    return -1;
               
            }
            

            return 0;

        }

        public int ota_0x11_uint()
        {

            if (Pack_Count_now < Pack_Count_all -1)
            {
                pack_length = PACK_UINT_LENGTH;
                System.Buffer.BlockCopy(PublicUartSet.OTA_Buff, Pack_Count_now * PACK_UINT_LENGTH, OTA_buff_uint, 0, pack_length);
            }
            else
            {
                pack_length = (ushort)(PublicUartSet.OTA_Buff.Length % PACK_UINT_LENGTH);
                System.Buffer.BlockCopy(PublicUartSet.OTA_Buff, Pack_Count_now * PACK_UINT_LENGTH, OTA_buff_uint, 0, pack_length);
            }
            pack_length_all = (ushort)(pack_length + 22);

            CMD_OTA_0X11[3] = (byte)(pack_length_all >> 8);
            CMD_OTA_0X11[4] = (byte)(pack_length_all);
                                                                               
            

            CMD_OTA_0X11[19] = (byte)(Pack_Count_now >> 8);
            CMD_OTA_0X11[20] = (byte)(Pack_Count_now);

            CRC_check = GetVerify.CRC16Caculate(OTA_buff_uint, pack_length);

            CMD_OTA_0X11[21] = (byte)(CRC_check >> 8);
            CMD_OTA_0X11[22] = (byte)(CRC_check);

            CMD_OTA_0X11[23] = (byte)(pack_length >> 8);
            CMD_OTA_0X11[24] = (byte)(pack_length);

            Array.Resize(ref CMD_OTA_0X11, pack_length_all + 6);


            System.Buffer.BlockCopy(OTA_buff_uint, 0, CMD_OTA_0X11, 25, pack_length);
            CMD_OTA_0X11[pack_length + 25] = 0x00;
            CMD_OTA_0X11[pack_length + 26] = 0x00;
            CMD_OTA_0X11[pack_length + 27] = GetVerify.CheckSum(CMD_OTA_0X11, pack_length_all + 5);

            if (mCom.Usart_Send_And_Receive(CMD_OTA_0X11, ref RDbuff, DELAY_TIME) < 0)
            {               
                return -1;
            }
            if (RDbuff[RDbuff.Length - 1] != GetVerify.CheckSum(RDbuff, RDbuff.Length - 1))
            {                
                return -1;
            }
            if ((RDbuff[0] == OTA_HEAD) && (RDbuff[1] == OTA_ADDRESS))
            {
                if ((RDbuff[5] == 0xC4) && (RDbuff[9] == 0x02))
                {
                    for (byte i = 0; i < GET_RETRY_COUNT; i++)
                    {
                        Thread.Sleep(250);
                        if (mCom.Usart_Send_And_Receive(CMD_OTA_QUERY, ref RDbuff, (byte)(DELAY_TIME)) < 0)
                            continue;
                        if (RDbuff[RDbuff.Length - 1] != GetVerify.CheckSum(RDbuff, RDbuff.Length - 1))
                            continue;
                        if (RDbuff[5] != 0xD4)
                            continue;
                        if (RDbuff[12] != (byte)(PublicUartSet.temp_channal - 1))
                            continue;
                        for (byte j = 0; j < RDbuff[12]; j++)
                        {
                            int k = (RDbuff.Length - 2 - RDbuff[12] + j);
                            if (RDbuff[k] != 0X00)
                                return -3;
                        }
                        return 0;
                    }
                    return -3;
                }
                else
                    return -1;
            }
            else
                return -1;
        }
        public void ota_0x12()
        {
           
        }
        public void ota_0x13()
        {
            ;
        }

        void show_download_fail()
        {
            PublicUartSet.logs_task.Add("—————————————————");
            PublicUartSet.logs_task.Add("下载失败 !!!");
            PublicUartSet.ConnectTaskSta = (byte)PublicUartSet.result.FAIL;

        }
        void show_download_success()
        {
            PublicUartSet.logs_task.Add("—————————————————");
            PublicUartSet.logs_task.Add("下载完成 请手动重启设备");
            PublicUartSet.ConnectTaskSta = (byte)PublicUartSet.result.NO_ERROR;

        }

        void show_OTA_success()
        {
            PublicUartSet.logs_task.Add("—————————————————");
            PublicUartSet.logs_task.Add("升级成功");
            PublicUartSet.ConnectTaskSta = (byte)PublicUartSet.result.NO_ERROR;

        }
    }
}


