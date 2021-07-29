using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections;
using System.Threading;


namespace MainSender
{

    public static class PublicUartSet
    {
        /// <summary>
        /// 这里保存串口的接收数据用于解析
        /// </summary>
        public static Queue RDQue = new Queue();
        /// <summary>
        /// 这里保存串口的接收数据用于显示
        /// </summary>
        public static List<string> logs = new List<string>();


        /// <summary>
        /// 这里保存日志显示
        /// </summary>
        public static List<string> logs_task = new List<string>();

        
        public static int ProgressValue = 0;

        /// <summary>
        /// 串口接口
        /// </summary>
        public static SerialPort MainUsart { get; set; } = new SerialPort();

        // 串口的打开状态标记位
        public static bool ConnectState { get; set; }

        public static bool ConnectChange { get; set; }


        public enum result { NO_ERROR = 3, IDLE= 0, FAIL = 1, IN_PROCESS = 2 }
        public static byte ConnectTaskSta { get; set; }

        public static string ConnectCom { get; set; }
        public static string ConnectBaudRate { get; set; }
        public static string ConnectParity { get; set; }
        public static string ConnectDataBits { get; set; }
        public static string ConnectStopBits { get; set; }

        // 数据状态
        public static int sendCount = 0;    // 发送数据量
        public static int receCount = 0;    // 接收数据量

        public static long ThreadTick = 0;

        public static byte temp_channal = 0;

        public static Int16 temp_base = 0;

        public static byte[]  OTA_Buff  {get; set;  }
        public static string OTA_Version { get; set; }
    }
        /// <summary>
        /// 在这里实现串口的数据接收和发送
        /// </summary>

    public class ComFun
    {
        private long DelayTime = 0;
        private object RXLock = new object();    // 锁住线程

        public string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                    returnStr += " ";
                }
            }
            return returnStr;

        }
        /// <summary>
        /// 数据接收
        /// </summary>
        public  void ComReadData()
        {
         

            //while (PublicUartSet.ConnectState)
            {
                //lock (RXLock)   // 锁住串口
                {
                    Thread.Sleep(50); // 以50ms一个周期，进行串口数据接收，不能太快，不然会出现拆包的现象
                    try
                    {
                        // 查询串口中目前保存了多少数据
                        int n = PublicUartSet.MainUsart.BytesToRead;

                        // 读取数据
                        byte[] buf = new byte[n];
                        PublicUartSet.MainUsart.Read(buf, 0, n);

                        // 打印数据
                        if (buf.Length > 0)
                        {
                            PublicUartSet.RDQue.Enqueue(buf);

                            PublicUartSet.receCount += buf.Length;
                            PublicUartSet.logs.Add("R");
                            PublicUartSet.logs.Add(byteToHexStr(buf));
                            
                            PublicUartSet.MainUsart.DiscardInBuffer();

                        
                        }
                    }
                    catch
                    {
                        PublicUartSet.ConnectState = false;
                        PublicUartSet.MainUsart.Close();
                        //MessageBox.Show("串口接收失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        public void ComWrite(byte[] data)
        {

            try
            {
                if (PublicUartSet.ConnectState && data != null)
                {
                    PublicUartSet.MainUsart.Write(data, 0, data.Length);

                    PublicUartSet.sendCount += data.Length;
                    PublicUartSet.logs.Add("T");
                    PublicUartSet.logs.Add(byteToHexStr(data));

                }
}
            catch
            {
                MessageBox.Show("串口发送失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public Int16 Usart_Send_And_Receive(byte[] txbuf , ref byte[] rxbuf, byte delay)
        {
            ComWrite(txbuf);
            DelayTime = PublicUartSet.ThreadTick;

            while ((PublicUartSet.ThreadTick - DelayTime) < delay)
            {
                ComReadData();
                if (PublicUartSet.RDQue.Count > 0)
                    break;
            }
            if (PublicUartSet.RDQue.Count == 0)
                return -1;
            rxbuf = (byte[])PublicUartSet.RDQue.Dequeue();
            return 0;
        }
    }
    
}
