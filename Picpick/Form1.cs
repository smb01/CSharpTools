using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.Principal;

namespace Picpick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CatchForm f;

        private Bitmap CatchScreen()
        {
            Bitmap CatchBmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(CatchBmp);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
            return CatchBmp;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            f = new CatchForm(this, CatchScreen());
            f.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            f.Close();
        }
    }
}


