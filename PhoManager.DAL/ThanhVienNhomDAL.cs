using System.Collections.Generic;
using System.Linq;
using PhoManager.DTO;

namespace PhoManager.DAL
{
    public class ThanhVienNhomDAL
    {
        private readonly QLQuanPhoDataContext _db;

        public ThanhVienNhomDAL()
        {
            _db = new QLQuanPhoDataContext();
        }

        public List<ThanhVienNhomDTO> LayTatCaThanhVien()
        {
            return _db.THANH_VIEN_NHOMs
                      .OrderBy(t => t.ThuTu)
                      .Select(t => new ThanhVienNhomDTO
                      {
                          Id = t.Id,
                          HoTen = t.HoTen,
                          VaiTro = t.VaiTro,
                          MoTa = t.MoTa,
                          ThuTu = t.ThuTu ?? 0
                      })
                      .ToList();
        }
    }
}
