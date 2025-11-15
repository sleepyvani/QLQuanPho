using System;
using System.Collections.Generic;
using PhoManager.DAL;
using PhoManager.DTO;

namespace PhoManager.BLL
{
    public class HoaDonBLL
    {
        private HoaDonDAL hoaDonDAL = new HoaDonDAL();
        private BanAnDAL banAnDAL = new BanAnDAL();
        public int TaoHoaDon(HoaDonDTO hoaDon)
        {
            hoaDon.TongTien = TinhTongTien(hoaDon.ChiTietHoaDon);
            hoaDon.ThanhTien = TinhThanhTien(hoaDon.TongTien, hoaDon.GiamGia, hoaDon.Thue);
            int maHD = hoaDonDAL.TaoHoaDon(hoaDon);
            if (maHD > 0)
            {
                foreach (var chiTiet in hoaDon.ChiTietHoaDon)
                {
                    chiTiet.MaHD = maHD;
                    chiTiet.ThanhTien = chiTiet.SoLuong * chiTiet.DonGia;
                    hoaDonDAL.ThemChiTietHoaDon(chiTiet);
                }
                banAnDAL.CapNhatTrangThaiBan(hoaDon.MaBan, "Có khách");
            }
            
            return maHD;
        }
        public HoaDonDTO LayHoaDonTheoMa(int maHD)
        {
            return hoaDonDAL.LayHoaDonTheoMa(maHD);
        }
        public HoaDonDTO LayHoaDonChuaThanhToanTheoBan(int maBan)
        {
            return hoaDonDAL.LayHoaDonChuaThanhToanTheoBan(maBan);
        }
        public bool ThemMonVaoHoaDon(int maHD, ChiTietHoaDonDTO chiTiet)
        {
            chiTiet.MaHD = maHD;
            chiTiet.ThanhTien = chiTiet.SoLuong * chiTiet.DonGia;
            
            bool result = hoaDonDAL.ThemChiTietHoaDon(chiTiet);
            
            if (result)
            {
                CapNhatTongTienHoaDon(maHD);
            }
            
            return result;
        }
        public bool XoaMonKhoiHoaDon(int maCTHD, int maHD)
        {
            bool result = hoaDonDAL.XoaChiTietHoaDon(maCTHD);
            
            if (result)
            {
                CapNhatTongTienHoaDon(maHD);
            }
            
            return result;
        }
        public bool ThanhToanHoaDon(HoaDonDTO hoaDon)
        {
            hoaDon.TrangThai = "Đã thanh toán";
            hoaDon.NgayLap = DateTime.Now;
            
            bool result = hoaDonDAL.CapNhatHoaDon(hoaDon);
            
            if (result)
            {
                banAnDAL.CapNhatTrangThaiBan(hoaDon.MaBan, "Trống");
            }
            
            return result;
        }
        private decimal TinhTongTien(List<ChiTietHoaDonDTO> chiTietHoaDon)
        {
            decimal tongTien = 0;
            foreach (var chiTiet in chiTietHoaDon)
            {
                tongTien += chiTiet.SoLuong * chiTiet.DonGia;
            }
            return tongTien;
        }
        private decimal TinhThanhTien(decimal tongTien, decimal giamGia, decimal thue)
        {
            decimal thanhTien = tongTien - giamGia;
            thanhTien += thanhTien * thue / 100;
            return thanhTien;
        }
        private void CapNhatTongTienHoaDon(int maHD)
        {
            HoaDonDTO hoaDon = hoaDonDAL.LayHoaDonTheoMa(maHD);
            if (hoaDon != null)
            {
                hoaDon.TongTien = TinhTongTien(hoaDon.ChiTietHoaDon);
                hoaDon.ThanhTien = TinhThanhTien(hoaDon.TongTien, hoaDon.GiamGia, hoaDon.Thue);
                hoaDonDAL.CapNhatHoaDon(hoaDon);
            }
        }
        public List<HoaDonDTO> LayDanhSachHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            return hoaDonDAL.LayDanhSachHoaDon(tuNgay, denNgay);
        }
    }
}

