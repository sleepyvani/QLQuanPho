using System;
using System.Drawing;
using System.Windows.Forms;
using PhoManager.BLL;
using PhoManager.DTO;

namespace PhoManager.UI.Forms
{
    public partial class FrmGioiThieu : Form
    {
        private readonly ThanhVienNhomBLL _thanhVienNhomBLL = new ThanhVienNhomBLL();

        public FrmGioiThieu()
        {
            InitializeComponent();

            try
            {
                PhoManager.UI.Helpers.ThemeManager.ApplyBaseFormStyle(this);
            }
            catch { }

            this.Load += FrmGioiThieu_Load;
        }

        private void FrmGioiThieu_Load(object sender, EventArgs e)
        {
            LoadThanhVienNhom();
        }

        private void LoadThanhVienNhom()
        {
            var members = _thanhVienNhomBLL.LayDanhSachThanhVien();

            panelMain.SuspendLayout();

            for (int i = panelMain.Controls.Count - 1; i >= 0; i--)
            {
                if (panelMain.Controls[i] is GroupBox)
                    panelMain.Controls.RemoveAt(i);
            }

            foreach (var m in members)
            {
                var gb = new GroupBox();
                gb.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                gb.Padding = new Padding(11);
                gb.Margin = new Padding(3, 6, 3, 6);
                gb.Size = new Size(640, 120);
                gb.Text = $"{m.HoTen} - {m.VaiTro}";

                var lbl = new Label();
                lbl.Dock = DockStyle.Fill;
                lbl.Font = new Font("Segoe UI", 9f);
                lbl.MaximumSize = new Size(617, 0);
                lbl.Text = string.IsNullOrWhiteSpace(m.MoTa)
                    ? "Thành viên nhóm phát triển dự án."
                    : m.MoTa;

                gb.Controls.Add(lbl);
                panelMain.Controls.Add(gb);
            }

            panelMain.ResumeLayout();
        }
    }
}
