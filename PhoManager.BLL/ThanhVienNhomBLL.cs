using System.Collections.Generic;
using PhoManager.DAL;
using PhoManager.DTO;

namespace PhoManager.BLL
{
    public class ThanhVienNhomBLL
    {
        private readonly ThanhVienNhomDAL _dal = new ThanhVienNhomDAL();

        public List<ThanhVienNhomDTO> LayDanhSachThanhVien()
        {
            return _dal.LayTatCaThanhVien();
        }
    }
}
