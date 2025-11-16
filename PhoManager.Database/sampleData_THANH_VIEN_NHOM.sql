-- =============================================
-- Sample Data cho bảng THANH_VIEN_NHOM
-- Script này có thể chạy độc lập để thêm dữ liệu mẫu
-- =============================================

USE QLQuanPho;
GO

-- Kiểm tra và thêm dữ liệu mẫu
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
    
    PRINT N'Đã thêm 6 bản ghi vào bảng THANH_VIEN_NHOM thành công!';
END
ELSE
BEGIN
    PRINT N'Bảng THANH_VIEN_NHOM đã có dữ liệu. Bỏ qua việc thêm dữ liệu mẫu.';
END
GO

-- Hiển thị dữ liệu đã thêm
SELECT * FROM [dbo].[THANH_VIEN_NHOM] ORDER BY [ThuTu];
GO

