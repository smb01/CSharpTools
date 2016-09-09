namespace GifCut
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
            this.components = new System.ComponentModel.Container();
            this.btnDcomBeign = new System.Windows.Forms.Button();
            this.btnDcomOut = new System.Windows.Forms.Button();
            this.btnDcomSrc = new System.Windows.Forms.Button();
            this.txtDcomOut = new System.Windows.Forms.TextBox();
            this.txtDcomSrc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnComBegin = new System.Windows.Forms.Button();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lvSrcFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboTime = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkRepeat = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDcomBeign
            // 
            this.btnDcomBeign.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDcomBeign.Location = new System.Drawing.Point(261, 85);
            this.btnDcomBeign.Name = "btnDcomBeign";
            this.btnDcomBeign.Size = new System.Drawing.Size(142, 25);
            this.btnDcomBeign.TabIndex = 4;
            this.btnDcomBeign.Text = "Start";
            this.btnDcomBeign.Click += new System.EventHandler(this.btnDcomBeign_Click);
            // 
            // btnDcomOut
            // 
            this.btnDcomOut.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDcomOut.Location = new System.Drawing.Point(371, 53);
            this.btnDcomOut.Name = "btnDcomOut";
            this.btnDcomOut.Size = new System.Drawing.Size(32, 25);
            this.btnDcomOut.TabIndex = 3;
            this.btnDcomOut.Text = "...";
            this.btnDcomOut.Click += new System.EventHandler(this.btnDcomOut_Click);
            // 
            // btnDcomSrc
            // 
            this.btnDcomSrc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDcomSrc.Location = new System.Drawing.Point(371, 23);
            this.btnDcomSrc.Name = "btnDcomSrc";
            this.btnDcomSrc.Size = new System.Drawing.Size(32, 25);
            this.btnDcomSrc.TabIndex = 1;
            this.btnDcomSrc.Text = "...";
            this.btnDcomSrc.Click += new System.EventHandler(this.btnDcomSrc_Click);
            // 
            // txtDcomOut
            // 
            this.txtDcomOut.Location = new System.Drawing.Point(42, 55);
            this.txtDcomOut.Name = "txtDcomOut";
            this.txtDcomOut.Size = new System.Drawing.Size(323, 20);
            this.txtDcomOut.TabIndex = 2;
            // 
            // txtDcomSrc
            // 
            this.txtDcomSrc.Location = new System.Drawing.Point(42, 25);
            this.txtDcomSrc.Name = "txtDcomSrc";
            this.txtDcomSrc.Size = new System.Drawing.Size(323, 20);
            this.txtDcomSrc.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Save:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File:";
            // 
            // btnComBegin
            // 
            this.btnComBegin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnComBegin.Location = new System.Drawing.Point(261, 234);
            this.btnComBegin.Name = "btnComBegin";
            this.btnComBegin.Size = new System.Drawing.Size(141, 25);
            this.btnComBegin.TabIndex = 4;
            this.btnComBegin.Text = "Start";
            this.btnComBegin.Click += new System.EventHandler(this.btnComBegin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(16, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Interval time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(160, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "(ms)";
            // 
            // lvSrcFiles
            // 
            this.lvSrcFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvSrcFiles.ContextMenuStrip = this.contextMenuStrip1;
            this.lvSrcFiles.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvSrcFiles.FullRowSelect = true;
            this.lvSrcFiles.Location = new System.Drawing.Point(5, 15);
            this.lvSrcFiles.Name = "lvSrcFiles";
            this.lvSrcFiles.ShowItemToolTips = true;
            this.lvSrcFiles.Size = new System.Drawing.Size(398, 213);
            this.lvSrcFiles.TabIndex = 22;
            this.lvSrcFiles.UseCompatibleStateImageBehavior = false;
            this.lvSrcFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Source file";
            this.columnHeader1.Width = 369;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem,
            this.removeFileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.addFileToolStripMenuItem.Text = "Add file";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.addFileToolStripMenuItem_Click);
            // 
            // removeFileToolStripMenuItem
            // 
            this.removeFileToolStripMenuItem.Name = "removeFileToolStripMenuItem";
            this.removeFileToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.removeFileToolStripMenuItem.Text = "Remove file";
            this.removeFileToolStripMenuItem.Click += new System.EventHandler(this.removeFileToolStripMenuItem_Click);
            // 
            // cboTime
            // 
            this.cboTime.DisplayMember = "Text";
            this.cboTime.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTime.FormattingEnabled = true;
            this.cboTime.ItemHeight = 15;
            this.cboTime.Location = new System.Drawing.Point(86, 236);
            this.cboTime.Name = "cboTime";
            this.cboTime.Size = new System.Drawing.Size(71, 21);
            this.cboTime.TabIndex = 20;
            this.cboTime.Text = "500";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDcomBeign);
            this.groupBox1.Controls.Add(this.btnDcomSrc);
            this.groupBox1.Controls.Add(this.txtDcomSrc);
            this.groupBox1.Controls.Add(this.btnDcomOut);
            this.groupBox1.Controls.Add(this.txtDcomOut);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(408, 115);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gif Decompress";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkRepeat);
            this.groupBox2.Controls.Add(this.lvSrcFiles);
            this.groupBox2.Controls.Add(this.cboTime);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnComBegin);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(8, 130);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(408, 267);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gif Compress";
            // 
            // chkRepeat
            // 
            this.chkRepeat.AutoSize = true;
            this.chkRepeat.Location = new System.Drawing.Point(198, 238);
            this.chkRepeat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkRepeat.Name = "chkRepeat";
            this.chkRepeat.Size = new System.Drawing.Size(56, 17);
            this.chkRepeat.TabIndex = 23;
            this.chkRepeat.Text = "repeat";
            this.chkRepeat.UseVisualStyleBackColor = true;
            this.chkRepeat.CheckedChanged += new System.EventHandler(this.chkRepeat_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 401);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GifCut 1.0";
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.FolderBrowserDialog FBD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDcomBeign;
        private System.Windows.Forms.Button btnDcomOut;
        private System.Windows.Forms.Button btnDcomSrc;
        private System.Windows.Forms.Button btnComBegin;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox cboTime;
        private System.Windows.Forms.TextBox txtDcomOut;
        private System.Windows.Forms.TextBox txtDcomSrc;
        private System.Windows.Forms.ListView lvSrcFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkRepeat;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFileToolStripMenuItem;
    }
}