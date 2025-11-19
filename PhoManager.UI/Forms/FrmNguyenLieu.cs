using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.DTO;

namespace PhoManager.UI.Forms
{
    /// <summary>
    /// Form quản lý nguyên liệu/kho. Cho phép xem, thêm, sửa, xóa nguyên liệu.
    /// </summary>
    public partial class FrmNguyenLieu : Form
    {
        private readonly NguyenLieuBLL nguyenLieuBLL = new NguyenLieuBLL();
        private NguyenLieuDTO nguyenLieuDangChon;

        // Giao diện (UI) được khai báo trong file designer nên không khai báo thủ công ở đây.

        public FrmNguyenLieu()
        {
            InitializeComponent();
            // Áp dụng chủ đề cơ bản cho form
            PhoManager.UI.Helpers.ThemeManager.ApplyBaseFormStyle(this);
            // Áp dụng style cho lưới và các control nếu có
            PhoManager.UI.Helpers.ThemeManager.StyleDataGridView(dgvNguyenLieu);
            PhoManager.UI.Helpers.ThemeManager.StyleButton(btnThem, PhoManager.UI.Helpers.ButtonVariant.Primary);
            PhoManager.UI.Helpers.ThemeManager.StyleButton(btnSua, PhoManager.UI.Helpers.ButtonVariant.Secondary);
            PhoManager.UI.Helpers.ThemeManager.StyleButton(btnXoa, PhoManager.UI.Helpers.ButtonVariant.Danger);
            PhoManager.UI.Helpers.ThemeManager.StyleButton(btnLamMoi, PhoManager.UI.Helpers.ButtonVariant.Tertiary);
            
            // Maintain critical properties after StyleButton - remove icons and ensure no wrapping
            btnThem.AutoSize = false;
            btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btnThem.UseCompatibleTextRendering = false;
            btnThem.Image = null;
            btnThem.Width = 120;
            btnSua.AutoSize = false;
            btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btnSua.UseCompatibleTextRendering = false;
            btnSua.Image = null;
            btnSua.Width = 120;
            btnXoa.AutoSize = false;
            btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btnXoa.UseCompatibleTextRendering = false;
            btnXoa.Image = null;
            btnXoa.Width = 120;
            btnLamMoi.AutoSize = false;
            btnLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btnLamMoi.UseCompatibleTextRendering = false;
            btnLamMoi.Image = null;
            btnLamMoi.Width = 140;
            
            PhoManager.UI.Helpers.ThemeManager.StyleTextBox(txtTen);
            PhoManager.UI.Helpers.ThemeManager.StyleTextBox(txtDonVi);
            PhoManager.UI.Helpers.ThemeManager.StyleTextBox(txtGiaNhap);

            LoadNguyenLieu();

            // Đăng ký sự kiện sắp xếp khi bấm vào tiêu đề cột
            if (this.dgvNguyenLieu != null)
            {
                this.dgvNguyenLieu.ColumnHeaderMouseClick += dgvNguyenLieu_ColumnHeaderMouseClick;
            }
        }

        // Phần khởi tạo giao diện được đặt trong tệp FrmNguyenLieu.Designer.cs

