using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using PhoManager.BLL;
using PhoManager.DTO;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    /// <summary>
    /// Báo cáo danh sách hóa đơn trong một khoảng thời gian.
    /// Hiển thị danh sách hóa đơn và tổng số hóa đơn, tổng doanh thu.
    /// </summary>
    public partial class FrmBaoCaoHoaDon : Form
    {
        private readonly HoaDonBLL hoaDonBLL = new HoaDonBLL();
        // UI controls are defined in the designer file. Do not redeclare them here.

        // Từ điển lưu trạng thái sắp xếp cho từng cột
        private readonly System.Collections.Generic.Dictionary<string, bool> sortDirections = new System.Collections.Generic.Dictionary<string, bool>();

        // Giữ hóa đơn được chọn để in. Khi người dùng nhấn In hóa đơn, đối tượng này sẽ
        // được sử dụng bởi sự kiện PrintPage để vẽ nội dung hóa đơn lên tài liệu in.
        private HoaDonDTO invoiceToPrint;

        // Đối tượng PrintDocument dùng cho tính năng in. Được khởi tạo một lần trong
        // hàm khởi tạo form để gắn sự kiện PrintPage.
        private System.Drawing.Printing.PrintDocument printDocument;

        public FrmBaoCaoHoaDon()
        {
            InitializeComponent();

            // Áp dụng theme và style các control
            ThemeManager.ApplyBaseFormStyle(this);
            if (this.dgvHoaDon != null)
            {
                ThemeManager.StyleDataGridView(dgvHoaDon);
            }
            if (this.btnXem != null)
            {
                ThemeManager.StyleButton(btnXem, ButtonVariant.Primary);
                btnXem.AutoSize = false;
                btnXem.TextAlign = ContentAlignment.MiddleCenter;
                btnXem.UseCompatibleTextRendering = false;
                btnXem.Image = null;
                btnXem.Width = 150;
            }
            if (this.btnExport != null)
            {
                ThemeManager.StyleButton(btnExport, ButtonVariant.Secondary);
                btnExport.AutoSize = false;
                btnExport.TextAlign = ContentAlignment.MiddleCenter;
                btnExport.UseCompatibleTextRendering = false;
                btnExport.Image = null;
                btnExport.Width = 150;
            }
            if (this.btnPrint != null)
            {
                ThemeManager.StyleButton(btnPrint, ButtonVariant.Secondary);
                btnPrint.AutoSize = false;
                btnPrint.TextAlign = ContentAlignment.MiddleCenter;
                btnPrint.UseCompatibleTextRendering = false;
                btnPrint.Image = null;
                btnPrint.Width = 150;
            }

            // Khởi tạo PrintDocument và gắn sự kiện PrintPage để vẽ nội dung hóa đơn khi in.
            printDocument = new System.Drawing.Printing.PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            // Đăng ký sự kiện sắp xếp cho DataGridView nếu đã khởi tạo
            if (this.dgvHoaDon != null)
            {
                this.dgvHoaDon.ColumnHeaderMouseClick += dgvHoaDon_ColumnHeaderMouseClick;
            }
        }

        // The InitializeComponent method has been moved to the designer file (FrmBaoCaoHoaDon.Designer.cs).

        private void btnXem_Click(object sender, EventArgs e)
        {
            DateTime tu = dtpTuNgay.Value.Date;
            DateTime den = dtpDenNgay.Value.Date;
            if (tu > den)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
                return;
            }
            try
            {
                List<HoaDonDTO> list = hoaDonBLL.LayDanhSachHoaDon(tu, den);
                dgvHoaDon.DataSource = list;
                if (list != null && list.Count > 0)
                {
                    // Đặt header và định dạng cột nếu tồn tại
                    if (dgvHoaDon.Columns.Contains("MaHD"))
                    {
                        dgvHoaDon.Columns["MaHD"].HeaderText = "Mã HĐ";
                    }
                    if (dgvHoaDon.Columns.Contains("TenBan"))
                    {
                        dgvHoaDon.Columns["TenBan"].HeaderText = "Bàn";
                    }
                    if (dgvHoaDon.Columns.Contains("TenNhanVien"))
                    {
                        dgvHoaDon.Columns["TenNhanVien"].HeaderText = "Nhân viên";
                    }
                    if (dgvHoaDon.Columns.Contains("NgayLap"))
                    {
                        dgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày lập";
                        dgvHoaDon.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }
                    if (dgvHoaDon.Columns.Contains("ThanhTien"))
                    {
                        dgvHoaDon.Columns["ThanhTien"].HeaderText = "Thành tiền";
                        dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "#,##0";
                    }
                }
                // Tính tổng số hóa đơn và tổng doanh thu
                int totalCount = list?.Count ?? 0;
                decimal totalRevenue = list?.Sum(hd => hd.ThanhTien) ?? 0m;
                lblTong.Text = $"Số hóa đơn: {totalCount} | Tổng doanh thu: {totalRevenue:#,##0} đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message);
            }
        }

        /// <summary>
        /// Xử lý sự kiện nhấn vào tiêu đề cột để sắp xếp danh sách hóa đơn.
        /// </summary>
        private void dgvHoaDon_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvHoaDon.Columns.Count == 0) return;
            string colName = dgvHoaDon.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(colName)) colName = dgvHoaDon.Columns[e.ColumnIndex].Name;
            if (string.IsNullOrEmpty(colName)) return;
            bool ascending = true;
            if (sortDirections.ContainsKey(colName)) ascending = !sortDirections[colName];
            sortDirections[colName] = ascending;
            // Nếu DataSource là List<HoaDonDTO>
            if (dgvHoaDon.DataSource is List<PhoManager.DTO.HoaDonDTO> list)
            {
                var prop = typeof(PhoManager.DTO.HoaDonDTO).GetProperty(colName);
                if (prop == null) return;
                IEnumerable<PhoManager.DTO.HoaDonDTO> sorted = ascending
                    ? list.OrderBy(item => prop.GetValue(item, null))
                    : list.OrderByDescending(item => prop.GetValue(item, null));
                dgvHoaDon.DataSource = sorted.ToList();
                return;
            }
            // Nếu DataSource là DataTable
            if (dgvHoaDon.DataSource is System.Data.DataTable dt)
            {
                var dv = dt.DefaultView;
                dv.Sort = colName + (ascending ? " ASC" : " DESC");
                dgvHoaDon.DataSource = dv.ToTable();
                return;
            }
            // Nếu DataSource là DataView
            if (dgvHoaDon.DataSource is System.Data.DataView dv2)
            {
                dv2.Sort = colName + (ascending ? " ASC" : " DESC");
                dgvHoaDon.DataSource = dv2.ToTable();
                return;
            }
            // Nếu DataSource là IList
            if (dgvHoaDon.DataSource is System.Collections.IList genericList && genericList.Count > 0)
            {
                var elementType = genericList[0].GetType();
                var prop = elementType.GetProperty(colName);
                if (prop == null) return;
                var sorted = ascending ? genericList.Cast<object>().OrderBy(item => prop.GetValue(item, null))
                                        : genericList.Cast<object>().OrderByDescending(item => prop.GetValue(item, null));
                var listType = typeof(System.Collections.Generic.List<>).MakeGenericType(elementType);
                var newList = (System.Collections.IList)Activator.CreateInstance(listType);
                foreach (var obj in sorted) newList.Add(obj);
                dgvHoaDon.DataSource = newList;
            }
        }

        /// <summary>
        /// Xuất hóa đơn được chọn ra file văn bản (CSV). Người dùng sẽ được hỏi nơi lưu file.
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHoaDon.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn cần xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Lấy mã hóa đơn từ dòng được chọn
                int maHD = GetSelectedInvoiceId();
                if (maHD <= 0)
                {
                    MessageBox.Show("Không thể xác định mã hóa đơn được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Lấy đầy đủ thông tin hóa đơn (bao gồm chi tiết)
                HoaDonDTO hoaDon = hoaDonBLL.LayHoaDonTheoMa(maHD);
                if (hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    sfd.FileName = $"HoaDon_{maHD}.csv";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportInvoiceToFile(hoaDon, sfd.FileName);
                        MessageBox.Show("Xuất hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xuất hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ghi nội dung hóa đơn ra file văn bản hoặc CSV. Mỗi mục chi tiết sẽ nằm trên một dòng.
        /// </summary>
        /// <param name="hoaDon">Hóa đơn cần xuất.</param>
        /// <param name="filePath">Đường dẫn file lưu.</param>
        private void ExportInvoiceToFile(HoaDonDTO hoaDon, string filePath)
        {
            using (var writer = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine($"Hóa đơn: {hoaDon.MaHD}");
                writer.WriteLine($"Ngày lập: {hoaDon.NgayLap:dd/MM/yyyy HH:mm:ss}");
                writer.WriteLine($"Bàn: {hoaDon.TenBan}");
                writer.WriteLine($"Nhân viên: {hoaDon.TenNhanVien}");
                writer.WriteLine();
                writer.WriteLine("Tên món, Số lượng, Đơn giá, Thành tiền");
                foreach (var ct in hoaDon.ChiTietHoaDon)
                {
                    writer.WriteLine($"{ct.TenMon}, {ct.SoLuong}, {ct.DonGia:#,##0}, {ct.ThanhTien:#,##0}");
                }
                writer.WriteLine();
                writer.WriteLine($"Tổng tiền: {hoaDon.TongTien:#,##0}");
                writer.WriteLine($"Giảm giá: {hoaDon.GiamGia:#,##0}");
                writer.WriteLine($"Thuế (%): {hoaDon.Thue:#,##0}");
                writer.WriteLine($"Thành tiền: {hoaDon.ThanhTien:#,##0}");
            }
        }

        /// <summary>
        /// Xử lý in hóa đơn. Sẽ hiển thị hộp thoại xem trước trước khi in thực tế.
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHoaDon.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn cần in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int maHD = GetSelectedInvoiceId();
                if (maHD <= 0)
                {
                    MessageBox.Show("Không thể xác định mã hóa đơn được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                HoaDonDTO hoaDon = hoaDonBLL.LayHoaDonTheoMa(maHD);
                if (hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Gán hóa đơn cho trường invoiceToPrint để dùng trong sự kiện PrintPage
                invoiceToPrint = hoaDon;
                using (PrintPreviewDialog previewDialog = new PrintPreviewDialog())
                {
                    previewDialog.Document = printDocument;
                    previewDialog.WindowState = FormWindowState.Maximized;
                    previewDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi in hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hàm vẽ nội dung hóa đơn lên trang in. Được gọi tự động khi PrintDocument in.
        /// </summary>
        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (invoiceToPrint == null)
            {
                e.Cancel = true;
                return;
            }
            // Thiết lập font cho in
            Font headerFont = new Font("Segoe UI", 14, FontStyle.Bold);
            Font subHeaderFont = new Font("Segoe UI", 10, FontStyle.Regular);
            Font tableHeaderFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font tableFont = new Font("Segoe UI", 10);
            float yPos = 20;
            float leftMargin = e.MarginBounds.Left;

            // In tiêu đề hóa đơn
            e.Graphics.DrawString($"HÓA ĐƠN MUA HÀNG", headerFont, Brushes.Black, leftMargin, yPos);
            yPos += headerFont.GetHeight(e.Graphics) + 10;
            e.Graphics.DrawString($"Mã hóa đơn: {invoiceToPrint.MaHD}", subHeaderFont, Brushes.Black, leftMargin, yPos);
            yPos += subHeaderFont.GetHeight(e.Graphics) + 2;
            e.Graphics.DrawString($"Ngày lập: {invoiceToPrint.NgayLap:dd/MM/yyyy HH:mm}", subHeaderFont, Brushes.Black, leftMargin, yPos);
            yPos += subHeaderFont.GetHeight(e.Graphics) + 2;
            e.Graphics.DrawString($"Bàn: {invoiceToPrint.TenBan}", subHeaderFont, Brushes.Black, leftMargin, yPos);
            yPos += subHeaderFont.GetHeight(e.Graphics) + 2;
            e.Graphics.DrawString($"Nhân viên: {invoiceToPrint.TenNhanVien}", subHeaderFont, Brushes.Black, leftMargin, yPos);
            yPos += subHeaderFont.GetHeight(e.Graphics) + 10;

            // In tiêu đề bảng chi tiết
            float col1Width = 200; // tên món
            float col2Width = 80;  // số lượng
            float col3Width = 100; // đơn giá
            float col4Width = 120; // thành tiền
            e.Graphics.DrawString("Tên món", tableHeaderFont, Brushes.Black, leftMargin, yPos);
            e.Graphics.DrawString("Số lượng", tableHeaderFont, Brushes.Black, leftMargin + col1Width, yPos);
            e.Graphics.DrawString("Đơn giá", tableHeaderFont, Brushes.Black, leftMargin + col1Width + col2Width, yPos);
            e.Graphics.DrawString("Thành tiền", tableHeaderFont, Brushes.Black, leftMargin + col1Width + col2Width + col3Width, yPos);
            yPos += tableHeaderFont.GetHeight(e.Graphics) + 4;

            // In chi tiết từng món
            foreach (var ct in invoiceToPrint.ChiTietHoaDon)
            {
                e.Graphics.DrawString(ct.TenMon, tableFont, Brushes.Black, leftMargin, yPos);
                e.Graphics.DrawString(ct.SoLuong.ToString(), tableFont, Brushes.Black, leftMargin + col1Width, yPos);
                e.Graphics.DrawString(ct.DonGia.ToString("#,##0"), tableFont, Brushes.Black, leftMargin + col1Width + col2Width, yPos);
                e.Graphics.DrawString(ct.ThanhTien.ToString("#,##0"), tableFont, Brushes.Black, leftMargin + col1Width + col2Width + col3Width, yPos);
                yPos += tableFont.GetHeight(e.Graphics) + 2;
            }
            yPos += 10;
            // In tổng kết
            e.Graphics.DrawString($"Tổng tiền: {invoiceToPrint.TongTien:#,##0}", tableHeaderFont, Brushes.Black, leftMargin, yPos);
            yPos += tableHeaderFont.GetHeight(e.Graphics) + 2;
            e.Graphics.DrawString($"Giảm giá: {invoiceToPrint.GiamGia:#,##0}", tableHeaderFont, Brushes.Black, leftMargin, yPos);
            yPos += tableHeaderFont.GetHeight(e.Graphics) + 2;
            e.Graphics.DrawString($"Thuế (%): {invoiceToPrint.Thue:#,##0}", tableHeaderFont, Brushes.Black, leftMargin, yPos);
            yPos += tableHeaderFont.GetHeight(e.Graphics) + 2;
            e.Graphics.DrawString($"Thành tiền: {invoiceToPrint.ThanhTien:#,##0}", tableHeaderFont, Brushes.Black, leftMargin, yPos);

            // Không cần trang in tiếp theo
            e.HasMorePages = false;
        }

        /// <summary>
        /// Trích xuất mã hóa đơn từ dòng được chọn trong DataGridView. Hỗ trợ các nguồn dữ liệu khác nhau.
        /// </summary>
        /// <returns>Mã hóa đơn hoặc 0 nếu không xác định được.</returns>
        private int GetSelectedInvoiceId()
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
                return 0;
            var row = dgvHoaDon.SelectedRows[0];
            // Nếu DataBoundItem là HoaDonDTO
            if (row.DataBoundItem is HoaDonDTO dto)
            {
                return dto.MaHD;
            }
            // Nếu là DataRowView
            if (row.DataBoundItem is System.Data.DataRowView drv)
            {
                try
                {
                    return Convert.ToInt32(drv["MaHD"]);
                }
                catch { return 0; }
            }
            // Nếu trực tiếp trong row.Cells
            try
            {
                return Convert.ToInt32(row.Cells["MaHD"].Value);
            }
            catch
            {
                return 0;
            }
        }
    }
}