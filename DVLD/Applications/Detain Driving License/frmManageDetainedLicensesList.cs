using DVLD.Applications.Rlease_Detained_License;
using DVLD.Licenses;
using DVLDBusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Applications.Detain_Driving_License
{
    public partial class frmManageDetainedLicensesList : Form
    {
        public frmManageDetainedLicensesList()
        {
            InitializeComponent();
            ApplyDetainedListTheme();
        }

        DataTable _dtDetainedLicenses;
        private void frmManageDetainedLicensesList_Load(object sender, EventArgs e)
        {
            _dtDetainedLicenses = clsDetainedLicense.GetAllDetainedLicenses();

            dgvDetainedLicenses.DataSource = _dtDetainedLicenses;


            lblRecordsCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
            if (dgvDetainedLicenses.Rows.Count > 0)
            {

                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 120;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 120;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 190;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 100;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 150;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 190;

                dgvDetainedLicenses.Columns[6].HeaderText = "N.No";
                dgvDetainedLicenses.Columns[6].Width = 100;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 300;

                dgvDetainedLicenses.Columns[8].HeaderText = "Release App.ID";
                dgvDetainedLicenses.Columns[8].Width = 150;


            }

            cbFilterBy.SelectedIndex = 0;

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Released")
            {
                txtFilterValue.Visible = false;
                cbFilterIsRelesedLicense.Visible = true;
                cbFilterIsRelesedLicense.Focus();
                cbFilterIsRelesedLicense.SelectedIndex = 0;
            }
            else
            {
                cbFilterIsRelesedLicense.Visible = false;
                txtFilterValue.Visible = (cbFilterBy.Text != "None");

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            _dtDetainedLicenses.DefaultView.RowFilter = "";

        }

        private void cbFilterIsRelesedLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = cbFilterIsRelesedLicense.Text;

            switch (FilterValue)
            {
                case "All":
                    break;

                case "Yes":
                    FilterValue = "1";
                    break;

                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _dtDetainedLicenses.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);


            lblRecordsCount.Text = dgvDetainedLicenses.Rows.Count.ToString();

        }

        private void ApplyFiltering()
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;

                case "Is Released":
                    FilterColumn = "IsReleased";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                _dtDetainedLicenses.DefaultView.RowFilter = $" [{FilterColumn}] = {txtFilterValue.Text.Trim()}";

            else
                _dtDetainedLicenses.DefaultView.RowFilter = $" [{FilterColumn}] LIKE  '{txtFilterValue.Text.Trim()}%'";


            lblRecordsCount.Text = dgvDetainedLicenses.Rows.Count.ToString();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            ApplyFiltering();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // this allow only digits if Person Id is selected
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewDetainLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainLicense();
            frm.ShowDialog();

            // refresh the list
            frmManageDetainedLicensesList_Load(null, null);
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();

            // refresh the list
            frmManageDetainedLicensesList_Load(null, null);
        }

        private void showPersonDetilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LiscenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.FindByLicenseID(LiscenseID).DriverInfo.PersonID;

            Form frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LiscenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;

            Form frm = new frmShowDriverLicenseInfo(LiscenseID);
            frm.ShowDialog();
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LiscenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.FindByLicenseID(LiscenseID).DriverInfo.PersonID;

            Form frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DetainID = (int)dgvDetainedLicenses.CurrentRow.Cells[0].Value;

            Form frm = new frmReleaseDetainedLicense(DetainID);
            frm.ShowDialog();

            // refresh the list
            frmManageDetainedLicensesList_Load(null, null);
        }

        private void cmsDetainedLicenses_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool IsReleased = (bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value;

            releaseDetainedLicenseToolStripMenuItem.Enabled = (!IsReleased);



        }


        private void ApplyDetainedListTheme()
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
            lblRecordsCount.ForeColor = textWhite;

            // =========================
            // 📥 Filters
            // =========================

            cbFilterBy.BackColor = Color.FromArgb(15, 23, 42);
            cbFilterBy.ForeColor = textWhite;
            cbFilterBy.FlatStyle = FlatStyle.Flat;

            txtFilterValue.BackColor = Color.FromArgb(15, 23, 42);
            txtFilterValue.ForeColor = textWhite;

            cbFilterIsRelesedLicense.BackColor = Color.FromArgb(15, 23, 42);
            cbFilterIsRelesedLicense.ForeColor = textWhite;
            cbFilterIsRelesedLicense.FlatStyle = FlatStyle.Flat;

            // =========================
            // 🔘 Buttons
            // =========================

            // Add (Detain)
            btnAddNewDetainLicense.BackColor = primaryBlue;
            btnAddNewDetainLicense.FlatStyle = FlatStyle.Flat;
            btnAddNewDetainLicense.FlatAppearance.BorderSize = 0;

            // Release
            btnReleaseLicense.BackColor = Color.FromArgb(34, 197, 94);
            btnReleaseLicense.FlatStyle = FlatStyle.Flat;
            btnReleaseLicense.FlatAppearance.BorderSize = 0;

            // Close
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // =========================
            // 🖼️ Image
            // =========================
            pbPersonImage.BackColor = Color.Transparent;

            // =========================
            // 📊 DataGridView
            // =========================

            dgvDetainedLicenses.BackgroundColor = card;
            dgvDetainedLicenses.BorderStyle = BorderStyle.None;
            dgvDetainedLicenses.EnableHeadersVisualStyles = false;

            // Header
            dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 175);
            dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Rows
            dgvDetainedLicenses.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvDetainedLicenses.DefaultCellStyle.ForeColor = textWhite;
            dgvDetainedLicenses.DefaultCellStyle.SelectionBackColor = primaryBlue;
            dgvDetainedLicenses.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid
            dgvDetainedLicenses.GridColor = Color.FromArgb(51, 65, 85);

            // Row Header
            dgvDetainedLicenses.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvDetainedLicenses.RowHeadersDefaultCellStyle.ForeColor = textWhite;

            // =========================
            // 🧾 Context Menu
            // =========================

            cmsDetainedLicenses.BackColor = card;
            cmsDetainedLicenses.ForeColor = textWhite;

            foreach (ToolStripItem item in cmsDetainedLicenses.Items)
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
