# 📖 HƯỚNG DẪN CÀI ĐẶT CHO NGƯỜI DÙNG CUỐI

## 🎯 Yêu cầu hệ thống

Trước khi cài đặt ứng dụng **Quản Lý Quán Phở**, máy tính của bạn cần có:

1. **Windows 7 SP1 trở lên** (Windows 10/11 khuyên dùng)
2. **.NET Framework 4.8** (sẽ được tự động cài nếu chưa có)
3. **SQL Server** (cần cài đặt riêng - xem hướng dẫn bên dưới)

---

## 📦 Bước 1: Cài đặt SQL Server

### Tùy chọn 1: SQL Server Express (Khuyên dùng - Miễn phí)

1. Tải SQL Server Express từ: https://www.microsoft.com/sql-server/sql-server-downloads
2. Chạy file cài đặt
3. Chọn **"Basic"** installation (cài đặt cơ bản)
4. Chọn **"Mixed Mode Authentication"** (SQL Server Authentication + Windows Authentication)
5. Đặt mật khẩu cho tài khoản `sa` (ghi nhớ mật khẩu này!)
6. Hoàn tất cài đặt

### Tùy chọn 2: SQL Server LocalDB (Nhẹ hơn)

1. Tải SQL Server Express LocalDB từ: https://www.microsoft.com/sql-server/sql-server-downloads
2. Chạy file cài đặt
3. Hoàn tất cài đặt

---

## 🚀 Bước 2: Cài đặt ứng dụng Quản Lý Quán Phở

1. **Chạy file setup**: `QLQuanPho_Setup.exe`
2. **Làm theo hướng dẫn** trong cửa sổ cài đặt
3. Nếu máy bạn chưa có .NET Framework 4.8, setup sẽ tự động tải và cài đặt
4. Chọn thư mục cài đặt (mặc định: `C:\Program Files\Quản Lý Quán Phở`)
5. Hoàn tất cài đặt

---

## 🗄️ Bước 3: Tạo Database

Sau khi cài đặt ứng dụng, bạn cần tạo database:

### Cách 1: Sử dụng SQL Server Management Studio (SSMS)

1. **Tải và cài SSMS** (nếu chưa có): https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms
2. **Mở SSMS** và kết nối đến SQL Server:
   - Server name: `localhost` hoặc `.\SQLEXPRESS` (nếu dùng Express)
   - Authentication: Windows Authentication hoặc SQL Server Authentication
3. **Tạo database mới**:
   - Right-click "Databases" → New Database
   - Tên database: `QLQuanPho`
   - OK
4. **Chạy SQL Scripts**:
   - Mở file `C:\Program Files\Quản Lý Quán Phở\Database\createTable.sql`
   - Chọn database `QLQuanPho` trong dropdown
   - Execute (F5)
   - Mở file `sampleData.sql` và Execute (F5)

### Cách 2: Sử dụng Command Line (sqlcmd)

1. Mở **Command Prompt** (Run as Administrator)
2. Chạy lệnh:
   ```cmd
   sqlcmd -S localhost -E -i "C:\Program Files\Quản Lý Quán Phở\Database\createTable.sql"
   sqlcmd -S localhost -E -i "C:\Program Files\Quản Lý Quán Phở\Database\sampleData.sql"
   ```

---

## ⚙️ Bước 4: Cấu hình Connection String

1. Mở file: `C:\Program Files\Quản Lý Quán Phở\QLQuanPho.exe.config`
2. Tìm section `<connectionStrings>`
3. Chỉnh sửa connection string theo cấu hình SQL Server của bạn:

### Nếu dùng SQL Server Express với Windows Authentication:
```xml
<connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=QLQuanPho;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;TrustServerCertificate=True" />
```

### Nếu dùng SQL Server với SQL Authentication:
```xml
<connectionString="Data Source=localhost;Initial Catalog=QLQuanPho;User ID=sa;Password=YourPassword;MultipleActiveResultSets=True;Connect Timeout=30;TrustServerCertificate=True" />
```

### Nếu dùng LocalDB:
```xml
<connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QLQuanPho;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;TrustServerCertificate=True" />
```

4. **Lưu file**

---

## ✅ Bước 5: Chạy ứng dụng

1. Tìm shortcut **"Quản Lý Quán Phở"** trên Desktop hoặc Start Menu
2. Double-click để chạy
3. Đăng nhập với tài khoản mặc định (nếu đã chạy sampleData.sql):
   - Username: `admin`
   - Password: `admin` (hoặc mật khẩu đã được thiết lập)

---

## 🔧 Xử lý lỗi thường gặp

### Lỗi: "Cannot connect to SQL Server"

**Nguyên nhân**: Connection string không đúng hoặc SQL Server chưa chạy

**Giải pháp**:
1. Kiểm tra SQL Server đang chạy: Services → SQL Server (MSSQLSERVER)
2. Kiểm tra lại connection string trong file `.exe.config`
3. Thử kết nối bằng SSMS trước

### Lỗi: ".NET Framework 4.8 is required"

**Giải pháp**: Tải và cài .NET Framework 4.8 từ: https://dotnet.microsoft.com/download/dotnet-framework/net48

### Lỗi: "Database QLQuanPho does not exist"

**Giải pháp**: Chạy lại file `createTable.sql` để tạo database

---

## 📞 Hỗ trợ

Nếu gặp vấn đề, vui lòng:
1. Kiểm tra file log trong: `C:\Program Files\Quản Lý Quán Phở\Logs\`
2. Liên hệ bộ phận hỗ trợ kỹ thuật

---

## 📝 Lưu ý

- **Backup database** thường xuyên để tránh mất dữ liệu
- **Cập nhật mật khẩu** tài khoản `sa` sau khi cài đặt
- **Kiểm tra firewall** nếu cần kết nối từ xa đến SQL Server

