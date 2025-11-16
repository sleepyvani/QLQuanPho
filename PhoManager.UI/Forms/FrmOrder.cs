using System;
using System.Drawing;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.DTO;
using System.Linq;
using System.Collections.Generic;
using PhoManager.UI.Helpers;
using System.Drawing.Printing;


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
            ThemeManager.StyleButton(btnThemMon, ButtonVariant.Primary);
            ThemeManager.StyleButton(btnXoaMon, ButtonVariant.Danger);
            ThemeManager.StyleButton(btnThanhToan, ButtonVariant.Primary);

            LoadDanhSachBan();
            LoadDanhSachMonAn();

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

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (hoaDonHienTai == null || hoaDonHienTai.ChiTietHoaDon == null || hoaDonHienTai.ChiTietHoaDon.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn nào cần thanh toán.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn thanh toán hóa đơn hiện tại?",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            bool ok = hoaDonBLL.ThanhToanHoaDon(hoaDonHienTai);
            if (!ok)
            {
                MessageBox.Show("Thanh toán thất bại. Vui lòng thử lại.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                PrintInvoice(hoaDonHienTai);
            }
            catch (Exception ex)
            {
                PhoManager.Utilities.Logger.Error("Lỗi khi in hóa đơn: " + ex);
            }

            MessageBox.Show("Thanh toán thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadChiTietHoaDon(maBanHienTai);
        }
        private void PrintInvoice(HoaDonDTO invoice)
        {
            if (invoice == null) return;

            using (PrintDocument printDoc = new PrintDocument())
            {
                printDoc.DocumentName = $"HoaDon_{invoice.MaHD}";
                printDoc.PrintPage += (s, e) =>
                {
                    float y = e.MarginBounds.Top;
                    float x = e.MarginBounds.Left;

                    using (Font headerFont = new Font("Segoe UI", 14, FontStyle.Bold))
                    using (Font subHeaderFont = new Font("Segoe UI", 10, FontStyle.Regular))
                    using (Font tableHeaderFont = new Font("Segoe UI", 10, FontStyle.Bold))
                    using (Font tableFont = new Font("Segoe UI", 10, FontStyle.Regular))
                    {
                        // ===== Header hóa đơn =====
                        e.Graphics.DrawString("HÓA ĐƠN THANH TOÁN", headerFont, Brushes.Black, x, y);
                        y += headerFont.GetHeight(e.Graphics) + 10;

                        e.Graphics.DrawString($"Mã hóa đơn: {invoice.MaHD}", subHeaderFont, Brushes.Black, x, y);
                        y += subHeaderFont.GetHeight(e.Graphics) + 2;

                        e.Graphics.DrawString($"Ngày lập: {invoice.NgayLap:dd/MM/yyyy HH:mm}", subHeaderFont, Brushes.Black, x, y);
                        y += subHeaderFont.GetHeight(e.Graphics) + 2;

                        e.Graphics.DrawString($"Bàn: {invoice.TenBan}", subHeaderFont, Brushes.Black, x, y);
                        y += subHeaderFont.GetHeight(e.Graphics) + 2;

                        e.Graphics.DrawString($"Nhân viên: {invoice.TenNhanVien}", subHeaderFont, Brushes.Black, x, y);
                        y += subHeaderFont.GetHeight(e.Graphics) + 10;

                        // ===== Bảng chi tiết món =====
                        float col1 = 220;  // Tên món
                        float col2 = 60;   // SL
                        float col3 = 100;  // Đơn giá
                        float col4 = 110;  // Thành tiền

                        e.Graphics.DrawString("Món", tableHeaderFont, Brushes.Black, x, y);
                        e.Graphics.DrawString("SL", tableHeaderFont, Brushes.Black, x + col1, y);
                        e.Graphics.DrawString("Đơn giá", tableHeaderFont, Brushes.Black, x + col1 + col2, y);
                        e.Graphics.DrawString("Thành tiền", tableHeaderFont, Brushes.Black, x + col1 + col2 + col3, y);

                        y += tableHeaderFont.GetHeight(e.Graphics) + 4;
                        e.Graphics.DrawLine(Pens.Black, x, y, x + col1 + col2 + col3 + col4, y);
                        y += 4;

                        foreach (var ct in invoice.ChiTietHoaDon)
                        {
                            e.Graphics.DrawString(ct.TenMon, tableFont, Brushes.Black, x, y);
                            e.Graphics.DrawString(ct.SoLuong.ToString(), tableFont, Brushes.Black, x + col1, y);
                            e.Graphics.DrawString(ct.DonGia.ToString("#,##0"), tableFont, Brushes.Black, x + col1 + col2, y);
                            e.Graphics.DrawString(ct.ThanhTien.ToString("#,##0"), tableFont, Brushes.Black, x + col1 + col2 + col3, y);

                            y += tableFont.GetHeight(e.Graphics) + 2;

                            // Nếu vượt quá 1 trang, báo in tiếp trang sau
                            if (y > e.MarginBounds.Bottom - 80)
                            {
                                e.HasMorePages = true;
                                return;
                            }
                        }

                        y += 10;
                        e.Graphics.DrawLine(Pens.Black, x, y, x + col1 + col2 + col3 + col4, y);
                        y += 6;

                        // ===== Tổng kết =====
                        e.Graphics.DrawString($"Tổng tiền: {invoice.TongTien:#,##0} VNĐ", tableFont, Brushes.Black, x, y);
                        y += tableFont.GetHeight(e.Graphics) + 2;

                        if (invoice.GiamGia != 0)
                        {
                            e.Graphics.DrawString($"Giảm giá: {invoice.GiamGia:#,##0} VNĐ", tableFont, Brushes.Black, x, y);
                            y += tableFont.GetHeight(e.Graphics) + 2;
                        }

                        if (invoice.Thue != 0)
                        {
                            e.Graphics.DrawString($"Thuế: {invoice.Thue:#,##0} VNĐ", tableFont, Brushes.Black, x, y);
                            y += tableFont.GetHeight(e.Graphics) + 2;
                        }

                        e.Graphics.DrawString($"Thành tiền: {invoice.ThanhTien:#,##0} VNĐ", tableHeaderFont, Brushes.Black, x, y);
                    }

                    e.HasMorePages = false;
                };

                using (PrintPreviewDialog preview = new PrintPreviewDialog())
                {
                    preview.Document = printDoc;
                    preview.WindowState = FormWindowState.Maximized;
                    preview.ShowDialog();
                }
            }
        }

    }
}

