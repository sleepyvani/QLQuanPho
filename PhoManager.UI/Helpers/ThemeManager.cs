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
        // Modern Color Palette - Inspired by modern design systems
        public static readonly Color PrimaryColor = Color.FromArgb(59, 130, 246);      // Blue-500
        public static readonly Color PrimaryDark = Color.FromArgb(37, 99, 235);       // Blue-600
        public static readonly Color PrimaryLight = Color.FromArgb(239, 246, 255);    // Blue-50
        public static readonly Color AccentColor = Color.FromArgb(139, 92, 246);      // Purple-500
        public static readonly Color SuccessColor = Color.FromArgb(34, 197, 94);       // Green-500
        public static readonly Color WarningColor = Color.FromArgb(251, 191, 36);      // Amber-400
        public static readonly Color DangerColor = Color.FromArgb(239, 68, 68);       // Red-500
        public static readonly Color DangerDark = Color.FromArgb(220, 38, 38);         // Red-600
        
        // Text Colors
        public static readonly Color TextPrimary = Color.FromArgb(15, 23, 42);        // Slate-900
        public static readonly Color TextSecondary = Color.FromArgb(51, 65, 85);      // Slate-700
        public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);       // Slate-500
        public static readonly Color TextDisabled = Color.FromArgb(148, 163, 184);    // Slate-400
        
        // Background Colors
        public static readonly Color BackgroundPrimary = Color.FromArgb(248, 250, 252); // Slate-50
        public static readonly Color BackgroundSecondary = Color.White;
        public static readonly Color BackgroundTertiary = Color.FromArgb(241, 245, 249); // Slate-100
        
        // Border Colors
        public static readonly Color BorderLight = Color.FromArgb(226, 232, 240);     // Slate-200
        public static readonly Color BorderMedium = Color.FromArgb(203, 213, 225);    // Slate-300
        public static readonly Color BorderDark = Color.FromArgb(148, 163, 184);      // Slate-400
        
        // Sidebar Colors
        public static readonly Color SidebarColor = Color.FromArgb(15, 23, 42);       // Slate-900
        public static readonly Color SidebarActive = Color.FromArgb(30, 41, 59);       // Slate-800
        public static readonly Color SidebarHover = Color.FromArgb(51, 65, 85);         // Slate-700
        public static readonly Color SidebarText = Color.FromArgb(226, 232, 240);     // Slate-200
        
        // Input Colors
        public static readonly Color InputBackground = Color.White;
        public static readonly Color InputBorder = Color.FromArgb(203, 213, 225);     // Slate-300
        public static readonly Color InputBorderFocus = Color.FromArgb(59, 130, 246); // Blue-500
        public static readonly Color InputBackgroundFocus = Color.FromArgb(255, 255, 255);
        
        // Card Colors
        public static readonly Color CardBackground = Color.White;
        public static readonly Color CardShadow = Color.FromArgb(0, 0, 0, 8);
        
        // Spacing Constants
        public const int SpacingXS = 4;
        public const int SpacingSM = 8;
        public const int SpacingMD = 16;
        public const int SpacingLG = 24;
        public const int SpacingXL = 32;
        public const int SpacingXXL = 48;
        
        // Border Radius
        public const int RadiusSM = 6;
        public const int RadiusMD = 8;
        public const int RadiusLG = 12;
        public const int RadiusXL = 16;
        
        // Typography
        private static readonly Font FontRegular = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        private static readonly Font FontSemibold = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
        private static readonly Font FontBold = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
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
            form.BackColor = BackgroundPrimary;
            form.Font = FontRegular;
        }

        public static void StyleDataGridView(DataGridView grid)
        {
            if (grid == null) return;

            grid.BackgroundColor = BackgroundSecondary;
            grid.BorderStyle = BorderStyle.None;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.EnableHeadersVisualStyles = false;
            
            // Column Headers - Modern and clean
            grid.ColumnHeadersDefaultCellStyle.BackColor = BackgroundTertiary;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
            grid.ColumnHeadersDefaultCellStyle.Font = FontSemibold;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(SpacingMD, 14, SpacingMD, 14);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            grid.ColumnHeadersHeight = 52;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            
            // Cell Styles
            grid.DefaultCellStyle.BackColor = BackgroundSecondary;
            grid.DefaultCellStyle.ForeColor = TextPrimary;
            grid.DefaultCellStyle.Font = FontRegular;
            grid.DefaultCellStyle.Padding = new Padding(SpacingMD, 0, SpacingMD, 0);
            grid.DefaultCellStyle.SelectionBackColor = PrimaryLight;
            grid.DefaultCellStyle.SelectionForeColor = TextPrimary;
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            
            // Row Template
            grid.RowTemplate.Height = 52;
            grid.RowTemplate.DefaultCellStyle.Padding = new Padding(SpacingMD, 0, SpacingMD, 0);
            
            // Grid Lines
            grid.GridColor = BorderLight;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.RowHeadersVisible = false;
            grid.AllowUserToResizeRows = false;
            grid.AlternatingRowsDefaultCellStyle.BackColor = BackgroundPrimary;
        }

        public static void StyleTextBox(TextBox textBox)
        {
            if (textBox == null) return;

            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = InputBackground;
            textBox.ForeColor = TextPrimary;
            textBox.Font = FontRegular;
            textBox.Margin = new Padding(0, SpacingSM, 0, SpacingMD);
            textBox.Height = 40;
            
            // Add focus event for better UX
            textBox.Enter += (s, e) =>
            {
                textBox.BackColor = InputBackgroundFocus;
                textBox.BorderStyle = BorderStyle.FixedSingle;
            };
            textBox.Leave += (s, e) =>
            {
                textBox.BackColor = InputBackground;
            };
        }

        public static void StyleComboBox(ComboBox comboBox)
        {
            if (comboBox == null) return;

            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.BackColor = InputBackground;
            comboBox.ForeColor = TextPrimary;
            comboBox.Font = FontRegular;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Height = 40;
            
            comboBox.Enter += (s, e) =>
            {
                comboBox.BackColor = InputBackgroundFocus;
            };
            comboBox.Leave += (s, e) =>
            {
                comboBox.BackColor = InputBackground;
            };
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
            Color borderColor = Color.Transparent;

            switch (variant)
            {
                case ButtonVariant.Primary:
                    backColor = PrimaryColor;
                    hoverColor = PrimaryDark;
                    foreColor = Color.White;
                    break;
                case ButtonVariant.Secondary:
                    backColor = BackgroundSecondary;
                    hoverColor = BackgroundTertiary;
                    foreColor = TextPrimary;
                    borderColor = BorderMedium;
                    break;
                case ButtonVariant.Tertiary:
                    backColor = BackgroundTertiary;
                    hoverColor = BorderLight;
                    foreColor = TextSecondary;
                    break;
                case ButtonVariant.Danger:
                    backColor = DangerColor;
                    hoverColor = DangerDark;
                    foreColor = Color.White;
                    break;
                default: // Ghost
                    backColor = Color.Transparent;
                    hoverColor = BackgroundTertiary;
                    foreColor = TextSecondary;
                    break;
            }

            button.FlatStyle = FlatStyle.Flat;
            button.UseVisualStyleBackColor = false;
            button.FlatAppearance.BorderSize = variant == ButtonVariant.Secondary ? 1 : 0;
            if (button.FlatAppearance.BorderSize > 0)
            {
                button.FlatAppearance.BorderColor = borderColor;
            }
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Font = FontSemibold;
            button.Cursor = Cursors.Hand;
            
            // Standardize button height for regular buttons
            if (button.Height < 50)
            {
                button.Height = 42;
            }
            
            // Padding and alignment based on button size
            if (button.Height >= 80)
            {
                // Large buttons (quick actions) - vertical layout
                button.Padding = new Padding(glyph == null ? 18 : 20, 14, 20, 14);
                button.TextAlign = ContentAlignment.BottomCenter;
                button.ImageAlign = ContentAlignment.TopCenter;
                button.TextImageRelation = TextImageRelation.ImageAboveText;
            }
            else
            {
                // Regular buttons - horizontal layout with icon and text on same line
                if (!string.IsNullOrEmpty(glyph))
                {
                    // Button with icon - align both to middle left
                    button.Padding = new Padding(SpacingMD, 0, SpacingLG, 0);
                    button.TextAlign = ContentAlignment.MiddleLeft;
                    button.ImageAlign = ContentAlignment.MiddleLeft;
                    button.TextImageRelation = TextImageRelation.ImageBeforeText;
                }
                else
                {
                    // Button without icon - center text
                    button.Padding = new Padding(SpacingLG, 0, SpacingLG, 0);
                    button.TextAlign = ContentAlignment.MiddleCenter;
                    button.ImageAlign = ContentAlignment.MiddleCenter;
                }
            }

            if (!string.IsNullOrEmpty(glyph))
            {
                int iconSize = button.Height >= 80 ? 32 : 18;
                button.Image = CreateGlyphIcon(glyph, foreColor, iconSize);
            }

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

            panel.BackColor = CardBackground;
            panel.Padding = new Padding(SpacingLG);
            panel.Margin = new Padding(SpacingMD);
            panel.ForeColor = TextPrimary;
            panel.Font = FontRegular;
            
            // Add subtle shadow effect
            panel.Paint += (s, e) =>
            {
                var bounds = panel.ClientRectangle;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                
                // Draw shadow
                using (var shadowBrush = new SolidBrush(Color.FromArgb(20, 0, 0, 0)))
                {
                    var shadowRect = new Rectangle(bounds.X + 2, bounds.Y + 2, bounds.Width, bounds.Height);
                    using (GraphicsPath shadowPath = CreateRoundedRectangle(shadowRect, RadiusLG))
                    {
                        e.Graphics.FillPath(shadowBrush, shadowPath);
                    }
                }
                
                // Draw card
                using (GraphicsPath path = CreateRoundedRectangle(bounds, RadiusLG))
                {
                    using (var fill = new SolidBrush(panel.BackColor))
                    {
                        e.Graphics.FillPath(fill, path);
                    }
                    using (var pen = new Pen(BorderLight, 1))
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

        public static void StyleInputField(Control container, TextBox textBox, PictureBox icon = null)
        {
            if (container == null || textBox == null) return;
            
            container.BackColor = InputBackground;
            container.Padding = new Padding(0, 8, 0, 8);
            
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = InputBackground;
            textBox.ForeColor = TextPrimary;
            textBox.Font = FontRegular;
            textBox.Dock = DockStyle.Fill;
            textBox.Margin = new Padding(icon != null ? 44 : 12, 0, 12, 0);
            
            if (icon != null)
            {
                icon.Dock = DockStyle.Left;
                icon.SizeMode = PictureBoxSizeMode.CenterImage;
                icon.Width = 44;
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
