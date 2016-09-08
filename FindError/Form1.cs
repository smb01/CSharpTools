using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace FindError
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        WinError werr = new WinError();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtErrCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    string strErrCode = txtErrCode.Text.Trim().ToLower();
                    if (strErrCode == "")
                        return;

                    listView1.Items.Clear();

                    StringBuilder sb = new StringBuilder(1024);

                    for (int i = 0; i < werr.dicErrInfo.Count; i++)
                    {
                        uint uDicCode = (uint)werr.dicErrInfo.GetKey(i);

                        if (strErrCode == uDicCode.ToString().ToLower() || strErrCode == uDicCode.ToString("x"))
                        {
                            WinError.FormatMessage(WinError.FORMAT_MESSAGE_FROM_SYSTEM, IntPtr.Zero, uDicCode, 0, sb, sb.Capacity, IntPtr.Zero);

                            string strValue = werr.dicErrInfo.GetByIndex(i) as string;

                            ListViewItem item = new ListViewItem(strValue);

                            item.SubItems.Add(uDicCode.ToString());
                            item.SubItems.Add(uDicCode.ToString());
                            item.SubItems.Add("0x" + uDicCode.ToString("x8"));
                            item.SubItems.Add(sb.ToString());

                            listView1.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
