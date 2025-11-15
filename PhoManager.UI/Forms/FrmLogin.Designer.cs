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
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.TableLayoutPanel tblUser;
        private System.Windows.Forms.PictureBox picUserIcon;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.TableLayoutPanel tblPassword;
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
            this.tblPassword = new System.Windows.Forms.TableLayoutPanel();
            this.picPasswordIcon = new System.Windows.Forms.PictureBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.tblUser = new System.Windows.Forms.TableLayoutPanel();
            this.picUserIcon = new System.Windows.Forms.PictureBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBadge = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.tblPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPasswordIcon)).BeginInit();
            this.pnlUser.SuspendLayout();
            this.tblUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).BeginInit();
            this.SuspendLayout();
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
            this.btnThoat.Location = new System.Drawing.Point(40, 404);
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
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(0);
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
            this.lnkForgot.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lnkForgot.Location = new System.Drawing.Point(240, 300);
            this.lnkForgot.Name = "lnkForgot";
            this.lnkForgot.Size = new System.Drawing.Size(98, 20);
            this.lnkForgot.TabIndex = 6;
            this.lnkForgot.TabStop = true;
            this.lnkForgot.Text = "Cần trợ giúp?";
            // 
            // chkGhiNho
            // 
            this.chkGhiNho.AutoSize = true;
            this.chkGhiNho.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkGhiNho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.chkGhiNho.Location = new System.Drawing.Point(40, 300);
            this.chkGhiNho.Name = "chkGhiNho";
            this.chkGhiNho.Size = new System.Drawing.Size(147, 24);
            this.chkGhiNho.TabIndex = 5;
            this.chkGhiNho.Text = "Ghi nhớ tài khoản";
            this.chkGhiNho.UseVisualStyleBackColor = true;
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlPassword.Controls.Add(this.tblPassword);
            this.pnlPassword.Location = new System.Drawing.Point(40, 240);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(340, 48);
            this.pnlPassword.TabIndex = 4;
            this.pnlPassword.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPassword_Paint);
            // 
            // tblPassword
            // 
            this.tblPassword.ColumnCount = 3;
            this.tblPassword.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tblPassword.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPassword.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tblPassword.Controls.Add(this.picPasswordIcon, 0, 0);
            this.tblPassword.Controls.Add(this.txtMatKhau, 1, 0);
            this.tblPassword.Controls.Add(this.btnTogglePassword, 2, 0);
            this.tblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPassword.Location = new System.Drawing.Point(0, 0);
            this.tblPassword.Name = "tblPassword";
            this.tblPassword.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.tblPassword.RowCount = 1;
            this.tblPassword.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPassword.Size = new System.Drawing.Size(340, 48);
            this.tblPassword.TabIndex = 0;
            // 
            // picPasswordIcon
            // 
            this.picPasswordIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPasswordIcon.Location = new System.Drawing.Point(3, 9);
            this.picPasswordIcon.Name = "picPasswordIcon";
            this.picPasswordIcon.Size = new System.Drawing.Size(38, 30);
            this.picPasswordIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPasswordIcon.TabIndex = 2;
            this.picPasswordIcon.TabStop = false;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtMatKhau.Location = new System.Drawing.Point(47, 9);
            this.txtMatKhau.MaxLength = 100;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '•';
            this.txtMatKhau.Size = new System.Drawing.Size(258, 25);
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatKhau_KeyPress);
            // 
            // btnTogglePassword
            // 
            this.btnTogglePassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTogglePassword.FlatAppearance.BorderSize = 0;
            this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePassword.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14F);
            this.btnTogglePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnTogglePassword.Location = new System.Drawing.Point(311, 9);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Size = new System.Drawing.Size(26, 30);
            this.btnTogglePassword.TabIndex = 0;
            this.btnTogglePassword.Text = "";
            this.btnTogglePassword.UseVisualStyleBackColor = false;
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlUser.Controls.Add(this.tblUser);
            this.pnlUser.Location = new System.Drawing.Point(40, 184);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(340, 48);
            this.pnlUser.TabIndex = 3;
            // 
            // tblUser
            // 
            this.tblUser.ColumnCount = 2;
            this.tblUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tblUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblUser.Controls.Add(this.picUserIcon, 0, 0);
            this.tblUser.Controls.Add(this.txtTaiKhoan, 1, 0);
            this.tblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblUser.Location = new System.Drawing.Point(0, 0);
            this.tblUser.Name = "tblUser";
            this.tblUser.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.tblUser.RowCount = 1;
            this.tblUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblUser.Size = new System.Drawing.Size(340, 48);
            this.tblUser.TabIndex = 0;
            // 
            // picUserIcon
            // 
            this.picUserIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picUserIcon.Location = new System.Drawing.Point(3, 9);
            this.picUserIcon.Name = "picUserIcon";
            this.picUserIcon.Size = new System.Drawing.Size(38, 30);
            this.picUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picUserIcon.TabIndex = 2;
            this.picUserIcon.TabStop = false;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtTaiKhoan.Location = new System.Drawing.Point(47, 9);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(290, 25);
            this.txtTaiKhoan.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 24F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(35, 86);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(362, 54);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Chào mừng trở lại!";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblBadge
            // 
            this.lblBadge.AutoSize = true;
            this.lblBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.lblBadge.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblBadge.Location = new System.Drawing.Point(40, 40);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.lblBadge.Size = new System.Drawing.Size(162, 32);
            this.lblBadge.TabIndex = 0;
            this.lblBadge.Text = "Pho Manager 2025";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
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
            this.tblPassword.ResumeLayout(false);
            this.tblPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPasswordIcon)).EndInit();
            this.pnlUser.ResumeLayout(false);
            this.tblUser.ResumeLayout(false);
            this.tblUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).EndInit();
            this.ResumeLayout(false);

        }
    }
}