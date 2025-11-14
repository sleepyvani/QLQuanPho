using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhoManager.UI.Forms
{
    /// <summary>
    /// Form hiển thị thông tin giới thiệu về nhóm phát triển dự án.
    /// Bao gồm tên các thành viên, vai trò và mô tả ngắn.
    /// </summary>
    public partial class FrmGioiThieu : Form
    {
        public FrmGioiThieu()
        {
            InitializeComponent();
            // Áp dụng style cơ bản cho form giới thiệu để đồng nhất giao diện
            try
            {
                PhoManager.UI.Helpers.ThemeManager.ApplyBaseFormStyle(this);
            }
            catch
            {
                // Nếu ThemeManager chưa được triển khai, bỏ qua
            }
        }

        // The UI for this form is defined in the designer file (FrmGioiThieu.Designer.cs).
    }
}