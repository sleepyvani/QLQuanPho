using PhoManager.UI.Helpers;

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

        // Labels for input fields (added to guide user input)
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.Label lblTrangThai;

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
            this.txtTimKiemNV = new System.Windows.Forms.TextBox();
            this.btnTimKiemNV = new System.Windows.Forms.Button();
            //
            // lblHoTen
            //
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(1000, 40);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(56, 17);
            this.lblHoTen.TabIndex = 11;
            this.lblHoTen.Text = "Họ tên";
            //
            // lblTaiKhoan
            //
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Location = new System.Drawing.Point(1000, 89);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(74, 17);
            this.lblTaiKhoan.TabIndex = 12;
            this.lblTaiKhoan.Text = "Tài khoản";
            //
            // lblMatKhau
            //
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(1000, 138);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(71, 17);
            this.lblMatKhau.TabIndex = 13;
            this.lblMatKhau.Text = "Mật khẩu";
            //
            // lblChucVu
            //
            this.lblChucVu = new System.Windows.Forms.Label();
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Location = new System.Drawing.Point(1000, 187);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(62, 17);
            this.lblChucVu.TabIndex = 14;
            this.lblChucVu.Text = "Chức vụ";
            //
            // lblTrangThai
            //
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(1000, 236);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(76, 17);
            this.lblTrangThai.TabIndex = 15;
            this.lblTrangThai.Text = "Trạng thái";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.ColumnHeadersHeight = 29;
            this.dgvNhanVien.Location = new System.Drawing.Point(27, 25);
            this.dgvNhanVien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.Size = new System.Drawing.Size(933, 492);
            this.dgvNhanVien.TabIndex = 0;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(1000, 62);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(265, 22);
            this.txtHoTen.TabIndex = 1;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(1000, 111);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(265, 22);
            this.txtTaiKhoan.TabIndex = 2;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(1000, 160);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(265, 22);
            this.txtMatKhau.TabIndex = 3;
            // 
            // cboChucVu
            // 
            this.cboChucVu.Items.AddRange(new object[] {
            "Quản lý",
            "Thu ngân",
            "Bếp"});
            this.cboChucVu.Location = new System.Drawing.Point(1000, 209);
            this.cboChucVu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(265, 24);
            this.cboChucVu.TabIndex = 4;
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.Checked = true;
            this.chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThai.Location = new System.Drawing.Point(1000, 258);
            this.chkTrangThai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(139, 30);
            this.chkTrangThai.TabIndex = 5;
            this.chkTrangThai.Text = "Hoạt động";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(1000, 308);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 37);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(1147, 308);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 37);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(1000, 357);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 37);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            // 
            // txtTimKiemNV
            // 
            this.txtTimKiemNV.Location = new System.Drawing.Point(1000, 25);
            this.txtTimKiemNV.Name = "txtTimKiemNV";
            this.txtTimKiemNV.Size = new System.Drawing.Size(186, 22);
            this.txtTimKiemNV.TabIndex = 9;
            this.txtTimKiemNV.TextChanged += new System.EventHandler(this.txtTimKiemNV_TextChanged);
            // 
            // btnTimKiemNV
            // 
            this.btnTimKiemNV.Location = new System.Drawing.Point(1192, 24);
            this.btnTimKiemNV.Name = "btnTimKiemNV";
            this.btnTimKiemNV.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiemNV.TabIndex = 10;
            this.btnTimKiemNV.Text = "Tìm Kiếm";
            this.btnTimKiemNV.UseVisualStyleBackColor = true;
            this.btnTimKiemNV.Click += new System.EventHandler(this.btnTimKiemNV_Click);
            // 
            // FrmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ThemeManager.BackgroundColor;
            this.ClientSize = new System.Drawing.Size(1333, 554);
            this.Controls.Add(this.btnTimKiemNV);
            this.Controls.Add(this.txtTimKiemNV);
            this.Controls.Add(this.dgvNhanVien);
            // add labels for user inputs before controls
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.lblTaiKhoan);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.lblChucVu);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.cboChucVu);
            this.Controls.Add(this.chkTrangThai);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

        private System.Windows.Forms.TextBox txtTimKiemNV;
        private System.Windows.Forms.Button btnTimKiemNV;

        // Note: label fields are declared at the top of this partial class. Removed duplicate declarations here to prevent ambiguity.
    }
}

