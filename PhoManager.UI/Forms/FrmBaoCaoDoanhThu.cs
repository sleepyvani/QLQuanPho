using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PhoManager.BLL;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    /// <summary>
    /// Báo cáo doanh thu theo ngày hoặc theo tháng.
    /// </summary>
    public partial class FrmBaoCaoDoanhThu : Form
    {
        private readonly ThongKeBLL thongKeBLL = new ThongKeBLL();
        // UI controls are now defined in the designer file (FrmBaoCaoDoanhThu.Designer.cs)
        // Remove field declarations from code-behind to avoid duplication.

        // Lưu trạng thái sắp xếp cho từng cột của DataGridView
        private readonly System.Collections.Generic.Dictionary<string, bool> sortDirections = new System.Collections.Generic.Dictionary<string, bool>();

        public FrmBaoCaoDoanhThu()
        {
            InitializeComponent();

            // Áp dụng giao diện nền và tùy chỉnh các control theo ThemeManager
            ThemeManager.ApplyBaseFormStyle(this);
            if (this.dgvBaoCao != null)
            {
                ThemeManager.StyleDataGridView(dgvBaoCao);
            }
            if (this.btnXem != null)
            {
                ThemeManager.StyleButton(btnXem, ButtonVariant.Primary, IconGlyphs.Search);
            }

            // Gắn sự kiện sắp xếp cho DataGridView nếu đã khởi tạo
            if (this.dgvBaoCao != null)
            {
                this.dgvBaoCao.ColumnHeaderMouseClick += dgvBaoCao_ColumnHeaderMouseClick;
            }
        }

        // Note: the InitializeComponent method has been moved to the designer file (FrmBaoCaoDoanhThu.Designer.cs).

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