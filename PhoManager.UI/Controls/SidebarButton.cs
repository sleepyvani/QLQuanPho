using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PhoManager.UI.Helpers;

namespace PhoManager.UI.Controls
{
    public class SidebarButton : Button
    {
        private string glyph = IconGlyphs.Dashboard;
        private bool isActive;

        [Browsable(true)]
        [Category("Appearance")]
        public string Glyph
        {
            get => glyph;
            set
            {
                glyph = value;
                RefreshIcon();
            }
        }

        [Browsable(false)]
        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                UpdateState();
            }
        }

        public SidebarButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = ThemeManager.SidebarColor;
            ForeColor = Color.FromArgb(148, 163, 184); // Slate-400
            Font = new Font("Segoe UI Semibold", 10F);
            Height = 48;
            Dock = DockStyle.Top;
            TextAlign = ContentAlignment.MiddleLeft;
            ImageAlign = ContentAlignment.MiddleLeft;
            TextImageRelation = TextImageRelation.ImageBeforeText;
            Padding = new Padding(18, 0, 12, 0);
            Cursor = Cursors.Hand;
            RefreshIcon();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            UpdateState();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!IsActive)
            {
                BackColor = Color.FromArgb(51, 65, 85); // Slate-700
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!IsActive)
            {
                BackColor = ThemeManager.SidebarColor;
            }
        }

        private void UpdateState()
        {
            if (IsActive)
            {
                BackColor = ThemeManager.SidebarActive; // Blue-500
                ForeColor = Color.White;
            }
            else
            {
                BackColor = ThemeManager.SidebarColor;
                ForeColor = Color.FromArgb(148, 163, 184); // Slate-400
            }

            RefreshIcon();
        }

        private void RefreshIcon()
        {
            Image = ThemeManager.CreateGlyphIcon(glyph, IsActive ? Color.White : Color.FromArgb(148, 163, 184), 24);
        }
    }
}

