using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.DTO;
using PhoManager.UI.Helpers;
using QLQuanPho.Properties;

namespace PhoManager.UI.Forms
{
    public partial class FrmLogin : Form
    {
        private NhanVienBLL nhanVienBLL = new NhanVienBLL();
        public static NhanVienDTO NhanVienDangNhap { get; private set; }
        private bool passwordVisible;

        public FrmLogin()
        {
            InitializeComponent();
            LoadVisuals();
            InitializeState();
        }

        private void LoadVisuals()
        {
            lblBadge.Text = "Pho Manager 2025";
            lblTitle.Text = "Chào mừng trở lại!";
            lblSubtitle.Text = "Nhập thông tin tài khoản để tiếp tục truy cập hệ thống";

            picUserIcon.Image = ThemeManager.CreateGlyphIcon(IconGlyphs.People, ThemeManager.TextMuted, 24);
            picPasswordIcon.Image = ThemeManager.CreateGlyphIcon(IconGlyphs.Lock, ThemeManager.TextMuted, 24);

            ThemeManager.StyleButton(btnDangNhap, ButtonVariant.Primary);
            ThemeManager.StyleButton(btnThoat, ButtonVariant.Secondary);

            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.ForeColor = ThemeManager.TextMuted;
            btnTogglePassword.Cursor = Cursors.Hand;
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
            passwordVisible = false;
            txtMatKhau.PasswordChar = '•';
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

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            txtMatKhau.PasswordChar = passwordVisible ? '\0' : '•';
            btnTogglePassword.Text = passwordVisible ? "\uE70D" : "\uE722";
        }

    }
}

