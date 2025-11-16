# 📦 HƯỚNG DẪN TẠO SETUP.EXE CHO ỨNG DỤNG QLQuanPho

## 🎯 Tổng quan

Ứng dụng QLQuanPho sử dụng **.NET Framework 4.8**, do đó:
- ✅ **CÓ THỂ** tạo file setup .exe
- ⚠️ **KHÔNG THỂ** loại bỏ hoàn toàn yêu cầu .NET Framework (vì đây là .NET Framework, không phải .NET Core)
- ✅ **CÓ THỂ** tự động cài đặt .NET Framework 4.8 trong quá trình setup nếu máy người dùng chưa có

## 🔧 Giải pháp 1: Sử dụng Inno Setup (KHUYẾN NGHỊ - Miễn phí)

### Bước 1: Tải và cài đặt Inno Setup
1. Tải Inno Setup từ: https://jrsoftware.org/isdl.php
2. Cài đặt Inno Setup (miễn phí, mã nguồn mở)

### Bước 2: Tạo script setup

Tạo file `QLQuanPho_Setup.iss` với nội dung sau:

```iss
[Setup]
AppName=Quản Lý Quán Phở
AppVersion=1.0
DefaultDirName={pf}\QLQuanPho
DefaultGroupName=Quản Lý Quán Phở
OutputDir=Setup
OutputBaseFilename=QLQuanPho_Setup
Compression=lzma
SolidCompression=yes
PrivilegesRequired=admin
ArchitecturesInstallIn64BitMode=x64

; Tự động kiểm tra và cài .NET Framework 4.8
[Files]
Source: "bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs
Source: "PhoManager.Database\*.sql"; DestDir: "{app}\Database"; Flags: ignoreversion

[Icons]
Name: "{group}\Quản Lý Quán Phở"; Filename: "{app}\QLQuanPho.exe"
Name: "{group}\Gỡ cài đặt"; Filename: "{uninstallexe}"
Name: "{commondesktop}\Quản Lý Quán Phở"; Filename: "{app}\QLQuanPho.exe"

[Run]
; Kiểm tra và cài .NET Framework 4.8 nếu chưa có
Filename: "{dotnet48}"; StatusMsg: "Đang cài đặt .NET Framework 4.8..."; Check: not IsDotNet48Installed

[Code]
function IsDotNet48Installed: Boolean;
var
  Release: Cardinal;
begin
  Result := False;
  if RegQueryDWordValue(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', Release) then
  begin
    // .NET Framework 4.8 = Release >= 528040
    Result := Release >= 528040;
  end;
end;
```

### Bước 3: Build Release version
1. Trong Visual Studio: Build → Configuration Manager → Chọn "Release"
2. Build → Rebuild Solution
3. Copy file `ndp48-web.exe` (Downloader .NET Framework 4.8) vào thư mục Setup

### Bước 4: Tạo file setup
1. Mở Inno Setup Compiler
2. File → Open → Chọn file `QLQuanPho_Setup.iss`
3. Build → Compile (F9)
4. File setup sẽ được tạo trong thư mục `Setup\QLQuanPho_Setup.exe`

---

## 🔧 Giải pháp 2: Visual Studio Installer Projects (Miễn phí)

### Bước 1: Cài đặt extension
1. Visual Studio → Extensions → Manage Extensions
2. Tìm "Microsoft Visual Studio Installer Projects"
3. Download and Install
4. Restart Visual Studio

### Bước 2: Tạo Setup Project
1. Right-click Solution → Add → New Project
2. Chọn "Setup Project" (Visual Studio Installer)
3. Đặt tên: `QLQuanPhoSetup`

### Bước 3: Cấu hình Setup Project
1. Right-click `QLQuanPhoSetup` → View → File System
2. Right-click "Application Folder" → Add → Project Output
3. Chọn "QLQuanPho" project → Primary Output
4. Add thêm:
   - Content Files (cho SQL scripts)
   - Config Files

### Bước 4: Thêm Prerequisites (.NET Framework 4.8)
1. Right-click `QLQuanPhoSetup` → Properties
2. Prerequisites → Check "Microsoft .NET Framework 4.8 (x86 and x64)"
3. Chọn "Download prerequisites from the same location as my application"

### Bước 5: Build Setup
1. Right-click `QLQuanPhoSetup` → Build
2. File `.msi` sẽ được tạo trong `QLQuanPhoSetup\Release\`

---

## 🔧 Giải pháp 3: Advanced Installer (Có bản miễn phí)

1. Tải Advanced Installer: https://www.advancedinstaller.com/
2. Tạo project mới → Windows Application
3. Import files từ `bin\Release`
4. Thêm Prerequisites → .NET Framework 4.8
5. Build → Tạo file `.exe` hoặc `.msi`

---

## 🔧 Giải phải 4: Migrate sang .NET 6/7/8 (Self-Contained - KHÔNG CẦN .NET)

### Ưu điểm:
- ✅ **KHÔNG CẦN** cài .NET Framework trên máy người dùng
- ✅ Tự đóng gói tất cả dependencies
- ✅ File .exe độc lập, chạy trực tiếp

### Nhược điểm:
- ⚠️ Cần migrate toàn bộ code (có thể mất thời gian)
- ⚠️ LINQ to SQL không còn được hỗ trợ (cần chuyển sang Entity Framework Core)

### Các bước migrate:
1. Tạo project mới .NET 6/7/8 WinForms
2. Copy code và chuyển đổi:
   - LINQ to SQL → Entity Framework Core
   - System.Data.Linq → Microsoft.EntityFrameworkCore
3. Cấu hình self-contained deployment:
   ```xml
   <PropertyGroup>
     <SelfContained>true</SelfContained>
     <RuntimeIdentifier>win-x64</RuntimeIdentifier>
     <PublishSingleFile>true</PublishSingleFile>
     <IncludeNativeLibrariesForSelfExtract>true</IncludeNativeLibrariesForSelfExtract>
   </PropertyGroup>
   ```
4. Publish: `dotnet publish -c Release -r win-x64 --self-contained true`

---

## 📋 Checklist trước khi tạo Setup

- [ ] Build project ở chế độ **Release**
- [ ] Test ứng dụng trên máy không có Visual Studio
- [ ] Chuẩn bị file SQL scripts (createTable.sql, sampleData.sql)
- [ ] Tạo file hướng dẫn cài đặt SQL Server cho người dùng
- [ ] Test connection string (có thể cần chỉnh sửa trong App.config)
- [ ] Tạo file README cho người dùng cuối

---

## 🎯 KHUYẾN NGHỊ

**Cho dự án hiện tại (.NET Framework 4.8):**
- ✅ Sử dụng **Inno Setup** (Giải pháp 1) - Miễn phí, dễ sử dụng, tự động cài .NET Framework

**Cho dự án tương lai:**
- ✅ Nên migrate sang **.NET 6/7/8** để có self-contained deployment (không cần cài .NET)

---

## 📝 Lưu ý quan trọng

1. **SQL Server vẫn cần cài đặt riêng** - Setup chỉ cài ứng dụng, không cài SQL Server
2. **Connection String** - Cần hướng dẫn người dùng cấu hình trong App.config
3. **Database** - Cần chạy SQL scripts để tạo database trước khi sử dụng
4. **.NET Framework 4.8** - Sẽ được tự động cài nếu sử dụng Inno Setup với script trên

---

## 🔗 Tài liệu tham khảo

- Inno Setup: https://jrsoftware.org/isinfo.php
- Visual Studio Installer Projects: https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2017InstallerProjects
- .NET Framework 4.8 Download: https://dotnet.microsoft.com/download/dotnet-framework/net48

