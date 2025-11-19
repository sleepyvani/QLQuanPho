using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PhoManager.UI.Forms
{
    /// <summary>
    /// Designer code for the invoice report form (FrmBaoCaoHoaDon).
    /// The form consists of a filter panel for selecting date range and a button to view the report,
    /// a DataGridView to display the list of invoices, and a label at the bottom showing
    /// the summary (number of invoices and total revenue).
    /// </summary>
    public partial class FrmBaoCaoHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Initialize the UI components for the invoice report form.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTu = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDen = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnXemRDLC = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.lblTong = new System.Windows.Forms.Label();
            this.layoutMain.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.ColumnCount = 1;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.Controls.Add(this.panelFilter, 0, 0);
            this.layoutMain.Controls.Add(this.dgvHoaDon, 0, 1);
            this.layoutMain.Controls.Add(this.lblTong, 0, 2);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.RowCount = 3;
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.layoutMain.Size = new System.Drawing.Size(1053, 483);
            this.layoutMain.TabIndex = 0;
            // 
            // panelFilter
            // 
            this.panelFilter.AutoSize = true;
            this.panelFilter.Controls.Add(this.lblTu);
            this.panelFilter.Controls.Add(this.dtpTuNgay);
            this.panelFilter.Controls.Add(this.lblDen);
            this.panelFilter.Controls.Add(this.dtpDenNgay);
            this.panelFilter.Controls.Add(this.btnXem);
            this.panelFilter.Controls.Add(this.btnExport);
            this.panelFilter.Controls.Add(this.btnPrint);
            this.panelFilter.Controls.Add(this.btnXemRDLC);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(3, 3);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panelFilter.Size = new System.Drawing.Size(1047, 79);
            this.panelFilter.TabIndex = 0;
            this.panelFilter.WrapContents = false;
            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTu.Location = new System.Drawing.Point(9, 11);
            this.lblTu.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.lblTu.Name = "lblTu";
            this.lblTu.Size = new System.Drawing.Size(68, 21);
            this.lblTu.TabIndex = 0;
            this.lblTu.Text = "Từ ngày:";
            this.lblTu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(83, 8);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(3, 3, 11, 3);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(125, 29);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDen.Location = new System.Drawing.Point(222, 11);
            this.lblDen.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(79, 21);
            this.lblDen.TabIndex = 2;
            this.lblDen.Text = "Đến ngày:";
            this.lblDen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(307, 8);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(3, 3, 11, 3);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(125, 29);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // btnXem
            // 
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnXem.Location = new System.Drawing.Point(443, 10);
            this.btnXem.Margin = new System.Windows.Forms.Padding(0, 5, 6, 5);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(171, 45);
            this.btnXem.TabIndex = 4;
            this.btnXem.Text = "Xem báo cáo";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnExport
            // 
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnExport.Location = new System.Drawing.Point(620, 10);
            this.btnExport.Margin = new System.Windows.Forms.Padding(0, 5, 6, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(171, 45);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Xuất hóa đơn";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnPrint.Location = new System.Drawing.Point(797, 10);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0, 5, 6, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(171, 45);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "In hóa đơn";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnXemRDLC
            // 
            this.btnXemRDLC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemRDLC.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnXemRDLC.Location = new System.Drawing.Point(974, 10);
            this.btnXemRDLC.Margin = new System.Windows.Forms.Padding(0, 5, 6, 5);
            this.btnXemRDLC.Name = "btnXemRDLC";
            this.btnXemRDLC.Size = new System.Drawing.Size(171, 45);
            this.btnXemRDLC.TabIndex = 7;
            this.btnXemRDLC.Text = "Xem báo cáo RDLC";
            this.btnXemRDLC.UseVisualStyleBackColor = true;
            this.btnXemRDLC.Click += new System.EventHandler(this.btnXemRDLC_Click);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.Location = new System.Drawing.Point(3, 88);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(1047, 349);
            this.dgvHoaDon.TabIndex = 1;
            // 
            // lblTong
            // 
            this.lblTong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(67)))));
            this.lblTong.Location = new System.Drawing.Point(3, 440);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(1047, 43);
            this.lblTong.TabIndex = 2;
            this.lblTong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmBaoCaoHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 483);
            this.Controls.Add(this.layoutMain);
            this.MinimumSize = new System.Drawing.Size(912, 530);
            this.Name = "FrmBaoCaoHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo Hóa đơn";
            this.layoutMain.ResumeLayout(false);
            this.layoutMain.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.Label lblTu;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnXemRDLC;
    }
}