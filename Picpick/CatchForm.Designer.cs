namespace Picpick
{
    partial class CatchForm
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
            this.picWndImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWndImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picWndImage
            // 
            this.picWndImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picWndImage.Location = new System.Drawing.Point(0, 0);
            this.picWndImage.Name = "picWndImage";
            this.picWndImage.Size = new System.Drawing.Size(292, 296);
            this.picWndImage.TabIndex = 0;
            this.picWndImage.TabStop = false;
            this.picWndImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picWndImage_MouseDown);
            this.picWndImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picWndImage_MouseMove);
            // 
            // CatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 296);
            this.Controls.Add(this.picWndImage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CatchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "picWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.picWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWndImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picWndImage;
    }
}
