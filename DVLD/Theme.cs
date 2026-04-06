using System.Drawing;
using System.Windows.Forms;

public static class Theme
{
    // 🎯 Colors
    public static Color Background = Color.FromArgb(15, 23, 42);
    public static Color Card = Color.FromArgb(30, 41, 59);
    public static Color Primary = Color.FromArgb(59, 130, 246);
    public static Color Text = Color.FromArgb(226, 232, 240);
    public static Color SubText = Color.FromArgb(148, 163, 184);
    public static Color Danger = Color.FromArgb(239, 68, 68);
    public static Color Success = Color.FromArgb(34, 197, 94);

    // =========================
    // 🔥 Apply Theme (Main)
    // =========================
    public static void Apply(Form form)
    {
        form.BackColor = Background;

        foreach (Control ctrl in form.Controls)
        {
            ApplyControl(ctrl);
        }
    }

    // =========================
    // 🔁 Apply لكل Control
    // =========================
    private static void ApplyControl(Control ctrl)
    {
        // =========================
        // 📝 Label
        // =========================
        if (ctrl is Label lbl)
        {
            if (lbl.Font.Bold)
                lbl.ForeColor = SubText;
            else
                lbl.ForeColor = Text;
        }

        // =========================
        // 🔘 Button
        // =========================
        else if (ctrl is Button btn)
        {
            btn.BackColor = Primary;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
        }

        // =========================
        // 📥 TextBox
        // =========================
        else if (ctrl is TextBox txt)
        {
            txt.BackColor = Background;
            txt.ForeColor = Text;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        // =========================
        // 📥 ComboBox
        // =========================
        else if (ctrl is ComboBox cb)
        {
            cb.BackColor = Background;
            cb.ForeColor = Text;
            cb.FlatStyle = FlatStyle.Flat;
        }

        // =========================
        // 📦 GroupBox
        // =========================
        else if (ctrl is GroupBox gb)
        {
            gb.BackColor = Card;
            gb.ForeColor = Color.White;
        }

        // =========================
        // 📊 DataGridView
        // =========================
        else if (ctrl is DataGridView dgv)
        {
            dgv.BackgroundColor = Card;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 175);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv.DefaultCellStyle.BackColor = Background;
            dgv.DefaultCellStyle.ForeColor = Text;
            dgv.DefaultCellStyle.SelectionBackColor = Primary;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.GridColor = Color.FromArgb(51, 65, 85);
        }

        // =========================
        // 📑 TabControl
        // =========================
        else if (ctrl is TabControl tab)
        {
            tab.BackColor = Background;

            foreach (TabPage page in tab.TabPages)
            {
                page.BackColor = Background;

                foreach (Control c in page.Controls)
                {
                    ApplyControl(c);
                }
            }
        }

        // =========================
        // 🔗 LinkLabel
        // =========================
        else if (ctrl is LinkLabel link)
        {
            link.LinkColor = Primary;
            link.ActiveLinkColor = Color.LightBlue;
        }

        // =========================
        // 🧾 ContextMenu
        // =========================
        else if (ctrl is ContextMenuStrip cms)
        {
            cms.BackColor = Card;
            cms.ForeColor = Text;

            foreach (ToolStripItem item in cms.Items)
            {
                if (item is ToolStripMenuItem menu)
                {
                    menu.BackColor = Card;
                    menu.ForeColor = Text;
                }
            }
        }

        // =========================
        // 🖼️ PictureBox
        // =========================
        else if (ctrl is PictureBox pic)
        {
            pic.BackColor = Color.Transparent;
        }

        // =========================
        // 🔁 Recursive
        // =========================
        foreach (Control child in ctrl.Controls)
        {
            ApplyControl(child);
        }
    }
}