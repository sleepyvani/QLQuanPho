using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Controls
{
    public class RoundedButton : Button
    {
        private int borderRadius = 15;
        private Color borderColor = Color.Transparent;
        private int borderWidth = 0;
        private ButtonVariant variant = ButtonVariant.Primary;
        private string glyph = string.Empty;
        private int glyphSize = 22;

        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.FromArgb(35, 96, 67);
            ForeColor = Color.White;
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Cursor = Cursors.Hand;
            Padding = new Padding(14, 10, 14, 10);
            Size = new Size(140, 44);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
            ApplyVariant();
        }

        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public int BorderWidth
        {
            get => borderWidth;
            set
            {
                borderWidth = value;
                Invalidate();
            }
        }

        public ButtonVariant Variant
        {
            get => variant;
            set
            {
                variant = value;
                ApplyVariant();
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public string Glyph
        {
            get => glyph;
            set
            {
                glyph = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public int GlyphSize
        {
            get => glyphSize;
            set
            {
                glyphSize = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath path = GetRoundedRectanglePath(rect, borderRadius);

            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                g.FillPath(brush, path);
            }

            if (borderWidth > 0 && borderColor != Color.Transparent)
            {
                using (Pen pen = new Pen(borderColor, borderWidth))
                {
                    g.DrawPath(pen, path);
                }
            }

            Rectangle textRect = rect;
            if (!string.IsNullOrEmpty(glyph))
            {
                var icon = ThemeManager.CreateGlyphIcon(glyph, ForeColor, glyphSize + 6);
                int iconY = (Height - icon.Height) / 2;
                g.DrawImage(icon, 18, iconY, icon.Width, icon.Height);
                textRect = new Rectangle(18 + icon.Width + 8, rect.Y, rect.Width - (icon.Width + 26), rect.Height);
            }

            using (SolidBrush textBrush = new SolidBrush(ForeColor))
            {
                StringFormat format = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(Text, Font, textBrush, textRect, format);
            }

            if (ClientRectangle.Contains(PointToClient(Cursor.Position)) && Enabled)
            {
                using (SolidBrush hoverBrush = new SolidBrush(Color.FromArgb(30, Color.White)))
                {
                    g.FillPath(hoverBrush, path);
                }
            }

            path.Dispose();
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Invalidate();
        }

        private void ApplyVariant()
        {
            switch (variant)
            {
                case ButtonVariant.Primary:
                    BackColor = ThemeManager.PrimaryColor;
                    ForeColor = Color.White;
                    borderColor = Color.Transparent;
                    borderWidth = 0;
                    break;
                case ButtonVariant.Secondary:
                    BackColor = Color.FromArgb(241, 245, 249); // Slate-100
                    ForeColor = ThemeManager.TextColor;
                    borderColor = ThemeManager.BorderColor;
                    borderWidth = 1;
                    break;
                case ButtonVariant.Tertiary:
                    BackColor = Color.White;
                    ForeColor = ThemeManager.TextColor;
                    borderColor = ThemeManager.BorderColor;
                    borderWidth = 1;
                    break;
                case ButtonVariant.Danger:
                    BackColor = ThemeManager.DangerColor;
                    ForeColor = Color.White;
                    borderColor = Color.Transparent;
                    borderWidth = 0;
                    break;
                default:
                    BackColor = Color.Transparent;
                    ForeColor = ThemeManager.TextColor;
                    borderColor = ThemeManager.BorderColor;
                    borderWidth = 1;
                    break;
            }
        }
    }
}
