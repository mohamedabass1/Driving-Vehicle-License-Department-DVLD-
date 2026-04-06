using DVLD.Licenses;
using DVLD.Tests;
using DVLDBusinessLayer;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmShowLocalDrivingLicenseApplicationsList : Form
    {
        public frmShowLocalDrivingLicenseApplicationsList()
        {
            InitializeComponent();
            ApplyLocalApplicationsListTheme();

            // Theme.Apply(this);
        }

        private DataTable _dtLocalDirvingLecenseApplications;
        private void frmShowLocalDrivingLicenseApplicationsList_Load(object sender, System.EventArgs e)
        {
            _dtLocalDirvingLecenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvLocalDrivingLicenseApplications.DataSource = _dtLocalDirvingLecenseApplications;

            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
            if (dgvLocalDrivingLicenseApplications.Rows.Count > 0)
            {

                // dgvLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicenseApplications.Columns[0].Width = 120;

                // dgvLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplications.Columns[1].Width = 300;

                // dgvLocalDrivingLicenseApplications.Columns[2].HeaderText = "National No";
                dgvLocalDrivingLicenseApplications.Columns[2].Width = 150;

                //dgvLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplications.Columns[3].Width = 350;

                //  dgvLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplications.Columns[4].Width = 170;

                //dgvLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplications.Columns[5].Width = 150;
            }

            cbFilterBy.SelectedIndex = 0;

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Focus();
                txtFilterValue.Text = "";
            }

            _dtLocalDirvingLecenseApplications.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();



        }

        private void txtFilterValue_TextChanged(object sender, System.EventArgs e)
        {
            string FilterColumn = cbFilterBy.Text;

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtLocalDirvingLecenseApplications.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "L.D.L.AppID")
                //in this case we deal with integer not string.
                _dtLocalDirvingLecenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtLocalDirvingLecenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase L.D.L.AppID id is selected.
            if (cbFilterBy.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddNewApplication_Click(object sender, System.EventArgs e)
        {
            Form frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();

            //refresh
            frmShowLocalDrivingLicenseApplicationsList_Load(null, null);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            Form frm = new frmAddUpdateLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();

            //refresh
            frmShowLocalDrivingLicenseApplicationsList_Load(null, null);
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

            if (MessageBox.Show("Are you sure wants to delete this application", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

                clsLocalDrivingLicenseApplication ApplicationToDelete = clsLocalDrivingLicenseApplication.
                    FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);


                if (ApplicationToDelete != null)
                {

                    if (ApplicationToDelete.Delete())
                    {
                        MessageBox.Show("Application deleted successfully", "Deleted",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // refresh after deleting
                        frmShowLocalDrivingLicenseApplicationsList_Load(null, null);

                    }
                    else
                    {
                        MessageBox.Show("Could not delete  application,another data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;


            Form frm = new frmShowLocalDrivingLicenseApplicationInfo(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();

            // refresh after deleting
            frmShowLocalDrivingLicenseApplicationsList_Load(null, null);

        }

        private void CancelApplicationtoolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure wants to cancel this application", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information) == DialogResult.No)
                return;


            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;


            clsLocalDrivingLicenseApplication ApplicationToCancel = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(
            LocalDrivingLicenseApplicationID);

            if (ApplicationToCancel.Cancel())
            {
                MessageBox.Show("Application Canceled successfully", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // refresh after deleting
                frmShowLocalDrivingLicenseApplicationsList_Load(null, null);

            }
            else
            {
                MessageBox.Show("Could not delete  application,another data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }


        private void _SchduleTest(clsTestType.enTestType TestType)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            Form frm = new frmListTestAppointments(LocalDrivingLicenseApplicationID, TestType);
            frm.ShowDialog();

            frmShowLocalDrivingLicenseApplicationsList_Load(null, null);
        }
        private void scheduleVisionTestToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            _SchduleTest(clsTestType.enTestType.VisionTest);

        }

        private void scheduleWritingTestToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            _SchduleTest(clsTestType.enTestType.WrittenTest);

        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            _SchduleTest(clsTestType.enTestType.StreetTest);

        }


        private void showLicensetoolStripMenuItem3_Click(object sender, System.EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            int LicenseID = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID
                (LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                Form frm = new frmShowDriverLicenseInfo(LicenseID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            Form frm = new frmIssueDrivingLicenseFristTime(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();

            frmShowLocalDrivingLicenseApplicationsList_Load(null, null);

        }

        private void showPersonLicenseHistorytoolStripMenuItem4_Click(object sender, System.EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            int PersonID = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID).ApplicantPersonID;

            Form frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();

            frmShowLocalDrivingLicenseApplicationsList_Load(null, null);

        }

        private void cmsApplications_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.
                   FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);


            int TotalPassedTests = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;
            bool IsLicenseIssued = LocalDrivingLicenseApplication.IsLicenseIssued();


            issueDrivingLicenseToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !IsLicenseIssued;

            showLicensetoolStripMenuItem3.Enabled = IsLicenseIssued;
            scheduleStreetTestToolStripMenuItem.Enabled = IsLicenseIssued;

            editApplicationToolStripMenuItem.Enabled = !IsLicenseIssued && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //We only canel the applications with status=new.
            CancelApplicationtoolStripMenuItem1.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //We only Delete the applications with status=new.
            deleteApplicationToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);


            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest);
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreatTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.StreetTest);

            scheduleTestsToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreatTest) &&
                (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);


            if (scheduleTestsToolStripMenuItem.Enabled)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                scheduleWritingTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreatTest;
            }


        }

        private void ApplyLocalApplicationsListTheme()
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

            // =========================
            // 🔘 Add Button
            // =========================
            btnAddNewApplication.BackColor = primaryBlue;
            btnAddNewApplication.FlatStyle = FlatStyle.Flat;
            btnAddNewApplication.FlatAppearance.BorderSize = 0;

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

            dgvLocalDrivingLicenseApplications.BackgroundColor = card;
            dgvLocalDrivingLicenseApplications.BorderStyle = BorderStyle.None;
            dgvLocalDrivingLicenseApplications.EnableHeadersVisualStyles = false;

            // Header
            dgvLocalDrivingLicenseApplications.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 175);
            dgvLocalDrivingLicenseApplications.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Rows
            dgvLocalDrivingLicenseApplications.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvLocalDrivingLicenseApplications.DefaultCellStyle.ForeColor = textWhite;
            dgvLocalDrivingLicenseApplications.DefaultCellStyle.SelectionBackColor = primaryBlue;
            dgvLocalDrivingLicenseApplications.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid
            dgvLocalDrivingLicenseApplications.GridColor = Color.FromArgb(51, 65, 85);

            // Row Header
            dgvLocalDrivingLicenseApplications.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvLocalDrivingLicenseApplications.RowHeadersDefaultCellStyle.ForeColor = textWhite;

            // =========================
            // 🧾 Context Menu (🔥 مهم جداً)
            // =========================

            cmsApplications.BackColor = Color.FromArgb(30, 41, 59);
            cmsApplications.ForeColor = textWhite;

            foreach (ToolStripItem item in cmsApplications.Items)
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
