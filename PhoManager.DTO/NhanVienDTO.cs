using System;

namespace PhoManager.DTO
{
    public class NhanVienDTO
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string ChucVu { get; set; }
        public DateTime NgayTao { get; set; }
        public bool TrangThai { get; set; }
    }
}

