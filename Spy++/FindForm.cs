using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Spypp
{
    public partial class FindForm : Form
    {
        public FindForm(Form f)
        {
            InitializeComponent();
            this.f = f;
        }

        Form f = null;
		bool isMouseDowned = false;
        int oldRop2 = 0;
        IntPtr ghwnd = IntPtr.Zero;
        IntPtr hdc = IntPtr.Zero;
        IntPtr hpen = IntPtr.Zero;
        IntPtr oldPen = IntPtr.Zero;

        private void FindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Win32.ReleaseDC(Win32.GetDesktopWindow(), hdc);
        }

        private void FindForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = (Properties.Resources._1).ToBitmap();
            hdc = Win32.GetWindowDC(Win32.GetDesktopWindow());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDowned = true;
            pictureBox1.Image = (Properties.Resources._2).ToBitmap();
            using (MemoryStream ms = new MemoryStream(Properties.Resources._3))
            {
                this.Cursor = new Cursor(ms);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouseDowned)
                return;

            Win32.POINT p = new Win32.POINT();
            Win32.RECT rect = new Win32.RECT();
            Win32.GetCursorPos(out p);
            IntPtr hwnd = Win32.WindowFromPoint(p);
            if (ghwnd == hwnd)
                return;
            if (ghwnd != IntPtr.Zero)
            {
                Win32.GetWindowRect(ghwnd, out rect);
                Win32.Rectangle(hdc, rect.Left, rect.Top, rect.Right, rect.Bottom);
                Win32.SetROP2(hdc, oldRop2);
                Win32.SelectObject(hdc, oldPen);
                Win32.DeleteObject(hpen);
            }

            ghwnd = hwnd;
            oldRop2 = Win32.SetROP2(hdc, Win32.R2_NOTXORPEN);
            Win32.GetWindowRect(hwnd, out rect);
            hpen = Win32.CreatePen(Win32.PS_INSIDEFRAME, 2, Win32.RGB(0, 0, 255));
            oldPen = Win32.SelectObject(hdc, hpen);
            Win32.Rectangle(hdc, rect.Left, rect.Top, rect.Right, rect.Bottom);
            txtHandle.Text = "0x" + ((ulong)hwnd).ToString("X8");
            StringBuilder sb = new StringBuilder(512);
            Win32.GetWindowText(hwnd, sb, sb.Capacity);
            txtWinText.Text = sb.ToString();
            Win32.GetClassName(hwnd, sb, sb.Capacity);
            txtWinClass.Text = sb.ToString();
            long ulStyle = Win32.GetWindowLong(hwnd, Win32.GWL_STYLE);
            lblStyle.Text = "0x" + ulStyle.ToString("X8");
            lblRect.Text = "(" + rect.Left.ToString() + "," + rect.Top.ToString() + ")-(" + rect.Right.ToString() + "," + rect.Bottom.ToString() + ")," + (rect.Right - rect.Left).ToString() + "x" + (rect.Bottom - rect.Top).ToString();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDowned = false;
            pictureBox1.Image = (Properties.Resources._1).ToBitmap();
            this.Cursor = Cursors.Default;
            Win32.RECT rect = new Win32.RECT();
            Win32.GetWindowRect(ghwnd, out rect);
            Win32.Rectangle(hdc, rect.Left, rect.Top, rect.Right, rect.Bottom);
            Win32.SetROP2(hdc, oldRop2);
            Win32.SelectObject(hdc, oldPen);
            Win32.DeleteObject(hpen);
            ghwnd = IntPtr.Zero;
        }

        private void chkHide_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHide.Checked)
                this.f.Hide();
            else
                this.f.Show();
        }
    }
}
