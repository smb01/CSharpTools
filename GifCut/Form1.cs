using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace GifCut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int repeat;

        private void btnDcomSrc_Click(object sender, EventArgs e)
        {
            OFD.Multiselect = false;
            OFD.Filter = "Gif files(*.gif)|*.gif";
            if (OFD.ShowDialog() == DialogResult.OK)
                txtDcomSrc.Text = OFD.FileName;
        }

        private void btnDcomOut_Click(object sender, EventArgs e)
        {
            if (FBD.ShowDialog() == DialogResult.OK)
                txtDcomOut.Text = FBD.SelectedPath;
        }

        private void btnDcomBeign_Click(object sender, EventArgs e)
        {
            if (txtDcomSrc.Text.Trim() == "")
            {
                txtDcomSrc.Focus();
                return;
            }
            if (txtDcomOut.Text.Trim() == "")
            {
                txtDcomOut.Focus();
                return;
            }
            if (GifConvert.DecompressGif(txtDcomSrc.Text, txtDcomOut.Text))
                MessageBox.Show("OK");
        }

        private void chkRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRepeat.Checked)
                repeat = 0;
            else
                repeat = -1;
        }

        private void btnComBegin_Click(object sender, EventArgs e)
        {
            if (lvSrcFiles.Items.Count == 0)
                return;
            SFD.Filter = "Gif files(*.gif)|*.gif";
            if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<string> files = new List<string>();
                foreach(ListViewItem item in lvSrcFiles.Items)
                    files.Add(item.Text);
                if (GifConvert.CompressGif(files, SFD.FileName, int.Parse(cboTime.Text), repeat))
                    MessageBox.Show("OK");
            }
        }

        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OFD.Multiselect = true;
            OFD.Filter = "Jpg files(*.jpg)|*.jpg|Png files(*.png)|(*.png)|All files(*.*)|*.*";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in OFD.FileNames)
                {
                    ListViewItem item = new ListViewItem(file);
                    lvSrcFiles.Items.Add(item);
                }
            }
        }

        private void removeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for(int i = lvSrcFiles.Items.Count - 1; i >=0; i--)
            {
                ListViewItem item = lvSrcFiles.Items[i];
                if (item.Selected)
                    item.Remove();
            }
        }
    }
}
