-- =============================================
-- Database: QLQuanPho
-- Mô tả: Script tạo các bảng cho hệ thống quản lý quán phở
-- =============================================

USE master;
GO

-- Tạo database nếu chưa tồn tại
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QLQuanPho')
BEGIN
    CREATE DATABASE QLQuanPho;
END
GO

USE QLQuanPho;
GO

-- =============================================
-- Bảng: NhanVien (Nhân viên)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NhanVien]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[NhanVien](
        [MaNV] [int] IDENTITY(1,1) NOT NULL,
        [HoTen] [nvarchar](100) NOT NULL,
        [TaiKhoan] [nvarchar](50) NOT NULL,
        [MatKhau] [nvarchar](255) NOT NULL,
        [ChucVu] [nvarchar](50) NOT NULL, -- Quản lý / Thu ngân / Bếp / Phục vụ / Pha chế
        [NgayTao] [datetime] NOT NULL DEFAULT GETDATE(),
        [TrangThai] [bit] NOT NULL DEFAULT 1, -- 1: Hoạt động, 0: Ngừng hoạt động
        CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED ([MaNV] ASC),
        CONSTRAINT [UQ_NhanVien_TaiKhoan] UNIQUE ([TaiKhoan])
    );
END
GO

-- =============================================
-- Bảng: MonAn (Món ăn)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MonAn]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[MonAn](
        [MaMon] [int] IDENTITY(1,1) NOT NULL,
        [TenMon] [nvarchar](100) NOT NULL,
        [GiaNho] [decimal](18, 0) NOT NULL DEFAULT 0, -- Giá tô nhỏ
        [GiaLon] [decimal](18, 0) NOT NULL DEFAULT 0, -- Giá tô lớn
        [GhiChu] [nvarchar](500) NULL, -- Ghi chú món (ít nước, thêm hành, không giá, ...)
        [MoTa] [nvarchar](500) NULL,
        [TrangThai] [bit] NOT NULL DEFAULT 1, -- 1: Còn bán, 0: Ngừng bán
        [NgayTao] [datetime] NOT NULL DEFAULT GETDATE(),
        CONSTRAINT [PK_MonAn] PRIMARY KEY CLUSTERED ([MaMon] ASC)
    );
END
GO

-- =============================================
-- Bảng: NguyenLieu (Nguyên liệu)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NguyenLieu]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[NguyenLieu](
        [MaNL] [int] IDENTITY(1,1) NOT NULL,
        [TenNL] [nvarchar](100) NOT NULL,
        [SoLuongTon] [decimal](18, 2) NOT NULL DEFAULT 0,
        [DonViTinh] [nvarchar](20) NOT NULL, -- kg, lít, gói, ...
        [GiaNhap] [decimal](18, 0) NULL, -- Giá nhập nguyên liệu
        [NgayCapNhat] [datetime] NOT NULL DEFAULT GETDATE(),
        CONSTRAINT [PK_NguyenLieu] PRIMARY KEY CLUSTERED ([MaNL] ASC)
    );
END
GO

-- =============================================
-- Bảng: MonAn_NguyenLieu (Liên kết Món ăn - Nguyên liệu)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MonAn_NguyenLieu]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[MonAn_NguyenLieu](
        [MaMon] [int] NOT NULL,
        [MaNL] [int] NOT NULL,
        [SoLuong] [decimal](18, 2) NOT NULL DEFAULT 1, -- Số lượng nguyên liệu cần cho 1 món
        CONSTRAINT [PK_MonAn_NguyenLieu] PRIMARY KEY CLUSTERED ([MaMon] ASC, [MaNL] ASC),
        CONSTRAINT [FK_MonAn_NguyenLieu_MonAn] FOREIGN KEY([MaMon]) REFERENCES [dbo].[MonAn] ([MaMon]) ON DELETE CASCADE,
        CONSTRAINT [FK_MonAn_NguyenLieu_NguyenLieu] FOREIGN KEY([MaNL]) REFERENCES [dbo].[NguyenLieu] ([MaNL]) ON DELETE CASCADE
    );
END
GO

