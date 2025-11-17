# 📊 HƯỚNG DẪN CHI TIẾT TẠO BÁO CÁO RDLC

## 🚀 BƯỚC 1: CÀI ĐẶT REPORTVIEWER

### Cách 1: NuGet Package (Dễ nhất)

1. **Right-click vào Solution** → **Manage NuGet Packages for Solution**
2. Tìm: `Microsoft.ReportViewer.WinForms`
3. Chọn version: **15.0.0** (tương thích .NET Framework 4.8)
4. Click **Install**

### Cách 2: Download và cài thủ công

1. Tải **Microsoft Report Viewer 2015 Runtime** từ Microsoft
2. Cài đặt trên máy
3. Thêm Reference vào project

---

## 📝 BƯỚC 2: TẠO FILE .RDLC

### 2.1. Tạo Report mới

1. **Right-click vào project** → **Add** → **New Item**
2. Tìm **"Report"** hoặc **"RDLC Report"**
3. Đặt tên: `RptHoaDon.rdlc`
4. Click **Add**

**LƯU Ý**: Nếu không thấy template "Report", cần cài **Microsoft RDLC Report Designer** extension trong Visual Studio.

### 2.2. Thiết kế Report Layout

#### A. Thiết lập kích thước Report

1. **Right-click vào Report** → **Report Properties**
2. Tab **Page Setup**:
   - **Paper size**: A4 (21cm x 29.7cm)
   - **Margins**: 1cm (tất cả các cạnh)

#### B. Thêm Data Source

1. Mở **Report Data** panel (View → Report Data, hoặc Ctrl+Alt+D)
2. **Right-click Data Sources** → **Add Data Source**
3. Chọn **Object** → Next
4. Browse và chọn class: `PhoManager.DTO.HoaDonDTO`
5. Click **Finish**

#### C. Tạo Dataset

1. **Right-click Datasets** → **Add Dataset**
2. Chọn Data Source vừa tạo
3. Chọn các fields cần hiển thị:
   - MaHD
   - NgayLap
   - TenBan (từ BanAn)
   - TenNhanVien (từ NhanVien)
   - TongTien
   - ThanhTien
   - TrangThai
4. Đặt tên Dataset: `dsHoaDon`
5. Click **OK**

#### D. Thiết kế Layout

**1. Thêm Header (Tiêu đề báo cáo):**

- Kéo **Textbox** vào phần Header
- Đặt text: `"PHO MANAGER - BÁO CÁO HÓA ĐƠN"`
- Format: Font size 16, Bold, Center

**2. Thêm Table để hiển thị dữ liệu:**

- Kéo **Table** từ Toolbox vào Body
- Table sẽ có 3 rows: Header, Detail, Footer
- Kéo các field từ Dataset vào các cột:
  - Cột 1: `MaHD` (Header: "Mã HD")
  - Cột 2: `NgayLap` (Header: "Ngày lập")
  - Cột 3: `TenBan` (Header: "Bàn")
  - Cột 4: `TenNhanVien` (Header: "Nhân viên")
  - Cột 5: `TongTien` (Header: "Tổng tiền")
  - Cột 6: `ThanhTien` (Header: "Thành tiền")
  - Cột 7: `TrangThai` (Header: "Trạng thái")

**3. Format các cột:**

- **Số tiền**: Right-click cell → Expression → `=Format(Fields!TongTien.Value, "N0") & " VND"`
- **Ngày tháng**: Right-click cell → Expression → `=Format(Fields!NgayLap.Value, "dd/MM/yyyy")`

**4. Thêm Footer (Tổng hợp):**

- Thêm row Footer vào Table
- Merge các cột đầu
- Cột cuối: `=Sum(Fields!ThanhTien.Value)` → Format: `=Format(Sum(Fields!ThanhTien.Value), "N0") & " VND"`

---

## 💻 BƯỚC 3: TẠO FORM HIỂN THỊ REPORT

### 3.1. Tạo Form mới

1. **Add** → **Windows Form**: `FrmBaoCaoHoaDonRDLC.cs`

### 3.2. Thêm ReportViewer Control

