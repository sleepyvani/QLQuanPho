using System;
using System.Collections.Generic;
using System.Linq;
using PhoManager.DTO;

namespace PhoManager.DAL
{
    public class NhanVienDAL
    {
        public NhanVienDTO DangNhap(string taiKhoan, string matKhau)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                return db.NhanViens
                    .Where(n => n.TaiKhoan == taiKhoan && n.MatKhau == matKhau && n.TrangThai)
                    .Select(n => new NhanVienDTO
                    {
                        MaNV = n.MaNV,
                        HoTen = n.HoTen,
                        TaiKhoan = n.TaiKhoan,
                        ChucVu = n.ChucVu,
                        TrangThai = n.TrangThai
                    })
                    .FirstOrDefault();
            }
        }

        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            using (var db = new QLQuanPhoDataContext())
            {
                return db.NhanViens
                    .OrderBy(n => n.HoTen)
                    .Select(n => n.ToDto())
                    .ToList();
            }
        }

        public NhanVienDTO LayNhanVienTheoMa(int maNV)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                return db.NhanViens
                    .FirstOrDefault(n => n.MaNV == maNV)
                    ?.ToDto();
            }
        }

        public bool ThemNhanVien(NhanVienDTO nhanVien)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                var entity = new NhanVien
                {
                    HoTen = nhanVien.HoTen,
                    TaiKhoan = nhanVien.TaiKhoan,
                    MatKhau = nhanVien.MatKhau,
                    ChucVu = nhanVien.ChucVu,
                    TrangThai = nhanVien.TrangThai,
                    NgayTao = DateTime.Now
                };

                db.NhanViens.InsertOnSubmit(entity);
                db.SubmitChanges();
                nhanVien.MaNV = entity.MaNV;
                nhanVien.NgayTao = entity.NgayTao;
                return true;
            }
        }

        public bool CapNhatNhanVien(NhanVienDTO nhanVien)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                var entity = db.NhanViens.SingleOrDefault(n => n.MaNV == nhanVien.MaNV);
                if (entity == null)
                {
                    return false;
                }

                entity.HoTen = nhanVien.HoTen;
                entity.TaiKhoan = nhanVien.TaiKhoan;
                entity.MatKhau = nhanVien.MatKhau;
                entity.ChucVu = nhanVien.ChucVu;
                entity.TrangThai = nhanVien.TrangThai;

                db.SubmitChanges();
                return true;
            }
        }

        public bool XoaNhanVien(int maNV)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                var entity = db.NhanViens.SingleOrDefault(n => n.MaNV == maNV);
                if (entity == null)
                {
                    return false;
                }

                db.NhanViens.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
        }

        public bool DoiMatKhau(int maNV, string matKhauMoi)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                var entity = db.NhanViens.SingleOrDefault(n => n.MaNV == maNV);
                if (entity == null)
                {
                    return false;
                }

                entity.MatKhau = matKhauMoi;
                db.SubmitChanges();
                return true;
            }
        }

        public bool KiemTraTaiKhoanTonTai(string taiKhoan)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                return db.NhanViens.Any(n => n.TaiKhoan == taiKhoan);
            }
        }
    }
}

