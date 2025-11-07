using System;
using System.Configuration;
using System.Data.Linq;

namespace PhoManager.DAL
{
    public class PhoDataContext : DataContext
    {
        private static readonly string ConnectionString;

        static PhoDataContext()
        {
            var connection = ConfigurationManager.ConnectionStrings["QLQuanPhoConnectionString"];
            if (connection == null || string.IsNullOrWhiteSpace(connection.ConnectionString))
            {
                throw new InvalidOperationException("Connection string 'QLQuanPhoConnectionString' is missing or empty in App.config.");
            }

            ConnectionString = connection.ConnectionString;
        }

        public PhoDataContext() : base(ConnectionString)
        {
            CommandTimeout = 30;
        }

        public static bool TestConnection()
        {
            using (var context = new PhoDataContext())
            {
                try
                {
                    context.Connection.Open();
                    context.Connection.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public Table<MonAnEntity> MonAns => GetTable<MonAnEntity>();
        public Table<NhanVienEntity> NhanViens => GetTable<NhanVienEntity>();
        public Table<BanAnEntity> BanAns => GetTable<BanAnEntity>();
        public Table<HoaDonEntity> HoaDons => GetTable<HoaDonEntity>();
        public Table<ChiTietHoaDonEntity> ChiTietHoaDons => GetTable<ChiTietHoaDonEntity>();
        public Table<NguyenLieuEntity> NguyenLieus => GetTable<NguyenLieuEntity>();
        public Table<MonAnNguyenLieuEntity> MonAnNguyenLieus => GetTable<MonAnNguyenLieuEntity>();
    }
}
