using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MainSender
{
    public class TempTest
    {
        
        private static byte DELAY_TIME = 50;   //20*10 ms
        private static byte TEMP_ADDRESS = 0X26;
        private static byte TEMP_HEAD = 0XF5;
        private static byte GET_RETRY_COUNT = 4;


        private verify GetVerify = new verify();
        private ComFun mCom = new ComFun();
        public enum result { NO_ERROR = 0, FAIL = 1, IN_PROCESS = 2 }
        public static byte[] CMD_handshake =      { TEMP_HEAD, TEMP_ADDRESS, 0x04, 0, 2, 0xAA, 0x55, 0x20 };
        public static byte[] CMD_temp_strat_get = { TEMP_HEAD, TEMP_ADDRESS, 0xBF, 0x00, 0x0C, 0x84, 0x00, 0x00, 0x00, 0x01 ,
                                                    0x31, 0x03, 0x00, 0x17, 0x70, 0x00, 0x00, 0x26 };
        public static byte[] CMD_temp_real_get =  { TEMP_HEAD, TEMP_ADDRESS, 0xBF, 0x00, 0x0C, 0xA4, 0x00, 0x00, 0x00, 0x01,
                                                    0x31, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xBC };

        private  byte[] RDbuff =  {0}; 
        private byte[] UserInfo;
        private float temp_value_real;
        private int temp_value;
        public void temperature_get()
        {
            byte i = 0;
            //PublicUartSet.RDQue.Clear();
            PublicUartSet.ConnectTaskSta = 0;
            Array.Clear(RDbuff, 0, RDbuff.Length);
            while (PublicUartSet.ConnectState)
            {

                if (mCom.Usart_Send_And_Receive(CMD_handshake, ref RDbuff, DELAY_TIME) < 0)
                {
                    show_fail();
                    break;
                }
                else
                {

                    if (RDbuff[RDbuff.Length-1] != GetVerify.CheckSum(RDbuff, RDbuff.Length - 1))
                    {
                        show_fail();
                        break;
                    }
                    if((RDbuff [0] == TEMP_HEAD)&&(RDbuff[1] == TEMP_ADDRESS))
                    {

                        UserInfo = RDbuff.Skip(7).Take(4).ToArray();
                        PublicUartSet.logs_task.Add("设备号： " + mCom.byteToHexStr(UserInfo));
                        UserInfo = RDbuff.Skip(11).Take(1).ToArray();
                        PublicUartSet.logs_task.Add("硬件版本：" + mCom.byteToHexStr(UserInfo));
                        UserInfo = RDbuff.Skip(12).Take(4).ToArray();
                     
                        PublicUartSet.logs_task.Add("软件版本：" + string.Join(".", UserInfo));
                        
                        PublicUartSet.logs_task.Add("传感器个数：" + PublicUartSet.temp_channal.ToString());

                        CMD_temp_strat_get[11] = (byte)(PublicUartSet.temp_channal - 1);
                        CMD_temp_strat_get[CMD_temp_strat_get.Length - 1] = GetVerify.CheckSum(CMD_temp_strat_get,CMD_temp_strat_get.Length - 1);
                        
                        if (mCom.Usart_Send_And_Receive(CMD_temp_strat_get, ref RDbuff, (byte)(DELAY_TIME )) < 0)
                        {
                            show_fail();
                            break;
                        }
                        if (RDbuff[RDbuff.Length - 1] != GetVerify.CheckSum(RDbuff, RDbuff.Length - 1))
                        {
                            show_fail();
                            break;
                        }
                        for ( i = 0; i < GET_RETRY_COUNT; i++)
                        {
                            Thread.Sleep(250);
                            if (mCom.Usart_Send_And_Receive(CMD_temp_real_get, ref RDbuff, (byte)(DELAY_TIME)) < 0)                          
                                continue;                         
                            if (RDbuff[RDbuff.Length - 1] != GetVerify.CheckSum(RDbuff, RDbuff.Length - 1))
                                continue;
                            if (RDbuff[9] != 0x03)
                                continue;
                            for (Byte j = 1; j <= RDbuff[25]; j++)
                            {
                                UserInfo = RDbuff.Skip(27 + j * 2).Take(2).ToArray();
                                temp_value = (Int16)UserInfo[0] << 8 | UserInfo[1];
                                temp_value_real = (float)temp_value / 100;
                                
                                if ((temp_value_real <= PublicUartSet.temp_base + 5) && (temp_value_real >= PublicUartSet.temp_base - 5))
                                    PublicUartSet.logs_task.Add("第" + j.ToString() + "路温度: " + temp_value_real.ToString("f1") + "℃");
                                else
                                    PublicUartSet.logs_task.Add("第" + j.ToString() + "路温度: " + temp_value_real.ToString("f1") + "℃" + "  超出范围");
                            } 
                                              
                            break;
                            
                        }
                        if (i >= GET_RETRY_COUNT)
                        {
                            show_fail();
                            break;

                         }
                        show_success();



                    }
                    show_fail();
                    break;

                }
            }

             void show_fail()
            {   

                PublicUartSet.logs_task.Add("—————————————————");
                PublicUartSet.logs_task.Add("FAIL !!!");
                PublicUartSet.ConnectTaskSta = (byte)PublicUartSet.result.FAIL;

            }
            void show_success()
            {
                PublicUartSet.logs_task.Add("—————————————————");
                PublicUartSet.logs_task.Add("PASS!!!");
                PublicUartSet.ConnectTaskSta = (byte)PublicUartSet.result.NO_ERROR;

            }

        }


    }
}
