using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PhoManager.UI.Helpers
{
    public static class LogoHelper
    {
        public static Image CreateLogo(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                Rectangle logoRect = new Rectangle(0, 0, width, height);
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(logoRect);
                    
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        logoRect, 
                        Color.FromArgb(255, 165, 79), // Cam
                        Color.FromArgb(220, 53, 69),  // Đỏ
                        LinearGradientMode.Vertical))
                    {
                        g.FillPath(brush, path);
                    }
                    
                    using (Pen pen = new Pen(Color.White, 4))
                    {
                        g.DrawPath(pen, path);
                    }
                }

                int bowlWidth = width * 3 / 4;
                int bowlHeight = height * 3 / 4;
                int bowlX = (width - bowlWidth) / 2;
                int bowlY = (height - bowlHeight) / 2 + height / 8;

                using (GraphicsPath bowlPath = new GraphicsPath())
                {
                    Rectangle bowlRect = new Rectangle(bowlX, bowlY, bowlWidth, bowlHeight);
                    bowlPath.AddArc(bowlRect, 0, 180);
                    
                    using (SolidBrush soupBrush = new SolidBrush(Color.FromArgb(255, 248, 220)))
                    {
                        g.FillPath(soupBrush, bowlPath);
                    }
                    
                    using (Pen bowlPen = new Pen(Color.White, 3))
                    {
                        g.DrawPath(bowlPen, bowlPath);
                    }
                    
                    g.DrawLine(new Pen(Color.White, 3), 
                        bowlX, bowlY + bowlHeight / 2, 
                        bowlX + bowlWidth, bowlY + bowlHeight / 2);
                }

                using (Pen steamPen = new Pen(Color.White, 2))
                {
                    int steamX = bowlX + bowlWidth / 3;
                    int steamY = bowlY - height / 12;
                    for (int i = 0; i < 3; i++)
                    {
                        g.DrawCurve(steamPen, new Point[]
                        {
                            new Point(steamX + i * (bowlWidth / 6), steamY),
                            new Point(steamX + i * (bowlWidth / 6) - 5, steamY - height / 8),
                            new Point(steamX + i * (bowlWidth / 6), steamY - height / 6),
                            new Point(steamX + i * (bowlWidth / 6) + 5, steamY - height / 4)
                        });
                    }
                }

                using (Font textFont = new Font("Segoe UI", height / 6, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    string text = "PHỞ";
                    SizeF textSize = g.MeasureString(text, textFont);
                    float textX = (width - textSize.Width) / 2;
                    float textY = bowlY + bowlHeight + height / 12;
                    g.DrawString(text, textFont, textBrush, textX, textY);
                }
            }

            return bitmap;
        }

        public static Image CreateSimpleLogo(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                Rectangle logoRect = new Rectangle(0, 0, width, height);
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(logoRect);
                    
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(35, 96, 67)))
                    {
                        g.FillPath(brush, path);
                    }
                }

                using (Font textFont = new Font("Segoe UI", height / 3, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    string text = "PHỞ";
                    StringFormat format = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(text, textFont, textBrush, logoRect, format);
                }
            }

            return bitmap;
        }
    }
}
