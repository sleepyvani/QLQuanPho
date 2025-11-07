using System;
using System.Data;
using PhoManager.DAL;

namespace PhoManager.BLL
{
    public class ThongKeBLL
    {
        private ThongKeDAL thongKeDAL = new ThongKeDAL();
        public DataTable ThongKeDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            return thongKeDAL.ThongKeDoanhThu(tuNgay, denNgay);
        }
        public DataTable ThongKeMonBanChay(DateTime tuNgay, DateTime denNgay, int top = 10)
        {
            return thongKeDAL.ThongKeMonBanChay(tuNgay, denNgay, top);
        }
        public DataTable ThongKeDoanhThuTheoNhanVien(DateTime tuNgay, DateTime denNgay)
        {
            return thongKeDAL.ThongKeDoanhThuTheoNhanVien(tuNgay, denNgay);
        }
        public decimal LayTongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            return thongKeDAL.LayTongDoanhThu(tuNgay, denNgay);
        }
        public int LaySoLuongHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            return thongKeDAL.LaySoLuongHoaDon(tuNgay, denNgay);
        }
    }
}

