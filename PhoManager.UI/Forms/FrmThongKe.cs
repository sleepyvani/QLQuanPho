using System;
using System.Windows.Forms;
using PhoManager.BLL;

namespace PhoManager.UI.Forms
{
    public partial class FrmThongKe : Form
    {
        private ThongKeBLL thongKeBLL = new ThongKeBLL();

        public FrmThongKe()
        {
            InitializeComponent();
        }

        private void btnXemThongKe_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;
            dgvThongKe.DataSource = thongKeBLL.ThongKeDoanhThu(tuNgay, denNgay);
        }
    }
}

