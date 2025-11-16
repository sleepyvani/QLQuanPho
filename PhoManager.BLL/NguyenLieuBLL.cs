using System;
using System.Collections.Generic;
using PhoManager.DAL;
using PhoManager.DTO;

namespace PhoManager.BLL
{
    /// <summary>
    /// Business logic layer for NguyenLieu. Encapsulates validation and calls to DAL.
    /// </summary>
    public class NguyenLieuBLL
    {
        private readonly NguyenLieuDAL dal = new NguyenLieuDAL();

        /// <summary>
        /// Lấy danh sách nguyên liệu trong kho.
        /// </summary>
        public List<NguyenLieuDTO> LayDanhSachNguyenLieu()
        {
            return dal.LayDanhSachNguyenLieu();
        }

        /// <summary>
        /// Thêm nguyên liệu mới. Kiểm tra trùng tên và trường bắt buộc.
        /// </summary>
        public string ThemNguyenLieu(NguyenLieuDTO nguyenLieu)
        {
            if (nguyenLieu == null)
            {
                return "Dữ liệu nguyên liệu không hợp lệ!";
            }
            if (string.IsNullOrWhiteSpace(nguyenLieu.TenNL))
            {
                return "Tên nguyên liệu không được để trống!";
            }
            if (dal.KiemTraTenTrung(nguyenLieu.TenNL))
            {
                return "Tên nguyên liệu đã tồn tại!";
            }
            if (dal.ThemNguyenLieu(nguyenLieu))
            {
                return "Thêm nguyên liệu thành công!";
            }
            return "Thêm nguyên liệu thất bại!";
        }

        /// <summary>
        /// Cập nhật thông tin nguyên liệu. Kiểm tra tên và số lượng.
        /// </summary>
        public string CapNhatNguyenLieu(NguyenLieuDTO nguyenLieu)
        {
            if (nguyenLieu == null)
            {
                return "Dữ liệu nguyên liệu không hợp lệ!";
            }
            if (string.IsNullOrWhiteSpace(nguyenLieu.TenNL))
            {
                return "Tên nguyên liệu không được để trống!";
            }
            if (dal.CapNhatNguyenLieu(nguyenLieu))
            {
                return "Cập nhật nguyên liệu thành công!";
            }
            return "Cập nhật nguyên liệu thất bại!";
        }

        /// <summary>
        /// Xóa nguyên liệu theo mã.
        /// </summary>
        public string XoaNguyenLieu(int maNL)
        {
            if (dal.XoaNguyenLieu(maNL))
            {
                return "Xóa nguyên liệu thành công!";
            }
            return "Xóa nguyên liệu thất bại!";
        }
    }
}