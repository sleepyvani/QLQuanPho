using System;
using System.Drawing;
using System.Windows.Forms;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblBadge;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.PictureBox picUserIcon;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.PictureBox picPasswordIcon;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.CheckBox chkGhiNho;
        private System.Windows.Forms.LinkLabel lnkForgot;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;

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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.lnkForgot = new System.Windows.Forms.LinkLabel();
            this.chkGhiNho = new System.Windows.Forms.CheckBox();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.picPasswordIcon = new System.Windows.Forms.PictureBox();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.picUserIcon = new System.Windows.Forms.PictureBox();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBadge = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPasswordIcon)).BeginInit();
            this.pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = ThemeManager.PanelColor;
            this.pnlCard.Controls.Add(this.btnThoat);
            this.pnlCard.Controls.Add(this.btnDangNhap);
            this.pnlCard.Controls.Add(this.lnkForgot);
            this.pnlCard.Controls.Add(this.chkGhiNho);
            this.pnlCard.Controls.Add(this.pnlPassword);
            this.pnlCard.Controls.Add(this.pnlUser);
            this.pnlCard.Controls.Add(this.lblSubtitle);
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblBadge);
            this.pnlCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(40);
            this.pnlCard.Size = new System.Drawing.Size(420, 560);
            this.pnlCard.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(40, 380);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(340, 44);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(40, 332);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(340, 48);
            this.btnDangNhap.TabIndex = 1;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // lnkForgot
            // 
            this.lnkForgot.AutoSize = true;
            this.lnkForgot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkForgot.LinkColor = ThemeManager.PrimaryColor;
            this.lnkForgot.Location = new System.Drawing.Point(240, 300);
            this.lnkForgot.Name = "lnkForgot";
            this.lnkForgot.Size = new System.Drawing.Size(92, 20);
            this.lnkForgot.TabIndex = 6;
            this.lnkForgot.TabStop = true;
            this.lnkForgot.Text = "Cần trợ giúp?";
            // 
            // chkGhiNho
            // 
            this.chkGhiNho.AutoSize = true;
            this.chkGhiNho.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkGhiNho.ForeColor = ThemeManager.TextSecondary;
            this.chkGhiNho.Location = new System.Drawing.Point(40, 300);
            this.chkGhiNho.Name = "chkGhiNho";
            this.chkGhiNho.Size = new System.Drawing.Size(147, 24);
            this.chkGhiNho.TabIndex = 5;
            this.chkGhiNho.Text = "Ghi nhớ tài khoản";
            this.chkGhiNho.UseVisualStyleBackColor = true;
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = ThemeManager.InputBackground;
            this.pnlPassword.Controls.Add(this.btnTogglePassword);
            this.pnlPassword.Controls.Add(this.txtMatKhau);
            this.pnlPassword.Controls.Add(this.picPasswordIcon);
            this.pnlPassword.Location = new System.Drawing.Point(40, 240);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.pnlPassword.Size = new System.Drawing.Size(340, 48);
            this.pnlPassword.TabIndex = 4;
            // 
            // btnTogglePassword
            // 
            this.btnTogglePassword.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTogglePassword.FlatAppearance.BorderSize = 0;
            this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePassword.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F);
            this.btnTogglePassword.ForeColor = ThemeManager.TextMuted;
            this.btnTogglePassword.Location = new System.Drawing.Point(308, 6);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Size = new System.Drawing.Size(32, 36);
            this.btnTogglePassword.TabIndex = 0;
            this.btnTogglePassword.Text = "";
            this.btnTogglePassword.UseVisualStyleBackColor = false;
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BackColor = ThemeManager.InputBackground;
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMatKhau.ForeColor = ThemeManager.TextColor;
            this.txtMatKhau.Location = new System.Drawing.Point(44, 6);
            this.txtMatKhau.MaxLength = 100;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '•';
            this.txtMatKhau.Size = new System.Drawing.Size(264, 25);
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatKhau_KeyPress);
            // 
            // picPasswordIcon
            // 
            this.picPasswordIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.picPasswordIcon.Location = new System.Drawing.Point(0, 6);
            this.picPasswordIcon.Name = "picPasswordIcon";
            this.picPasswordIcon.Size = new System.Drawing.Size(44, 36);
            this.picPasswordIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPasswordIcon.TabIndex = 2;
            this.picPasswordIcon.TabStop = false;
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = ThemeManager.InputBackground;
            this.pnlUser.Controls.Add(this.txtTaiKhoan);
            this.pnlUser.Controls.Add(this.picUserIcon);
            this.pnlUser.Location = new System.Drawing.Point(40, 184);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.pnlUser.Size = new System.Drawing.Size(340, 48);
            this.pnlUser.TabIndex = 3;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.BackColor = ThemeManager.InputBackground;
            this.txtTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTaiKhoan.ForeColor = ThemeManager.TextColor;
            this.txtTaiKhoan.Location = new System.Drawing.Point(44, 6);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(296, 25);
            this.txtTaiKhoan.TabIndex = 1;
            // 
            // picUserIcon
            // 
            this.picUserIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.picUserIcon.Location = new System.Drawing.Point(0, 6);
            this.picUserIcon.Name = "picUserIcon";
            this.picUserIcon.Size = new System.Drawing.Size(44, 36);
            this.picUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picUserIcon.TabIndex = 2;
            this.picUserIcon.TabStop = false;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = ThemeManager.TextMuted;
            this.lblSubtitle.Location = new System.Drawing.Point(40, 140);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(340, 23);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Nhập thông tin tài khoản để tiếp tục truy cập hệ thống";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 24F);
            this.lblTitle.ForeColor = ThemeManager.TextColor;
            this.lblTitle.Location = new System.Drawing.Point(40, 100);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 45);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Chào mừng trở lại!";
            // 
            // lblBadge
            // 
            this.lblBadge.AutoSize = true;
            this.lblBadge.BackColor = ThemeManager.PrimaryLight;
            this.lblBadge.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblBadge.ForeColor = ThemeManager.PrimaryColor;
            this.lblBadge.Location = new System.Drawing.Point(40, 40);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.lblBadge.Size = new System.Drawing.Size(153, 30);
            this.lblBadge.TabIndex = 0;
            this.lblBadge.Text = "Pho Manager 2025";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ThemeManager.BackgroundColor;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(420, 560);
            this.Controls.Add(this.pnlCard);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPasswordIcon)).EndInit();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).EndInit();
            this.ResumeLayout(false);

        }
    }
}