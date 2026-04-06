using DVLD.Application_Type;
using DVLDBusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmListApplicationTypes : Form
    {
        public DataTable dt_ApplicationTypes;
        public frmListApplicationTypes()
        {
            InitializeComponent();
            //ApplyApplicationTypesTheme();
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            dt_ApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = dt_ApplicationTypes;


            lblTotalRecords.Text = dgvApplicationTypes.Rows.Count.ToString();

            if (dgvApplicationTypes.Rows.Count > 0)
            {

                dgvApplicationTypes.Columns[0].HeaderText = "ID";
                dgvApplicationTypes.Columns[0].Width = 120;

                dgvApplicationTypes.Columns[1].HeaderText = "Title";
                dgvApplicationTypes.Columns[1].Width = 300;

                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvApplicationTypes.Columns[2].Width = 150;

            }
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUpdateApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListApplicationTypes_Load(null, null);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyApplicationTypesTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);
            Color card = Color.FromArgb(30, 41, 59);

            // =========================
            // 🏷️ Title
            // =========================
            label1.ForeColor = primaryBlue;

            // =========================
            // 📝 Labels
            // =========================
            label3.ForeColor = textGray;
            lblTotalRecords.ForeColor = textWhite;

            // =========================
            // 🖼️ Image
            // =========================
            pictureBox1.BackColor = Color.Transparent;

            // =========================
            // 🔘 Close Button
            // =========================
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // =========================
            // 📊 DataGridView
            // =========================
            dgvApplicationTypes.BackgroundColor = card;
            dgvApplicationTypes.BorderStyle = BorderStyle.None;
            dgvApplicationTypes.EnableHeadersVisualStyles = false;

            // Header
            dgvApplicationTypes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 175);
            dgvApplicationTypes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Rows
            dgvApplicationTypes.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvApplicationTypes.DefaultCellStyle.ForeColor = textWhite;
            dgvApplicationTypes.DefaultCellStyle.SelectionBackColor = primaryBlue;
            dgvApplicationTypes.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid
            dgvApplicationTypes.GridColor = Color.FromArgb(51, 65, 85);

            // Row Header
            dgvApplicationTypes.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvApplicationTypes.RowHeadersDefaultCellStyle.ForeColor = textWhite;

            // =========================
            // 🧾 Context Menu
            // =========================
            contextMenuStrip1.BackColor = card;
            contextMenuStrip1.ForeColor = textWhite;

            foreach (ToolStripItem item in contextMenuStrip1.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.BackColor = card;
                    menuItem.ForeColor = textWhite;
                }
            }
        }
    }
}
