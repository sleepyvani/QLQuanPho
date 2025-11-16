using System;
using System.Collections.Generic;
using System.Linq;
using PhoManager.DTO;

namespace PhoManager.DAL
{
    public class NhanVienDAL
    {
        /// <summary>
        /// Thực hiện đăng nhập dựa trên tài khoản và mật khẩu. Mật khẩu được so khớp qua hàm kiểm tra hash.
        /// </summary>
        /// <param name="taiKhoan">Tài khoản đăng nhập.</param>
        /// <param name="matKhau">Mật khẩu thuần nhập vào.</param>
        /// <returns>Đối tượng NhanVienDTO nếu thông tin đúng, ngược lại null.</returns>
        public NhanVienDTO DangNhap(string taiKhoan, string matKhau)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                // Truy xuất nhân viên theo tài khoản và trạng thái còn hoạt động
                var entity = db.NhanViens.FirstOrDefault(n => n.TaiKhoan == taiKhoan && n.TrangThai);
                if (entity == null)
                {
                    return null;
                }
                // So khớp mật khẩu bằng cách kiểm tra hash
                if (!PhoManager.Utilities.PasswordHelper.VerifyPassword(matKhau, entity.MatKhau))
                {
                    return null;
                }
                return new NhanVienDTO
                {
                    MaNV = entity.MaNV,
                    HoTen = entity.HoTen,
                    TaiKhoan = entity.TaiKhoan,
                    ChucVu = entity.ChucVu,
                    TrangThai = entity.TrangThai
                };
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
                try
                {
                    var entity = new NhanVien
                    {
                        HoTen = nhanVien.HoTen,
                        TaiKhoan = nhanVien.TaiKhoan,
                        // Lưu mật khẩu dưới dạng hash để tăng bảo mật
                        MatKhau = PhoManager.Utilities.PasswordHelper.IsHashed(nhanVien.MatKhau)
                            ? nhanVien.MatKhau
                            : PhoManager.Utilities.PasswordHelper.HashPassword(nhanVien.MatKhau),
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
                catch (Exception ex)
                {
                    // Ghi log lỗi và trả về false
                    PhoManager.Utilities.Logger.Error($"ThemNhanVien thất bại: {ex.Message}");
                    return false;
                }
            }
        }

        public bool CapNhatNhanVien(NhanVienDTO nhanVien)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                try
                {
                    var entity = db.NhanViens.SingleOrDefault(n => n.MaNV == nhanVien.MaNV);
                    if (entity == null)
                    {
                        return false;
                    }
                    entity.HoTen = nhanVien.HoTen;
                    entity.TaiKhoan = nhanVien.TaiKhoan;
                    // Nếu mật khẩu truyền vào chưa băm thì băm trước khi lưu
                    entity.MatKhau = PhoManager.Utilities.PasswordHelper.IsHashed(nhanVien.MatKhau)
                        ? nhanVien.MatKhau
                        : PhoManager.Utilities.PasswordHelper.HashPassword(nhanVien.MatKhau);
                    entity.ChucVu = nhanVien.ChucVu;
                    entity.TrangThai = nhanVien.TrangThai;
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    PhoManager.Utilities.Logger.Error($"CapNhatNhanVien thất bại: {ex.Message}");
                    return false;
                }
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
                try
                {
                    var entity = db.NhanViens.SingleOrDefault(n => n.MaNV == maNV);
                    if (entity == null)
                    {
                        return false;
                    }
                    // Băm mật khẩu mới trước khi lưu
                    entity.MatKhau = PhoManager.Utilities.PasswordHelper.IsHashed(matKhauMoi)
                        ? matKhauMoi
                        : PhoManager.Utilities.PasswordHelper.HashPassword(matKhauMoi);
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    PhoManager.Utilities.Logger.Error($"DoiMatKhau thất bại: {ex.Message}");
                    return false;
                }
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

