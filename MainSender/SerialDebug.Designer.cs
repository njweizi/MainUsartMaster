namespace MainSender
{
    partial class SerialDebug
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialDebug));
            this.status_timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus_Port = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_recestatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_sendstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.richTextBox_Receive = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_ClcReceData = new System.Windows.Forms.Button();
            this.button_OTA = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_ReceData = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerDisplay = new System.Windows.Forms.Timer(this.components);
            this.richTextBox_Result = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.comboBox_BandRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Serial = new System.Windows.Forms.ComboBox();
            this.button_temperatureTest = new System.Windows.Forms.Button();
            this.comboBox_channal_num = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_temp_base = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Ticktimer = new System.Windows.Forms.Timer(this.components);
            this.TaskProgressBar = new WindowsFormsApp.MyProgressBar();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // status_timer
            // 
            this.status_timer.Enabled = true;
            this.status_timer.Interval = 1000;
            this.status_timer.Tick += new System.EventHandler(this.Update_StatusTime);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus_Port,
            this.toolStripStatus_recestatus,
            this.toolStripStatus_sendstatus,
            this.toolStripStatus_Time});
            this.statusStrip1.Location = new System.Drawing.Point(0, 742);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(755, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatus_Port
            // 
            this.toolStripStatus_Port.Name = "toolStripStatus_Port";
            this.toolStripStatus_Port.Size = new System.Drawing.Size(97, 17);
            this.toolStripStatus_Port.Text = "串口状态：False";
            this.toolStripStatus_Port.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatus_recestatus
            // 
            this.toolStripStatus_recestatus.Name = "toolStripStatus_recestatus";
            this.toolStripStatus_recestatus.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatus_recestatus.Text = "收到数据：0";
            this.toolStripStatus_recestatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatus_sendstatus
            // 
            this.toolStripStatus_sendstatus.Name = "toolStripStatus_sendstatus";
            this.toolStripStatus_sendstatus.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatus_sendstatus.Text = "发送数据：0";
            this.toolStripStatus_sendstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatus_Time
            // 
            this.toolStripStatus_Time.Name = "toolStripStatus_Time";
            this.toolStripStatus_Time.Size = new System.Drawing.Size(0, 17);
            // 
            // richTextBox_Receive
            // 
            this.richTextBox_Receive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Receive.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Receive.Location = new System.Drawing.Point(11, 322);
            this.richTextBox_Receive.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_Receive.Name = "richTextBox_Receive";
            this.richTextBox_Receive.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_Receive.Size = new System.Drawing.Size(732, 418);
            this.richTextBox_Receive.TabIndex = 16;
            this.richTextBox_Receive.Text = "";
            this.richTextBox_Receive.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox_Receive_MouseDoubleClick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(11, 299);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "接收数据";
            // 
            // button_ClcReceData
            // 
            this.button_ClcReceData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_ClcReceData.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ClcReceData.Location = new System.Drawing.Point(78, 294);
            this.button_ClcReceData.Margin = new System.Windows.Forms.Padding(2);
            this.button_ClcReceData.Name = "button_ClcReceData";
            this.button_ClcReceData.Size = new System.Drawing.Size(92, 25);
            this.button_ClcReceData.TabIndex = 19;
            this.button_ClcReceData.Text = "清除数据";
            this.button_ClcReceData.UseVisualStyleBackColor = true;
            this.button_ClcReceData.Click += new System.EventHandler(this.button_ClcReceData_Click);
            // 
            // button_OTA
            // 
            this.button_OTA.Enabled = false;
            this.button_OTA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_OTA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_OTA.Location = new System.Drawing.Point(368, 36);
            this.button_OTA.Margin = new System.Windows.Forms.Padding(2);
            this.button_OTA.Name = "button_OTA";
            this.button_OTA.Size = new System.Drawing.Size(88, 25);
            this.button_OTA.TabIndex = 24;
            this.button_OTA.Text = "固件升级";
            this.button_OTA.UseVisualStyleBackColor = true;
            this.button_OTA.Click += new System.EventHandler(this.button_OTA_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(755, 25);
            this.menuStrip1.TabIndex = 31;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.fileToolStripMenuItem.Text = "文件";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_ReceData});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "保存数据";
            // 
            // MenuItem_ReceData
            // 
            this.MenuItem_ReceData.Name = "MenuItem_ReceData";
            this.MenuItem_ReceData.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_ReceData.Text = "接收数据";
            this.MenuItem_ReceData.Click += new System.EventHandler(this.MenuItem_ReceData_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.设置ToolStripMenuItem.Text = "端口设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // timerDisplay
            // 
            this.timerDisplay.Enabled = true;
            this.timerDisplay.Interval = 10;
            this.timerDisplay.Tick += new System.EventHandler(this.timerDisplay_Tick);
            // 
            // richTextBox_Result
            // 
            this.richTextBox_Result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Result.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox_Result.Location = new System.Drawing.Point(506, 42);
            this.richTextBox_Result.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_Result.Name = "richTextBox_Result";
            this.richTextBox_Result.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox_Result.Size = new System.Drawing.Size(237, 276);
            this.richTextBox_Result.TabIndex = 32;
            this.richTextBox_Result.Text = "";
            this.richTextBox_Result.TextChanged += new System.EventHandler(this.richTextBox_Result_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(503, 25);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 33;
            this.label9.Text = "运行日志";
            // 
            // button_OK
            // 
            this.button_OK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_OK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_OK.Location = new System.Drawing.Point(14, 107);
            this.button_OK.Margin = new System.Windows.Forms.Padding(2);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(88, 25);
            this.button_OK.TabIndex = 38;
            this.button_OK.Text = "打开";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // comboBox_BandRate
            // 
            this.comboBox_BandRate.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_BandRate.FormattingEnabled = true;
            this.comboBox_BandRate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBox_BandRate.Location = new System.Drawing.Point(68, 70);
            this.comboBox_BandRate.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_BandRate.Name = "comboBox_BandRate";
            this.comboBox_BandRate.Size = new System.Drawing.Size(70, 25);
            this.comboBox_BandRate.TabIndex = 37;
            this.comboBox_BandRate.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(11, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 36;
            this.label2.Text = "波特率:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 35;
            this.label1.Text = "串口号:";
            // 
            // comboBox_Serial
            // 
            this.comboBox_Serial.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Serial.FormattingEnabled = true;
            this.comboBox_Serial.Location = new System.Drawing.Point(68, 38);
            this.comboBox_Serial.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Serial.Name = "comboBox_Serial";
            this.comboBox_Serial.Size = new System.Drawing.Size(70, 25);
            this.comboBox_Serial.TabIndex = 34;
            // 
            // button_temperatureTest
            // 
            this.button_temperatureTest.Enabled = false;
            this.button_temperatureTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_temperatureTest.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_temperatureTest.Location = new System.Drawing.Point(261, 36);
            this.button_temperatureTest.Margin = new System.Windows.Forms.Padding(2);
            this.button_temperatureTest.Name = "button_temperatureTest";
            this.button_temperatureTest.Size = new System.Drawing.Size(88, 25);
            this.button_temperatureTest.TabIndex = 39;
            this.button_temperatureTest.Text = "采集测试";
            this.button_temperatureTest.UseVisualStyleBackColor = true;
            this.button_temperatureTest.Click += new System.EventHandler(this.temperatureTest_Click);
            // 
            // comboBox_channal_num
            // 
            this.comboBox_channal_num.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_channal_num.FormattingEnabled = true;
            this.comboBox_channal_num.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_channal_num.Location = new System.Drawing.Point(211, 38);
            this.comboBox_channal_num.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_channal_num.Name = "comboBox_channal_num";
            this.comboBox_channal_num.Size = new System.Drawing.Size(32, 25);
            this.comboBox_channal_num.TabIndex = 41;
            this.comboBox_channal_num.Tag = "";
            this.comboBox_channal_num.Text = "4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(154, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 40;
            this.label3.Text = "通道数:";
            // 
            // comboBox_temp_base
            // 
            this.comboBox_temp_base.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_temp_base.FormattingEnabled = true;
            this.comboBox_temp_base.Items.AddRange(new object[] {
            "10",
            "15",
            "20",
            "25",
            "30"});
            this.comboBox_temp_base.Location = new System.Drawing.Point(211, 69);
            this.comboBox_temp_base.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_temp_base.Name = "comboBox_temp_base";
            this.comboBox_temp_base.Size = new System.Drawing.Size(44, 25);
            this.comboBox_temp_base.TabIndex = 43;
            this.comboBox_temp_base.Tag = "";
            this.comboBox_temp_base.Text = "25";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(154, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 42;
            this.label4.Text = "参考温度:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(258, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 18);
            this.label5.TabIndex = 44;
            this.label5.Text = "℃/±5";
            // 
            // Ticktimer
            // 
            this.Ticktimer.Enabled = true;
            this.Ticktimer.Interval = 10;
            this.Ticktimer.Tick += new System.EventHandler(this.Ticktimer_Tick);
            // 
            // TaskProgressBar
            // 
            this.TaskProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.TaskProgressBar.ColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TaskProgressBar.ColorStart = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TaskProgressBar.Location = new System.Drawing.Point(506, 299);
            this.TaskProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.TaskProgressBar.Name = "TaskProgressBar";
            this.TaskProgressBar.Size = new System.Drawing.Size(219, 19);
            this.TaskProgressBar.TabIndex = 45;
            this.TaskProgressBar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // SerialDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(755, 764);
            this.Controls.Add(this.TaskProgressBar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_temp_base);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_channal_num);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_temperatureTest);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.comboBox_BandRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Serial);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.richTextBox_Result);
            this.Controls.Add(this.button_OTA);
            this.Controls.Add(this.button_ClcReceData);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.richTextBox_Receive);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(771, 554);
            this.Name = "SerialDebug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "调试工具V1.0";
            this.Load += new System.EventHandler(this.SerialDebug_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer status_timer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.RichTextBox richTextBox_Receive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_ClcReceData;
        private System.Windows.Forms.Button button_OTA;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_ReceData;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Port;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_recestatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_sendstatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Time;
        private System.Windows.Forms.Timer timerDisplay;
        private System.Windows.Forms.RichTextBox richTextBox_Result;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.ComboBox comboBox_BandRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Serial;
        private System.Windows.Forms.Button button_temperatureTest;
        private System.Windows.Forms.ComboBox comboBox_channal_num;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_temp_base;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private WindowsFormsApp.MyProgressBar TaskProgressBar;
        private System.Windows.Forms.Timer Ticktimer;
    }
}

