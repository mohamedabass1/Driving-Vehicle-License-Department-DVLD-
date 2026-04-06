using DVLD.Licenses;
using DVLDBusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Applications.Inertnational_Driving_License
{
    public partial class frmManageInternationalLicenseList : Form
    {
        public frmManageInternationalLicenseList()
        {
            InitializeComponent();
            ApplyInternationalListTheme();
        }

        DataTable _dtInternationalDrivingLicesnses;
        private void frmManagInternationalLicenseList_Load(object sender, EventArgs e)
        {
            _dtInternationalDrivingLicesnses = clsInternationalLicense.GetAllInternationalLicenses();
            dgvInternationalDrivingLicesnses.DataSource = _dtInternationalDrivingLicesnses;

            cbFilterBy.SelectedIndex = 0;


            lblRecordsCount.Text = dgvInternationalDrivingLicesnses.Rows.Count.ToString();

            if (dgvInternationalDrivingLicesnses.Rows.Count > 0)
            {
                dgvInternationalDrivingLicesnses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalDrivingLicesnses.Columns[0].Width = 120;

                dgvInternationalDrivingLicesnses.Columns[1].HeaderText = "Application ID";
                dgvInternationalDrivingLicesnses.Columns[1].Width = 120;

                dgvInternationalDrivingLicesnses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalDrivingLicesnses.Columns[2].Width = 120;

                dgvInternationalDrivingLicesnses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalDrivingLicesnses.Columns[3].Width = 120;

                dgvInternationalDrivingLicesnses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalDrivingLicesnses.Columns[4].Width = 260;

                dgvInternationalDrivingLicesnses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalDrivingLicesnses.Columns[5].Width = 260;

                dgvInternationalDrivingLicesnses.Columns[6].HeaderText = "Is Active";
                dgvInternationalDrivingLicesnses.Columns[6].Width = 150;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbFilterActiveLicense.Visible = true;
                cbFilterActiveLicense.Focus();
                cbFilterActiveLicense.SelectedIndex = 0;

            }

            else
            {
                cbFilterActiveLicense.Visible = false;
                txtFilterValue.Visible = (cbFilterBy.Text != "None");

                txtFilterValue.Text = "";
                txtFilterValue.Focus();

            }

        }

        private void cbFilterActiveLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbFilterActiveLicense.Text;

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
                _dtInternationalDrivingLicesnses.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtInternationalDrivingLicesnses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);


            lblRecordsCount.Text = dgvInternationalDrivingLicesnses.Rows.Count.ToString();


        }


        private void ApplyFiltering()
        {

            //            None
            //Internatonal License ID
            //Application ID
            //Driver ID
            //Local License ID
            //Is Active
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Internatonal License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;

                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtInternationalDrivingLicesnses.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvInternationalDrivingLicesnses.Rows.Count.ToString();
                return;
            }




            _dtInternationalDrivingLicesnses.DefaultView.RowFilter = $" [{FilterColumn}] = {txtFilterValue.Text.Trim()}";



            lblRecordsCount.Text = dgvInternationalDrivingLicesnses.Rows.Count.ToString();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            ApplyFiltering();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void btnAddNewInertnationalApplication_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddNewInertrnationalDrivingLicense();
            frm.ShowDialog();
            frmManagInternationalLicenseList_Load(null, null);
        }

        private void showPersonDetilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalDrivingLicesnses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.Find(DriverID).PersonID;

            Form frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();

        }

        private void showLicenseDetilesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int InternationalLicenseID = (int)dgvInternationalDrivingLicesnses.CurrentRow.Cells[0].Value;
            Form frm = new frmShowDriverInternationalLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalDrivingLicesnses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.Find(DriverID).PersonID;


            Form frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void ApplyInternationalListTheme()
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
            // 📥 Filter
            // =========================

            cbFilterBy.BackColor = Color.FromArgb(15, 23, 42);
            cbFilterBy.ForeColor = textWhite;
            cbFilterBy.FlatStyle = FlatStyle.Flat;

            txtFilterValue.BackColor = Color.FromArgb(15, 23, 42);
            txtFilterValue.ForeColor = textWhite;

            cbFilterActiveLicense.BackColor = Color.FromArgb(15, 23, 42);
            cbFilterActiveLicense.ForeColor = textWhite;
            cbFilterActiveLicense.FlatStyle = FlatStyle.Flat;

            // =========================
            // 🔘 Add Button
            // =========================
            btnAddNewInertnationalApplication.BackColor = primaryBlue;
            btnAddNewInertnationalApplication.FlatStyle = FlatStyle.Flat;
            btnAddNewInertnationalApplication.FlatAppearance.BorderSize = 0;

            // =========================
            // 🔘 Close Button
            // =========================
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // =========================
            // 🖼️ Images
            // =========================
            pictureBox1.BackColor = Color.Transparent;
            pbPersonImage.BackColor = Color.Transparent;

            // =========================
            // 📊 DataGridView (🔥 أهم جزء)
            // =========================

            dgvInternationalDrivingLicesnses.BackgroundColor = card;
            dgvInternationalDrivingLicesnses.BorderStyle = BorderStyle.None;
            dgvInternationalDrivingLicesnses.EnableHeadersVisualStyles = false;

            // Header
            dgvInternationalDrivingLicesnses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 175);
            dgvInternationalDrivingLicesnses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Rows
            dgvInternationalDrivingLicesnses.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvInternationalDrivingLicesnses.DefaultCellStyle.ForeColor = textWhite;
            dgvInternationalDrivingLicesnses.DefaultCellStyle.SelectionBackColor = primaryBlue;
            dgvInternationalDrivingLicesnses.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid
            dgvInternationalDrivingLicesnses.GridColor = Color.FromArgb(51, 65, 85);

            // Row Header
            dgvInternationalDrivingLicesnses.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvInternationalDrivingLicesnses.RowHeadersDefaultCellStyle.ForeColor = textWhite;

            // =========================
            // 🧾 Context Menu
            // =========================

            cmsInternationalApplication.BackColor = Color.FromArgb(30, 41, 59);
            cmsInternationalApplication.ForeColor = textWhite;

            foreach (ToolStripItem item in cmsInternationalApplication.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.BackColor = Color.FromArgb(30, 41, 59);
                    menuItem.ForeColor = textWhite;
                }
            }

            // ❗ بدون تغيير Layout
        }
    }
}
