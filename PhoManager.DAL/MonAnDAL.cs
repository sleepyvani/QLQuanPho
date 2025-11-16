using System;
using System.Collections.Generic;
using System.Linq;
using PhoManager.DTO;

namespace PhoManager.DAL
{
    public class MonAnDAL
    {
        public List<MonAnDTO> LayDanhSachMonAn()
        {
            using (var db = new QLQuanPhoDataContext())
            {
                return db.MonAns
                    .OrderBy(m => m.TenMon)
                    .Select(m => m.ToDto())
                    .ToList();
            }
        }
    
        public MonAnDTO LayMonAnTheoMa(int maMon)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                return db.MonAns
                    .FirstOrDefault(m => m.MaMon == maMon)
                    ?.ToDto();
            }
        }

        public bool ThemMonAn(MonAnDTO monAn)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                var entity = new MonAn
                {
                    TenMon = monAn.TenMon,
                    GiaNho = monAn.GiaNho,
                    GiaLon = monAn.GiaLon,
                    GhiChu = monAn.GhiChu,
                    MoTa = monAn.MoTa,
                    TrangThai = monAn.TrangThai,
                    NgayTao = DateTime.Now
                };

                db.MonAns.InsertOnSubmit(entity);
                db.SubmitChanges();
                monAn.MaMon = entity.MaMon;
                monAn.NgayTao = entity.NgayTao;
                return true;
            }
        }

        public bool CapNhatMonAn(MonAnDTO monAn)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                var entity = db.MonAns.SingleOrDefault(m => m.MaMon == monAn.MaMon);
                if (entity == null)
                {
                    return false;
                }

                entity.TenMon = monAn.TenMon;
                entity.GiaNho = monAn.GiaNho;
                entity.GiaLon = monAn.GiaLon;
                entity.GhiChu = monAn.GhiChu;
                entity.MoTa = monAn.MoTa;
                entity.TrangThai = monAn.TrangThai;

                db.SubmitChanges();
                return true;
            }
        }

        public string XoaMonAn(int maMon)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                var monAn = db.MonAns.SingleOrDefault(m => m.MaMon == maMon);
                if (monAn == null)
                {
                    return "Món ãn không t?n t?i.";
                }

                bool dangDuocSuDung = db.ChiTietHoaDons.Any(ct => ct.MaMon == maMon);
                if (dangDuocSuDung)
                {
                    return "Món ãn này ð? ðý?c s? d?ng trong hóa ðõn, không th? xóa!";
                }

                db.MonAns.DeleteOnSubmit(monAn);
                db.SubmitChanges();
                return "Xóa món ãn thành công.";
            }
        }

        public string NgungBanMonAn(int maMon)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                var monAn = db.MonAns.SingleOrDefault(m => m.MaMon == maMon);
                if (monAn == null)
                    return "Món ãn không t?n t?i.";

                monAn.TrangThai = false; 
                db.SubmitChanges();
                return "Ð? chuy?n món ãn sang tr?ng thái ng?ng bán.";
            }
        }

        public List<MonAnDTO> LayDanhSachMonAnDangBan()
        {
            using (var db = new QLQuanPhoDataContext())
            {
                return db.MonAns
                         .Where(m => m.TrangThai == true)
                         .Select(m => new MonAnDTO
                         {
                             MaMon = m.MaMon,
                             TenMon = m.TenMon,
                             GiaNho = m.GiaNho,
                             GiaLon = m.GiaLon,
                             TrangThai = m.TrangThai
                         }).ToList();
            }
        }

        public List<MonAnDTO> TimKiemMonAn(string tenMon)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                tenMon = tenMon?.Trim() ?? string.Empty;

                return db.MonAns
                    .Where(m => m.TenMon.Contains(tenMon))
                    .OrderBy(m => m.TenMon)
                    .Select(m => m.ToDto())
                    .ToList();
            }
        }
    }
}

