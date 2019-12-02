using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorTrack
{
    public partial class Form1 : Form
    {
        Color color1 = Color.Black;
        Color color2 = Color.Black;
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int r1 = trackBar1.Value;
            int g1 = trackBar2.Value;
            int b1 = trackBar3.Value;

            int r2 = trackBar4.Value;
            int g2 = trackBar5.Value;
            int b2 = trackBar6.Value;

            color1 = Color.FromArgb(r1, g1, b1);
            color2 = Color.FromArgb(r2, g2, b2);
            
            string hex1 = color1.R.ToString("X2") + color1.G.ToString("X2") + color1.B.ToString("X2");
            string hex2 = color2.R.ToString("X2") + color2.G.ToString("X2") + color2.B.ToString("X2");

            RGB1.Text = r1 + "," + g1 + "," + b1;
            RGB2.Text = r2 + "," + g2 + "," + b2;

            HEX1.Text = "#" + hex1;
            HEX2.Text = "#" + hex2;

            label1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int r1 = trackBar1.Value;
            int g1 = trackBar2.Value;
            int b1 = trackBar3.Value;

            int r2 = trackBar4.Value;
            int g2 = trackBar5.Value;
            int b2 = trackBar6.Value;

            color1 = Color.FromArgb(r1, g1, b1);
            color2 = Color.FromArgb(r2, g2, b2);

            string hex1 = color1.R.ToString("X2") + color1.G.ToString("X2") + color1.B.ToString("X2");
            string hex2 = color2.R.ToString("X2") + color2.G.ToString("X2") + color2.B.ToString("X2");

            RGB1.Text = r1 + "," + g1 + "," + b1;
            RGB2.Text = r2 + "," + g2 + "," + b2;

            HEX1.Text = "#" + hex1;
            HEX1.Text = "#" + hex2;
        }

        private void ColorOnPaint(object sender, PaintEventArgs e)
        {
            if (isGradient.Checked)
            {
                Graphics g = e.Graphics;
                g.FillRectangle(Brushes.Black, e.ClipRectangle);

                Brush linearGradientBrush = new LinearGradientBrush(
                   e.ClipRectangle, color1, color2, angle.Value);
                g.FillRectangle(linearGradientBrush, e.ClipRectangle);

                linearGradientBrush.Dispose();
            }
            else
            {
                label1.BackColor = color1;
            }
        }

        private void isGradient_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = isGradient.Checked;
            angle.Enabled = isGradient.Checked;
            label1.Refresh();
        }

        private void angle_Scroll(object sender, EventArgs e)
        {
            angle_value.Text = angle.Value.ToString();
            label1.Refresh();
        }
    }
}
