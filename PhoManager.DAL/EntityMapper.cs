using System.Collections.Generic;
using System.Linq;
using PhoManager.DTO;

namespace PhoManager.DAL
{
    internal static class EntityMapper
    {
        public static MonAnDTO ToDto(this MonAnEntity entity)
        {
            if (entity == null) return null;

            return new MonAnDTO
            {
                MaMon = entity.MaMon,
                TenMon = entity.TenMon,
                GiaNho = entity.GiaNho,
                GiaLon = entity.GiaLon,
                GhiChu = entity.GhiChu,
                MoTa = entity.MoTa,
                TrangThai = entity.TrangThai,
                NgayTao = entity.NgayTao
            };
        }

        public static NhanVienDTO ToDto(this NhanVienEntity entity)
        {
            if (entity == null) return null;

            return new NhanVienDTO
            {
                MaNV = entity.MaNV,
                HoTen = entity.HoTen,
                TaiKhoan = entity.TaiKhoan,
                MatKhau = entity.MatKhau,
                ChucVu = entity.ChucVu,
                NgayTao = entity.NgayTao,
                TrangThai = entity.TrangThai
            };
        }

        public static BanAnDTO ToDto(this BanAnEntity entity)
        {
            if (entity == null) return null;

            return new BanAnDTO
            {
                MaBan = entity.MaBan,
                TenBan = entity.TenBan,
                TrangThai = entity.TrangThai,
                SoLuongGhe = entity.SoLuongGhe,
                GhiChu = entity.GhiChu
            };
        }

        public static NguyenLieuDTO ToDto(this NguyenLieuEntity entity)
        {
            if (entity == null) return null;

            return new NguyenLieuDTO
            {
                MaNL = entity.MaNL,
                TenNL = entity.TenNL,
                SoLuongTon = entity.SoLuongTon,
                DonViTinh = entity.DonViTinh,
                GiaNhap = entity.GiaNhap,
                NgayCapNhat = entity.NgayCapNhat
            };
        }

        public static ChiTietHoaDonDTO ToDto(this ChiTietHoaDonEntity entity, string tenMon)
        {
            if (entity == null) return null;

            return new ChiTietHoaDonDTO
            {
                MaCTHD = entity.MaCTHD,
                MaHD = entity.MaHD,
                MaMon = entity.MaMon,
                SoLuong = entity.SoLuong,
                DonGia = entity.DonGia,
                KichCo = entity.KichCo,
                GhiChu = entity.GhiChu,
                ThanhTien = entity.ThanhTien,
                TenMon = tenMon
            };
        }

        public static HoaDonDTO ToDto(
            this HoaDonEntity entity,
            string tenBan,
            string tenNhanVien,
            IEnumerable<ChiTietHoaDonDTO> chiTiet)
        {
            if (entity == null) return null;

            return new HoaDonDTO
            {
                MaHD = entity.MaHD,
                MaBan = entity.MaBan,
                MaNV = entity.MaNV,
                NgayLap = entity.NgayLap,
                TongTien = entity.TongTien,
                GiamGia = entity.GiamGia,
                Thue = entity.Thue,
                ThanhTien = entity.ThanhTien,
                PhuongThucThanhToan = entity.PhuongThucThanhToan,
                TrangThai = entity.TrangThai,
                GhiChu = entity.GhiChu,
                TenBan = tenBan,
                TenNhanVien = tenNhanVien,
                ChiTietHoaDon = chiTiet?.ToList() ?? new List<ChiTietHoaDonDTO>()
            };
        }
    }
}
