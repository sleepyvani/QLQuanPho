-- =============================================
-- Sample Data cho hệ thống quản lý quán phở
-- Cung cấp dữ liệu mẫu mang tính thực tế để khởi tạo hệ thống
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
    (N'Nguyễn Văn A', 'admin', 'a6fb2f6a72814c70b6f36ade61b3fce7:77239889b9a8665774b5b6741d9fc863b436280f62501f275d807df82eef4380', N'Quản lý', 1),
    (N'Trần Thị Bình', 'thungan', '6852d07da3fa484db9d0b794aab499f1:60947dd0c2cae57ee607acaf5e0953a901bde4e5c35b666561aeaa0a8cc1f40e', N'Thu ngân', 1),
    (N'Lê Văn Cường', 'bep', 'd55f259da392427a88754bf9da188399:d200e1145cbca7305b37fd418b954d4b8f055ae6a97d02fd0d382d6e5b935b52', N'Bếp', 1),
    (N'Phạm Thị Duyên', 'phucvu', '0481a1f599bf4a2398572fe3a533e47d:9e34cd0e88aa973413af342345c4ad00110042a7b9e701110e46acbc438f8bc4', N'Phục vụ', 1),
    (N'Doàn Văn Huy', 'thungan2', 'e8611ac9fbdd4ad89e8191ac074249b1:870971340185f2783351bee1b454faf112c4f09a54ce728f5c50bb5ad1208a8b', N'Thu ngân', 1),
    (N'Đỗ Thị Lan', 'phache', '0e8f8a5f659b4ff99ff93e30835b1b5c:77bff83357e9cdffbe4128dd1b439618837cc23c073a461063571554a61f51af', N'Pha chế', 1);
END
GO

-- =============================================
-- Dữ liệu mẫu: NguyenLieu
-- =============================================
IF NOT EXISTS (SELECT * FROM NguyenLieu WHERE TenNL = N'Bánh phở')
BEGIN
    INSERT INTO [dbo].[NguyenLieu] ([TenNL], [SoLuongTon], [DonViTinh], [GiaNhap])
    VALUES 
    (N'Bánh phở', 200, N'kg', 50000),
    (N'Thịt bò', 80, N'kg', 220000),
    (N'Thịt gà', 60, N'kg', 120000),
    (N'Nước dùng', 400, N'lít', 0),
    (N'Hành lá', 30, N'kg', 30000),
    (N'Ngò gai', 20, N'kg', 40000),
    (N'Giá đỗ', 25, N'kg', 20000),
    (N'Gừng', 10, N'kg', 25000),
    (N'Hành tím', 10, N'kg', 30000),
    (N'Bắp bò', 50, N'kg', 220000),
    (N'Xương bò', 100, N'kg', 50000),
    (N'Bò viên', 40, N'kg', 150000);
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
    (N'Phở Đặc Biệt', 70000, 90000, N'Tô nhỏ: 70000đ, Tô lớn: 90000đ', N'Phở đặc biệt với nhiều loại thịt'),
    (N'Phở Bò Viên', 50000, 70000, N'Tô nhỏ: 50000đ, Tô lớn: 70000đ', N'Phở bò viên truyền thống'),
    (N'Phở Không', 30000, 40000, N'Tô nhỏ: 30000đ, Tô lớn: 40000đ', N'Chỉ có bánh phở và nước dùng'),
    (N'Phở Tái Nạm', 60000, 80000, N'Tô nhỏ: 60000đ, Tô lớn: 80000đ', N'Phở bò tái nạm'),
    (N'Phở Tái Gân', 60000, 80000, N'Tô nhỏ: 60000đ, Tô lớn: 80000đ', N'Phở bò tái gân');
END
GO

