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
            lblHeroTitle.Text = "Quản lý quán phở\nnhanh và trực quan";
            lblHeroSubtitle.Text = "Giao diện mới giúp bạn theo dõi trạng thái bàn, doanh thu và ca làm một cách thoải mái.";
            lblHeroBullet1.Text = "• Vận hành gọn gàng, phối hợp mượt mà.";
            lblHeroBullet2.Text = "• Báo cáo tức thời, kiểm soát doanh thu.";
            lblBranding.Text = "Pho Manager";
            lblBadge.Text = "Đã tối ưu cho ca làm sáng";

            picUserIcon.Image = ThemeManager.CreateGlyphIcon(IconGlyphs.People, Color.FromArgb(150, 155, 168), 26);
            picPasswordIcon.Image = ThemeManager.CreateGlyphIcon(IconGlyphs.Lock, Color.FromArgb(150, 155, 168), 26);

            ThemeManager.ApplyRoundedCorners(pnlCard, 26);
            ThemeManager.ApplyRoundedCorners(pnlUser, 20);
            ThemeManager.ApplyRoundedCorners(pnlPassword, 20);

            ThemeManager.StyleButton(btnDangNhap, ButtonVariant.Primary, IconGlyphs.Lock);
            ThemeManager.StyleButton(btnThoat, ButtonVariant.Secondary, IconGlyphs.Logout);

            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.ForeColor = Color.FromArgb(120, 130, 145);
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

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(pnlLeft.ClientRectangle,
                       Color.FromArgb(18, 38, 63),
                       Color.FromArgb(32, 84, 145),
                       LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, pnlLeft.ClientRectangle);
            }
        }

        private void pnlHeroArt_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = pnlHeroArt.ClientRectangle;
            rect.Inflate(-6, -6);
            using (var bowlBrush = new SolidBrush(Color.FromArgb(248, 250, 253)))
            using (var rimPen = new Pen(Color.FromArgb(191, 226, 255), 3))
            using (var accentPen = new Pen(Color.FromArgb(26, 188, 156), 3))
            {
                var center = new Point(rect.Width / 2, rect.Height / 2 + 15);
                var size = new Size(rect.Width - 30, rect.Height / 2);
                var bowlRect = new Rectangle(center.X - size.Width / 2, center.Y - size.Height / 2, size.Width, size.Height);
                var path = new GraphicsPath();
                path.AddArc(bowlRect.X, bowlRect.Y, bowlRect.Width, bowlRect.Height, 0, 180);
                path.AddLine(bowlRect.X, center.Y, bowlRect.Right, center.Y);
                g.FillPath(bowlBrush, path);
                g.DrawPath(rimPen, path);
                g.DrawCurve(accentPen, new[]
                {
                    new Point(bowlRect.X + 18, bowlRect.Y + 4),
                    new Point(center.X, bowlRect.Y - 28),
                    new Point(bowlRect.Right - 18, bowlRect.Y + 4)
                });
                g.DrawLine(rimPen, bowlRect.X + 25, center.Y + 6, bowlRect.Right - 25, center.Y + 6);
            }
        }
    }
}

