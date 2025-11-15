using System.Windows.Forms;

namespace PhoManager.UI.Forms
{
    /// <summary>
    /// Form quản lý người dùng kế thừa từ FrmNhanVien.
    /// Sử dụng lại chức năng quản lý nhân viên để làm quản lý tài khoản người dùng.
    /// </summary>
    public class FrmQuanLyNguoiDung : FrmNhanVien
    {
        public FrmQuanLyNguoiDung() : base()
        {
            this.Text = "Quản lý Người dùng";
        }
    }
}