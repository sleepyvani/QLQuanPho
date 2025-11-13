using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.DTO;

namespace PhoManager.UI.Forms
{
    /// <summary>
    /// Form quản lý nguyên liệu/kho. Cho phép xem, thêm, sửa, xóa nguyên liệu.
    /// </summary>
    public partial class FrmNguyenLieu : Form
    {
        private readonly NguyenLieuBLL nguyenLieuBLL = new NguyenLieuBLL();
        private NguyenLieuDTO nguyenLieuDangChon;

        // Controls
        private SplitContainer splitContainer;
        private DataGridView dgvNguyenLieu;
        private TextBox txtTen;
        private TextBox txtDonVi;
        private NumericUpDown nudSoLuong;
        private TextBox txtGiaNhap;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblStatus;

        public FrmNguyenLieu()
        {
            InitializeComponent();
            LoadNguyenLieu();

            // Đăng ký sự kiện sắp xếp khi bấm vào tiêu đề cột
            this.dgvNguyenLieu.ColumnHeaderMouseClick += dgvNguyenLieu_ColumnHeaderMouseClick;
        }

        /// <summary>
        /// Khởi tạo giao diện.
        /// </summary>
        private void InitializeComponent()
        {
            this.Text = "Quản lý Nguyên liệu";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 450);

            splitContainer = new SplitContainer();
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Orientation = Orientation.Vertical;
            splitContainer.SplitterDistance = 500;
            this.Controls.Add(splitContainer);

            // DataGridView
            dgvNguyenLieu = new DataGridView();
            dgvNguyenLieu.Dock = DockStyle.Fill;
            dgvNguyenLieu.ReadOnly = true;
            dgvNguyenLieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNguyenLieu.AllowUserToAddRows = false;
            dgvNguyenLieu.AllowUserToDeleteRows = false;
            dgvNguyenLieu.AutoGenerateColumns = true;
            dgvNguyenLieu.CellClick += dgvNguyenLieu_CellClick;
            splitContainer.Panel1.Controls.Add(dgvNguyenLieu);

            // Panel for details
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Add(panel);

            int marginTop = 20;
            int labelWidth = 100;
            int controlWidth = 180;
            int leftX = 20;
            int secondX = leftX + labelWidth + 10;
            int rowHeight = 30;
            int currentY = marginTop;

            // Tên nguyên liệu
            Label lblTen = new Label();
            lblTen.Text = "Tên NL:";
            lblTen.Location = new Point(leftX, currentY + 5);
            lblTen.AutoSize = true;
            panel.Controls.Add(lblTen);
            txtTen = new TextBox();
            txtTen.Location = new Point(secondX, currentY);
            txtTen.Width = controlWidth;
            panel.Controls.Add(txtTen);
            currentY += rowHeight;

            // Đơn vị tính
            Label lblDonVi = new Label();
            lblDonVi.Text = "Đơn vị:";
            lblDonVi.Location = new Point(leftX, currentY + 5);
            lblDonVi.AutoSize = true;
            panel.Controls.Add(lblDonVi);
            txtDonVi = new TextBox();
            txtDonVi.Location = new Point(secondX, currentY);
            txtDonVi.Width = controlWidth;
            panel.Controls.Add(txtDonVi);
            currentY += rowHeight;

            // Số lượng tồn
            Label lblSoLuong = new Label();
            lblSoLuong.Text = "Số lượng:";
            lblSoLuong.Location = new Point(leftX, currentY + 5);
            lblSoLuong.AutoSize = true;
            panel.Controls.Add(lblSoLuong);
            nudSoLuong = new NumericUpDown();
            nudSoLuong.Location = new Point(secondX, currentY);
            nudSoLuong.Width = controlWidth;
            nudSoLuong.Minimum = 0;
            nudSoLuong.Maximum = 1000000;
            panel.Controls.Add(nudSoLuong);
            currentY += rowHeight;

            // Giá nhập
            Label lblGiaNhap = new Label();
            lblGiaNhap.Text = "Giá nhập:";
            lblGiaNhap.Location = new Point(leftX, currentY + 5);
            lblGiaNhap.AutoSize = true;
            panel.Controls.Add(lblGiaNhap);
            txtGiaNhap = new TextBox();
            txtGiaNhap.Location = new Point(secondX, currentY);
            txtGiaNhap.Width = controlWidth;
            panel.Controls.Add(txtGiaNhap);
            currentY += rowHeight + 10;

            // Buttons
            btnThem = new Button();
            btnThem.Text = "Thêm";
            btnThem.Width = 80;
            btnThem.Location = new Point(leftX, currentY);
            btnThem.Click += btnThem_Click;
            panel.Controls.Add(btnThem);

            btnSua = new Button();
            btnSua.Text = "Sửa";
            btnSua.Width = 80;
            btnSua.Location = new Point(leftX + 90, currentY);
            btnSua.Click += btnSua_Click;
            panel.Controls.Add(btnSua);

            btnXoa = new Button();
            btnXoa.Text = "Xóa";
            btnXoa.Width = 80;
            btnXoa.Location = new Point(leftX + 180, currentY);
            btnXoa.Click += btnXoa_Click;
            panel.Controls.Add(btnXoa);