-- =============================================
-- Bảng: BanAn (Bàn ăn)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BanAn]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[BanAn](
        [MaBan] [int] IDENTITY(1,1) NOT NULL,
        [TenBan] [nvarchar](50) NOT NULL,
        [TrangThai] [nvarchar](20) NOT NULL DEFAULT N'Trống', -- Trống / Có khách / Đã thanh toán
        [SoLuongGhe] [int] NOT NULL DEFAULT 4, -- Số lượng ghế
        [GhiChu] [nvarchar](200) NULL,
        CONSTRAINT [PK_BanAn] PRIMARY KEY CLUSTERED ([MaBan] ASC),
        CONSTRAINT [UQ_BanAn_TenBan] UNIQUE ([TenBan])
    );
END
GO

-- =============================================
-- Bảng: HoaDon (Hóa đơn)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HoaDon]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[HoaDon](
        [MaHD] [int] IDENTITY(1,1) NOT NULL,
        [MaBan] [int] NOT NULL,
        [MaNV] [int] NOT NULL,
        [NgayLap] [datetime] NOT NULL DEFAULT GETDATE(),
        [TongTien] [decimal](18, 0) NOT NULL DEFAULT 0,
        [GiamGia] [decimal](18, 0) NOT NULL DEFAULT 0, -- Giảm giá (VND)
        [Thue] [decimal](5, 2) NOT NULL DEFAULT 0, -- Thuế (%)
        [ThanhTien] [decimal](18, 0) NOT NULL DEFAULT 0, -- Tổng tiền sau giảm giá và thuế
        [PhuongThucThanhToan] [nvarchar](50) NULL, -- Tiền mặt / Chuyển khoản
        [TrangThai] [nvarchar](20) NOT NULL DEFAULT N'Chưa thanh toán', -- Chưa thanh toán / Đã thanh toán / Hủy
        [GhiChu] [nvarchar](500) NULL,
        CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED ([MaHD] ASC),
        CONSTRAINT [FK_HoaDon_BanAn] FOREIGN KEY([MaBan]) REFERENCES [dbo].[BanAn] ([MaBan]),
        CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNV]) REFERENCES [dbo].[NhanVien] ([MaNV])
    );
END
GO

-- =============================================
-- Bảng: ChiTietHoaDon (Chi tiết hóa đơn)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChiTietHoaDon]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[ChiTietHoaDon](
        [MaCTHD] [int] IDENTITY(1,1) NOT NULL,
        [MaHD] [int] NOT NULL,
        [MaMon] [int] NOT NULL,
        [SoLuong] [int] NOT NULL DEFAULT 1,
        [DonGia] [decimal](18, 0) NOT NULL, -- Đơn giá tại thời điểm bán
        [KichCo] [nvarchar](10) NULL, -- Nhỏ / Lớn
        [GhiChu] [nvarchar](200) NULL, -- Ghi chú riêng cho món (ít nước, thêm hành, ...)
        [ThanhTien] [decimal](18, 0) NOT NULL, -- Số lượng * Đơn giá
        CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED ([MaCTHD] ASC),
        CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHD]) REFERENCES [dbo].[HoaDon] ([MaHD]) ON DELETE CASCADE,
        CONSTRAINT [FK_ChiTietHoaDon_MonAn] FOREIGN KEY([MaMon]) REFERENCES [dbo].[MonAn] ([MaMon])
    );
END
GO

-- =============================================
-- Tạo Index để tối ưu truy vấn
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_HoaDon_NgayLap' AND object_id = OBJECT_ID('HoaDon'))
BEGIN
    CREATE INDEX [IX_HoaDon_NgayLap] ON [dbo].[HoaDon] ([NgayLap]);
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_HoaDon_MaBan' AND object_id = OBJECT_ID('HoaDon'))
BEGIN
    CREATE INDEX [IX_HoaDon_MaBan] ON [dbo].[HoaDon] ([MaBan]);
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_ChiTietHoaDon_MaHD' AND object_id = OBJECT_ID('ChiTietHoaDon'))
BEGIN
    CREATE INDEX [IX_ChiTietHoaDon_MaHD] ON [dbo].[ChiTietHoaDon] ([MaHD]);
END
GO

PRINT N'Tạo các bảng thành công!';
GO
