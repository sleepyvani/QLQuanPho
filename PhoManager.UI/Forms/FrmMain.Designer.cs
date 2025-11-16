using System;
using System.Drawing;
using System.Windows.Forms;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.FlowLayoutPanel navBar;
        private System.Windows.Forms.Button btnNavOrder;
        private System.Windows.Forms.Button btnNavTables;
        private System.Windows.Forms.Button btnNavMenu;
        private System.Windows.Forms.Button btnNavStaff;
        private System.Windows.Forms.Button btnNavInvoices;
        private System.Windows.Forms.Button btnNavAnalytics;
        private System.Windows.Forms.Button btnNavSettings;
        private System.Windows.Forms.Button btnNavLogout;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Button btnQuickOrder;
        private System.Windows.Forms.FlowLayoutPanel cardContainer;
        private System.Windows.Forms.Panel cardRevenue;
        private System.Windows.Forms.Label lblRevenueCaption;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Label lblRevenueSub;
        private System.Windows.Forms.Panel cardOrders;
        private System.Windows.Forms.Label lblOrdersCaption;
        private System.Windows.Forms.Label lblOrdersValue;
        private System.Windows.Forms.Label lblOrdersSub;
        private System.Windows.Forms.Panel cardTables;
        private System.Windows.Forms.Label lblTablesCaption;
        private System.Windows.Forms.Label lblTablesValue;
        private System.Windows.Forms.Label lblTablesSub;
        private System.Windows.Forms.TableLayoutPanel quickActionPanel;
        private System.Windows.Forms.Button btnQuanLyMonAn;
        private System.Windows.Forms.Button btnQuanLyNhanVien;
        private System.Windows.Forms.Button btnQuanLyBanAn;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnCauHinh;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusDatabase;
        private System.Windows.Forms.ToolStripStatusLabel statusSpacer;
        private System.Windows.Forms.ToolStripStatusLabel statusUser;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.ContextMenuStrip ctxBaoCao;
        private System.Windows.Forms.ToolStripMenuItem ctxBaoCaoDoanhThu;
        private System.Windows.Forms.ToolStripMenuItem ctxBaoCaoMon;
        private System.Windows.Forms.ToolStripMenuItem ctxBaoCaoHoaDon;

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
            this.components = new System.ComponentModel.Container();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.navBar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNavOrder = new System.Windows.Forms.Button();
            this.btnNavTables = new System.Windows.Forms.Button();
            this.btnNavMenu = new System.Windows.Forms.Button();
            this.btnNavStaff = new System.Windows.Forms.Button();
            this.btnNavInvoices = new System.Windows.Forms.Button();
            this.btnNavAnalytics = new System.Windows.Forms.Button();
            this.ctxBaoCao = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxBaoCaoDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxBaoCaoMon = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxBaoCaoHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNavSettings = new System.Windows.Forms.Button();
            this.btnNavLogout = new System.Windows.Forms.Button();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.quickActionPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnQuanLyMonAn = new System.Windows.Forms.Button();
            this.btnQuanLyNhanVien = new System.Windows.Forms.Button();
            this.btnQuanLyBanAn = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnCauHinh = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.cardContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.cardRevenue = new System.Windows.Forms.Panel();
            this.lblRevenueSub = new System.Windows.Forms.Label();
            this.lblRevenueValue = new System.Windows.Forms.Label();
            this.lblRevenueCaption = new System.Windows.Forms.Label();
            this.cardOrders = new System.Windows.Forms.Panel();
            this.lblOrdersSub = new System.Windows.Forms.Label();
            this.lblOrdersValue = new System.Windows.Forms.Label();
            this.lblOrdersCaption = new System.Windows.Forms.Label();
            this.cardTables = new System.Windows.Forms.Panel();
            this.lblTablesSub = new System.Windows.Forms.Label();
            this.lblTablesValue = new System.Windows.Forms.Label();
            this.lblTablesCaption = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnQuickOrder = new System.Windows.Forms.Button();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.btnGioiThieu = new System.Windows.Forms.Button();
            this.pnlTopBar.SuspendLayout();
            this.navBar.SuspendLayout();
            this.ctxBaoCao.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.quickActionPanel.SuspendLayout();
            this.cardContainer.SuspendLayout();
            this.cardRevenue.SuspendLayout();
            this.cardOrders.SuspendLayout();
            this.cardTables.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.Add(this.navBar);
            this.pnlTopBar.Controls.Add(this.lblBrand);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Padding = new System.Windows.Forms.Padding(27, 17, 27, 17);
            this.pnlTopBar.Size = new System.Drawing.Size(1383, 68);
            this.pnlTopBar.TabIndex = 0;
            // 
            // navBar
            // 
            this.navBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.navBar.Controls.Add(this.btnNavOrder);
            this.navBar.Controls.Add(this.btnNavTables);
            this.navBar.Controls.Add(this.btnNavMenu);
            this.navBar.Controls.Add(this.btnNavStaff);
            this.navBar.Controls.Add(this.btnNavInvoices);
            this.navBar.Controls.Add(this.btnNavAnalytics);
            this.navBar.Controls.Add(this.btnNavSettings);
            this.navBar.Controls.Add(this.btnNavLogout);
            this.navBar.Location = new System.Drawing.Point(235, 17);
            this.navBar.Name = "navBar";
            this.navBar.Size = new System.Drawing.Size(1120, 34);
            this.navBar.TabIndex = 1;
            this.navBar.WrapContents = false;
            // 
            // btnNavOrder
            // 
            this.btnNavOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.btnNavOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavOrder.Location = new System.Drawing.Point(0, 3);
            this.btnNavOrder.Margin = new System.Windows.Forms.Padding(0, 3, 7, 3);
            this.btnNavOrder.Name = "btnNavOrder";
            this.btnNavOrder.Size = new System.Drawing.Size(126, 28);
            this.btnNavOrder.TabIndex = 0;
            this.btnNavOrder.Text = "Gọi món";
            this.btnNavOrder.UseVisualStyleBackColor = true;
            this.btnNavOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnNavTables
            // 
            this.btnNavTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavTables.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.btnNavTables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavTables.Location = new System.Drawing.Point(133, 3);
            this.btnNavTables.Margin = new System.Windows.Forms.Padding(0, 3, 7, 3);
            this.btnNavTables.Name = "btnNavTables";
            this.btnNavTables.Size = new System.Drawing.Size(149, 28);
            this.btnNavTables.TabIndex = 1;
            this.btnNavTables.Text = "Quản lý Bàn";
            this.btnNavTables.UseVisualStyleBackColor = true;
            this.btnNavTables.Click += new System.EventHandler(this.btnQuanLyBanAn_Click);
            // 
            // btnNavMenu
            // 
            this.btnNavMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.btnNavMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavMenu.Location = new System.Drawing.Point(289, 3);
            this.btnNavMenu.Margin = new System.Windows.Forms.Padding(0, 3, 7, 3);
            this.btnNavMenu.Name = "btnNavMenu";
            this.btnNavMenu.Size = new System.Drawing.Size(149, 28);
            this.btnNavMenu.TabIndex = 2;
            this.btnNavMenu.Text = "Quản lý Món";
            this.btnNavMenu.UseVisualStyleBackColor = true;
            this.btnNavMenu.Click += new System.EventHandler(this.btnQuanLyMonAn_Click);
            // 
            // btnNavStaff
            // 
            this.btnNavStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavStaff.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.btnNavStaff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavStaff.Location = new System.Drawing.Point(445, 3);
            this.btnNavStaff.Margin = new System.Windows.Forms.Padding(0, 3, 7, 3);
            this.btnNavStaff.Name = "btnNavStaff";
            this.btnNavStaff.Size = new System.Drawing.Size(126, 28);
            this.btnNavStaff.TabIndex = 3;
            this.btnNavStaff.Text = "Nhân viên";
            this.btnNavStaff.UseVisualStyleBackColor = true;
            this.btnNavStaff.Click += new System.EventHandler(this.btnQuanLyNhanVien_Click);
            // 
            // btnNavInvoices
            // 
            this.btnNavInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavInvoices.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.btnNavInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavInvoices.Location = new System.Drawing.Point(578, 3);
            this.btnNavInvoices.Margin = new System.Windows.Forms.Padding(0, 3, 7, 3);
            this.btnNavInvoices.Name = "btnNavInvoices";
            this.btnNavInvoices.Size = new System.Drawing.Size(114, 28);
            this.btnNavInvoices.TabIndex = 4;
            this.btnNavInvoices.Text = "Hóa đơn";
            this.btnNavInvoices.UseVisualStyleBackColor = true;
            this.btnNavInvoices.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnNavAnalytics
            // 
            this.btnNavAnalytics.ContextMenuStrip = this.ctxBaoCao;
            this.btnNavAnalytics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAnalytics.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.btnNavAnalytics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavAnalytics.Location = new System.Drawing.Point(699, 3);
            this.btnNavAnalytics.Margin = new System.Windows.Forms.Padding(0, 3, 7, 3);
            this.btnNavAnalytics.Name = "btnNavAnalytics";
            this.btnNavAnalytics.Size = new System.Drawing.Size(114, 28);
            this.btnNavAnalytics.TabIndex = 5;
            this.btnNavAnalytics.Text = "Báo cáo";
            this.btnNavAnalytics.UseVisualStyleBackColor = true;
            this.btnNavAnalytics.Click += new System.EventHandler(this.navAnalytics_Click);
            // 
            // ctxBaoCao
            // 
            this.ctxBaoCao.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxBaoCao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxBaoCaoDoanhThu,
            this.ctxBaoCaoMon,
            this.ctxBaoCaoHoaDon});
            this.ctxBaoCao.Name = "ctxBaoCao";
            this.ctxBaoCao.Size = new System.Drawing.Size(204, 76);
            // 
            // ctxBaoCaoDoanhThu
            // 
            this.ctxBaoCaoDoanhThu.Name = "ctxBaoCaoDoanhThu";
            this.ctxBaoCaoDoanhThu.Size = new System.Drawing.Size(203, 24);
            this.ctxBaoCaoDoanhThu.Text = "Báo cáo doanh thu";
            this.ctxBaoCaoDoanhThu.Click += new System.EventHandler(this.menuBaoCaoDoanhThu_Click);
            // 
            // ctxBaoCaoMon
            // 
            this.ctxBaoCaoMon.Name = "ctxBaoCaoMon";
            this.ctxBaoCaoMon.Size = new System.Drawing.Size(203, 24);
            this.ctxBaoCaoMon.Text = "Món bán chạy";
            this.ctxBaoCaoMon.Click += new System.EventHandler(this.menuBaoCaoMonBanChay_Click);
            // 
            // ctxBaoCaoHoaDon
            // 
            this.ctxBaoCaoHoaDon.Name = "ctxBaoCaoHoaDon";
            this.ctxBaoCaoHoaDon.Size = new System.Drawing.Size(203, 24);
            this.ctxBaoCaoHoaDon.Text = "Báo cáo hóa đơn";
            this.ctxBaoCaoHoaDon.Click += new System.EventHandler(this.menuBaoCaoHoaDon_Click);
            // 
            // btnNavSettings
            // 
            this.btnNavSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.btnNavSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNavSettings.Location = new System.Drawing.Point(820, 3);
            this.btnNavSettings.Margin = new System.Windows.Forms.Padding(0, 3, 7, 3);
            this.btnNavSettings.Name = "btnNavSettings";
            this.btnNavSettings.Size = new System.Drawing.Size(114, 28);
            this.btnNavSettings.TabIndex = 6;
            this.btnNavSettings.Text = "Cấu hình";
            this.btnNavSettings.UseVisualStyleBackColor = true;
            this.btnNavSettings.Click += new System.EventHandler(this.btnCauHinh_Click);
            // 
            // btnNavLogout
            // 
            this.btnNavLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.btnNavLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnNavLogout.Location = new System.Drawing.Point(941, 3);
            this.btnNavLogout.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnNavLogout.Name = "btnNavLogout";
            this.btnNavLogout.Size = new System.Drawing.Size(137, 28);
            this.btnNavLogout.TabIndex = 7;
            this.btnNavLogout.Text = "Đăng xuất";
            this.btnNavLogout.UseVisualStyleBackColor = true;
            this.btnNavLogout.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblBrand.Location = new System.Drawing.Point(27, 19);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(161, 32);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "Pho Manager";
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCurrentTime.Location = new System.Drawing.Point(1027, 15);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(143, 20);
            this.lblCurrentTime.TabIndex = 2;
            this.lblCurrentTime.Text = "00:00:00 01/01/2000";
            this.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlMain.Controls.Add(this.quickActionPanel);
            this.pnlMain.Controls.Add(this.cardContainer);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Controls.Add(this.statusStrip);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 68);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(27, 26, 27, 0);
            this.pnlMain.Size = new System.Drawing.Size(1383, 700);
            this.pnlMain.TabIndex = 1;
            // 
            // quickActionPanel
            // 
            this.quickActionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quickActionPanel.AutoScroll = true;
            this.quickActionPanel.BackColor = System.Drawing.Color.Transparent;
            this.quickActionPanel.ColumnCount = 5;
            this.quickActionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.quickActionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.quickActionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.quickActionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.quickActionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.quickActionPanel.Controls.Add(this.btnQuanLyMonAn, 0, 0);
            this.quickActionPanel.Controls.Add(this.btnQuanLyNhanVien, 1, 0);
            this.quickActionPanel.Controls.Add(this.btnQuanLyBanAn, 2, 0);
            this.quickActionPanel.Controls.Add(this.btnOrder, 3, 0);
            this.quickActionPanel.Controls.Add(this.btnHoaDon, 4, 0);
            this.quickActionPanel.Controls.Add(this.btnThongKe, 0, 1);
            this.quickActionPanel.Controls.Add(this.btnCauHinh, 1, 1);
            this.quickActionPanel.Controls.Add(this.btnDangXuat, 2, 1);
            this.quickActionPanel.Controls.Add(this.btnGioiThieu, 3, 1);
            this.quickActionPanel.Location = new System.Drawing.Point(27, 341);
            this.quickActionPanel.Name = "quickActionPanel";
            this.quickActionPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 21);
            this.quickActionPanel.RowCount = 2;
            this.quickActionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.quickActionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.quickActionPanel.Size = new System.Drawing.Size(1329, 331);
            this.quickActionPanel.TabIndex = 3;
            // 
            // btnQuanLyMonAn
            // 
            this.btnQuanLyMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuanLyMonAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyMonAn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnQuanLyMonAn.Location = new System.Drawing.Point(11, 11);
            this.btnQuanLyMonAn.Margin = new System.Windows.Forms.Padding(11);
            this.btnQuanLyMonAn.Name = "btnQuanLyMonAn";
            this.btnQuanLyMonAn.Size = new System.Drawing.Size(243, 133);
            this.btnQuanLyMonAn.TabIndex = 0;
            this.btnQuanLyMonAn.Text = "Quản lý Món";
            this.btnQuanLyMonAn.UseVisualStyleBackColor = true;
            this.btnQuanLyMonAn.Click += new System.EventHandler(this.btnQuanLyMonAn_Click);
            // 
            // btnQuanLyNhanVien
            // 
            this.btnQuanLyNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuanLyNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyNhanVien.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnQuanLyNhanVien.Location = new System.Drawing.Point(276, 11);
            this.btnQuanLyNhanVien.Margin = new System.Windows.Forms.Padding(11);
            this.btnQuanLyNhanVien.Name = "btnQuanLyNhanVien";
            this.btnQuanLyNhanVien.Size = new System.Drawing.Size(243, 133);
            this.btnQuanLyNhanVien.TabIndex = 1;
            this.btnQuanLyNhanVien.Text = "Nhân viên";
            this.btnQuanLyNhanVien.UseVisualStyleBackColor = true;
            this.btnQuanLyNhanVien.Click += new System.EventHandler(this.btnQuanLyNhanVien_Click);
            // 
            // btnQuanLyBanAn
            // 
            this.btnQuanLyBanAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuanLyBanAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyBanAn.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnQuanLyBanAn.Location = new System.Drawing.Point(541, 11);
            this.btnQuanLyBanAn.Margin = new System.Windows.Forms.Padding(11);
            this.btnQuanLyBanAn.Name = "btnQuanLyBanAn";
            this.btnQuanLyBanAn.Size = new System.Drawing.Size(243, 133);
            this.btnQuanLyBanAn.TabIndex = 2;
            this.btnQuanLyBanAn.Text = "Quản lý Bàn";
            this.btnQuanLyBanAn.UseVisualStyleBackColor = true;
            this.btnQuanLyBanAn.Click += new System.EventHandler(this.btnQuanLyBanAn_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnOrder.Location = new System.Drawing.Point(806, 11);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(11);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(243, 133);
            this.btnOrder.TabIndex = 3;
            this.btnOrder.Text = "Gọi món";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnHoaDon.Location = new System.Drawing.Point(1071, 11);
            this.btnHoaDon.Margin = new System.Windows.Forms.Padding(11);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(247, 133);
            this.btnHoaDon.TabIndex = 4;
            this.btnHoaDon.Text = "Hóa đơn";
            this.btnHoaDon.UseVisualStyleBackColor = true;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnThongKe.Location = new System.Drawing.Point(11, 166);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(11);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(243, 133);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnCauHinh
            // 
            this.btnCauHinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCauHinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCauHinh.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnCauHinh.Location = new System.Drawing.Point(276, 166);
            this.btnCauHinh.Margin = new System.Windows.Forms.Padding(11);
            this.btnCauHinh.Name = "btnCauHinh";
            this.btnCauHinh.Size = new System.Drawing.Size(243, 133);
            this.btnCauHinh.TabIndex = 6;
            this.btnCauHinh.Text = "Cấu hình";
            this.btnCauHinh.UseVisualStyleBackColor = true;
            this.btnCauHinh.Click += new System.EventHandler(this.btnCauHinh_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnDangXuat.Location = new System.Drawing.Point(541, 166);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(11);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(243, 133);
            this.btnDangXuat.TabIndex = 7;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // cardContainer
            // 
            this.cardContainer.AutoSize = true;
            this.cardContainer.Controls.Add(this.cardRevenue);
            this.cardContainer.Controls.Add(this.cardOrders);
            this.cardContainer.Controls.Add(this.cardTables);
            this.cardContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardContainer.Location = new System.Drawing.Point(27, 154);
            this.cardContainer.Margin = new System.Windows.Forms.Padding(0);
            this.cardContainer.Name = "cardContainer";
            this.cardContainer.Size = new System.Drawing.Size(1329, 188);
            this.cardContainer.TabIndex = 2;
            // 
            // cardRevenue
            // 
            this.cardRevenue.BackColor = System.Drawing.Color.White;
            this.cardRevenue.Controls.Add(this.lblRevenueSub);
            this.cardRevenue.Controls.Add(this.lblRevenueValue);
            this.cardRevenue.Controls.Add(this.lblRevenueCaption);
            this.cardRevenue.Location = new System.Drawing.Point(0, 0);
            this.cardRevenue.Margin = new System.Windows.Forms.Padding(0, 0, 21, 19);
            this.cardRevenue.Name = "cardRevenue";
            this.cardRevenue.Padding = new System.Windows.Forms.Padding(23, 21, 23, 21);
            this.cardRevenue.Size = new System.Drawing.Size(331, 169);
            this.cardRevenue.TabIndex = 0;
            // 
            // lblRevenueSub
            // 
            this.lblRevenueSub.AutoSize = true;
            this.lblRevenueSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRevenueSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblRevenueSub.Location = new System.Drawing.Point(23, 117);
            this.lblRevenueSub.Name = "lblRevenueSub";
            this.lblRevenueSub.Size = new System.Drawing.Size(175, 20);
            this.lblRevenueSub.TabIndex = 2;
            this.lblRevenueSub.Text = "Hôm nay so với hôm qua";
            // 
            // lblRevenueValue
            // 
            this.lblRevenueValue.AutoSize = true;
            this.lblRevenueValue.Font = new System.Drawing.Font("Segoe UI Semibold", 24F);
            this.lblRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblRevenueValue.Location = new System.Drawing.Point(23, 53);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new System.Drawing.Size(142, 54);
            this.lblRevenueValue.TabIndex = 1;
            this.lblRevenueValue.Text = "0 VND";
            // 
            // lblRevenueCaption
            // 
            this.lblRevenueCaption.AutoSize = true;
            this.lblRevenueCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblRevenueCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblRevenueCaption.Location = new System.Drawing.Point(23, 21);
            this.lblRevenueCaption.Name = "lblRevenueCaption";
            this.lblRevenueCaption.Size = new System.Drawing.Size(183, 25);
            this.lblRevenueCaption.TabIndex = 0;
            this.lblRevenueCaption.Text = "Doanh thu hôm nay";
            // 
            // cardOrders
            // 
            this.cardOrders.BackColor = System.Drawing.Color.White;
            this.cardOrders.Controls.Add(this.lblOrdersSub);
            this.cardOrders.Controls.Add(this.lblOrdersValue);
            this.cardOrders.Controls.Add(this.lblOrdersCaption);
            this.cardOrders.Location = new System.Drawing.Point(352, 0);
            this.cardOrders.Margin = new System.Windows.Forms.Padding(0, 0, 21, 19);
            this.cardOrders.Name = "cardOrders";
            this.cardOrders.Padding = new System.Windows.Forms.Padding(23, 21, 23, 21);
            this.cardOrders.Size = new System.Drawing.Size(331, 169);
            this.cardOrders.TabIndex = 1;
            // 
            // lblOrdersSub
            // 
            this.lblOrdersSub.AutoSize = true;
            this.lblOrdersSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrdersSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblOrdersSub.Location = new System.Drawing.Point(23, 117);
            this.lblOrdersSub.Name = "lblOrdersSub";
            this.lblOrdersSub.Size = new System.Drawing.Size(193, 20);
            this.lblOrdersSub.TabIndex = 2;
            this.lblOrdersSub.Text = "Đơn đã hoàn tất trong ngày";
            // 
            // lblOrdersValue
            // 
            this.lblOrdersValue.AutoSize = true;
            this.lblOrdersValue.Font = new System.Drawing.Font("Segoe UI Semibold", 24F);
            this.lblOrdersValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(165)))), ((int)(((byte)(250)))));
            this.lblOrdersValue.Location = new System.Drawing.Point(23, 53);
            this.lblOrdersValue.Name = "lblOrdersValue";
            this.lblOrdersValue.Size = new System.Drawing.Size(45, 54);
            this.lblOrdersValue.TabIndex = 1;
            this.lblOrdersValue.Text = "0";
            // 
            // lblOrdersCaption
            // 
            this.lblOrdersCaption.AutoSize = true;
            this.lblOrdersCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblOrdersCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblOrdersCaption.Location = new System.Drawing.Point(23, 21);
            this.lblOrdersCaption.Name = "lblOrdersCaption";
            this.lblOrdersCaption.Size = new System.Drawing.Size(126, 25);
            this.lblOrdersCaption.TabIndex = 0;
            this.lblOrdersCaption.Text = "Đơn hoàn tất";
            // 
            // cardTables
            // 
            this.cardTables.BackColor = System.Drawing.Color.White;
            this.cardTables.Controls.Add(this.lblTablesSub);
            this.cardTables.Controls.Add(this.lblTablesValue);
            this.cardTables.Controls.Add(this.lblTablesCaption);
            this.cardTables.Location = new System.Drawing.Point(704, 0);
            this.cardTables.Margin = new System.Windows.Forms.Padding(0, 0, 21, 19);
            this.cardTables.Name = "cardTables";
            this.cardTables.Padding = new System.Windows.Forms.Padding(23, 21, 23, 21);
            this.cardTables.Size = new System.Drawing.Size(331, 169);
            this.cardTables.TabIndex = 2;
            // 
            // lblTablesSub
            // 
            this.lblTablesSub.AutoSize = true;
            this.lblTablesSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTablesSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTablesSub.Location = new System.Drawing.Point(23, 117);
            this.lblTablesSub.Name = "lblTablesSub";
            this.lblTablesSub.Size = new System.Drawing.Size(127, 20);
            this.lblTablesSub.TabIndex = 2;
            this.lblTablesSub.Text = "Bàn đang phục vụ";
            // 
            // lblTablesValue
            // 
            this.lblTablesValue.AutoSize = true;
            this.lblTablesValue.Font = new System.Drawing.Font("Segoe UI Semibold", 24F);
            this.lblTablesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(165)))), ((int)(((byte)(250)))));
            this.lblTablesValue.Location = new System.Drawing.Point(23, 53);
            this.lblTablesValue.Name = "lblTablesValue";
            this.lblTablesValue.Size = new System.Drawing.Size(45, 54);
            this.lblTablesValue.TabIndex = 1;
            this.lblTablesValue.Text = "0";
            // 
            // lblTablesCaption
            // 
            this.lblTablesCaption.AutoSize = true;
            this.lblTablesCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblTablesCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTablesCaption.Location = new System.Drawing.Point(23, 21);
            this.lblTablesCaption.Name = "lblTablesCaption";
            this.lblTablesCaption.Size = new System.Drawing.Size(160, 25);
            this.lblTablesCaption.TabIndex = 0;
            this.lblTablesCaption.Text = "Trạng thái bàn ăn";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblCurrentTime);
            this.pnlHeader.Controls.Add(this.btnQuickOrder);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Controls.Add(this.lblNhanVien);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(27, 26);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1329, 128);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnQuickOrder
            // 
            this.btnQuickOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnQuickOrder.Location = new System.Drawing.Point(1031, 62);
            this.btnQuickOrder.Name = "btnQuickOrder";
            this.btnQuickOrder.Size = new System.Drawing.Size(297, 49);
            this.btnQuickOrder.TabIndex = 3;
            this.btnQuickOrder.Text = "Tạo order mới";
            this.btnQuickOrder.UseVisualStyleBackColor = true;
            this.btnQuickOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblPageTitle.Location = new System.Drawing.Point(16, 15);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(136, 41);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Xin chào";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNhanVien.Location = new System.Drawing.Point(21, 66);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(283, 25);
            this.lblNhanVien.TabIndex = 1;
            this.lblNhanVien.Text = "Hãy bắt đầu ca làm việc của bạn";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusDatabase,
            this.statusSpacer,
            this.statusUser});
            this.statusStrip.Location = new System.Drawing.Point(27, 674);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(1329, 26);
            this.statusStrip.TabIndex = 4;
            // 
            // statusDatabase
            // 
            this.statusDatabase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.statusDatabase.Name = "statusDatabase";
            this.statusDatabase.Size = new System.Drawing.Size(173, 20);
            this.statusDatabase.Text = "Database: Đang kiểm tra";
            // 
            // statusSpacer
            // 
            this.statusSpacer.Name = "statusSpacer";
            this.statusSpacer.Size = new System.Drawing.Size(1016, 20);
            this.statusSpacer.Spring = true;
            // 
            // statusUser
            // 
            this.statusUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.statusUser.Name = "statusUser";
            this.statusUser.Size = new System.Drawing.Size(123, 20);
            this.statusUser.Text = "Người dùng: N/A";
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // btnGioiThieu
            // 
            this.btnGioiThieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGioiThieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGioiThieu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnGioiThieu.Location = new System.Drawing.Point(806, 166);
            this.btnGioiThieu.Margin = new System.Windows.Forms.Padding(11);
            this.btnGioiThieu.Name = "btnGioiThieu";
            this.btnGioiThieu.Size = new System.Drawing.Size(243, 133);
            this.btnGioiThieu.TabIndex = 8;
            this.btnGioiThieu.Text = "Giới thiệu";
            this.btnGioiThieu.UseVisualStyleBackColor = true;
            this.btnGioiThieu.Click += new System.EventHandler(this.btnGioiThieu_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 768);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTopBar);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pho Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.navBar.ResumeLayout(false);
            this.ctxBaoCao.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.quickActionPanel.ResumeLayout(false);
            this.cardContainer.ResumeLayout(false);
            this.cardRevenue.ResumeLayout(false);
            this.cardRevenue.PerformLayout();
            this.cardOrders.ResumeLayout(false);
            this.cardOrders.PerformLayout();
            this.cardTables.ResumeLayout(false);
            this.cardTables.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        private Button btnGioiThieu;
    }
}
