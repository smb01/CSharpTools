using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Spypp
{
    public partial class PropertyForm : Form
    {
        public PropertyForm(IntPtr hwnd)
        {
            InitializeComponent();
            this.hwnd = hwnd;
        }

        IntPtr hwnd = IntPtr.Zero;

        uint[] style = new uint[]
        {
			 Win32.WS_BORDER,Win32.WS_CAPTION,Win32.WS_CHILD,Win32.WS_CLIPCHILDREN,Win32.WS_CLIPSIBLINGS,Win32.WS_DLGFRAME,Win32.WS_DISABLED,
				 Win32.WS_GROUP,Win32.WS_HSCROLL,Win32.WS_MAXIMIZE,Win32.WS_MAXIMIZEBOX,Win32.WS_MINIMIZE,Win32.WS_MINIMIZEBOX,Win32.WS_OVERLAPPED,
				 Win32.WS_POPUP,Win32.WS_SYSMENU,Win32.WS_TABSTOP,Win32.WS_THICKFRAME,Win32.WS_VISIBLE,Win32.WS_VSCROLL
        };

        string[] strs_style = new string[]
        {
			 "WS_BORDER","WS_CAPTION","WS_CHILD","WS_CLIPCHILDREN","WS_CLIPSIBLINGS","WS_DLGFRAME","WS_DISABLED",
				 "WS_GROUP","WS_HSCROLL","WS_MAXIMIZE","WS_MAXIMIZEBOX","WS_MINIMIZE","WS_MINIMIZEBOX","WS_OVERLAPPED",
				 "WS_POPUP","WS_SYSMENU","WS_TABSTOP","WS_THICKFRAME","WS_VISIBLE","WS_VSCROLL"
        };

        uint[] exstyle = new uint[]
        {
			 Win32.WS_EX_ACCEPTFILES,Win32.WS_EX_APPWINDOW,Win32.WS_EX_CLIENTEDGE,Win32.WS_EX_COMPOSITED,Win32.WS_EX_CONTEXTHELP,Win32.WS_EX_CONTROLPARENT,Win32.WS_EX_DLGMODALFRAME,
				 Win32.WS_EX_LAYERED,Win32.WS_EX_LAYOUTRTL,Win32.WS_EX_LEFT,Win32.WS_EX_LEFTSCROLLBAR,Win32.WS_EX_LTRREADING,Win32.WS_EX_MDICHILD,Win32.WS_EX_NOACTIVATE,
				 Win32.WS_EX_NOINHERITLAYOUT,Win32.WS_EX_NOPARENTNOTIFY,Win32.WS_EX_RIGHT,Win32.WS_EX_RIGHTSCROLLBAR,Win32.WS_EX_RTLREADING,Win32.WS_EX_STATICEDGE,
				 Win32.WS_EX_TOOLWINDOW,Win32.WS_EX_TOPMOST,Win32.WS_EX_TRANSPARENT,Win32.WS_EX_WINDOWEDGE
		};

        string[] strs_exstyle = new string[]
        {
			 "WS_EX_ACCEPTFILES","WS_EX_APPWINDOW","WS_EX_CLIENTEDGE","WS_EX_COMPOSITED","WS_EX_CONTEXTHELP","WS_EX_CONTROLPARENT","WS_EX_DLGMODALFRAME",
				 "WS_EX_LAYERED","WS_EX_LAYOUTRTL","WS_EX_LEFT","WS_EX_LEFTSCROLLBAR","WS_EX_LTRREADING","WS_EX_MDICHILD","WS_EX_NOACTIVATE",
				 "WS_EX_NOINHERITLAYOUT","WS_EX_NOPARENTNOTIFY","WS_EX_RIGHT","WS_EX_RIGHTSCROLLBAR","WS_EX_RTLREADING","WS_EX_STATICEDGE",
				 "WS_EX_TOOLWINDOW","WS_EX_TOPMOST","WS_EX_TRANSPARENT","WS_EX_WINDOWEDGE"
        };

        uint[] clsstyle = new uint[]
        {
			 Win32.CS_BYTEALIGNCLIENT,Win32.CS_BYTEALIGNWINDOW,Win32.CS_CLASSDC,Win32.CS_DBLCLKS,Win32.CS_DROPSHADOW,Win32.CS_GLOBALCLASS,
				 Win32.CS_HREDRAW,Win32.CS_IME,Win32.CS_NOCLOSE,Win32.CS_OWNDC,Win32.CS_PARENTDC,Win32.CS_SAVEBITS,Win32.CS_VREDRAW
        };

        string[] strs_clsstyle = new string[]
        {
			 "CS_BYTEALIGNCLIENT","CS_BYTEALIGNWINDOW","CS_CLASSDC","CS_DBLCLKS","CS_DROPSHADOW","CS_GLOBALCLASS",
				 "CS_HREDRAW","CS_IME","CS_NOCLOSE","CS_OWNDC","CS_PARENTDC","CS_SAVEBITS","CS_VREDRAW"
        };

        private void PropertyForm_Load(object sender, EventArgs e)
        {
            lblHandle.Text = "";
            lblStyle.Text = "";
            lblExtStyle.Text = "";
            lblClassStyle.Text = "";
            lblParentHandle.Text = "";

            lblHandle.Text = "0x" + ((ulong)hwnd).ToString("X8");

            StringBuilder sb = new StringBuilder(512);

            Win32.GetWindowText(hwnd, sb, sb.Capacity);

            txtCaption.Text = sb.ToString();

            Win32.GetClassName(hwnd, sb, sb.Capacity);

            txtClassName.Text = sb.ToString();

            int nStyle = Win32.GetWindowLong(hwnd, Win32.GWL_STYLE);

            lblStyle.Text = "0x" + nStyle.ToString("X8");

            for (int i = 0; i < style.Length; i++)
            {
                if ((nStyle & style[i]) > 0)
                {
                    lbStyle.Items.Add(strs_style[i]);
                }
            }

            int nStyleEx = Win32.GetWindowLong(hwnd, Win32.GWL_EXSTYLE);

            lblExtStyle.Text = "0x" + nStyleEx.ToString("X8");

            for (int i = 0; i < exstyle.Length; i++)
            {
                if ((nStyleEx & exstyle[i]) > 0)
                    lbExtStyle.Items.Add(strs_exstyle[i]);
            }

            uint ulClassStyle = Win32.GetClassLong(hwnd, Win32.GCL_STYLE);

            lblClassStyle.Text = "0x" + ulClassStyle.ToString("X8");

            for (int i = 0; i < clsstyle.Length; i++)
            {
                if ((ulClassStyle & clsstyle[i]) > 0)
                    cboClassStyle.Items.Add(strs_clsstyle[i]);
            }

            if (cboClassStyle.Items.Count > 0)
                cboClassStyle.SelectedIndex = 0;

            IntPtr hParent = (IntPtr)Win32.GetWindowLong(hwnd, Win32.GWL_HWNDPARENT);

            if (hParent != IntPtr.Zero)
            {
                lblParentHandle.Text = "0x" + ((ulong)hParent).ToString("X8");

                Win32.GetWindowText(hParent, sb, sb.Capacity);

                txtParentCaption.Text = sb.ToString();

                Win32.GetClassName(hParent, sb, sb.Capacity);

                txtParentClassName.Text = sb.ToString();
            }

            int nPId = 0;
            int nTId = 0;

            nTId = Win32.GetWindowThreadProcessId(hwnd, out nPId);

            try
            {
                Process p = Process.GetProcessById(nPId);
                txtProcessInfo.Text = "Process ID: " + nPId.ToString() + "\r\n";
                txtProcessInfo.AppendText("\r\nThread ID: " + nTId.ToString() + "\r\n");
                txtProcessInfo.AppendText("\r\nSession ID: " + p.SessionId.ToString() + "\r\n");
                txtProcessInfo.AppendText("\r\nProcess Name: " + p.MainModule.ModuleName + "\r\n");
                txtProcessInfo.AppendText("\r\nImage Path: " + p.MainModule.FileName + "\r\n");
                txtProcessInfo.AppendText("\r\nCaption: " + p.MainWindowTitle + "\r\n");
                txtProcessInfo.AppendText("\r\nStart Time: " + p.StartTime.ToString());
            }
            catch (Exception ex) { } 
        }
    }
}
