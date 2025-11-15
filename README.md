# 🥢 HỆ THỐNG QUẢN LÝ QUÁN PHỞ

Ứng dụng quản lý quán phở được xây dựng bằng **WinForms C#** với kiến trúc **3-layer**, sử dụng **LINQ to SQL** để kết nối **SQL Server**.

## 📋 Mục lục

- [Yêu cầu hệ thống](#yêu-cầu-hệ-thống)
- [Hướng dẫn cài đặt và chạy ứng dụng](#hướng-dẫn-cài-đặt-và-chạy-ứng-dụng)
- [Cấu trúc dự án](#cấu-trúc-dự-án)
- [Tính năng](#tính-năng)
- [Hướng dẫn sử dụng](#hướng-dẫn-sử-dụng)
- [Xử lý lỗi thường gặp](#xử-lý-lỗi-thường-gặp)

## 🔧 Yêu cầu hệ thống

### Phần mềm cần thiết

1. **.NET Framework 4.8** 
   - Tải từ: https://dotnet.microsoft.com/download/dotnet-framework/net48
   - Hoặc cài đặt qua Visual Studio Installer

2. **SQL Server** (một trong các phiên bản sau):
   - SQL Server 2012 trở lên
   - SQL Server Express (miễn phí): https://www.microsoft.com/sql-server/sql-server-downloads
   - SQL Server LocalDB (kèm theo Visual Studio)

3. **SQL Server Management Studio (SSMS)**
   - Tải từ: https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms
   - Dùng để quản lý database

4. **Visual Studio 2017 trở lên**
   - Visual Studio Community (miễn phí): https://visualstudio.microsoft.com/
   - Đảm bảo cài đặt workload "Desktop development with .NET"

## 🚀 Hướng dẫn cài đặt và chạy ứng dụng

### Bước 1: Cài đặt SQL Server

#### Cách 1: Cài đặt SQL Server Express (Khuyên dùng)

1. Tải **SQL Server Express** từ trang chính thức Microsoft
2. Chạy file cài đặt và làm theo hướng dẫn
3. Trong quá trình cài đặt, chọn **"Mixed Mode Authentication"** (SQL Server Authentication + Windows Authentication)
4. Đặt mật khẩu cho tài khoản `sa` (hoặc ghi nhớ mật khẩu nếu bạn đã đặt)
5. Hoàn tất cài đặt

#### Cách 2: Sử dụng SQL Server LocalDB (Có sẵn với Visual Studio)

1. LocalDB được cài đặt tự động khi cài Visual Studio với workload .NET Desktop
2. Tên instance mặc định: `(localdb)\MSSQLLocalDB`
3. Không cần cài đặt thêm

### Bước 2: Tạo Database

#### 2.1. Mở SQL Server Management Studio (SSMS)

1. Mở **SQL Server Management Studio**
2. Kết nối đến SQL Server:
   - **Server name:** 
     - SQL Server Express: `localhost` hoặc `localhost\SQLEXPRESS`
     - LocalDB: `(localdb)\MSSQLLocalDB`
     - SQL Server có tên cụ thể: `TÊN_MÁY\TÊN_INSTANCE`
   - **Authentication:** 
     - Windows Authentication (nếu dùng Windows login)
     - SQL Server Authentication (nếu dùng tài khoản `sa`)

#### 2.2. Chạy Script tạo Database

1. Trong SSMS, mở file `PhoManager.Database/create_tables.sql`
2. **Kiểm tra** script trước khi chạy:
   - Script sẽ tự động tạo database `QLQuanPho` nếu chưa tồn tại
   - Script sẽ tạo tất cả các bảng cần thiết
3. Nhấn **F5** hoặc click **Execute** để chạy script
4. Kiểm tra kết quả ở tab **Messages** - sẽ hiển thị "Tạo các bảng thành công!"

#### 2.3. Thêm dữ liệu mẫu

1. Mở file `PhoManager.Database/sample_data.sql`
2. Đảm bảo đã chọn database `QLQuanPho` trong dropdown phía trên
3. Nhấn **F5** để chạy script
4. Kiểm tra kết quả: "Thêm dữ liệu mẫu thành công!"

#### 2.4. (Tùy chọn) Tạo Stored Procedures

1. Mở file `PhoManager.Database/stored_procedures.sql`
2. Đảm bảo đã chọn database `QLQuanPho`
3. Nhấn **F5** để chạy script

#### 2.5. Kiểm tra Database đã tạo thành công

Trong SSMS, mở rộng:
- Databases → QLQuanPho → Tables
- Bạn sẽ thấy các bảng: `BanAn`, `ChiTietHoaDon`, `HoaDon`, `MonAn`, `MonAn_NguyenLieu`, `NguyenLieu`, `NhanVien`

### Bước 3: Cấu hình Connection String

1. Mở file `App.config` trong project (có thể mở bằng Notepad hoặc Visual Studio)

2. Tìm section `<connectionStrings>` và cập nhật theo cấu hình SQL Server của bạn:

#### Trường hợp 1: Windows Authentication (Khuyên dùng)

```xml
<connectionStrings>
    <add name="QLQuanPhoConnectionString" 
         connectionString="Data Source=localhost;Initial Catalog=QLQuanPho;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;TrustServerCertificate=True;Application Name=QLQuanPhoApp" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

**Giải thích:**
- `Data Source=localhost`: Server name (thay `localhost` nếu dùng tên khác)
- `Initial Catalog=QLQuanPho`: Tên database
- `Integrated Security=True`: Dùng Windows Authentication
- `MultipleActiveResultSets=True`: Cho phép nhiều kết quả cùng lúc

#### Trường hợp 2: SQL Server Authentication

```xml
<connectionStrings>
    <add name="QLQuanPhoConnectionString" 
         connectionString="Data Source=localhost;Initial Catalog=QLQuanPho;User ID=sa;Password=YourPassword123;MultipleActiveResultSets=True;Connect Timeout=30;TrustServerCertificate=True;Application Name=QLQuanPhoApp" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

**Thay đổi:**
- `User ID=sa`: Tên đăng nhập SQL Server
- `Password=YourPassword123`: Mật khẩu của bạn (thay bằng mật khẩu thực tế)

#### Trường hợp 3: LocalDB

```xml
<connectionStrings>
    <add name="QLQuanPhoConnectionString" 
         connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QLQuanPho;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;TrustServerCertificate=True;Application Name=QLQuanPhoApp" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

#### Trường hợp 4: SQL Server có tên instance cụ thể

```xml
<connectionStrings>
    <add name="QLQuanPhoConnectionString" 
         connectionString="Data Source=localhost\SQLEXPRESS;Initial Catalog=QLQuanPho;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;TrustServerCertificate=True;Application Name=QLQuanPhoApp" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

**Lưu ý:** Thay `SQLEXPRESS` bằng tên instance của bạn (ví dụ: `MSSQLSERVER`, `SQLEXPRESS2019`, ...)

### Bước 4: Mở Project trong Visual Studio

1. **Mở Visual Studio**
2. Chọn **File → Open → Project/Solution**
3. Tìm và chọn file `QLQuanPho.sln` trong thư mục project
4. Đợi Visual Studio load project và restore packages (nếu có)

### Bước 5: Build Project

1. Trong Visual Studio, chọn menu **Build → Build Solution** (hoặc nhấn **Ctrl+Shift+B**)
2. Kiểm tra cửa sổ **Output** ở phía dưới:
   - Nếu build thành công: `========== Build: 1 succeeded, 0 failed, 0 up-to-date, 0 skipped ==========`
   - Nếu có lỗi: Xem phần [Xử lý lỗi thường gặp](#xử-lý-lỗi-thường-gặp)

### Bước 6: Chạy ứng dụng

1. Nhấn **F5** hoặc click nút **Start** (màu xanh) trên toolbar
2. Hoặc chọn menu **Debug → Start Debugging**
3. Ứng dụng sẽ khởi động và hiển thị màn hình **Đăng nhập**

### Bước 7: Đăng nhập lần đầu

Sử dụng tài khoản mặc định từ dữ liệu mẫu:

- **Tài khoản:** `admin`
- **Mật khẩu:** `admin123`
- **Chức vụ:** Quản lý (có đầy đủ quyền)

Hoặc:

- **Tài khoản:** `thungan`
- **Mật khẩu:** `123456`
- **Chức vụ:** Thu ngân

### Bước 8: Kiểm tra kết nối Database

1. Sau khi đăng nhập thành công, bạn sẽ thấy màn hình chính
2. Ở thanh **Status Bar** phía dưới, kiểm tra trạng thái:
   - ✅ **"Database: Kết nối thành công"** (màu xanh) → Database hoạt động tốt
   - ❌ **"Database: Không thể kết nối"** (màu đỏ) → Kiểm tra lại connection string

## 📁 Cấu trúc dự án

```
QLQuanPho/
│
├── PhoManager.Database/          # Scripts database
│   ├── create_tables.sql         # Tạo database và bảng
│   ├── sample_data.sql           # Dữ liệu mẫu (nhân viên, món ăn, bàn...)
│   └── stored_procedures.sql     # Stored procedures (tùy chọn)
│
├── PhoManager.DTO/               # Data Transfer Objects (Lớp dữ liệu)
│   ├── MonAnDTO.cs               # DTO cho món ăn
│   ├── NhanVienDTO.cs            # DTO cho nhân viên
│   ├── BanAnDTO.cs               # DTO cho bàn ăn
│   ├── HoaDonDTO.cs              # DTO cho hóa đơn
│   ├── ChiTietHoaDonDTO.cs       # DTO cho chi tiết hóa đơn
│   └── NguyenLieuDTO.cs          # DTO cho nguyên liệu
│
├── PhoManager.DAL/               # Data Access Layer (Truy xuất dữ liệu)
│   ├── QLQuanPho.dbml            # LINQ to SQL DBML (Database Markup Language)
│   ├── QLQuanPho.designer.cs     # Auto-generated DataContext và Entities từ DBML
│   ├── EntityMapper.cs           # Chuyển đổi Entity ↔ DTO
│   ├── MonAnDAL.cs               # DAL cho món ăn
│   ├── NhanVienDAL.cs            # DAL cho nhân viên
│   ├── BanAnDAL.cs               # DAL cho bàn ăn
│   ├── HoaDonDAL.cs              # DAL cho hóa đơn
│   └── ThongKeDAL.cs             # DAL cho thống kê
│
├── PhoManager.BLL/               # Business Logic Layer (Xử lý nghiệp vụ)
│   ├── MonAnBLL.cs               # Business logic cho món ăn
│   ├── NhanVienBLL.cs            # Business logic cho nhân viên
│   ├── BanAnBLL.cs               # Business logic cho bàn ăn
│   ├── HoaDonBLL.cs              # Business logic cho hóa đơn
│   ├── OrderBLL.cs               # Business logic cho order
│   └── ThongKeBLL.cs             # Business logic cho thống kê
│
└── PhoManager.UI/                # User Interface (WinForms)
    └── Forms/
        ├── FrmLogin.cs           # Form đăng nhập
        ├── FrmMain.cs            # Form màn hình chính
        ├── FrmMonAn.cs           # Form quản lý món ăn
        ├── FrmNhanVien.cs        # Form quản lý nhân viên
        ├── FrmBanAn.cs           # Form quản lý bàn ăn
        ├── FrmOrder.cs           # Form gọi món
        ├── FrmHoaDon.cs          # Form hóa đơn
        ├── FrmThongKe.cs         # Form thống kê
        └── FrmCauHinh.cs         # Form cấu hình
```

## ✨ Tính năng

### 1. Quản lý Món ăn
- Thêm / sửa / xóa món phở
- Quản lý giá (tô nhỏ / tô lớn)
- Ghi chú món ăn
- Tìm kiếm món ăn

### 2. Quản lý Nhân viên
- Thêm / sửa / xóa nhân viên
- Phân quyền: Quản lý / Thu ngân / Bếp
- Đăng nhập hệ thống

### 3. Quản lý Bàn ăn
- Quản lý bàn ăn
- Cập nhật trạng thái bàn (Trống / Có khách / Đã thanh toán)

### 4. Order món
- Chọn bàn và gọi món
- Thêm món vào đơn hàng
- Tính tổng tiền tự động

### 5. Hóa đơn
- Xem hóa đơn
- In hóa đơn (cần implement thêm)
- Thanh toán

### 6. Thống kê
- Thống kê doanh thu theo ngày/tháng/năm
- Món bán chạy nhất
- Doanh thu theo nhân viên

## 🚀 Hướng dẫn sử dụng

### Đăng nhập

Tài khoản mặc định (từ sample_data.sql):
- **Tài khoản:** `admin`
- **Mật khẩu:** `admin123`
- **Chức vụ:** Quản lý

Hoặc:
- **Tài khoản:** `thungan`
- **Mật khẩu:** `123456`
- **Chức vụ:** Thu ngân

### Quyền truy cập

- **Quản lý:** Có đầy đủ quyền truy cập tất cả chức năng
- **Thu ngân:** Có thể order món, xem hóa đơn, quản lý bàn
- **Bếp:** Có thể xem order (cần implement thêm)

## ❌ Xử lý lỗi thường gặp

### Lỗi 1: "Cannot connect to database" hoặc "Database: Không thể kết nối"

**Nguyên nhân:**
- Connection string không đúng
- SQL Server chưa khởi động
- Database chưa được tạo
- Tường lửa chặn kết nối

**Giải pháp:**
1. Kiểm tra SQL Server đã chạy chưa:
   - Mở **SQL Server Configuration Manager**
   - Kiểm tra service **SQL Server (MSSQLSERVER)** hoặc **SQL Server (SQLEXPRESS)** đang **Running**
   - Nếu chưa chạy, click chuột phải → **Start**

2. Kiểm tra connection string trong `App.config`:
   - Đảm bảo `Data Source` đúng với tên server
   - Kiểm tra `Initial Catalog=QLQuanPho` đã đúng tên database
   - Nếu dùng SQL Authentication, kiểm tra `User ID` và `Password`

3. Kiểm tra database đã tồn tại:
   - Mở SSMS
   - Kiểm tra trong **Databases** có database `QLQuanPho` chưa
   - Nếu chưa có, chạy lại script `create_tables.sql`

4. Test connection trong SSMS:
   - Thử kết nối với thông tin giống connection string
   - Nếu SSMS kết nối được nhưng app không được → Kiểm tra lại App.config

### Lỗi 2: "Connection string 'QLQuanPhoConnectionString' is missing"

**Nguyên nhân:** 
- File `App.config` không có connection string hoặc tên không đúng

**Giải pháp:**
1. Mở file `App.config`
2. Đảm bảo có section `<connectionStrings>` với tên chính xác `QLQuanPhoConnectionString`
3. Build lại project (Ctrl+Shift+B)

### Lỗi 3: "Login failed for user" hoặc "Cannot open database"

**Nguyên nhân:**
- Sai tài khoản/mật khẩu SQL Server
- Tài khoản không có quyền truy cập database
- Database không tồn tại

**Giải pháp:**
1. Kiểm tra lại `User ID` và `Password` trong connection string
2. Thử đổi sang Windows Authentication:
   ```xml
   Integrated Security=True
   ```
3. Đảm bảo database `QLQuanPho` đã được tạo

### Lỗi 4: Build lỗi - "The type or namespace name 'PhoManager' could not be found"

**Nguyên nhân:**
- File chưa được include vào project
- Namespace không đúng

**Giải pháp:**
1. Kiểm tra trong **Solution Explorer** xem tất cả file `.cs` đã có trong project chưa
2. Nếu thiếu, click chuột phải vào project → **Add → Existing Item** → Chọn file
3. Clean và rebuild solution:
   - **Build → Clean Solution**
   - **Build → Rebuild Solution**

### Lỗi 5: "System.Data.Linq not found"

**Nguyên nhân:**
- Thiếu reference `System.Data.Linq`

**Giải pháp:**
1. Trong Visual Studio, click chuột phải vào project → **Add Reference**
2. Chọn **.NET** tab
3. Tìm và chọn **System.Data.Linq**
4. Click **OK** và build lại

### Lỗi 6: "InvalidOperationException: Connection string is missing"

**Nguyên nhân:**
- App.config không được copy vào thư mục output

**Giải pháp:**
1. Click chuột phải vào `App.config` trong Solution Explorer
2. Chọn **Properties**
3. Đảm bảo **Copy to Output Directory** = **Copy always** hoặc **Copy if newer**

### Lỗi 7: Ứng dụng chạy nhưng không hiển thị gì hoặc crash ngay

**Nguyên nhân:**
- Có exception chưa được xử lý
- Database chưa có dữ liệu

**Giải pháp:**
1. Chạy ứng dụng trong **Debug mode** (F5)
2. Kiểm tra cửa sổ **Output** hoặc **Exception** để xem lỗi cụ thể
3. Đảm bảo đã chạy script `sample_data.sql` để có dữ liệu đăng nhập

## 📝 Ghi chú kỹ thuật

- Ứng dụng sử dụng **LINQ to SQL** (System.Data.Linq) với **DBML** (Database Markup Language) để kết nối database
- **DBML** được sử dụng để định nghĩa database schema và tự động generate DataContext và Entity classes
- File `QLQuanPho.dbml` chứa định nghĩa các bảng và quan hệ, file `QLQuanPho.designer.cs` được tự động generate từ DBML
- Kiến trúc **3-layer** (DTO → DAL → BLL → UI) giúp code dễ bảo trì và mở rộng
- Tất cả DAL classes sử dụng `using` statement để đảm bảo dispose connection đúng cách
- Validation được thực hiện ở cả BLL và UI layer
- Các tính năng in hóa đơn, gộp/tách bàn, quản lý nguyên liệu có thể được mở rộng thêm
- **Lưu ý**: Khi thay đổi database schema, cần cập nhật file `QLQuanPho.dbml` và rebuild project để regenerate `QLQuanPho.designer.cs`

## 💡 Mẹo và Best Practices

### 1. Tối ưu hiệu suất
- Sử dụng `using` statement cho tất cả DataContext để tự động dispose
- Tránh query quá nhiều dữ liệu cùng lúc, sử dụng pagination nếu cần
- Index các cột thường xuyên được query (đã có trong script create_tables.sql)

### 2. Bảo mật
- ⚠️ **Mật khẩu hiện tại được lưu dạng plain text** - Nên hash mật khẩu (SHA256, BCrypt...) trước khi lưu
- Sử dụng Windows Authentication khi có thể (an toàn hơn SQL Authentication)
- Không commit file `App.config` có thông tin nhạy cảm lên Git
- Validation được thực hiện ở cả BLL và UI layer
- LINQ to SQL tự động sử dụng parameterized queries → tránh SQL Injection

### 3. Backup Database
- Nên backup database thường xuyên:
  ```sql
  BACKUP DATABASE QLQuanPho 
  TO DISK = 'C:\Backup\QLQuanPho.bak'
  ```

### 4. Phát triển thêm tính năng
- In hóa đơn: Sử dụng `PrintDocument` class
- Gộp/tách bàn: Thêm logic vào `HoaDonBLL`
- Quản lý nguyên liệu: Mở rộng `NguyenLieuDAL` và thêm form tương ứng
- Hash mật khẩu: Tạo helper class trong BLL để hash/verify password

## 📊 Kiến trúc và Công nghệ

### Kiến trúc 3-Layer
```
┌─────────────────────────────────┐
│   UI Layer (WinForms)           │  ← Giao diện người dùng
│   - FrmLogin, FrmMain, ...      │
└──────────────┬──────────────────┘
               │
┌──────────────▼──────────────────┐
│   BLL Layer (Business Logic)    │  ← Xử lý nghiệp vụ, validation
│   - MonAnBLL, NhanVienBLL, ...  │
└──────────────┬──────────────────┘
               │
┌──────────────▼──────────────────┐
│   DAL Layer (Data Access)       │  ← Truy xuất dữ liệu
│   - QLQuanPhoDataContext (DBML) │
│   - MonAnDAL, NhanVienDAL, ...  │
└──────────────┬──────────────────┘
               │
┌──────────────▼──────────────────┐
│   Database (SQL Server)         │  ← Lưu trữ dữ liệu
│   - Tables, Stored Procedures   │
└─────────────────────────────────┘
```

### Công nghệ sử dụng
- **.NET Framework 4.8**: Runtime framework
- **C#**: Ngôn ngữ lập trình
- **WinForms**: Framework giao diện desktop
- **LINQ to SQL**: ORM để truy xuất database
- **DBML (Database Markup Language)**: Định nghĩa database schema và mapping
- **SQL Server**: Hệ quản trị cơ sở dữ liệu
- **System.Data.Linq**: Thư viện LINQ to SQL

## 🧪 Test và Debug

### Chạy ứng dụng ở chế độ Debug
1. Nhấn **F5** để chạy ở chế độ Debug
2. Đặt breakpoint bằng cách click vào số dòng bên trái
3. Sử dụng **Debug → Windows** để xem:
   - **Watch**: Giá trị biến
   - **Locals**: Biến local trong scope hiện tại
   - **Output**: Thông tin log

### Test kết nối database
1. Mở file `PhoManager.DAL/QLQuanPho.designer.cs`
2. Thêm breakpoint vào method `TestConnection()` trong class `QLQuanPhoDataContext`
3. Chạy ứng dụng và kiểm tra kết nối

## 📞 Hỗ trợ

Nếu gặp vấn đề, kiểm tra:
1. ✅ SQL Server đã cài đặt và đang chạy
2. ✅ Database `QLQuanPho` đã được tạo
3. ✅ Connection string trong `App.config` đúng
4. ✅ Đã chạy script `sample_data.sql` để có dữ liệu đăng nhập
5. ✅ Visual Studio đã cài đặt .NET Framework 4.8

## 📄 License

Dự án này được tạo cho mục đích học tập và tham khảo.

---

## 🎯 Checklist trước khi chạy

- [ ] Đã cài đặt SQL Server hoặc SQL Server Express
- [ ] Đã cài đặt SQL Server Management Studio (SSMS)
- [ ] Đã cài đặt Visual Studio 2017+ với .NET Framework 4.8
- [ ] Đã tạo database bằng script `create_tables.sql`
- [ ] Đã thêm dữ liệu mẫu bằng script `sample_data.sql`
- [ ] Đã cấu hình connection string trong `App.config`
- [ ] Đã build project thành công (không có lỗi)
- [ ] Đã test kết nối database trong SSMS

---

**Chúc bạn thành công với dự án! 🎉**

Nếu có thắc mắc, hãy kiểm tra phần [Xử lý lỗi thường gặp](#xử-lý-lỗi-thường-gặp) ở trên.