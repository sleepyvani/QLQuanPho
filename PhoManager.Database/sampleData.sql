-- =============================================
-- Sample Data cho hệ thống quản lý quán phở
-- =============================================

USE QLQuanPho;
GO

-- =============================================
-- Dữ liệu mẫu: NhanVien
-- =============================================
IF NOT EXISTS (SELECT * FROM NhanVien WHERE TaiKhoan = 'admin')
BEGIN
    INSERT INTO [dbo].[NhanVien] ([HoTen], [TaiKhoan], [MatKhau], [ChucVu], [TrangThai])
    VALUES 
    (N'Nguyễn Văn Admin', 'admin', 'admin123', N'Quản lý', 1),
    (N'Trần Thị Thu Ngân', 'thungan', '123456', N'Thu ngân', 1),
    (N'Lê Văn Bếp', 'bep', '123456', N'Bếp', 1),
    (N'Phạm Thị Phục Vụ', 'phucvu', '123456', N'Thu ngân', 1);
END
GO

-- =============================================
-- Dữ liệu mẫu: NguyenLieu
-- =============================================
IF NOT EXISTS (SELECT * FROM NguyenLieu WHERE TenNL = N'Bánh phở')
BEGIN
    INSERT INTO [dbo].[NguyenLieu] ([TenNL], [SoLuongTon], [DonViTinh], [GiaNhap])
    VALUES 
    (N'Bánh phở', 100, N'kg', 50000),
    (N'Thịt bò', 50, N'kg', 200000),
    (N'Thịt gà', 30, N'kg', 120000),
    (N'Nước dùng', 200, N'lít', 0),
    (N'Hành lá', 20, N'kg', 30000),
    (N'Ngò gai', 15, N'kg', 40000),
    (N'Gia vị', 50, N'gói', 5000),
    (N'Chanh', 30, N'kg', 25000);
END
GO

-- =============================================
-- Dữ liệu mẫu: MonAn
-- =============================================
IF NOT EXISTS (SELECT * FROM MonAn WHERE TenMon = N'Phở Bò')
BEGIN
    INSERT INTO [dbo].[MonAn] ([TenMon], [GiaNho], [GiaLon], [GhiChu], [MoTa])
    VALUES 
    (N'Phở Bò', 50000, 70000, N'Tô nhỏ: 50000đ, Tô lớn: 70000đ', N'Phở bò truyền thống Việt Nam'),
    (N'Phở Bò Tái', 55000, 75000, N'Tô nhỏ: 55000đ, Tô lớn: 75000đ', N'Phở bò tái chín'),
    (N'Phở Gà', 45000, 65000, N'Tô nhỏ: 45000đ, Tô lớn: 65000đ', N'Phở gà thơm ngon'),
    (N'Phở Đặc Biệt', 70000, 90000, N'Tô nhỏ: 70000đ, Tô lớn: 90000đ', N'Phở đầy đủ thịt bò, gân, sụn'),
    (N'Phở Bò Viên', 50000, 70000, N'Tô nhỏ: 50000đ, Tô lớn: 70000đ', N'Phở với bò viên'),
    (N'Phở Không', 30000, 40000, N'Chỉ có bánh phở và nước dùng', N'Phở không thịt');
END
GO

-- =============================================
-- Dữ liệu mẫu: MonAn_NguyenLieu (Liên kết món - nguyên liệu)
-- =============================================
IF NOT EXISTS (SELECT * FROM MonAn_NguyenLieu)
BEGIN
    DECLARE @MaPhBo int, @MaPhGa int, @MaPhDB int;
    DECLARE @MaBanhPho int, @MaThitBo int, @MaThitGa int, @MaNuocDung int, @MaHanhLa int, @MaNgoGai int;
    
    SELECT @MaPhBo = MaMon FROM MonAn WHERE TenMon = N'Phở Bò';
    SELECT @MaPhGa = MaMon FROM MonAn WHERE TenMon = N'Phở Gà';
    SELECT @MaPhDB = MaMon FROM MonAn WHERE TenMon = N'Phở Đặc Biệt';
    
    SELECT @MaBanhPho = MaNL FROM NguyenLieu WHERE TenNL = N'Bánh phở';
    SELECT @MaThitBo = MaNL FROM NguyenLieu WHERE TenNL = N'Thịt bò';
    SELECT @MaThitGa = MaNL FROM NguyenLieu WHERE TenNL = N'Thịt gà';
    SELECT @MaNuocDung = MaNL FROM NguyenLieu WHERE TenNL = N'Nước dùng';
    SELECT @MaHanhLa = MaNL FROM NguyenLieu WHERE TenNL = N'Hành lá';
    SELECT @MaNgoGai = MaNL FROM NguyenLieu WHERE TenNL = N'Ngò gai';
    
    -- Phở Bò: cần bánh phở, thịt bò, nước dùng, hành lá, ngò gai
    INSERT INTO [dbo].[MonAn_NguyenLieu] ([MaMon], [MaNL], [SoLuong])
    VALUES 
    (@MaPhBo, @MaBanhPho, 0.3), -- 0.3kg bánh phở
    (@MaPhBo, @MaThitBo, 0.15), -- 0.15kg thịt bò
    (@MaPhBo, @MaNuocDung, 0.5), -- 0.5 lít nước dùng
    (@MaPhBo, @MaHanhLa, 0.02), -- 0.02kg hành lá
    (@MaPhBo, @MaNgoGai, 0.01); -- 0.01kg ngò gai
    
    -- Phở Gà: cần bánh phở, thịt gà, nước dùng, hành lá, ngò gai
    INSERT INTO [dbo].[MonAn_NguyenLieu] ([MaMon], [MaNL], [SoLuong])
    VALUES 
    (@MaPhGa, @MaBanhPho, 0.3),
    (@MaPhGa, @MaThitGa, 0.15),
    (@MaPhGa, @MaNuocDung, 0.5),
    (@MaPhGa, @MaHanhLa, 0.02),
    (@MaPhGa, @MaNgoGai, 0.01);
    
    -- Phở Đặc Biệt: cần nhiều nguyên liệu hơn
    INSERT INTO [dbo].[MonAn_NguyenLieu] ([MaMon], [MaNL], [SoLuong])
    VALUES 
    (@MaPhDB, @MaBanhPho, 0.4),
    (@MaPhDB, @MaThitBo, 0.25),
    (@MaPhDB, @MaNuocDung, 0.6),
    (@MaPhDB, @MaHanhLa, 0.03),
    (@MaPhDB, @MaNgoGai, 0.02);
END
GO

-- =============================================
-- Dữ liệu mẫu: BanAn
-- =============================================
IF NOT EXISTS (SELECT * FROM BanAn WHERE TenBan = N'Bàn 1')
BEGIN
    INSERT INTO [dbo].[BanAn] ([TenBan], [TrangThai], [SoLuongGhe], [GhiChu])
    VALUES 
    (N'Bàn 1', N'Trống', 4, NULL),
    (N'Bàn 2', N'Trống', 4, NULL),
    (N'Bàn 3', N'Trống', 4, NULL),
    (N'Bàn 4', N'Trống', 6, NULL),
    (N'Bàn 5', N'Trống', 6, NULL),
    (N'Bàn 6', N'Trống', 2, NULL),
    (N'Bàn 7', N'Trống', 2, NULL),
    (N'Bàn 8', N'Trống', 4, NULL),
    (N'Bàn 9', N'Trống', 8, N'Bàn lớn'),
    (N'Bàn 10', N'Trống', 4, NULL);
END
GO

PRINT 'Thêm dữ liệu mẫu thành công!';
GO

