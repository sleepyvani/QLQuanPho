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
        /// <summary>
        /// Indicates whether the dark theme is currently active.  When true the colour
        /// palette will switch to darker shades and light foregrounds.  Use
        /// <see cref="SetTheme(bool)"/> to change this flag and update the static colour
        /// fields accordingly.  By default the application starts in light mode.
        /// </summary>
        public static bool IsDarkTheme { get; private set; } = false;

        /// <summary>
        /// The primary accent colour used for important buttons and highlights.
        /// Modern blue color - #3B82F6 (Blue-500)
        /// </summary>
        public static Color PrimaryColor = Color.FromArgb(59, 130, 246);

        /// <summary>
        /// A darker variation of the primary colour used on hover states.
        /// #2563EB (Blue-600)
        /// </summary>
        public static Color PrimaryDark = Color.FromArgb(37, 99, 235);

        /// <summary>
        /// A lighter variation of the primary colour for backgrounds.
        /// #DBEAFE (Blue-100)
        /// </summary>
        public static Color PrimaryLight = Color.FromArgb(219, 234, 254);

        /// <summary>
        /// A secondary accent colour used sparingly.
        /// #60A5FA (Blue-400)
        /// </summary>
        public static Color AccentColor = Color.FromArgb(96, 165, 250);

        /// <summary>
        /// Colour used for destructive actions like delete buttons.
        /// #EF4444 (Red-500)
        /// </summary>
        public static Color DangerColor = Color.FromArgb(239, 68, 68);

        /// <summary>
        /// Main text colour.  Adjusted depending on light/dark mode.
        /// #1E293B (Slate-800)
        /// </summary>
        public static Color TextColor = Color.FromArgb(30, 41, 59);

        /// <summary>
        /// Secondary text colour.
        /// #475569 (Slate-600)
        /// </summary>
        public static Color TextSecondary = Color.FromArgb(71, 85, 105);

        /// <summary>
        /// Muted text colour for secondary captions.
        /// #64748B (Slate-500)
        /// </summary>
        public static Color TextMuted = Color.FromArgb(100, 116, 139);

        /// <summary>
        /// Background colour for the main window and large panels.
        /// #F8FAFC (Slate-50)
        /// </summary>
        public static Color BackgroundColor = Color.FromArgb(248, 250, 252);

        /// <summary>
        /// Background colour for card-like panels and containers.
        /// </summary>
        public static Color PanelColor = Color.White;

        /// <summary>
        /// Background colour for input fields.
        /// #F1F5F9 (Slate-100)
        /// </summary>
        public static Color InputBackground = Color.FromArgb(241, 245, 249);

        /// <summary>
        /// Background colour for the sidebar.
        /// #1E293B (Slate-800)
        /// </summary>
        public static Color SidebarColor = Color.FromArgb(30, 41, 59);

        /// <summary>
        /// Background colour for the active sidebar button.
        /// Uses primary blue color
        /// </summary>
        public static Color SidebarActive = Color.FromArgb(59, 130, 246);

        /// <summary>
        /// Border color for subtle separators.
        /// #E2E8F0 (Slate-200)
        /// </summary>
        public static Color BorderColor = Color.FromArgb(226, 232, 240);

        /// <summary>
        /// When the user selects a custom logo this property is set.  If null then
        /// the default logo (file in Resources folder) will be used.  Forms
        /// displaying a logo should bind to this property rather than embedding
        /// the logo directly so that theme and configuration changes apply
        /// instantly.
        /// </summary>
        public static Image CustomLogoImage { get; set; }

        /// <summary>
        /// Switches the colour palette between light and dark modes.  When
        /// switching the static colour fields are updated immediately.  Call
        /// this method before styling controls or redrawing windows.  If you
        /// need to refresh existing controls after changing the theme you
        /// should manually call an update method on those controls (for
        /// example, FrmMain.ReloadTheme()).
        /// </summary>
        /// <param name="dark">True to enable dark mode; false for light.</param>
        public static void SetTheme(bool dark)
        {
            IsDarkTheme = dark;
            if (dark)
            {
                // Dark theme values - keeping blue as primary
                PrimaryColor = Color.FromArgb(59, 130, 246); // Blue-500
                PrimaryDark = Color.FromArgb(37, 99, 235); // Blue-600
                PrimaryLight = Color.FromArgb(30, 58, 138); // Blue-800
                AccentColor = Color.FromArgb(96, 165, 250); // Blue-400
                DangerColor = Color.FromArgb(239, 68, 68); // Red-500
                TextColor = Color.FromArgb(248, 250, 252); // Slate-50
                TextSecondary = Color.FromArgb(203, 213, 225); // Slate-300
                TextMuted = Color.FromArgb(148, 163, 184); // Slate-400
                BackgroundColor = Color.FromArgb(15, 23, 42); // Slate-900
                PanelColor = Color.FromArgb(30, 41, 59); // Slate-800
                InputBackground = Color.FromArgb(51, 65, 85); // Slate-700
                SidebarColor = Color.FromArgb(15, 23, 42); // Slate-900
                SidebarActive = Color.FromArgb(59, 130, 246); // Blue-500
                BorderColor = Color.FromArgb(51, 65, 85); // Slate-700
            }
            else
            {
                // Light theme values - Modern blue theme
                PrimaryColor = Color.FromArgb(59, 130, 246); // Blue-500
                PrimaryDark = Color.FromArgb(37, 99, 235); // Blue-600
                PrimaryLight = Color.FromArgb(219, 234, 254); // Blue-100
                AccentColor = Color.FromArgb(96, 165, 250); // Blue-400
                DangerColor = Color.FromArgb(239, 68, 68); // Red-500
                TextColor = Color.FromArgb(30, 41, 59); // Slate-800
                TextSecondary = Color.FromArgb(71, 85, 105); // Slate-600
                TextMuted = Color.FromArgb(100, 116, 139); // Slate-500
                BackgroundColor = Color.FromArgb(248, 250, 252); // Slate-50
                PanelColor = Color.White;
                InputBackground = Color.FromArgb(241, 245, 249); // Slate-100
                SidebarColor = Color.FromArgb(30, 41, 59); // Slate-800
                SidebarActive = Color.FromArgb(59, 130, 246); // Blue-500
                BorderColor = Color.FromArgb(226, 232, 240); // Slate-200
            }
        }

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
            grid.DefaultCellStyle.SelectionBackColor = PrimaryLight;
            grid.DefaultCellStyle.SelectionForeColor = TextColor;
            grid.RowTemplate.Height = 42;
            grid.GridColor = BorderColor;
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
                    backColor = Color.FromArgb(241, 245, 249); // Slate-100
                    hoverColor = Color.FromArgb(226, 232, 240); // Slate-200
                    foreColor = TextColor;
                    break;
                case ButtonVariant.Tertiary:
                    backColor = Color.White;
                    hoverColor = Color.FromArgb(248, 250, 252); // Slate-50
                    foreColor = TextColor;
                    break;
                case ButtonVariant.Danger:
                    backColor = DangerColor;
                    hoverColor = Color.FromArgb(220, 38, 38); // Red-600
                    foreColor = Color.White;
                    break;
                default:
                    backColor = Color.Transparent;
                    hoverColor = Color.FromArgb(241, 245, 249); // Slate-100
                    foreColor = TextColor;
                    break;
            }

            button.FlatStyle = FlatStyle.Flat;
            button.UseVisualStyleBackColor = false;
            button.FlatAppearance.BorderSize = variant == ButtonVariant.Secondary || variant == ButtonVariant.Ghost ? 1 : 0;
            if (button.FlatAppearance.BorderSize > 0)
            {
                button.FlatAppearance.BorderColor = variant == ButtonVariant.Secondary ? BorderColor : BorderColor;
            }
            // Note: Flat buttons don't have rounded corners by default in WinForms
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Font = new Font("Segoe UI Semibold", 10F);
            
            // Adjust height only for regular buttons (not large quick action buttons)
            if (button.Height < 50)
            {
                button.Height = Math.Max(button.Height, 42);
            }
            
            // Adjust padding and alignment based on button size and glyph
            if (button.Height >= 80)
            {
                // Large buttons: vertical layout
                button.TextImageRelation = TextImageRelation.ImageAboveText;
                button.ImageAlign = ContentAlignment.TopCenter;
                button.TextAlign = ContentAlignment.BottomCenter;
                button.Padding = new Padding(12, 12, 12, 8);
                if (!string.IsNullOrEmpty(glyph))
                {
                    button.Image = CreateGlyphIcon(glyph, foreColor, 32);
                }
            }
            else
            {
                // Regular buttons: horizontal layout
                button.Padding = new Padding(glyph == null ? 18 : 50, 0, 20, 0);
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.ImageAlign = ContentAlignment.MiddleLeft;
                button.TextImageRelation = TextImageRelation.ImageBeforeText;
                if (!string.IsNullOrEmpty(glyph))
                {
                    button.Image = CreateGlyphIcon(glyph, foreColor, 18);
                }
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
                // Draw border without rounded corners
                using (var pen = new Pen(BorderColor, 1))
                {
                    e.Graphics.DrawRectangle(pen, bounds);
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

