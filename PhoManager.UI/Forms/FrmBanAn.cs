using System;
using System.Drawing;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.DTO;
using System.Linq;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    public partial class FrmBanAn : Form
    {
        private BanAnBLL banAnBLL = new BanAnBLL();
        private BanAnDTO banAnDangChon;

        // Keep track of sort direction for each column
        private readonly System.Collections.Generic.Dictionary<string, bool> sortDirections = new System.Collections.Generic.Dictionary<string, bool>();

        public FrmBanAn()
        {
            InitializeComponent();
            ThemeManager.ApplyBaseFormStyle(this);
            ThemeManager.StyleDataGridView(dgvBanAn);
            ThemeManager.StyleTextBox(txtTimKiemBan);
            ThemeManager.StyleTextBox(txtTenBan);
            ThemeManager.StyleTextBox(txtGhiChu);
            ThemeManager.StyleButton(btnTimKiemBan, ButtonVariant.Primary);
            ThemeManager.StyleButton(btnThem, ButtonVariant.Primary);
            ThemeManager.StyleButton(btnSua, ButtonVariant.Secondary);
            ThemeManager.StyleButton(btnXoa, ButtonVariant.Danger);
            
            // Maintain critical properties after StyleButton - remove icons and ensure no wrapping
            btnTimKiemBan.AutoSize = false;
            btnTimKiemBan.TextAlign = ContentAlignment.MiddleCenter;
            btnTimKiemBan.UseCompatibleTextRendering = false;
            btnTimKiemBan.Image = null;
            btnTimKiemBan.Width = 140;
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
            
            LoadDanhSachBanAn(); 
            // Register events for sorting and selection
            this.dgvBanAn.SelectionChanged += dgvBanAn_SelectionChanged;
            this.dgvBanAn.ColumnHeaderMouseClick += dgvBanAn_ColumnHeaderMouseClick;

        }

        private void LoadDanhSachBanAn(string keyword = "")
        {
            var ds = string.IsNullOrWhiteSpace(keyword)
                ? banAnBLL.LayDanhSachBanAn()
                : banAnBLL.LayDanhSachBanAn().FindAll(b => b.TenBan.Contains(keyword));

            dgvBanAn.DataSource = ds;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenBan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bàn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BanAnDTO banAn = new BanAnDTO
            {
                TenBan = txtTenBan.Text.Trim(),
                SoLuongGhe = (int)nudSoLuongGhe.Value,
                TrangThai = "Trống",
                GhiChu = txtGhiChu.Text.Trim()
            };

            string result = banAnBLL.ThemBanAn(banAn);
            MessageBox.Show(result, "Thông báo",
                MessageBoxButtons.OK,
                result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (result.Contains("thành công"))
            {
                ClearForm();
                LoadDanhSachBanAn();
            }
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (banAnDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn bàn cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string result = banAnBLL.XoaBanAn(banAnDangChon.MaBan);
                MessageBox.Show(result, "Thông báo",
                    MessageBoxButtons.OK,
                    result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (result.Contains("thành công"))
                {
                    ClearForm();
                    LoadDanhSachBanAn();
                }
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (banAnDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn bàn cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            banAnDangChon.TenBan = txtTenBan.Text.Trim();
            banAnDangChon.SoLuongGhe = (int)nudSoLuongGhe.Value;
            banAnDangChon.GhiChu = txtGhiChu.Text.Trim();

            string result = banAnBLL.CapNhatBanAn(banAnDangChon);
            MessageBox.Show(result, "Thông báo",
                MessageBoxButtons.OK,
                result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (result.Contains("thành công"))
            {
                ClearForm();
                LoadDanhSachBanAn();
            }
        }

        private void dgvBanAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBanAn.SelectedRows.Count > 0)
            {
                banAnDangChon = (BanAnDTO)dgvBanAn.SelectedRows[0].DataBoundItem;
                txtTenBan.Text = banAnDangChon.TenBan;
                nudSoLuongGhe.Value = banAnDangChon.SoLuongGhe;
                txtGhiChu.Text = banAnDangChon.GhiChu;
            }
        }

        private void dgvBanAn_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBanAn.SelectedRows.Count > 0)
            {
                banAnDangChon = (BanAnDTO)dgvBanAn.SelectedRows[0].DataBoundItem;
                txtTenBan.Text = banAnDangChon.TenBan;
                nudSoLuongGhe.Value = banAnDangChon.SoLuongGhe;
                txtGhiChu.Text = banAnDangChon.GhiChu;
            }
        }

        /// <summary>
        /// Handle click on column headers to sort the table.
        /// </summary>
        private void dgvBanAn_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string propName = dgvBanAn.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(propName))
            {
                propName = dgvBanAn.Columns[e.ColumnIndex].Name;
            }
            if (string.IsNullOrEmpty(propName)) return;
            var list = dgvBanAn.DataSource as System.Collections.Generic.List<PhoManager.DTO.BanAnDTO>;
            if (list == null || list.Count == 0) return;

            bool ascending = true;
            if (sortDirections.ContainsKey(propName))
            {
                ascending = !sortDirections[propName];
            }
            sortDirections[propName] = ascending;

            var propInfo = typeof(PhoManager.DTO.BanAnDTO).GetProperty(propName);
            if (propInfo == null) return;
            System.Collections.Generic.IEnumerable<PhoManager.DTO.BanAnDTO> sorted;
            if (ascending)
            {
                sorted = list.OrderBy(item => propInfo.GetValue(item, null));
            }
            else
            {
                sorted = list.OrderByDescending(item => propInfo.GetValue(item, null));
            }
            var newList = new System.Collections.Generic.List<PhoManager.DTO.BanAnDTO>(sorted);
            dgvBanAn.DataSource = null;
            dgvBanAn.DataSource = newList;
        }

        private void btnTimKiemBan_Click(object sender, EventArgs e)
        {
            LoadDanhSachBanAn(txtTimKiemBan.Text.Trim());
        }

        private void ClearForm()
        {
            txtTenBan.Clear();
            nudSoLuongGhe.Value = nudSoLuongGhe.Minimum;
            txtGhiChu.Clear();
            banAnDangChon = null;
        }
    }
}

