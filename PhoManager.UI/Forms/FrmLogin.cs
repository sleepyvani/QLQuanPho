using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.DTO;
using QLQuanPho.Properties;

namespace PhoManager.UI.Forms
{
    public partial class FrmLogin : Form
    {
        private NhanVienBLL nhanVienBLL = new NhanVienBLL();
        public static NhanVienDTO NhanVienDangNhap { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
            LoadLogo();
            InitializeState();
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
                using (Font font = new Font("Segoe UI", Math.Min(width, height) / 4, FontStyle.Bold))
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                txtTaiKhoan.Focus();
            }
            else
            {
                txtMatKhau.Focus();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out string message))
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string taiKhoan = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            NhanVienDTO nhanVien = nhanVienBLL.DangNhap(taiKhoan, matKhau);
            
            if (nhanVien != null)
            {
                PersistLoginPreference(taiKhoan);
                NhanVienDangNhap = nhanVien;
                this.Hide();
                FrmMain frmMain = new FrmMain();
                frmMain.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi đăng nhập", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtTaiKhoan.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void InitializeState()
        {
            if (Settings.Default.RememberAccount)
            {
                txtTaiKhoan.Text = Settings.Default.RememberedUsername;
                chkGhiNho.Checked = true;
            }
        }

        private bool ValidateInputs(out string message)
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                txtTaiKhoan.Focus();
                message = "Vui lòng nhập tài khoản.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                txtMatKhau.Focus();
                message = "Vui lòng nhập mật khẩu.";
                return false;
            }

            message = string.Empty;
            return true;
        }

        private void PersistLoginPreference(string taiKhoan)
        {
            Settings.Default.RememberAccount = chkGhiNho.Checked;
            Settings.Default.RememberedUsername = chkGhiNho.Checked ? taiKhoan : string.Empty;
            Settings.Default.Save();
        }
    }
}

