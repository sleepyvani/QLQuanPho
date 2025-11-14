using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PhoManager.UI.Forms
{
    /// <summary>
    /// Designer code for the best-selling dishes report form (FrmBaoCaoMonBanChay).
    /// The form includes a filter section where the user can select a date range and the number of top dishes to show,
    /// a DataGridView to display the results, a chart to visualize the sales quantities,
    /// and a summary label showing the total quantity and revenue for the selected period.
    /// </summary>
    public partial class FrmBaoCaoMonBanChay
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
        /// Initialize the UI components for the best-selling dishes report form.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTu = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDen = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTop = new System.Windows.Forms.Label();
            this.nudTop = new System.Windows.Forms.NumericUpDown();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.chartBaoCao = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTong = new System.Windows.Forms.Label();
            this.layoutMain.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBaoCao)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.ColumnCount = 1;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.Controls.Add(this.panelFilter, 0, 0);
            this.layoutMain.Controls.Add(this.dgvBaoCao, 0, 1);
            this.layoutMain.Controls.Add(this.chartBaoCao, 0, 2);
            this.layoutMain.Controls.Add(this.lblTong, 0, 3);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.RowCount = 4;
            // Fixed height for filter row, rest proportionally divided
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.layoutMain.Size = new System.Drawing.Size(782, 453);
            this.layoutMain.TabIndex = 0;
            // 
            // panelFilter
            // 
            this.panelFilter.AutoSize = true;
            this.panelFilter.Controls.Add(this.lblTu);
            this.panelFilter.Controls.Add(this.dtpTuNgay);
            this.panelFilter.Controls.Add(this.lblDen);
            this.panelFilter.Controls.Add(this.dtpDenNgay);
            this.panelFilter.Controls.Add(this.lblTop);
            this.panelFilter.Controls.Add(this.nudTop);
            this.panelFilter.Controls.Add(this.btnXem);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.panelFilter.Location = new System.Drawing.Point(3, 3);
            this.panelFilter.Margin = new System.Windows.Forms.Padding(3);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(5);
            this.panelFilter.Size = new System.Drawing.Size(776, 74);
            this.panelFilter.TabIndex = 0;
            this.panelFilter.WrapContents = false;
            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTu.Location = new System.Drawing.Point(8, 9);
            this.lblTu.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.lblTu.Name = "lblTu";
            this.lblTu.Size = new System.Drawing.Size(61, 17);
            this.lblTu.TabIndex = 0;
            this.lblTu.Text = "Từ ngày:";
            this.lblTu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(75, 6);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(110, 24);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDen.Location = new System.Drawing.Point(198, 9);
            this.lblDen.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(69, 17);
            this.lblDen.TabIndex = 2;
            this.lblDen.Text = "Đến ngày:";
            this.lblDen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(273, 6);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(110, 24);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTop.Location = new System.Drawing.Point(396, 9);
            this.lblTop.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(35, 17);
            this.lblTop.TabIndex = 4;
            this.lblTop.Text = "Top:";
            this.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudTop
            // 
            this.nudTop.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudTop.Location = new System.Drawing.Point(437, 6);
            this.nudTop.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.nudTop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTop.Name = "nudTop";
            this.nudTop.Size = new System.Drawing.Size(60, 24);
            this.nudTop.TabIndex = 5;
            this.nudTop.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnXem
            // 
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnXem.Location = new System.Drawing.Point(510, 5);
            this.btnXem.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(120, 30);
            this.btnXem.TabIndex = 6;
            this.btnXem.Text = "Xem báo cáo";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AllowUserToDeleteRows = false;
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCao.Location = new System.Drawing.Point(3, 83);
            this.dgvBaoCao.MultiSelect = false;
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.RowHeadersVisible = false;
            this.dgvBaoCao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCao.Size = new System.Drawing.Size(776, 193);
            this.dgvBaoCao.TabIndex = 1;
            // 
            // chartBaoCao
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBaoCao.ChartAreas.Add(chartArea1);
            this.chartBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartBaoCao.Location = new System.Drawing.Point(3, 282);
            this.chartBaoCao.Name = "chartBaoCao";
            this.chartBaoCao.Size = new System.Drawing.Size(776, 127);
            this.chartBaoCao.TabIndex = 2;
            // 
            // lblTong
            // 
            this.lblTong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(67)))));
            this.lblTong.Location = new System.Drawing.Point(3, 412);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(776, 41);
            this.lblTong.TabIndex = 3;
            this.lblTong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmBaoCaoMonBanChay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.layoutMain);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FrmBaoCaoMonBanChay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo Món bán chạy";
            this.layoutMain.ResumeLayout(false);
            this.layoutMain.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBaoCao)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.Label lblTu;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.NumericUpDown nudTop;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBaoCao;
        private System.Windows.Forms.Label lblTong;
    }
}