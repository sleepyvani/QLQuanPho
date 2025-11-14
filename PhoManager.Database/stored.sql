-- =============================================
-- Stored Procedures cho hệ thống quản lý quán phở
-- =============================================

USE QLQuanPho;
GO

-- =============================================
-- SP: sp_DangNhap - Đăng nhập hệ thống
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DangNhap]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[sp_DangNhap];
GO

CREATE PROCEDURE [dbo].[sp_DangNhap]
    @TaiKhoan NVARCHAR(50),
    @MatKhau NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        MaNV,
        HoTen,
        TaiKhoan,
        ChucVu,
        TrangThai
    FROM NhanVien
    WHERE TaiKhoan = @TaiKhoan 
        AND MatKhau = @MatKhau
        AND TrangThai = 1;
END
GO

-- =============================================
-- SP: sp_ThongKeDoanhThu - Thống kê doanh thu
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_ThongKeDoanhThu]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[sp_ThongKeDoanhThu];
GO

CREATE PROCEDURE [dbo].[sp_ThongKeDoanhThu]
    @TuNgay DATETIME = NULL,
    @DenNgay DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    IF @TuNgay IS NULL SET @TuNgay = DATEADD(DAY, -30, GETDATE());
    IF @DenNgay IS NULL SET @DenNgay = GETDATE();
    
    SELECT 
        CONVERT(DATE, NgayLap) AS Ngay,
        COUNT(MaHD) AS SoHoaDon,
        SUM(ThanhTien) AS TongDoanhThu
    FROM HoaDon
    WHERE NgayLap BETWEEN @TuNgay AND @DenNgay
        AND TrangThai = N'Đã thanh toán'
    GROUP BY CONVERT(DATE, NgayLap)
    ORDER BY Ngay DESC;
END
GO

-- =============================================
-- SP: sp_MonBanChay - Thống kê món bán chạy
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_MonBanChay]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[sp_MonBanChay];
GO

CREATE PROCEDURE [dbo].[sp_MonBanChay]
    @TuNgay DATETIME = NULL,
    @DenNgay DATETIME = NULL,
    @Top INT = 10
AS
BEGIN
    SET NOCOUNT ON;
    
    IF @TuNgay IS NULL SET @TuNgay = DATEADD(DAY, -30, GETDATE());
    IF @DenNgay IS NULL SET @DenNgay = GETDATE();
    
    SELECT TOP (@Top)
        m.TenMon,
        SUM(ct.SoLuong) AS TongSoLuong,
        SUM(ct.ThanhTien) AS TongDoanhThu
    FROM ChiTietHoaDon ct
    INNER JOIN HoaDon hd ON ct.MaHD = hd.MaHD
    INNER JOIN MonAn m ON ct.MaMon = m.MaMon
    WHERE hd.NgayLap BETWEEN @TuNgay AND @DenNgay
        AND hd.TrangThai = N'Đã thanh toán'
    GROUP BY m.TenMon
    ORDER BY TongSoLuong DESC;
END
GO

-- =============================================
-- SP: sp_DoanhThuTheoNhanVien - Doanh thu theo nhân viên
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_DoanhThuTheoNhanVien]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[sp_DoanhThuTheoNhanVien];
GO

CREATE PROCEDURE [dbo].[sp_DoanhThuTheoNhanVien]
    @TuNgay DATETIME = NULL,
    @DenNgay DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    IF @TuNgay IS NULL SET @TuNgay = DATEADD(DAY, -30, GETDATE());
    IF @DenNgay IS NULL SET @DenNgay = GETDATE();
    
    SELECT 
        nv.MaNV,
        nv.HoTen,
        nv.ChucVu,
        COUNT(hd.MaHD) AS SoHoaDon,
        SUM(hd.ThanhTien) AS TongDoanhThu
    FROM NhanVien nv
    LEFT JOIN HoaDon hd ON nv.MaNV = hd.MaNV
        AND hd.NgayLap BETWEEN @TuNgay AND @DenNgay
        AND hd.TrangThai = N'Đã thanh toán'
    WHERE nv.TrangThai = 1
    GROUP BY nv.MaNV, nv.HoTen, nv.ChucVu
    ORDER BY TongDoanhThu DESC;
END
GO

-- =============================================
-- SP: sp_CapNhatTrangThaiBan - Cập nhật trạng thái bàn
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_CapNhatTrangThaiBan]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[sp_CapNhatTrangThaiBan];
GO

CREATE PROCEDURE [dbo].[sp_CapNhatTrangThaiBan]
    @MaBan INT,
    @TrangThai NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE BanAn
    SET TrangThai = @TrangThai
    WHERE MaBan = @MaBan;
    
    SELECT @@ROWCOUNT AS SoDongCapNhat;
END
GO

PRINT N'Tạo các Stored Procedures thành công!';
GO
