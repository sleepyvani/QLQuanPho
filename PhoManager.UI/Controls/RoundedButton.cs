using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PhoManager.UI.Controls
{
    public class RoundedButton : Button
    {
        private int borderRadius = 15;
        private Color borderColor = Color.Transparent;
        private int borderWidth = 0;

        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.FromArgb(35, 96, 67);
            ForeColor = Color.White;
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Cursor = Cursors.Hand;
            Padding = new Padding(10, 8, 10, 8);
            Size = new Size(120, 40);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
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

            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            using (SolidBrush textBrush = new SolidBrush(ForeColor))
            {
                g.DrawString(Text, Font, textBrush, rect, format);
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
    }
}
