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
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            SetActiveNav(navInvoices);
            using (var frm = new FrmHoaDon())
            {
                frm.ShowDialog();
            }
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
