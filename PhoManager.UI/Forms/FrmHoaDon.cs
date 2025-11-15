using System;
using System.Drawing;
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
            ThemeManager.StyleButton(btnXemHoaDon, ButtonVariant.Primary);
            ThemeManager.StyleButton(btnInHoaDon, ButtonVariant.Secondary);
            
            // Maintain critical properties after StyleButton - remove icons and ensure no wrapping
            btnXemHoaDon.AutoSize = false;
            btnXemHoaDon.TextAlign = ContentAlignment.MiddleCenter;
            btnXemHoaDon.UseCompatibleTextRendering = false;
            btnXemHoaDon.Image = null;
            btnXemHoaDon.Width = 150;
            btnInHoaDon.AutoSize = false;
            btnInHoaDon.TextAlign = ContentAlignment.MiddleCenter;
            btnInHoaDon.UseCompatibleTextRendering = false;
            btnInHoaDon.Image = null;
            btnInHoaDon.Width = 150;
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
        }
    }
}

