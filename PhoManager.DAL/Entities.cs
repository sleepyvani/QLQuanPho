using System;
using System.Data.Linq.Mapping;

namespace PhoManager.DAL
{
    [Table(Name = "dbo.MonAn")]
    public class MonAnEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaMon { get; set; }

        [Column]
        public string TenMon { get; set; }

        [Column]
        public decimal GiaNho { get; set; }

        [Column]
        public decimal GiaLon { get; set; }

        [Column(CanBeNull = true)]
        public string GhiChu { get; set; }

        [Column(CanBeNull = true)]
        public string MoTa { get; set; }

        [Column]
        public bool TrangThai { get; set; }

        [Column]
        public DateTime NgayTao { get; set; }
    }

    [Table(Name = "dbo.NguyenLieu")]
    public class NguyenLieuEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaNL { get; set; }

        [Column]
        public string TenNL { get; set; }

        [Column]
        public decimal SoLuongTon { get; set; }

        [Column]
        public string DonViTinh { get; set; }

        [Column(CanBeNull = true)]
        public decimal? GiaNhap { get; set; }

        [Column]
        public DateTime NgayCapNhat { get; set; }
    }

    [Table(Name = "dbo.MonAn_NguyenLieu")]
    public class MonAnNguyenLieuEntity
    {
        [Column(IsPrimaryKey = true)]
        public int MaMon { get; set; }

        [Column(IsPrimaryKey = true)]
        public int MaNL { get; set; }

        [Column]
        public decimal SoLuong { get; set; }
    }

    [Table(Name = "dbo.NhanVien")]
    public class NhanVienEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaNV { get; set; }

        [Column]
        public string HoTen { get; set; }

        [Column]
        public string TaiKhoan { get; set; }

        [Column]
        public string MatKhau { get; set; }

        [Column]
        public string ChucVu { get; set; }

        [Column]
        public DateTime NgayTao { get; set; }

        [Column]
        public bool TrangThai { get; set; }
    }

    [Table(Name = "dbo.BanAn")]
    public class BanAnEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaBan { get; set; }

        [Column]
        public string TenBan { get; set; }

        [Column]
        public string TrangThai { get; set; }

        [Column]
        public int SoLuongGhe { get; set; }

        [Column(CanBeNull = true)]
        public string GhiChu { get; set; }
    }

    [Table(Name = "dbo.HoaDon")]
    public class HoaDonEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaHD { get; set; }

        [Column]
        public int MaBan { get; set; }

        [Column]
        public int MaNV { get; set; }

        [Column]
        public DateTime NgayLap { get; set; }

        [Column]
        public decimal TongTien { get; set; }

        [Column]
        public decimal GiamGia { get; set; }

        [Column]
        public decimal Thue { get; set; }

        [Column]
        public decimal ThanhTien { get; set; }

        [Column(CanBeNull = true)]
        public string PhuongThucThanhToan { get; set; }

        [Column]
        public string TrangThai { get; set; }

        [Column(CanBeNull = true)]
        public string GhiChu { get; set; }
    }

    [Table(Name = "dbo.ChiTietHoaDon")]
    public class ChiTietHoaDonEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MaCTHD { get; set; }

        [Column]
        public int MaHD { get; set; }

        [Column]
        public int MaMon { get; set; }

        [Column]
        public int SoLuong { get; set; }

        [Column]
        public decimal DonGia { get; set; }

        [Column(CanBeNull = true)]
        public string KichCo { get; set; }

        [Column(CanBeNull = true)]
        public string GhiChu { get; set; }

        [Column]
        public decimal ThanhTien { get; set; }
    }
}
