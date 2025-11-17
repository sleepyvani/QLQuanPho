# 🚀 HƯỚNG DẪN NHANH TẠO BÁO CÁO RDLC

## ⚡ BƯỚC NHANH (5 phút)

### 1. Cài đặt ReportViewer (2 phút)

**Cách 1: NuGet (Khuyên dùng)**
```
Tools → NuGet Package Manager → Package Manager Console
Install-Package Microsoft.ReportViewer.WinForms -Version 15.0.0
```

**Cách 2: Visual Studio Installer**
- Mở Visual Studio Installer
- Modify → Individual components
- Tìm và check: **Microsoft RDLC Report Designer**
- Install

### 2. Tạo file .rdlc (2 phút)

1. **Right-click project** → **Add** → **New Item**
2. Tìm **"Report"** → Đặt tên: `RptHoaDon.rdlc`
3. **Right-click Report** → **Report Properties** → Page size: A4

### 3. Thêm Data Source (1 phút)

1. Mở **Report Data** (Ctrl+Alt+D)
2. **Right-click Data Sources** → **Add Data Source**
3. Chọn **Object** → Browse → Chọn `PhoManager.DTO.HoaDonDTO`
4. **Right-click Datasets** → **Add Dataset**
5. Chọn tất cả fields → Đặt tên: `dsHoaDon`

### 4. Thiết kế Report (5 phút)

1. Kéo **Table** từ Toolbox vào Report
2. Kéo các field vào các cột:
   - MaHD, NgayLap, TenBan, TenNhanVien, TongTien, ThanhTien
3. Format:
   - Ngày: Right-click → Expression → `=Format(Fields!NgayLap.Value, "dd/MM/yyyy")`
   - Tiền: `=Format(Fields!TongTien.Value, "N0") & " VND"`

### 5. Tạo Form hiển thị (2 phút)

1. Form đã được tạo sẵn: `FrmBaoCaoHoaDonRDLC.cs`
2. Chỉ cần:
   - Cài ReportViewer từ NuGet
   - Tạo file .rdlc
   - Update path trong code

---

## 📋 CHECKLIST

- [ ] Cài Microsoft.ReportViewer.WinForms (NuGet)
- [ ] Cài Microsoft RDLC Report Designer (Visual Studio Installer)
- [ ] Tạo thư mục `Reports` trong project
- [ ] Tạo file `RptHoaDon.rdlc`
- [ ] Thêm Data Source: HoaDonDTO
- [ ] Tạo Dataset: dsHoaDon
- [ ] Thiết kế layout với Table
- [ ] Format các cột (ngày, tiền)
- [ ] Set Build Action = Content cho .rdlc
- [ ] Set Copy to Output = Copy always
- [ ] Test form `FrmBaoCaoHoaDonRDLC`

---

## 🔗 GỌI FORM TỪ FORM KHÁC

```csharp
// Trong FrmBaoCaoHoaDon.cs hoặc form khác
private void btnXemBaoCaoRDLC_Click(object sender, EventArgs e)
{
    DateTime tuNgay = dateTimePicker1.Value;
    DateTime denNgay = dateTimePicker2.Value;
    
    using (var frm = new FrmBaoCaoHoaDonRDLC(tuNgay, denNgay))
    {
        frm.ShowDialog();
    }
}
```

---

## ⚠️ LƯU Ý QUAN TRỌNG

1. **Tên Dataset**: Phải khớp giữa code và .rdlc file
2. **Path**: File .rdlc phải được copy vào bin/Reports
3. **Reference**: Phải có Microsoft.ReportViewer.WinForms

---

Xem file `HUONG_DAN_RDLC_CHI_TIET.md` để biết chi tiết hơn!

