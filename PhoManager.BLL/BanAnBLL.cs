using System.Collections.Generic;
using PhoManager.DAL;
using PhoManager.DTO;

namespace PhoManager.BLL
{
    public class BanAnBLL
    {
        private BanAnDAL banAnDAL = new BanAnDAL();
        public List<BanAnDTO> LayDanhSachBanAn()
        {
            return banAnDAL.LayDanhSachBanAn();
        }
        public BanAnDTO LayBanAnTheoMa(int maBan)
        {
            return banAnDAL.LayBanAnTheoMa(maBan);
        }
        public string ThemBanAn(BanAnDTO banAn)
        {
            if (string.IsNullOrWhiteSpace(banAn.TenBan))
            {
                return "Tên bàn không được để trống!";
            }

            if (banAn.SoLuongGhe <= 0)
            {
                return "Số lượng ghế phải lớn hơn 0!";
            }

            if (banAnDAL.ThemBanAn(banAn))
            {
                return "Thêm bàn ăn thành công!";
            }

            return "Thêm bàn ăn thất bại!";
        }
        public string CapNhatBanAn(BanAnDTO banAn)
        {
            if (string.IsNullOrWhiteSpace(banAn.TenBan))
            {
                return "Tên bàn không được để trống!";
            }

            if (banAn.SoLuongGhe <= 0)
            {
                return "Số lượng ghế phải lớn hơn 0!";
            }

            if (banAnDAL.CapNhatBanAn(banAn))
            {
                return "Cập nhật bàn ăn thành công!";
            }

            return "Cập nhật bàn ăn thất bại!";
        }
        public bool CapNhatTrangThaiBan(int maBan, string trangThai)
        {
            return banAnDAL.CapNhatTrangThaiBan(maBan, trangThai);
        }
        public string XoaBanAn(int maBan)
        {
            if (banAnDAL.XoaBanAn(maBan))
            {
                return "Xóa bàn ăn thành công!";
            }

            return "Xóa bàn ăn thất bại!";
        }
        public List<BanAnDTO> LayDanhSachBanTrong()
        {
            return banAnDAL.LayDanhSachBanTrong();
        }
    }
}