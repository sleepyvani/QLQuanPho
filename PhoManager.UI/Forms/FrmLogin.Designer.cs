using System;
using System.Drawing;
using System.Windows.Forms;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblBranding;
        private System.Windows.Forms.Label lblHeroTitle;
        private System.Windows.Forms.Label lblHeroSubtitle;
        private System.Windows.Forms.FlowLayoutPanel flpHeroBullets;
        private System.Windows.Forms.Label lblHeroBullet1;
        private System.Windows.Forms.Label lblHeroBullet2;
        private System.Windows.Forms.Panel pnlHeroArt;
        private System.Windows.Forms.Label lblHeroFooter;
        private System.Windows.Forms.Panel pnlRight;
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblHeroFooter = new System.Windows.Forms.Label();
            this.pnlHeroArt = new System.Windows.Forms.Panel();
            this.flpHeroBullets = new System.Windows.Forms.FlowLayoutPanel();
            this.lblHeroBullet1 = new System.Windows.Forms.Label();
            this.lblHeroBullet2 = new System.Windows.Forms.Label();
            this.lblHeroSubtitle = new System.Windows.Forms.Label();
            this.lblHeroTitle = new System.Windows.Forms.Label();
            this.lblBranding = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
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
            this.flpHeroBullets.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPasswordIcon)).BeginInit();
            this.pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(48, 52, 48, 40);
            this.pnlLeft.Size = new System.Drawing.Size(420, 560);
            this.pnlLeft.TabIndex = 0;
            this.pnlLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLeft_Paint);
            // 
            // lblHeroFooter
            // 
            this.lblHeroFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblHeroFooter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeroFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(231)))), ((int)(((byte)(243)))));
            this.lblHeroFooter.Location = new System.Drawing.Point(48, 506);
            this.lblHeroFooter.Name = "lblHeroFooter";
            this.lblHeroFooter.Size = new System.Drawing.Size(324, 14);
            this.lblHeroFooter.TabIndex = 6;
            this.lblHeroFooter.Text = "© 2025 Pho Manager — All rights reserved";
            this.lblHeroFooter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlHeroArt
            // 
            this.pnlHeroArt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeroArt.Location = new System.Drawing.Point(212, 210);
            this.pnlHeroArt.Name = "pnlHeroArt";
            this.pnlHeroArt.Size = new System.Drawing.Size(160, 180);
            this.pnlHeroArt.TabIndex = 5;
            this.pnlHeroArt.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeroArt_Paint);
            // 
            // flpHeroBullets
            // 
            this.flpHeroBullets.AutoSize = true;
            this.flpHeroBullets.Controls.Add(this.lblHeroBullet1);
            this.flpHeroBullets.Controls.Add(this.lblHeroBullet2);
            this.flpHeroBullets.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpHeroBullets.Location = new System.Drawing.Point(52, 212);
            this.flpHeroBullets.Name = "flpHeroBullets";
            this.flpHeroBullets.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.flpHeroBullets.Size = new System.Drawing.Size(190, 94);
            this.flpHeroBullets.TabIndex = 4;
            // 
            // lblHeroBullet1
            // 
            this.lblHeroBullet1.AutoSize = true;
            this.lblHeroBullet1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHeroBullet1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(231)))), ((int)(((byte)(243)))));
            this.lblHeroBullet1.Location = new System.Drawing.Point(3, 6);
            this.lblHeroBullet1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.lblHeroBullet1.Name = "lblHeroBullet1";
            this.lblHeroBullet1.Size = new System.Drawing.Size(184, 46);
            this.lblHeroBullet1.TabIndex = 0;
            this.lblHeroBullet1.Text = "• Theo dõi ca làm theo thời gian";
            // 
            // lblHeroBullet2
            // 
            this.lblHeroBullet2.AutoSize = true;
            this.lblHeroBullet2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHeroBullet2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(231)))), ((int)(((byte)(243)))));
            this.lblHeroBullet2.Location = new System.Drawing.Point(193, 6);
            this.lblHeroBullet2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.lblHeroBullet2.Name = "lblHeroBullet2";
            this.lblHeroBullet2.Size = new System.Drawing.Size(232, 23);
            this.lblHeroBullet2.TabIndex = 1;
            this.lblHeroBullet2.Text = "• Báo cáo doanh thu tức thời";
            // 
            // lblHeroSubtitle
            // 
            this.lblHeroSubtitle.AutoSize = true;
            this.lblHeroSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHeroSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(231)))), ((int)(((byte)(243)))));
            this.lblHeroSubtitle.Location = new System.Drawing.Point(52, 164);
            this.lblHeroSubtitle.Name = "lblHeroSubtitle";
            this.lblHeroSubtitle.Size = new System.Drawing.Size(278, 38);
            this.lblHeroSubtitle.TabIndex = 3;
            this.lblHeroSubtitle.Text = "Giải pháp quản lý quán phở tối giản giúp đội ngũ vận hành hiệu quả hơn mỗi ngày.";
            // 
            // lblHeroTitle
            // 
            this.lblHeroTitle.AutoSize = true;
            this.lblHeroTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 28F);
            this.lblHeroTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeroTitle.Location = new System.Drawing.Point(48, 102);
            this.lblHeroTitle.Name = "lblHeroTitle";
            this.lblHeroTitle.Size = new System.Drawing.Size(249, 51);
            this.lblHeroTitle.TabIndex = 2;
            this.lblHeroTitle.Text = "Pho Manager";
            // 
            // lblBranding
            // 
            this.lblBranding.AutoSize = true;
            this.lblBranding.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBranding.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            this.lblBranding.Location = new System.Drawing.Point(48, 48);
            this.lblBranding.Name = "lblBranding";
            this.lblBranding.Size = new System.Drawing.Size(96, 21);
            this.lblBranding.TabIndex = 1;
            this.lblBranding.Text = "Pho House";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlRight.Controls.Add(this.pnlCard);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(420, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(40);
            this.pnlRight.Size = new System.Drawing.Size(420, 560);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.btnThoat);
            this.pnlCard.Controls.Add(this.btnDangNhap);
            this.pnlCard.Controls.Add(this.lnkForgot);
            this.pnlCard.Controls.Add(this.chkGhiNho);
            this.pnlCard.Controls.Add(this.pnlPassword);
            this.pnlCard.Controls.Add(this.pnlUser);
            this.pnlCard.Controls.Add(this.lblSubtitle);
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblBadge);
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Location = new System.Drawing.Point(40, 40);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(32);
            this.pnlCard.Size = new System.Drawing.Size(340, 480);
            this.pnlCard.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThoat.Location = new System.Drawing.Point(32, 78);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(276, 44);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDangNhap.Location = new System.Drawing.Point(32, 32);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(276, 46);
            this.btnDangNhap.TabIndex = 1;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // lnkForgot
            // 
            this.lnkForgot.AutoSize = true;
            this.lnkForgot.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lnkForgot.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lnkForgot.Location = new System.Drawing.Point(195, 288);
            this.lnkForgot.Name = "lnkForgot";
            this.lnkForgot.Size = new System.Drawing.Size(92, 19);
            this.lnkForgot.TabIndex = 6;
            this.lnkForgot.TabStop = true;
            this.lnkForgot.Text = "Cần trợ giúp?";
            // 
            // chkGhiNho
            // 
            this.chkGhiNho.AutoSize = true;
            this.chkGhiNho.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkGhiNho.Location = new System.Drawing.Point(32, 284);
            this.chkGhiNho.Name = "chkGhiNho";
            this.chkGhiNho.Size = new System.Drawing.Size(147, 24);
            this.chkGhiNho.TabIndex = 5;
            this.chkGhiNho.Text = "Ghi nhớ tài khoản";
            this.chkGhiNho.UseVisualStyleBackColor = true;
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.pnlPassword.Controls.Add(this.btnTogglePassword);
            this.pnlPassword.Controls.Add(this.txtMatKhau);
            this.pnlPassword.Controls.Add(this.picPasswordIcon);
            this.pnlPassword.Location = new System.Drawing.Point(32, 220);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.pnlPassword.Size = new System.Drawing.Size(276, 48);
            this.pnlPassword.TabIndex = 4;
            // 
            // btnTogglePassword
            // 
            this.btnTogglePassword.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTogglePassword.FlatAppearance.BorderSize = 0;
            this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePassword.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F);
            this.btnTogglePassword.Location = new System.Drawing.Point(244, 6);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Size = new System.Drawing.Size(32, 36);
            this.btnTogglePassword.TabIndex = 0;
            this.btnTogglePassword.Text = "";
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMatKhau.Location = new System.Drawing.Point(44, 6);
            this.txtMatKhau.MaxLength = 100;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '•';
            this.txtMatKhau.Size = new System.Drawing.Size(232, 25);
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
            this.pnlUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.pnlUser.Controls.Add(this.txtTaiKhoan);
            this.pnlUser.Controls.Add(this.picUserIcon);
            this.pnlUser.Location = new System.Drawing.Point(32, 164);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.pnlUser.Size = new System.Drawing.Size(276, 48);
            this.pnlUser.TabIndex = 3;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.txtTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTaiKhoan.Location = new System.Drawing.Point(44, 6);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(232, 25);
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
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(128)))), ((int)(((byte)(140)))));
            this.lblSubtitle.Location = new System.Drawing.Point(32, 120);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(621, 23);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Nhập thông tin tài khoản để tiếp tục truy cập hệ thống vận hành Pho Manager.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(63)))));
            this.lblTitle.Location = new System.Drawing.Point(28, 78);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(309, 46);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Chào mừng trở lại!";
            // 
            // lblBadge
            // 
            this.lblBadge.AutoSize = true;
            this.lblBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(247)))), ((int)(((byte)(245)))));
            this.lblBadge.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.lblBadge.Location = new System.Drawing.Point(32, 36);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.lblBadge.Size = new System.Drawing.Size(153, 28);
            this.lblBadge.TabIndex = 0;
            this.lblBadge.Text = "Pho Manager 2025";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(840, 560);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.flpHeroBullets.ResumeLayout(false);
            this.flpHeroBullets.PerformLayout();
            this.pnlRight.ResumeLayout(false);
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