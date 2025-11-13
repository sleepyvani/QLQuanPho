using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.DTO;

namespace PhoManager.UI.Forms
{
    /// <summary>
    /// Báo cáo danh sách hóa đơn trong một khoảng thời gian.
    /// Hiển thị danh sách hóa đơn và tổng số hóa đơn, tổng doanh thu.
    /// </summary>
    public partial class FrmBaoCaoHoaDon : Form
    {
        private readonly HoaDonBLL hoaDonBLL = new HoaDonBLL();
        private DataGridView dgvHoaDon;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnXem;
        private Label lblTong;
        private TableLayoutPanel layout;
        private Panel panelFilter;
        private Label lblTu;
        private Label lblDen;

        // Từ điển lưu trạng thái sắp xếp cho từng cột
        private readonly System.Collections.Generic.Dictionary<string, bool> sortDirections = new System.Collections.Generic.Dictionary<string, bool>();

        public FrmBaoCaoHoaDon()
        {
            InitializeComponent();

            // Đăng ký sự kiện sắp xếp cho DataGridView nếu đã khởi tạo
            if (this.dgvHoaDon != null)
            {
                this.dgvHoaDon.ColumnHeaderMouseClick += dgvHoaDon_ColumnHeaderMouseClick;
            }
        }

        private void InitializeComponent()
        {
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblTu = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDen = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.lblTong = new System.Windows.Forms.Label();
            this.layout.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layout.Controls.Add(this.panelFilter, 0, 0);
            this.layout.Controls.Add(this.dgvHoaDon, 0, 1);
            this.layout.Controls.Add(this.lblTong, 0, 2);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Name = "layout";
            this.layout.RowCount = 3;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.layout.Size = new System.Drawing.Size(782, 453);
            this.layout.TabIndex = 0;
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.lblTu);
            this.panelFilter.Controls.Add(this.dtpTuNgay);
            this.panelFilter.Controls.Add(this.lblDen);
            this.panelFilter.Controls.Add(this.dtpDenNgay);
            this.panelFilter.Controls.Add(this.btnXem);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilter.Location = new System.Drawing.Point(3, 3);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(776, 74);
            this.panelFilter.TabIndex = 0;
            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.Location = new System.Drawing.Point(10, 12);
            this.lblTu.Name = "lblTu";
            this.lblTu.Size = new System.Drawing.Size(59, 16);
            this.lblTu.TabIndex = 0;
            this.lblTu.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(70, 10);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(120, 22);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Location = new System.Drawing.Point(200, 12);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(67, 16);
            this.lblDen.TabIndex = 2;
            this.lblDen.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(270, 10);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(120, 22);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(420, 8);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(120, 30);
            this.btnXem.TabIndex = 4;
            this.btnXem.Text = "Xem báo cáo";
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.ColumnHeadersHeight = 29;
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.Location = new System.Drawing.Point(3, 83);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(776, 327);
            this.dgvHoaDon.TabIndex = 1;
            // 
            // lblTong
            // 
            this.lblTong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(96)))), ((int)(((byte)(67)))));
            this.lblTong.Location = new System.Drawing.Point(3, 413);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(776, 40);
            this.lblTong.TabIndex = 2;
            this.lblTong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmBaoCaoHoaDon
            // 
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.layout);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FrmBaoCaoHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo Hóa đơn";
            this.layout.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

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
    }
}