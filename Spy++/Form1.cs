using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Spypp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TreeNode _node = null;

        private bool EnumWindowsProc(IntPtr hwnd, int lParam)
        {
            try
            {
                int pid = 0;
                string other = "";
                StringBuilder caption = new StringBuilder(260);
                StringBuilder className = new StringBuilder(260);

                Win32.GetWindowText(hwnd, caption, 260);
                Win32.GetWindowThreadProcessId(hwnd, out pid);
                Win32.GetClassName(hwnd, className, 260);

                if ((Win32.GetWindowLong(hwnd, Win32.GWL_EXSTYLE) & Win32.WS_EX_TOPMOST) == Win32.WS_EX_TOPMOST)
                    other = "~Topmost";
                else
                    other = "";

                if (Win32.IsWindowVisible(hwnd))
                {
                    TreeNode node = new TreeNode("Window " + ((Int32)hwnd).ToString("X8") + "~" + caption + "~" + className + "~" + pid.ToString() + other, 0, 0);
                    node.Tag = (Int32)hwnd;
                    treeViewEx1.Nodes[0].Nodes.Add(node);
                }
                else if (!onlyShowVisibleToolStripMenuItem.Checked)
                {
                    TreeNode node = new TreeNode("Window " + ((Int32)hwnd).ToString("X8") + "~" + caption + "~" + className + "~" + pid.ToString() + other, 1, 1);
                    node.Tag = (Int32)hwnd;
                    treeViewEx1.Nodes[0].Nodes.Add(node);
                }
            }
            catch (Exception ex) { }
            return true;
        }

        private bool EnumChildWindowsProc(IntPtr hwnd, int lParam)
        {
            try
            {
                int pid = 0;
                string other = "";
                StringBuilder caption = new StringBuilder(260);
                StringBuilder className = new StringBuilder(260);

                Win32.GetWindowText(hwnd, caption, 260);
                Win32.GetWindowThreadProcessId(hwnd, out pid);
                Win32.GetClassName(hwnd, className, 260);

                if ((Win32.GetWindowLong(hwnd, Win32.GWL_EXSTYLE) & Win32.WS_EX_TOPMOST) == Win32.WS_EX_TOPMOST)
                    other = "~Topmost";
                else
                    other = "";

                if (Win32.IsWindowVisible(hwnd))
                {
                    TreeNode node = new TreeNode("Window " + ((Int32)hwnd).ToString("X8") + "~" + caption + "~" + className + "~" + pid.ToString() + other, 0, 0);
                    node.Tag = (Int32)hwnd;
                    _node.Nodes.Add(node);
                }
                else if(!onlyShowVisibleToolStripMenuItem.Checked)
                {
                    TreeNode node = new TreeNode("Window " + ((Int32)hwnd).ToString("X8") + "~" + caption + "~" + className + "~" + pid.ToString() + other, 1, 1);
                    node.Tag = (Int32)hwnd;
                    _node.Nodes.Add(node);
                }
            }
            catch (Exception ex) { }

            return true;
        }

        private void EnumWindows()
        {
            treeViewEx1.Nodes.Clear();

            StringBuilder caption = new StringBuilder(260);
            StringBuilder className = new StringBuilder(260);

            IntPtr hwnd = Win32.GetDesktopWindow();
            Win32.GetClassName(hwnd, className, 260);
            Win32.GetWindowText(hwnd, caption, 260);

            TreeNode node = new TreeNode("Window " + ((Int32)hwnd).ToString("X8") + "~" + caption + "~" + className, 0, 0);
            node.Tag = (Int32)hwnd;
            treeViewEx1.Nodes.Add(node);

            Win32.EnumWindowsProc callback = new Win32.EnumWindowsProc(EnumWindowsProc);
            Win32.EnumWindows(callback, 0);

            treeViewEx1.Nodes[0].Expand();
        }

        private void EnumChildWindows(TreeNode node)
        {
            IntPtr hwnd = (IntPtr)(Int32)node.Tag;
            _node = node;
            Win32.EnumChildWindowsProc callback = new Win32.EnumChildWindowsProc(EnumChildWindowsProc);
            Win32.EnumChildWindows(hwnd, callback, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshToolStripMenuItem_Click(sender, e);
        }

        private void treeViewEx1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point point = new Point(e.X, e.Y);
                TreeNode node = treeViewEx1.GetNodeAt(point);
                treeViewEx1.SelectedNode = node;

                if (treeViewEx1.SelectedNode == null)
                {
                    propertiesToolStripMenuItem.Enabled = false;
                    destoryToolStripMenuItem.Enabled = false;
                    topmostToolStripMenuItem.Enabled = false;
                    showToolStripMenuItem.Enabled = false;
                    maximizeToolStripMenuItem.Enabled = false;
                }
                else
                {
                    propertiesToolStripMenuItem.Enabled = true;
                    destoryToolStripMenuItem.Enabled = true;
                    topmostToolStripMenuItem.Enabled = true;
                    showToolStripMenuItem.Enabled = true;
                    maximizeToolStripMenuItem.Enabled = true;
                    maximizeToolStripMenuItem.Checked = false;

                    IntPtr hWnd = (IntPtr)(Int32)(treeViewEx1.SelectedNode.Tag);

                    if ((Win32.GetWindowLong(hWnd, Win32.GWL_EXSTYLE) & Win32.WS_EX_TOPMOST) == Win32.WS_EX_TOPMOST)
                        topmostToolStripMenuItem.Checked = true;
                    else
                        topmostToolStripMenuItem.Checked = false;

                    if (Win32.IsWindowVisible(hWnd))
                        showToolStripMenuItem.Checked = true;
                    else
                        showToolStripMenuItem.Checked = false;

                    if (Win32.IsZoomed(hWnd))
                        maximizeToolStripMenuItem.Checked = true;
                    else if (Win32.IsIconic(hWnd))
                        maximizeToolStripMenuItem.Checked = false;
                }
            }
        }

        private void treeViewEx1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    if (node.IsExpanded)
                        node.Collapse();
                    node.Nodes.Clear();
                    EnumChildWindows(node);
                }
            }
            catch (Exception ex) { }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnumWindows();
        }

        private void onlyShowVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (onlyShowVisibleToolStripMenuItem.Checked)
                onlyShowVisibleToolStripMenuItem.Checked = false;
            else
                onlyShowVisibleToolStripMenuItem.Checked = true;
            refreshToolStripMenuItem_Click(sender, e);
        }

        private void destoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewEx1.SelectedNode;
            IntPtr hWnd = (IntPtr)(Int32)(node.Tag);
            Win32.SendMessage(hWnd, Win32.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            if (!Win32.IsWindow(hWnd))
                treeViewEx1.SelectedNode.Remove();
        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewEx1.SelectedNode;
            IntPtr hWnd = (IntPtr)(Int32)(node.Tag);
            if (maximizeToolStripMenuItem.Checked)
                Win32.ShowWindow(hWnd, Win32.SW_SHOWMINIMIZED);
            else
                Win32.ShowWindow(hWnd, Win32.SW_SHOWMAXIMIZED);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewEx1.SelectedNode;
            IntPtr hWnd = (IntPtr)(Int32)(node.Tag);
            if (showToolStripMenuItem.Checked)
                Win32.ShowWindow(hWnd, Win32.SW_HIDE);
            else
                Win32.ShowWindow(hWnd, Win32.SW_SHOW);
        }

        private void topmostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewEx1.SelectedNode;
            IntPtr hWnd = (IntPtr)(Int32)(node.Tag);
            if (topmostToolStripMenuItem.Checked)
                Win32.SetWindowPos(hWnd, Win32.HWND_NOTOPMOST, 0, 0, 0, 0, Win32.SWP_NOMOVE | Win32.SWP_NOSIZE);
            else
                Win32.SetWindowPos(hWnd, Win32.HWND_TOPMOST, 0, 0, 0, 0, Win32.SWP_NOMOVE | Win32.SWP_NOSIZE);     
        }

        private void findWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm f = new FindForm(this);
            f.Show();
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewEx1.SelectedNode;
            IntPtr hWnd = (IntPtr)(Int32)(node.Tag);
            PropertyForm f = new PropertyForm(hWnd);
            f.Show();
        }
    }
}