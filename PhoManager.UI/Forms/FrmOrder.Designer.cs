namespace PhoManager.UI.Forms
{
    partial class FrmOrder
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cboBan;
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.ComboBox cboKichCo;
        private System.Windows.Forms.TextBox txtGhiChuMon;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Label lblTongTien;

        private void InitializeComponent()
        {
            this.cboBan = new System.Windows.Forms.ComboBox();
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.cboKichCo = new System.Windows.Forms.ComboBox();
            this.txtGhiChuMon = new System.Windows.Forms.TextBox();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            
            this.cboBan.Location = new System.Drawing.Point(20, 20);
            this.cboBan.Size = new System.Drawing.Size(200, 21);
            this.cboBan.SelectedIndexChanged += new System.EventHandler(this.cboBan_SelectedIndexChanged);
            
            this.dgvMonAn.Location = new System.Drawing.Point(20, 60);
            this.dgvMonAn.Size = new System.Drawing.Size(500, 300);
            
            this.dgvChiTiet.Location = new System.Drawing.Point(550, 60);
            this.dgvChiTiet.Size = new System.Drawing.Size(400, 300);
            
            this.txtSoLuong.Location = new System.Drawing.Point(20, 380);
            this.txtSoLuong.Text = "1";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 20);
            
            this.cboKichCo.Location = new System.Drawing.Point(130, 380);
            this.cboKichCo.Size = new System.Drawing.Size(100, 21);
            this.cboKichCo.Items.AddRange(new object[] { "Nhỏ", "Lớn" });
            
            this.txtGhiChuMon.Location = new System.Drawing.Point(240, 380);
            this.txtGhiChuMon.Size = new System.Drawing.Size(200, 20);
            
            this.btnThemMon.Location = new System.Drawing.Point(450, 378);
            this.btnThemMon.Text = "Thêm món";
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            
            this.lblTongTien.Location = new System.Drawing.Point(550, 380);
            this.lblTongTien.Size = new System.Drawing.Size(400, 20);
            this.lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.cboBan);
            this.Controls.Add(this.dgvMonAn);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.cboKichCo);
            this.Controls.Add(this.txtGhiChuMon);
            this.Controls.Add(this.btnThemMon);
            this.Controls.Add(this.lblTongTien);
            this.Name = "FrmOrder";
            this.Text = "Gọi món (Order)";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
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

