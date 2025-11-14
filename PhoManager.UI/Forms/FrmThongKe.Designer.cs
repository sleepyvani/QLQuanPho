using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    partial class FrmThongKe
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnXemThongKe;

        private void InitializeComponent()
        {
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXemThongKe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.SuspendLayout();
            
            this.dtpTuNgay.Location = new System.Drawing.Point(20, 20);
            this.dtpTuNgay.Size = new System.Drawing.Size(200, 20);
            
            this.dtpDenNgay.Location = new System.Drawing.Point(240, 20);
            this.dtpDenNgay.Size = new System.Drawing.Size(200, 20);
            
            this.btnXemThongKe.Location = new System.Drawing.Point(460, 18);
            this.btnXemThongKe.Size = new System.Drawing.Size(120, 42);
            this.btnXemThongKe.Text = "Xem thống kê";
            this.btnXemThongKe.UseVisualStyleBackColor = false;
            this.btnXemThongKe.Click += new System.EventHandler(this.btnXemThongKe_Click);
            ThemeManager.StyleButton(this.btnXemThongKe, ButtonVariant.Primary);
            
            this.dgvThongKe.Location = new System.Drawing.Point(20, 60);
            this.dgvThongKe.Size = new System.Drawing.Size(800, 400);
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ThemeManager.BackgroundPrimary;
            this.ClientSize = new System.Drawing.Size(900, 500);
            ThemeManager.StyleDataGridView(this.dgvThongKe);
            this.Controls.Add(this.dgvThongKe);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.btnXemThongKe);
            this.Name = "FrmThongKe";
            this.Text = "Thống kê";
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
    }
}

