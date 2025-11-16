using System;
using System.Collections.Generic;
using PhoManager.DAL;
using System.Transactions;
using PhoManager.DTO;

namespace PhoManager.BLL
{
    public class HoaDonBLL
    {
        private HoaDonDAL hoaDonDAL = new HoaDonDAL();
        private BanAnDAL banAnDAL = new BanAnDAL();
        public int TaoHoaDon(HoaDonDTO hoaDon)
        {
            // Tính toán tổng tiền và thành tiền trước khi lưu
            hoaDon.TongTien = TinhTongTien(hoaDon.ChiTietHoaDon);
            hoaDon.ThanhTien = TinhThanhTien(hoaDon.TongTien, hoaDon.GiamGia, hoaDon.Thue);
            // Sử dụng TransactionScope để đảm bảo tính toàn vẹn khi thêm hóa đơn và chi tiết
            using (var scope = new System.Transactions.TransactionScope())
            {
                try
                {
                    int maHD = hoaDonDAL.TaoHoaDon(hoaDon);
                    if (maHD > 0)
                    {
                        foreach (var chiTiet in hoaDon.ChiTietHoaDon)
                        {
                            chiTiet.MaHD = maHD;
                            chiTiet.ThanhTien = chiTiet.SoLuong * chiTiet.DonGia;
                            // Nếu thêm chi tiết thất bại, ném ngoại lệ để rollback
                            bool ok = hoaDonDAL.ThemChiTietHoaDon(chiTiet);
                            if (!ok)
                            {
                                throw new Exception("Không thể thêm chi tiết hóa đơn.");
                            }
                        }
                        // Cập nhật trạng thái bàn khi đã có khách
                        banAnDAL.CapNhatTrangThaiBan(hoaDon.MaBan, "Có khách");
                        // Hoàn tất giao dịch
                        scope.Complete();
                        return maHD;
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi và trả về 0 để báo thất bại
                    PhoManager.Utilities.Logger.Error($"TaoHoaDon thất bại: {ex.Message}");
                    return 0;
                }
            }
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
            // Sử dụng giá trị mặc định từ cấu hình nếu người dùng chưa nhập thuế hoặc giảm giá
            try
            {
                if (thue <= 0)
                {
                    string thueConfig = System.Configuration.ConfigurationManager.AppSettings["DefaultTaxRate"];
                    if (decimal.TryParse(thueConfig, out decimal thueDefault))
                    {
                        thue = thueDefault;
                    }
                }
                if (giamGia <= 0)
                {
                    string giamConfig = System.Configuration.ConfigurationManager.AppSettings["DefaultDiscount"];
                    if (decimal.TryParse(giamConfig, out decimal giamDefault))
                    {
                        giamGia = giamDefault;
                    }
                }
            }
            catch
            {
                // Nếu đọc cấu hình thất bại thì bỏ qua và dùng các giá trị truyền vào
            }
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

