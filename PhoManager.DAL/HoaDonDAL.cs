using System;
using System.Collections.Generic;
using System.Linq;
using PhoManager.DTO;

namespace PhoManager.DAL
{
    public class HoaDonDAL
    {
        public int TaoHoaDon(HoaDonDTO hoaDon)
        {
            using (var db = new PhoDataContext())
            {
                var entity = new HoaDonEntity
                {
                    MaBan = hoaDon.MaBan,
                    MaNV = hoaDon.MaNV,
                    NgayLap = hoaDon.NgayLap,
                    TongTien = hoaDon.TongTien,
                    GiamGia = hoaDon.GiamGia,
                    Thue = hoaDon.Thue,
                    ThanhTien = hoaDon.ThanhTien,
                    PhuongThucThanhToan = hoaDon.PhuongThucThanhToan,
                    TrangThai = hoaDon.TrangThai,
                    GhiChu = hoaDon.GhiChu
                };

                db.HoaDons.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.MaHD;
            }
        }

        public bool ThemChiTietHoaDon(ChiTietHoaDonDTO chiTiet)
        {
            using (var db = new PhoDataContext())
            {
                var entity = new ChiTietHoaDonEntity
                {
                    MaHD = chiTiet.MaHD,
                    MaMon = chiTiet.MaMon,
                    SoLuong = chiTiet.SoLuong,
                    DonGia = chiTiet.DonGia,
                    KichCo = chiTiet.KichCo,
                    GhiChu = chiTiet.GhiChu,
                    ThanhTien = chiTiet.ThanhTien
                };

                db.ChiTietHoaDons.InsertOnSubmit(entity);
                db.SubmitChanges();
                chiTiet.MaCTHD = entity.MaCTHD;
                return true;
            }
        }

        public HoaDonDTO LayHoaDonTheoMa(int maHD)
        {
            using (var db = new PhoDataContext())
            {
                var result = (from hd in db.HoaDons
                              join b in db.BanAns on hd.MaBan equals b.MaBan
                              join nv in db.NhanViens on hd.MaNV equals nv.MaNV
                              where hd.MaHD == maHD
                              select new { hd, b.TenBan, nv.HoTen }).FirstOrDefault();

                if (result == null)
                {
                    return null;
                }

                var chiTiet = LayChiTietHoaDon(db, maHD);
                return result.hd.ToDto(result.TenBan, result.HoTen, chiTiet);
            }
        }

        public HoaDonDTO LayHoaDonChuaThanhToanTheoBan(int maBan)
        {
            using (var db = new PhoDataContext())
            {
                var result = (from hd in db.HoaDons
                              join b in db.BanAns on hd.MaBan equals b.MaBan
                              join nv in db.NhanViens on hd.MaNV equals nv.MaNV
                              where hd.MaBan == maBan && hd.TrangThai == "Chưa thanh toán"
                              orderby hd.NgayLap descending
                              select new { hd, b.TenBan, nv.HoTen }).FirstOrDefault();

                if (result == null)
                {
                    return null;
                }

                var chiTiet = LayChiTietHoaDon(db, result.hd.MaHD);
                return result.hd.ToDto(result.TenBan, result.HoTen, chiTiet);
            }
        }

        public List<ChiTietHoaDonDTO> LayChiTietHoaDon(int maHD)
        {
            using (var db = new PhoDataContext())
            {
                return LayChiTietHoaDon(db, maHD);
            }
        }

        public bool CapNhatHoaDon(HoaDonDTO hoaDon)
        {
            using (var db = new PhoDataContext())
            {
                var entity = db.HoaDons.SingleOrDefault(h => h.MaHD == hoaDon.MaHD);
                if (entity == null)
                {
                    return false;
                }

                entity.TongTien = hoaDon.TongTien;
                entity.GiamGia = hoaDon.GiamGia;
                entity.Thue = hoaDon.Thue;
                entity.ThanhTien = hoaDon.ThanhTien;
                entity.PhuongThucThanhToan = hoaDon.PhuongThucThanhToan;
                entity.TrangThai = hoaDon.TrangThai;
                entity.GhiChu = hoaDon.GhiChu;
                entity.NgayLap = hoaDon.NgayLap;

                db.SubmitChanges();
                return true;
            }
        }

        public bool XoaChiTietHoaDon(int maCTHD)
        {
            using (var db = new PhoDataContext())
            {
                var entity = db.ChiTietHoaDons.SingleOrDefault(ct => ct.MaCTHD == maCTHD);
                if (entity == null)
                {
                    return false;
                }

                db.ChiTietHoaDons.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
        }

        public List<HoaDonDTO> LayDanhSachHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new PhoDataContext())
            {
                return (from hd in db.HoaDons
                        join b in db.BanAns on hd.MaBan equals b.MaBan
                        join nv in db.NhanViens on hd.MaNV equals nv.MaNV
                        where hd.NgayLap >= tuNgay && hd.NgayLap <= denNgay
                        orderby hd.NgayLap descending
                        select hd.ToDto(b.TenBan, nv.HoTen, null)).ToList();
            }
        }

        private List<ChiTietHoaDonDTO> LayChiTietHoaDon(PhoDataContext db, int maHD)
        {
            return (from ct in db.ChiTietHoaDons
                    join m in db.MonAns on ct.MaMon equals m.MaMon
                    where ct.MaHD == maHD
                    select ct.ToDto(m.TenMon)).ToList();
        }
    }
}

