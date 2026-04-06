using System.Drawing;
using System.Windows.Forms;

namespace DVLD
{
    public static class ThemeManager
    {
        public static class Theme
        {
            public static Color Background = Color.FromArgb(15, 23, 42);
            public static Color Card = Color.FromArgb(30, 41, 59);

            public static Color Primary = Color.FromArgb(59, 130, 246);

            public static Color TextPrimary = Color.FromArgb(226, 232, 240);
            public static Color TextSecondary = Color.FromArgb(148, 163, 184);

            public static Color Success = Color.FromArgb(34, 197, 94);
            public static Color Warning = Color.FromArgb(251, 191, 36);
            public static Color Danger = Color.FromArgb(239, 68, 68);

            public static Color ButtonSecondary = Color.FromArgb(71, 85, 105);
        }
        public static void ApplyTheme(Control parent)
        {
            // Form نفسه
            if (parent is Form)
                parent.BackColor = Theme.Background;

            foreach (Control ctrl in parent.Controls)
            {
                ApplyControlTheme(ctrl);

                // 🔁 Recursion (أهم شيء)
                if (ctrl.HasChildren)
                    ApplyTheme(ctrl);
            }
        }

        private static void ApplyControlTheme(Control ctrl)
        {
            // =========================
            // 📝 Label
            // =========================
            if (ctrl is Label lbl)
            {
                if (lbl.Font.Bold)
                    lbl.ForeColor = Theme.TextSecondary;
                else
                    lbl.ForeColor = Theme.TextPrimary;
            }

            // =========================
            // 🔘 Button
            // =========================
            else if (ctrl is Button btn)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;

                if (btn.Name.ToLower().Contains("save") ||
                    btn.Name.ToLower().Contains("add") ||
                    btn.Name.ToLower().Contains("create"))
                {
                    btn.BackColor = Theme.Primary;
                    btn.ForeColor = Color.White;
                }
                else if (btn.Name.ToLower().Contains("close") ||
                         btn.Name.ToLower().Contains("cancel"))
                {
                    btn.BackColor = Theme.ButtonSecondary;
                    btn.ForeColor = Color.White;
                }
            }

            // =========================
            // 📥 TextBox
            // =========================
            else if (ctrl is TextBox txt)
            {
                txt.BackColor = Theme.Background;
                txt.ForeColor = Theme.TextPrimary;
                txt.BorderStyle = BorderStyle.FixedSingle;
            }

            // =========================
            // 📊 DataGridView
            // =========================
            else if (ctrl is DataGridView dgv)
            {
                dgv.BackgroundColor = Theme.Card;
                dgv.BorderStyle = BorderStyle.None;
                dgv.EnableHeadersVisualStyles = false;

                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 175);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                dgv.DefaultCellStyle.BackColor = Theme.Background;
                dgv.DefaultCellStyle.ForeColor = Theme.TextPrimary;
                dgv.DefaultCellStyle.SelectionBackColor = Theme.Primary;

                dgv.GridColor = Color.FromArgb(51, 65, 85);
            }

            // =========================
            // 📦 GroupBox
            // =========================
            else if (ctrl is GroupBox gb)
            {
                gb.BackColor = Theme.Card;
                gb.ForeColor = Color.White;
            }

            // =========================
            // 🧾 ContextMenu
            // =========================
            else if (ctrl.ContextMenuStrip != null)
            {
                var cms = ctrl.ContextMenuStrip;
                cms.BackColor = Theme.Card;
                cms.ForeColor = Theme.TextPrimary;

                foreach (ToolStripItem item in cms.Items)
                {
                    if (item is ToolStripMenuItem menuItem)
                    {
                        menuItem.BackColor = Theme.Card;
                        menuItem.ForeColor = Theme.TextPrimary;
                    }
                }
            }
        }
    }
}
