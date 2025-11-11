using System;
using System.Data;
using System.Linq;

namespace PhoManager.DAL
{
    public class ThongKeDAL
    {
        public DataTable ThongKeDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                var data = db.HoaDons
                    .Where(h => h.NgayLap.Date >= tuNgay.Date && h.NgayLap.Date <= denNgay.Date && h.TrangThai == "Đã thanh toán")
                    .GroupBy(h => h.NgayLap.Date)
                    .Select(g => new
                    {
                        Ngay = g.Key,
                        SoHoaDon = g.Count(),
                        TongDoanhThu = g.Sum(x => x.ThanhTien)
                    })
                    .OrderByDescending(x => x.Ngay)
                    .ToList();

                return BuildDataTable(data, table =>
                {
                    table.Columns.Add("Ngay", typeof(DateTime));
                    table.Columns.Add("SoHoaDon", typeof(int));
                    table.Columns.Add("TongDoanhThu", typeof(decimal));
                }, (table, item) =>
                {
                    table.Rows.Add(item.Ngay, item.SoHoaDon, item.TongDoanhThu);
                });
            }
        }

        public DataTable ThongKeMonBanChay(DateTime tuNgay, DateTime denNgay, int top = 10)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                var data = (from ct in db.ChiTietHoaDons
                            join hd in db.HoaDons on ct.MaHD equals hd.MaHD
                            join m in db.MonAns on ct.MaMon equals m.MaMon
                            where hd.NgayLap.Date >= tuNgay.Date && hd.NgayLap.Date <= denNgay.Date
                                  && hd.TrangThai == "Đã thanh toán"
                            group new { ct, m } by m.TenMon into g
                            orderby g.Sum(x => x.ct.SoLuong) descending
                            select new
                            {
                                TenMon = g.Key,
                                TongSoLuong = g.Sum(x => x.ct.SoLuong),
                                TongDoanhThu = g.Sum(x => x.ct.ThanhTien)
                            })
                            .Take(top)
                            .ToList();

                return BuildDataTable(data, table =>
                {
                    table.Columns.Add("TenMon", typeof(string));
                    table.Columns.Add("TongSoLuong", typeof(int));
                    table.Columns.Add("TongDoanhThu", typeof(decimal));
                }, (table, item) =>
                {
                    table.Rows.Add(item.TenMon, item.TongSoLuong, item.TongDoanhThu);
                });
            }
        }

        public DataTable ThongKeDoanhThuTheoNhanVien(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                var data = (from nv in db.NhanViens
                            where nv.TrangThai
                            join hd in db.HoaDons.Where(h => h.NgayLap.Date >= tuNgay.Date && h.NgayLap.Date <= denNgay.Date && h.TrangThai == "Đã thanh toán")
                                on nv.MaNV equals hd.MaNV into hoaDonGroup
                            select new
                            {
                                nv.MaNV,
                                nv.HoTen,
                                nv.ChucVu,
                                SoHoaDon = hoaDonGroup.Count(),
                                TongDoanhThu = hoaDonGroup.Sum(h => (decimal?)h.ThanhTien) ?? 0m
                            })
                            .OrderByDescending(x => x.TongDoanhThu)
                            .ToList();

                return BuildDataTable(data, table =>
                {
                    table.Columns.Add("MaNV", typeof(int));
                    table.Columns.Add("HoTen", typeof(string));
                    table.Columns.Add("ChucVu", typeof(string));
                    table.Columns.Add("SoHoaDon", typeof(int));
                    table.Columns.Add("TongDoanhThu", typeof(decimal));
                }, (table, item) =>
                {
                    table.Rows.Add(item.MaNV, item.HoTen, item.ChucVu, item.SoHoaDon, item.TongDoanhThu);
                });
            }
        }

        public decimal LayTongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                return db.HoaDons
                    .Where(h => h.NgayLap.Date >= tuNgay.Date && h.NgayLap.Date <= denNgay.Date && h.TrangThai == "Đã thanh toán")
                    .Select(h => (decimal?)h.ThanhTien)
                    .Sum() ?? 0m;
            }
        }

        public int LaySoLuongHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new QLQuanPhoDataContext())
            {
                return db.HoaDons
                    .Count(h => h.NgayLap.Date >= tuNgay.Date && h.NgayLap.Date <= denNgay.Date && h.TrangThai == "Đã thanh toán");
            }
        }

        private DataTable BuildDataTable<T>(System.Collections.Generic.IEnumerable<T> data, Action<DataTable> initializeColumns, Action<DataTable, T> addRow)
        {
            var table = new DataTable();

            initializeColumns(table);

            foreach (var item in data)
            {
                addRow(table, item);
            }

            return table;
        }
    }
}

