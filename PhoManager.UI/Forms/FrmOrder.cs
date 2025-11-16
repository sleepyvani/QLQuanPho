using System;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.DTO;
using System.Linq;
using System.Collections.Generic;
using PhoManager.UI.Helpers;
using System.Drawing.Printing;
using System.Drawing;

namespace PhoManager.UI.Forms
{
    public partial class FrmOrder : Form
    {
        private OrderBLL orderBLL = new OrderBLL();
        private MonAnBLL monAnBLL = new MonAnBLL();
        private BanAnBLL banAnBLL = new BanAnBLL();
        private HoaDonBLL hoaDonBLL = new HoaDonBLL();
        private int maBanHienTai = 0;
        private HoaDonDTO hoaDonHienTai;
        private Dictionary<string, bool> sortDirections;

        public FrmOrder()
        {
            InitializeComponent();
            ThemeManager.ApplyBaseFormStyle(this);
            ThemeManager.StyleDataGridView(dgvMonAn);
            ThemeManager.StyleDataGridView(dgvChiTiet);
            ThemeManager.StyleComboBox(cboBan);
            ThemeManager.StyleComboBox(cboKichCo);
            ThemeManager.StyleTextBox(txtSoLuong);
            ThemeManager.StyleTextBox(txtGhiChuMon);
            ThemeManager.StyleButton(btnThemMon, ButtonVariant.Primary, IconGlyphs.Add);
            ThemeManager.StyleButton(btnXoaMon, ButtonVariant.Danger, IconGlyphs.Delete);        
            ThemeManager.StyleButton(btnThanhToan, ButtonVariant.Primary, IconGlyphs.Money);
            LoadDanhSachBan();
            LoadDanhSachMonAn();
            btnXoaMon.Click += btnXoaMon_Click;

            // Initialize sorting direction dictionary
            sortDirections = new Dictionary<string, bool>();
            // Attach event handlers for sorting when clicking column headers
            dgvMonAn.ColumnHeaderMouseClick += dgvMonAn_ColumnHeaderMouseClick;
            dgvChiTiet.ColumnHeaderMouseClick += dgvChiTiet_ColumnHeaderMouseClick;

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

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            string kichCo = cboKichCo.Text?.Trim();
            if (string.IsNullOrEmpty(kichCo))
            {
                MessageBox.Show("Vui lòng chọn kích cỡ món ăn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKichCo.Focus();
                return;
            }

            ChiTietHoaDonDTO chiTiet = new ChiTietHoaDonDTO
            {
                MaMon = monAn.MaMon,
                SoLuong = soLuong,
                KichCo = kichCo,
                GhiChu = txtGhiChuMon.Text?.Trim()
            };

            if (FrmLogin.NhanVienDangNhap != null)
            {
                string result = orderBLL.TaoOrder(maBan, FrmLogin.NhanVienDangNhap.MaNV, chiTiet);
                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                LoadChiTietHoaDon(maBan);
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (hoaDonHienTai == null || dgvChiTiet.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChiTietHoaDonDTO chiTiet = (ChiTietHoaDonDTO)dgvChiTiet.SelectedRows[0].DataBoundItem;

            string result = orderBLL.XoaMonKhoiOrder(chiTiet.MaCTHD, hoaDonHienTai.MaHD);
            MessageBox.Show(result, "Thông báo",
                MessageBoxButtons.OK,
                result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            LoadChiTietHoaDon(hoaDonHienTai.MaBan);
        }

        private void LoadChiTietHoaDon(int maBan)
        {
            hoaDonHienTai = hoaDonBLL.LayHoaDonChuaThanhToanTheoBan(maBan);
            if (hoaDonHienTai != null)
            {
                dgvChiTiet.DataSource = hoaDonHienTai.ChiTietHoaDon;
                lblTongTien.Text = $"Tổng tiền: {hoaDonHienTai.ThanhTien:N0} VNĐ";
            }
            else
            {
                dgvChiTiet.DataSource = null;
                lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            }
        }

        /// <summary>
        /// Xử lý sự kiện thanh toán hóa đơn. Khi nhấn nút Thanh toán, chương trình sẽ
        /// xác nhận người dùng, cập nhật trạng thái hóa đơn, giải phóng bàn, hiển thị
        /// bản xem trước hóa đơn và làm mới danh sách chi tiết cho bàn hiện tại.
        /// </summary>
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (hoaDonHienTai == null || hoaDonHienTai.ChiTietHoaDon == null || hoaDonHienTai.ChiTietHoaDon.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn nào cần thanh toán cho bàn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Xác nhận trước khi thanh toán
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn thanh toán hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
            {
                return;
            }
            // Thực hiện thanh toán
            bool ok = hoaDonBLL.ThanhToanHoaDon(hoaDonHienTai);
            if (!ok)
            {
                MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Hiển thị hóa đơn sau khi thanh toán bằng hộp thoại xem trước in
                PrintInvoice(hoaDonHienTai);
            }
            catch (Exception ex)
            {
                // Nếu in thất bại, chỉ ghi log và tiếp tục
                PhoManager.Utilities.Logger.Error("Lỗi khi in hóa đơn: " + ex.Message);
            }
            MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Làm mới chi tiết cho bàn hiện tại. Sau khi thanh toán, hóa đơn hiện tại trở thành null
            LoadChiTietHoaDon(maBanHienTai);
        }

        /// <summary>
        /// Tạo và hiển thị hộp thoại xem trước in cho hóa đơn đã thanh toán. Hàm này
        /// tái sử dụng mã vẽ hóa đơn từ FrmBaoCaoHoaDon. Nếu PrintDocument chưa
        /// được cài đặt, hàm sẽ tạo mới và gán sự kiện PrintPage. Sau đó hiển thị
        /// PrintPreviewDialog để người dùng xem nội dung hóa đơn.
        /// </summary>
        /// <param name="invoice">Đối tượng hóa đơn cần in.</param>
        private void PrintInvoice(HoaDonDTO invoice)
        {
            if (invoice == null) return;
            // Tạo PrintDocument tạm thời và gán sự kiện vẽ trang
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (s, e) =>
            {
                // Sao chép logic vẽ hóa đơn từ FrmBaoCaoHoaDon
                Font headerFont = new Font("Segoe UI", 14, FontStyle.Bold);
                Font subHeaderFont = new Font("Segoe UI", 10, FontStyle.Regular);
                Font tableHeaderFont = new Font("Segoe UI", 10, FontStyle.Bold);
                Font tableFont = new Font("Segoe UI", 10);
                float yPos = 20;
                float leftMargin = e.MarginBounds.Left;

                // Tiêu đề hóa đơn
                e.Graphics.DrawString("HÓA ĐƠN MUA HÀNG", headerFont, Brushes.Black, leftMargin, yPos);
                yPos += headerFont.GetHeight(e.Graphics) + 10;
                e.Graphics.DrawString($"Mã hóa đơn: {invoice.MaHD}", subHeaderFont, Brushes.Black, leftMargin, yPos);
                yPos += subHeaderFont.GetHeight(e.Graphics) + 2;
                e.Graphics.DrawString($"Ngày lập: {invoice.NgayLap:dd/MM/yyyy HH:mm}", subHeaderFont, Brushes.Black, leftMargin, yPos);
                yPos += subHeaderFont.GetHeight(e.Graphics) + 2;
                e.Graphics.DrawString($"Bàn: {invoice.TenBan}", subHeaderFont, Brushes.Black, leftMargin, yPos);
                yPos += subHeaderFont.GetHeight(e.Graphics) + 2;
                e.Graphics.DrawString($"Nhân viên: {invoice.TenNhanVien}", subHeaderFont, Brushes.Black, leftMargin, yPos);
                yPos += subHeaderFont.GetHeight(e.Graphics) + 10;

                // Tiêu đề bảng
                float col1Width = 200;
                float col2Width = 80;
                float col3Width = 100;
                float col4Width = 120;
                e.Graphics.DrawString("Tên món", tableHeaderFont, Brushes.Black, leftMargin, yPos);
                e.Graphics.DrawString("Số lượng", tableHeaderFont, Brushes.Black, leftMargin + col1Width, yPos);
                e.Graphics.DrawString("Đơn giá", tableHeaderFont, Brushes.Black, leftMargin + col1Width + col2Width, yPos);
                e.Graphics.DrawString("Thành tiền", tableHeaderFont, Brushes.Black, leftMargin + col1Width + col2Width + col3Width, yPos);
                yPos += tableHeaderFont.GetHeight(e.Graphics) + 4;

                // Chi tiết từng món
                foreach (var ct in invoice.ChiTietHoaDon)
                {
                    e.Graphics.DrawString(ct.TenMon, tableFont, Brushes.Black, leftMargin, yPos);
                    e.Graphics.DrawString(ct.SoLuong.ToString(), tableFont, Brushes.Black, leftMargin + col1Width, yPos);
                    e.Graphics.DrawString(ct.DonGia.ToString("#,##0"), tableFont, Brushes.Black, leftMargin + col1Width + col2Width, yPos);
                    e.Graphics.DrawString(ct.ThanhTien.ToString("#,##0"), tableFont, Brushes.Black, leftMargin + col1Width + col2Width + col3Width, yPos);
                    yPos += tableFont.GetHeight(e.Graphics) + 2;
                }
                yPos += 10;
                // Tổng kết
                e.Graphics.DrawString($"Tổng tiền: {invoice.TongTien:#,##0}", tableHeaderFont, Brushes.Black, leftMargin, yPos);
                yPos += tableHeaderFont.GetHeight(e.Graphics) + 2;
                e.Graphics.DrawString($"Giảm giá: {invoice.GiamGia:#,##0}", tableHeaderFont, Brushes.Black, leftMargin, yPos);
                yPos += tableHeaderFont.GetHeight(e.Graphics) + 2;
                e.Graphics.DrawString($"Thuế (%): {invoice.Thue:#,##0}", tableHeaderFont, Brushes.Black, leftMargin, yPos);
                yPos += tableHeaderFont.GetHeight(e.Graphics) + 2;
                e.Graphics.DrawString($"Thành tiền: {invoice.ThanhTien:#,##0}", tableHeaderFont, Brushes.Black, leftMargin, yPos);
                e.HasMorePages = false;
            };
            // Hiển thị hộp thoại xem trước
            using (PrintPreviewDialog previewDialog = new PrintPreviewDialog())
            {
                previewDialog.Document = printDoc;
                previewDialog.WindowState = FormWindowState.Maximized;
                previewDialog.ShowDialog();
            }
        }


        private void cboBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBan.SelectedItem is BanAnDTO selectedBan)
            {
                maBanHienTai = selectedBan.MaBan;
                LoadChiTietHoaDon(maBanHienTai);
            }
        }

        private void btnXoaMon_Click_1(object sender, EventArgs e)
        {

            if(hoaDonHienTai == null || dgvChiTiet.SelectedRows.Count == 0)
    {
                MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChiTietHoaDonDTO chiTiet = (ChiTietHoaDonDTO)dgvChiTiet.SelectedRows[0].DataBoundItem;

            string result = orderBLL.XoaMonKhoiOrder(chiTiet.MaCTHD, hoaDonHienTai.MaHD);
            MessageBox.Show(result, "Thông báo",
                MessageBoxButtons.OK,
                result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            LoadChiTietHoaDon(hoaDonHienTai.MaBan);
        }

        /// <summary>
        /// Handles sorting of the list of món ăn when user clicks a column header.
        /// </summary>
        private void dgvMonAn_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvMonAn.DataSource == null) return;
            // Determine the property name associated with the clicked column
            string columnName = dgvMonAn.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(columnName))
            {
                columnName = dgvMonAn.Columns[e.ColumnIndex].Name;
            }
            if (string.IsNullOrEmpty(columnName)) return;

            // Toggle sort direction: default ascending if not present
            bool ascending = !sortDirections.ContainsKey(columnName) || !sortDirections[columnName];
            sortDirections[columnName] = ascending;

            // Check if data source is a list of MonAnDTO
            if (dgvMonAn.DataSource is IList<MonAnDTO> listMon)
            {
                IEnumerable<MonAnDTO> sorted;
                if (ascending)
                {
                    sorted = listMon.OrderBy(item => GetPropertyValue(item, columnName));
                }
                else
                {
                    sorted = listMon.OrderByDescending(item => GetPropertyValue(item, columnName));
                }
                dgvMonAn.DataSource = sorted.ToList();
            }
        }

        /// <summary>
        /// Handles sorting of the chi tiết order list when user clicks a column header.
        /// </summary>
        private void dgvChiTiet_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvChiTiet.DataSource == null) return;
            string columnName = dgvChiTiet.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(columnName))
            {
                columnName = dgvChiTiet.Columns[e.ColumnIndex].Name;
            }
            if (string.IsNullOrEmpty(columnName)) return;

            bool ascending = !sortDirections.ContainsKey(columnName) || !sortDirections[columnName];
            sortDirections[columnName] = ascending;

            if (dgvChiTiet.DataSource is IList<ChiTietHoaDonDTO> listChiTiet)
            {
                IEnumerable<ChiTietHoaDonDTO> sorted;
                if (ascending)
                {
                    sorted = listChiTiet.OrderBy(item => GetPropertyValue(item, columnName));
                }
                else
                {
                    sorted = listChiTiet.OrderByDescending(item => GetPropertyValue(item, columnName));
                }
                dgvChiTiet.DataSource = sorted.ToList();
            }
        }

        /// <summary>
        /// Helper method to retrieve property values via reflection.
        /// </summary>
        private object GetPropertyValue(object obj, string propertyName)
        {
            if (obj == null || string.IsNullOrEmpty(propertyName)) return null;
            var prop = obj.GetType().GetProperty(propertyName);
            return prop != null ? prop.GetValue(obj) : null;
        }
    }
}

