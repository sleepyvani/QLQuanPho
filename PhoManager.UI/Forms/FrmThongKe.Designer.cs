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
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.ColumnHeadersHeight = 29;
            this.dgvThongKe.Location = new System.Drawing.Point(27, 74);
            this.dgvThongKe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.Size = new System.Drawing.Size(1067, 492);
            this.dgvThongKe.TabIndex = 0;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Location = new System.Drawing.Point(27, 25);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(265, 22);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Location = new System.Drawing.Point(320, 25);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(265, 22);
            this.dtpDenNgay.TabIndex = 2;
            // 
            // btnXemThongKe
            // 
            this.btnXemThongKe.Location = new System.Drawing.Point(613, 22);
            this.btnXemThongKe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXemThongKe.Name = "btnXemThongKe";
            this.btnXemThongKe.Size = new System.Drawing.Size(100, 28);
            this.btnXemThongKe.TabIndex = 3;
            this.btnXemThongKe.Text = "Xem thống kê";
            this.btnXemThongKe.Click += new System.EventHandler(this.btnXemThongKe_Click);
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 615);
            this.Controls.Add(this.dgvThongKe);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.btnXemThongKe);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