        /// <summary>
        /// Nạp danh sách nguyên liệu vào DataGridView.
        /// </summary>
        private void LoadNguyenLieu()
        {
            var list = nguyenLieuBLL.LayDanhSachNguyenLieu();
            dgvNguyenLieu.DataSource = list;
            // Ẩn những cột không cần hiển thị
            if (dgvNguyenLieu.Columns.Contains("MaNL"))
            {
                dgvNguyenLieu.Columns["MaNL"].Visible = false;
            }
            if (dgvNguyenLieu.Columns.Contains("NgayCapNhat"))
            {
                dgvNguyenLieu.Columns["NgayCapNhat"].HeaderText = "Cập nhật";
                dgvNguyenLieu.Columns["NgayCapNhat"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        // Từ điển lưu trạng thái sắp xếp cho từng cột
        private readonly System.Collections.Generic.Dictionary<string, bool> sortDirections = new System.Collections.Generic.Dictionary<string, bool>();

        /// <summary>
        /// Xử lý sự kiện nhấn vào tiêu đề cột để sắp xếp danh sách nguyên liệu.
        /// </summary>
        private void dgvNguyenLieu_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string propName = dgvNguyenLieu.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(propName))
            {
                propName = dgvNguyenLieu.Columns[e.ColumnIndex].Name;
            }
            if (string.IsNullOrEmpty(propName)) return;
            var list = dgvNguyenLieu.DataSource as System.Collections.Generic.List<PhoManager.DTO.NguyenLieuDTO>;
            if (list == null || list.Count == 0) return;
            bool ascending = true;
            if (sortDirections.ContainsKey(propName))
            {
                ascending = !sortDirections[propName];
            }
            sortDirections[propName] = ascending;

            var propInfo = typeof(PhoManager.DTO.NguyenLieuDTO).GetProperty(propName);
            if (propInfo == null) return;
            System.Collections.Generic.IEnumerable<PhoManager.DTO.NguyenLieuDTO> sorted;
            if (ascending)
            {
                sorted = list.OrderBy(item => propInfo.GetValue(item, null));
            }
            else
            {
                sorted = list.OrderByDescending(item => propInfo.GetValue(item, null));
            }
            var newList = new System.Collections.Generic.List<PhoManager.DTO.NguyenLieuDTO>(sorted);
            dgvNguyenLieu.DataSource = null;
            dgvNguyenLieu.DataSource = newList;
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNguyenLieu.Rows[e.RowIndex].DataBoundItem is NguyenLieuDTO item)
            {
                nguyenLieuDangChon = item;
                txtTen.Text = item.TenNL;
                txtDonVi.Text = item.DonViTinh;
                nudSoLuong.Value = (decimal)item.SoLuongTon;
                txtGiaNhap.Text = item.GiaNhap.HasValue ? item.GiaNhap.Value.ToString() : "";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NguyenLieuDTO nl = new NguyenLieuDTO();
            nl.TenNL = txtTen.Text.Trim();
            nl.DonViTinh = txtDonVi.Text.Trim();
            nl.SoLuongTon = (decimal)nudSoLuong.Value;
            if (decimal.TryParse(txtGiaNhap.Text.Trim(), out decimal gia))
            {
                nl.GiaNhap = gia;
            }
            else
            {
                nl.GiaNhap = null;
            }
            string result = nguyenLieuBLL.ThemNguyenLieu(nl);
            lblStatus.Text = result;
            LoadNguyenLieu();
            ClearForm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (nguyenLieuDangChon == null)
            {
                lblStatus.Text = "Vui lòng chọn nguyên liệu cần sửa.";
                return;
            }
            nguyenLieuDangChon.TenNL = txtTen.Text.Trim();
            nguyenLieuDangChon.DonViTinh = txtDonVi.Text.Trim();
            nguyenLieuDangChon.SoLuongTon = (decimal)nudSoLuong.Value;
            if (decimal.TryParse(txtGiaNhap.Text.Trim(), out decimal gia))
            {
                nguyenLieuDangChon.GiaNhap = gia;
            }
            else
            {
                nguyenLieuDangChon.GiaNhap = null;
            }
            string result = nguyenLieuBLL.CapNhatNguyenLieu(nguyenLieuDangChon);
            lblStatus.Text = result;
            LoadNguyenLieu();
            ClearForm();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (nguyenLieuDangChon == null)
            {
                lblStatus.Text = "Vui lòng chọn nguyên liệu cần xóa.";
                return;
            }
            if (MessageBox.Show($"Bạn có chắc muốn xóa '{nguyenLieuDangChon.TenNL}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string result = nguyenLieuBLL.XoaNguyenLieu(nguyenLieuDangChon.MaNL);
                lblStatus.Text = result;
                LoadNguyenLieu();
                ClearForm();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtTen.Clear();
            txtDonVi.Clear();
            nudSoLuong.Value = 0;
            txtGiaNhap.Clear();
            nguyenLieuDangChon = null;
        }
    }
}