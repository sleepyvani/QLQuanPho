using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    partial class FrmHoaDon
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnXemHoaDon;
        private System.Windows.Forms.Button btnInHoaDon;

        private void InitializeComponent()
        {
            this.btnXemHoaDon = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            this.btnXemHoaDon.Location = new System.Drawing.Point(50, 50);
            this.btnXemHoaDon.Size = new System.Drawing.Size(150, 42);
            this.btnXemHoaDon.Text = "Xem hóa đơn";
            this.btnXemHoaDon.UseVisualStyleBackColor = false;
            this.btnXemHoaDon.Click += new System.EventHandler(this.btnXemHoaDon_Click);
            ThemeManager.StyleButton(this.btnXemHoaDon, ButtonVariant.Primary);
            
            this.btnInHoaDon.Location = new System.Drawing.Point(220, 50);
            this.btnInHoaDon.Size = new System.Drawing.Size(150, 42);
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = false;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            ThemeManager.StyleButton(this.btnInHoaDon, ButtonVariant.Secondary);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ThemeManager.BackgroundPrimary;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.btnXemHoaDon);
            this.Controls.Add(this.btnInHoaDon);
            this.Name = "FrmHoaDon";
            this.Text = "Hóa đơn";
            this.ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
    }
}

