namespace PhoManager.UI.Forms
{
    partial class FrmThongKe
    {
        private System.ComponentModel.IContainer components = null;
        // Controls for improved layout and chart support
        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.FlowLayoutPanel panelFilter;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnXemThongKe;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKe;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXemThongKe = new System.Windows.Forms.Button();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.chartThongKe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.ColumnCount = 1;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.RowCount = 3;
            // Row for filter
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            // Row for grid view
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            // Row for chart
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutMain.Controls.Add(this.panelFilter, 0, 0);
            this.layoutMain.Controls.Add(this.dgvThongKe, 0, 1);
            this.layoutMain.Controls.Add(this.chartThongKe, 0, 2);
            // 
            // panelFilter
            // 
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.panelFilter.Padding = new System.Windows.Forms.Padding(10);
            this.panelFilter.WrapContents = false;
            // Add controls to filter panel
            this.panelFilter.Controls.Add(this.lblTuNgay);
            this.panelFilter.Controls.Add(this.dtpTuNgay);
            this.panelFilter.Controls.Add(this.lblDenNgay);
            this.panelFilter.Controls.Add(this.dtpDenNgay);
            this.panelFilter.Controls.Add(this.btnXemThongKe);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.Text = "Từ ngày:";
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Margin = new System.Windows.Forms.Padding(0, 6, 4, 0);
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Width = 120;
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.Text = "Đến ngày:";
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Margin = new System.Windows.Forms.Padding(0, 6, 4, 0);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Width = 120;
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
            // 
            // btnXemThongKe
            // 
            this.btnXemThongKe.AutoSize = true;
            this.btnXemThongKe.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.btnXemThongKe.Text = "Xem thống kê";
            this.btnXemThongKe.Click += new System.EventHandler(this.btnXemThongKe_Click);
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // chartThongKe
            // 
            chartArea1.Name = "ChartArea1";
            this.chartThongKe.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartThongKe.Legends.Add(legend1);
            this.chartThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartThongKe.Series.Add(series1);
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.layoutMain);
            this.Name = "FrmThongKe";
            this.Text = "Thống kê";
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).EndInit();
            this.ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
    }
}