1. Mở form trong **Design mode**
2. Từ **Toolbox**, tìm **ReportViewer** (trong phần Reporting)
3. Kéo vào form
4. Set **Dock = Fill**

### 3.3. Code Load Report

```csharp
using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PhoManager.BLL;
using PhoManager.DTO;

namespace PhoManager.UI.Forms
{
    public partial class FrmBaoCaoHoaDonRDLC : Form
    {
        private readonly HoaDonBLL hoaDonBLL = new HoaDonBLL();
        private DateTime tuNgay;
        private DateTime denNgay;

        public FrmBaoCaoHoaDonRDLC(DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
        }

        private void FrmBaoCaoHoaDonRDLC_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                // Lấy dữ liệu
                var danhSachHoaDon = hoaDonBLL.LayDanhSachHoaDonTheoKhoangThoiGian(tuNgay, denNgay);

                // Tạo DataSource - TÊN PHẢI KHỚP VỚI TÊN DATASET TRONG .RDLC
                ReportDataSource reportDataSource = new ReportDataSource("dsHoaDon", danhSachHoaDon);

                // Clear và add data source
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                // Set path to .rdlc file
                // Cách 1: Đường dẫn tương đối (file phải được copy vào bin)
                reportViewer1.LocalReport.ReportPath = @"Reports\RptHoaDon.rdlc";

                // Cách 2: Đường dẫn tuyệt đối
                // reportViewer1.LocalReport.ReportPath = @"C:\Path\To\RptHoaDon.rdlc";

                // Cách 3: Embed Resource (khuyến nghị)
                // reportViewer1.LocalReport.ReportEmbeddedResource = "PhoManager.UI.Reports.RptHoaDon.rdlc";

                // Thêm Parameters (nếu có)
                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("TuNgay", tuNgay.ToString("dd/MM/yyyy"));
                parameters[1] = new ReportParameter("DenNgay", denNgay.ToString("dd/MM/yyyy"));
                reportViewer1.LocalReport.SetParameters(parameters);

                // Refresh report
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
```

---

## ⚙️ BƯỚC 4: CẤU HÌNH PROJECT

### 4.1. Tạo thư mục Reports

1. Tạo thư mục `Reports` trong project
2. Đặt file `.rdlc` vào đó

### 4.2. Cấu hình Build Action

1. **Right-click file .rdlc** → **Properties**
2. **Build Action**: `Content`
3. **Copy to Output Directory**: `Copy always`

### 4.3. Thêm Reference ReportViewer

1. **Right-click References** → **Add Reference**
2. Tìm và thêm:
   - `Microsoft.ReportViewer.WinForms`
   - `Microsoft.ReportViewer.Common`
   - `Microsoft.ReportViewer.ProcessingObjectModel`

---

## 📋 VÍ DỤ: BÁO CÁO HÓA ĐƠN CHI TIẾT

### Dataset Structure cho Hóa đơn chi tiết:

```csharp
// Tạo class DTO cho báo cáo
public class HoaDonBaoCaoDTO
{
    public int MaHD { get; set; }
    public DateTime NgayLap { get; set; }
    public string TenBan { get; set; }
    public string TenNhanVien { get; set; }
    public decimal TongTien { get; set; }
    public decimal GiamGia { get; set; }
    public decimal Thue { get; set; }
    public decimal ThanhTien { get; set; }
    public string TrangThai { get; set; }
    public List<ChiTietHoaDonBaoCaoDTO> ChiTiet { get; set; }
}

public class ChiTietHoaDonBaoCaoDTO
{
    public string TenMon { get; set; }
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public string KichCo { get; set; }
    public decimal ThanhTien { get; set; }
}
```

### Report Layout mẫu:

