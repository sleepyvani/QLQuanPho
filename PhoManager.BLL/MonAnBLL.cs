using System.Collections.Generic;
using PhoManager.DAL;
using PhoManager.DTO;

namespace PhoManager.BLL
{
    public class MonAnBLL
    {
        private MonAnDAL monAnDAL = new MonAnDAL();
        public List<MonAnDTO> LayDanhSachMonAn()
        {
            return monAnDAL.LayDanhSachMonAn();
        }
        public MonAnDTO LayMonAnTheoMa(int maMon)
        {
            return monAnDAL.LayMonAnTheoMa(maMon);
        }
        public string ThemMonAn(MonAnDTO monAn)
        {
            if (string.IsNullOrWhiteSpace(monAn.TenMon))
            {
                return "Tên món không được để trống!";
            }

            if (monAn.GiaNho < 0 || monAn.GiaLon < 0)
            {
                return "Giá món phải lớn hơn hoặc bằng 0!";
            }

            if (monAn.GiaLon < monAn.GiaNho)
            {
                return "Giá tô lớn phải lớn hơn hoặc bằng giá tô nhỏ!";
            }

            if (monAnDAL.ThemMonAn(monAn))
            {
                return "Thêm món ăn thành công!";
            }

            return "Thêm món ăn thất bại!";
        }

        public string CapNhatMonAn(MonAnDTO monAn)
        {
            if (string.IsNullOrWhiteSpace(monAn.TenMon))
            {
                return "Tên món không được để trống!";
            }

            if (monAn.GiaNho < 0 || monAn.GiaLon < 0)
            {
                return "Giá món phải lớn hơn hoặc bằng 0!";
            }

            if (monAn.GiaLon < monAn.GiaNho)
            {
                return "Giá tô lớn phải lớn hơn hoặc bằng giá tô nhỏ!";
            }

            if (monAnDAL.CapNhatMonAn(monAn))
            {
                return "Cập nhật món ăn thành công!";
            }

            return "Cập nhật món ăn thất bại!";
        }

        public string XoaMonAn(int maMon)
        {
            if (monAnDAL.XoaMonAn(maMon))
            {
                return "Xóa món ăn thành công!";
            }

            return "Xóa món ăn thất bại!";
        }

        public List<MonAnDTO> TimKiemMonAn(string tenMon)
        {
            return monAnDAL.TimKiemMonAn(tenMon);
        }
    }
}

