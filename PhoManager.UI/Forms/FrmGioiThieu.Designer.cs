using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PhoManager.UI.Forms
{
    /// <summary>
    /// Designer code for the introduction form (FrmGioiThieu).
    /// This form displays information about the development team including
    /// each member's name, role, and a brief description. The layout uses a
    /// FlowLayoutPanel to stack group boxes vertically with consistent spacing.
    /// </summary>
    public partial class FrmGioiThieu
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel panelMain;
        private Label lblHeader;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label lblDesc1;
        private Label lblDesc2;
        private Label lblDesc3;
        private Label lblDesc4;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Initialize the UI components for the introduction form.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDesc1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDesc2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblDesc3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblDesc4 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.AutoScroll = true;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(650, 500);
            this.panelMain.TabIndex = 0;
            this.panelMain.WrapContents = false;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(23, 23);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(3);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(463, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Nhóm phát triển dự án Quản lý Quán Phở";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDesc1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(23, 59);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(560, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nguyễn Văn A - Tech Lead";
            // 
            // lblDesc1
            // 
            this.lblDesc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesc1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesc1.Location = new System.Drawing.Point(10, 26);
            this.lblDesc1.MaximumSize = new System.Drawing.Size(540, 0);
            this.lblDesc1.Name = "lblDesc1";
            this.lblDesc1.Size = new System.Drawing.Size(540, 64);
            this.lblDesc1.TabIndex = 0;
            this.lblDesc1.Text = "Chịu trách nhiệm thiết kế kiến trúc hệ thống, hướng dẫn team và review code.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDesc2);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(23, 171);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(560, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trần Thị B - Lập trình viên Frontend";
            // 
            // lblDesc2
            // 
            this.lblDesc2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesc2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesc2.Location = new System.Drawing.Point(10, 26);
            this.lblDesc2.MaximumSize = new System.Drawing.Size(540, 0);
            this.lblDesc2.Name = "lblDesc2";
            this.lblDesc2.Size = new System.Drawing.Size(540, 64);
            this.lblDesc2.TabIndex = 0;
            this.lblDesc2.Text = "Phát triển giao diện người dùng và trải nghiệm tương tác.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblDesc3);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(23, 283);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(560, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lê Văn C - Lập trình viên Backend";
            // 
            // lblDesc3
            // 
            this.lblDesc3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesc3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesc3.Location = new System.Drawing.Point(10, 26);
            this.lblDesc3.MaximumSize = new System.Drawing.Size(540, 0);
            this.lblDesc3.Name = "lblDesc3";
            this.lblDesc3.Size = new System.Drawing.Size(540, 64);
            this.lblDesc3.TabIndex = 0;
            this.lblDesc3.Text = "Xây dựng API, xử lý nghiệp vụ và quản lý cơ sở dữ liệu.";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblDesc4);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(23, 395);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox4.Size = new System.Drawing.Size(560, 100);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Phạm Thị D - Kiểm thử";
            // 
            // lblDesc4
            // 
            this.lblDesc4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesc4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesc4.Location = new System.Drawing.Point(10, 26);
            this.lblDesc4.MaximumSize = new System.Drawing.Size(540, 0);
            this.lblDesc4.Name = "lblDesc4";
            this.lblDesc4.Size = new System.Drawing.Size(540, 64);
            this.lblDesc4.TabIndex = 0;
            this.lblDesc4.Text = "Chịu trách nhiệm kiểm thử, đảm bảo chất lượng sản phẩm.";
            // 
            // FrmGioiThieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 500);
            this.Controls.Add(this.panelMain);
            this.Name = "FrmGioiThieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giới thiệu nhóm";
            // add controls to flow layout panel
            this.panelMain.Controls.Add(this.lblHeader);
            this.panelMain.Controls.Add(this.groupBox1);
            this.panelMain.Controls.Add(this.groupBox2);
            this.panelMain.Controls.Add(this.groupBox3);
            this.panelMain.Controls.Add(this.groupBox4);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}