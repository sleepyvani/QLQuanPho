using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    partial class FrmBanAn
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvBanAn;
        private System.Windows.Forms.TextBox txtTenBan;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;

        // Labels to describe input fields for better user guidance
        private System.Windows.Forms.Label lblTenBan;
        private System.Windows.Forms.Label lblSoLuongGhe;
        private System.Windows.Forms.Label lblGhiChu;

        private void InitializeComponent()
        {
            this.dgvBanAn = new System.Windows.Forms.DataGridView();
            this.txtTenBan = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.nudSoLuongGhe = new System.Windows.Forms.NumericUpDown();
            this.txtTimKiemBan = new System.Windows.Forms.TextBox();
            this.btnTimKiemBan = new System.Windows.Forms.Button();
            this.lblTenBan = new System.Windows.Forms.Label();
            this.lblSoLuongGhe = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongGhe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBanAn
            // 
            this.dgvBanAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBanAn.ColumnHeadersHeight = 45;
            this.dgvBanAn.Location = new System.Drawing.Point(27, 25);
            this.dgvBanAn.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBanAn.Name = "dgvBanAn";
            this.dgvBanAn.RowHeadersWidth = 51;
            this.dgvBanAn.Size = new System.Drawing.Size(933, 492);
            this.dgvBanAn.TabIndex = 0;
            this.dgvBanAn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBanAn_CellContentClick);
            // 
            // txtTenBan
            // 
            this.txtTenBan.Location = new System.Drawing.Point(993, 70);
            this.txtTenBan.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenBan.Name = "txtTenBan";
            this.txtTenBan.Size = new System.Drawing.Size(265, 22);
            this.txtTenBan.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(993, 168);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(265, 73);
            this.txtGhiChu.TabIndex = 3;
            // 
            // btnThem
            // 
            this.btnThem.AutoSize = false;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnThem.Location = new System.Drawing.Point(993, 266);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 42);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnThem.UseCompatibleTextRendering = false;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.AutoSize = false;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnSua.Location = new System.Drawing.Point(1111, 266);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 42);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSua.UseCompatibleTextRendering = false;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AutoSize = false;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnXoa.Location = new System.Drawing.Point(993, 316);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 42);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnXoa.UseCompatibleTextRendering = false;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(2047, 146);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Visible = false;
            // 
            // nudSoLuongGhe
            // 
            this.nudSoLuongGhe.Location = new System.Drawing.Point(993, 122);
            this.nudSoLuongGhe.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuongGhe.Name = "nudSoLuongGhe";
            this.nudSoLuongGhe.Size = new System.Drawing.Size(265, 22);
            this.nudSoLuongGhe.TabIndex = 7;
            this.nudSoLuongGhe.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTimKiemBan
            // 
            this.txtTimKiemBan.Location = new System.Drawing.Point(993, 25);
            this.txtTimKiemBan.Name = "txtTimKiemBan";
            this.txtTimKiemBan.Size = new System.Drawing.Size(184, 22);
            this.txtTimKiemBan.TabIndex = 8;
            // 
            // btnTimKiemBan
            // 
            this.btnTimKiemBan.AutoSize = false;
            this.btnTimKiemBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemBan.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnTimKiemBan.Location = new System.Drawing.Point(1183, 24);
            this.btnTimKiemBan.Name = "btnTimKiemBan";
            this.btnTimKiemBan.Size = new System.Drawing.Size(140, 32);
            this.btnTimKiemBan.TabIndex = 9;
            this.btnTimKiemBan.Text = "Tìm kiếm";
            this.btnTimKiemBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTimKiemBan.UseCompatibleTextRendering = false;
            this.btnTimKiemBan.UseVisualStyleBackColor = true;
            this.btnTimKiemBan.Click += new System.EventHandler(this.btnTimKiemBan_Click);
            // 
            // lblTenBan
            // 
            this.lblTenBan.AutoSize = true;
            this.lblTenBan.Location = new System.Drawing.Point(990, 50);
            this.lblTenBan.Name = "lblTenBan";
            this.lblTenBan.Size = new System.Drawing.Size(57, 16);
            this.lblTenBan.TabIndex = 10;
            this.lblTenBan.Text = "Tên bàn";
            // 
            // lblSoLuongGhe
            // 
            this.lblSoLuongGhe.AutoSize = true;
            this.lblSoLuongGhe.Location = new System.Drawing.Point(993, 100);
            this.lblSoLuongGhe.Name = "lblSoLuongGhe";
            this.lblSoLuongGhe.Size = new System.Drawing.Size(86, 16);
            this.lblSoLuongGhe.TabIndex = 11;
            this.lblSoLuongGhe.Text = "Số lượng ghế";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(993, 148);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(51, 16);
            this.lblGhiChu.TabIndex = 12;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // FrmBanAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ThemeManager.BackgroundColor;
            this.ClientSize = new System.Drawing.Size(1333, 554);
            this.Controls.Add(this.btnTimKiemBan);
            this.Controls.Add(this.txtTimKiemBan);
            this.Controls.Add(this.lblTenBan);
            this.Controls.Add(this.lblSoLuongGhe);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.nudSoLuongGhe);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.dgvBanAn);
            this.Controls.Add(this.txtTenBan);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.btnThem);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBanAn";
            this.Text = "Quản lý Bàn ăn";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongGhe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown nudSoLuongGhe;
        private System.Windows.Forms.TextBox txtTimKiemBan;
        private System.Windows.Forms.Button btnTimKiemBan;

        // Note: label fields are declared at the top of this partial class. Removed duplicate declarations here to prevent ambiguity.
    }
}

