using System;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    public partial class FrmHoaDon : Form
    {
        private HoaDonBLL hoaDonBLL = new HoaDonBLL();

        public FrmHoaDon()
        {
            InitializeComponent();
            ThemeManager.ApplyBaseFormStyle(this);
            ThemeManager.StyleButton(btnXemHoaDon, ButtonVariant.Primary, IconGlyphs.Invoice);
            ThemeManager.StyleButton(btnInHoaDon, ButtonVariant.Secondary, IconGlyphs.Report);
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
        }
    }
}

