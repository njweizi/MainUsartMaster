using System;
using System.Drawing;
using System.IO;   // 导入输入输出文件框
using System.IO.Ports;   // 串口模块
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;

namespace MainSender
{
    // 解决线程访问问题
    public delegate void SerialPortEventHandler(Object sender, SerialPortEventArgs e);    // 定义委托

    
    public partial class SerialDebug : Form
    {
        private ComFun mCom = new ComFun();
        private TempTest tempTestFun = new TempTest();
        private Sensor_OTA sensor_OTA_Fun = new Sensor_OTA();
        private string FilePath = null;    // 打开文件路径

        private object thisLock = new object();    // 锁住线程
        private bool recTextBoxForcedDown = true;
         // public event SerialPortEventHandler comReceiveDataEvent = null;  // 定义串口接收数据响应事件

         public SerialDebug()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 串口初始化设置
        /// </summary>

        public void MainFormInitializeSerialSet()
        {
            MainFormInitializePorts();   // 初始化串口号
            // 初始化波特率
            comboBox_BandRate.Text = comboBox_BandRate.Items[6].ToString();
            //初始化默认参数
            PublicUartSet.ConnectCom = "None";
            PublicUartSet.ConnectDataBits = "8";
            PublicUartSet.ConnectParity =   "None";
            PublicUartSet.ConnectStopBits = "1";
            PublicUartSet.ConnectBaudRate = "115200";
        }
        /// <summary>
        /// 可用串口扫描，并且显示
        /// </summary>
        public void MainFormInitializePorts()
        {
            comboBox_Serial.Items.Clear();   // 清空原来的信息
            comboBox_Serial.Text = "None";
            // 返回可用串口号，形式：COM3
            string[] arraysPostsNames = SerialPort.GetPortNames();  // 获取所有可用的串口号

            // 检查串口号是否正确
            if (arraysPostsNames.Length > 0)
            {
                
                Array.Sort(arraysPostsNames);  // 使用默认进行排序，从小到大
                Array.Reverse(arraysPostsNames);  //翻转
                for (int i = 0; i < arraysPostsNames.Length; i++)
                {
                    comboBox_Serial.Items.Add(arraysPostsNames[i]);  // 将所有可用串口加载到串口显示框当中
                }
                comboBox_Serial.Text = arraysPostsNames[0];   // 默认选择第一个串口
                if (PublicUartSet.ConnectState == false)
                    comboBox_Serial.Enabled = true;   // 打开选择框
                                                  // 设置状态栏属性
                toolStripStatus_Port.Text = "串口号：" + comboBox_Serial.Text;  // 设置状态栏的情况                   
                toolStripStatus_Port.ForeColor = Color.Black; // 设置为
                button_OK.Enabled = true ;
            }
            else
            {
                toolStripStatus_Port.Text = "没有可用串口";  // 设置状态栏的情况                   
                toolStripStatus_Port.ForeColor = Color.Red; // 设置为红色
                comboBox_Serial.Text = "None";   // 提示没有可用串口
                PublicUartSet.ConnectCom = "None";
                comboBox_Serial.Enabled = false;   // 禁止打开串口选择框
                button_OK.Enabled = false;
            }
        }


        /// <summary>
        /// 串口读取数据响应方法
        /// </summary>
        /// <param name="e"></param>
 /*       private void serialPortMonitor_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            ReceiveData();
        }*/

        private void SerialDebug_Load(object sender, EventArgs e)
        {
            MainFormInitializeSerialSet();
            //comReceiveDataEvent += new SerialPortEventHandler(ComReceiveDataEvent);  // 订阅事件
            toolStripStatus_Time.Text = "时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  // 显示当前时间
        }

