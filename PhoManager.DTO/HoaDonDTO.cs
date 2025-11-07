using System;
using System.Collections.Generic;

namespace PhoManager.DTO
{
    public class HoaDonDTO
    {
        public int MaHD { get; set; }
        public int MaBan { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public decimal GiamGia { get; set; }
        public decimal Thue { get; set; }
        public decimal ThanhTien { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        
        public string TenBan { get; set; }
        public string TenNhanVien { get; set; }
        
        public List<ChiTietHoaDonDTO> ChiTietHoaDon { get; set; }
        
        public HoaDonDTO()
        {
            ChiTietHoaDon = new List<ChiTietHoaDonDTO>();
        }
    }
}

