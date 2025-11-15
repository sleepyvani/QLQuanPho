using System;
using System.Drawing;
using System.Windows.Forms;
using PhoManager.DAL;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    public partial class FrmMain : Form
    {
        private bool isLoggingOut;
        private Button currentNavButton;

        public FrmMain()
        {
            InitializeComponent();
            ThemeManager.ApplyPanelCardStyle(cardRevenue);
            ThemeManager.ApplyPanelCardStyle(cardOrders);
            ThemeManager.ApplyPanelCardStyle(cardTables);
            LoadMenu();
            StyleNavigationButtons();
            StyleQuickActionButtons();
            UpdateDatabaseStatus();
            timerClock_Tick(this, EventArgs.Empty);

            // Load initial dashboard statistics (revenue and order count)
            UpdateDashboardStatistics();
        }

        /// <summary>
        /// Re-applies theme colours to the main form.  Call this method after
        /// toggling between light and dark modes.  It will update backgrounds,
        /// card styles and buttons accordingly.
        /// </summary>
        public void ReloadTheme()
        {
            // Update primary panels
            this.pnlTopBar.BackColor = ThemeManager.PanelColor;
            this.pnlMain.BackColor = ThemeManager.BackgroundColor;

            // Update cards
            ThemeManager.ApplyPanelCardStyle(cardRevenue);
            ThemeManager.ApplyPanelCardStyle(cardOrders);
            ThemeManager.ApplyPanelCardStyle(cardTables);

            // Re-style navigation and action buttons
            StyleNavigationButtons();
            StyleQuickActionButtons();
            
            this.Invalidate();
        }

        private void StyleNavigationButtons()
        {
            var navButtons = new[] { btnNavOrder, btnNavTables, btnNavMenu, btnNavStaff, btnNavInvoices, btnNavAnalytics, btnNavSettings, btnNavLogout };
            foreach (var btn in navButtons)
            {
                ThemeManager.StyleButton(btn, ButtonVariant.Ghost);
            }
            ThemeManager.StyleButton(btnQuickOrder, ButtonVariant.Primary, IconGlyphs.Order);
        }

        private void StyleQuickActionButtons()
        {
            ThemeManager.StyleButton(btnQuanLyMonAn, ButtonVariant.Tertiary, IconGlyphs.Bowl);
            ThemeManager.StyleButton(btnQuanLyNhanVien, ButtonVariant.Tertiary, IconGlyphs.People);
            ThemeManager.StyleButton(btnQuanLyBanAn, ButtonVariant.Tertiary, IconGlyphs.Table);
            ThemeManager.StyleButton(btnOrder, ButtonVariant.Primary, IconGlyphs.Order);
            ThemeManager.StyleButton(btnHoaDon, ButtonVariant.Tertiary, IconGlyphs.Invoice);
            ThemeManager.StyleButton(btnThongKe, ButtonVariant.Tertiary, IconGlyphs.Chart);
            ThemeManager.StyleButton(btnCauHinh, ButtonVariant.Tertiary, IconGlyphs.Settings);
            ThemeManager.StyleButton(btnDangXuat, ButtonVariant.Danger, IconGlyphs.Logout);
            
            // Set button sizes for quick actions
            var quickActions = new[] { btnQuanLyMonAn, btnQuanLyNhanVien, btnQuanLyBanAn, btnOrder, btnHoaDon, btnThongKe, btnCauHinh, btnDangXuat };
            foreach (var btn in quickActions)
            {
                btn.Size = new Size(210, 90);
                btn.TextImageRelation = TextImageRelation.ImageAboveText;
                btn.ImageAlign = ContentAlignment.TopCenter;
                btn.TextAlign = ContentAlignment.BottomCenter;
            }
        }

        private void LoadMenu()
        {
            if (FrmLogin.NhanVienDangNhap != null)
            {
                lblNhanVien.Text = $"Xin chào, {FrmLogin.NhanVienDangNhap.HoTen}";
                statusUser.Text = $"Người dùng: {FrmLogin.NhanVienDangNhap.HoTen}";
                var parts = FrmLogin.NhanVienDangNhap.HoTen.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var lastName = parts.Length > 0 ? parts[parts.Length - 1] : FrmLogin.NhanVienDangNhap.HoTen;
                lblPageTitle.Text = $"Chào {lastName}, chúc một ngày tốt lành!";
            }

            string chucVu = FrmLogin.NhanVienDangNhap?.ChucVu ?? "";
            bool isManager = string.Equals(chucVu, "Quản lý", StringComparison.OrdinalIgnoreCase);

            btnNavMenu.Enabled = isManager;
            btnNavStaff.Enabled = isManager;
            btnNavAnalytics.Enabled = isManager;
            btnNavSettings.Enabled = isManager;

            btnQuanLyMonAn.Enabled = isManager;
            btnQuanLyNhanVien.Enabled = isManager;
            btnThongKe.Enabled = isManager;
            btnCauHinh.Enabled = isManager;
        }

        private void SetActiveNavButton(Button target)
        {
            if (currentNavButton != null)
            {
                currentNavButton.BackColor = ThemeManager.PanelColor;
                currentNavButton.ForeColor = ThemeManager.TextColor;
            }
            currentNavButton = target;
            if (currentNavButton != null)
            {
                currentNavButton.BackColor = ThemeManager.PrimaryLight;
                currentNavButton.ForeColor = ThemeManager.PrimaryColor;
            }
        }

        private void UpdateDatabaseStatus()
        {
            try
            {
                bool ok = QLQuanPhoDataContext.TestConnection();
                statusDatabase.Text = ok ? "Database: Kết nối thành công" : "Database: Không thể kết nối";
                statusDatabase.ForeColor = ok ? ThemeManager.PrimaryColor : ThemeManager.DangerColor;
            }
            catch (Exception ex)
            {
                statusDatabase.Text = $"Database: Lỗi - {ex.Message}";
                statusDatabase.ForeColor = ThemeManager.DangerColor;
            }
        }

        /// <summary>
        /// Updates the revenue and order count statistics displayed on the dashboard.  It
        /// calculates today's total revenue and total number of completed orders
        /// (hóa đơn đã thanh toán) using ThongKeBLL.  It also compares today's
        /// values with yesterday's to update the subtitle texts.  This method
        /// should be called whenever data that affects revenue or order count
        /// changes, such as after completing an order or viewing invoice history.
        /// </summary>
        private void UpdateDashboardStatistics()
        {
            try
            {
                var tkBLL = new PhoManager.BLL.ThongKeBLL();
                DateTime today = DateTime.Today;
                DateTime yesterday = today.AddDays(-1);

                // Calculate revenue and order count for today
                decimal revenueToday = tkBLL.LayTongDoanhThu(today, today);
                int ordersToday = tkBLL.LaySoLuongHoaDon(today, today);

                // Format revenue with thousand separators and currency suffix
                lblRevenueValue.Text = string.Format("{0:N0} VND", revenueToday);
                lblOrdersValue.Text = ordersToday.ToString();

                // Compare with yesterday for subtitle text
                decimal revenueYesterday = tkBLL.LayTongDoanhThu(yesterday, yesterday);
                int ordersYesterday = tkBLL.LaySoLuongHoaDon(yesterday, yesterday);

                // Determine revenue change text
                string revChange;
                if (revenueYesterday == 0m && revenueToday > 0m)
                {
                    revChange = "Tăng so với hôm qua";
                }
                else if (revenueYesterday == 0m && revenueToday == 0m)
                {
                    revChange = "Không có doanh thu";
                }
                else
                {
                    decimal diff = revenueToday - revenueYesterday;
                    decimal percent = revenueYesterday != 0 ? diff / revenueYesterday * 100 : 0;
                    if (diff > 0)
                    {
                        revChange = $"+{percent:0.##}% so với hôm qua";
                    }
                    else if (diff < 0)
                    {
                        revChange = $"-{Math.Abs(percent):0.##}% so với hôm qua";
                    }
                    else
                    {
                        revChange = "Bằng hôm qua";
                    }
                }
                lblRevenueSub.Text = revChange;

                // Determine order change text
                string orderChange;
                if (ordersYesterday == 0 && ordersToday > 0)
                {
                    orderChange = "Tăng so với hôm qua";
                }
                else if (ordersYesterday == 0 && ordersToday == 0)
                {
                    orderChange = "Không có đơn hoàn tất";
                }
                else
                {
                    int diffOrder = ordersToday - ordersYesterday;
                    decimal percentOrder = ordersYesterday != 0 ? (decimal)diffOrder / ordersYesterday * 100 : 0;
                    if (diffOrder > 0)
                    {
                        orderChange = $"+{percentOrder:0.##}% so với hôm qua";
                    }
                    else if (diffOrder < 0)
                    {
                        orderChange = $"-{Math.Abs(percentOrder):0.##}% so với hôm qua";
                    }
                    else
                    {
                        orderChange = "Bằng hôm qua";
                    }
                }
                lblOrdersSub.Text = orderChange;
            }
            catch (Exception ex)
            {
                // Log but do not crash if there is a database error; display fallback text
                PhoManager.Utilities.Logger.Error("Failed to update dashboard statistics: " + ex.Message);
                lblRevenueValue.Text = "0 VND";
                lblOrdersValue.Text = "0";
                lblRevenueSub.Text = "Không thể lấy dữ liệu";
                lblOrdersSub.Text = "Không thể lấy dữ liệu";
            }
        }

        private void btnQuanLyMonAn_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavMenu);
            using (var frm = new FrmMonAn())
            {
                frm.ShowDialog();
            }
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavStaff);
            using (var frm = new FrmNhanVien())
            {
                frm.ShowDialog();
            }
        }

        private void btnQuanLyBanAn_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavTables);
            using (var frm = new FrmBanAn())
            {
                frm.ShowDialog();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavOrder);
            using (var frm = new FrmOrder())
            {
                frm.ShowDialog();
            }

            // After closing the Order form, refresh dashboard statistics because
            // the user may have added or completed orders which affect revenue
            // and order counts.
            UpdateDashboardStatistics();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavInvoices);
            using (var frm = new FrmBaoCaoHoaDon())
            {
                frm.ShowDialog();
            }

            // Sau khi xem hoặc thao tác với hóa đơn, cập nhật lại thống kê để phản ánh
            // các hóa đơn đã thanh toán gần đây.
            UpdateDashboardStatistics();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavAnalytics);
            using (var frm = new FrmThongKe())
            {
                frm.ShowDialog();
            }
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavSettings);
            using (var frm = new FrmCauHinh())
            {
                frm.ShowDialog();
            }
        }

        private void menuBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmBaoCaoDoanhThu())
            {
                frm.ShowDialog();
            }
        }

        private void menuBaoCaoMonBanChay_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmBaoCaoMonBanChay())
            {
                frm.ShowDialog();
            }
        }

        private void menuBaoCaoHoaDon_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmBaoCaoHoaDon())
            {
                frm.ShowDialog();
            }
        }

        private void navAnalytics_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavAnalytics);
            var location = btnNavAnalytics.PointToScreen(new Point(btnNavAnalytics.Width, btnNavAnalytics.Height / 2));
            ctxBaoCao.Show(location);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavLogout);
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isLoggingOut = true;
                Close();
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLoggingOut)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
