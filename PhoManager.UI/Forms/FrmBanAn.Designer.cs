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
            // Ẩn control numericUpDown1 vì không sử dụng
            this.numericUpDown1.Visible = false;
            this.nudSoLuongGhe = new System.Windows.Forms.NumericUpDown();
            this.txtTimKiemBan = new System.Windows.Forms.TextBox();
            this.btnTimKiemBan = new System.Windows.Forms.Button();
            //
            // lblTenBan
            //
            this.lblTenBan = new System.Windows.Forms.Label();
            this.lblTenBan.AutoSize = true;
            this.lblTenBan.Location = new System.Drawing.Point(1000, 40);
            this.lblTenBan.Name = "lblTenBan";
            this.lblTenBan.Size = new System.Drawing.Size(59, 17);
            this.lblTenBan.TabIndex = 10;
            this.lblTenBan.Text = "Tên bàn";
            //
            // lblSoLuongGhe
            //
            this.lblSoLuongGhe = new System.Windows.Forms.Label();
            this.lblSoLuongGhe.AutoSize = true;
            this.lblSoLuongGhe.Location = new System.Drawing.Point(1000, 92);
            this.lblSoLuongGhe.Name = "lblSoLuongGhe";
            this.lblSoLuongGhe.Size = new System.Drawing.Size(99, 17);
            this.lblSoLuongGhe.TabIndex = 11;
            this.lblSoLuongGhe.Text = "Số lượng ghế";
            //
            // lblGhiChu
            //
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(1000, 140);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(58, 17);
            this.lblGhiChu.TabIndex = 12;
            this.lblGhiChu.Text = "Ghi chú";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongGhe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBanAn
            // 
            this.dgvBanAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBanAn.ColumnHeadersHeight = 29;
            this.dgvBanAn.Location = new System.Drawing.Point(27, 25);
            this.dgvBanAn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvBanAn.Name = "dgvBanAn";
            this.dgvBanAn.RowHeadersWidth = 51;
            this.dgvBanAn.Size = new System.Drawing.Size(933, 492);
            this.dgvBanAn.TabIndex = 0;
            this.dgvBanAn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBanAn_CellContentClick);
            // 
            // txtTenBan
            // 
            this.txtTenBan.Location = new System.Drawing.Point(1000, 62);
            this.txtTenBan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenBan.Name = "txtTenBan";
            this.txtTenBan.Size = new System.Drawing.Size(265, 22);
            this.txtTenBan.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(1000, 160);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(265, 73);
            this.txtGhiChu.TabIndex = 3;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(1000, 258);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 37);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(1145, 258);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 37);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(1000, 303);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 37);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(2047, 146);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 0;
            // 
            // nudSoLuongGhe
            // 
            this.nudSoLuongGhe.Location = new System.Drawing.Point(1000, 114);
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
            this.txtTimKiemBan.Location = new System.Drawing.Point(1000, 25);
            this.txtTimKiemBan.Name = "txtTimKiemBan";
            this.txtTimKiemBan.Size = new System.Drawing.Size(184, 22);
            this.txtTimKiemBan.TabIndex = 8;
            // 
            // btnTimKiemBan
            // 
            this.btnTimKiemBan.Location = new System.Drawing.Point(1190, 24);
            this.btnTimKiemBan.Name = "btnTimKiemBan";
            this.btnTimKiemBan.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiemBan.TabIndex = 9;
            this.btnTimKiemBan.Text = "Tìm kiếm";
            this.btnTimKiemBan.UseVisualStyleBackColor = true;
            this.btnTimKiemBan.Click += new System.EventHandler(this.btnTimKiemBan_Click);
            // 
            // FrmBanAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 554);
            this.Controls.Add(this.btnTimKiemBan);
            this.Controls.Add(this.txtTimKiemBan);
            // Add labels before associated input controls
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

