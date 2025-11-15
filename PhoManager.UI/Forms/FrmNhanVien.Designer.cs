namespace PhoManager.UI.Forms
{
    partial class FrmNhanVien
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;

        private void InitializeComponent()
        {
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();
            
            this.dgvNhanVien.Location = new System.Drawing.Point(20, 20);
            this.dgvNhanVien.Size = new System.Drawing.Size(700, 400);
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            
            this.txtHoTen.Location = new System.Drawing.Point(750, 50);
            this.txtHoTen.Size = new System.Drawing.Size(200, 20);
            
            this.txtTaiKhoan.Location = new System.Drawing.Point(750, 90);
            this.txtTaiKhoan.Size = new System.Drawing.Size(200, 20);
            
            this.txtMatKhau.Location = new System.Drawing.Point(750, 130);
            this.txtMatKhau.Size = new System.Drawing.Size(200, 20);
            this.txtMatKhau.PasswordChar = '*';
            
            this.cboChucVu.Location = new System.Drawing.Point(750, 170);
            this.cboChucVu.Size = new System.Drawing.Size(200, 21);
            this.cboChucVu.Items.AddRange(new object[] { "Quản lý", "Thu ngân", "Bếp" });
            
            this.chkTrangThai.Location = new System.Drawing.Point(750, 210);
            this.chkTrangThai.Text = "Hoạt động";
            this.chkTrangThai.Checked = true;
            
            this.btnThem.Location = new System.Drawing.Point(750, 250);
            this.btnThem.Size = new System.Drawing.Size(90, 30);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            
            this.btnSua.Location = new System.Drawing.Point(860, 250);
            this.btnSua.Size = new System.Drawing.Size(90, 30);
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            
            this.btnXoa.Location = new System.Drawing.Point(750, 290);
            this.btnXoa.Size = new System.Drawing.Size(90, 30);
            this.btnXoa.Text = "Xóa";
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.cboChucVu);
            this.Controls.Add(this.chkTrangThai);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Name = "FrmNhanVien";
            this.Text = "Quản lý Nhân viên";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
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