-- =============================================
-- Dữ liệu mẫu: MonAn_NguyenLieu (Liên kết món - nguyên liệu)
-- =============================================
IF NOT EXISTS (SELECT * FROM MonAn_NguyenLieu)
BEGIN
    DECLARE 
        @MaPhoBo INT, @MaPhoBoTai INT, @MaPhoGa INT, @MaPhoDB INT,
        @MaPhoBoVien INT, @MaPhoKhong INT, @MaPhoTaiNam INT, @MaPhoTaiGan INT,
        @MaBanhPho INT, @MaThitBo INT, @MaThitGa INT, @MaNuocDung INT,
        @MaHanhLa INT, @MaNgoGai INT, @MaGiaDo INT, @MaBapBo INT, @MaXuongBo INT, @MaBoVien INT;
    
    SELECT @MaPhoBo = MaMon FROM MonAn WHERE TenMon = N'Phở Bò';
    SELECT @MaPhoBoTai = MaMon FROM MonAn WHERE TenMon = N'Phở Bò Tái';
    SELECT @MaPhoGa = MaMon FROM MonAn WHERE TenMon = N'Phở Gà';
    SELECT @MaPhoDB = MaMon FROM MonAn WHERE TenMon = N'Phở Đặc Biệt';
    SELECT @MaPhoBoVien = MaMon FROM MonAn WHERE TenMon = N'Phở Bò Viên';
    SELECT @MaPhoKhong = MaMon FROM MonAn WHERE TenMon = N'Phở Không';
    SELECT @MaPhoTaiNam = MaMon FROM MonAn WHERE TenMon = N'Phở Tái Nạm';
    SELECT @MaPhoTaiGan = MaMon FROM MonAn WHERE TenMon = N'Phở Tái Gân';

    SELECT @MaBanhPho = MaNL FROM NguyenLieu WHERE TenNL = N'Bánh phở';
    SELECT @MaThitBo = MaNL FROM NguyenLieu WHERE TenNL = N'Thịt bò';
    SELECT @MaThitGa = MaNL FROM NguyenLieu WHERE TenNL = N'Thịt gà';
    SELECT @MaNuocDung = MaNL FROM NguyenLieu WHERE TenNL = N'Nước dùng';
    SELECT @MaHanhLa = MaNL FROM NguyenLieu WHERE TenNL = N'Hành lá';
    SELECT @MaNgoGai = MaNL FROM NguyenLieu WHERE TenNL = N'Ngò gai';
    SELECT @MaGiaDo = MaNL FROM NguyenLieu WHERE TenNL = N'Giá đỗ';
    SELECT @MaBapBo = MaNL FROM NguyenLieu WHERE TenNL = N'Bắp bò';
    SELECT @MaXuongBo = MaNL FROM NguyenLieu WHERE TenNL = N'Xương bò';
    SELECT @MaBoVien = MaNL FROM NguyenLieu WHERE TenNL = N'Bò viên';

    -- Phở Bò
    INSERT INTO [dbo].[MonAn_NguyenLieu] ([MaMon], [MaNL], [SoLuong])
    VALUES
    (@MaPhoBo, @MaBanhPho, 0.30),
    (@MaPhoBo, @MaThitBo, 0.15),
    (@MaPhoBo, @MaNuocDung, 0.50),
    (@MaPhoBo, @MaHanhLa, 0.02),
    (@MaPhoBo, @MaNgoGai, 0.01),
    (@MaPhoBo, @MaGiaDo, 0.03);

    -- Phở Bò Tái
    INSERT INTO [dbo].[MonAn_NguyenLieu] ([MaMon], [MaNL], [SoLuong])
    VALUES
    (@MaPhoBoTai, @MaBanhPho, 0.30),
    (@MaPhoBoTai, @MaThitBo, 0.15),
    (@MaPhoBoTai, @MaNuocDung, 0.50),
    (@MaPhoBoTai, @MaHanhLa, 0.02),
    (@MaPhoBoTai, @MaNgoGai, 0.01),
    (@MaPhoBoTai, @MaGiaDo, 0.03);

    -- Phở Gà
    INSERT INTO [dbo].[MonAn_NguyenLieu] ([MaMon], [MaNL], [SoLuong])
    VALUES
    (@MaPhoGa, @MaBanhPho, 0.30),
    (@MaPhoGa, @MaThitGa, 0.15),
    (@MaPhoGa, @MaNuocDung, 0.50),
    (@MaPhoGa, @MaHanhLa, 0.02),
    (@MaPhoGa, @MaNgoGai, 0.01),
    (@MaPhoGa, @MaGiaDo, 0.03);

    -- Phở Đặc Biệt
    INSERT INTO [dbo].[MonAn_NguyenLieu] ([MaMon], [MaNL], [SoLuong])
    VALUES
    (@MaPhoDB, @MaBanhPho, 0.40),
    (@MaPhoDB, @MaThitBo, 0.20),
    (@MaPhoDB, @MaBapBo, 0.10),
    (@MaPhoDB, @MaNuocDung, 0.60),
    (@MaPhoDB, @MaHanhLa, 0.03),
    (@MaPhoDB, @MaNgoGai, 0.02),
    (@MaPhoDB, @MaGiaDo, 0.04);

    -- Phở Bò Viên
    INSERT INTO [dbo].[MonAn_NguyenLieu] ([MaMon], [MaNL], [SoLuong])
    VALUES
    (@MaPhoBoVien, @MaBanhPho, 0.30),
    (@MaPhoBoVien, @MaBoVien, 0.20),
    (@MaPhoBoVien, @MaNuocDung, 0.50),
    (@MaPhoBoVien, @MaHanhLa, 0.02),
    (@MaPhoBoVien, @MaNgoGai, 0.01),
    (@MaPhoBoVien, @MaGiaDo, 0.03);

    -- Phở Không
    INSERT INTO [dbo].[MonAn_NguyenLieu] ([MaMon], [MaNL], [SoLuong])
    VALUES
    (@MaPhoKhong, @MaBanhPho, 0.30),
    (@MaPhoKhong, @MaNuocDung, 0.50),
    (@MaPhoKhong, @MaHanhLa, 0.02),
    (@MaPhoKhong, @MaNgoGai, 0.01),
    (@MaPhoKhong, @MaGiaDo, 0.03);

    -- Phở Tái Nạm
    INSERT INTO [dbo].[MonAn_NguyenLieu] ([MaMon], [MaNL], [SoLuong])
    VALUES
    (@MaPhoTaiNam, @MaBanhPho, 0.30),
    (@MaPhoTaiNam, @MaThitBo, 0.10),
    (@MaPhoTaiNam, @MaBapBo, 0.15),
    (@MaPhoTaiNam, @MaNuocDung, 0.50),
    (@MaPhoTaiNam, @MaHanhLa, 0.02),
    (@MaPhoTaiNam, @MaNgoGai, 0.01),
    (@MaPhoTaiNam, @MaGiaDo, 0.03);

    -- Phở Tái Gân
    INSERT INTO [dbo].[MonAn_NguyenLieu] ([MaMon], [MaNL], [SoLuong])
    VALUES
    (@MaPhoTaiGan, @MaBanhPho, 0.30),
    (@MaPhoTaiGan, @MaThitBo, 0.10),
    (@MaPhoTaiGan, @MaXuongBo, 0.15),
    (@MaPhoTaiGan, @MaNuocDung, 0.50),
    (@MaPhoTaiGan, @MaHanhLa, 0.02),
    (@MaPhoTaiGan, @MaNgoGai, 0.01),
    (@MaPhoTaiGan, @MaGiaDo, 0.03);
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

