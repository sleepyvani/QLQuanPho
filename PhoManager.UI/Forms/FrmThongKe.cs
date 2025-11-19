using System;
using System.Windows.Forms;
using PhoManager.BLL;
using System.Linq;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    public partial class FrmThongKe : Form
    {
        private ThongKeBLL thongKeBLL = new ThongKeBLL();

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
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            if (tuNgay > denNgay)
            {
                MessageBox.Show(
                    "Ngày bắt đầu không được lớn hơn ngày kết thúc.",
                    "Khoảng ngày không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtpTuNgay.Focus();
                return;
            }

            DateTime homNay = DateTime.Today;
            if (denNgay > homNay)
            {
                MessageBox.Show(
                    "Ngày kết thúc không được lớn hơn ngày hiện tại.",
                    "Khoảng ngày không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                dtpDenNgay.Value = homNay;
                return;
            }

            if ((denNgay - tuNgay).TotalDays > 365)
            {
                MessageBox.Show(
                    "Khoảng thời gian thống kê không nên dài quá 1 năm. Vui lòng chọn lại.",
                    "Khoảng ngày quá lớn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            dgvThongKe.DataSource = thongKeBLL.ThongKeDoanhThu(tuNgay, denNgay);
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

