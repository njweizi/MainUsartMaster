using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;     // 串口模块


namespace MainSender
{
    


    public partial class ToolMeu : Form
    {
   
        public ToolMeu()
        {
            InitializeComponent();
        }

        private void ToolMeu_Load(object sender, EventArgs e)
        {
             InitializeSerialSet(); // 初始化串口设置
        }
        /// <summary>
        /// 串口初始化设置
        /// </summary>

        public void InitializeSerialSet()
        {
            InitializePorts();   // 初始化串口号
            // 初始化波特率
            comboBox_BandRate2.Text = comboBox_BandRate2.Items[6].ToString();
            // 初始化校验位
            comboBox_Check.Text = comboBox_Check.Items[0].ToString();
            // 初始化数据位
            comboBox_Data.Text = comboBox_Data.Items[0].ToString();
            // 初始化停止位
            comboBox_Stop.Text = comboBox_Stop.Items[0].ToString();

        }
        /// <summary>
        /// 可用串口扫描，并且显示
        /// </summary>
        public void InitializePorts()
        {
            comboBox_Serial2.Items.Clear();   // 清空原来的信息
            // 返回可用串口号，形式：COM3
            string[] arraysPostsNames = SerialPort.GetPortNames();  // 获取所有可用的串口号

            // 检查串口号是否正确
            if (arraysPostsNames.Length > 0)
            {

                Array.Sort(arraysPostsNames);  // 使用默认进行排序，从小到大肾虚
                for (int i = 0; i < arraysPostsNames.Length; i++)
                {
                    comboBox_Serial2.Items.Add(arraysPostsNames[i]);  // 将所有可用串口加载到串口显示框当中
                }
                comboBox_Serial2.Text = arraysPostsNames[0];   // 默认选择第一个串口

                comboBox_Serial2.Enabled = true;   // 打开选择框
                           
            }
            else
            {
   
                comboBox_Serial2.Text = "None";   // 提示没有可用串口
                comboBox_Serial2.Enabled = false;   // 禁止打开串口选择框
            }
        }

        /// <summary>
        /// 串口状态响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolMeu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (PublicUartSet.ConnectState == true)
                return;
            PublicUartSet.ConnectCom = comboBox_Serial2.Text;
            PublicUartSet.ConnectBaudRate = comboBox_BandRate2.Text;
            PublicUartSet.ConnectCom = comboBox_Serial2.Text;
            PublicUartSet.ConnectDataBits = comboBox_Data.Text;
            PublicUartSet.ConnectParity = comboBox_Check.Text;
            PublicUartSet.ConnectStopBits = comboBox_Stop.Text;

            PublicUartSet.ConnectChange = true;
        }
    }
}
