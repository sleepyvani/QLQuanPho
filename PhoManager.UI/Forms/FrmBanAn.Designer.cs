namespace PhoManager.UI.Forms
{
    partial class FrmBanAn
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvBanAn;
        private System.Windows.Forms.TextBox txtTenBan;
        private System.Windows.Forms.TextBox txtSoLuongGhe;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;

        private void InitializeComponent()
        {
            this.dgvBanAn = new System.Windows.Forms.DataGridView();
            this.txtTenBan = new System.Windows.Forms.TextBox();
            this.txtSoLuongGhe = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanAn)).BeginInit();
            this.SuspendLayout();
            
            this.dgvBanAn.Location = new System.Drawing.Point(20, 20);
            this.dgvBanAn.Size = new System.Drawing.Size(700, 400);
            this.dgvBanAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            
            this.txtTenBan.Location = new System.Drawing.Point(750, 50);
            this.txtTenBan.Size = new System.Drawing.Size(200, 20);
            
            this.txtSoLuongGhe.Location = new System.Drawing.Point(750, 90);
            this.txtSoLuongGhe.Size = new System.Drawing.Size(200, 20);
            
            this.txtGhiChu.Location = new System.Drawing.Point(750, 130);
            this.txtGhiChu.Size = new System.Drawing.Size(200, 60);
            this.txtGhiChu.Multiline = true;
            
            this.btnThem.Location = new System.Drawing.Point(750, 210);
            this.btnThem.Size = new System.Drawing.Size(90, 30);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.dgvBanAn);
            this.Controls.Add(this.txtTenBan);
            this.Controls.Add(this.txtSoLuongGhe);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.btnThem);
            this.Name = "FrmBanAn";
            this.Text = "Quản lý Bàn ăn";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanAn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
    }
}

