using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FileHash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool bStop = false;
        private List<string> lstFile = new List<string>();
        private Thread thread = null;

        private string BytesToStr(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
                sb.AppendFormat("{0:X2}", b);
            return sb.ToString();
        }

        private void AddText(string strText)
        {
            try
            {
                Action a = delegate()
                {
                    txtResult.AppendText(strText);
                    txtResult.ScrollToCaret();
                    Application.DoEvents();
                };
                this.Invoke(a);
            }
            catch (System.Exception ex) { throw ex; }
        }

        private void InitProbarValue(int FileMax, int TotalMax)
        {
            try
            {
                Action a = delegate()
                {
                    probarFile.Maximum = FileMax;
                    probarFile.Value = 0;
                    probarTotal.Maximum = TotalMax;
                    probarTotal.Value = 0;
                    Application.DoEvents();
                };
                this.Invoke(a);
            }
            catch (System.Exception ex) { throw ex; }
        }

        private void SetButtonState(bool bEnable)
        {
            try
            {
                Action a = delegate()
                {
                    btnBrowse.Enabled = bEnable;
                    btnClear.Enabled = bEnable;
                    btnCopy.Enabled = bEnable;
                    btnSave.Enabled = bEnable;
                    btnStop.Enabled = !bEnable;
                    Application.DoEvents();
                };
                this.Invoke(a);
            }
            catch (System.Exception ex) { throw ex; }
        }

        private void SetProbarFileValue(int value)
        {
            try
            {
                Action a = delegate()
                {
                    probarFile.Value = value;
                    Application.DoEvents();
                };
                this.Invoke(a);
            }
            catch (System.Exception ex) { throw ex; }
        }

        private void SetProbarTotalValue(int value)
        {
            try
            {
                Action a = delegate()
                {
                    probarTotal.Value = value;
                    Application.DoEvents();
                };
                this.Invoke(a);
            }
            catch (System.Exception ex) { throw ex; }
        }

        private void HashFile(object obj)
        {
            List<string> lstFile = null;

            try
            {
                lstFile = obj as List<string>;

                if (lstFile.Count == 0)
                    return;

                InitProbarValue(100, lstFile.Count);

                SetButtonState(false);

                bStop = false;

                for (int i = 0; i < lstFile.Count; i++)
                {
                    string strFile = lstFile[i];

                    AddText("Name   :" + strFile + "\r\n");

                    using (FileStream fs = new FileStream(strFile, FileMode.Open))
                    {
                        long totalRead = 0;
                        const int ClockLength = 1024 * 1024;
                        byte[] bytetoread = new byte[ClockLength];

                        MD5CryptoServiceProvider md5 = null;
                        SHA1Managed sha1 = null;
                        CRC32 crc32 = null;

                        if(chkMD5.Checked)
                            md5 = new MD5CryptoServiceProvider();

                        if(chkSHA1.Checked)
                            sha1 = new SHA1Managed();

                        if(chkCRC32.Checked)
                            crc32 = new CRC32();

                        while (true)
                        {
                            if (bStop)
                                break;

                            int nRead = fs.Read(bytetoread, 0, ClockLength);
							
                            if (chkMD5.Checked)
                                md5.TransformBlock(bytetoread, 0, nRead, bytetoread, 0);

                            if (chkSHA1.Checked)
                                sha1.TransformBlock(bytetoread, 0, nRead, bytetoread, 0);

                            if (chkCRC32.Checked)
                                crc32.TransformBlock(bytetoread, 0, nRead);

                            totalRead += nRead;

                            if (fs.Length != 0)
                                SetProbarFileValue((int)((double)totalRead / (double)fs.Length * 100));                         

                            if (totalRead >= fs.Length)
                                break;
                        }

                        fs.Close();

                        SetProbarTotalValue(i + 1);

                        if (!bStop)
                        {
                            if (chkMD5.Checked)
                                md5.TransformFinalBlock(bytetoread, 0, 0);

                            if (chkSHA1.Checked)
                                sha1.TransformFinalBlock(bytetoread, 0, 0);

                            if (chkCRC32.Checked)
                                crc32.TransformFinalBlock(bytetoread, 0, 0);

                            if(chkVersion.Checked)
                            {
                                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(strFile);
                                AddText("Version:" + fvi.FileVersion + "\r\n");                       
                            }

                            if (chkDate.Checked)
                            {
                                FileInfo fi = new FileInfo(strFile);
                                AddText("Date   :" + fi.LastWriteTime.ToLocalTime().ToString() + "\r\n");
                            }

                            if (chkMD5.Checked)
                                AddText("MD5    :" + BytesToStr(md5.Hash) + "\r\n");

                            if (chkSHA1.Checked)
                                AddText("SHA1   :" + BytesToStr(sha1.Hash) + "\r\n");

                            if (chkCRC32.Checked)
                                AddText("CRC32  :" + crc32.hash.ToString("X8") + "\r\n\r\n");
                        }
                        else
                        {
                            AddText("Stoped\r\n\r\n");
                        }
                    }
                }
            }
            catch (Exception ex) 
            { 
                AddText("Exception:" + ex.Message + "\r\n\r\n"); 
            }
            finally
            {
                if(lstFile != null)
                    lstFile.Clear();

                SetButtonState(true);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chkVersion.Checked = true;
            chkDate.Checked = true;
            chkMD5.Checked = true;
            chkSHA1.Checked = true;
            chkCRC32.Checked = true;
            SetButtonState(true);
        }

        private void txtResult_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if(thread != null && thread.IsAlive)
                {
                    MessageBox.Show("There are tasks being processed, please wait add.");
                    return;
                }

                string[] strsPath = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int i = 0; i < strsPath.Length; i++)
                {
                    if (Directory.Exists(strsPath[i]))
                        continue;
                    lstFile.Add(strsPath[i]);
                }

                thread = new Thread(new ParameterizedThreadStart(HashFile));
                thread.IsBackground = true;
                thread.Start(lstFile);
            }
        }

        private void txtResult_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if(OFD.ShowDialog() == DialogResult.OK)
            {
                string[] strsPath = OFD.FileNames;

                for (int i = 0; i < strsPath.Length; i++)
                {
                    if (Directory.Exists(strsPath[i]))
                        continue;
                    lstFile.Add(strsPath[i]);
                }

                thread = new Thread(new ParameterizedThreadStart(HashFile));
                thread.IsBackground = true;
                thread.Start(lstFile);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if(txtResult.Text.Trim() != "")
                Clipboard.SetDataObject(txtResult.Text, true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SFD.Filter = "txt files(*.txt)|*.txt|all files(*.*)|*.*";
                if (SFD.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(SFD.FileName, txtResult.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            bStop = true;
        }
    }
}
