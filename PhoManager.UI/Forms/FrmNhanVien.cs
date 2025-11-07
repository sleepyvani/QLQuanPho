using System;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.DTO;

namespace PhoManager.UI.Forms
{
    public partial class FrmNhanVien : Form
    {
        private NhanVienBLL nhanVienBLL = new NhanVienBLL();

        public FrmNhanVien()
        {
            InitializeComponent();
            LoadDanhSachNhanVien();
        }

        private void LoadDanhSachNhanVien()
        {
            dgvNhanVien.DataSource = nhanVienBLL.LayDanhSachNhanVien();
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVienDTO nhanVien = new NhanVienDTO
            {
                HoTen = txtHoTen.Text.Trim(),
                TaiKhoan = txtTaiKhoan.Text.Trim(),
                MatKhau = txtMatKhau.Text.Trim(),
                ChucVu = cboChucVu.Text,
                TrangThai = chkTrangThai.Checked
            };

            string result = nhanVienBLL.ThemNhanVien(nhanVien);
            MessageBox.Show(result, "Thông báo");
            if (result.Contains("thành công"))
            {
                ClearForm();
                LoadDanhSachNhanVien();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
                return;
            }
        }

        private void ClearForm()
        {
            txtHoTen.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            cboChucVu.SelectedIndex = -1;
            chkTrangThai.Checked = true;
        }
    }
}

