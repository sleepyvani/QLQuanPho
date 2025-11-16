using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Forms
{
    public partial class FrmCauHinh : Form
    {
        /// <summary>
        /// Đường dẫn tạm thời tới file logo mà người dùng chọn.  Nếu null thì
        /// logo hiện tại sẽ được giữ nguyên.  File sẽ được sao chép vào
        /// thư mục chương trình khi người dùng lưu cấu hình.
        /// </summary>
        private string selectedLogoPath;

        public FrmCauHinh()
        {
            InitializeComponent();
            ThemeManager.ApplyBaseFormStyle(this);
            ThemeManager.StyleButton(btnLuu, ButtonVariant.Primary, IconGlyphs.Save);

            // Khởi tạo lựa chọn giao diện (theme)
            cbTheme.Items.AddRange(new object[] { "Sáng", "Tối" });
            cbTheme.SelectedIndex = ThemeManager.IsDarkTheme ? 1 : 0;

            // Hiển thị logo hiện tại (nếu có) hoặc mặc định
            try
            {
                if (ThemeManager.CustomLogoImage != null)
                {
                    picLogoPreview.Image = (Image)ThemeManager.CustomLogoImage.Clone();
                }
                else
                {
                    // Thử đọc logo từ file logo.png trong thư mục chạy ứng dụng
                    string logoPath = System.IO.Path.Combine(Application.StartupPath, "logo.png");
                    if (System.IO.File.Exists(logoPath))
                    {
                        picLogoPreview.Image = Image.FromFile(logoPath);
                    }
                    else
                    {
                        // Nếu không có file thì tạo logo placeholder
                        picLogoPreview.Image = LogoHelper.CreateSimpleLogo(picLogoPreview.Width, picLogoPreview.Height);
                    }
                }
            }
            catch
            {
                // Nếu xảy ra lỗi khi đọc logo, dùng logo đơn giản
                picLogoPreview.Image = LogoHelper.CreateSimpleLogo(picLogoPreview.Width, picLogoPreview.Height);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Áp dụng thay đổi theme
            bool dark = cbTheme.SelectedIndex == 1;
            ThemeManager.SetTheme(dark);

            // Nếu người dùng đã chọn logo mới thì sao chép vào thư mục ứng dụng
            try
            {
                if (!string.IsNullOrEmpty(selectedLogoPath) && System.IO.File.Exists(selectedLogoPath))
                {
                    string dest = System.IO.Path.Combine(Application.StartupPath, "logo.png");
                    System.IO.File.Copy(selectedLogoPath, dest, true);
                    // Cập nhật logo hiện tại trong ThemeManager để các form khác có thể sử dụng
                    try
                    {
                        ThemeManager.CustomLogoImage = Image.FromFile(dest);
                    }
                    catch
                    {
                        ThemeManager.CustomLogoImage = null;
                    }
                }
            }
            catch (Exception ex)
            {
                PhoManager.Utilities.Logger.Error("Không thể sao chép file logo: " + ex.Message);
            }

            // Cập nhật giao diện cho form chính nếu đang mở
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is FrmMain main)
                {
                    main.ReloadTheme();
                }
            }

            MessageBox.Show("Lưu cấu hình thành công!");
        }

        private void btnChangeLogo_Click(object sender, EventArgs e)
        {
            if (openFileDialogLogo.ShowDialog() == DialogResult.OK)
            {
                selectedLogoPath = openFileDialogLogo.FileName;
                try
                {
                    // Hiển thị ảnh xem trước
                    Image img = Image.FromFile(selectedLogoPath);
                    picLogoPreview.Image = (Image)img.Clone();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể đọc ảnh: " + ex.Message);
                }
            }
        }
    }
}

