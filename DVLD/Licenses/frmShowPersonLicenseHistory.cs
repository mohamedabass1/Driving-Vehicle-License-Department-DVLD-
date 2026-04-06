using DVLD.Applications.Inertnational_Driving_License;
using DVLDBusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        int _PersonID = -1;
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            ApplyLicenseHistoryTheme();
            _PersonID = PersonID;
        }

        clsDriver _Driver;
        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

            _Driver = clsDriver.FindByPersonID(_PersonID);

            if (_Driver != null)
            {
                _LoadDriverLocalLicenses();
                _LoadInternationalDrivingLicesnses();
            }

        }

        DataTable _dtLcocalDrivingLicesnesList;
        private void _LoadDriverLocalLicenses()
        {


            _dtLcocalDrivingLicesnesList = _Driver.GetLicenses();

            dgvLocalDrivingLicesnses.DataSource = _dtLcocalDrivingLicesnesList;

            lblTotalLocalDrivingLicenses.Text = dgvLocalDrivingLicesnses.Rows.Count.ToString();

            if (dgvLocalDrivingLicesnses.Rows.Count > 0)
            {
                dgvLocalDrivingLicesnses.Columns[0].HeaderText = "Lic.ID";
                dgvLocalDrivingLicesnses.Columns[0].Width = 120;

                dgvLocalDrivingLicesnses.Columns[1].HeaderText = "App.ID";
                dgvLocalDrivingLicesnses.Columns[1].Width = 120;

                dgvLocalDrivingLicesnses.Columns[2].HeaderText = "Class Name";
                dgvLocalDrivingLicesnses.Columns[2].Width = 320;

                dgvLocalDrivingLicesnses.Columns[3].HeaderText = "Issue Date";
                dgvLocalDrivingLicesnses.Columns[3].Width = 260;

                dgvLocalDrivingLicesnses.Columns[4].HeaderText = "Expiration Date";
                dgvLocalDrivingLicesnses.Columns[4].Width = 260;

                dgvLocalDrivingLicesnses.Columns[5].HeaderText = "Is Active";
                dgvLocalDrivingLicesnses.Columns[5].Width = 150;
            }

        }


        // we will bulid this feature when we perpere InternationalDrivingLicesnses Class
        DataTable _dtInternationalDrivingLicesnses;
        private void _LoadInternationalDrivingLicesnses()
        {
            _dtInternationalDrivingLicesnses = clsInternationalLicense.GetDriverInternationalLicenses(_Driver.DriverID);
            dgvInternationalDrivingLicesnses.DataSource = _dtInternationalDrivingLicesnses;

            lblTotalInternationalDrivingLicenses.Text = dgvInternationalDrivingLicesnses.Rows.Count.ToString();

            if (dgvInternationalDrivingLicesnses.Rows.Count > 0)
            {
                dgvInternationalDrivingLicesnses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalDrivingLicesnses.Columns[0].Width = 120;

                dgvInternationalDrivingLicesnses.Columns[1].HeaderText = "Application ID";
                dgvInternationalDrivingLicesnses.Columns[1].Width = 120;

                dgvInternationalDrivingLicesnses.Columns[2].HeaderText = "L.License ID";
                dgvInternationalDrivingLicesnses.Columns[2].Width = 120;

                dgvInternationalDrivingLicesnses.Columns[3].HeaderText = "Issue Date";
                dgvInternationalDrivingLicesnses.Columns[3].Width = 260;

                dgvInternationalDrivingLicesnses.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalDrivingLicesnses.Columns[4].Width = 260;

                dgvInternationalDrivingLicesnses.Columns[5].HeaderText = "Is Active";
                dgvInternationalDrivingLicesnses.Columns[5].Width = 150;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                int LicenseID = (int)dgvLocalDrivingLicesnses.CurrentRow.Cells[0].Value;
                Form frm = new frmShowDriverLicenseInfo(LicenseID);
                frm.ShowDialog();
            }
            else
            {
                int InternationalLicenseID = (int)dgvInternationalDrivingLicesnses.CurrentRow.Cells[0].Value;
                Form frm = new frmShowDriverInternationalLicenseInfo(InternationalLicenseID);
                frm.ShowDialog();
            }
        }

        private void ApplyLicenseHistoryTheme()
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
            // 🖼️ Image
            // =========================
            pictureBox1.BackColor = Color.Transparent;

            // =========================
            // 📦 GroupBox
            // =========================
            groupBox1.BackColor = card;
            groupBox1.ForeColor = Color.White;

            // =========================
            // 🔥 TabControl FIX
            // =========================
            tabControl1.BackColor = Color.FromArgb(15, 23, 42);
            tapLocal.BackColor = Color.FromArgb(15, 23, 42);
            tapInternational.BackColor = Color.FromArgb(15, 23, 42);

            // =========================
            // 📝 Labels
            // =========================
            label2.ForeColor = textGray;
            label3.ForeColor = textGray;
            label5.ForeColor = textGray;
            label7.ForeColor = textGray;

            lblTotalLocalDrivingLicenses.ForeColor = textWhite;
            lblTotalInternationalDrivingLicenses.ForeColor = textWhite;

            // =========================
            // 📊 Local Grid
            // =========================
            StyleGrid(dgvLocalDrivingLicesnses, card, primaryBlue, textWhite);

            // =========================
            // 📊 International Grid
            // =========================
            StyleGrid(dgvInternationalDrivingLicesnses, card, primaryBlue, textWhite);

            // =========================
            // 🧾 Context Menu
            // =========================
            cmsLocalDrivingLicense.BackColor = card;
            cmsLocalDrivingLicense.ForeColor = textWhite;

            foreach (ToolStripItem item in cmsLocalDrivingLicense.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.BackColor = card;
                    menuItem.ForeColor = textWhite;
                }
            }

            // =========================
            // 🔘 Button
            // =========================
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);
        }

        private void StyleGrid(DataGridView dgv, Color card, Color primaryBlue, Color textWhite)
        {
            dgv.BackgroundColor = card;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            // Header
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 175);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Rows
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgv.DefaultCellStyle.ForeColor = textWhite;
            dgv.DefaultCellStyle.SelectionBackColor = primaryBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid
            dgv.GridColor = Color.FromArgb(51, 65, 85);

            // Row Header
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgv.RowHeadersDefaultCellStyle.ForeColor = textWhite;
        }
    }
}
