using DVLDBusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Tests.Test_Type
{
    public partial class frmListTestTypes : Form
    {
        private DataTable dtTestTypes;
        public frmListTestTypes()
        {
            InitializeComponent();
            ApplyTestTypesTheme();
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            dtTestTypes = clsTestType.GetAllTestTypes();
            dgvTestTypes.DataSource = dtTestTypes;

            lblTotalRecords.Text = dgvTestTypes.Rows.Count.ToString();

            if (dgvTestTypes.Rows.Count > 0)
            {
                dgvTestTypes.Columns[0].HeaderText = "ID";
                dgvTestTypes.Columns[0].Width = 100;

                dgvTestTypes.Columns[1].HeaderText = "Title";
                dgvTestTypes.Columns[1].Width = 150;

                dgvTestTypes.Columns[2].HeaderText = "Description";
                dgvTestTypes.Columns[2].Width = 400;

                dgvTestTypes.Columns[3].HeaderText = "Fees";
                dgvTestTypes.Columns[3].Width = 100;

            }
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUpdateTestType((clsTestType.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListTestTypes_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void ApplyTestTypesTheme()
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
            dgvTestTypes.BackgroundColor = card;
            dgvTestTypes.BorderStyle = BorderStyle.None;
            dgvTestTypes.EnableHeadersVisualStyles = false;

            // Header
            dgvTestTypes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 175);
            dgvTestTypes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Rows
            dgvTestTypes.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvTestTypes.DefaultCellStyle.ForeColor = textWhite;
            dgvTestTypes.DefaultCellStyle.SelectionBackColor = primaryBlue;
            dgvTestTypes.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid
            dgvTestTypes.GridColor = Color.FromArgb(51, 65, 85);

            // Row Header
            dgvTestTypes.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvTestTypes.RowHeadersDefaultCellStyle.ForeColor = textWhite;

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

            // ❗ بدون تغيير Layout
        }
    }
}