        public void ComReceiveDataEvent(Object sender, SerialPortEventArgs e)
        {

            if (this.InvokeRequired)
            {
                try
                {
                    Invoke(new Action<Object, SerialPortEventArgs>(ComReceiveDataEvent), sender, e);
                }
                catch (Exception)
                {

                }
                return;
            }


            if (richTextBox_Receive.Text.Length > 0)
            {
                richTextBox_Receive.AppendText("\n");  // 中间使用 隔开，也可以使用-隔开
                richTextBox_Receive.AppendText("●");
            }
            richTextBox_Receive.AppendText(System.Text.Encoding.Default.GetString(e.receivedBytes));

        }
        /// <summary>
        /// 串口选择框改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Select_Ports_Change(object sender, EventArgs e)
        {
            // 设置状态栏属性
            toolStripStatus_Port.ForeColor = Color.Black; // 设置为黑色
        }
        /// <summary>
        /// 更新状态栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_StatusTime(object sender, EventArgs e)
        {
      
            toolStripStatus_Time.Text = "时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  // 显示当前时间 
            if(PublicUartSet.ConnectChange == false)
                return;
            PublicUartSet.ConnectChange = false;
            comboBox_Serial.Text = PublicUartSet.ConnectCom;
            comboBox_BandRate.Text = PublicUartSet.ConnectBaudRate;            
            
        }
        /// <summary>
        /// 保存文件加载方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDataSend = new SaveFileDialog();
            saveDataSend.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   // 获取文件路径
            saveDataSend.Filter = "*.txt|txt file";   // 文本文件
            saveDataSend.DefaultExt = ".txt";   // 默认文件的形式
            saveDataSend.FileName = "SendData.txt";   // 文件默认名

