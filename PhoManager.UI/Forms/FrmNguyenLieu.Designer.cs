using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PhoManager.UI.Forms
{
    /// <summary>
    /// Designer generated part for FrmNguyenLieu.
    /// Defines the UI layout using WinForms designer style. All controls are created
    /// and configured here so that the logic file (FrmNguyenLieu.cs) can remain
    /// focused on business logic. The form displays a list of ingredients on the
    /// left and a detail panel on the right for adding/editing ingredients.
    /// </summary>
    public partial class FrmNguyenLieu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initialize the UI for the ingredient management form.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.dgvNguyenLieu = new System.Windows.Forms.DataGridView();
            this.panelDetail = new System.Windows.Forms.TableLayoutPanel();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblDonVi = new System.Windows.Forms.Label();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblGiaNhap = new System.Windows.Forms.Label();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenLieu)).BeginInit();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.dgvNguyenLieu);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.panelDetail);
            this.splitContainerMain.Panel2MinSize = 250;
            this.splitContainerMain.Size = new System.Drawing.Size(914, 480);
            this.splitContainerMain.SplitterDistance = 500;
            this.splitContainerMain.SplitterWidth = 5;
            this.splitContainerMain.TabIndex = 0;
            // 
            // dgvNguyenLieu
            // 
            this.dgvNguyenLieu.AllowUserToAddRows = false;
            this.dgvNguyenLieu.AllowUserToDeleteRows = false;
            this.dgvNguyenLieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNguyenLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguyenLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNguyenLieu.Location = new System.Drawing.Point(0, 0);
            this.dgvNguyenLieu.MultiSelect = false;
            this.dgvNguyenLieu.Name = "dgvNguyenLieu";
            this.dgvNguyenLieu.ReadOnly = true;
            this.dgvNguyenLieu.RowHeadersVisible = false;
            this.dgvNguyenLieu.RowHeadersWidth = 51;
            this.dgvNguyenLieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNguyenLieu.Size = new System.Drawing.Size(571, 480);
            this.dgvNguyenLieu.TabIndex = 0;
            this.dgvNguyenLieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNguyenLieu_CellClick);
            // 
            // panelDetail
            // 
            this.panelDetail.ColumnCount = 2;
            this.panelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.panelDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDetail.Controls.Add(this.lblTen, 0, 0);
            this.panelDetail.Controls.Add(this.txtTen, 1, 0);
            this.panelDetail.Controls.Add(this.lblDonVi, 0, 1);
            this.panelDetail.Controls.Add(this.txtDonVi, 1, 1);
            this.panelDetail.Controls.Add(this.lblSoLuong, 0, 2);
            this.panelDetail.Controls.Add(this.nudSoLuong, 1, 2);
            this.panelDetail.Controls.Add(this.lblGiaNhap, 0, 3);
            this.panelDetail.Controls.Add(this.txtGiaNhap, 1, 3);
            this.panelDetail.Controls.Add(this.panelButtons, 0, 4);
            this.panelDetail.Controls.Add(this.lblStatus, 0, 5);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetail.Location = new System.Drawing.Point(0, 0);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.RowCount = 6;
            this.panelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.panelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.panelDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDetail.Size = new System.Drawing.Size(338, 480);
            this.panelDetail.TabIndex = 0;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.Location = new System.Drawing.Point(3, 0);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(108, 32);
            this.lblTen.TabIndex = 0;
            this.lblTen.Text = "Tên:";
            this.lblTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTen
            // 
            this.txtTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTen.Location = new System.Drawing.Point(117, 3);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(218, 29);
            this.txtTen.TabIndex = 1;
            // 
            // lblDonVi
            // 
            this.lblDonVi.AutoSize = true;
            this.lblDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDonVi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDonVi.Location = new System.Drawing.Point(3, 32);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(108, 32);
            this.lblDonVi.TabIndex = 2;
            this.lblDonVi.Text = "Đơn vị:";
            this.lblDonVi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDonVi
            // 
            this.txtDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDonVi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDonVi.Location = new System.Drawing.Point(117, 35);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Size = new System.Drawing.Size(218, 29);
            this.txtDonVi.TabIndex = 3;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSoLuong.Location = new System.Drawing.Point(3, 64);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(108, 32);
            this.lblSoLuong.TabIndex = 4;
            this.lblSoLuong.Text = "Số lượng:";
            this.lblSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Dock = System.Windows.Forms.DockStyle.Left;
            this.nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudSoLuong.Location = new System.Drawing.Point(117, 67);
            this.nudSoLuong.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(114, 29);
            this.nudSoLuong.TabIndex = 5;
            // 
            // lblGiaNhap
            // 
            this.lblGiaNhap.AutoSize = true;
            this.lblGiaNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGiaNhap.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGiaNhap.Location = new System.Drawing.Point(3, 96);
            this.lblGiaNhap.Name = "lblGiaNhap";
            this.lblGiaNhap.Size = new System.Drawing.Size(108, 32);
            this.lblGiaNhap.TabIndex = 6;
            this.lblGiaNhap.Text = "Giá nhập:";
            this.lblGiaNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGiaNhap.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtGiaNhap.Location = new System.Drawing.Point(117, 99);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(218, 29);
            this.txtGiaNhap.TabIndex = 7;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelDetail.SetColumnSpan(this.panelButtons, 2);
            this.panelButtons.Controls.Add(this.btnThem);
            this.panelButtons.Controls.Add(this.btnSua);
            this.panelButtons.Controls.Add(this.btnXoa);
            this.panelButtons.Controls.Add(this.btnLamMoi);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(3, 128);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(460, 43);
            this.panelButtons.TabIndex = 8;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnThem.AutoSize = false;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnThem.Location = new System.Drawing.Point(3, 5);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 42);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnThem.UseCompatibleTextRendering = false;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSua.AutoSize = false;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnSua.Location = new System.Drawing.Point(119, 5);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 42);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSua.UseCompatibleTextRendering = false;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnXoa.AutoSize = false;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnXoa.Location = new System.Drawing.Point(235, 5);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 42);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnXoa.UseCompatibleTextRendering = false;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLamMoi.AutoSize = false;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnLamMoi.Location = new System.Drawing.Point(351, 5);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(140, 32);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLamMoi.UseCompatibleTextRendering = false;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.panelDetail.SetColumnSpan(this.lblStatus, 2);
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(67)))));
            this.lblStatus.Location = new System.Drawing.Point(3, 176);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(332, 304);
            this.lblStatus.TabIndex = 9;
            // 
            // FrmNguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 480);
            this.Controls.Add(this.splitContainerMain);
            this.MinimumSize = new System.Drawing.Size(912, 477);
            this.Name = "FrmNguyenLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Nguyên liệu";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenLieu)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.DataGridView dgvNguyenLieu;
        private System.Windows.Forms.TableLayoutPanel panelDetail;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblDonVi;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label lblGiaNhap;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblStatus;
    }
}