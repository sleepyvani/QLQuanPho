using System;
using System.Windows.Forms;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    public partial class FrmCauHinh : Form
    {
        public FrmCauHinh()
        {
            InitializeComponent();
            ThemeManager.ApplyBaseFormStyle(this);
            ThemeManager.StyleButton(btnLuu, ButtonVariant.Primary, IconGlyphs.Save);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lưu cấu hình thành công!");
        }
    }
}

