
namespace MainSender
{
    partial class ToolMeu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_OK = new System.Windows.Forms.Button();
            this.comboBox_Stop = new System.Windows.Forms.ComboBox();
            this.comboBox_Data = new System.Windows.Forms.ComboBox();
            this.comboBox_Check = new System.Windows.Forms.ComboBox();
            this.comboBox_BandRate2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Serial2 = new System.Windows.Forms.ComboBox();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_OK.Font = new System.Drawing.Font("宋体", 13F);
            this.button_OK.Location = new System.Drawing.Point(113, 297);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(117, 33);
            this.button_OK.TabIndex = 23;
            this.button_OK.Text = "确定";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // comboBox_Stop
            // 
            this.comboBox_Stop.Font = new System.Drawing.Font("Consolas", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Stop.FormattingEnabled = true;
            this.comboBox_Stop.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBox_Stop.Location = new System.Drawing.Point(196, 240);
            this.comboBox_Stop.Name = "comboBox_Stop";
            this.comboBox_Stop.Size = new System.Drawing.Size(121, 34);
            this.comboBox_Stop.TabIndex = 22;
            // 
            // comboBox_Data
            // 
            this.comboBox_Data.Font = new System.Drawing.Font("Consolas", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Data.FormattingEnabled = true;
            this.comboBox_Data.Items.AddRange(new object[] {
            "8",
            "9"});
            this.comboBox_Data.Location = new System.Drawing.Point(196, 188);
            this.comboBox_Data.Name = "comboBox_Data";
            this.comboBox_Data.Size = new System.Drawing.Size(121, 34);
            this.comboBox_Data.TabIndex = 21;
            // 
            // comboBox_Check
            // 
            this.comboBox_Check.Font = new System.Drawing.Font("Consolas", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Check.FormattingEnabled = true;
            this.comboBox_Check.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.comboBox_Check.Location = new System.Drawing.Point(196, 136);
            this.comboBox_Check.Name = "comboBox_Check";
            this.comboBox_Check.Size = new System.Drawing.Size(121, 34);
            this.comboBox_Check.TabIndex = 20;
            // 
            // comboBox_BandRate2
            // 
            this.comboBox_BandRate2.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_BandRate2.FormattingEnabled = true;
            this.comboBox_BandRate2.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBox_BandRate2.Location = new System.Drawing.Point(196, 84);
            this.comboBox_BandRate2.Name = "comboBox_BandRate2";
            this.comboBox_BandRate2.Size = new System.Drawing.Size(121, 32);
            this.comboBox_BandRate2.TabIndex = 19;
            this.comboBox_BandRate2.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 13F);
            this.label5.Location = new System.Drawing.Point(85, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "停止位:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 13F);
            this.label4.Location = new System.Drawing.Point(85, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 22);
            this.label4.TabIndex = 17;
            this.label4.Text = "数据位:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13F);
            this.label3.Location = new System.Drawing.Point(85, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 22);
            this.label3.TabIndex = 16;
            this.label3.Text = "校验位:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13F);
            this.label2.Location = new System.Drawing.Point(85, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 22);
            this.label2.TabIndex = 15;
            this.label2.Text = "波特率:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13F);
            this.label1.Location = new System.Drawing.Point(87, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "串口号:";
            // 
            // comboBox_Serial2
            // 
            this.comboBox_Serial2.Font = new System.Drawing.Font("Consolas", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Serial2.FormattingEnabled = true;
            this.comboBox_Serial2.Location = new System.Drawing.Point(196, 35);
            this.comboBox_Serial2.Name = "comboBox_Serial2";
            this.comboBox_Serial2.Size = new System.Drawing.Size(121, 34);
            this.comboBox_Serial2.TabIndex = 13;
            // 
            // button_Refresh
            // 
            this.button_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Refresh.Font = new System.Drawing.Font("宋体", 13F);
            this.button_Refresh.Location = new System.Drawing.Point(271, 297);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(121, 33);
            this.button_Refresh.TabIndex = 24;
            this.button_Refresh.Text = "取消";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // ToolMeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 377);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.comboBox_Stop);
            this.Controls.Add(this.comboBox_Data);
            this.Controls.Add(this.comboBox_Check);
            this.Controls.Add(this.comboBox_BandRate2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Serial2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToolMeu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "端口设置菜单";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ToolMeu_FormClosed);
            this.Load += new System.EventHandler(this.ToolMeu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.ComboBox comboBox_Stop;
        private System.Windows.Forms.ComboBox comboBox_Data;
        private System.Windows.Forms.ComboBox comboBox_Check;
        private System.Windows.Forms.ComboBox comboBox_BandRate2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Serial2;
        private System.Windows.Forms.Button button_Refresh;
    }
}