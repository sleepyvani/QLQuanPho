# 📊 HƯỚNG DẪN TẠO BÁO CÁO RDLC TRONG WINFORMS

## 🎯 Tổng quan

RDLC (Report Definition Language Client-side) là công nghệ báo cáo của Microsoft cho WinForms. Báo cáo được thiết kế bằng Visual Studio Report Designer và hiển thị bằng ReportViewer control.

---

## 📦 Bước 1: Cài đặt ReportViewer

### Cách 1: Sử dụng NuGet Package (KHUYẾN NGHỊ)

1. **Right-click vào project** → **Manage NuGet Packages**
2. Tìm và cài đặt: **Microsoft.ReportViewer.WinForms**
3. Hoặc chạy lệnh trong Package Manager Console:
   ```
   Install-Package Microsoft.ReportViewer.WinForms
   ```

### Cách 2: Thêm Reference thủ công

1. **Right-click References** → **Add Reference**
2. Tìm và thêm:
   - `Microsoft.ReportViewer.WinForms`
   - `Microsoft.ReportViewer.Common`
   - `Microsoft.ReportViewer.ProcessingObjectModel`

---

## 📝 Bước 2: Tạo Report (.rdlc file)

### 2.1. Tạo file RDLC

1. **Right-click vào project** → **Add** → **New Item**
2. Chọn **Report** (hoặc tìm "RDLC Report")
3. Đặt tên: `RptHoaDon.rdlc` (ví dụ)
4. Click **Add**

### 2.2. Thiết kế Report

1. **Mở file .rdlc** trong Visual Studio
2. **Right-click vào Report** → **Report Properties**:
   - Đặt kích thước: A4 (21cm x 29.7cm)
   - Margins: 1cm mỗi bên

3. **Thêm Data Source**:
   - Right-click vào **Report Data** (bên trái) → **Add Data Source**
   - Chọn **Object** → Next
   - Browse và chọn class DTO của bạn (ví dụ: `HoaDonDTO`)
   - Finish

4. **Thêm Dataset**:
   - Right-click **Datasets** → **Add Dataset**
   - Chọn Data Source vừa tạo
   - Chọn các fields cần hiển thị
   - Đặt tên Dataset: `dsHoaDon`

5. **Thiết kế Layout**:
   - **Kéo thả các controls** từ Toolbox:
     - **Textbox**: Hiển thị text, số
     - **Table**: Hiển thị dữ liệu dạng bảng
     - **Image**: Hiển thị hình ảnh
     - **Rectangle**: Vẽ khung
     - **Line**: Vẽ đường kẻ

6. **Thêm Table để hiển thị dữ liệu**:
   - Kéo **Table** từ Toolbox vào Report
   - Kéo các field từ Dataset vào các cột
   - Format: Font, màu sắc, căn lề

---

## 💻 Bước 3: Tạo Form hiển thị Report

### 3.1. Tạo Form mới

1. **Add** → **Windows Form**: `FrmBaoCaoHoaDonRDLC.cs`

### 3.2. Thêm ReportViewer Control

1. Mở form trong Design mode
2. Từ **Toolbox**, kéo **ReportViewer** vào form
3. Đặt tên: `reportViewer1`
4. Set **Dock = Fill**

### 3.3. Code để load Report

```csharp
using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PhoManager.BLL;
using System.Collections.Generic;

namespace PhoManager.UI.Forms
{
    public partial class FrmBaoCaoHoaDonRDLC : Form
    {
        public FrmBaoCaoHoaDonRDLC()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoHoaDonRDLC_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                // Lấy dữ liệu từ BLL
                var hoaDonBLL = new HoaDonBLL();
                var danhSachHoaDon = hoaDonBLL.LayDanhSachHoaDon(); // Hoặc method lấy dữ liệu của bạn

                // Tạo DataSource cho Report
                ReportDataSource reportDataSource = new ReportDataSource("dsHoaDon", danhSachHoaDon);
                
                // Clear existing data sources
                reportViewer1.LocalReport.DataSources.Clear();
                
                // Add data source
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                
                // Set path to .rdlc file
                reportViewer1.LocalReport.ReportPath = @"Reports\RptHoaDon.rdlc";
                
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

## 🔧 Bước 4: Cấu hình Project

### 4.1. Copy .rdlc file vào Output Directory

1. **Right-click vào file .rdlc** → **Properties**
2. Set **Build Action**: `Content`
3. Set **Copy to Output Directory**: `Copy always` hoặc `Copy if newer`

### 4.2. Tạo thư mục Reports

1. Tạo thư mục `Reports` trong project
2. Đặt file .rdlc vào đó
3. Update path trong code: `@"Reports\RptHoaDon.rdlc"`

---

## 📋 Ví dụ: Báo cáo Hóa đơn chi tiết

### Dataset Structure:
```
dsHoaDon
├── MaHD (int)
├── NgayLap (DateTime)
├── TenBan (string)
├── TenNhanVien (string)
├── TongTien (decimal)
├── ThanhTien (decimal)
└── ChiTietHoaDon (List)
    ├── TenMon (string)
    ├── SoLuong (int)
    ├── DonGia (decimal)
    └── ThanhTien (decimal)
