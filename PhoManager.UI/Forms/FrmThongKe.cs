using System;
using System.Windows.Forms;
using PhoManager.BLL;
using System.Linq;
using PhoManager.UI.Helpers;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace PhoManager.UI.Forms
{
    public partial class FrmThongKe : Form
    {
        private ThongKeBLL thongKeBLL = new ThongKeBLL();

        // Dictionary lưu trạng thái sắp xếp cho DataGridView thống kê
        private readonly System.Collections.Generic.Dictionary<string, bool> sortDirections = new System.Collections.Generic.Dictionary<string, bool>();

        public FrmThongKe()
        {
            InitializeComponent();
            ThemeManager.ApplyBaseFormStyle(this);
            ThemeManager.StyleDataGridView(dgvThongKe);
            ThemeManager.StyleButton(btnXemThongKe, ButtonVariant.Primary, IconGlyphs.Chart);

            // Đăng ký sự kiện sắp xếp nếu DataGridView đã được khởi tạo
            if (this.dgvThongKe != null)
            {
                this.dgvThongKe.ColumnHeaderMouseClick += dgvThongKe_ColumnHeaderMouseClick;
            }
        }

        private void btnXemThongKe_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;
            // Lấy dữ liệu thống kê theo ngày
            DataTable table = thongKeBLL.ThongKeDoanhThu(tuNgay, denNgay);
            dgvThongKe.DataSource = table;
            // Vẽ biểu đồ doanh thu
            if (this.chartThongKe != null)
            {
                chartThongKe.Series.Clear();
                // Series doanh thu theo ngày
                Series seriesDoanhThu = new Series("Doanh thu");
                seriesDoanhThu.ChartType = SeriesChartType.Column;
                seriesDoanhThu.XValueType = ChartValueType.String;
                seriesDoanhThu.IsValueShownAsLabel = true;
                // Series số hóa đơn
                Series seriesSoHoaDon = new Series("Số hóa đơn");
                seriesSoHoaDon.ChartType = SeriesChartType.Line;
                seriesSoHoaDon.XValueType = ChartValueType.String;
                seriesSoHoaDon.IsValueShownAsLabel = true;
                // Lặp qua từng dòng dữ liệu
                foreach (DataRow row in table.Rows)
                {
                    DateTime ngay = Convert.ToDateTime(row["Ngay"]);
                    int soHoaDon = Convert.ToInt32(row["SoHoaDon"]);
                    decimal tongDoanhThu = Convert.ToDecimal(row["TongDoanhThu"]);
                    string xValue = ngay.ToString("dd/MM");
                    seriesDoanhThu.Points.AddXY(xValue, tongDoanhThu);
                    seriesSoHoaDon.Points.AddXY(xValue, soHoaDon);
                }
                // Thiết lập tên trục
                chartThongKe.ChartAreas[0].AxisX.Title = "Ngày";
                chartThongKe.ChartAreas[0].AxisY.Title = "Doanh thu";
                chartThongKe.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
                chartThongKe.ChartAreas[0].AxisY2.Title = "Số hóa đơn";
                seriesSoHoaDon.YAxisType = AxisType.Secondary;
                chartThongKe.Series.Add(seriesDoanhThu);
                chartThongKe.Series.Add(seriesSoHoaDon);
                // Đặt màu sắc hài hòa theo theme nếu cần (sử dụng màu mặc định của Chart)
            }
        }

        /// <summary>
        /// Xử lý sự kiện bấm vào tiêu đề cột để sắp xếp dữ liệu thống kê.
        /// </summary>
        private void dgvThongKe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string colName = dgvThongKe.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(colName)) colName = dgvThongKe.Columns[e.ColumnIndex].Name;
            if (string.IsNullOrEmpty(colName)) return;
            bool ascending = true;
            if (sortDirections.ContainsKey(colName)) ascending = !sortDirections[colName];
            sortDirections[colName] = ascending;

            if (dgvThongKe.DataSource is System.Data.DataTable dt)
            {
                var dv = dt.DefaultView;
                dv.Sort = colName + (ascending ? " ASC" : " DESC");
                dgvThongKe.DataSource = dv.ToTable();
                return;
            }
            if (dgvThongKe.DataSource is System.Data.DataView dvSrc)
            {
                dvSrc.Sort = colName + (ascending ? " ASC" : " DESC");
                dgvThongKe.DataSource = dvSrc.ToTable();
                return;
            }
            if (dgvThongKe.DataSource is System.Collections.IList list && list.Count > 0)
            {
                var elementType = list[0].GetType();
                var prop = elementType.GetProperty(colName);
                if (prop == null) return;
                var sorted = ascending ? list.Cast<object>().OrderBy(item => prop.GetValue(item, null))
                                       : list.Cast<object>().OrderByDescending(item => prop.GetValue(item, null));
                var listType = typeof(System.Collections.Generic.List<>).MakeGenericType(elementType);
                var newList = (System.Collections.IList)Activator.CreateInstance(listType);
                foreach (var obj in sorted) newList.Add(obj);
                dgvThongKe.DataSource = newList;
            }
        }
    }
}

