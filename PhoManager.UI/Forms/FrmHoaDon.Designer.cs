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
            // 
            // btnXemHoaDon
            // 
            this.btnXemHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemHoaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnXemHoaDon.Location = new System.Drawing.Point(67, 62);
            this.btnXemHoaDon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXemHoaDon.Name = "btnXemHoaDon";
            this.btnXemHoaDon.Size = new System.Drawing.Size(200, 52);
            this.btnXemHoaDon.TabIndex = 0;
            this.btnXemHoaDon.Text = "Xem hóa đơn";
            this.btnXemHoaDon.UseVisualStyleBackColor = true;
            this.btnXemHoaDon.Click += new System.EventHandler(this.btnXemHoaDon_Click);
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInHoaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnInHoaDon.Location = new System.Drawing.Point(284, 62);
            this.btnInHoaDon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(200, 52);
            this.btnInHoaDon.TabIndex = 1;
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = true;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            // 
            // FrmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.btnXemHoaDon);
            this.Controls.Add(this.btnInHoaDon);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