-- =============================================
-- Dữ liệu mẫu: THANH_VIEN_NHOM
-- =============================================
IF NOT EXISTS (SELECT * FROM THANH_VIEN_NHOM)
BEGIN
    INSERT INTO [dbo].[THANH_VIEN_NHOM] ([HoTen], [VaiTro], [MoTa], [ThuTu])
    VALUES 
    (N'Nguyễn Văn An', N'Trưởng nhóm', N'Phụ trách quản lý và điều phối công việc của nhóm', 1),
    (N'Trần Thị Bình', N'Thành viên', N'Chịu trách nhiệm về phần giao diện người dùng', 2),
    (N'Lê Văn Cường', N'Thành viên', N'Phát triển backend và xử lý dữ liệu', 3),
    (N'Phạm Thị Duyên', N'Thành viên', N'Kiểm thử và đảm bảo chất lượng sản phẩm', 4),
    (N'Hoàng Văn Đức', N'Thành viên', N'Thiết kế database và tối ưu hiệu năng', 5),
    (N'Vũ Thị Hoa', N'Thành viên', N'Phát triển tính năng báo cáo và thống kê', 6);
END
GO

PRINT N'Thêm dữ liệu mẫu thành công!';

-- =============================================
-- Dữ liệu mẫu: HoaDon và ChiTietHoaDon
-- Tạo một số hóa đơn mẫu cùng chi tiết để người dùng có thể xem báo cáo và thống kê.
-- Các hóa đơn được tạo cách ngày hiện tại một số ngày để trải rộng thời gian.
-- =============================================
IF NOT EXISTS (SELECT * FROM HoaDon)
BEGIN
    -- Lấy mã nhân viên cho các tài khoản mẫu
    DECLARE @MaNV_ThuNgan INT, @MaNV_ThuNgan2 INT, @MaNV_PhucVu INT;
    SELECT @MaNV_ThuNgan = MaNV FROM NhanVien WHERE TaiKhoan = 'thungan';
    SELECT @MaNV_ThuNgan2 = MaNV FROM NhanVien WHERE TaiKhoan = 'thungan2';
    SELECT @MaNV_PhucVu = MaNV FROM NhanVien WHERE TaiKhoan = 'phucvu';

    -- Lấy mã bàn
    DECLARE @MaBan1 INT, @MaBan2 INT, @MaBan5 INT;
    SELECT @MaBan1 = MaBan FROM BanAn WHERE TenBan = N'Bàn 1';
    SELECT @MaBan2 = MaBan FROM BanAn WHERE TenBan = N'Bàn 2';
    SELECT @MaBan5 = MaBan FROM BanAn WHERE TenBan = N'Bàn 5';

    -- Thêm ba hóa đơn mẫu với tổng tiền, giảm giá, thuế và thành tiền đã tính sẵn
    -- Hóa đơn 1: 2 tô Phở Bò nhỏ + 1 tô Phở Gà lớn, không giảm giá, thuế 10%
    INSERT INTO [dbo].[HoaDon] ([MaBan], [MaNV], [NgayLap], [TongTien], [GiamGia], [Thue], [ThanhTien], [PhuongThucThanhToan], [TrangThai], [GhiChu])
    VALUES
    (@MaBan1, @MaNV_ThuNgan, DATEADD(day, -15, GETDATE()), 165000, 0, 10, 181500, N'Tiền mặt', N'Đã thanh toán', N'Hóa đơn mẫu 1'),
    -- Hóa đơn 2: 1 tô Phở Bò Viên nhỏ + 2 tô Phở Đặc Biệt lớn, giảm 10k, thuế 5%
    (@MaBan2, @MaNV_ThuNgan2, DATEADD(day, -13, GETDATE()), 230000, 10000, 5, 231000, N'Tiền mặt', N'Đã thanh toán', N'Hóa đơn mẫu 2'),
    -- Hóa đơn 3: 1 tô Phở Không nhỏ + 1 tô Phở Tái Nạm nhỏ + 1 tô Phở Tái Gân lớn, không giảm giá, thuế 8%
    (@MaBan5, @MaNV_PhucVu, DATEADD(day, -7, GETDATE()), 170000, 0, 8, 183600, N'Tiền mặt', N'Đã thanh toán', N'Hóa đơn mẫu 3');

    -- Lấy mã hóa đơn vừa thêm để thêm chi tiết
    DECLARE @MaHD1 INT = (SELECT TOP 1 MaHD FROM HoaDon WHERE TongTien = 165000 AND MaBan = @MaBan1 ORDER BY MaHD DESC);
    DECLARE @MaHD2 INT = (SELECT TOP 1 MaHD FROM HoaDon WHERE TongTien = 230000 AND MaBan = @MaBan2 ORDER BY MaHD DESC);
    DECLARE @MaHD3 INT = (SELECT TOP 1 MaHD FROM HoaDon WHERE TongTien = 170000 AND MaBan = @MaBan5 ORDER BY MaHD DESC);

    -- Lấy mã món ăn
    DECLARE @MonPhoBo INT = (SELECT MaMon FROM MonAn WHERE TenMon = N'Phở Bò');
    DECLARE @MonPhoGa INT = (SELECT MaMon FROM MonAn WHERE TenMon = N'Phở Gà');
    DECLARE @MonPhoBoVien INT = (SELECT MaMon FROM MonAn WHERE TenMon = N'Phở Bò Viên');
    DECLARE @MonPhoDB INT = (SELECT MaMon FROM MonAn WHERE TenMon = N'Phở Đặc Biệt');
    DECLARE @MonPhoKhong INT = (SELECT MaMon FROM MonAn WHERE TenMon = N'Phở Không');
    DECLARE @MonPhoTaiNam INT = (SELECT MaMon FROM MonAn WHERE TenMon = N'Phở Tái Nạm');
    DECLARE @MonPhoTaiGan INT = (SELECT MaMon FROM MonAn WHERE TenMon = N'Phở Tái Gân');

    -- Chi tiết hóa đơn 1
    INSERT INTO [dbo].[ChiTietHoaDon] ([MaHD], [MaMon], [SoLuong], [DonGia], [KichCo], [GhiChu], [ThanhTien])
    VALUES
    (@MaHD1, @MonPhoBo, 2, 50000, N'Nhỏ', N'', 100000),
    (@MaHD1, @MonPhoGa, 1, 65000, N'Lớn', N'', 65000);

    -- Chi tiết hóa đơn 2
    INSERT INTO [dbo].[ChiTietHoaDon] ([MaHD], [MaMon], [SoLuong], [DonGia], [KichCo], [GhiChu], [ThanhTien])
    VALUES
    (@MaHD2, @MonPhoBoVien, 1, 50000, N'Nhỏ', N'', 50000),
    (@MaHD2, @MonPhoDB, 2, 90000, N'Lớn', N'', 180000);

    -- Chi tiết hóa đơn 3
    INSERT INTO [dbo].[ChiTietHoaDon] ([MaHD], [MaMon], [SoLuong], [DonGia], [KichCo], [GhiChu], [ThanhTien])
    VALUES
    (@MaHD3, @MonPhoKhong, 1, 30000, N'Nhỏ', N'', 30000),
    (@MaHD3, @MonPhoTaiNam, 1, 60000, N'Nhỏ', N'', 60000),
    (@MaHD3, @MonPhoTaiGan, 1, 80000, N'Lớn', N'', 80000);
END
GO
GO
