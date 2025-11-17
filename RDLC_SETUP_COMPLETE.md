# ✅ HOÀN TẤT THIẾT LẬP RDLC REPORT

## 🎉 Đã hoàn thành

### ✅ Các file đã tạo:

1. **Reports/RptHoaDon.rdlc** - File báo cáo RDLC với layout đầy đủ
2. **PhoManager.UI/Forms/FrmBaoCaoHoaDonRDLC.cs** - Form hiển thị báo cáo
3. **PhoManager.UI/Forms/FrmBaoCaoHoaDonRDLC.Designer.cs** - Designer file
4. **QLQuanPho.csproj** - Đã cập nhật để include file .rdlc

### ✅ Các tính năng đã thêm:

1. **Nút "Xem báo cáo RDLC"** trong form `FrmBaoCaoHoaDon`
2. **Xử lý đường dẫn file** tự động tìm file .rdlc ở nhiều vị trí
3. **Báo cáo với đầy đủ thông tin**:
   - Mã hóa đơn
   - Ngày lập
   - Tên bàn
   - Tên nhân viên
   - Tổng tiền
   - Thành tiền
   - Trạng thái
   - Phương thức thanh toán
   - Tổng hợp cuối báo cáo

---

## 🚀 CÁCH SỬ DỤNG

### 1. Build Project

```
Build → Rebuild Solution
```

### 2. Chạy ứng dụng

1. Mở form **Báo cáo Hóa đơn** (từ menu hoặc nút trên main form)
2. Chọn khoảng thời gian (Từ ngày - Đến ngày)
3. Click nút **"Xem báo cáo RDLC"**
4. Báo cáo sẽ hiển thị trong form mới với ReportViewer

### 3. Export báo cáo

Trong ReportViewer, bạn có thể:
- **Export PDF**: Click nút Export → Chọn PDF
- **Export Excel**: Click nút Export → Chọn Excel
- **In**: Click nút Print
- **Zoom**: Sử dụng thanh zoom để phóng to/thu nhỏ

---

## 📋 CẤU TRÚC FILE

```
QLQuanPho/
├── Reports/
│   └── RptHoaDon.rdlc          ← File báo cáo (đã tạo)
├── PhoManager.UI/
│   └── Forms/
│       ├── FrmBaoCaoHoaDon.cs  ← Form báo cáo chính (đã thêm nút)
│       └── FrmBaoCaoHoaDonRDLC.cs  ← Form hiển thị RDLC (mới)
└── bin/
    └── Release/
        └── Reports/
            └── RptHoaDon.rdlc  ← Tự động copy khi build
```

---

## 🔧 TÙY CHỈNH BÁO CÁO

### Thay đổi layout:

1. **Mở file `Reports/RptHoaDon.rdlc`** trong Visual Studio
2. **Right-click vào Report** → **Report Properties** để thay đổi:
   - Kích thước trang
   - Margins
   - Orientation (Portrait/Landscape)

### Thêm/xóa cột:

1. Mở file .rdlc trong Visual Studio
2. Click vào **Table** trong report
3. **Right-click** → **Insert Column** hoặc **Delete Column**
4. Kéo field từ Dataset vào cột mới

### Thay đổi format:

- **Số tiền**: Right-click cell → Expression → `=Format(Fields!TongTien.Value, "N0") & " VND"`
- **Ngày tháng**: `=Format(Fields!NgayLap.Value, "dd/MM/yyyy")`
- **Màu sắc**: Right-click → Properties → BackgroundColor

---

## ⚠️ LƯU Ý

1. **File .rdlc phải được copy vào bin**: Đã cấu hình trong .csproj
2. **Dataset name**: Phải khớp giữa code (`dsHoaDon`) và file .rdlc
3. **Data Source**: Phải là `HoaDonDTO` hoặc class tương ứng
4. **ReportViewer**: Đã cài từ NuGet (Microsoft.ReportViewer.WinForms)

---

## 🐛 XỬ LÝ LỖI

### Lỗi: "Cannot find report file"

**Giải pháp**:
- Kiểm tra file `RptHoaDon.rdlc` có trong thư mục `bin/Release/Reports/` hoặc `bin/Debug/Reports/`
- Rebuild project để copy file

### Lỗi: "Data source name does not exist"

**Giải pháp**:
- Kiểm tra tên Dataset trong file .rdlc phải là `dsHoaDon`
- Kiểm tra tên trong code: `new ReportDataSource("dsHoaDon", data)`

### Lỗi: "ReportViewer control not found"

**Giải pháp**:
- Cài lại package: `Install-Package Microsoft.ReportViewer.WinForms`
- Kiểm tra Reference trong project

---

## 📚 TÀI LIỆU THAM KHẢO

- Xem file `HUONG_DAN_RDLC_CHI_TIET.md` để biết cách tạo báo cáo mới
- Xem file `RDLC_QUICK_START.md` để hướng dẫn nhanh

---

## ✨ TÍNH NĂNG NÂNG CAO (Có thể thêm sau)

1. **Subreport**: Báo cáo chi tiết hóa đơn với danh sách món ăn
2. **Grouping**: Nhóm theo ngày, theo nhân viên
3. **Charts**: Biểu đồ doanh thu
4. **Watermark**: Logo hoặc watermark trên báo cáo
5. **Multiple pages**: Header/Footer trên mỗi trang

---

**Chúc bạn sử dụng thành công! 🎉**

