namespace PhoManager.UI.Forms
{
    partial class FrmCauHinh
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.ComboBox cbTheme;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.PictureBox picLogoPreview;
        private System.Windows.Forms.Button btnChangeLogo;
        private System.Windows.Forms.OpenFileDialog openFileDialogLogo;

        private void InitializeComponent()
        {
            this.btnLuu = new System.Windows.Forms.Button();
            this.lblTheme = new System.Windows.Forms.Label();
            this.cbTheme = new System.Windows.Forms.ComboBox();
            this.lblLogo = new System.Windows.Forms.Label();
            this.picLogoPreview = new System.Windows.Forms.PictureBox();
            this.btnChangeLogo = new System.Windows.Forms.Button();
            this.openFileDialogLogo = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();

            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(50, 40);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(60, 17);
            this.lblTheme.TabIndex = 0;
            this.lblTheme.Text = "Giao diện:";

            // 
            // cbTheme
            // 
            this.cbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTheme.FormattingEnabled = true;
            this.cbTheme.Location = new System.Drawing.Point(200, 35);
            this.cbTheme.Name = "cbTheme";
            this.cbTheme.Size = new System.Drawing.Size(200, 24);
            this.cbTheme.TabIndex = 1;

            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Location = new System.Drawing.Point(50, 90);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(44, 17);
            this.lblLogo.TabIndex = 2;
            this.lblLogo.Text = "Logo:";

            // 
            // picLogoPreview
            // 
            this.picLogoPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogoPreview.Location = new System.Drawing.Point(200, 80);
            this.picLogoPreview.Name = "picLogoPreview";
            this.picLogoPreview.Size = new System.Drawing.Size(100, 100);
            this.picLogoPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoPreview.TabIndex = 3;
            this.picLogoPreview.TabStop = false;

            // 
            // btnChangeLogo
            // 
            this.btnChangeLogo.Location = new System.Drawing.Point(320, 80);
            this.btnChangeLogo.Name = "btnChangeLogo";
            this.btnChangeLogo.Size = new System.Drawing.Size(100, 30);
            this.btnChangeLogo.TabIndex = 4;
            this.btnChangeLogo.Text = "Chọn logo";
            this.btnChangeLogo.UseVisualStyleBackColor = true;
            this.btnChangeLogo.Click += new System.EventHandler(this.btnChangeLogo_Click);

            // 
            // openFileDialogLogo
            // 
            this.openFileDialogLogo.Filter = "Ảnh (*.png;*.jpg)|*.png;*.jpg|Tất cả tập tin (*.*)|*.*";

            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(50, 220);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 40);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            // 
            // FrmCauHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnChangeLogo);
            this.Controls.Add(this.picLogoPreview);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.cbTheme);
            this.Controls.Add(this.lblTheme);
            this.Name = "FrmCauHinh";
            this.Text = "Cấu hình hệ thống";
            ((System.ComponentModel.ISupportInitialize)(this.picLogoPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
    }
}