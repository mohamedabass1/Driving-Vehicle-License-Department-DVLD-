using DVLD.Licenses;
using DVLDBusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Applications.Renew_License_Application
{
    public partial class frmRenewLicenseApplication : Form
    {
        int _NewLicenseID = -1;
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
            ApplyRenewLicenseTheme();
        }

        private void frmRenewLicenseApplication_Load(object sender, System.EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblExpirationDate.Text = "???";
        }
        private void ctrlDriverLicenseInfoCardWithFilter1_OnLicenseSelected(int obj)
        {
            int selectedLicenseID = obj;

            lblOldLicenseID.Text = selectedLicenseID.ToString();

            llShowLicensesHistory.Enabled = (selectedLicenseID != -1);

            if (selectedLicenseID == -1)
                return;

            int DefaultValidityLength = ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength;
            lblExpirationDate.Text = DateTime.Now.AddYears(DefaultValidityLength).ToShortDateString();
            lblLicenseFees.Text = ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            txtNotes.Text = ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.Notes;


            // we check if the license unactive
            if (!ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show($"Selected License is not active, Choose an active license",
                    "Not Allwoed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;

                return;
            }

            // we check if the is not expired
            if (!ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show($"Selected License is not yet expired, It will expired on: {ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.ExpirationDate} ",
                    "Not Allwoed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;

                return;
            }


            btnRenew.Enabled = true;


        }

        private void btnRenew_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLicense NewLicense = ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.
                RenewLicense(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);


            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblRenewLicenseApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblIRenewedLicenseID.Text = _NewLicenseID.ToString();

            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ctrlDriverLicenseInfoCardWithFilter1.FilterEnabled = false;
            btnRenew.Enabled = false;
            llShowNewLicenseInfo.Enabled = true;

        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowDriverLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void frmRenewLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoCardWithFilter1.FilterFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyRenewLicenseTheme()
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
            // 📦 GroupBox
            // =========================
            gpApplicationInfo.BackColor = card;
            gpApplicationInfo.ForeColor = Color.White;

            // =========================
            // 📝 Labels (Titles)
            // =========================
            foreach (Control ctrl in gpApplicationInfo.Controls)
            {
                if (ctrl is Label lbl && lbl.Font.Bold)
                {
                    lbl.ForeColor = textGray;
                }
            }

            // =========================
            // 📊 Values
            // =========================
            lblRenewLicenseApplicationID.ForeColor = primaryBlue;
            lblApplicationDate.ForeColor = textWhite;
            lblApplicationFees.ForeColor = textWhite;
            lblCreatedByUser.ForeColor = textWhite;
            lblIssueDate.ForeColor = textWhite;
            lblExpirationDate.ForeColor = textWhite;
            lblIRenewedLicenseID.ForeColor = primaryBlue;
            lblOldLicenseID.ForeColor = textWhite;
            lblLicenseFees.ForeColor = textWhite;
            lblTotalFees.ForeColor = primaryBlue;

            // =========================
            // 📥 Notes
            // =========================
            txtNotes.BackColor = Color.FromArgb(15, 23, 42);
            txtNotes.ForeColor = textWhite;

            // =========================
            // 🔗 Links
            // =========================
            llShowNewLicenseInfo.LinkColor = primaryBlue;
            llShowLicensesHistory.LinkColor = primaryBlue;

            llShowNewLicenseInfo.ActiveLinkColor = Color.LightBlue;
            llShowLicensesHistory.ActiveLinkColor = Color.LightBlue;

            // =========================
            // 🔘 Buttons
            // =========================

            // Primary Action
            btnRenew.BackColor = primaryBlue;
            btnRenew.ForeColor = Color.White;
            btnRenew.FlatStyle = FlatStyle.Flat;
            btnRenew.FlatAppearance.BorderSize = 0;

            // Secondary
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            // Hover
            btnRenew.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // =========================
            // 🖼️ Icons
            // =========================
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox6.BackColor = Color.Transparent;
            pictureBox7.BackColor = Color.Transparent;
            pictureBox8.BackColor = Color.Transparent;
            pictureBox9.BackColor = Color.Transparent;
            pictureBox10.BackColor = Color.Transparent;
            pictureBox11.BackColor = Color.Transparent;

            // ❗ بدون تغيير Layout
        }
    }
}
