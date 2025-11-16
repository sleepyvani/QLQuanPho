using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.DTO;
using System.Linq;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    public partial class FrmMonAn : Form
    {
        private readonly MonAnBLL monAnBLL = new MonAnBLL();
        private List<MonAnDTO> danhSachMonAn;

        // Lưu trạng thái sắp xếp cho từng cột trong bảng món ăn
        private readonly Dictionary<string, bool> sortDirections = new Dictionary<string, bool>();

        public FrmMonAn()
        {
            InitializeComponent();
            ThemeManager.ApplyBaseFormStyle(this);
            ThemeManager.StyleDataGridView(dgvMonAn);
            ThemeManager.StyleButton(btnTimKiem, ButtonVariant.Primary);
            ThemeManager.StyleButton(btnLamMoi, ButtonVariant.Secondary);
            ThemeManager.StyleButton(btnThem, ButtonVariant.Primary);
            ThemeManager.StyleButton(btnSua, ButtonVariant.Secondary);
            ThemeManager.StyleButton(btnXoa, ButtonVariant.Danger);

            // Maintain critical properties after StyleButton - remove icons and ensure no wrapping
            btnTimKiem.AutoSize = false;
            btnTimKiem.TextAlign = ContentAlignment.MiddleCenter;
            btnTimKiem.UseCompatibleTextRendering = false;
            btnTimKiem.Image = null;
            btnTimKiem.Width = 140;
            btnLamMoi.AutoSize = false;
            btnLamMoi.TextAlign = ContentAlignment.MiddleCenter;
            btnLamMoi.UseCompatibleTextRendering = false;
            btnLamMoi.Image = null;
            btnLamMoi.Width = 140;
            btnThem.AutoSize = false;
            btnThem.TextAlign = ContentAlignment.MiddleCenter;
            btnThem.UseCompatibleTextRendering = false;
            btnThem.Image = null;
            btnThem.Width = 120;
            btnSua.AutoSize = false;
            btnSua.TextAlign = ContentAlignment.MiddleCenter;
            btnSua.UseCompatibleTextRendering = false;
            btnSua.Image = null;
            btnSua.Width = 150;
            btnXoa.AutoSize = false;
            btnXoa.TextAlign = ContentAlignment.MiddleCenter;
            btnXoa.UseCompatibleTextRendering = false;
            btnXoa.Image = null;
            btnXoa.Width = 120;

            ThemeManager.StyleTextBox(txtTimKiem);
            ConfigureGrid();
            LoadDanhSachMonAn();

            // Gắn sự kiện sắp xếp dữ liệu khi nhấn vào tiêu đề cột
            this.dgvMonAn.ColumnHeaderMouseClick += dgvMonAn_ColumnHeaderMouseClick;
        }

        private void LoadDanhSachMonAn()
        {
            danhSachMonAn = monAnBLL.LayDanhSachMonAn();
            dgvMonAn.DataSource = danhSachMonAn;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out string message))
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MonAnDTO monAn = new MonAnDTO
            {
                TenMon = txtTenMon.Text.Trim(),
                GiaNho = nudGiaNho.Value,
                GiaLon = nudGiaLon.Value,
                GhiChu = txtGhiChu.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                TrangThai = chkTrangThai.Checked
            };

            string result = monAnBLL.ThemMonAn(monAn);
            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK,
                result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (result.Contains("thành công"))
            {
                ClearForm();
                LoadDanhSachMonAn();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvMonAn.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs(out string message))
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MonAnDTO monAn = (MonAnDTO)dgvMonAn.SelectedRows[0].DataBoundItem;
            monAn.TenMon = txtTenMon.Text.Trim();
            monAn.GiaNho = nudGiaNho.Value;
            monAn.GiaLon = nudGiaLon.Value;
            monAn.GhiChu = txtGhiChu.Text.Trim();
            monAn.MoTa = txtMoTa.Text.Trim();
            monAn.TrangThai = chkTrangThai.Checked;

            string result = monAnBLL.CapNhatMonAn(monAn);
            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK,
                result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (result.Contains("thành công"))
            {
                ClearForm();
                LoadDanhSachMonAn();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvMonAn.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa món ăn này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MonAnDTO monAn = (MonAnDTO)dgvMonAn.SelectedRows[0].DataBoundItem;
                string result = monAnBLL.XoaMonAn(monAn.MaMon);
                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK,
                    result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result.Contains("thành công"))
                {
                    ClearForm();
                    LoadDanhSachMonAn();
                }
            }
        }

        private void dgvMonAn_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMonAn.SelectedRows.Count > 0)
            {
                MonAnDTO monAn = (MonAnDTO)dgvMonAn.SelectedRows[0].DataBoundItem;
                txtTenMon.Text = monAn.TenMon;
                nudGiaNho.Value = ClampToRange(monAn.GiaNho, nudGiaNho.Minimum, nudGiaNho.Maximum);
                nudGiaLon.Value = ClampToRange(monAn.GiaLon, nudGiaLon.Minimum, nudGiaLon.Maximum);
                txtGhiChu.Text = monAn.GhiChu ?? "";
                txtMoTa.Text = monAn.MoTa ?? "";
                chkTrangThai.Checked = monAn.TrangThai;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenMon = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(tenMon))
            {
                danhSachMonAn = monAnBLL.TimKiemMonAn(tenMon);
                dgvMonAn.DataSource = danhSachMonAn;
            }
            else
            {
                LoadDanhSachMonAn();
            }
        }

        private void ClearForm()
        {
            txtTenMon.Clear();
            nudGiaNho.Value = nudGiaNho.Minimum;
            nudGiaLon.Value = nudGiaLon.Minimum;
            txtGhiChu.Clear();
            txtMoTa.Clear();
            chkTrangThai.Checked = true;
        }

        /// <summary>
        /// Xử lý sự kiện nhấn vào tiêu đề cột của DataGridView món ăn để sắp xếp dữ liệu.
        /// </summary>
        private void dgvMonAn_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string propName = dgvMonAn.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(propName))
            {
                propName = dgvMonAn.Columns[e.ColumnIndex].Name;
            }
            if (string.IsNullOrEmpty(propName)) return;
            if (danhSachMonAn == null || danhSachMonAn.Count == 0) return;

            bool ascending = true;
            if (sortDirections.ContainsKey(propName))
            {
                ascending = !sortDirections[propName];
            }
            sortDirections[propName] = ascending;

            var propInfo = typeof(MonAnDTO).GetProperty(propName);
            if (propInfo == null) return;
            IEnumerable<MonAnDTO> sorted;
            if (ascending)
            {
                sorted = danhSachMonAn.OrderBy(ma => propInfo.GetValue(ma, null));
            }
            else
            {
                sorted = danhSachMonAn.OrderByDescending(ma => propInfo.GetValue(ma, null));
            }
            danhSachMonAn = new List<MonAnDTO>(sorted);
            dgvMonAn.DataSource = null;
            dgvMonAn.DataSource = danhSachMonAn;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            ClearForm();
            LoadDanhSachMonAn();
        }

        private bool ValidateInputs(out string message)
        {
            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                message = "Tên món không được để trống.";
                txtTenMon.Focus();
                return false;
            }

            if (nudGiaNho.Value <= 0 || nudGiaLon.Value <= 0)
            {
                message = "Giá món phải lớn hơn 0.";
                return false;
            }

            if (nudGiaLon.Value < nudGiaNho.Value)
            {
                message = "Giá tô lớn phải lớn hơn hoặc bằng giá tô nhỏ.";
                nudGiaLon.Focus();
                return false;
            }

            message = string.Empty;
            return true;
        }

        private decimal ClampToRange(decimal value, decimal minimum, decimal maximum)
        {
            if (value < minimum) return minimum;
            if (value > maximum) return maximum;
            return value;
        }

        private void ConfigureGrid()
        {
            dgvMonAn.AutoGenerateColumns = false;
            dgvMonAn.Columns.Clear();

            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(MonAnDTO.MaMon),
                HeaderText = "Mã",
                Width = 60
            });

            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(MonAnDTO.TenMon),
                HeaderText = "Tên món",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(MonAnDTO.GiaNho),
                HeaderText = "Giá nhỏ",
                DefaultCellStyle = { Format = "N0" }
            });

            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(MonAnDTO.GiaLon),
                HeaderText = "Giá lớn",
                DefaultCellStyle = { Format = "N0" }
            });

            dgvMonAn.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = nameof(MonAnDTO.TrangThai),
                HeaderText = "Đang bán",
                Width = 80
            });
        }
    }        
}

