using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ShellExt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool CheckSubKeyName(RegistryKey reg, string keyname)
        {
            try
            {
                foreach (string str in reg.GetSubKeyNames())
                {
                    if (str.ToLower() == keyname.ToLower())
                        return true;
                }
                return false;
            }
            catch (Exception ex) { return false; }
        }

        private bool CheckValueName(RegistryKey reg, string valuename)
        {
            try
            {
                foreach (string str in reg.GetValueNames())
                {
                    if (str.ToLower() == valuename.ToLower())
                        return true;
                }
                return false;
            }
            catch (Exception ex) { return false; }
        }

        private void ExplorerFile(string path)
        {
            string cmdline = "explorer.exe /select," + path;
            Win32.WinExec(cmdline, Win32.SW_SHOW);
        }

        private void ExplorerReg(string keyname)
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Applets\\Regedit", true);
                reg.SetValue("lastkey", keyname);
                reg.Close();
                Process.Start("regedit.exe");
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }

        private string GetFileCompanyName(string path)
        {
            try
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(path);
                if (fvi.CompanyName == null)
                    return "";
                return fvi.CompanyName;
            }
            catch (Exception ex) { return ex.Message; }
        }

        private void ShowFileProperty(string path)
        {
            Win32.SHELLEXECUTEINFO sei = new Win32.SHELLEXECUTEINFO();
            sei.cbSize = Marshal.SizeOf(sei);
            sei.fMask = Win32.SEE_MASK_INVOKEIDLIST | Win32.SEE_MASK_NOCLOSEPROCESS | Win32.SEE_MASK_FLAG_NO_UI;
            sei.dwHotKey = 0;
            sei.hIcon = new IntPtr(0);
            sei.hInstApp = new IntPtr(0);
            sei.hkeyClass = new IntPtr(0);
            sei.hProcess = new IntPtr(0);
            sei.hwnd = new IntPtr(0);
            sei.lpClass = "";
            sei.lpDirectory = "";
            sei.lpFile = path;
            sei.lpIDList = new IntPtr(0);
            sei.lpParameters = "";
            sei.lpVerb = "properties";
            sei.nShow = Win32.SW_NORMAL;
            Win32.ShellExecuteEx(ref sei);
        }

        private void listView1ShowFuncSub(RegistryKey reg, ListViewItem item, string keyname, string type)
        {
            RegistryKey subreg = reg.OpenSubKey(keyname);

            if (CheckSubKeyName(subreg, "InprocServer32"))
            {
                RegistryKey tempreg = subreg.OpenSubKey("InprocServer32");

                if (CheckValueName(tempreg, ""))
                {
                    string value = tempreg.GetValue(null).ToString();
                    string company = GetFileCompanyName(value);

                    item.SubItems.AddRange(new string[] { type, value, company });

                    if (!company.Contains("Microsoft Cor"))
                    {
                        item.ForeColor = Color.Blue;
                    }
                }
                else
                {
                    item.SubItems.AddRange(new string[]{ type, "File not exists" });
                    item.ForeColor = Color.Blue;
                }

                tempreg.Close();
            }
            else
            {
                item.SubItems.AddRange(new string[] { type, "Invalid CLSID" });
                item.ForeColor = Color.Blue;
            }

            subreg.Close();
        }

        private void listView1ShowFunc(string keyname, string type)
        {
            RegistryKey reg = Registry.ClassesRoot.OpenSubKey("CLSID");
            RegistryKey subreg = Registry.ClassesRoot.OpenSubKey(keyname);

            foreach (String str in subreg.GetSubKeyNames())
            {
                ListViewItem item = new ListViewItem(str);
                RegistryKey tempreg = subreg.OpenSubKey(str);

                if (CheckValueName(tempreg, ""))
                {
                    if (CheckSubKeyName(reg, tempreg.GetValue(null).ToString()))
                    {
                        listView1ShowFuncSub(reg, item, tempreg.GetValue(null).ToString(), type);
                    }
                    else
                    {
                        item.SubItems.AddRange(new string[] { type, "CLSID not exists" });
                        item.ForeColor = Color.Blue;
                    }
                }
                else if (CheckSubKeyName(reg, str))
                {
                    listView1ShowFuncSub(reg, item, str, type);
                }
                else
                {
                    item.SubItems.AddRange(new string[] { type, "Invalid CLSID" });
                    item.ForeColor = Color.Blue;
                }

                tempreg.Close();

                listView1.Items.Add(item);
            }

            subreg.Close();
            reg.Close();
        }

        private void listView1Show()
        {
            try
            {
                RegistryKey reg = Registry.ClassesRoot.OpenSubKey("*");
                if(CheckSubKeyName(reg, "shell"))
                {
                    RegistryKey subreg = Registry.ClassesRoot.OpenSubKey("*\\shell");

                    foreach (string keyname in subreg.GetSubKeyNames())
                    {
                        ListViewItem item = new ListViewItem(keyname);

                        RegistryKey tempreg = subreg.OpenSubKey(keyname);

                        if (CheckSubKeyName(tempreg, "command"))
                        {
                            RegistryKey temp = tempreg.OpenSubKey("command");
                            string value = temp.GetValue(null).ToString();
                            item.SubItems.AddRange(new string[] { "shell", value });
                            temp.Close();
                            if (!GetFileCompanyName(value).Contains("Microsoft Cor"))
                                item.ForeColor = Color.Blue;
                        }
                        else
                        {
                            item.SubItems.AddRange(new string[] { "shell", "" });
                            item.ForeColor = Color.Blue;
                        }

                        tempreg.Close();

                        listView1.Items.Add(item);
                    }

                    subreg.Close();
                }
                reg.Close();

                listView1ShowFunc("*\\shellex\\ContextMenuHandlers", "shellEx");
                listView1ShowFunc("AllFilesystemObjects\\shellex\\ContextMenuHandlers", "AllFsos shellEx");
                listView1ShowFunc("Directory\\shellex\\ContextMenuHandlers", "Directory shellEx");
            }
            catch (Exception ex) { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1Show();
        }

        private void btnPathBrowse_Click(object sender, EventArgs e)
        {
            OFD.Filter = "All types(*.*)|*.*";
            OFD.Multiselect = false;
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtItemPath.Text = OFD.FileName;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtItemName.Clear();
            txtItemPath.Clear();
            txtItemArgs.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RegistryKey key = null;
            RegistryKey keySub = null;

            try
            {
                if (txtItemName.Text.Trim() == "")
                {
                    txtItemName.Focus();
                    return;
                }

                if (txtItemPath.Text.Trim() == "")
                {
                    txtItemPath.Focus();
                    return;
                }

                if (!CheckSubKeyName(Registry.ClassesRoot, "*\\shell"))
                {
                    Registry.ClassesRoot.OpenSubKey("*", true).CreateSubKey("shell");
                }

                key = Registry.ClassesRoot.OpenSubKey("*\\shell", true);

                if (CheckSubKeyName(key, txtItemName.Text))
                {
                    txtItemName.Focus();
                    key.Close();
                    return;
                }

                keySub = key.CreateSubKey(txtItemName.Text);
                keySub = keySub.CreateSubKey("command");
                keySub.SetValue("", txtItemPath.Text + " " + txtItemArgs.Text, RegistryValueKind.String);
                keySub.Close();

                MessageBox.Show("OK!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (key != null)
                    key.Close();
                if (keySub != null)
                    keySub.Close();
            }
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1Show();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key;
                ListViewItem item = listView1.SelectedItems[0];

                if (item.SubItems[1].Text == "shell")
                    key = Registry.ClassesRoot.OpenSubKey("*\\shell", true);
                else if (item.SubItems[1].Text == "shellEx")
                    key = Registry.ClassesRoot.OpenSubKey("*\\shellex\\ContextMenuHandlers", true);
                else if (item.SubItems[1].Text == "AllFsos shellEx")
                    key = Registry.ClassesRoot.OpenSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers", true);
                else
                    key = Registry.ClassesRoot.OpenSubKey("Directory\\shellex\\ContextMenuHandlers", true);

                key.DeleteSubKeyTree(item.SubItems[0].Text);
                key.Close();

                item.Remove();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tsmiExplorer_Click(object sender, EventArgs e)
        {
            ExplorerFile(listView1.SelectedItems[0].SubItems[2].Text);
            //ShowFileProperty(listView1.SelectedItems[0].SubItems[2].Text);
        }

        private void tsmiRegExplorer_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = listView1.SelectedItems[0];
                string str;

                if (item.SubItems[1].Text == "shell")
                    str = "*\\shell";
                else if (item.SubItems[1].Text == "shellEx")
                    str = "*\\shellex\\ContextMenuHandlers";
                else if (item.SubItems[1].Text == "AllFsos shellEx")
                    str = "AllFilesystemObjects\\shellex\\ContextMenuHandlers";
                else
                    str = "Directory\\shellex\\ContextMenuHandlers";

                ExplorerReg("HKEY_CLASSES_ROOT\\" + str + "\\" + item.SubItems[0].Text);           
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            listView1.Export();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
            {
                tsmiDelete.Enabled = false;
                tsmiExplorer.Enabled = false;
                tsmiRegExplorer.Enabled = false;
            }
            else
            {
                tsmiDelete.Enabled = true;
                tsmiExplorer.Enabled = true;
                tsmiRegExplorer.Enabled = true;
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == listView1.CurrentColumn)
            {
                if (listView1.asc)
                    listView1.asc = false;
                else
                    listView1.asc = true;
                listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, listView1.asc, 1, 0);
            }
            else
            {
                listView1.asc = false;
                listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, listView1.asc, 1, 0);
                listView1.CurrentColumn = e.Column;
            }
        }
    }
}
