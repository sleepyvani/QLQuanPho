using System;
using System.Drawing;
using System.Windows.Forms;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlSidebarHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.FlowLayoutPanel sidebarButtons;
        private PhoManager.UI.Controls.SidebarButton navDashboard;
        private PhoManager.UI.Controls.SidebarButton navOrder;
        private PhoManager.UI.Controls.SidebarButton navTables;
        private PhoManager.UI.Controls.SidebarButton navMenu;
        private PhoManager.UI.Controls.SidebarButton navStaff;
        private PhoManager.UI.Controls.SidebarButton navInvoices;
        private PhoManager.UI.Controls.SidebarButton navAnalytics;
        private PhoManager.UI.Controls.SidebarButton navSettings;
        private PhoManager.UI.Controls.SidebarButton navLogout;
        private System.Windows.Forms.Panel pnlSidebarFooter;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblCurrentTime;
        private PhoManager.UI.Controls.RoundedButton btnQuickOrder;
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
        private System.Windows.Forms.FlowLayoutPanel quickActionPanel;
        private PhoManager.UI.Controls.RoundedButton btnQuanLyMonAn;
        private PhoManager.UI.Controls.RoundedButton btnQuanLyNhanVien;
        private PhoManager.UI.Controls.RoundedButton btnQuanLyBanAn;
        private PhoManager.UI.Controls.RoundedButton btnOrder;
        private PhoManager.UI.Controls.RoundedButton btnHoaDon;
        private PhoManager.UI.Controls.RoundedButton btnThongKe;
        private PhoManager.UI.Controls.RoundedButton btnCauHinh;
        private PhoManager.UI.Controls.RoundedButton btnDangXuat;
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlSidebarFooter = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.sidebarButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.navDashboard = new PhoManager.UI.Controls.SidebarButton();
            this.navOrder = new PhoManager.UI.Controls.SidebarButton();
            this.navTables = new PhoManager.UI.Controls.SidebarButton();
            this.navMenu = new PhoManager.UI.Controls.SidebarButton();
            this.navStaff = new PhoManager.UI.Controls.SidebarButton();
            this.navInvoices = new PhoManager.UI.Controls.SidebarButton();
            this.navAnalytics = new PhoManager.UI.Controls.SidebarButton();
            this.navSettings = new PhoManager.UI.Controls.SidebarButton();
            this.navLogout = new PhoManager.UI.Controls.SidebarButton();
            this.pnlSidebarHeader = new System.Windows.Forms.Panel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.quickActionPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuanLyMonAn = new PhoManager.UI.Controls.RoundedButton();
            this.btnQuanLyNhanVien = new PhoManager.UI.Controls.RoundedButton();
            this.btnQuanLyBanAn = new PhoManager.UI.Controls.RoundedButton();
            this.btnOrder = new PhoManager.UI.Controls.RoundedButton();
            this.btnHoaDon = new PhoManager.UI.Controls.RoundedButton();
            this.btnThongKe = new PhoManager.UI.Controls.RoundedButton();
            this.btnCauHinh = new PhoManager.UI.Controls.RoundedButton();
            this.btnDangXuat = new PhoManager.UI.Controls.RoundedButton();
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
            this.btnQuickOrder = new PhoManager.UI.Controls.RoundedButton();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.ctxBaoCao = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxBaoCaoDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxBaoCaoMon = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxBaoCaoHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSidebar.SuspendLayout();
            this.pnlSidebarFooter.SuspendLayout();
            this.sidebarButtons.SuspendLayout();
            this.pnlSidebarHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.quickActionPanel.SuspendLayout();
            this.cardContainer.SuspendLayout();
            this.cardRevenue.SuspendLayout();
            this.cardOrders.SuspendLayout();
            this.cardTables.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.ctxBaoCao.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = PhoManager.UI.Helpers.ThemeManager.SidebarColor;
            this.pnlSidebar.Controls.Add(this.pnlSidebarFooter);
            this.pnlSidebar.Controls.Add(this.sidebarButtons);
            this.pnlSidebar.Controls.Add(this.pnlSidebarHeader);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(230, 720);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlSidebarFooter
            // 
            this.pnlSidebarFooter.Controls.Add(this.lblVersion);
            this.pnlSidebarFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSidebarFooter.Location = new System.Drawing.Point(0, 660);
            this.pnlSidebarFooter.Name = "pnlSidebarFooter";
            this.pnlSidebarFooter.Size = new System.Drawing.Size(230, 60);
            this.pnlSidebarFooter.TabIndex = 2;
            // 
            // lblVersion
            // 
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblVersion.ForeColor = Color.FromArgb(160, 168, 190);
            this.lblVersion.Location = new System.Drawing.Point(0, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Padding = new Padding(15, 0, 0, 15);
            this.lblVersion.Size = new System.Drawing.Size(230, 60);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "QL Quán Phở v1.3";
            this.lblVersion.TextAlign = ContentAlignment.BottomLeft;
            // 
            // sidebarButtons
            // 
            this.sidebarButtons.AutoScroll = true;
            this.sidebarButtons.Controls.Add(this.navDashboard);
            this.sidebarButtons.Controls.Add(this.navOrder);
            this.sidebarButtons.Controls.Add(this.navTables);
            this.sidebarButtons.Controls.Add(this.navMenu);
            this.sidebarButtons.Controls.Add(this.navStaff);
            this.sidebarButtons.Controls.Add(this.navInvoices);
            this.sidebarButtons.Controls.Add(this.navAnalytics);
            this.sidebarButtons.Controls.Add(this.navSettings);
            this.sidebarButtons.Controls.Add(this.navLogout);
            this.sidebarButtons.Dock = DockStyle.Fill;
            this.sidebarButtons.FlowDirection = FlowDirection.TopDown;
            this.sidebarButtons.Location = new Point(0, 120);
            this.sidebarButtons.Name = "sidebarButtons";
            this.sidebarButtons.Padding = new Padding(0, 10, 0, 0);
            this.sidebarButtons.Size = new Size(230, 540);
            this.sidebarButtons.TabIndex = 1;
            this.sidebarButtons.WrapContents = false;
            // 
            // navDashboard
            // 
            this.navDashboard.Glyph = PhoManager.UI.Helpers.IconGlyphs.Dashboard;
            this.navDashboard.IsActive = true;
            this.navDashboard.Text = "Tổng quan";
            this.navDashboard.Click += new System.EventHandler(this.navDashboard_Click);
            this.sidebarButtons.Controls.Add(this.navDashboard);
            // 
            // navOrder
            // 
            this.navOrder.Glyph = PhoManager.UI.Helpers.IconGlyphs.Order;
            this.navOrder.Text = "Gọi món";
            this.navOrder.Click += new EventHandler(this.btnOrder_Click);
            // 
            // navTables
            // 
            this.navTables.Glyph = PhoManager.UI.Helpers.IconGlyphs.Table;
            this.navTables.Text = "Quản lý Bàn";
            this.navTables.Click += new EventHandler(this.btnQuanLyBanAn_Click);
            // 
            // navMenu
            // 
            this.navMenu.Glyph = PhoManager.UI.Helpers.IconGlyphs.Bowl;
            this.navMenu.Text = "Quản lý Món";
            this.navMenu.Click += new EventHandler(this.btnQuanLyMonAn_Click);
            // 
            // navStaff
            // 
            this.navStaff.Glyph = PhoManager.UI.Helpers.IconGlyphs.People;
            this.navStaff.Text = "Nhân viên";
            this.navStaff.Click += new EventHandler(this.btnQuanLyNhanVien_Click);
            // 
            // navInvoices
            // 
            this.navInvoices.Glyph = PhoManager.UI.Helpers.IconGlyphs.Invoice;
            this.navInvoices.Text = "Hóa đơn";
            this.navInvoices.Click += new EventHandler(this.btnHoaDon_Click);
            // 
            // navAnalytics
            // 
            this.navAnalytics.Glyph = PhoManager.UI.Helpers.IconGlyphs.Chart;
            this.navAnalytics.Text = "Báo cáo";
            this.navAnalytics.ContextMenuStrip = this.ctxBaoCao;
            this.navAnalytics.Click += new EventHandler(this.navAnalytics_Click);
            // 
            // navSettings
            // 
            this.navSettings.Glyph = PhoManager.UI.Helpers.IconGlyphs.Settings;
            this.navSettings.Text = "Cấu hình";
            this.navSettings.Click += new EventHandler(this.btnCauHinh_Click);
            // 
            // navLogout
            // 
            this.navLogout.Glyph = PhoManager.UI.Helpers.IconGlyphs.Logout;
            this.navLogout.Text = "Đăng xuất";
            this.navLogout.Click += new EventHandler(this.btnDangXuat_Click);
            // 
            // pnlSidebarHeader
            // 
            this.pnlSidebarHeader.Controls.Add(this.lblBrand);
            this.pnlSidebarHeader.Controls.Add(this.picLogo);
            this.pnlSidebarHeader.Dock = DockStyle.Top;
            this.pnlSidebarHeader.Location = new Point(0, 0);
            this.pnlSidebarHeader.Name = "pnlSidebarHeader";
            this.pnlSidebarHeader.Size = new Size(230, 120);
            this.pnlSidebarHeader.TabIndex = 0;
            // 
            // lblBrand
            // 
            this.lblBrand.ForeColor = Color.White;
            this.lblBrand.Font = new Font("Segoe UI Semibold", 12F);
            this.lblBrand.Location = new Point(80, 42);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new Size(135, 35);
            this.lblBrand.TabIndex = 1;
            this.lblBrand.Text = "Pho Manager";
            this.lblBrand.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // picLogo
            // 
            this.picLogo.Location = new Point(20, 38);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new Size(48, 48);
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = PhoManager.UI.Helpers.ThemeManager.BackgroundColor;
            this.pnlMain.Controls.Add(this.quickActionPanel);
            this.pnlMain.Controls.Add(this.cardContainer);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Controls.Add(this.statusStrip);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(230, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(24, 24, 24, 0);
            this.pnlMain.Size = new Size(970, 720);
            this.pnlMain.TabIndex = 1;
            // 
            // quickActionPanel
            // 
            this.quickActionPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.quickActionPanel.AutoScroll = true;
            this.quickActionPanel.BackColor = Color.Transparent;
            this.quickActionPanel.Controls.Add(this.btnQuanLyMonAn);
            this.quickActionPanel.Controls.Add(this.btnQuanLyNhanVien);
            this.quickActionPanel.Controls.Add(this.btnQuanLyBanAn);
            this.quickActionPanel.Controls.Add(this.btnOrder);
            this.quickActionPanel.Controls.Add(this.btnHoaDon);
            this.quickActionPanel.Controls.Add(this.btnThongKe);
            this.quickActionPanel.Controls.Add(this.btnCauHinh);
            this.quickActionPanel.Controls.Add(this.btnDangXuat);
            this.quickActionPanel.FlowDirection = FlowDirection.LeftToRight;
            this.quickActionPanel.Location = new Point(0, 320);
            this.quickActionPanel.Name = "quickActionPanel";
            this.quickActionPanel.Padding = new Padding(0, 0, 0, 20);
            this.quickActionPanel.Size = new Size(922, 322);
            this.quickActionPanel.TabIndex = 3;
            this.quickActionPanel.WrapContents = true;
            // 
            // btnQuanLyMonAn
            // 
            this.btnQuanLyMonAn.Glyph = PhoManager.UI.Helpers.IconGlyphs.Bowl;
            this.btnQuanLyMonAn.Text = "Quản lý Món ăn";
            this.btnQuanLyMonAn.Variant = ButtonVariant.Tertiary;
            this.btnQuanLyMonAn.Margin = new Padding(10);
            this.btnQuanLyMonAn.Size = new Size(210, 90);
            this.btnQuanLyMonAn.Click += new EventHandler(this.btnQuanLyMonAn_Click);
            // 
            // btnQuanLyNhanVien
            // 
            this.btnQuanLyNhanVien.Glyph = PhoManager.UI.Helpers.IconGlyphs.People;
            this.btnQuanLyNhanVien.Text = "Nhân viên";
            this.btnQuanLyNhanVien.Variant = ButtonVariant.Tertiary;
            this.btnQuanLyNhanVien.Margin = new Padding(10);
            this.btnQuanLyNhanVien.Size = new Size(210, 90);
            this.btnQuanLyNhanVien.Click += new EventHandler(this.btnQuanLyNhanVien_Click);
            // 
            // btnQuanLyBanAn
            // 
            this.btnQuanLyBanAn.Glyph = PhoManager.UI.Helpers.IconGlyphs.Table;
            this.btnQuanLyBanAn.Text = "Quản lý Bàn";
            this.btnQuanLyBanAn.Variant = ButtonVariant.Tertiary;
            this.btnQuanLyBanAn.Margin = new Padding(10);
            this.btnQuanLyBanAn.Size = new Size(210, 90);
            this.btnQuanLyBanAn.Click += new EventHandler(this.btnQuanLyBanAn_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Glyph = PhoManager.UI.Helpers.IconGlyphs.Order;
            this.btnOrder.Text = "Gọi món trực tiếp";
            this.btnOrder.Variant = ButtonVariant.Primary;
            this.btnOrder.Margin = new Padding(10);
            this.btnOrder.Size = new Size(210, 90);
            this.btnOrder.Click += new EventHandler(this.btnOrder_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Glyph = PhoManager.UI.Helpers.IconGlyphs.Invoice;
            this.btnHoaDon.Text = "Quản lý Hóa đơn";
            this.btnHoaDon.Variant = ButtonVariant.Tertiary;
            this.btnHoaDon.Margin = new Padding(10);
            this.btnHoaDon.Size = new Size(210, 90);
            this.btnHoaDon.Click += new EventHandler(this.btnHoaDon_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Glyph = PhoManager.UI.Helpers.IconGlyphs.Chart;
            this.btnThongKe.Text = "Thống kê nhanh";
            this.btnThongKe.Variant = ButtonVariant.Tertiary;
            this.btnThongKe.Margin = new Padding(10);
            this.btnThongKe.Size = new Size(210, 90);
            this.btnThongKe.Click += new EventHandler(this.btnThongKe_Click);
            // 
            // btnCauHinh
            // 
            this.btnCauHinh.Glyph = PhoManager.UI.Helpers.IconGlyphs.Settings;
            this.btnCauHinh.Text = "Thiết lập hệ thống";
            this.btnCauHinh.Variant = ButtonVariant.Tertiary;
            this.btnCauHinh.Margin = new Padding(10);
            this.btnCauHinh.Size = new Size(210, 90);
            this.btnCauHinh.Click += new EventHandler(this.btnCauHinh_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Glyph = PhoManager.UI.Helpers.IconGlyphs.Logout;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Variant = ButtonVariant.Danger;
            this.btnDangXuat.Margin = new Padding(10);
            this.btnDangXuat.Size = new Size(210, 90);
            this.btnDangXuat.Click += new EventHandler(this.btnDangXuat_Click);
            // 
            // cardContainer
            // 
            this.cardContainer.AutoSize = true;
            this.cardContainer.Controls.Add(this.cardRevenue);
            this.cardContainer.Controls.Add(this.cardOrders);
            this.cardContainer.Controls.Add(this.cardTables);
            this.cardContainer.Dock = DockStyle.Top;
            this.cardContainer.Location = new Point(24, 144);
            this.cardContainer.Margin = new Padding(0);
            this.cardContainer.Name = "cardContainer";
            this.cardContainer.Size = new Size(922, 176);
            this.cardContainer.TabIndex = 2;
            // 
            // cardRevenue
            // 
            this.cardRevenue.BackColor = Color.White;
            this.cardRevenue.Controls.Add(this.lblRevenueSub);
            this.cardRevenue.Controls.Add(this.lblRevenueValue);
            this.cardRevenue.Controls.Add(this.lblRevenueCaption);
            this.cardRevenue.Location = new Point(0, 0);
            this.cardRevenue.Margin = new Padding(0, 0, 18, 18);
            this.cardRevenue.Name = "cardRevenue";
            this.cardRevenue.Size = new Size(290, 158);
            this.cardRevenue.TabIndex = 0;
            // 
            // lblRevenueSub
            // 
            this.lblRevenueSub.AutoSize = true;
            this.lblRevenueSub.Font = new Font("Segoe UI", 9F);
            this.lblRevenueSub.ForeColor = ThemeManager.TextMuted;
            this.lblRevenueSub.Location = new Point(24, 110);
            this.lblRevenueSub.Name = "lblRevenueSub";
            this.lblRevenueSub.Size = new Size(120, 15);
            this.lblRevenueSub.TabIndex = 2;
            this.lblRevenueSub.Text = "Hôm nay so với hôm qua";
            // 
            // lblRevenueValue
            // 
            this.lblRevenueValue.AutoSize = true;
            this.lblRevenueValue.Font = new Font("Segoe UI Semibold", 24F);
            this.lblRevenueValue.ForeColor = ThemeManager.PrimaryColor;
            this.lblRevenueValue.Location = new Point(20, 50);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new Size(129, 45);
            this.lblRevenueValue.TabIndex = 1;
            this.lblRevenueValue.Text = "0 VND";
            // 
            // lblRevenueCaption
            // 
            this.lblRevenueCaption.AutoSize = true;
            this.lblRevenueCaption.Font = new Font("Segoe UI Semibold", 11F);
            this.lblRevenueCaption.ForeColor = ThemeManager.TextColor;
            this.lblRevenueCaption.Location = new Point(20, 18);
            this.lblRevenueCaption.Name = "lblRevenueCaption";
            this.lblRevenueCaption.Size = new Size(131, 20);
            this.lblRevenueCaption.TabIndex = 0;
            this.lblRevenueCaption.Text = "Doanh thu hôm nay";
            // 
            // cardOrders
            // 
            this.cardOrders.BackColor = Color.White;
            this.cardOrders.Controls.Add(this.lblOrdersSub);
            this.cardOrders.Controls.Add(this.lblOrdersValue);
            this.cardOrders.Controls.Add(this.lblOrdersCaption);
            this.cardOrders.Location = new Point(308, 0);
            this.cardOrders.Margin = new Padding(0, 0, 18, 18);
            this.cardOrders.Name = "cardOrders";
            this.cardOrders.Size = new Size(290, 158);
            this.cardOrders.TabIndex = 1;
            // 
            // lblOrdersSub
            // 
            this.lblOrdersSub.AutoSize = true;
            this.lblOrdersSub.Font = new Font("Segoe UI", 9F);
            this.lblOrdersSub.ForeColor = ThemeManager.TextMuted;
            this.lblOrdersSub.Location = new Point(24, 110);
            this.lblOrdersSub.Name = "lblOrdersSub";
            this.lblOrdersSub.Size = new Size(148, 15);
            this.lblOrdersSub.TabIndex = 2;
            this.lblOrdersSub.Text = "Đơn đã hoàn tất trong ngày";
            // 
            // lblOrdersValue
            // 
            this.lblOrdersValue.AutoSize = true;
            this.lblOrdersValue.Font = new Font("Segoe UI Semibold", 24F);
            this.lblOrdersValue.ForeColor = ThemeManager.AccentColor;
            this.lblOrdersValue.Location = new Point(20, 50);
            this.lblOrdersValue.Name = "lblOrdersValue";
            this.lblOrdersValue.Size = new Size(37, 45);
            this.lblOrdersValue.TabIndex = 1;
            this.lblOrdersValue.Text = "0";
            // 
            // lblOrdersCaption
            // 
            this.lblOrdersCaption.AutoSize = true;
            this.lblOrdersCaption.Font = new Font("Segoe UI Semibold", 11F);
            this.lblOrdersCaption.ForeColor = ThemeManager.TextColor;
            this.lblOrdersCaption.Location = new Point(20, 18);
            this.lblOrdersCaption.Name = "lblOrdersCaption";
            this.lblOrdersCaption.Size = new Size(100, 20);
            this.lblOrdersCaption.TabIndex = 0;
            this.lblOrdersCaption.Text = "Đơn hoàn tất";
            // 
            // cardTables
            // 
            this.cardTables.BackColor = Color.White;
            this.cardTables.Controls.Add(this.lblTablesSub);
            this.cardTables.Controls.Add(this.lblTablesValue);
            this.cardTables.Controls.Add(this.lblTablesCaption);
            this.cardTables.Location = new Point(616, 0);
            this.cardTables.Margin = new Padding(0, 0, 18, 18);
            this.cardTables.Name = "cardTables";
            this.cardTables.Size = new Size(290, 158);
            this.cardTables.TabIndex = 2;
            // 
            // lblTablesSub
            // 
            this.lblTablesSub.AutoSize = true;
            this.lblTablesSub.Font = new Font("Segoe UI", 9F);
            this.lblTablesSub.ForeColor = ThemeManager.TextMuted;
            this.lblTablesSub.Location = new Point(24, 110);
            this.lblTablesSub.Name = "lblTablesSub";
            this.lblTablesSub.Size = new Size(95, 15);
            this.lblTablesSub.TabIndex = 2;
            this.lblTablesSub.Text = "Bàn đang phục vụ";
            // 
            // lblTablesValue
            // 
            this.lblTablesValue.AutoSize = true;
            this.lblTablesValue.Font = new Font("Segoe UI Semibold", 24F);
            this.lblTablesValue.ForeColor = ThemeManager.TextColor;
            this.lblTablesValue.Location = new Point(20, 50);
            this.lblTablesValue.Name = "lblTablesValue";
            this.lblTablesValue.Size = new Size(37, 45);
            this.lblTablesValue.TabIndex = 1;
            this.lblTablesValue.Text = "0";
            // 
            // lblTablesCaption
            // 
            this.lblTablesCaption.AutoSize = true;
            this.lblTablesCaption.Font = new Font("Segoe UI Semibold", 11F);
            this.lblTablesCaption.ForeColor = ThemeManager.TextColor;
            this.lblTablesCaption.Location = new Point(20, 18);
            this.lblTablesCaption.Name = "lblTablesCaption";
            this.lblTablesCaption.Size = new Size(138, 20);
            this.lblTablesCaption.TabIndex = 0;
            this.lblTablesCaption.Text = "Trạng thái bàn ăn";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnQuickOrder);
            this.pnlHeader.Controls.Add(this.lblCurrentTime);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Controls.Add(this.lblNhanVien);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(24, 24);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(922, 120);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnQuickOrder
            // 
            this.btnQuickOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnQuickOrder.Glyph = PhoManager.UI.Helpers.IconGlyphs.Order;
            this.btnQuickOrder.Location = new Point(642, 58);
            this.btnQuickOrder.Name = "btnQuickOrder";
            this.btnQuickOrder.Size = new Size(260, 46);
            this.btnQuickOrder.TabIndex = 3;
            this.btnQuickOrder.Text = "Tạo order mới";
            this.btnQuickOrder.Click += new EventHandler(this.btnOrder_Click);
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblCurrentTime.Font = new Font("Segoe UI", 9F);
            this.lblCurrentTime.ForeColor = ThemeManager.TextMuted;
            this.lblCurrentTime.Location = new Point(636, 18);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new Size(266, 24);
            this.lblCurrentTime.TabIndex = 2;
            this.lblCurrentTime.Text = "00:00";
            this.lblCurrentTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new Font("Segoe UI Semibold", 18F);
            this.lblPageTitle.ForeColor = ThemeManager.TextColor;
            this.lblPageTitle.Location = new Point(14, 14);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new Size(247, 32);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Xin chào buổi sáng 🌤️";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new Font("Segoe UI", 11F);
            this.lblNhanVien.ForeColor = ThemeManager.TextMuted;
            this.lblNhanVien.Location = new Point(18, 62);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new Size(219, 20);
            this.lblNhanVien.TabIndex = 1;
            this.lblNhanVien.Text = "Hãy bắt đầu ca làm việc của bạn";
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = DockStyle.Bottom;
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.statusDatabase,
                this.statusSpacer,
                this.statusUser
            });
            this.statusStrip.Location = new Point(24, 694);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(922, 26);
            this.statusStrip.TabIndex = 4;
            // 
            // statusDatabase
            // 
            this.statusDatabase.Font = new Font("Segoe UI", 9F);
            this.statusDatabase.ForeColor = Color.FromArgb(99, 110, 133);
            this.statusDatabase.Name = "statusDatabase";
            this.statusDatabase.Size = new Size(144, 21);
            this.statusDatabase.Text = "Database: Đang kiểm tra";
            // 
            // statusSpacer
            // 
            this.statusSpacer.Spring = true;
            this.statusSpacer.Name = "statusSpacer";
            this.statusSpacer.Size = new Size(655, 21);
            // 
            // statusUser
            // 
            this.statusUser.Font = new Font("Segoe UI", 9F);
            this.statusUser.ForeColor = Color.FromArgb(99, 110, 133);
            this.statusUser.Name = "statusUser";
            this.statusUser.Size = new Size(107, 21);
            this.statusUser.Text = "Người dùng: N/A";
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new EventHandler(this.timerClock_Tick);
            // 
            // ctxBaoCao
            // 
            this.ctxBaoCao.Items.AddRange(new ToolStripItem[] {
                this.ctxBaoCaoDoanhThu,
                this.ctxBaoCaoMon,
                this.ctxBaoCaoHoaDon
            });
            this.ctxBaoCao.Name = "ctxBaoCao";
            this.ctxBaoCao.Size = new Size(196, 70);
            // 
            // ctxBaoCaoDoanhThu
            // 
            this.ctxBaoCaoDoanhThu.Name = "ctxBaoCaoDoanhThu";
            this.ctxBaoCaoDoanhThu.Size = new Size(195, 22);
            this.ctxBaoCaoDoanhThu.Text = "Báo cáo doanh thu";
            this.ctxBaoCaoDoanhThu.Click += new EventHandler(this.menuBaoCaoDoanhThu_Click);
            // 
            // ctxBaoCaoMon
            // 
            this.ctxBaoCaoMon.Name = "ctxBaoCaoMon";
            this.ctxBaoCaoMon.Size = new Size(195, 22);
            this.ctxBaoCaoMon.Text = "Món bán chạy";
            this.ctxBaoCaoMon.Click += new EventHandler(this.menuBaoCaoMonBanChay_Click);
            // 
            // ctxBaoCaoHoaDon
            // 
            this.ctxBaoCaoHoaDon.Name = "ctxBaoCaoHoaDon";
            this.ctxBaoCaoHoaDon.Size = new Size(195, 22);
            this.ctxBaoCaoHoaDon.Text = "Báo cáo hóa đơn";
            this.ctxBaoCaoHoaDon.Click += new EventHandler(this.menuBaoCaoHoaDon_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 720);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "FrmMain";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pho Manager";
            this.FormClosing += new FormClosingEventHandler(this.FrmMain_FormClosing);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebarFooter.ResumeLayout(false);
            this.sidebarButtons.ResumeLayout(false);
            this.pnlSidebarHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
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
            this.ctxBaoCao.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