```

### Report Layout:
```
┌─────────────────────────────────────┐
│  PHO MANAGER - BÁO CÁO HÓA ĐƠN      │
├─────────────────────────────────────┤
│  Mã HD: [MaHD]                      │
│  Ngày: [NgayLap]                    │
│  Bàn: [TenBan]                      │
│  Nhân viên: [TenNhanVien]           │
├─────────────────────────────────────┤
│  Chi tiết:                          │
│  ┌─────────┬──────┬────────┬──────┐│
│  │ Tên món │ SL   │ Đơn giá│ TT   ││
│  ├─────────┼──────┼────────┼──────┤│
│  │ [TenMon]│[SL]  │[DonGia]│[TT]  ││
│  └─────────┴──────┴────────┴──────┘│
├─────────────────────────────────────┤
│  Tổng tiền: [TongTien]              │
│  Thành tiền: [ThanhTien]            │
└─────────────────────────────────────┘
```

---

## 🎨 Các tính năng nâng cao

### 1. Tham số (Parameters)

```csharp
// Thêm parameter
ReportParameter[] parameters = new ReportParameter[2];
parameters[0] = new ReportParameter("TuNgay", dateTimePicker1.Value.ToString("dd/MM/yyyy"));
parameters[1] = new ReportParameter("DenNgay", dateTimePicker2.Value.ToString("dd/MM/yyyy"));

reportViewer1.LocalReport.SetParameters(parameters);
```

### 2. Subreport (Báo cáo con)

- Tạo report con riêng
- Trong report chính, thêm Subreport control
- Link subreport với report con

### 3. Grouping và Sorting

- Right-click vào Table → **Add Group**
- Chọn field để group
- Thêm Header/Footer cho group

### 4. Expressions (Biểu thức)

- Sử dụng Visual Basic expressions:
  - `=Sum(Fields!ThanhTien.Value)`
  - `=Format(Fields!NgayLap.Value, "dd/MM/yyyy")`
  - `=IIf(Fields!TongTien.Value > 100000, "Cao", "Thấp")`

### 5. Formatting

- **Số tiền**: `=Format(Fields!TongTien.Value, "N0") & " VND"`
- **Ngày tháng**: `=Format(Fields!NgayLap.Value, "dd/MM/yyyy")`
- **Phần trăm**: `=Format(Fields!Thue.Value, "0.00") & "%"`

---

## 📦 Cấu trúc thư mục đề xuất

```
QLQuanPho/
├── Reports/
│   ├── RptHoaDon.rdlc
│   ├── RptDoanhThu.rdlc
│   ├── RptMonBanChay.rdlc
│   └── RptNguyenLieu.rdlc
├── PhoManager.UI/
│   └── Forms/
│       ├── FrmBaoCaoHoaDonRDLC.cs
│       └── FrmBaoCaoDoanhThuRDLC.cs
```

---

## ⚠️ Lưu ý quan trọng

1. **ReportViewer Version**: Đảm bảo version tương thích với .NET Framework 4.8
2. **Path to .rdlc**: Sử dụng đường dẫn tương đối hoặc embed resource
3. **Data Source Name**: Tên trong code phải khớp với tên Dataset trong .rdlc
4. **Build Action**: File .rdlc phải được copy vào output directory

---

## 🔗 Tài liệu tham khảo

- Microsoft RDLC Documentation: https://docs.microsoft.com/en-us/sql/reporting-services/report-definition-language-ssrs
- ReportViewer Control: https://docs.microsoft.com/en-us/sql/reporting-services/application-integration/using-the-winforms-reportviewer-control

---

## 💡 Tips

1. **Test với dữ liệu mẫu** trước khi kết nối database
2. **Sử dụng Table** cho dữ liệu dạng bảng
3. **Group by** để tổng hợp dữ liệu
4. **Preview** thường xuyên khi thiết kế
5. **Export** sang PDF/Excel để test

