using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsScreenColorPicker
{
    public partial class Form1 : Form
    {
        private Timer tim = new Timer();
        private Bitmap bitmap;
        private Point p;

        public Form1()
        {
            InitializeComponent();
            button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            panel2.BackColor = Color.AliceBlue;

            tim.Interval = 1;
            tim.Tick += delegate
            {
         //       p.X = Control.MousePosition.X;
          //      p.Y = Control.MousePosition.Y;

                p = Control.MousePosition;

                if(bitmap != null)bitmap.Dispose();
                bitmap = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);

                Graphics graphics = Graphics.FromImage(bitmap);

                Point upleft = new Point(p.X - pictureBox1.Size.Width / 2, p.Y - pictureBox1.Size.Width / 2);
                graphics.CopyFromScreen(upleft,
                    new Point(0,0), pictureBox1.Size);

                pictureBox1.BackgroundImage = bitmap;
          //      graphics.DrawImage(bitmap, new Point());

                Color col = bitmap.GetPixel(pictureBox1.Size.Width/2, pictureBox1.Size.Height/2);

                int r = col.R;
                int g = col.G;
                int b = col.B;
                panel2.BackColor = col;

                int c = r << 16 | g << 8 | b;
                textBox1.Text = c.ToString("X6");
                textBox2.Text = r + ", " + g + ", " + b;
                textBox3.Text = (r / 255f).ToString("0.00")+ ", " + (g / 255f).ToString("0.00") + ", " + (b / 255f).ToString("0.00");

                label5.Text = "Coord:" + p.ToString();
            };
        }

        private void button1_MouseDown(object sender, EventArgs e)
        {
            tim.Start();
        }

        private void button1_MouseUp(object sender, EventArgs e)
        {
            tim.Stop();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
