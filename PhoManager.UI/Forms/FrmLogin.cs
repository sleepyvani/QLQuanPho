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

        private const string PLACEHOLDER_USERNAME = "Nhập tài khoản";
        private const string PLACEHOLDER_PASSWORD = "Nhập mật khẩu";
        private Color placeholderColor = ThemeManager.TextMuted;
        private Color textColor = ThemeManager.TextColor;

        private void LoadVisuals()
        {
            lblBadge.Text = "Pho Manager 2025";
            lblTitle.Text = "Chào mừng trở lại!";

            picUserIcon.Image = ThemeManager.CreateGlyphIcon(IconGlyphs.People, ThemeManager.TextMuted, 24);
            picPasswordIcon.Image = ThemeManager.CreateGlyphIcon(IconGlyphs.Lock, ThemeManager.TextMuted, 24);

            ThemeManager.StyleButton(btnDangNhap, ButtonVariant.Primary);
            ThemeManager.StyleButton(btnThoat, ButtonVariant.Secondary);

            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.ForeColor = ThemeManager.TextMuted;
            btnTogglePassword.Cursor = Cursors.Hand;

            // Setup placeholders
            SetupPlaceholder(txtTaiKhoan, PLACEHOLDER_USERNAME);
            SetupPlaceholder(txtMatKhau, PLACEHOLDER_PASSWORD);
        }

        private void SetupPlaceholder(TextBox textBox, string placeholder)
        {
            // Set initial placeholder
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = placeholderColor;
            }

            // TableLayoutPanel will handle vertical centering automatically
            textBox.Multiline = false;

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = textColor;
                    if (textBox == txtMatKhau)
                    {
                        textBox.PasswordChar = '•';
                    }
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = placeholderColor;
                    if (textBox == txtMatKhau)
                    {
                        textBox.PasswordChar = '\0';
                    }
                }
            };
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
            
            // Remove placeholder if present
            if (taiKhoan == PLACEHOLDER_USERNAME) taiKhoan = "";
            if (matKhau == PLACEHOLDER_PASSWORD) matKhau = "";

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
                txtMatKhau.Text = PLACEHOLDER_PASSWORD;
                txtMatKhau.ForeColor = placeholderColor;
                txtMatKhau.PasswordChar = '\0';
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
            if (Settings.Default.RememberAccount && !string.IsNullOrWhiteSpace(Settings.Default.RememberedUsername))
            {
                txtTaiKhoan.Text = Settings.Default.RememberedUsername;
                txtTaiKhoan.ForeColor = textColor;
                chkGhiNho.Checked = true;
            }
            passwordVisible = false;
            txtMatKhau.PasswordChar = '\0'; // Will be set when user enters
        }

        private bool ValidateInputs(out string message)
        {
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(taiKhoan) || taiKhoan == PLACEHOLDER_USERNAME)
            {
                txtTaiKhoan.Focus();
                message = "Vui lòng nhập tài khoản.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(matKhau) || matKhau == PLACEHOLDER_PASSWORD)
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

        private void pnlPassword_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

    }
}

