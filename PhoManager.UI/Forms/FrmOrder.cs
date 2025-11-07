using System;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.DTO;

namespace PhoManager.UI.Forms
{
    public partial class FrmOrder : Form
    {
        private OrderBLL orderBLL = new OrderBLL();
        private MonAnBLL monAnBLL = new MonAnBLL();
        private BanAnBLL banAnBLL = new BanAnBLL();
        private HoaDonBLL hoaDonBLL = new HoaDonBLL();
        private int maBanHienTai = 0;

        public FrmOrder()
        {
            InitializeComponent();
            LoadDanhSachBan();
            LoadDanhSachMonAn();
        }

        private void LoadDanhSachBan()
        {
            cboBan.DataSource = banAnBLL.LayDanhSachBanAn();
            cboBan.DisplayMember = "TenBan";
            cboBan.ValueMember = "MaBan";
        }

        private void LoadDanhSachMonAn()
        {
            dgvMonAn.DataSource = monAnBLL.LayDanhSachMonAn();
            dgvMonAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (cboBan.SelectedValue == null || dgvMonAn.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn và món ăn!");
                return;
            }

            int maBan = (int)cboBan.SelectedValue;
            MonAnDTO monAn = (MonAnDTO)dgvMonAn.SelectedRows[0].DataBoundItem;
            
            ChiTietHoaDonDTO chiTiet = new ChiTietHoaDonDTO
            {
                MaMon = monAn.MaMon,
                SoLuong = int.Parse(txtSoLuong.Text),
                KichCo = cboKichCo.Text,
                GhiChu = txtGhiChuMon.Text
            };

            if (FrmLogin.NhanVienDangNhap != null)
            {
                string result = orderBLL.TaoOrder(maBan, FrmLogin.NhanVienDangNhap.MaNV, chiTiet);
                MessageBox.Show(result);
                LoadChiTietHoaDon(maBan);
            }
        }

        private void LoadChiTietHoaDon(int maBan)
        {
            HoaDonDTO hoaDon = hoaDonBLL.LayHoaDonChuaThanhToanTheoBan(maBan);
            if (hoaDon != null)
            {
                dgvChiTiet.DataSource = hoaDon.ChiTietHoaDon;
                lblTongTien.Text = $"Tổng tiền: {hoaDon.ThanhTien:N0} VNĐ";
            }
        }

        private void cboBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBan.SelectedValue != null)
            {
                maBanHienTai = (int)cboBan.SelectedValue;
                LoadChiTietHoaDon(maBanHienTai);
            }
        }
    }
}

