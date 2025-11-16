namespace PhoManager.UI.Forms
{
    partial class FrmMonAn
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel rootLayout;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.TableLayoutPanel detailLayout;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label lblGiaNho;
        private System.Windows.Forms.NumericUpDown nudGiaNho;
        private System.Windows.Forms.Label lblGiaLon;
        private System.Windows.Forms.NumericUpDown nudGiaLon;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.FlowLayoutPanel actionPanel;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblHint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.detailLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.lblGiaNho = new System.Windows.Forms.Label();
            this.nudGiaNho = new System.Windows.Forms.NumericUpDown();
            this.lblGiaLon = new System.Windows.Forms.Label();
            this.nudGiaLon = new System.Windows.Forms.NumericUpDown();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.actionPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.rootLayout.SuspendLayout();
            this.searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            this.detailLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaNho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaLon)).BeginInit();
            this.actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // rootLayout
            // 
            this.rootLayout.ColumnCount = 1;
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Controls.Add(this.searchPanel, 0, 0);
            this.rootLayout.Controls.Add(this.splitContainer, 0, 1);
            this.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootLayout.Location = new System.Drawing.Point(0, 0);
            this.rootLayout.Name = "rootLayout";
            this.rootLayout.RowCount = 2;
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Size = new System.Drawing.Size(1234, 683);
            this.rootLayout.TabIndex = 0;
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.searchPanel.Controls.Add(this.btnLamMoi);
            this.searchPanel.Controls.Add(this.btnTimKiem);
            this.searchPanel.Controls.Add(this.txtTimKiem);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(23, 16, 23, 16);
            this.searchPanel.Size = new System.Drawing.Size(1234, 64);
            this.searchPanel.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.Location = new System.Drawing.Point(389, 18);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(103, 28);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTimKiem.Location = new System.Drawing.Point(274, 18);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(103, 28);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(23, 19);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(228, 30);
            this.txtTimKiem.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(3, 67);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvMonAn);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.detailLayout);
            this.splitContainer.Size = new System.Drawing.Size(1228, 613);
            this.splitContainer.SplitterDistance = 731;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 1;
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.AllowUserToAddRows = false;
            this.dgvMonAn.AllowUserToDeleteRows = false;
            this.dgvMonAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonAn.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonAn.ColumnHeadersHeight = 29;
            this.dgvMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonAn.Location = new System.Drawing.Point(0, 0);
            this.dgvMonAn.MultiSelect = false;
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.ReadOnly = true;
            this.dgvMonAn.RowHeadersVisible = false;
            this.dgvMonAn.RowHeadersWidth = 51;
            this.dgvMonAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonAn.Size = new System.Drawing.Size(731, 613);
            this.dgvMonAn.TabIndex = 0;
            this.dgvMonAn.SelectionChanged += new System.EventHandler(this.dgvMonAn_SelectionChanged);
            // 
            // detailLayout
            // 
            this.detailLayout.ColumnCount = 2;
            this.detailLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.detailLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.detailLayout.Controls.Add(this.lblTenMon, 0, 0);
            this.detailLayout.Controls.Add(this.txtTenMon, 1, 0);
            this.detailLayout.Controls.Add(this.lblGiaNho, 0, 1);
            this.detailLayout.Controls.Add(this.nudGiaNho, 1, 1);
            this.detailLayout.Controls.Add(this.lblGiaLon, 0, 2);
            this.detailLayout.Controls.Add(this.nudGiaLon, 1, 2);
            this.detailLayout.Controls.Add(this.lblGhiChu, 0, 3);
            this.detailLayout.Controls.Add(this.txtGhiChu, 1, 3);
            this.detailLayout.Controls.Add(this.lblMoTa, 0, 4);
            this.detailLayout.Controls.Add(this.txtMoTa, 1, 4);
            this.detailLayout.Controls.Add(this.chkTrangThai, 1, 5);
            this.detailLayout.Controls.Add(this.actionPanel, 1, 6);
            this.detailLayout.Controls.Add(this.lblHint, 1, 7);
            this.detailLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailLayout.Location = new System.Drawing.Point(0, 0);
            this.detailLayout.Name = "detailLayout";
            this.detailLayout.Padding = new System.Windows.Forms.Padding(11, 21, 11, 11);
            this.detailLayout.RowCount = 8;
            this.detailLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.detailLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.detailLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.detailLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.detailLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.detailLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.detailLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.detailLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.detailLayout.Size = new System.Drawing.Size(492, 613);
            this.detailLayout.TabIndex = 0;
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenMon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenMon.Location = new System.Drawing.Point(14, 21);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(135, 53);
            this.lblTenMon.TabIndex = 0;
            this.lblTenMon.Text = "Tên món";
            this.lblTenMon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenMon
            // 
            this.txtTenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenMon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenMon.Location = new System.Drawing.Point(155, 24);
            this.txtTenMon.MaxLength = 100;
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(323, 30);
            this.txtTenMon.TabIndex = 1;
            // 
            // lblGiaNho
            // 
            this.lblGiaNho.AutoSize = true;
            this.lblGiaNho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGiaNho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGiaNho.Location = new System.Drawing.Point(14, 74);
            this.lblGiaNho.Name = "lblGiaNho";
            this.lblGiaNho.Size = new System.Drawing.Size(135, 53);
            this.lblGiaNho.TabIndex = 2;
            this.lblGiaNho.Text = "Giá tô nhỏ";
            this.lblGiaNho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudGiaNho
            // 
            this.nudGiaNho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudGiaNho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudGiaNho.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudGiaNho.Location = new System.Drawing.Point(155, 77);
            this.nudGiaNho.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudGiaNho.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudGiaNho.Name = "nudGiaNho";
            this.nudGiaNho.Size = new System.Drawing.Size(323, 30);
            this.nudGiaNho.TabIndex = 3;
            this.nudGiaNho.ThousandsSeparator = true;
            this.nudGiaNho.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblGiaLon
            // 
            this.lblGiaLon.AutoSize = true;
            this.lblGiaLon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGiaLon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGiaLon.Location = new System.Drawing.Point(14, 127);
            this.lblGiaLon.Name = "lblGiaLon";
            this.lblGiaLon.Size = new System.Drawing.Size(135, 53);
            this.lblGiaLon.TabIndex = 4;
            this.lblGiaLon.Text = "Giá tô lớn";
            this.lblGiaLon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudGiaLon
            // 
            this.nudGiaLon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudGiaLon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudGiaLon.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudGiaLon.Location = new System.Drawing.Point(155, 130);
            this.nudGiaLon.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.nudGiaLon.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudGiaLon.Name = "nudGiaLon";
            this.nudGiaLon.Size = new System.Drawing.Size(323, 30);
            this.nudGiaLon.TabIndex = 5;
            this.nudGiaLon.ThousandsSeparator = true;
            this.nudGiaLon.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGhiChu.Location = new System.Drawing.Point(14, 180);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(135, 96);
            this.lblGhiChu.TabIndex = 6;
            this.lblGhiChu.Text = "Ghi chú";
            this.lblGhiChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGhiChu.Location = new System.Drawing.Point(155, 183);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(323, 90);
            this.txtGhiChu.TabIndex = 7;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMoTa.Location = new System.Drawing.Point(14, 276);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(135, 128);
            this.lblMoTa.TabIndex = 8;
            this.lblMoTa.Text = "Mô tả";
            this.lblMoTa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMoTa.Location = new System.Drawing.Point(155, 279);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.Size = new System.Drawing.Size(323, 122);
            this.txtMoTa.TabIndex = 9;
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Checked = true;
            this.chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThai.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkTrangThai.Location = new System.Drawing.Point(155, 413);
            this.chkTrangThai.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(96, 31);
            this.chkTrangThai.TabIndex = 10;
            this.chkTrangThai.Text = "Đang bán";
            this.chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // actionPanel
            // 
            this.actionPanel.Controls.Add(this.btnThem);
            this.actionPanel.Controls.Add(this.btnSua);
            this.actionPanel.Controls.Add(this.btnXoa);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionPanel.Location = new System.Drawing.Point(152, 447);
            this.actionPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 11);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(329, 97);
            this.actionPanel.TabIndex = 11;
            this.actionPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.actionPanel_Paint);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(67)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(3, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 43);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(204)))), ((int)(((byte)(66)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Location = new System.Drawing.Point(109, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 43);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Cập nhật";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(68)))), ((int)(((byte)(55)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(215, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 43);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblHint.ForeColor = System.Drawing.Color.DimGray;
            this.lblHint.Location = new System.Drawing.Point(155, 582);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(323, 20);
            this.lblHint.TabIndex = 12;
            this.lblHint.Text = "* Giá tính theo đồng Việt Nam";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmMonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1234, 683);
            this.Controls.Add(this.rootLayout);
            this.Name = "FrmMonAn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Món ăn";
            this.rootLayout.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            this.detailLayout.ResumeLayout(false);
            this.detailLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaNho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaLon)).EndInit();
            this.actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}

