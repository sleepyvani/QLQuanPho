using System;

namespace PhoManager.DTO
{
    public class NguyenLieuDTO
    {
        public int MaNL { get; set; }
        public string TenNL { get; set; }
        public decimal SoLuongTon { get; set; }
        public string DonViTinh { get; set; }
        public decimal? GiaNhap { get; set; }
        public DateTime NgayCapNhat { get; set; }
    }
}

