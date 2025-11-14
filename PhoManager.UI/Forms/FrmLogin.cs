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
        private const string PLACEHOLDER_USERNAME = "Nhập tài khoản";
        private const string PLACEHOLDER_PASSWORD = "Nhập mật khẩu";
        private Color placeholderColor = Color.FromArgb(148, 163, 184); // Slate-400
        private Color textColor = Color.FromArgb(15, 23, 42); // Slate-900

        public FrmLogin()
        {
            InitializeComponent();
            LoadVisuals();
            InitializeState();
        }

        private void LoadVisuals()
        {
            lblBadge.Text = "Pho Manager 2025";

            picUserIcon.Image = ThemeManager.CreateGlyphIcon(IconGlyphs.People, ThemeManager.TextMuted, 24);
            picPasswordIcon.Image = ThemeManager.CreateGlyphIcon(IconGlyphs.Lock, ThemeManager.TextMuted, 24);

            ThemeManager.ApplyRoundedCorners(pnlCard, ThemeManager.RadiusXL);
            ThemeManager.ApplyRoundedCorners(pnlUser, ThemeManager.RadiusMD);
            ThemeManager.ApplyRoundedCorners(pnlPassword, ThemeManager.RadiusMD);

            ThemeManager.StyleButton(btnDangNhap, ButtonVariant.Primary);
            ThemeManager.StyleButton(btnThoat, ButtonVariant.Secondary);

            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.ForeColor = ThemeManager.TextMuted;
            btnTogglePassword.Cursor = Cursors.Hand;
            
            // Ensure textboxes display text correctly
            txtTaiKhoan.Multiline = false;
            txtMatKhau.Multiline = false;
            
            // Setup placeholders
            SetupPlaceholder(txtTaiKhoan, PLACEHOLDER_USERNAME);
            SetupPlaceholder(txtMatKhau, PLACEHOLDER_PASSWORD);
        }
        
        private void SetupPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = placeholderColor;
            
            // For password field, remove password char when showing placeholder
            if (textBox == txtMatKhau)
            {
                textBox.PasswordChar = '\0';
            }
            
            textBox.Enter += (s, e) => {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = textColor;
                    if (textBox == txtMatKhau)
                    {
                        textBox.PasswordChar = passwordVisible ? '\0' : '•';
                    }
                }
            };
            textBox.Leave += (s, e) => {
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
            // Only focus if not showing placeholder
            if (txtTaiKhoan.Text == PLACEHOLDER_USERNAME || string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
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

            string taiKhoan = (txtTaiKhoan.Text == PLACEHOLDER_USERNAME) ? "" : txtTaiKhoan.Text.Trim();
            string matKhau = (txtMatKhau.Text == PLACEHOLDER_PASSWORD) ? "" : txtMatKhau.Text.Trim();

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
            passwordVisible = false;
            
            if (Settings.Default.RememberAccount && !string.IsNullOrWhiteSpace(Settings.Default.RememberedUsername))
            {
                // Load saved username - override placeholder
                txtTaiKhoan.Text = Settings.Default.RememberedUsername;
                txtTaiKhoan.ForeColor = textColor;
                chkGhiNho.Checked = true;
            }
            // If no saved username, placeholder is already set in SetupPlaceholder()
            
            // Password field always starts with placeholder (no saved password)
            // PasswordChar is handled in SetupPlaceholder Leave event
        }

        private bool ValidateInputs(out string message)
        {
            string taiKhoan = txtTaiKhoan.Text.Trim();
            if (string.IsNullOrWhiteSpace(taiKhoan) || taiKhoan == PLACEHOLDER_USERNAME)
            {
                txtTaiKhoan.Focus();
                message = "Vui lòng nhập tài khoản.";
                return false;
            }

            string matKhau = txtMatKhau.Text.Trim();
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
            // Only toggle password char if not showing placeholder
            if (txtMatKhau.Text != PLACEHOLDER_PASSWORD)
            {
                txtMatKhau.PasswordChar = passwordVisible ? '\0' : '•';
            }
            btnTogglePassword.Text = passwordVisible ? "\uE70D" : "\uE722";
        }

    }
}

