using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MyProgressBar: ProgressBar
    {
        /// <summary>
        /// 文本设置
        /// </summary>
        public Font TextFont { get; set; } = SystemFonts.DefaultFont;

        /// <summary>
        /// 渐变色开始
        /// </summary>
        public Color ColorStart { get; set; } = Color.FromArgb(204, 235, 255);

        /// <summary>
        /// 渐变色结束
        /// </summary>
        public Color ColorEnd { get; set; } = Color.FromArgb(0, 153, 255);

        public MyProgressBar() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);//自动绘制
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);//减少闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//减少闪烁
            this.SetStyle(ControlStyles.DoubleBuffer, true);//减少闪烁
            this.SetStyle(ControlStyles.ResizeRedraw, true);//重绘控件
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);//减少闪烁
            this.Paint += OnLabelPaint;
        }

        public void OnLabelPaint(object sender, PaintEventArgs e)
        {
            using (Graphics gr = this.CreateGraphics())
            {
                string str = this.Value.ToString() + "%";
                // 设置渐变色
                LinearGradientBrush brBG = new LinearGradientBrush(e.ClipRectangle,
                    ColorStart, ColorEnd, LinearGradientMode.Horizontal);
                // 设置文字
                float X = gr.MeasureString(str, TextFont).Width / 2.0F - 8;
                float Y = this.Height / 2 - (gr.MeasureString(str, TextFont).Height / 2.0F) + 1; // 加1是向下微调，总感觉字偏上了
                int W = e.ClipRectangle.Width * this.Value / this.Maximum;
                int H = e.ClipRectangle.Height;
                e.Graphics.FillRectangle(brBG, e.ClipRectangle.X, e.ClipRectangle.Y, W, H);
                e.Graphics.DrawString(str, TextFont, Brushes.Black, new PointF(X, Y));
            }
        }
    }
}
