using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Picpick
{
    public partial class CatchForm : Form
    {
        public CatchForm(Form1 f, Bitmap b)
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.ShowInTaskbar = false;
            this.f = f;
            this.b = b;
        }

        int hdc;
        Bitmap b;
        Graphics g;
        Form1 f;

        private void picWindow_Load(object sender, EventArgs e)
        {
            picWndImage.Image = b;
            hdc = Win32.GetDC(IntPtr.Zero);
            b = new Bitmap(30, 30);
        }

        private void picWndImage_MouseMove(object sender, MouseEventArgs e)
        {
            g = Graphics.FromImage(b);      
            g.CopyFromScreen(e.X - 15, e.Y - 15, 0, 0, b.Size);        
            Image thumb = b.GetThumbnailImage(f.pictureBox1.Width, f.pictureBox1.Height, null, IntPtr.Zero);         
            g.DrawImage(b, 15, 15, thumb.Width, thumb.Height);

            f.pictureBox1.Image = thumb;

            g = Graphics.FromImage(f.pictureBox1.Image);
            g.DrawRectangle(Pens.Red, f.pictureBox1.Width / 2 - 2, f.pictureBox1.Height / 2 - 2, 4, 4);

            int rgb = Win32.GetPixel(hdc, e.X, e.Y);

            f.lblHtml.Text = rgb.ToString("X6");
            f.pictureBox2.BackColor = Color.FromArgb((int)(rgb & 0x000000FF), (int)(rgb & 0x0000FF00) >> 8, (int)(rgb & 0x00FF0000) >> 16);
            f.Refresh();
        }

        private void picWndImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Clipboard.SetDataObject(f.lblHtml.Text, true);
                f.Close();
                Close();
            }
        }
    }
}
