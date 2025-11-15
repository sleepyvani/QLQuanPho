using System.Collections.Generic;
using PhoManager.DAL;
using PhoManager.DTO;

namespace PhoManager.BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL nhanVienDAL = new NhanVienDAL();
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

            NhanVienDTO nhanVien = nhanVienDAL.LayNhanVienTheoMa(maNV);
            if (nhanVien == null || nhanVien.MatKhau != matKhauCu)
            {
                return "Mật khẩu cũ không đúng!";
            }

            if (nhanVienDAL.DoiMatKhau(maNV, matKhauMoi))
            {
                return "Đổi mật khẩu thành công!";
            }

            return "Đổi mật khẩu thất bại!";
        }
    }
}

