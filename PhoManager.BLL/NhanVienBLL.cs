using System.Collections.Generic;
using PhoManager.DAL;
using PhoManager.DTO;

namespace PhoManager.BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL nhanVienDAL = new NhanVienDAL();
        /// <summary>
        /// Đăng nhập dựa trên tài khoản và mật khẩu. Kiểm tra đầu vào và ủy thác cho DAL xử lý.
        /// </summary>
        /// <param name="taiKhoan">Tên tài khoản.</param>
        /// <param name="matKhau">Mật khẩu thuần.</param>
        /// <returns>Đối tượng NhanVienDTO nếu đăng nhập thành công, ngược lại null.</returns>
        public NhanVienDTO DangNhap(string taiKhoan, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(taiKhoan) || string.IsNullOrWhiteSpace(matKhau))
            {
                return null;
            }
            return nhanVienDAL.DangNhap(taiKhoan, matKhau);
        }

        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            return nhanVienDAL.LayDanhSachNhanVien();
        }

        public NhanVienDTO LayNhanVienTheoMa(int maNV)
        {
            return nhanVienDAL.LayNhanVienTheoMa(maNV);
        }

        public string ThemNhanVien(NhanVienDTO nhanVien)
        {
            if (string.IsNullOrWhiteSpace(nhanVien.HoTen))
            {
                return "Họ tên không được để trống!";
            }

            if (string.IsNullOrWhiteSpace(nhanVien.TaiKhoan))
            {
                return "Tài khoản không được để trống!";
            }

            if (string.IsNullOrWhiteSpace(nhanVien.MatKhau))
            {
                return "Mật khẩu không được để trống!";
            }

            if (nhanVienDAL.KiemTraTaiKhoanTonTai(nhanVien.TaiKhoan))
            {
                return "Tài khoản đã tồn tại!";
            }

            if (nhanVienDAL.ThemNhanVien(nhanVien))
            {
                return "Thêm nhân viên thành công!";
            }

            return "Thêm nhân viên thất bại!";
        }

        public string CapNhatNhanVien(NhanVienDTO nhanVien)
        {
            if (string.IsNullOrWhiteSpace(nhanVien.HoTen))
            {
                return "Họ tên không được để trống!";
            }

            if (string.IsNullOrWhiteSpace(nhanVien.TaiKhoan))
            {
                return "Tài khoản không được để trống!";
            }

            if (string.IsNullOrWhiteSpace(nhanVien.MatKhau))
            {
                return "Mật khẩu không được để trống!";
            }

            if (nhanVienDAL.CapNhatNhanVien(nhanVien))
            {
                return "Cập nhật nhân viên thành công!";
            }

            return "Cập nhật nhân viên thất bại!";
        }

        public string XoaNhanVien(int maNV)
        {
            if (nhanVienDAL.XoaNhanVien(maNV))
            {
                return "Xóa nhân viên thành công!";
            }

            return "Xóa nhân viên thất bại!";
        }

        public string DoiMatKhau(int maNV, string matKhauCu, string matKhauMoi, string xacNhanMatKhau)
        {
            if (string.IsNullOrWhiteSpace(matKhauMoi))
            {
                return "Mật khẩu mới không được để trống!";
            }
            if (matKhauMoi != xacNhanMatKhau)
            {
                return "Mật khẩu xác nhận không khớp!";
            }
            // Lấy thông tin nhân viên từ cơ sở dữ liệu
            NhanVienDTO nhanVien = nhanVienDAL.LayNhanVienTheoMa(maNV);
            if (nhanVien == null)
            {
                return "Nhân viên không tồn tại!";
            }
            // Kiểm tra mật khẩu cũ có trùng khớp không
            if (!PhoManager.Utilities.PasswordHelper.VerifyPassword(matKhauCu, nhanVien.MatKhau))
            {
                return "Mật khẩu cũ không đúng!";
            }
            // Gọi DAL để đổi mật khẩu (sẽ tự băm mật khẩu nếu cần)
            if (nhanVienDAL.DoiMatKhau(maNV, matKhauMoi))
            {
                return "Đổi mật khẩu thành công!";
            }
            return "Đổi mật khẩu thất bại!";
        }
    }
}

