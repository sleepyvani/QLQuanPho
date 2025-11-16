using PhoManager.UI.Helpers;

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
        private System.Windows.Forms.Label lblBan;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblKichCo;
        private System.Windows.Forms.Label lblGhiChuMon;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Button btnThanhToan;

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
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.lblBan = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblKichCo = new System.Windows.Forms.Label();
            this.lblGhiChuMon = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // cboBan
            // 
            this.cboBan.Location = new System.Drawing.Point(27, 25);
            this.cboBan.Margin = new System.Windows.Forms.Padding(4);
            this.cboBan.Name = "cboBan";
            this.cboBan.Size = new System.Drawing.Size(265, 24);
            this.cboBan.TabIndex = 0;
            this.cboBan.SelectedIndexChanged += new System.EventHandler(this.cboBan_SelectedIndexChanged);
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.ColumnHeadersHeight = 45;
            this.dgvMonAn.Location = new System.Drawing.Point(27, 74);
            this.dgvMonAn.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.RowHeadersWidth = 51;
            this.dgvMonAn.Size = new System.Drawing.Size(667, 369);
            this.dgvMonAn.TabIndex = 1;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.ColumnHeadersHeight = 45;
            this.dgvChiTiet.Location = new System.Drawing.Point(733, 74);
            this.dgvChiTiet.Margin = new System.Windows.Forms.Padding(4);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.Size = new System.Drawing.Size(533, 369);
            this.dgvChiTiet.TabIndex = 2;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(27, 468);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(132, 22);
            this.txtSoLuong.TabIndex = 3;
            this.txtSoLuong.Text = "1";
            // 
            // cboKichCo
            // 
            this.cboKichCo.Items.AddRange(new object[] {
            "Nhỏ",
            "Lớn"});
            this.cboKichCo.Location = new System.Drawing.Point(173, 468);
            this.cboKichCo.Margin = new System.Windows.Forms.Padding(4);
            this.cboKichCo.Name = "cboKichCo";
            this.cboKichCo.Size = new System.Drawing.Size(132, 24);
            this.cboKichCo.TabIndex = 4;
            // 
            // txtGhiChuMon
            // 
            this.txtGhiChuMon.Location = new System.Drawing.Point(320, 468);
            this.txtGhiChuMon.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChuMon.Name = "txtGhiChuMon";
            this.txtGhiChuMon.Size = new System.Drawing.Size(265, 22);
            this.txtGhiChuMon.TabIndex = 5;
            // 
            // btnThemMon
            // 
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnThemMon.Location = new System.Drawing.Point(600, 465);
            this.btnThemMon.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(120, 30);
            this.btnThemMon.TabIndex = 6;
            this.btnThemMon.Text = "Thêm món";
            this.btnThemMon.UseVisualStyleBackColor = true;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Location = new System.Drawing.Point(730, 37);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(533, 25);
            this.lblTongTien.TabIndex = 7;
            this.lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaMon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnXoaMon.Location = new System.Drawing.Point(1191, 465);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(120, 30);
            this.btnXoaMon.TabIndex = 8;
            this.btnXoaMon.Text = "Xóa món";
            this.btnXoaMon.UseVisualStyleBackColor = true;
            this.btnXoaMon.Click += new System.EventHandler(this.btnXoaMon_Click_1);
            // 
            // lblBan
            // 
            this.lblBan.AutoSize = true;
            this.lblBan.Location = new System.Drawing.Point(27, 5);
            this.lblBan.Name = "lblBan";
            this.lblBan.Size = new System.Drawing.Size(67, 16);
            this.lblBan.TabIndex = 9;
            this.lblBan.Text = "Chọn bàn:";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(27, 442);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(63, 16);
            this.lblSoLuong.TabIndex = 10;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // lblKichCo
            // 
            this.lblKichCo.AutoSize = true;
            this.lblKichCo.Location = new System.Drawing.Point(173, 442);
            this.lblKichCo.Name = "lblKichCo";
            this.lblKichCo.Size = new System.Drawing.Size(53, 16);
            this.lblKichCo.TabIndex = 11;
            this.lblKichCo.Text = "Kích cỡ:";
            // 
            // lblGhiChuMon
            // 
            this.lblGhiChuMon.AutoSize = true;
            this.lblGhiChuMon.Location = new System.Drawing.Point(320, 442);
            this.lblGhiChuMon.Name = "lblGhiChuMon";
            this.lblGhiChuMon.Size = new System.Drawing.Size(54, 16);
            this.lblGhiChuMon.TabIndex = 12;
            this.lblGhiChuMon.Text = "Ghi chú:";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnThanhToan.Location = new System.Drawing.Point(1144, 37);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(167, 30);
            this.btnThanhToan.TabIndex = 13;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // FrmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1333, 554);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnXoaMon);
            this.Controls.Add(this.lblBan);
            this.Controls.Add(this.cboBan);
            this.Controls.Add(this.dgvMonAn);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.lblKichCo);
            this.Controls.Add(this.cboKichCo);
            this.Controls.Add(this.lblGhiChuMon);
            this.Controls.Add(this.txtGhiChuMon);
            this.Controls.Add(this.btnThemMon);
            this.Controls.Add(this.lblTongTien);
            this.Margin = new System.Windows.Forms.Padding(4);
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