            btnLamMoi = new Button();
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Width = 80;
            btnLamMoi.Location = new Point(leftX + 270, currentY);
            btnLamMoi.Click += btnLamMoi_Click;
            panel.Controls.Add(btnLamMoi);
            currentY += rowHeight + 10;

            lblStatus = new Label();
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.FromArgb(35, 96, 67);
            lblStatus.Location = new Point(leftX, currentY + 5);
            panel.Controls.Add(lblStatus);
        }

        /// <summary>
        /// Nạp danh sách nguyên liệu vào DataGridView.
        /// </summary>
        private void LoadNguyenLieu()
        {
            var list = nguyenLieuBLL.LayDanhSachNguyenLieu();
            dgvNguyenLieu.DataSource = list;
            // Ẩn những cột không cần hiển thị
            if (dgvNguyenLieu.Columns.Contains("MaNL"))
            {
                dgvNguyenLieu.Columns["MaNL"].Visible = false;
            }
            if (dgvNguyenLieu.Columns.Contains("NgayCapNhat"))
            {
                dgvNguyenLieu.Columns["NgayCapNhat"].HeaderText = "Cập nhật";
                dgvNguyenLieu.Columns["NgayCapNhat"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        // Từ điển lưu trạng thái sắp xếp cho từng cột
        private readonly System.Collections.Generic.Dictionary<string, bool> sortDirections = new System.Collections.Generic.Dictionary<string, bool>();

        /// <summary>
        /// Xử lý sự kiện nhấn vào tiêu đề cột để sắp xếp danh sách nguyên liệu.
        /// </summary>
        private void dgvNguyenLieu_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string propName = dgvNguyenLieu.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(propName))
            {
                propName = dgvNguyenLieu.Columns[e.ColumnIndex].Name;
            }
            if (string.IsNullOrEmpty(propName)) return;
            var list = dgvNguyenLieu.DataSource as System.Collections.Generic.List<PhoManager.DTO.NguyenLieuDTO>;
            if (list == null || list.Count == 0) return;
            bool ascending = true;
            if (sortDirections.ContainsKey(propName))
            {
                ascending = !sortDirections[propName];
            }
            sortDirections[propName] = ascending;

            var propInfo = typeof(PhoManager.DTO.NguyenLieuDTO).GetProperty(propName);
            if (propInfo == null) return;
            System.Collections.Generic.IEnumerable<PhoManager.DTO.NguyenLieuDTO> sorted;
            if (ascending)
            {
                sorted = list.OrderBy(item => propInfo.GetValue(item, null));
            }
            else
            {
                sorted = list.OrderByDescending(item => propInfo.GetValue(item, null));
            }
            var newList = new System.Collections.Generic.List<PhoManager.DTO.NguyenLieuDTO>(sorted);
            dgvNguyenLieu.DataSource = null;
            dgvNguyenLieu.DataSource = newList;
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNguyenLieu.Rows[e.RowIndex].DataBoundItem is NguyenLieuDTO item)
            {
                nguyenLieuDangChon = item;
                txtTen.Text = item.TenNL;
                txtDonVi.Text = item.DonViTinh;
                nudSoLuong.Value = (decimal)item.SoLuongTon;
                txtGiaNhap.Text = item.GiaNhap.HasValue ? item.GiaNhap.Value.ToString() : "";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NguyenLieuDTO nl = new NguyenLieuDTO();
            nl.TenNL = txtTen.Text.Trim();
            nl.DonViTinh = txtDonVi.Text.Trim();
            nl.SoLuongTon = (decimal)nudSoLuong.Value;
            if (decimal.TryParse(txtGiaNhap.Text.Trim(), out decimal gia))
            {
                nl.GiaNhap = gia;
            }
            else
            {
                nl.GiaNhap = null;
            }
            string result = nguyenLieuBLL.ThemNguyenLieu(nl);
            lblStatus.Text = result;
            LoadNguyenLieu();
            ClearForm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (nguyenLieuDangChon == null)
            {
                lblStatus.Text = "Vui lòng chọn nguyên liệu cần sửa.";
                return;
            }
            nguyenLieuDangChon.TenNL = txtTen.Text.Trim();
            nguyenLieuDangChon.DonViTinh = txtDonVi.Text.Trim();
            nguyenLieuDangChon.SoLuongTon = (decimal)nudSoLuong.Value;
            if (decimal.TryParse(txtGiaNhap.Text.Trim(), out decimal gia))
            {
                nguyenLieuDangChon.GiaNhap = gia;
            }
            else
            {
                nguyenLieuDangChon.GiaNhap = null;
            }
            string result = nguyenLieuBLL.CapNhatNguyenLieu(nguyenLieuDangChon);
            lblStatus.Text = result;
            LoadNguyenLieu();
            ClearForm();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (nguyenLieuDangChon == null)
            {
                lblStatus.Text = "Vui lòng chọn nguyên liệu cần xóa.";
                return;
            }
            if (MessageBox.Show($"Bạn có chắc muốn xóa '{nguyenLieuDangChon.TenNL}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string result = nguyenLieuBLL.XoaNguyenLieu(nguyenLieuDangChon.MaNL);
                lblStatus.Text = result;
                LoadNguyenLieu();
                ClearForm();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtTen.Clear();
            txtDonVi.Clear();
            nudSoLuong.Value = 0;
            txtGiaNhap.Clear();
            nguyenLieuDangChon = null;
        }
    }
}