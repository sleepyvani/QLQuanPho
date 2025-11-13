using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhoManager.UI.Forms
{
    /// <summary>
    /// Form hiển thị thông tin giới thiệu về nhóm phát triển dự án.
    /// Bao gồm tên các thành viên, vai trò và mô tả ngắn.
    /// </summary>
    public class FrmGioiThieu : Form
    {
        public FrmGioiThieu()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Giới thiệu nhóm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(650, 500);
            this.AutoScroll = true;

            // FlowLayoutPanel để chứa nội dung giới thiệu
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.FlowDirection = FlowDirection.TopDown;
            panel.WrapContents = false;
            panel.AutoScroll = true;
            panel.Padding = new Padding(20);

            Label header = new Label();
            header.Text = "Nhóm phát triển dự án Quản lý Quán Phở";
            header.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            header.AutoSize = true;
            panel.Controls.Add(header);

            // Thêm thông tin các thành viên
            AddMember(panel, "Nguyễn Văn A", "Tech Lead", "Chịu trách nhiệm thiết kế kiến trúc hệ thống, hướng dẫn team và review code.");
            AddMember(panel, "Trần Thị B", "Lập trình viên Frontend", "Phát triển giao diện người dùng và trải nghiệm tương tác.");
            AddMember(panel, "Lê Văn C", "Lập trình viên Backend", "Xây dựng API, xử lý nghiệp vụ và quản lý cơ sở dữ liệu.");
            AddMember(panel, "Phạm Thị D", "Kiểm thử", "Chịu trách nhiệm kiểm thử, đảm bảo chất lượng sản phẩm.");

            this.Controls.Add(panel);
        }

        private void AddMember(FlowLayoutPanel panel, string name, string role, string description)
        {
            GroupBox box = new GroupBox();
            box.Width = 560;
            box.Height = 100;
            box.Padding = new Padding(10);
            // Thiết lập tiêu đề của group box
            box.Text = name + " - " + role;

            Label lblDesc = new Label();
            lblDesc.Text = description;
            lblDesc.Dock = DockStyle.Fill;
            lblDesc.AutoSize = false;
            lblDesc.MaximumSize = new Size(540, 0);
            lblDesc.AutoEllipsis = true;
            lblDesc.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            box.Controls.Add(lblDesc);
            panel.Controls.Add(box);
        }
    }
}