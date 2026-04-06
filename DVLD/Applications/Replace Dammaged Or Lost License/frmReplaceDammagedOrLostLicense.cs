using DVLD.Licenses;
using DVLDBusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Applications.Replace_Dammaged_Or_Lost_License
{
    public partial class frmReplaceDammagedOrLostLicense : Form
    {
        private int _NewLicenseID = -1;
        public frmReplaceDammagedOrLostLicense()
        {
            InitializeComponent();
            ApplyReplaceLicenseTheme();
        }

        private void frmReplaceDammagedOrLostLicense_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacment For Dammaged License";
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense).Fees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ctrlDriverLicenseInfoCardWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();

            llShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
                return;


            // we check if the license unactive
            if (!ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show($"Selected License is not active, Choose an active license",
                    "Not Allwoed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnReplace.Enabled = false;

                return;
            }

            btnReplace.Enabled = true;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue a Replacment for the license?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            clsLicense.enIssueReason issueReason = (rbDammagedLicense.Checked ? clsLicense.enIssueReason.ReplacementForDamaged : clsLicense.enIssueReason.ReplacementForLost);

            clsLicense NewLicense = ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.Replace(issueReason, clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Replace the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblReplaceLicenseApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblIReplacedLicenseID.Text = _NewLicenseID.ToString();

            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ctrlDriverLicenseInfoCardWithFilter1.FilterEnabled = false;
            btnReplace.Enabled = false;
            gpReplacementFor.Enabled = false;
            llShowNewLicenseInfo.Enabled = true;

        }
        private void frmReplaceDammagedOrLostLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoCardWithFilter1.FilterFocus();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLostLicense.Checked)
            {
                lblTitle.Text = "Replacment For Lost License";
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReplaceLostDrivingLicense).Fees.ToString();
            }
            else
            {
                lblTitle.Text = "Replacment For Dammaged License";
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense).Fees.ToString();
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyReplaceLicenseTheme()
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
            lblTitle.ForeColor = primaryBlue;

            // =========================
            // 📦 Application Info
            // =========================
            gpApplicationInfo.BackColor = card;
            gpApplicationInfo.ForeColor = Color.White;

            foreach (Control ctrl in gpApplicationInfo.Controls)
            {
                if (ctrl is Label lbl && lbl.Font.Bold)
                {
                    lbl.ForeColor = textGray;
                }
            }

            // Values
            lblReplaceLicenseApplicationID.ForeColor = primaryBlue;
            lblApplicationDate.ForeColor = textWhite;
            lblApplicationFees.ForeColor = textWhite;
            lblCreatedByUser.ForeColor = textWhite;
            lblIReplacedLicenseID.ForeColor = primaryBlue;
            lblOldLicenseID.ForeColor = textWhite;

            // =========================
            // 📦 Replacement Type
            // =========================
            gpReplacementFor.BackColor = card;
            gpReplacementFor.ForeColor = Color.White;

            rbDammagedLicense.ForeColor = textWhite;
            rbLostLicense.ForeColor = textWhite;

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
            btnReplace.BackColor = primaryBlue;
            btnReplace.ForeColor = Color.White;
            btnReplace.FlatStyle = FlatStyle.Flat;
            btnReplace.FlatAppearance.BorderSize = 0;

            // Secondary
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            // Hover
            btnReplace.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // =========================
            // 🖼️ Icons
            // =========================
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox7.BackColor = Color.Transparent;
            pictureBox8.BackColor = Color.Transparent;

            // ❗ بدون تغيير Layout
        }
    }
}
