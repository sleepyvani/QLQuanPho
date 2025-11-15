using System;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.DTO;

namespace PhoManager.UI.Forms
{
    public partial class FrmBanAn : Form
    {
        private BanAnBLL banAnBLL = new BanAnBLL();

        public FrmBanAn()
        {
            InitializeComponent();
            LoadDanhSachBanAn();
        }

        private void LoadDanhSachBanAn()
        {
            dgvBanAn.DataSource = banAnBLL.LayDanhSachBanAn();
            dgvBanAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BanAnDTO banAn = new BanAnDTO
            {
                TenBan = txtTenBan.Text.Trim(),
                TrangThai = "Trống",
                SoLuongGhe = int.Parse(txtSoLuongGhe.Text),
                GhiChu = txtGhiChu.Text.Trim()
            };

            string result = banAnBLL.ThemBanAn(banAn);
            MessageBox.Show(result);
            if (result.Contains("thành công"))
            {
                ClearForm();
                LoadDanhSachBanAn();
            }
        }

        private void ClearForm()
        {
            txtTenBan.Clear();
            txtSoLuongGhe.Clear();
            txtGhiChu.Clear();
        }
    }
}

