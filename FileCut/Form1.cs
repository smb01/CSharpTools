using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FileCut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        Thread thread = null;

        private void FileSplitter()
        {
            try
            {
                Int64 size = 0;
                Int64 size_rem = 0;
                int count = 0;
                double percentum_now = 0;
                double percentum_old = 0;
                string strFile = txtFile.Text;
                string strSaveDir = txtSaveDir.Text;
                string strBat = "copy ";
                FileInfo fiSub = null;
                FileStream fs = null;
                FileStream fsSub = null;
                FileStream fsBat = null;
                BinaryReader br = null;
                BinaryWriter bw = null;

                FileInfo fi = new FileInfo(strFile);

                if (rdoSize.Checked)
                {
                    size = Int64.Parse(cboSize.Text.Replace(",", "")) * 1024;

                    if (fi.Length <= size)
                    {
                        cboSize.Focus();
                        return;
                    }

                    count = Convert.ToInt32(fi.Length / size);

                    if (fi.Length % size != 0)
                    {
                        size_rem = fi.Length - count * size;
                        count = count + 1;
                    }
                }
                else
                {
                    count = int.Parse(txtCount.Text);
                    size = fi.Length / count;

                    if (fi.Length % count != 0)
                    {
                        size_rem = count - fi.Length % count;
                        size = size + 1;
                    }
                }

                fs = fi.Open(FileMode.Open, FileAccess.Read);

                if (!Directory.Exists(strSaveDir))
                    Directory.CreateDirectory(strSaveDir);

                fsBat = new FileStream(strSaveDir + "\\" + fi.Name + ".bat", FileMode.Create);

                br = new BinaryReader(fs);

                txtStatus.AppendText(strFile + "\r\nStart cut......\r\n");

                for (int i = 0; i < count; i++)
                {
                    percentum_now = 0;
                    percentum_old = 0;

                    fiSub = new FileInfo(strSaveDir + "\\" + fi.Name + "_" + i.ToString());

                    txtStatus.AppendText("\r\nCreate " + fiSub.Name + "\r\n");

                    fsSub = fiSub.Open(FileMode.Create, FileAccess.Write, FileShare.Write);

                    bw = new BinaryWriter(fsSub);

                    txtStatus.AppendText("Write " + fiSub.Name + "\r\n");

                    if (i == count - 1)
                    {
                        strBat = strBat + "\"" + fi.Name + "_" + i.ToString() + "\"" + "/b " + "\"" + fi.Name + "\"";

                        Int64 size2 = (rdoSize.Checked ? size_rem : size - size_rem);

                        for (Int64 n = 0; n < size2; n++)
                        {
                            bw.Write(br.ReadByte());

                            percentum_now = Math.Round((Convert.ToDouble(n) / Convert.ToDouble(size2)), 2) * 100;

                            if (percentum_now > percentum_old)
                            {
                                percentum_old = percentum_now;
                                txtStatus.AppendText("... ... ... ... ... " + percentum_now.ToString() + "%\r\n");
                            }
                        }
                    }
                    else
                    {
                        strBat = strBat + "\"" + fi.Name + "_" + i.ToString() + "\"" +"/b + ";

                        for (Int64 n = 0; n < size; n++)
                        {
                            bw.Write(br.ReadByte());

                            percentum_now = Math.Round((Convert.ToDouble(n) / Convert.ToDouble(size)), 2) * 100;

                            if (percentum_now > percentum_old)
                            {
                                percentum_old = percentum_now;
                                txtStatus.AppendText("... ... ... ... ... " + percentum_now.ToString() + "%\r\n");
                            }
                        }
                    }

                    bw.Close();
                    fsSub.Close();
                }

                txtStatus.AppendText("\r\nCut finished!");

                fsBat.Write(System.Text.Encoding.Default.GetBytes(strBat), 0, System.Text.Encoding.Default.GetByteCount(strBat));

                br.Close();
                fs.Close();
                fsBat.Close();

                if (chkDelSrc.Checked)
                    File.Delete(strFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txtFile.Enabled = true;
                txtSaveDir.Enabled = true;
                btnStart.Enabled = true;
                rdoSize.Enabled = true;
                rdoCount.Enabled = true;
                txtCount.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null && thread.IsAlive)
            {
                MessageBox.Show("Please wait for the thread to exit.");
                e.Cancel = true;
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboSize.SelectedIndex = 2;
        }

        private void txtFile_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (Directory.Exists(paths[0]))
                    return;

                txtFile.Text = paths[0];
                txtSaveDir.Text = (new FileInfo(txtFile.Text)).DirectoryName;
            }
        }

        private void txtFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btnFileBrw_Click(object sender, EventArgs e)
        {
            OFD.Filter = "All types(*.*)|*.*";
            OFD.Multiselect = false;

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = OFD.FileName;
                txtSaveDir.Text = (new FileInfo(txtFile.Text)).DirectoryName;

                FileInfo fi_ = new FileInfo(OFD.FileName);

                unchecked
                {
                    if (fi_.Length < 1024 * 1024)
                        cboSize.SelectedIndex = 0;
                    else if (fi_.Length < 1024 * 1024 * 10)
                        cboSize.SelectedIndex = 1;
                    else if (fi_.Length < 1024 * 1024 * 100)
                        cboSize.SelectedIndex = 2;
                    else if (fi_.Length < 1024 * 1024 * 1000)
                        cboSize.SelectedIndex = 3;
                    else if (fi_.Length < 1024 * 1024 * 10000)
                        cboSize.SelectedIndex = 4;
                }
            }
        }

        private void btnFileSaveBrw_Click(object sender, EventArgs e)
        {
            FBD.ShowNewFolderButton = true;
            if (FBD.ShowDialog() == DialogResult.OK)
                txtSaveDir.Text = FBD.SelectedPath;
        }

        private void rdoSize_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSize.Checked)
            {
                cboSize.Enabled = true;
                txtCount.Enabled = false;
            }
            else
            {
                txtCount.Enabled = true;
                cboSize.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFile.Text))
            {
                txtFile.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtSaveDir.Text))
            {
                txtSaveDir.Focus();
                return;
            }

            if (rdoSize.Checked && string.IsNullOrEmpty(cboSize.Text))
            {
                cboSize.Focus();
                return;
            }

            if (rdoCount.Checked && string.IsNullOrEmpty(txtCount.Text))
            {
                txtCount.Focus();
                return;
            }

            txtFile.Enabled = false;
            txtSaveDir.Enabled = false;
            btnStart.Enabled = false;
            rdoSize.Enabled = false;
            rdoCount.Enabled = false;
            txtCount.Enabled = false;

            thread = new Thread(new ThreadStart(FileSplitter));
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
