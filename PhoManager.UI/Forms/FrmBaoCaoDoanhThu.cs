using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PhoManager.BLL;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;

namespace PhoManager.UI.Forms
{
    /// <summary>
    /// Báo cáo doanh thu theo ngày hoặc theo tháng.
    /// </summary>
    public partial class FrmBaoCaoDoanhThu : Form
    {
        private readonly ThongKeBLL thongKeBLL = new ThongKeBLL();
        private DataGridView dgvBaoCao;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBaoCao;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private RadioButton rdoNgay;
        private RadioButton rdoThang;
        private Button btnXem;
        private Label lblTong;
        private TableLayoutPanel layout;
        private Panel panelFilter;
        private Label lblTu;
        private Label lblDen;

        // Lưu trạng thái sắp xếp cho từng cột của DataGridView
        private readonly System.Collections.Generic.Dictionary<string, bool> sortDirections = new System.Collections.Generic.Dictionary<string, bool>();

        public FrmBaoCaoDoanhThu()
        {
            InitializeComponent();

            // Gắn sự kiện sắp xếp cho DataGridView nếu đã khởi tạo
            if (this.dgvBaoCao != null)
            {
                this.dgvBaoCao.ColumnHeaderMouseClick += dgvBaoCao_ColumnHeaderMouseClick;
            }
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblTu = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDen = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.rdoNgay = new System.Windows.Forms.RadioButton();
            this.rdoThang = new System.Windows.Forms.RadioButton();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.chartBaoCao = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTong = new System.Windows.Forms.Label();
            this.layout.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBaoCao)).BeginInit();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layout.Controls.Add(this.panelFilter, 0, 0);
            this.layout.Controls.Add(this.dgvBaoCao, 0, 1);
            this.layout.Controls.Add(this.chartBaoCao, 0, 2);
            this.layout.Controls.Add(this.lblTong, 0, 3);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Name = "layout";
            this.layout.RowCount = 4;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.layout.Size = new System.Drawing.Size(782, 453);
            this.layout.TabIndex = 0;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.lblTu);
            this.panelFilter.Controls.Add(this.dtpTuNgay);
            this.panelFilter.Controls.Add(this.lblDen);
            this.panelFilter.Controls.Add(this.dtpDenNgay);
            this.panelFilter.Controls.Add(this.rdoNgay);
            this.panelFilter.Controls.Add(this.rdoThang);
            this.panelFilter.Controls.Add(this.btnXem);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(3, 3);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(776, 74);
            this.panelFilter.TabIndex = 0;
            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.Location = new System.Drawing.Point(10, 10);
            this.lblTu.Name = "lblTu";
            this.lblTu.Size = new System.Drawing.Size(59, 16);
            this.lblTu.TabIndex = 0;
            this.lblTu.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(10, 10);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(120, 22);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Location = new System.Drawing.Point(10, 10);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(67, 16);
            this.lblDen.TabIndex = 2;
            this.lblDen.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(10, 10);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(120, 22);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // rdoNgay
            // 
            this.rdoNgay.Checked = true;
            this.rdoNgay.Location = new System.Drawing.Point(10, 10);
            this.rdoNgay.Name = "rdoNgay";
            this.rdoNgay.Size = new System.Drawing.Size(104, 24);
            this.rdoNgay.TabIndex = 4;
            this.rdoNgay.TabStop = true;
            this.rdoNgay.Text = "Theo ngày";
            // 
            // rdoThang
            // 
            this.rdoThang.Location = new System.Drawing.Point(10, 10);
            this.rdoThang.Name = "rdoThang";
            this.rdoThang.Size = new System.Drawing.Size(104, 24);
            this.rdoThang.TabIndex = 5;
            this.rdoThang.Text = "Theo tháng";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(10, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(100, 30);
            this.btnXem.TabIndex = 6;
            this.btnXem.Text = "Xem báo cáo";
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AllowUserToDeleteRows = false;
            this.dgvBaoCao.ColumnHeadersHeight = 29;
            this.dgvBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCao.Location = new System.Drawing.Point(3, 83);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.RowHeadersWidth = 51;
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
            series1.ChartArea = "ChartArea1";
            series1.Name = "Doanh thu";
            this.chartBaoCao.Series.Add(series1);
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
            // FrmBaoCaoDoanhThu
            // 
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.layout);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FrmBaoCaoDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo Doanh thu";
            this.layout.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBaoCao)).EndInit();
            this.ResumeLayout(false);

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DateTime tu = dtpTuNgay.Value.Date;
            DateTime den = dtpDenNgay.Value.Date;
            if (rdoThang.Checked)
            {
                // nếu chọn theo tháng: set từ ngày = ngày đầu tháng, đến ngày = cuối tháng
                tu = new DateTime(tu.Year, tu.Month, 1);
                den = tu.AddMonths(1).AddSeconds(-1);
            }
            if (tu > den)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
                return;
            }
            try
            {
                DataTable dt = thongKeBLL.ThongKeDoanhThu(tu, den);
                dgvBaoCao.DataSource = dt;
                if (dt != null)
                {
                    // Định dạng cột doanh thu theo tên cột phù hợp
                    if (dt.Columns.Contains("TongDoanhThu"))
                    {
                        dgvBaoCao.Columns["TongDoanhThu"].HeaderText = "Doanh thu";
                        dgvBaoCao.Columns["TongDoanhThu"].DefaultCellStyle.Format = "#,##0";
                    }
                    else if (dt.Columns.Contains("DoanhThu"))
                    {
                        dgvBaoCao.Columns["DoanhThu"].HeaderText = "Doanh thu";
                        dgvBaoCao.Columns["DoanhThu"].DefaultCellStyle.Format = "#,##0";
                    }
                    if (dt.Columns.Contains("Ngay"))
                    {
                        dgvBaoCao.Columns["Ngay"].HeaderText = rdoThang.Checked ? "Tháng" : "Ngày";
                        dgvBaoCao.Columns["Ngay"].DefaultCellStyle.Format = rdoThang.Checked ? "MM/yyyy" : "dd/MM/yyyy";
                    }
                    // Cập nhật biểu đồ
                    chartBaoCao.Series.Clear();
                    var series = new Series("Doanh thu");
                    series.ChartType = SeriesChartType.Column;
                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime ngay = Convert.ToDateTime(row["Ngay"]);
                        decimal doanhThu = 0m;
                        // Tên cột có thể khác nhau tùy theo truy vấn, thử đọc cả hai tên phổ biến
                        if (dt.Columns.Contains("TongDoanhThu"))
                        {
                            doanhThu = Convert.ToDecimal(row["TongDoanhThu"]);
                        }
                        else if (dt.Columns.Contains("DoanhThu"))
                        {
                            doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                        }
                        string xLabel = rdoThang.Checked ? ngay.ToString("MM/yyyy") : ngay.ToString("dd/MM");
                        series.Points.AddXY(xLabel, doanhThu);
                    }
                    chartBaoCao.Series.Add(series);
                }
                decimal total = thongKeBLL.LayTongDoanhThu(tu, den);
                lblTong.Text = $"Tổng doanh thu: {total:#,##0} đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê: " + ex.Message);
            }
        }

        /// <summary>
        /// Xử lý sự kiện nhấn vào tiêu đề cột để sắp xếp dữ liệu trong bảng doanh thu.
        /// </summary>
        private void dgvBaoCao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvBaoCao.Columns.Count == 0) return;
            string colName = dgvBaoCao.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(colName)) colName = dgvBaoCao.Columns[e.ColumnIndex].Name;
            if (string.IsNullOrEmpty(colName)) return;
            bool ascending = true;
            if (sortDirections.ContainsKey(colName)) ascending = !sortDirections[colName];
            sortDirections[colName] = ascending;

            // Xử lý DataTable
            if (dgvBaoCao.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;
                dv.Sort = colName + (ascending ? " ASC" : " DESC");
                dgvBaoCao.DataSource = dv.ToTable();
                return;
            }
            // Xử lý DataView
            if (dgvBaoCao.DataSource is DataView dvSrc)
            {
                dvSrc.Sort = colName + (ascending ? " ASC" : " DESC");
                dgvBaoCao.DataSource = dvSrc.ToTable();
                return;
            }
            // Xử lý IList generic
            if (dgvBaoCao.DataSource is System.Collections.IList list && list.Count > 0)
            {
                var elementType = list[0].GetType();
                var prop = elementType.GetProperty(colName);
                if (prop == null) return;
                var sorted = ascending ? list.Cast<object>().OrderBy(item => prop.GetValue(item, null))
                                       : list.Cast<object>().OrderByDescending(item => prop.GetValue(item, null));
                var listType = typeof(System.Collections.Generic.List<>).MakeGenericType(elementType);
                var newList = (System.Collections.IList)Activator.CreateInstance(listType);
                foreach (var obj in sorted)
                {
                    newList.Add(obj);
                }
                dgvBaoCao.DataSource = newList;
            }
        }
    }
}