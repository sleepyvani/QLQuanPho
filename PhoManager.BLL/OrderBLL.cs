using System;
using PhoManager.DAL;
using PhoManager.DTO;
using PhoManager.BLL;

namespace PhoManager.BLL
{
    public class OrderBLL
    {
        private HoaDonBLL hoaDonBLL = new HoaDonBLL();
        private MonAnDAL monAnDAL = new MonAnDAL();
        public string TaoOrder(int maBan, int maNV, ChiTietHoaDonDTO chiTiet)
        {
            MonAnDTO monAn = monAnDAL.LayMonAnTheoMa(chiTiet.MaMon);
            if (monAn == null)
            {
                return "Món ăn không tồn tại!";
            }

            if (!monAn.TrangThai)
            {
                return "Món ăn đã ngừng bán!";
            }

            if (chiTiet.KichCo == "Lớn")
            {
                chiTiet.DonGia = monAn.GiaLon;
            }
            else
            {
                chiTiet.DonGia = monAn.GiaNho;
            }

            HoaDonDTO hoaDon = hoaDonBLL.LayHoaDonChuaThanhToanTheoBan(maBan);

            if (hoaDon == null)
            {
                hoaDon = new HoaDonDTO
                {
                    MaBan = maBan,
                    MaNV = maNV,
                    NgayLap = DateTime.Now,
                    TongTien = 0,
                    GiamGia = 0,
                    Thue = 0,
                    ThanhTien = 0,
                    TrangThai = "Chưa thanh toán"
                };
                hoaDon.ChiTietHoaDon.Add(chiTiet);

                int maHD = hoaDonBLL.TaoHoaDon(hoaDon);
                if (maHD > 0)
                {
                    return "Tạo order thành công!";
                }
                else
                {
                    return "Tạo order thất bại!";
                }
            }
            else
            {
                bool result = hoaDonBLL.ThemMonVaoHoaDon(hoaDon.MaHD, chiTiet);
                if (result)
                {
                    return "Thêm món vào order thành công!";
                }
                else
                {
                    return "Thêm món vào order thất bại!";
                }
            }
        }

        public string XoaMonKhoiOrder(int maCTHD, int maHD)
        {
            bool result = hoaDonBLL.XoaMonKhoiHoaDon(maCTHD, maHD);
            if (result)
            {
                return "Xóa món khỏi order thành công!";
            }
            return "Xóa món khỏi order thất bại!";
        }
    }
}

