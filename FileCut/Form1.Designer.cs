namespace FileCut
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
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFileSaveBrw = new System.Windows.Forms.Button();
            this.btnFileBrw = new System.Windows.Forms.Button();
            this.txtSaveDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.rdoCount = new System.Windows.Forms.RadioButton();
            this.rdoSize = new System.Windows.Forms.RadioButton();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDelSrc = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "(KB)";
            // 
            // btnFileSaveBrw
            // 
            this.btnFileSaveBrw.Location = new System.Drawing.Point(294, 44);
            this.btnFileSaveBrw.Name = "btnFileSaveBrw";
            this.btnFileSaveBrw.Size = new System.Drawing.Size(42, 25);
            this.btnFileSaveBrw.TabIndex = 3;
            this.btnFileSaveBrw.Text = "...";
            this.btnFileSaveBrw.UseVisualStyleBackColor = true;
            this.btnFileSaveBrw.Click += new System.EventHandler(this.btnFileSaveBrw_Click);
            // 
            // btnFileBrw
            // 
            this.btnFileBrw.Location = new System.Drawing.Point(294, 13);
            this.btnFileBrw.Name = "btnFileBrw";
            this.btnFileBrw.Size = new System.Drawing.Size(42, 25);
            this.btnFileBrw.TabIndex = 1;
            this.btnFileBrw.Text = "...";
            this.btnFileBrw.UseVisualStyleBackColor = true;
            this.btnFileBrw.Click += new System.EventHandler(this.btnFileBrw_Click);
            // 
            // txtSaveDir
            // 
            this.txtSaveDir.AllowDrop = true;
            this.txtSaveDir.Location = new System.Drawing.Point(50, 46);
            this.txtSaveDir.Name = "txtSaveDir";
            this.txtSaveDir.Size = new System.Drawing.Size(240, 20);
            this.txtSaveDir.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Save";
            // 
            // txtFile
            // 
            this.txtFile.AllowDrop = true;
            this.txtFile.Location = new System.Drawing.Point(50, 14);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(240, 20);
            this.txtFile.TabIndex = 0;
            this.txtFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFile_DragDrop);
            this.txtFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFile_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "File";
            // 
            // txtStatus
            // 
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.Location = new System.Drawing.Point(3, 16);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(328, 187);
            this.txtStatus.TabIndex = 11;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(123, 18);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(157, 25);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // rdoCount
            // 
            this.rdoCount.AutoSize = true;
            this.rdoCount.Checked = true;
            this.rdoCount.Location = new System.Drawing.Point(10, 79);
            this.rdoCount.Name = "rdoCount";
            this.rdoCount.Size = new System.Drawing.Size(90, 17);
            this.rdoCount.TabIndex = 8;
            this.rdoCount.TabStop = true;
            this.rdoCount.Text = "Volume count";
            this.rdoCount.UseVisualStyleBackColor = true;
            // 
            // rdoSize
            // 
            this.rdoSize.AutoSize = true;
            this.rdoSize.Location = new System.Drawing.Point(10, 51);
            this.rdoSize.Name = "rdoSize";
            this.rdoSize.Size = new System.Drawing.Size(81, 17);
            this.rdoSize.TabIndex = 6;
            this.rdoSize.Text = "Volume size";
            this.rdoSize.UseVisualStyleBackColor = true;
            this.rdoSize.CheckedChanged += new System.EventHandler(this.rdoSize_CheckedChanged);
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(123, 77);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(157, 20);
            this.txtCount.TabIndex = 9;
            this.txtCount.Text = "3";
            // 
            // cboSize
            // 
            this.cboSize.Enabled = false;
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Items.AddRange(new object[] {
            "512",
            "1,024",
            "10,240",
            "102,400",
            "1,024,000"});
            this.cboSize.Location = new System.Drawing.Point(123, 49);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(157, 21);
            this.cboSize.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Controls.Add(this.rdoCount);
            this.groupBox2.Controls.Add(this.rdoSize);
            this.groupBox2.Controls.Add(this.txtCount);
            this.groupBox2.Controls.Add(this.cboSize);
            this.groupBox2.Controls.Add(this.chkDelSrc);
            this.groupBox2.Location = new System.Drawing.Point(10, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 108);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // chkDelSrc
            // 
            this.chkDelSrc.AutoSize = true;
            this.chkDelSrc.Location = new System.Drawing.Point(10, 22);
            this.chkDelSrc.Name = "chkDelSrc";
            this.chkDelSrc.Size = new System.Drawing.Size(113, 17);
            this.chkDelSrc.TabIndex = 4;
            this.chkDelSrc.Text = "Delete source files";
            this.chkDelSrc.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Location = new System.Drawing.Point(10, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 206);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 426);
            this.Controls.Add(this.btnFileSaveBrw);
            this.Controls.Add(this.btnFileBrw);
            this.Controls.Add(this.txtSaveDir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileCut 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog FBD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFileSaveBrw;
        private System.Windows.Forms.Button btnFileBrw;
        private System.Windows.Forms.TextBox txtSaveDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.RadioButton rdoCount;
        private System.Windows.Forms.RadioButton rdoSize;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkDelSrc;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

