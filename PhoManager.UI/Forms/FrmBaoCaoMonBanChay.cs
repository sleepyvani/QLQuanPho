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
    /// Báo cáo các món ăn bán chạy trong một khoảng thời gian.
    /// Người dùng có thể chọn ngày bắt đầu/kết thúc và số lượng món (top N) muốn xem.
    /// </summary>
    public partial class FrmBaoCaoMonBanChay : Form
    {
        private readonly ThongKeBLL thongKeBLL = new ThongKeBLL();
        // UI controls are defined in the designer file. Do not redeclare them here.

        // Dictionary để lưu trạng thái sắp xếp của từng cột DataGridView
        private readonly System.Collections.Generic.Dictionary<string, bool> sortDirections = new System.Collections.Generic.Dictionary<string, bool>();

        public FrmBaoCaoMonBanChay()
        {
            InitializeComponent();

            // Áp dụng theme và style các control
            ThemeManager.ApplyBaseFormStyle(this);
            if (this.dgvBaoCao != null)
            {
                ThemeManager.StyleDataGridView(dgvBaoCao);
            }
            if (this.btnXem != null)
            {
                ThemeManager.StyleButton(btnXem, ButtonVariant.Primary);
                btnXem.AutoSize = false;
                btnXem.TextAlign = ContentAlignment.MiddleCenter;
                btnXem.UseCompatibleTextRendering = false;
                btnXem.Image = null;
                btnXem.Width = 150;
            }

            // Đăng ký sự kiện sắp xếp cho DataGridView
            if (this.dgvBaoCao != null)
            {
                this.dgvBaoCao.ColumnHeaderMouseClick += dgvBaoCao_ColumnHeaderMouseClick;
            }
        }

        // The InitializeComponent method has been moved to the designer file (FrmBaoCaoMonBanChay.Designer.cs).

        private void btnXem_Click(object sender, EventArgs e)
        {
            DateTime tu = dtpTuNgay.Value.Date;
            DateTime den = dtpDenNgay.Value.Date;
            if (tu > den)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
                return;
            }
            try
            {
                int top = (int)nudTop.Value;
                DataTable dt = thongKeBLL.ThongKeMonBanChay(tu, den, top);
                dgvBaoCao.DataSource = dt;
                if (dt != null)
                {
                    // Định dạng tiêu đề và format cột cho DataGridView
                    if (dt.Columns.Contains("TenMon"))
                    {
                        dgvBaoCao.Columns["TenMon"].HeaderText = "Món ăn";
                    }
                    if (dt.Columns.Contains("TongSoLuong"))
                    {
                        dgvBaoCao.Columns["TongSoLuong"].HeaderText = "Số lượng";
                        dgvBaoCao.Columns["TongSoLuong"].DefaultCellStyle.Format = "N0";
                    }
                    if (dt.Columns.Contains("TongDoanhThu"))
                    {
                        dgvBaoCao.Columns["TongDoanhThu"].HeaderText = "Doanh thu";
                        dgvBaoCao.Columns["TongDoanhThu"].DefaultCellStyle.Format = "#,##0";
                    }
                    // Cập nhật biểu đồ: xóa series cũ và thêm series mới
                    chartBaoCao.Series.Clear();
                    var seriesChart = new Series("Số lượng");
                    seriesChart.ChartType = SeriesChartType.Column;
                    foreach (DataRow row in dt.Rows)
                    {
                        string tenMon = row["TenMon"].ToString();
                        int soLuong = Convert.ToInt32(row["TongSoLuong"]);
                        seriesChart.Points.AddXY(tenMon, soLuong);
                    }
                    chartBaoCao.Series.Add(seriesChart);
                }
                // Tính tổng số lượng và tổng doanh thu
                int totalQty = 0;
                decimal totalRevenue = 0m;
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TongSoLuong"] != DBNull.Value) totalQty += Convert.ToInt32(row["TongSoLuong"]);
                        if (row["TongDoanhThu"] != DBNull.Value) totalRevenue += Convert.ToDecimal(row["TongDoanhThu"]);
                    }
                }
                lblTong.Text = $"Tổng số lượng: {totalQty} | Tổng doanh thu: {totalRevenue:#,##0} đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê: " + ex.Message);
            }
        }

        /// <summary>
        /// Sắp xếp DataGridView khi nhấn tiêu đề cột.
        /// </summary>
        private void dgvBaoCao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvBaoCao.Columns.Count == 0) return;
            string colName = dgvBaoCao.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(colName)) colName = dgvBaoCao.Columns[e.ColumnIndex].Name;
            if (string.IsNullOrEmpty(colName)) return;
            bool ascending = true;
            if (sortDirections.ContainsKey(colName))
            {
                ascending = !sortDirections[colName];
            }
            sortDirections[colName] = ascending;

            // Nếu DataSource là DataTable
            if (dgvBaoCao.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;
                dv.Sort = colName + (ascending ? " ASC" : " DESC");
                dgvBaoCao.DataSource = dv.ToTable();
                return;
            }
            // Nếu DataSource là DataView
            if (dgvBaoCao.DataSource is DataView dvSrc)
            {
                dvSrc.Sort = colName + (ascending ? " ASC" : " DESC");
                dgvBaoCao.DataSource = dvSrc.ToTable();
                return;
            }
            // Nếu DataSource là IList generic
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

        private void btnXemRDLC_Click(object sender, EventArgs e)
        {
            DateTime tu = dtpTuNgay.Value.Date;
            DateTime den = dtpDenNgay.Value.Date;

            if (tu > den)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int top = (int)nudTop.Value;
                using (var frm = new FrmBaoCaoMonBanChayRDLC(tu, den, top))
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở báo cáo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}