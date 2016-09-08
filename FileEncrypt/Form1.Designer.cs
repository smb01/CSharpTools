namespace FileEncrypt
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.btnEncryt = new System.Windows.Forms.Button();
            this.chkKeyFile = new System.Windows.Forms.CheckBox();
            this.chkMasterPwd = new System.Windows.Forms.CheckBox();
            this.btnKeyFileBrw = new System.Windows.Forms.Button();
            this.btnSaveFileBrw = new System.Windows.Forms.Button();
            this.btnFileBrw = new System.Windows.Forms.Button();
            this.txtSaveFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKeyFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMasterPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(346, 151);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(65, 25);
            this.btnDecrypt.TabIndex = 10;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncryt
            // 
            this.btnEncryt.Location = new System.Drawing.Point(277, 151);
            this.btnEncryt.Name = "btnEncryt";
            this.btnEncryt.Size = new System.Drawing.Size(65, 25);
            this.btnEncryt.TabIndex = 9;
            this.btnEncryt.Text = "Encrypt";
            this.btnEncryt.UseVisualStyleBackColor = true;
            this.btnEncryt.Click += new System.EventHandler(this.btnEncryt_Click);
            // 
            // chkKeyFile
            // 
            this.chkKeyFile.AutoSize = true;
            this.chkKeyFile.Location = new System.Drawing.Point(12, 47);
            this.chkKeyFile.Name = "chkKeyFile";
            this.chkKeyFile.Size = new System.Drawing.Size(15, 14);
            this.chkKeyFile.TabIndex = 31;
            this.chkKeyFile.UseVisualStyleBackColor = true;
            this.chkKeyFile.CheckedChanged += new System.EventHandler(this.chkKeyFile_CheckedChanged);
            // 
            // chkMasterPwd
            // 
            this.chkMasterPwd.AutoSize = true;
            this.chkMasterPwd.Location = new System.Drawing.Point(12, 20);
            this.chkMasterPwd.Name = "chkMasterPwd";
            this.chkMasterPwd.Size = new System.Drawing.Size(15, 14);
            this.chkMasterPwd.TabIndex = 30;
            this.chkMasterPwd.UseVisualStyleBackColor = true;
            this.chkMasterPwd.CheckedChanged += new System.EventHandler(this.chkMasterPwd_CheckedChanged);
            // 
            // btnKeyFileBrw
            // 
            this.btnKeyFileBrw.Location = new System.Drawing.Point(381, 42);
            this.btnKeyFileBrw.Name = "btnKeyFileBrw";
            this.btnKeyFileBrw.Size = new System.Drawing.Size(30, 25);
            this.btnKeyFileBrw.TabIndex = 8;
            this.btnKeyFileBrw.Text = "...";
            this.btnKeyFileBrw.UseVisualStyleBackColor = true;
            this.btnKeyFileBrw.Click += new System.EventHandler(this.btnKeyFileBrw_Click);
            // 
            // btnSaveFileBrw
            // 
            this.btnSaveFileBrw.Location = new System.Drawing.Point(382, 110);
            this.btnSaveFileBrw.Name = "btnSaveFileBrw";
            this.btnSaveFileBrw.Size = new System.Drawing.Size(30, 25);
            this.btnSaveFileBrw.TabIndex = 3;
            this.btnSaveFileBrw.Text = "...";
            this.btnSaveFileBrw.UseVisualStyleBackColor = true;
            this.btnSaveFileBrw.Click += new System.EventHandler(this.btnSaveFileBrw_Click);
            // 
            // btnFileBrw
            // 
            this.btnFileBrw.Location = new System.Drawing.Point(382, 82);
            this.btnFileBrw.Name = "btnFileBrw";
            this.btnFileBrw.Size = new System.Drawing.Size(30, 25);
            this.btnFileBrw.TabIndex = 1;
            this.btnFileBrw.Text = "...";
            this.btnFileBrw.UseVisualStyleBackColor = true;
            this.btnFileBrw.Click += new System.EventHandler(this.btnFileBrw_Click);
            // 
            // txtSaveFile
            // 
            this.txtSaveFile.AllowDrop = true;
            this.txtSaveFile.Location = new System.Drawing.Point(49, 112);
            this.txtSaveFile.Name = "txtSaveFile";
            this.txtSaveFile.Size = new System.Drawing.Size(327, 20);
            this.txtSaveFile.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Save";
            // 
            // txtFile
            // 
            this.txtFile.AllowDrop = true;
            this.txtFile.Location = new System.Drawing.Point(49, 84);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(327, 20);
            this.txtFile.TabIndex = 0;
            this.txtFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFile_DragDrop);
            this.txtFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFile_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "File";
            // 
            // txtKeyFile
            // 
            this.txtKeyFile.AllowDrop = true;
            this.txtKeyFile.Location = new System.Drawing.Point(119, 44);
            this.txtKeyFile.Name = "txtKeyFile";
            this.txtKeyFile.Size = new System.Drawing.Size(257, 20);
            this.txtKeyFile.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Key File:";
            // 
            // txtMasterPwd
            // 
            this.txtMasterPwd.AllowDrop = true;
            this.txtMasterPwd.Location = new System.Drawing.Point(119, 17);
            this.txtMasterPwd.Name = "txtMasterPwd";
            this.txtMasterPwd.PasswordChar = '*';
            this.txtMasterPwd.Size = new System.Drawing.Size(257, 20);
            this.txtMasterPwd.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Master Password:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 153);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(260, 20);
            this.progressBar1.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 193);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncryt);
            this.Controls.Add(this.chkKeyFile);
            this.Controls.Add(this.chkMasterPwd);
            this.Controls.Add(this.btnKeyFileBrw);
            this.Controls.Add(this.btnSaveFileBrw);
            this.Controls.Add(this.btnFileBrw);
            this.Controls.Add(this.txtSaveFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKeyFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMasterPwd);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileEncrypt 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.FolderBrowserDialog FBD;
        private System.Windows.Forms.Button btnEncryt;
        private System.Windows.Forms.CheckBox chkKeyFile;
        private System.Windows.Forms.CheckBox chkMasterPwd;
        private System.Windows.Forms.Button btnKeyFileBrw;
        private System.Windows.Forms.Button btnSaveFileBrw;
        private System.Windows.Forms.Button btnFileBrw;
        private System.Windows.Forms.TextBox txtSaveFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKeyFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMasterPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

