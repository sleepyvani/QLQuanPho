namespace PhoManager.UI.Forms
{
    partial class FrmCauHinh
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLuu;

        private void InitializeComponent()
        {
            this.btnLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            this.btnLuu.Location = new System.Drawing.Point(50, 50);
            this.btnLuu.Size = new System.Drawing.Size(150, 40);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.btnLuu);
            this.Name = "FrmCauHinh";
            this.Text = "Cấu hình hệ thống";
            this.ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
    }
}