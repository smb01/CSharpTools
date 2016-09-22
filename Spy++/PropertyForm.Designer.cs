namespace Spypp
{
    partial class PropertyForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCaption = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.lblClassStyle = new System.Windows.Forms.Label();
            this.lblExtStyle = new System.Windows.Forms.Label();
            this.lblStyle = new System.Windows.Forms.Label();
            this.lblHandle = new System.Windows.Forms.Label();
            this.cboClassStyle = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lbExtStyle = new System.Windows.Forms.ListBox();
            this.lbStyle = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtProcessInfo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtParentCaption = new System.Windows.Forms.TextBox();
            this.txtParentClassName = new System.Windows.Forms.TextBox();
            this.lblParentHandle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(337, 426);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txtCaption);
            this.tabPage1.Controls.Add(this.txtClassName);
            this.tabPage1.Controls.Add(this.lblClassStyle);
            this.tabPage1.Controls.Add(this.lblExtStyle);
            this.tabPage1.Controls.Add(this.lblStyle);
            this.tabPage1.Controls.Add(this.lblHandle);
            this.tabPage1.Controls.Add(this.cboClassStyle);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.lbExtStyle);
            this.tabPage1.Controls.Add(this.lbStyle);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(329, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // txtCaption
            // 
            this.txtCaption.Location = new System.Drawing.Point(100, 34);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.ReadOnly = true;
            this.txtCaption.Size = new System.Drawing.Size(203, 20);
            this.txtCaption.TabIndex = 21;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(100, 58);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.ReadOnly = true;
            this.txtClassName.Size = new System.Drawing.Size(203, 20);
            this.txtClassName.TabIndex = 21;
            // 
            // lblClassStyle
            // 
            this.lblClassStyle.AutoSize = true;
            this.lblClassStyle.Location = new System.Drawing.Point(100, 284);
            this.lblClassStyle.Name = "lblClassStyle";
            this.lblClassStyle.Size = new System.Drawing.Size(28, 13);
            this.lblClassStyle.TabIndex = 20;
            this.lblClassStyle.Text = "style";
            // 
            // lblExtStyle
            // 
            this.lblExtStyle.AutoSize = true;
            this.lblExtStyle.Location = new System.Drawing.Point(100, 184);
            this.lblExtStyle.Name = "lblExtStyle";
            this.lblExtStyle.Size = new System.Drawing.Size(28, 13);
            this.lblExtStyle.TabIndex = 20;
            this.lblExtStyle.Text = "style";
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.Location = new System.Drawing.Point(100, 90);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(28, 13);
            this.lblStyle.TabIndex = 20;
            this.lblStyle.Text = "style";
            // 
            // lblHandle
            // 
            this.lblHandle.AutoSize = true;
            this.lblHandle.Location = new System.Drawing.Point(100, 14);
            this.lblHandle.Name = "lblHandle";
            this.lblHandle.Size = new System.Drawing.Size(39, 13);
            this.lblHandle.TabIndex = 20;
            this.lblHandle.Text = "handle";
            // 
            // cboClassStyle
            // 
            this.cboClassStyle.FormattingEnabled = true;
            this.cboClassStyle.Location = new System.Drawing.Point(172, 280);
            this.cboClassStyle.Name = "cboClassStyle";
            this.cboClassStyle.Size = new System.Drawing.Size(146, 21);
            this.cboClassStyle.TabIndex = 19;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 284);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Class Styles:";
            // 
            // lbExtStyle
            // 
            this.lbExtStyle.FormattingEnabled = true;
            this.lbExtStyle.Location = new System.Drawing.Point(13, 203);
            this.lbExtStyle.Name = "lbExtStyle";
            this.lbExtStyle.Size = new System.Drawing.Size(305, 69);
            this.lbExtStyle.TabIndex = 17;
            // 
            // lbStyle
            // 
            this.lbStyle.FormattingEnabled = true;
            this.lbStyle.Location = new System.Drawing.Point(13, 108);
            this.lbStyle.Name = "lbStyle";
            this.lbStyle.Size = new System.Drawing.Size(305, 69);
            this.lbStyle.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 184);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Extended Styles:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Window Styles:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Class Name:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 38);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "Window Caption:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 14);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "Window Handle:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage2.Controls.Add(this.txtProcessInfo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(329, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Process";
            // 
            // txtProcessInfo
            // 
            this.txtProcessInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProcessInfo.Location = new System.Drawing.Point(3, 3);
            this.txtProcessInfo.Multiline = true;
            this.txtProcessInfo.Name = "txtProcessInfo";
            this.txtProcessInfo.ReadOnly = true;
            this.txtProcessInfo.Size = new System.Drawing.Size(323, 394);
            this.txtProcessInfo.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtParentCaption);
            this.groupBox1.Controls.Add(this.txtParentClassName);
            this.groupBox1.Controls.Add(this.lblParentHandle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(14, 302);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 90);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parent Window";
            // 
            // txtParentCaption
            // 
            this.txtParentCaption.Location = new System.Drawing.Point(86, 40);
            this.txtParentCaption.Name = "txtParentCaption";
            this.txtParentCaption.ReadOnly = true;
            this.txtParentCaption.Size = new System.Drawing.Size(203, 20);
            this.txtParentCaption.TabIndex = 26;
            // 
            // txtParentClassName
            // 
            this.txtParentClassName.Location = new System.Drawing.Point(86, 62);
            this.txtParentClassName.Name = "txtParentClassName";
            this.txtParentClassName.ReadOnly = true;
            this.txtParentClassName.Size = new System.Drawing.Size(203, 20);
            this.txtParentClassName.TabIndex = 27;
            // 
            // lblParentHandle
            // 
            this.lblParentHandle.AutoSize = true;
            this.lblParentHandle.Location = new System.Drawing.Point(86, 22);
            this.lblParentHandle.Name = "lblParentHandle";
            this.lblParentHandle.Size = new System.Drawing.Size(39, 13);
            this.lblParentHandle.TabIndex = 25;
            this.lblParentHandle.Text = "handle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Class Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Caption:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Handle:";
            // 
            // PropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 426);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Property";
            this.Load += new System.EventHandler(this.PropertyForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblClassStyle;
        private System.Windows.Forms.Label lblExtStyle;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.Label lblHandle;
        private System.Windows.Forms.ComboBox cboClassStyle;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox lbExtStyle;
        private System.Windows.Forms.ListBox lbStyle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.TextBox txtCaption;
        private System.Windows.Forms.TextBox txtProcessInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtParentCaption;
        private System.Windows.Forms.TextBox txtParentClassName;
        private System.Windows.Forms.Label lblParentHandle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}