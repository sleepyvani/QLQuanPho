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
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.TableLayoutPanel pnlUserLayout;
        private System.Windows.Forms.PictureBox picUserIcon;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.TableLayoutPanel pnlPasswordLayout;
        private System.Windows.Forms.PictureBox picPasswordIcon;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.FlowLayoutPanel pnlOptions;
        private System.Windows.Forms.CheckBox chkGhiNho;
        private System.Windows.Forms.LinkLabel lnkForgot;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblBadge = new System.Windows.Forms.Label();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.pnlUserLayout = new System.Windows.Forms.TableLayoutPanel();
            this.picUserIcon = new System.Windows.Forms.PictureBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.pnlPasswordLayout = new System.Windows.Forms.TableLayoutPanel();
            this.picPasswordIcon = new System.Windows.Forms.PictureBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.pnlOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.chkGhiNho = new System.Windows.Forms.CheckBox();
            this.lnkForgot = new System.Windows.Forms.LinkLabel();
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pnlCard.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.pnlUserLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).BeginInit();
            this.pnlPassword.SuspendLayout();
            this.pnlPasswordLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPasswordIcon)).BeginInit();
            this.pnlOptions.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblBadge);
            this.pnlCard.Controls.Add(this.mainLayout);
            this.pnlCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(40);
            this.pnlCard.Size = new System.Drawing.Size(420, 560);
            this.pnlCard.TabIndex = 0;
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.pnlUser, 0, 1);
            this.mainLayout.Controls.Add(this.pnlPassword, 0, 2);
            this.mainLayout.Controls.Add(this.pnlOptions, 0, 3);
            this.mainLayout.Controls.Add(this.pnlButtons, 0, 4);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(40, 40);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 5;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(340, 480);
            this.mainLayout.TabIndex = 0;
            // 
            // lblBadge
            // 
            this.lblBadge.AutoSize = true;
            this.lblBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.lblBadge.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblBadge.Location = new System.Drawing.Point(-5, 0);
            this.lblBadge.Margin = new System.Windows.Forms.Padding(0, 0, 0, 24);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.lblBadge.Size = new System.Drawing.Size(208, 40);
            this.lblBadge.TabIndex = 0;
            this.lblBadge.Text = "Pho Manager 2025";
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.Color.White;
            this.pnlUser.Controls.Add(this.pnlUserLayout);
            this.pnlUser.Location = new System.Drawing.Point(0, 50);
            this.pnlUser.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(340, 44);
            this.pnlUser.TabIndex = 1;
            // 
            // pnlUserLayout
            // 
            this.pnlUserLayout.ColumnCount = 2;
            this.pnlUserLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.pnlUserLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlUserLayout.Controls.Add(this.picUserIcon, 0, 0);
            this.pnlUserLayout.Controls.Add(this.txtTaiKhoan, 1, 0);
            this.pnlUserLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserLayout.Location = new System.Drawing.Point(0, 0);
            this.pnlUserLayout.Name = "pnlUserLayout";
            this.pnlUserLayout.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.pnlUserLayout.RowCount = 1;
            this.pnlUserLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlUserLayout.Size = new System.Drawing.Size(340, 44);
            this.pnlUserLayout.TabIndex = 0;
            // 
            // picUserIcon
            // 
            this.picUserIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picUserIcon.Location = new System.Drawing.Point(0, 12);
            this.picUserIcon.Margin = new System.Windows.Forms.Padding(0);
            this.picUserIcon.Name = "picUserIcon";
            this.picUserIcon.Size = new System.Drawing.Size(48, 20);
            this.picUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picUserIcon.TabIndex = 0;
            this.picUserIcon.TabStop = false;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.BackColor = System.Drawing.Color.White;
            this.txtTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtTaiKhoan.Location = new System.Drawing.Point(56, 12);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(276, 25);
            this.txtTaiKhoan.TabIndex = 1;
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.White;
            this.pnlPassword.Controls.Add(this.pnlPasswordLayout);
            this.pnlPassword.Location = new System.Drawing.Point(0, 110);
            this.pnlPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(340, 44);
            this.pnlPassword.TabIndex = 2;
            // 
            // pnlPasswordLayout
            // 
            this.pnlPasswordLayout.ColumnCount = 3;
            this.pnlPasswordLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.pnlPasswordLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlPasswordLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.pnlPasswordLayout.Controls.Add(this.picPasswordIcon, 0, 0);
            this.pnlPasswordLayout.Controls.Add(this.txtMatKhau, 1, 0);
            this.pnlPasswordLayout.Controls.Add(this.btnTogglePassword, 2, 0);
            this.pnlPasswordLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPasswordLayout.Location = new System.Drawing.Point(0, 0);
            this.pnlPasswordLayout.Name = "pnlPasswordLayout";
            this.pnlPasswordLayout.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.pnlPasswordLayout.RowCount = 1;
            this.pnlPasswordLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlPasswordLayout.Size = new System.Drawing.Size(340, 44);
            this.pnlPasswordLayout.TabIndex = 0;
            // 
            // picPasswordIcon
            // 
            this.picPasswordIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPasswordIcon.Location = new System.Drawing.Point(0, 12);
            this.picPasswordIcon.Margin = new System.Windows.Forms.Padding(0);
            this.picPasswordIcon.Name = "picPasswordIcon";
            this.picPasswordIcon.Size = new System.Drawing.Size(48, 20);
            this.picPasswordIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPasswordIcon.TabIndex = 0;
            this.picPasswordIcon.TabStop = false;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BackColor = System.Drawing.Color.White;
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtMatKhau.Location = new System.Drawing.Point(56, 12);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.txtMatKhau.MaxLength = 100;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '•';
            this.txtMatKhau.Size = new System.Drawing.Size(244, 25);
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
            this.btnTogglePassword.Location = new System.Drawing.Point(308, 12);
            this.btnTogglePassword.Margin = new System.Windows.Forms.Padding(0);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Size = new System.Drawing.Size(32, 20);
            this.btnTogglePassword.TabIndex = 2;
            this.btnTogglePassword.Text = "";
            this.btnTogglePassword.UseVisualStyleBackColor = false;
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.chkGhiNho);
            this.pnlOptions.Controls.Add(this.lnkForgot);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOptions.Location = new System.Drawing.Point(0, 170);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(340, 30);
            this.pnlOptions.TabIndex = 3;
            // 
            // chkGhiNho
            // 
            this.chkGhiNho.AutoSize = true;
            this.chkGhiNho.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkGhiNho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.chkGhiNho.Location = new System.Drawing.Point(0, 0);
            this.chkGhiNho.Margin = new System.Windows.Forms.Padding(0);
            this.chkGhiNho.Name = "chkGhiNho";
            this.chkGhiNho.Size = new System.Drawing.Size(147, 24);
            this.chkGhiNho.TabIndex = 0;
            this.chkGhiNho.Text = "Ghi nhớ tài khoản";
            this.chkGhiNho.UseVisualStyleBackColor = true;
            // 
            // lnkForgot
            // 
            this.lnkForgot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkForgot.AutoSize = true;
            this.lnkForgot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkForgot.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lnkForgot.Location = new System.Drawing.Point(147, 0);
            this.lnkForgot.Margin = new System.Windows.Forms.Padding(0);
            this.lnkForgot.Name = "lnkForgot";
            this.lnkForgot.Size = new System.Drawing.Size(98, 20);
            this.lnkForgot.TabIndex = 1;
            this.lnkForgot.TabStop = true;
            this.lnkForgot.Text = "Cần trợ giúp?";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnDangNhap);
            this.pnlButtons.Controls.Add(this.btnThoat);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlButtons.Location = new System.Drawing.Point(0, 220);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(340, 100);
            this.pnlButtons.TabIndex = 4;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(0, 0);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(340, 44);
            this.btnDangNhap.TabIndex = 0;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(0, 56);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(340, 44);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
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
            this.mainLayout.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.pnlUserLayout.ResumeLayout(false);
            this.pnlUserLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).EndInit();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPasswordLayout.ResumeLayout(false);
            this.pnlPasswordLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPasswordIcon)).EndInit();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
