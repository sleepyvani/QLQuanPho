using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PhoManager.DAL;

namespace PhoManager.UI.Forms
{
    public partial class FrmMain : Form
    {
        private bool isLoggingOut;

        public FrmMain()
        {
            InitializeComponent();
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
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(35, 96, 67)))
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
                lblNhanVien.Text = $"Xin chào, {FrmLogin.NhanVienDangNhap.HoTen} ({FrmLogin.NhanVienDangNhap.ChucVu})";
                statusUser.Text = $"Người dùng: {FrmLogin.NhanVienDangNhap.HoTen}";
            }

            string chucVu = FrmLogin.NhanVienDangNhap?.ChucVu ?? "";
            
            if (chucVu != "Quản lý")
            {
                btnQuanLyMonAn.Enabled = false;
                btnQuanLyNhanVien.Enabled = false;
                btnThongKe.Enabled = false;
                btnCauHinh.Enabled = false;
            }
        }

        private void UpdateDatabaseStatus()
        {
            try
            {
                bool ok = PhoDataContext.TestConnection();
                statusDatabase.Text = ok ? "Database: Kết nối thành công" : "Database: Không thể kết nối";
                statusDatabase.ForeColor = ok ? System.Drawing.Color.FromArgb(35, 96, 67) : System.Drawing.Color.FromArgb(212, 68, 55);
            }
            catch (Exception ex)
            {
                statusDatabase.Text = $"Database: Lỗi - {ex.Message}";
                statusDatabase.ForeColor = System.Drawing.Color.FromArgb(212, 68, 55);
            }
        }

        private void btnQuanLyMonAn_Click(object sender, EventArgs e)
        {
            FrmMonAn frm = new FrmMonAn();
            frm.ShowDialog();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            FrmNhanVien frm = new FrmNhanVien();
            frm.ShowDialog();
        }

        private void btnQuanLyBanAn_Click(object sender, EventArgs e)
        {
            FrmBanAn frm = new FrmBanAn();
            frm.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            FrmOrder frm = new FrmOrder();
            frm.ShowDialog();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            FrmHoaDon frm = new FrmHoaDon();
            frm.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            FrmThongKe frm = new FrmThongKe();
            frm.ShowDialog();
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            FrmCauHinh frm = new FrmCauHinh();
            frm.ShowDialog();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isLoggingOut = true;
                this.Close();
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

