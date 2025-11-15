using System;
using System.Drawing;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.DTO;
using System.Linq;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    public partial class FrmNhanVien : Form
    {
        private NhanVienBLL nhanVienBLL = new NhanVienBLL();
        private NhanVienDTO nvDangChon; 

        // Dictionary to keep track of sort direction for each column
        private readonly System.Collections.Generic.Dictionary<string, bool> sortDirections = new System.Collections.Generic.Dictionary<string, bool>();


        public FrmNhanVien()
        {
            InitializeComponent();
            ThemeManager.ApplyBaseFormStyle(this);
            ThemeManager.StyleDataGridView(dgvNhanVien);
            ThemeManager.StyleTextBox(txtHoTen);
            ThemeManager.StyleTextBox(txtTaiKhoan);
            ThemeManager.StyleTextBox(txtMatKhau);
            ThemeManager.StyleTextBox(txtTimKiemNV);
            ThemeManager.StyleComboBox(cboChucVu);
            ThemeManager.StyleButton(btnTimKiemNV, ButtonVariant.Primary);
            ThemeManager.StyleButton(btnThem, ButtonVariant.Primary);
            ThemeManager.StyleButton(btnSua, ButtonVariant.Secondary);
            ThemeManager.StyleButton(btnXoa, ButtonVariant.Danger);
            
            // Maintain critical properties after StyleButton - remove icons and ensure no wrapping
            btnTimKiemNV.AutoSize = false;
            btnTimKiemNV.TextAlign = ContentAlignment.MiddleCenter;
            btnTimKiemNV.UseCompatibleTextRendering = false;
            btnTimKiemNV.Image = null;
            btnTimKiemNV.Width = 140;
            btnThem.AutoSize = false;
            btnThem.TextAlign = ContentAlignment.MiddleCenter;
            btnThem.UseCompatibleTextRendering = false;
            btnThem.Image = null;
            btnThem.Width = 120;
            btnSua.AutoSize = false;
            btnSua.TextAlign = ContentAlignment.MiddleCenter;
            btnSua.UseCompatibleTextRendering = false;
            btnSua.Image = null;
            btnSua.Width = 120;
            btnXoa.AutoSize = false;
            btnXoa.TextAlign = ContentAlignment.MiddleCenter;
            btnXoa.UseCompatibleTextRendering = false;
            btnXoa.Image = null;
            btnXoa.Width = 120;
            
            LoadDanhSachNhanVien();
            btnTimKiemNV.Click += btnTimKiemNV_Click;

            // Register events for sorting and selection
            this.dgvNhanVien.SelectionChanged += dgvNhanVien_SelectionChanged;
            this.dgvNhanVien.ColumnHeaderMouseClick += dgvNhanVien_ColumnHeaderMouseClick;

        }

        private void LoadDanhSachNhanVien(string keyword = "")
        {
            var ds = string.IsNullOrWhiteSpace(keyword)
                ? nhanVienBLL.LayDanhSachNhanVien()
                : nhanVienBLL.LayDanhSachNhanVien().FindAll(n => n.HoTen.Contains(keyword));

            dgvNhanVien.DataSource = ds;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO
            {
                HoTen = txtHoTen.Text.Trim(),
                TaiKhoan = txtTaiKhoan.Text.Trim(),
                MatKhau = txtMatKhau.Text.Trim(),
                ChucVu = cboChucVu.Text,
                TrangThai = chkTrangThai.Checked
            };

            string result = nhanVienBLL.ThemNhanVien(nv);
            MessageBox.Show(result, "Thông báo",
                MessageBoxButtons.OK,
                result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (result.Contains("thành công"))
            {
                ClearForm();
                LoadDanhSachNhanVien();
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (nvDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            nvDangChon.HoTen = txtHoTen.Text.Trim();
            nvDangChon.TaiKhoan = txtTaiKhoan.Text.Trim();
            nvDangChon.MatKhau = txtMatKhau.Text.Trim();
            nvDangChon.ChucVu = cboChucVu.Text;
            nvDangChon.TrangThai = chkTrangThai.Checked;

            string result = nhanVienBLL.CapNhatNhanVien(nvDangChon);
            MessageBox.Show(result, "Thông báo",
                MessageBoxButtons.OK,
                result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (result.Contains("thành công"))
            {
                ClearForm();
                LoadDanhSachNhanVien();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (nvDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string result = nhanVienBLL.XoaNhanVien(nvDangChon.MaNV);
                MessageBox.Show(result, "Thông báo",
                    MessageBoxButtons.OK,
                    result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (result.Contains("thành công"))
                {
                    ClearForm();
                    LoadDanhSachNhanVien();
                }
            }
        }
        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                nvDangChon = (NhanVienDTO)dgvNhanVien.SelectedRows[0].DataBoundItem;
                txtHoTen.Text = nvDangChon.HoTen;
                txtTaiKhoan.Text = nvDangChon.TaiKhoan;
                txtMatKhau.Text = nvDangChon.MatKhau;
                cboChucVu.Text = nvDangChon.ChucVu;
                chkTrangThai.Checked = nvDangChon.TrangThai;
            }
        }
        private void ClearForm()
        {
            txtHoTen.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            cboChucVu.SelectedIndex = -1;
            chkTrangThai.Checked = true;
            nvDangChon = null;
        }
        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien(txtTimKiemNV.Text.Trim());
        }

        private void txtTimKiemNV_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Xử lý sự kiện nhấn vào tiêu đề cột của DataGridView để sắp xếp dữ liệu.
        /// </summary>
        private void dgvNhanVien_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Lấy tên thuộc tính tương ứng với cột
            string propName = dgvNhanVien.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(propName))
            {
                propName = dgvNhanVien.Columns[e.ColumnIndex].Name;
            }
            if (string.IsNullOrEmpty(propName)) return;

            // Lấy danh sách hiện tại
            var list = dgvNhanVien.DataSource as System.Collections.Generic.List<PhoManager.DTO.NhanVienDTO>;
            if (list == null || list.Count == 0) return;

            // Xác định chiều sắp xếp
            bool ascending = true;
            if (sortDirections.ContainsKey(propName))
            {
                ascending = !sortDirections[propName];
            }
            sortDirections[propName] = ascending;

            var propInfo = typeof(PhoManager.DTO.NhanVienDTO).GetProperty(propName);
            if (propInfo == null) return;

            System.Collections.Generic.IEnumerable<PhoManager.DTO.NhanVienDTO> sorted;
            if (ascending)
            {
                sorted = list.OrderBy(nv => propInfo.GetValue(nv, null));
            }
            else
            {
                sorted = list.OrderByDescending(nv => propInfo.GetValue(nv, null));
            }

            var newList = new System.Collections.Generic.List<PhoManager.DTO.NhanVienDTO>(sorted);
            dgvNhanVien.DataSource = null;
            dgvNhanVien.DataSource = newList;
        }

    
    }
}

