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
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Label lblBan;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblKichCo;
        private System.Windows.Forms.Label lblGhiChuMon;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.FlowLayoutPanel pnlInputs;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;

        private void InitializeComponent()
        {
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlInputs = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
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
            this.mainLayout.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlInputs.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.pnlTop, 0, 0);
            this.mainLayout.Controls.Add(this.pnlMiddle, 0, 1);
            this.mainLayout.Controls.Add(this.pnlBottom, 0, 2);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(ThemeManager.SpacingLG);
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.mainLayout.Size = new System.Drawing.Size(1333, 554);
            this.mainLayout.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblBan);
            this.pnlTop.Controls.Add(this.cboBan);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(23, 23);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1287, 54);
            this.pnlTop.TabIndex = 0;
            // 
            // lblBan
            // 
            this.lblBan.AutoSize = true;
            this.lblBan.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblBan.ForeColor = ThemeManager.TextPrimary;
            this.lblBan.Location = new System.Drawing.Point(0, 24);
            this.lblBan.Name = "lblBan";
            this.lblBan.Size = new System.Drawing.Size(75, 19);
            this.lblBan.TabIndex = 0;
            this.lblBan.Text = "Chọn bàn:";
            // 
            // cboBan
            // 
            this.cboBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboBan.Location = new System.Drawing.Point(90, 20);
            this.cboBan.Name = "cboBan";
            this.cboBan.Size = new System.Drawing.Size(280, 25);
            this.cboBan.TabIndex = 1;
            this.cboBan.SelectedIndexChanged += new System.EventHandler(this.cboBan_SelectedIndexChanged);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.dgvChiTiet);
            this.pnlMiddle.Controls.Add(this.dgvMonAn);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(24, 94);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Padding = new System.Windows.Forms.Padding(0, 0, 0, ThemeManager.SpacingMD);
            this.pnlMiddle.Size = new System.Drawing.Size(1285, 320);
            this.pnlMiddle.TabIndex = 1;
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMonAn.ColumnHeadersHeight = 48;
            this.dgvMonAn.Location = new System.Drawing.Point(0, 0);
            this.dgvMonAn.Margin = new System.Windows.Forms.Padding(0, 0, ThemeManager.SpacingMD, 0);
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.RowHeadersWidth = 51;
            this.dgvMonAn.Size = new System.Drawing.Size(630, 320);
            this.dgvMonAn.TabIndex = 0;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTiet.ColumnHeadersHeight = 48;
            this.dgvChiTiet.Location = new System.Drawing.Point(650, 0);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.Size = new System.Drawing.Size(635, 320);
            this.dgvChiTiet.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlInputs);
            this.pnlBottom.Controls.Add(this.pnlButtons);
            this.pnlBottom.Controls.Add(this.lblTongTien);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(24, 430);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1285, 130);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlInputs
            // 
            this.pnlInputs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInputs.Controls.Add(this.lblSoLuong);
            this.pnlInputs.Controls.Add(this.txtSoLuong);
            this.pnlInputs.Controls.Add(this.lblKichCo);
            this.pnlInputs.Controls.Add(this.cboKichCo);
            this.pnlInputs.Controls.Add(this.lblGhiChuMon);
            this.pnlInputs.Controls.Add(this.txtGhiChuMon);
            this.pnlInputs.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlInputs.Location = new System.Drawing.Point(0, 0);
            this.pnlInputs.Name = "pnlInputs";
            this.pnlInputs.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.pnlInputs.Size = new System.Drawing.Size(900, 70);
            this.pnlInputs.TabIndex = 0;
            this.pnlInputs.WrapContents = false;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblSoLuong.ForeColor = ThemeManager.TextPrimary;
            this.lblSoLuong.Location = new System.Drawing.Point(3, 20);
            this.lblSoLuong.Margin = new System.Windows.Forms.Padding(3, 0, ThemeManager.SpacingSM, 0);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(72, 19);
            this.lblSoLuong.TabIndex = 0;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoLuong.Location = new System.Drawing.Point(86, 17);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(3, 0, ThemeManager.SpacingLG, 0);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(120, 25);
            this.txtSoLuong.TabIndex = 1;
            this.txtSoLuong.Text = "1";
            // 
            // lblKichCo
            // 
            this.lblKichCo.AutoSize = true;
            this.lblKichCo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblKichCo.ForeColor = ThemeManager.TextPrimary;
            this.lblKichCo.Location = new System.Drawing.Point(229, 20);
            this.lblKichCo.Margin = new System.Windows.Forms.Padding(3, 0, ThemeManager.SpacingSM, 0);
            this.lblKichCo.Name = "lblKichCo";
            this.lblKichCo.Size = new System.Drawing.Size(64, 19);
            this.lblKichCo.TabIndex = 2;
            this.lblKichCo.Text = "Kích cỡ:";
            // 
            // cboKichCo
            // 
            this.cboKichCo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKichCo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboKichCo.Items.AddRange(new object[] {
            "Nhỏ",
            "Lớn"});
            this.cboKichCo.Location = new System.Drawing.Point(304, 17);
            this.cboKichCo.Margin = new System.Windows.Forms.Padding(3, 0, ThemeManager.SpacingLG, 0);
            this.cboKichCo.Name = "cboKichCo";
            this.cboKichCo.Size = new System.Drawing.Size(120, 25);
            this.cboKichCo.TabIndex = 3;
            // 
            // lblGhiChuMon
            // 
            this.lblGhiChuMon.AutoSize = true;
            this.lblGhiChuMon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblGhiChuMon.ForeColor = ThemeManager.TextPrimary;
            this.lblGhiChuMon.Location = new System.Drawing.Point(447, 20);
            this.lblGhiChuMon.Margin = new System.Windows.Forms.Padding(3, 0, ThemeManager.SpacingSM, 0);
            this.lblGhiChuMon.Name = "lblGhiChuMon";
            this.lblGhiChuMon.Size = new System.Drawing.Size(67, 19);
            this.lblGhiChuMon.TabIndex = 4;
            this.lblGhiChuMon.Text = "Ghi chú:";
            // 
            // txtGhiChuMon
            // 
            this.txtGhiChuMon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGhiChuMon.Location = new System.Drawing.Point(522, 17);
            this.txtGhiChuMon.Margin = new System.Windows.Forms.Padding(3, 0, ThemeManager.SpacingLG, 0);
            this.txtGhiChuMon.Name = "txtGhiChuMon";
            this.txtGhiChuMon.Size = new System.Drawing.Size(250, 25);
            this.txtGhiChuMon.TabIndex = 5;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtons.Controls.Add(this.btnThemMon);
            this.pnlButtons.Controls.Add(this.btnXoaMon);
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlButtons.Location = new System.Drawing.Point(920, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.pnlButtons.Size = new System.Drawing.Size(365, 70);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnThemMon
            // 
            this.btnThemMon.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnThemMon.Size = new System.Drawing.Size(120, 42);
            this.btnThemMon.TabIndex = 0;
            this.btnThemMon.Text = "Thêm món";
            this.btnThemMon.UseVisualStyleBackColor = false;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            ThemeManager.StyleButton(this.btnThemMon, ButtonVariant.Primary, IconGlyphs.Add);
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.Size = new System.Drawing.Size(120, 42);
            this.btnXoaMon.TabIndex = 1;
            this.btnXoaMon.Text = "Xóa món";
            this.btnXoaMon.UseVisualStyleBackColor = false;
            this.btnXoaMon.Click += new System.EventHandler(this.btnXoaMon_Click_1);
            ThemeManager.StyleButton(this.btnXoaMon, ButtonVariant.Danger, IconGlyphs.Delete);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.lblTongTien.ForeColor = ThemeManager.PrimaryColor;
            this.lblTongTien.Location = new System.Drawing.Point(0, 90);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(1285, 40);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ThemeManager.BackgroundPrimary;
            this.ClientSize = new System.Drawing.Size(1333, 554);
            this.Controls.Add(this.mainLayout);
            ThemeManager.StyleDataGridView(this.dgvMonAn);
            ThemeManager.StyleDataGridView(this.dgvChiTiet);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmOrder";
            this.Text = "Gọi món (Order)";
            this.mainLayout.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlInputs.ResumeLayout(false);
            this.pnlInputs.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
    }
}
