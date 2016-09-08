using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FileEncrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        Thread thread = null;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(thread != null && thread.IsAlive)
            {
                MessageBox.Show("Please wait for the thread to exit.");
                e.Cancel = true;
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtMasterPwd.Enabled = false;
            txtKeyFile.Enabled = false;
        }

        private void chkMasterPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMasterPwd.Checked)
                txtMasterPwd.Enabled = true;
            else
                txtMasterPwd.Enabled = false;
        }

        private void chkKeyFile_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKeyFile.Checked)
                txtKeyFile.Enabled = true;
            else
                txtKeyFile.Enabled = false;
        }

        private void btnKeyFileBrw_Click(object sender, EventArgs e)
        {
            OFD.Filter = "All types(*.*)|*.*";
            OFD.Multiselect = false;
            if (OFD.ShowDialog() == DialogResult.OK)
                txtKeyFile.Text = OFD.FileName;
        }

        private void btnFileBrw_Click(object sender, EventArgs e)
        {
            OFD.Filter = "All types(*.*)|*.*";
            OFD.Multiselect = false;
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = OFD.FileName;
                if (Path.GetExtension(txtFile.Text).ToLower() == ".fe")
                    txtSaveFile.Text = Path.GetDirectoryName(txtFile.Text) + "\\" + Path.GetFileNameWithoutExtension(txtFile.Text);
                else
                    txtSaveFile.Text = txtFile.Text + ".fe";
            }
        }

        private void btnSaveFileBrw_Click(object sender, EventArgs e)
        {
            SFD.Filter = "All types(*.*)|*.*";
            if (SFD.ShowDialog() == DialogResult.OK)
                txtSaveFile.Text = SFD.FileName;
        }

        private void txtFile_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (Directory.Exists(paths[0]))
                    return;

                txtFile.Text = paths[0];

                if (Path.GetExtension(txtFile.Text).ToLower() == ".fe")
                    txtSaveFile.Text = Path.GetDirectoryName(txtFile.Text) + "\\" + Path.GetFileNameWithoutExtension(txtFile.Text);
                else
                    txtSaveFile.Text = txtFile.Text + ".fe";
            }
        }

        private void txtFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else 
                e.Effect = DragDropEffects.None;
        }

        private void btnEncryt_Click(object sender, EventArgs e)
        {
            byte[] bMasterPwd = null;
            byte[] bKeyFile = null;
            byte[] bPwd = null;
            int nLength = 0;
            int nOffset = 0;          
            FileStream fsKeyFile = null;

            if (!chkMasterPwd.Checked && !chkKeyFile.Checked)
                return;

            if (chkMasterPwd.Checked)
            {
                if (txtMasterPwd.TextLength == 0)
                {
                    txtMasterPwd.Focus();
                    return;
                }

                bMasterPwd = ASCIIEncoding.Default.GetBytes(txtMasterPwd.Text);
                nLength = bMasterPwd.Length;
            }

            if (chkKeyFile.Checked)
            {
                if (txtKeyFile.TextLength == 0)
                {
                    txtKeyFile.Focus();
                    return;
                }

                if (!File.Exists(txtKeyFile.Text))
                {
                    txtKeyFile.Focus();
                    return;
                }

                fsKeyFile = new FileStream(txtKeyFile.Text, FileMode.Open);
                bKeyFile = new byte[fsKeyFile.Length];
                fsKeyFile.Read(bKeyFile, 0, bKeyFile.Length);
                fsKeyFile.Close();
                nLength = nLength + bKeyFile.Length;
            }

            if (txtFile.TextLength == 0)
            {
                txtFile.Focus();
                return;
            }

            if (txtSaveFile.TextLength == 0)
            {
                txtSaveFile.Focus();
                return;
            }

            bPwd = new byte[nLength];

            if (bMasterPwd != null)
            {
                Buffer.BlockCopy(bMasterPwd, 0, bPwd, 0, bMasterPwd.Length);
                nOffset = bMasterPwd.Length;
            }

            if (bKeyFile != null)           
                Buffer.BlockCopy(bKeyFile, 0, bPwd, nOffset, bKeyFile.Length);
   
            aes aes = new aes(txtFile.Text, txtSaveFile.Text, bPwd, btnEncryt, btnDecrypt, progressBar1);

            thread = new Thread(new ThreadStart(aes.EncryptFile));
            thread.IsBackground = true;
            thread.Start();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            byte[] bMasterPwd = null;
            byte[] bKeyFile = null;
            byte[] bPwd = null;
            int nLength = 0;
            int nOffset = 0;
            FileStream fsKeyFile = null;

            if (!chkMasterPwd.Checked && !chkKeyFile.Checked)
                return;
    
            if (chkMasterPwd.Checked)
            {
                if (txtMasterPwd.TextLength == 0)
                {
                    txtMasterPwd.Focus();
                    return;
                }
                bMasterPwd = ASCIIEncoding.Default.GetBytes(txtMasterPwd.Text);
                nLength = bMasterPwd.Length;
            }

            if (chkKeyFile.Checked)
            {
                if (txtKeyFile.TextLength == 0)
                {
                    txtKeyFile.Focus();
                    return;
                }

                if (!File.Exists(txtKeyFile.Text))
                {
                    txtKeyFile.Focus();
                    return;
                }

                fsKeyFile = new FileStream(txtKeyFile.Text, FileMode.Open);
                bKeyFile = new byte[fsKeyFile.Length];
                fsKeyFile.Read(bKeyFile, 0, bKeyFile.Length);
                fsKeyFile.Close();
                nLength = nLength + bKeyFile.Length;
            }

            if (txtFile.TextLength == 0)
            {
                txtFile.Focus();
                return;
            }

            if (txtSaveFile.TextLength == 0)
            {
                txtSaveFile.Focus();
                return;
            }

            bPwd = new byte[nLength];
            if (bMasterPwd != null)
            {
                Buffer.BlockCopy(bMasterPwd, 0, bPwd, 0, bMasterPwd.Length);
                nOffset = bMasterPwd.Length;
            }

            if (bKeyFile != null)
                Buffer.BlockCopy(bKeyFile, 0, bPwd, nOffset, bKeyFile.Length);

            aes aes = new aes(txtFile.Text, txtSaveFile.Text, bPwd, btnEncryt, btnDecrypt, progressBar1);

            thread = new Thread(new ThreadStart(aes.DecryptFile));
            thread.IsBackground = true;
            thread.Start();
        }
    }
}