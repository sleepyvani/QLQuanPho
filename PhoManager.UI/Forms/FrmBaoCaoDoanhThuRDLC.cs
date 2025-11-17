using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PhoManager.BLL;
using PhoManager.DTO;

namespace PhoManager.UI.Forms
{
    /// <summary>
    /// Form hiển thị báo cáo doanh thu sử dụng RDLC Report
    /// </summary>
    public partial class FrmBaoCaoDoanhThuRDLC : Form
    {
        private readonly ThongKeBLL thongKeBLL = new ThongKeBLL();
        private DateTime tuNgay;
        private DateTime denNgay;

        public FrmBaoCaoDoanhThuRDLC(DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
        }

        private void FrmBaoCaoDoanhThuRDLC_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                string reportPath = ResolveReportPath("RptDoanhThu.rdlc");

                DataTable dt = thongKeBLL.ThongKeDoanhThu(tuNgay, denNgay);
                var danhSachDoanhThu = new List<DoanhThuBaoCaoDTO>();

                bool hasSoHoaDon = dt.Columns.Contains("SoHoaDon");
                bool hasSoLuongHoaDon = dt.Columns.Contains("SoLuongHoaDon");

                foreach (DataRow row in dt.Rows)
                {
                    danhSachDoanhThu.Add(new DoanhThuBaoCaoDTO
                    {
                        Ngay = Convert.ToDateTime(row["Ngay"]),
                        SoHoaDon = hasSoHoaDon
                            ? Convert.ToInt32(row["SoHoaDon"])
                            : hasSoLuongHoaDon
                                ? Convert.ToInt32(row["SoLuongHoaDon"])
                                : 0,
                        TongDoanhThu = row.Table.Columns.Contains("TongDoanhThu") && row["TongDoanhThu"] != DBNull.Value
                            ? Convert.ToDecimal(row["TongDoanhThu"])
                            : 0
                    });
                }

                reportViewer1.Reset();
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = reportPath;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDoanhThu", danhSachDoanhThu));

                var parameters = new[]
                {
                    new ReportParameter("TuNgay", tuNgay.ToString("dd/MM/yyyy")),
                    new ReportParameter("DenNgay", denNgay.ToString("dd/MM/yyyy"))
                };
                reportViewer1.LocalReport.SetParameters(parameters);

                reportViewer1.RefreshReport();
            }
            catch (Microsoft.Reporting.WinForms.LocalProcessingException lpe)
            {
                string errorMsg = $"Lỗi khi xử lý báo cáo:\n{lpe.Message}";
                if (lpe.InnerException != null)
                {
                    errorMsg += $"\n\nChi tiết: {lpe.InnerException.Message}";
                }
                MessageBox.Show(errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                string errorMsg = $"Không thể tải báo cáo doanh thu RDLC.\nChi tiết: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMsg += $"\n\nChi tiết bổ sung: {ex.InnerException.Message}";
                }
                MessageBox.Show(errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ResolveReportPath(string fileName)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string startupPath = Application.StartupPath;
            string currentDir = Directory.GetCurrentDirectory();

            string[] candidates = new[]
            {
                Path.Combine(baseDir, "Reports", fileName),
                Path.Combine(baseDir, fileName),
                Path.Combine(startupPath, "Reports", fileName),
                Path.Combine(startupPath, fileName),
                Path.Combine(currentDir, "Reports", fileName),
                Path.Combine(currentDir, fileName),
                Path.Combine("Reports", fileName)
            };

            foreach (string path in candidates)
            {
                if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
                {
                    return Path.GetFullPath(path);
                }
            }

            throw new FileNotFoundException($"Không tìm thấy file báo cáo: {fileName}\nĐã thử các đường dẫn: {string.Join("\n", candidates)}");
        }
    }

    // DTO cho báo cáo doanh thu
    public class DoanhThuBaoCaoDTO
    {
        public DateTime Ngay { get; set; }
        public int SoHoaDon { get; set; }
        public decimal TongDoanhThu { get; set; }
    }
}

