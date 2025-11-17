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
    /// Form hiển thị báo cáo món ăn bán chạy sử dụng RDLC Report
    /// </summary>
    public partial class FrmBaoCaoMonBanChayRDLC : Form
    {
        private readonly ThongKeBLL thongKeBLL = new ThongKeBLL();
        private DateTime tuNgay;
        private DateTime denNgay;
        private int top;

        public FrmBaoCaoMonBanChayRDLC(DateTime tuNgay, DateTime denNgay, int top = 10)
        {
            InitializeComponent();
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
            this.top = top;
        }

        private void FrmBaoCaoMonBanChayRDLC_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                string reportPath = ResolveReportPath("RptMonBanChay.rdlc");

                DataTable dt = thongKeBLL.ThongKeMonBanChay(tuNgay, denNgay, top);
                var danhSachMonBanChay = new List<MonBanChayBaoCaoDTO>();
                foreach (DataRow row in dt.Rows)
                {
                    danhSachMonBanChay.Add(new MonBanChayBaoCaoDTO
                    {
                        TenMon = row["TenMon"].ToString(),
                        SoLuongBan = Convert.ToInt32(row["TongSoLuong"]),
                        TongTien = row["TongDoanhThu"] != DBNull.Value ? Convert.ToDecimal(row["TongDoanhThu"]) : 0
                    });
                }

                reportViewer1.Reset();
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = reportPath;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsMonBanChay", danhSachMonBanChay));

                var parameters = new[]
                {
                    new ReportParameter("TuNgay", tuNgay.ToString("dd/MM/yyyy")),
                    new ReportParameter("DenNgay", denNgay.ToString("dd/MM/yyyy")),
                    new ReportParameter("Top", top.ToString())
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
                string errorMsg = $"Lỗi khi tải báo cáo: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMsg += $"\n\nChi tiết: {ex.InnerException.Message}";
                }
                errorMsg += $"\n\nStack Trace: {ex.StackTrace}";
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

    // DTO cho báo cáo món bán chạy
    public class MonBanChayBaoCaoDTO
    {
        public string TenMon { get; set; }
        public int SoLuongBan { get; set; }
        public decimal TongTien { get; set; }
    }
}

