namespace PhoManager.UI.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLy;
        private System.Windows.Forms.ToolStripMenuItem menuBanHang;
        private System.Windows.Forms.ToolStripMenuItem menuThongKe;
        private System.Windows.Forms.ToolStripMenuItem menuHeThong;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblCurrentTime;
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.quickActionPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuanLyMonAn = new PhoManager.UI.Controls.RoundedButton();
            this.btnQuanLyNhanVien = new PhoManager.UI.Controls.RoundedButton();
            this.btnQuanLyBanAn = new PhoManager.UI.Controls.RoundedButton();
            this.btnOrder = new PhoManager.UI.Controls.RoundedButton();
            this.btnHoaDon = new PhoManager.UI.Controls.RoundedButton();
            this.btnThongKe = new PhoManager.UI.Controls.RoundedButton();
            this.btnCauHinh = new PhoManager.UI.Controls.RoundedButton();
            this.btnDangXuat = new PhoManager.UI.Controls.RoundedButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer();
            this.menuStrip.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.quickActionPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuQuanLy,
                this.menuBanHang,
                this.menuThongKe,
                this.menuHeThong
            });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1000, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            
            this.menuQuanLy.Text = "Quản lý";
            
            this.menuBanHang.Text = "Bán hàng";
            
            this.menuThongKe.Text = "Thống kê";
            
            this.menuHeThong.Text = "Hệ thống";
            
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.headerPanel, 0, 0);
            this.mainLayout.Controls.Add(this.quickActionPanel, 0, 1);
            this.mainLayout.Controls.Add(this.statusStrip, 0, 2);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 24);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.mainLayout.Size = new System.Drawing.Size(1000, 576);
            this.mainLayout.TabIndex = 1;

            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.lblCurrentTime);
            this.headerPanel.Controls.Add(this.lblNhanVien);
            this.headerPanel.Controls.Add(this.picLogo);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1000, 100);
            this.headerPanel.TabIndex = 0;

            this.picLogo.Location = new System.Drawing.Point(20, 15);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(70, 70);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
 
            this.lblNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.lblNhanVien.ForeColor = System.Drawing.Color.FromArgb(35, 96, 67);
            this.lblNhanVien.Location = new System.Drawing.Point(100, 15);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(600, 70);
            this.lblNhanVien.TabIndex = 0;
            this.lblNhanVien.Text = "Xin chào";
            this.lblNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentTime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.lblCurrentTime.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblCurrentTime.Location = new System.Drawing.Point(620, 15);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(360, 70);
            this.lblCurrentTime.TabIndex = 1;
            this.lblCurrentTime.Text = "";
            this.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.quickActionPanel.BackColor = System.Drawing.Color.White;
            this.quickActionPanel.Controls.Add(this.btnQuanLyMonAn);
            this.quickActionPanel.Controls.Add(this.btnQuanLyNhanVien);
            this.quickActionPanel.Controls.Add(this.btnQuanLyBanAn);
            this.quickActionPanel.Controls.Add(this.btnOrder);
            this.quickActionPanel.Controls.Add(this.btnHoaDon);
            this.quickActionPanel.Controls.Add(this.btnThongKe);
            this.quickActionPanel.Controls.Add(this.btnCauHinh);
            this.quickActionPanel.Controls.Add(this.btnDangXuat);
            this.quickActionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quickActionPanel.Location = new System.Drawing.Point(20, 110);
            this.quickActionPanel.Margin = new System.Windows.Forms.Padding(20);
            this.quickActionPanel.Name = "quickActionPanel";
            this.quickActionPanel.Padding = new System.Windows.Forms.Padding(10);
            this.quickActionPanel.Size = new System.Drawing.Size(960, 422);
            this.quickActionPanel.TabIndex = 1;

            this.btnQuanLyMonAn.BackColor = System.Drawing.Color.FromArgb(242, 248, 245);
            this.btnQuanLyMonAn.BorderRadius = 15;
            this.btnQuanLyMonAn.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnQuanLyMonAn.ForeColor = System.Drawing.Color.FromArgb(35, 96, 67);
            this.btnQuanLyMonAn.Margin = new System.Windows.Forms.Padding(15);
            this.btnQuanLyMonAn.Name = "btnQuanLyMonAn";
            this.btnQuanLyMonAn.Size = new System.Drawing.Size(220, 100);
            this.btnQuanLyMonAn.TabIndex = 0;
            this.btnQuanLyMonAn.Text = "📋 Quản lý Món ăn";
            this.btnQuanLyMonAn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnQuanLyMonAn.Click += new System.EventHandler(this.btnQuanLyMonAn_Click);

            this.btnQuanLyNhanVien.BackColor = System.Drawing.Color.FromArgb(242, 248, 245);
            this.btnQuanLyNhanVien.BorderRadius = 15;
            this.btnQuanLyNhanVien.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnQuanLyNhanVien.ForeColor = System.Drawing.Color.FromArgb(35, 96, 67);
            this.btnQuanLyNhanVien.Margin = new System.Windows.Forms.Padding(15);
            this.btnQuanLyNhanVien.Name = "btnQuanLyNhanVien";
            this.btnQuanLyNhanVien.Size = new System.Drawing.Size(220, 100);
            this.btnQuanLyNhanVien.TabIndex = 1;
            this.btnQuanLyNhanVien.Text = "👥 Quản lý Nhân viên";
            this.btnQuanLyNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnQuanLyNhanVien.Click += new System.EventHandler(this.btnQuanLyNhanVien_Click);

            this.btnQuanLyBanAn.BackColor = System.Drawing.Color.FromArgb(242, 248, 245);
            this.btnQuanLyBanAn.BorderRadius = 15;
            this.btnQuanLyBanAn.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnQuanLyBanAn.ForeColor = System.Drawing.Color.FromArgb(35, 96, 67);
            this.btnQuanLyBanAn.Margin = new System.Windows.Forms.Padding(15);
            this.btnQuanLyBanAn.Name = "btnQuanLyBanAn";
            this.btnQuanLyBanAn.Size = new System.Drawing.Size(220, 100);
            this.btnQuanLyBanAn.TabIndex = 2;
            this.btnQuanLyBanAn.Text = "🪑 Quản lý Bàn ăn";
            this.btnQuanLyBanAn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnQuanLyBanAn.Click += new System.EventHandler(this.btnQuanLyBanAn_Click);

            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(35, 96, 67);
            this.btnOrder.BorderRadius = 15;
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Margin = new System.Windows.Forms.Padding(15);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(220, 100);
            this.btnOrder.TabIndex = 3;
            this.btnOrder.Text = "🛒 Gọi món";
            this.btnOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);

            this.btnHoaDon.BackColor = System.Drawing.Color.FromArgb(242, 248, 245);
            this.btnHoaDon.BorderRadius = 15;
            this.btnHoaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnHoaDon.ForeColor = System.Drawing.Color.FromArgb(35, 96, 67);
            this.btnHoaDon.Margin = new System.Windows.Forms.Padding(15);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(220, 100);
            this.btnHoaDon.TabIndex = 4;
            this.btnHoaDon.Text = "🧾 Hóa đơn";
            this.btnHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);

            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(242, 248, 245);
            this.btnThongKe.BorderRadius = 15;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnThongKe.ForeColor = System.Drawing.Color.FromArgb(35, 96, 67);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(15);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(220, 100);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "📊 Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);

            this.btnCauHinh.BackColor = System.Drawing.Color.FromArgb(242, 248, 245);
            this.btnCauHinh.BorderRadius = 15;
            this.btnCauHinh.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnCauHinh.ForeColor = System.Drawing.Color.FromArgb(35, 96, 67);
            this.btnCauHinh.Margin = new System.Windows.Forms.Padding(15);
            this.btnCauHinh.Name = "btnCauHinh";
            this.btnCauHinh.Size = new System.Drawing.Size(220, 100);
            this.btnCauHinh.TabIndex = 6;
            this.btnCauHinh.Text = "⚙️ Cấu hình";
            this.btnCauHinh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCauHinh.Click += new System.EventHandler(this.btnCauHinh_Click);

            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(255, 244, 242);
            this.btnDangXuat.BorderColor = System.Drawing.Color.FromArgb(212, 68, 55);
            this.btnDangXuat.BorderRadius = 15;
            this.btnDangXuat.BorderWidth = 2;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnDangXuat.ForeColor = System.Drawing.Color.FromArgb(212, 68, 55);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(15);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(220, 100);
            this.btnDangXuat.TabIndex = 7;
            this.btnDangXuat.Text = "🚪 Đăng xuất";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);

            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.statusDatabase,
                this.statusSpacer,
                this.statusUser
            });
            this.statusStrip.Location = new System.Drawing.Point(0, 552);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1000, 24);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";

            this.statusDatabase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.statusDatabase.ForeColor = System.Drawing.Color.DimGray;
            this.statusDatabase.Name = "statusDatabase";
            this.statusDatabase.Size = new System.Drawing.Size(120, 19);
            this.statusDatabase.Text = "Database: Unknown";

            this.statusSpacer.Spring = true;
            this.statusSpacer.Name = "statusSpacer";
            this.statusSpacer.Size = new System.Drawing.Size(734, 19);
            this.statusSpacer.Text = "";

            this.statusUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.statusUser.ForeColor = System.Drawing.Color.DimGray;
            this.statusUser.Name = "statusUser";
            this.statusUser.Size = new System.Drawing.Size(131, 19);
            this.statusUser.Text = "Người dùng: (chưa rõ)";

            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.mainLayout);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Quán Phở";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.quickActionPanel.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

