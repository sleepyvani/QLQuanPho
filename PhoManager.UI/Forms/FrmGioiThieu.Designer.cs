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
            this.panelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.AutoSize = true;
            this.panelMain.Controls.Add(this.lblHeader);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(23, 21, 23, 21);
            this.panelMain.Size = new System.Drawing.Size(743, 664);
            this.panelMain.TabIndex = 0;
            this.panelMain.WrapContents = false;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(26, 24);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(3);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(545, 37);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Nhóm phát triển dự án Quản lý Quán Phở";
            // 
            // FrmGioiThieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 664);
            this.Controls.Add(this.panelMain);
            this.Name = "FrmGioiThieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giới thiệu nhóm";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
