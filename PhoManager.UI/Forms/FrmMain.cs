using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PhoManager.DAL;
using PhoManager.UI.Helpers;
using PhoManager.UI.Controls;

namespace PhoManager.UI.Forms
{
    public partial class FrmMain : Form
    {
        private bool isLoggingOut;
        private SidebarButton currentNav;

        public FrmMain()
        {
            InitializeComponent();
            ThemeManager.ApplyPanelCardStyle(cardRevenue);
            ThemeManager.ApplyPanelCardStyle(cardOrders);
            ThemeManager.ApplyPanelCardStyle(cardTables);
            LoadLogo();
            LoadMenu();
            UpdateDatabaseStatus();
            timerClock_Tick(this, EventArgs.Empty);

            // Load initial dashboard statistics (revenue and order count)
            UpdateDashboardStatistics();
        }

        /// <summary>
        /// Re-applies theme colours and logo to the main form.  Call this method after
        /// toggling between light and dark modes or changing the logo.  It will
        /// update backgrounds, card styles, sidebar colours and quick action
        /// buttons accordingly.  Existing navigation state is preserved.
        /// </summary>
        public void ReloadTheme()
        {
            // Update primary panels
            this.pnlSidebar.BackColor = ThemeManager.SidebarColor;
            this.pnlSidebarHeader.BackColor = ThemeManager.SidebarColor;
            this.pnlSidebarFooter.BackColor = ThemeManager.SidebarColor;
            this.pnlMain.BackColor = ThemeManager.BackgroundColor;

            // Update cards
            ThemeManager.ApplyPanelCardStyle(cardRevenue);
            ThemeManager.ApplyPanelCardStyle(cardOrders);
            ThemeManager.ApplyPanelCardStyle(cardTables);

            // Update sidebar buttons state to refresh colours and icons
            var buttons = new[] { navDashboard, navOrder, navTables, navMenu, navStaff, navInvoices, navAnalytics, navSettings, navLogout };
            foreach (var btn in buttons)
            {
                // Trigger the setter to force UpdateState and refresh icon
                bool active = btn.IsActive;
                btn.IsActive = active;
            }

            // Update quick action buttons: reapply variant to update colours
            var actions = new[] { btnQuanLyMonAn, btnQuanLyNhanVien, btnQuanLyBanAn, btnOrder, btnHoaDon, btnThongKe, btnCauHinh, btnDangXuat };
            foreach (var act in actions)
            {
                // Reset variant to itself so the setter calls ApplyVariant
                var variant = act.Variant;
                act.Variant = variant;
            }

            // Reload the logo if a custom logo is set
            LoadLogo();
            this.Invalidate();
        }

        private void LoadLogo()
        {
            try
            {
                string logoPath = Path.Combine(Application.StartupPath, "Resources", "logo.png");
                if (File.Exists(logoPath))
                {
                    picLogo.Image = Image.FromFile(logoPath);
                    return;
                }

                logoPath = Path.Combine(Application.StartupPath, "logo.png");
                if (File.Exists(logoPath))
                {
                    picLogo.Image = Image.FromFile(logoPath);
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading logo from file: {ex.Message}");
            }

            picLogo.Image = CreatePlaceholderLogo(picLogo.Width, picLogo.Height);
        }

        private Image CreatePlaceholderLogo(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (Font font = new Font("Segoe UI", Math.Min(width, height) / 3, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString("PHỞ", font, brush, new RectangleF(0, 0, width, height), sf);
                }
            }
            return bmp;
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

            currentNav = navDashboard;
            navDashboard.IsActive = true;

            string chucVu = FrmLogin.NhanVienDangNhap?.ChucVu ?? "";
            bool isManager = string.Equals(chucVu, "Quản lý", StringComparison.OrdinalIgnoreCase);

            navMenu.Enabled = isManager;
            navStaff.Enabled = isManager;
            navAnalytics.Enabled = isManager;
            navSettings.Enabled = isManager;

            btnQuanLyMonAn.Enabled = isManager;
            btnQuanLyNhanVien.Enabled = isManager;
            btnThongKe.Enabled = isManager;
            btnCauHinh.Enabled = isManager;
        }

        private void SetActiveNav(SidebarButton target)
        {
            if (currentNav != null)
            {
                currentNav.IsActive = false;
            }
            currentNav = target;
            if (currentNav != null)
            {
                currentNav.IsActive = true;
            }
        }

        private void UpdateDatabaseStatus()
        {
            try
            {
                bool ok = QLQuanPhoDataContext.TestConnection();
                statusDatabase.Text = ok ? "Database: Kết nối thành công" : "Database: Không thể kết nối";
                statusDatabase.ForeColor = ok ? Color.FromArgb(35, 96, 67) : Color.FromArgb(212, 68, 55);
            }
            catch (Exception ex)
            {
                statusDatabase.Text = $"Database: Lỗi - {ex.Message}";
                statusDatabase.ForeColor = Color.FromArgb(212, 68, 55);
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
            SetActiveNav(navMenu);
            using (var frm = new FrmMonAn())
            {
                frm.ShowDialog();
            }
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            SetActiveNav(navStaff);
            using (var frm = new FrmNhanVien())
            {
                frm.ShowDialog();
            }
        }

        private void btnQuanLyBanAn_Click(object sender, EventArgs e)
        {
            SetActiveNav(navTables);
            using (var frm = new FrmBanAn())
            {
                frm.ShowDialog();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            SetActiveNav(navOrder);
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
            // Khi người dùng nhấn vào mục "Hóa đơn" trên thanh điều hướng, chúng ta mở form
            // báo cáo hóa đơn để hiển thị lịch sử hóa đơn và cho phép xuất/in. Form FrmHoaDon
            // cũ chỉ có nút stub nên được thay thế bằng FrmBaoCaoHoaDon.
            SetActiveNav(navInvoices);
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
            SetActiveNav(navAnalytics);
            using (var frm = new FrmThongKe())
            {
                frm.ShowDialog();
            }
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            SetActiveNav(navSettings);
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
            SetActiveNav(navAnalytics);
            var location = navAnalytics.PointToScreen(new Point(navAnalytics.Width, navAnalytics.Height / 2));
            ctxBaoCao.Show(location);
        }

        private void navDashboard_Click(object sender, EventArgs e)
        {
            SetActiveNav(navDashboard);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            SetActiveNav(navLogout);
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
            lblCurrentTime.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy - HH:mm:ss");
        }
    }
}