```
┌─────────────────────────────────────────────────────┐
│  PHO MANAGER                                        │
│  BÁO CÁO HÓA ĐƠN                                    │
│  Từ ngày: [TuNgay]  Đến ngày: [DenNgay]            │
├─────────────────────────────────────────────────────┤
│  ┌──────┬──────────┬──────┬──────────┬────────────┐ │
│  │Mã HD │ Ngày    │ Bàn  │ Nhân viên│ Thành tiền │ │
│  ├──────┼──────────┼──────┼──────────┼────────────┤ │
│  │[MaHD]│[NgayLap]│[Ban] │[NhanVien]│[ThanhTien] │ │
│  └──────┴──────────┴──────┴──────────┴────────────┘ │
├─────────────────────────────────────────────────────┤
│  Tổng số hóa đơn: [Count]                           │
│  Tổng doanh thu: [Sum(ThanhTien)]                   │
└─────────────────────────────────────────────────────┘
```

---

## 🎨 CÁC EXPRESSION THƯỜNG DÙNG

### Format số tiền:
```
=Format(Fields!TongTien.Value, "N0") & " VND"
```

### Format ngày tháng:
```
=Format(Fields!NgayLap.Value, "dd/MM/yyyy")
=Format(Fields!NgayLap.Value, "dd/MM/yyyy HH:mm")
```

### Tính tổng:
```
=Sum(Fields!ThanhTien.Value)
=Count(Fields!MaHD.Value)
=Avg(Fields!TongTien.Value)
```

### Điều kiện:
```
=IIf(Fields!TrangThai.Value = "Đã thanh toán", "Xanh", "Đỏ")
=IIf(Fields!TongTien.Value > 100000, "Cao", "Thấp")
```

### Tổng hợp theo nhóm:
```
=Sum(Fields!ThanhTien.Value, "GroupName")
```

---

## 🔧 XỬ LÝ LỖI THƯỜNG GẶP

### Lỗi 1: "Cannot find report file"

**Nguyên nhân**: Đường dẫn đến file .rdlc không đúng

**Giải pháp**:
- Kiểm tra file .rdlc có trong thư mục bin/Reports không
- Hoặc dùng đường dẫn tuyệt đối
- Hoặc embed resource

### Lỗi 2: "Data source name does not exist"

**Nguyên nhân**: Tên DataSource trong code không khớp với Dataset trong .rdlc

**Giải pháp**:
- Kiểm tra tên Dataset trong .rdlc (Report Data → Datasets)
- Đảm bảo tên trong code: `new ReportDataSource("dsHoaDon", data)`

### Lỗi 3: "ReportViewer control not found"

**Nguyên nhân**: Chưa cài ReportViewer hoặc chưa add reference

**Giải pháp**:
- Cài Microsoft.ReportViewer.WinForms từ NuGet
- Add reference thủ công

---

## 📦 CẤU TRÚC THƯ MỤC ĐỀ XUẤT

```
QLQuanPho/
├── Reports/                    (Thư mục chứa file .rdlc)
│   ├── RptHoaDon.rdlc
│   ├── RptDoanhThu.rdlc
│   ├── RptMonBanChay.rdlc
│   └── RptNguyenLieu.rdlc
├── PhoManager.UI/
│   └── Forms/
│       ├── FrmBaoCaoHoaDonRDLC.cs
│       └── FrmBaoCaoDoanhThuRDLC.cs
└── bin/
    └── Release/
        └── Reports/            (File .rdlc được copy vào đây)
            └── RptHoaDon.rdlc
```

---

## ✅ CHECKLIST TẠO BÁO CÁO RDLC

- [ ] Cài đặt Microsoft.ReportViewer.WinForms
- [ ] Tạo thư mục Reports trong project
- [ ] Tạo file .rdlc mới
- [ ] Thiết lập kích thước và margins
- [ ] Thêm Data Source (Object)
- [ ] Tạo Dataset với các fields cần thiết
- [ ] Thiết kế layout (Header, Table, Footer)
- [ ] Format các cột (số tiền, ngày tháng)
- [ ] Tạo Form mới với ReportViewer control
- [ ] Code load data và bind vào ReportViewer
- [ ] Set Build Action = Content cho file .rdlc
- [ ] Set Copy to Output Directory = Copy always
- [ ] Test với dữ liệu mẫu
- [ ] Test export PDF/Excel

---

## 🎯 VÍ DỤ HOÀN CHỈNH: Báo cáo Doanh thu

Tôi sẽ tạo một ví dụ hoàn chỉnh trong file tiếp theo...

