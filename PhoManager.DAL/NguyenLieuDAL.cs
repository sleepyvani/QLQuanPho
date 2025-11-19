using System;
using System.Collections.Generic;
using System.Linq;
using PhoManager.DTO;

namespace PhoManager.DAL
{
    /// <summary>
    /// Data access layer for the NguyenLieu table. Provides CRUD operations
    /// using LINQ to SQL through QLQuanPhoDataContext.
    /// </summary>
    public class NguyenLieuDAL
    {
        /// <summary>
        /// Lấy danh sách tất cả nguyên liệu, sắp xếp theo tên.
        /// </summary>
        public List<NguyenLieuDTO> LayDanhSachNguyenLieu()
        {
            using (var db = new QLQuanPhoDataContext())
            {
                return db.NguyenLieus
                    .OrderBy(nl => nl.TenNL)
                    .Select(nl => nl.ToDto())
                    .ToList();
            }
        }

        /// <summary>
        /// Thêm nguyên liệu mới vào cơ sở dữ liệu.
        /// </summary>
        public bool ThemNguyenLieu(NguyenLieuDTO nguyenLieu)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                var entity = new NguyenLieu
                {
                    TenNL = nguyenLieu.TenNL,
                    DonViTinh = nguyenLieu.DonViTinh,
                    SoLuongTon = nguyenLieu.SoLuongTon,
                    GiaNhap = nguyenLieu.GiaNhap,
                    NgayCapNhat = DateTime.Now
                };
                db.NguyenLieus.InsertOnSubmit(entity);
                db.SubmitChanges();

                // Sau khi thêm, cập nhật lại mã và ngày vào DTO
                nguyenLieu.MaNL = entity.MaNL;
                nguyenLieu.NgayCapNhat = entity.NgayCapNhat;
                return true;
            }
        }

        /// <summary>
        /// Cập nhật thông tin nguyên liệu.
        /// </summary>
        public bool CapNhatNguyenLieu(NguyenLieuDTO nguyenLieu)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                var entity = db.NguyenLieus.SingleOrDefault(nl => nl.MaNL == nguyenLieu.MaNL);
                if (entity == null)
                {
                    return false;
                }
                entity.TenNL = nguyenLieu.TenNL;
                entity.DonViTinh = nguyenLieu.DonViTinh;
                entity.SoLuongTon = nguyenLieu.SoLuongTon;
                entity.GiaNhap = nguyenLieu.GiaNhap;
                entity.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
        }

        /// <summary>
        /// Xóa nguyên liệu theo mã.
        /// </summary>
        public bool XoaNguyenLieu(int maNL)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                var entity = db.NguyenLieus.SingleOrDefault(nl => nl.MaNL == maNL);
                if (entity == null)
                {
                    return false;
                }
                db.NguyenLieus.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
        }

        /// <summary>
        /// Kiểm tra xem tên nguyên liệu đã tồn tại hay chưa.
        /// </summary>
        public bool KiemTraTenTrung(string tenNguyenLieu)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                return db.NguyenLieus.Any(nl => nl.TenNL.Trim().ToLower() == tenNguyenLieu.Trim().ToLower());
            }
        }
    }
}