            if (saveDataSend.ShowDialog() == DialogResult.OK)   // 显示文件框，并且选择文件
            {
                FilePath = saveDataSend.FileName;   // 获取文件名
                // 参数1：写入文件的文件名；参数2：写入文件的内容
                try
                {
                    //System.IO.File.WriteAllText(FilePath, richTextBox_Send.Text);   // 向文件中写入内容
                }
                catch
                {
                    MessageBox.Show("保存文件失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }

            }

        }
        /// <summary>
        /// 选择发送文件响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OTA_Click(object sender, EventArgs e)
        {
            PublicUartSet.RDQue.Clear();
            PublicUartSet.temp_channal = Convert.ToByte(comboBox_channal_num.Text);
            PublicUartSet.ProgressValue = 0;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;   // 是否可以选择多个文件
            fileDialog.Title = "请选择文件";     // 标题
            fileDialog.Filter = "bin文件(*.bin*)|*.bin*";   // 显示所有文件
            if (fileDialog.ShowDialog() == DialogResult.OK)   // 打开文件选择框
            {
                FilePath = System.IO.Path.GetFileNameWithoutExtension(fileDialog.FileName);//文件名没有扩展名
                if (FilePath.Contains("SMART-GF") && (FilePath.Contains("TempSensor")))
                {
                    try
                    {
                        PublicUartSet.OTA_Version = FilePath.Substring(0, FilePath.LastIndexOf("v") + 1);
                        PublicUartSet.OTA_Version = FilePath.Replace(PublicUartSet.OTA_Version, "");
                        PublicUartSet.OTA_Version = PublicUartSet.OTA_Version.Replace(".", "");
                    }
                    catch
                    {
                        MessageBox.Show("版本格式异常！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    richTextBox_Receive.Text = fileDialog.FileName;   // 在窗口中显示文件路径
                    ReadFile(fileDialog.FileName);   // 将文件内容显示在发送框当中
                }
                else
                    richTextBox_Receive.Text = "文件名错误,请重新选择 !!!!";
            }
            
            
        }

        /// <summary>
        /// 将文件内容显示在发送数据显示框中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public bool ReadFile(string filepath)
        {
            try
            {
                if (filepath == null || filepath.Trim() == "")  //文件存在
                {
                    return false;
                }

                PublicUartSet.OTA_Buff = File2Bytes(filepath);
                /*   PublicUartSet.logs.Add("T");
                   PublicUartSet.logs.Add(mCom.byteToHexStr(PublicUartSet.OTA_Buff));*/

                new Thread(sensor_OTA_Fun.ota_task) { IsBackground = true }.Start();
                return true;


            }
            catch (Exception)
            {

                MessageBox.Show("导入失败！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

        }

        /// <summary>
        /// 将文件转换为byte数组
        /// </summary>
        /// <param name="path">文件地址</param>
        /// <returns>转换后的byte数组</returns>
        public static byte[] File2Bytes(string path)
        {
            if (!File.Exists(path))
            {
                return new byte[0];
            }

            FileInfo fi = new FileInfo(path);
            byte[] buff = new byte[fi.Length];

            FileStream fs = fi.OpenRead();
            fs.Read(buff, 0, Convert.ToInt32(fs.Length));
            fs.Close();

            return buff;
        }

        /// <summary>
        /// 清除接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ClcReceData_Click(object sender, EventArgs e)
        {
            richTextBox_Receive.Text = "";   // 清空接收数据
            PublicUartSet.receCount = 0;
            toolStripStatus_recestatus.Text = "收到数据：" + PublicUartSet.receCount.ToString();

            PublicUartSet.sendCount = 0;
            toolStripStatus_sendstatus.Text = "发送数据：" + PublicUartSet.sendCount.ToString();
        }

        /// <summary>
        /// 保存发送数据，保存发送数据菜单响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_ReceData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDataSend = new SaveFileDialog();
            saveDataSend.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   // 获取文件路径
            saveDataSend.Filter = "*.txt|txt file";   // 文本文件
            saveDataSend.DefaultExt = ".txt";   // 默认文件的形式
            saveDataSend.FileName = "ReceData.txt";   // 文件默认名

            if (saveDataSend.ShowDialog() == DialogResult.OK)   // 显示文件框，并且选择文件
            {
                FilePath = saveDataSend.FileName;   // 获取文件名
                // 参数1：写入文件的文件名；参数2：写入文件的内容
                try
                {
                    System.IO.File.WriteAllText(FilePath, richTextBox_Receive.Text);   // 向文件中写入内容
                }
                catch
                {
                    MessageBox.Show("保存文件失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }

            }
        }
      
    

        /// <summary>
        /// 定时更新显示
        /// </summary>
        private void timerDisplay_Tick(object sender, EventArgs e)
        {
            TaskProgressBar.Value = PublicUartSet.ProgressValue;
            if (PublicUartSet.logs.Count >= 2)
            {
                if (PublicUartSet.logs[0] == "R")
                    LogTRX(PublicUartSet.logs[1],2);
                if (PublicUartSet.logs[0] == "T")
                    LogTRX(PublicUartSet.logs[1],1);
                PublicUartSet.logs.RemoveAt(0);

            }
            if ((PublicUartSet.logs_task.Count > 0)&&(PublicUartSet.ConnectTaskSta!=0))
            {
                LogTask(PublicUartSet.logs_task[0] , PublicUartSet.ConnectTaskSta);
                   
                PublicUartSet.logs_task.RemoveAt(0);
                button_temperatureTest.Enabled = true;
            }

        }

       /* public bool SendData(byte[] data)
        {
            if (PublicUartSet.MainUsart == null)
            {
                return false;
            }
            if (PublicUartSet.MainUsart.IsOpen == false)
            {
                return false;
            }

            try
            {
                
                PublicUartSet.MainUsart.Write(data, 0, data.Length);
                //string StringArray = string.Join(" ", data);
                LogTX(PublicUartSet.byteToHexStr(data));
                // 更新状态显示框
                PublicUartSet.sendCount += data.Length;
                toolStripStatus_sendstatus.Text = "发送数据：" + PublicUartSet.sendCount.ToString();
            }
            catch (Exception)
            {
                //提示信息
                MessageBox.Show("数据发送失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }*/

        /// <summary>
        /// 串口接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*public bool ReceiveData()
        {

            if (PublicUartSet.MainUsart == null)
            {
                return false;
            }
            if (PublicUartSet.MainUsart.IsOpen == false)
            {
                return false;
            }
            if (PublicUartSet.MainUsart.BytesToRead <= 0)   // 串口中没有数据
            {
                return false;
            }
            lock (thisLock)   // 锁住串口
            {
                int len = PublicUartSet.MainUsart.BytesToRead;
                byte[] data = new byte[len];
                try
                {
                    PublicUartSet.MainUsart.Read(data, 0, len);   // 向串口中读取数据
                }
                catch (Exception)
                {
                    MessageBox.Show("数据接收失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }


                SerialPortEventArgs args = new SerialPortEventArgs();
                args.receivedBytes = data;
                if (comReceiveDataEvent != null)
                {
                    comReceiveDataEvent.Invoke(this, args);
                }

            }


            return true;
        }*/



        private void button_Open_Click(object sender, EventArgs e)
        {

            ComOpen();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolMeu toolMeu = new ToolMeu();
            toolMeu.Show();
            MainFormInitializePorts();


        }
        /// <summary>
        /// 打开串口
        /// </summary>
        public void ComOpen()
        {
            if (PublicUartSet.MainUsart == null)
            {
                return;
            }

            if (PublicUartSet.MainUsart.IsOpen == false)
            {
                //PublicUartSet.MainUsart.PortName = PublicUartSet.ConnectCom;
                //PublicUartSet.MainUsart.BaudRate = Convert.ToInt32(PublicUartSet.ConnectBaudRate);
                if (comboBox_Serial.Text != "None")
                    PublicUartSet.ConnectCom = comboBox_Serial.Text;


                PublicUartSet.MainUsart.PortName = PublicUartSet.ConnectCom;          
                PublicUartSet.MainUsart.BaudRate = Convert.ToInt32(PublicUartSet.ConnectBaudRate);
                PublicUartSet.MainUsart.DataBits = Convert.ToInt32(PublicUartSet.ConnectDataBits);

                if(PublicUartSet.ConnectParity=="None") PublicUartSet.MainUsart.Parity = System.IO.Ports.Parity.None;
                if(PublicUartSet.ConnectParity == "Odd") PublicUartSet.MainUsart.Parity = System.IO.Ports.Parity.Odd;
                if(PublicUartSet.ConnectParity == "Even") PublicUartSet.MainUsart.Parity = System.IO.Ports.Parity.Even;

                if(PublicUartSet.ConnectDataBits == "1") PublicUartSet.MainUsart.StopBits = System.IO.Ports.StopBits.One;
                if (PublicUartSet.ConnectDataBits == "1.5") PublicUartSet.MainUsart.StopBits = System.IO.Ports.StopBits.OnePointFive;
                if (PublicUartSet.ConnectDataBits == "2") PublicUartSet.MainUsart.StopBits = System.IO.Ports.StopBits.Two;

                PublicUartSet.MainUsart.NewLine = "\r\n";
                PublicUartSet.MainUsart.RtsEnable = true;
                PublicUartSet.MainUsart.Handshake = System.IO.Ports.Handshake.None;
                try
                {
                    PublicUartSet.MainUsart.Open();

                    // 设置按键的使用权限
                    comboBox_Serial.Enabled = false;
                    comboBox_BandRate.Enabled = false;

                    PublicUartSet.ConnectState = true;

                    button_temperatureTest.Enabled = true;
                    button_OTA.Enabled = true;
                    // 打开属性变为关闭属性
                    button_OK.Text = "关闭串口";
                    toolStripStatus_Port.Text = "连接成功:" + comboBox_Serial.Text;
                    toolStripStatus_Port.ForeColor = Color.Green; 
                    PublicUartSet.MainUsart.Encoding = Encoding.GetEncoding("GB2312");
                    //new Thread(mCom.ComReadData) { IsBackground = true }.Start();
                }
                catch (Exception)
                {


                    toolStripStatus_Port.Text = "连接失败:" + comboBox_Serial.Text;
                    toolStripStatus_Port.ForeColor = Color.Red; // 设置为红色
                    MessageBox.Show("串口连接失败！\r\n可能原因：串口被占用", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PublicUartSet.MainUsart.Close();   // 关闭串口

                    // 设置按键的使用权限
                    comboBox_Serial.Enabled = true;
                    comboBox_BandRate.Enabled = true;

                    button_temperatureTest.Enabled = false;
                    button_OTA.Enabled = false;

                    PublicUartSet.ConnectState = false;
                    //comboBox_Serial.Text = "None";
                    // 打开属性变为关闭属性
                    button_OK.Text = "打开串口";
                }


            }
            else
            {
                PublicUartSet.MainUsart.Close();   // 关闭串口

                // 设置按键的使用权限
                comboBox_Serial.Enabled = true;
                comboBox_BandRate.Enabled = true;
                PublicUartSet.ConnectState = false;
                button_temperatureTest.Enabled = false;
                button_OTA.Enabled = false;
                // 打开属性变为关闭属性
                button_OK.Text = "打开串口";
                toolStripStatus_Port.Text = "串口号：" + comboBox_Serial.Text;  // 设置状态栏的情况                   
                toolStripStatus_Port.ForeColor = Color.Black; // 设置为
            }

        }

        private void temperatureTest_Click(object sender, EventArgs e)
        {
            button_temperatureTest.Enabled = false;
            richTextBox_Result.Text = "";
            PublicUartSet.RDQue.Clear();
            richTextBox_Result.BackColor = Color.White;
            PublicUartSet.temp_channal = Convert.ToByte( comboBox_channal_num.Text);
            PublicUartSet.temp_base = Convert.ToInt16(comboBox_temp_base.Text);
            new Thread(tempTestFun.temperature_get) { IsBackground = true }.Start();


        }

        #region 数据接收发送日志记录、支持其他线程访问  
        public delegate void LogAppendDelegate(Color color, string text);
        /// <summary>  
        /// 追加显示文本  
        /// </summary>  
        /// <param name="color">文本颜色</param>  
        /// <param name="text">显示文本</param>  
        public void LogAppend(Color color, string text)
        {
            richTextBox_Receive.AppendText("\n");
            richTextBox_Receive.SelectionColor = color;
            richTextBox_Receive.AppendText(text);
        }
        /// <summary>  
        /// 显示错误日志  
        /// </summary>  
        /// <param name="text"></param>  
        public void LogError(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBox_Receive.Invoke(la, Color.Red, DateTime.Now.ToString("HH:mm:ss ") + text);
        }
        /// <summary>  
        /// 显示警告信息  
        /// </summary>  
        /// <param name="text"></param>  
        public void LogRX(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBox_Receive.Invoke(la, Color.Blue, DateTime.Now.ToString("[HH:mm:ss:fff-") + "↑↑]:"+ text);

        }
        /// <summary>  
        /// 显示信息  
        /// </summary>  
        /// <param name="text"></param>  
        public void LogTX(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBox_Receive.Invoke(la, Color.Black, DateTime.Now.ToString("[HH:mm:ss:fff-") + "↓↓]:" + text);

        }
        public void LogTRX(string text, Byte sta)
        {
            switch (sta)
            {
                case 0:                   
                    break;
                case 1:
                    LogTX(text);
                    // 更新状态显示框
                    toolStripStatus_sendstatus.Text = "收到数据: " + PublicUartSet.sendCount.ToString();
                    break;
                case 2:
                    LogRX(text);
                    // 更新状态显示框
                    toolStripStatus_recestatus.Text = "收到数据: " + PublicUartSet.receCount.ToString();
                    break;

                default:
                    break;

            }
            if (recTextBoxForcedDown == true)
            {
                //this.richTextBox_Receive.Focus();

                //this.richTextBox_Receive.Select(this.richTextBox_Receive.TextLength, 0);
                this.richTextBox_Receive.SelectionStart = this.richTextBox_Receive.TextLength;
                this.richTextBox_Receive.ScrollToCaret();
            }
        }

        #endregion

        #region 工作记录、支持其他线程访问  
        public delegate void LogTaskAppendDelegate(Color color, string text);
        /// <summary>  
        /// 追加显示文本  
        /// </summary>  
        /// <param name="color">文本颜色</param>  
        /// <param name="text">显示文本</param>  
        public void LogTaskAppend(Color color, string text)
        {
            
            //richTextBox_Result.SelectionColor = color;
            richTextBox_Result.BackColor = color;
            richTextBox_Result.AppendText(text);
            richTextBox_Result.AppendText("\n");
        }

        public void LogTaskSuccess(string text)
        {
            LogTaskAppendDelegate la = new LogTaskAppendDelegate(LogTaskAppend);
            richTextBox_Result.Invoke(la, Color.Lime, text);
        }
 
        public void LogTaskProcess(string text)
        {
            LogTaskAppendDelegate la = new LogTaskAppendDelegate(LogTaskAppend);
            richTextBox_Result.Invoke(la, Color.Yellow,  text);

        }

        public void LogTaskFail(string text)
        {
            LogTaskAppendDelegate la = new LogTaskAppendDelegate(LogTaskAppend);
            richTextBox_Result.Invoke(la, Color.Red,  text);

        }

        public void LogTask(string text, Byte sta)
        {
            switch(sta)
            {
                case  0 :
                    
                     break; 
                case 1  :
                    LogTaskFail(text);
                    break;
                case 2:
                    LogTaskProcess(text);
                    break;
                case 3 :
                    LogTaskSuccess(text);
                    break;
                default : 
                    break;

            }

            this.richTextBox_Result.SelectionStart = this.richTextBox_Receive.TextLength;
            this.richTextBox_Result.ScrollToCaret();
        }

        private void richTextBox_Receive_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            recTextBoxForcedDown = !recTextBoxForcedDown;
        }
        #endregion



        private void Ticktimer_Tick(object sender, EventArgs e)
        {
           PublicUartSet.ThreadTick ++;
        }

        private void richTextBox_Result_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class SerialPortEventArgs : EventArgs
    {
        public byte[] receivedBytes = null;   // 用来接收串口读取的数据
    }

   

    
}
