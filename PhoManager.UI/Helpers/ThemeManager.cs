using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PhoManager.UI.Helpers
{
    public enum ButtonVariant
    {
        Primary,
        Secondary,
        Tertiary,
        Danger,
        Ghost
    }

    public static class IconGlyphs
    {
        public const string Dashboard = "\uE80F";
        public const string Bowl = "\uE9D5";
        public const string People = "\uE716";
        public const string Table = "\uEE69";
        public const string Order = "\uE74C";
        public const string Invoice = "\uE7B8";
        public const string Chart = "\uE9D2";
        public const string Settings = "\uE713";
        public const string Logout = "\uF3B1";
        public const string Lock = "\uE72E";
        public const string Search = "\uE721";
        public const string Refresh = "\uE72C";
        public const string Add = "\uE710";
        public const string Edit = "\uE70F";
        public const string Delete = "\uE74D";
        public const string Save = "\uE74E";
        public const string Filter = "\uE71C";
        public const string Report = "\uE9F9";
        public const string Money = "\uEAFD";
        public const string Clock = "\uE823";
    }

    public static class ThemeManager
    {
        public static readonly Color PrimaryColor = Color.FromArgb(26, 188, 156);
        public static readonly Color PrimaryDark = Color.FromArgb(22, 160, 133);
        public static readonly Color AccentColor = Color.FromArgb(52, 152, 219);
        public static readonly Color DangerColor = Color.FromArgb(235, 87, 87);
        public static readonly Color TextColor = Color.FromArgb(35, 45, 63);
        public static readonly Color TextMuted = Color.FromArgb(112, 123, 140);
        public static readonly Color BackgroundColor = Color.FromArgb(245, 247, 250);
        public static readonly Color PanelColor = Color.White;
        public static readonly Color SidebarColor = Color.FromArgb(33, 42, 62);
        public static readonly Color SidebarActive = Color.FromArgb(60, 75, 99);

        private static readonly Font DefaultFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        private static readonly Font IconFont;
        private static readonly Dictionary<string, Image> IconCache = new Dictionary<string, Image>();

        static ThemeManager()
        {
            try
            {
                IconFont = new Font("Segoe Fluent Icons", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            }
            catch
            {
                IconFont = new Font("Segoe MDL2 Assets", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            }
        }

        public static void ApplyBaseFormStyle(Form form)
        {
            form.BackColor = BackgroundColor;
            form.Font = DefaultFont;
        }

        public static void StyleDataGridView(DataGridView grid)
        {
            if (grid == null) return;

            grid.BackgroundColor = PanelColor;
            grid.BorderStyle = BorderStyle.None;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = PanelColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextColor;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 8, 12, 8);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(242, 250, 248);
            grid.DefaultCellStyle.SelectionForeColor = TextColor;
            grid.RowTemplate.Height = 42;
            grid.GridColor = Color.FromArgb(235, 238, 245);
        }

        public static void StyleTextBox(TextBox textBox)
        {
            if (textBox == null) return;

            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;
            textBox.ForeColor = TextColor;
            textBox.Font = DefaultFont;
            textBox.Margin = new Padding(0, 8, 0, 12);
        }

        public static void StyleComboBox(ComboBox comboBox)
        {
            if (comboBox == null) return;

            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.BackColor = Color.White;
            comboBox.ForeColor = TextColor;
            comboBox.Font = DefaultFont;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private class ButtonStyleState
        {
            public Color Normal { get; }
            public Color Hover { get; }

            public ButtonStyleState(Color normal, Color hover)
            {
                Normal = normal;
                Hover = hover;
            }
        }

        private static readonly ConditionalWeakTable<Button, ButtonStyleState> ButtonStates =
            new ConditionalWeakTable<Button, ButtonStyleState>();

        public static void StyleButton(Button button, ButtonVariant variant, string glyph = null)
        {
            if (button == null) return;

            Color backColor;
            Color foreColor;
            Color hoverColor;

            switch (variant)
            {
                case ButtonVariant.Primary:
                    backColor = PrimaryColor;
                    hoverColor = PrimaryDark;
                    foreColor = Color.White;
                    break;
                case ButtonVariant.Secondary:
                    backColor = Color.FromArgb(230, 233, 240);
                    hoverColor = Color.FromArgb(210, 214, 223);
                    foreColor = TextColor;
                    break;
                case ButtonVariant.Tertiary:
                    backColor = Color.FromArgb(245, 246, 250);
                    hoverColor = Color.FromArgb(230, 233, 240);
                    foreColor = TextColor;
                    break;
                case ButtonVariant.Danger:
                    backColor = DangerColor;
                    hoverColor = Color.FromArgb(215, 83, 83);
                    foreColor = Color.White;
                    break;
                default:
                    backColor = Color.Transparent;
                    hoverColor = Color.FromArgb(240, 242, 246);
                    foreColor = TextColor;
                    break;
            }

            button.FlatStyle = FlatStyle.Flat;
            button.UseVisualStyleBackColor = false;
            button.FlatAppearance.BorderSize = variant == ButtonVariant.Secondary || variant == ButtonVariant.Ghost ? 1 : 0;
            if (button.FlatAppearance.BorderSize > 0)
            {
                button.FlatAppearance.BorderColor = variant == ButtonVariant.Secondary ? Color.FromArgb(220, 222, 230) : backColor;
            }
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Font = new Font("Segoe UI Semibold", 10F);
            button.Height = Math.Max(button.Height, 42);
            button.Padding = new Padding(glyph == null ? 18 : 50, 0, 20, 0);
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;

            if (!string.IsNullOrEmpty(glyph))
            {
                button.Image = CreateGlyphIcon(glyph, foreColor);
            }

            ApplyRoundedCorners(button, 20);

            ButtonStates.Remove(button);
            ButtonStates.Add(button, new ButtonStyleState(backColor, hoverColor));
            button.MouseEnter -= ButtonMouseEnter;
            button.MouseLeave -= ButtonMouseLeave;
            button.MouseEnter += ButtonMouseEnter;
            button.MouseLeave += ButtonMouseLeave;
        }

        private static void ButtonMouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button && ButtonStates.TryGetValue(button, out var state))
            {
                button.BackColor = state.Hover;
            }
        }

        private static void ButtonMouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button && ButtonStates.TryGetValue(button, out var state))
            {
                button.BackColor = state.Normal;
            }
        }

        public static void ApplyPanelCardStyle(Control panel)
        {
            if (panel == null) return;

            panel.BackColor = PanelColor;
            panel.Padding = new Padding(20);
            panel.Margin = new Padding(12);
            panel.ForeColor = TextColor;
            panel.Font = DefaultFont;
            panel.Paint += (s, e) =>
            {
                var bounds = panel.ClientRectangle;
                bounds.Width -= 1;
                bounds.Height -= 1;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = CreateRoundedRectangle(bounds, 18))
                {
                    using (var fill = new SolidBrush(panel.BackColor))
                    {
                        e.Graphics.FillPath(fill, path);
                    }
                    using (var pen = new Pen(Color.FromArgb(235, 238, 245), 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };
        }

        public static Image CreateGlyphIcon(string glyph, Color color, int size = 28)
        {
            string cacheKey = $"{glyph}-{color.ToArgb()}-{size}";
            if (IconCache.TryGetValue(cacheKey, out var cached))
            {
                return cached;
            }

            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                using (var brush = new SolidBrush(color))
                {
                    StringFormat format = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(glyph, IconFont, brush, new RectangleF(0, 0, size, size), format);
                }
            }

            IconCache[cacheKey] = bmp;
            return bmp;
        }

        public static void ApplyRoundedCorners(Control control, int radius)
        {
            if (control == null) return;

            control.Resize += (s, e) =>
            {
                if (control.Width <= 0 || control.Height <= 0) return;
                using (GraphicsPath path = CreateRoundedRectangle(new Rectangle(0, 0, control.Width, control.Height), radius))
                {
                    control.Region = new Region(path);
                }
            };

            if (control.Width > 0 && control.Height > 0)
            {
                using (GraphicsPath path = CreateRoundedRectangle(new Rectangle(0, 0, control.Width, control.Height), radius))
                {
                    control.Region = new Region(path);
                }
            }
        }

        private static GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
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
    }
}

