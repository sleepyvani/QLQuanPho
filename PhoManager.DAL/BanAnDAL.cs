using System.Collections.Generic;
using System.Linq;
using PhoManager.DTO;

namespace PhoManager.DAL
{
    public class BanAnDAL
    {
        public List<BanAnDTO> LayDanhSachBanAn()
        {
            using (var db = new PhoDataContext())
            {
                return db.BanAns
                    .OrderBy(b => b.TenBan)
                    .Select(b => b.ToDto())
                    .ToList();
            }
        }

        public BanAnDTO LayBanAnTheoMa(int maBan)
        {
            using (var db = new PhoDataContext())
            {
                return db.BanAns
                    .FirstOrDefault(b => b.MaBan == maBan)
                    ?.ToDto();
            }
        }

        public bool ThemBanAn(BanAnDTO banAn)
        {
            using (var db = new PhoDataContext())
            {
                var entity = new BanAnEntity
                {
                    TenBan = banAn.TenBan,
                    TrangThai = banAn.TrangThai,
                    SoLuongGhe = banAn.SoLuongGhe,
                    GhiChu = banAn.GhiChu
                };

                db.BanAns.InsertOnSubmit(entity);
                db.SubmitChanges();
                banAn.MaBan = entity.MaBan;
                return true;
            }
        }

        public bool CapNhatBanAn(BanAnDTO banAn)
        {
            using (var db = new PhoDataContext())
            {
                var entity = db.BanAns.SingleOrDefault(b => b.MaBan == banAn.MaBan);
                if (entity == null)
                {
                    return false;
                }

                entity.TenBan = banAn.TenBan;
                entity.TrangThai = banAn.TrangThai;
                entity.SoLuongGhe = banAn.SoLuongGhe;
                entity.GhiChu = banAn.GhiChu;

                db.SubmitChanges();
                return true;
            }
        }

        public bool CapNhatTrangThaiBan(int maBan, string trangThai)
        {
            using (var db = new PhoDataContext())
            {
                var entity = db.BanAns.SingleOrDefault(b => b.MaBan == maBan);
                if (entity == null)
                {
                    return false;
                }

                entity.TrangThai = trangThai;
                db.SubmitChanges();
                return true;
            }
        }

        public bool XoaBanAn(int maBan)
        {
            using (var db = new PhoDataContext())
            {
                var entity = db.BanAns.SingleOrDefault(b => b.MaBan == maBan);
                if (entity == null)
                {
                    return false;
                }

                db.BanAns.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
        }

        public List<BanAnDTO> LayDanhSachBanTrong()
        {
            using (var db = new PhoDataContext())
            {
                return db.BanAns
                    .Where(b => b.TrangThai == "Trống")
                    .OrderBy(b => b.TenBan)
                    .Select(b => b.ToDto())
                    .ToList();
            }
        }
    }
}

