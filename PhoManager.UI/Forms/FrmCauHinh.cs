using System;
using System.Windows.Forms;

namespace PhoManager.UI.Forms
{
    public partial class FrmCauHinh : Form
    {
        public FrmCauHinh()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lưu cấu hình thành công!");
        }
    }
}

