using DVLD.Licenses;
using DVLDBusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Drivers
{
    public partial class frmDriversList : Form
    {
        public frmDriversList()
        {
            InitializeComponent();
            ApplyDriversTheme();
        }

        DataTable _dtDriversList;
        private void frmDriversList_Load(object sender, EventArgs e)
        {
            _dtDriversList = clsDriver.GetAllDrivers();

            dgvDriversList.DataSource = _dtDriversList;

            lblTotalRecords.Text = dgvDriversList.Rows.Count.ToString();

            if (dgvDriversList.Rows.Count > 0)
            {
                dgvDriversList.Columns[0].HeaderText = "Driver ID";
                dgvDriversList.Columns[0].Width = 120;

                dgvDriversList.Columns[1].HeaderText = "Person ID";
                dgvDriversList.Columns[1].Width = 120;

                dgvDriversList.Columns[2].HeaderText = "National No";
                dgvDriversList.Columns[2].Width = 150;

                dgvDriversList.Columns[3].HeaderText = "Full Name";
                dgvDriversList.Columns[3].Width = 320;


                dgvDriversList.Columns[4].HeaderText = "Date";
                dgvDriversList.Columns[4].Width = 260;

                dgvDriversList.Columns[5].HeaderText = "Active Licenses";
                dgvDriversList.Columns[5].Width = 150;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");
            txtFilterValue.Text = "";
            txtFilterValue.Focus();

        }

        private void ApplayFitring()
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtDriversList.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvDriversList.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "DriverID" || FilterColumn == "PersonID")
                _dtDriversList.DefaultView.RowFilter = $" [{FilterColumn}] = {txtFilterValue.Text.Trim()}";

            else
                _dtDriversList.DefaultView.RowFilter = $" [{FilterColumn}] LIKE  '{txtFilterValue.Text.Trim()}%'";


            lblTotalRecords.Text = dgvDriversList.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            ApplayFitring();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // this allow only digits if Person Id is selected
            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDriversList.CurrentRow.Cells[1].Value;

            Form frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();

            // refresh
            frmDriversList_Load(null, null);

        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showPersonLicenseHistorytoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDriversList.CurrentRow.Cells[1].Value;

            Form frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void ApplyDriversTheme()
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
            label2.ForeColor = textGray;
            label3.ForeColor = textGray;
            lblTotalRecords.ForeColor = textWhite;

            // =========================
            // 📥 ComboBox
            // =========================
            cbFilterBy.BackColor = Color.FromArgb(15, 23, 42);
            cbFilterBy.ForeColor = textWhite;
            cbFilterBy.FlatStyle = FlatStyle.Flat;

            // =========================
            // 📥 TextBox
            // =========================
            txtFilterValue.BackColor = Color.FromArgb(15, 23, 42);
            txtFilterValue.ForeColor = textWhite;

            // =========================
            // 🔘 Close Button
            // =========================
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // =========================
            // 🖼️ Image
            // =========================
            pictureBox1.BackColor = Color.Transparent;

            // =========================
            // 📊 DataGridView (🔥 أهم جزء)
            // =========================

            dgvDriversList.BackgroundColor = card;
            dgvDriversList.BorderStyle = BorderStyle.None;
            dgvDriversList.EnableHeadersVisualStyles = false;

            // Header
            dgvDriversList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 175);
            dgvDriversList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Rows
            dgvDriversList.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvDriversList.DefaultCellStyle.ForeColor = textWhite;
            dgvDriversList.DefaultCellStyle.SelectionBackColor = primaryBlue;
            dgvDriversList.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid
            dgvDriversList.GridColor = Color.FromArgb(51, 65, 85);

            // Row Header
            dgvDriversList.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvDriversList.RowHeadersDefaultCellStyle.ForeColor = textWhite;

            // =========================
            // 🧾 Context Menu
            // =========================

            contextMenuStrip1.BackColor = Color.FromArgb(30, 41, 59);
            contextMenuStrip1.ForeColor = textWhite;

            foreach (ToolStripItem item in contextMenuStrip1.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.BackColor = Color.FromArgb(30, 41, 59);
                    menuItem.ForeColor = textWhite;
                }
            }

            // ❗ بدون تغيير:
            // Size ❌
            // Location ❌
            // Font ❌
        }
    }
}
