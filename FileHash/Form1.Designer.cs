namespace FileHash
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.probarFile = new System.Windows.Forms.ProgressBar();
            this.probarTotal = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.chkVersion = new System.Windows.Forms.CheckBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkMD5 = new System.Windows.Forms.CheckBox();
            this.chkSHA1 = new System.Windows.Forms.CheckBox();
            this.chkCRC32 = new System.Windows.Forms.CheckBox();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.AllowDrop = true;
            this.txtResult.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(13, 13);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(506, 233);
            this.txtResult.TabIndex = 0;
            this.txtResult.WordWrap = false;
            this.txtResult.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtResult_DragDrop);
            this.txtResult.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtResult_DragEnter);
            // 
            // probarFile
            // 
            this.probarFile.Location = new System.Drawing.Point(60, 289);
            this.probarFile.Name = "probarFile";
            this.probarFile.Size = new System.Drawing.Size(377, 19);
            this.probarFile.TabIndex = 1;
            // 
            // probarTotal
            // 
            this.probarTotal.Location = new System.Drawing.Point(60, 315);
            this.probarTotal.Name = "probarTotal";
            this.probarTotal.Size = new System.Drawing.Size(377, 19);
            this.probarTotal.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 252);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(73, 25);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "&Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(100, 252);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(73, 25);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(188, 252);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(73, 25);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "&Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(276, 252);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(364, 252);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(73, 25);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "S&top";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkVersion
            // 
            this.chkVersion.AutoSize = true;
            this.chkVersion.Location = new System.Drawing.Point(451, 252);
            this.chkVersion.Name = "chkVersion";
            this.chkVersion.Size = new System.Drawing.Size(61, 17);
            this.chkVersion.TabIndex = 4;
            this.chkVersion.Text = "&Version";
            this.chkVersion.UseVisualStyleBackColor = true;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(451, 270);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(49, 17);
            this.chkDate.TabIndex = 4;
            this.chkDate.Text = "&Date";
            this.chkDate.UseVisualStyleBackColor = true;
            // 
            // chkMD5
            // 
            this.chkMD5.AutoSize = true;
            this.chkMD5.Location = new System.Drawing.Point(451, 287);
            this.chkMD5.Name = "chkMD5";
            this.chkMD5.Size = new System.Drawing.Size(49, 17);
            this.chkMD5.TabIndex = 4;
            this.chkMD5.Text = "&MD5";
            this.chkMD5.UseVisualStyleBackColor = true;
            // 
            // chkSHA1
            // 
            this.chkSHA1.AutoSize = true;
            this.chkSHA1.Location = new System.Drawing.Point(451, 304);
            this.chkSHA1.Name = "chkSHA1";
            this.chkSHA1.Size = new System.Drawing.Size(54, 17);
            this.chkSHA1.TabIndex = 4;
            this.chkSHA1.Text = "S&HA1";
            this.chkSHA1.UseVisualStyleBackColor = true;
            // 
            // chkCRC32
            // 
            this.chkCRC32.AutoSize = true;
            this.chkCRC32.Location = new System.Drawing.Point(451, 322);
            this.chkCRC32.Name = "chkCRC32";
            this.chkCRC32.Size = new System.Drawing.Size(60, 17);
            this.chkCRC32.TabIndex = 4;
            this.chkCRC32.Text = "C&RC32";
            this.chkCRC32.UseVisualStyleBackColor = true;
            // 
            // OFD
            // 
            this.OFD.Filter = "all files(*.*)|*.*";
            this.OFD.Multiselect = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 351);
            this.Controls.Add(this.chkCRC32);
            this.Controls.Add(this.chkSHA1);
            this.Controls.Add(this.chkMD5);
            this.Controls.Add(this.chkDate);
            this.Controls.Add(this.chkVersion);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.probarTotal);
            this.Controls.Add(this.probarFile);
            this.Controls.Add(this.txtResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileHash 1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ProgressBar probarFile;
        private System.Windows.Forms.ProgressBar probarTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox chkVersion;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkMD5;
        private System.Windows.Forms.CheckBox chkSHA1;
        private System.Windows.Forms.CheckBox chkCRC32;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.SaveFileDialog SFD;
    }
}

