using DVLD.Licenses;
using DVLDBusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Applications.Rlease_Detained_License
{
    public partial class frmReleaseDetainedLicense : Form
    {
        int _DetainID = -1;
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
            ApplyReleaseLicenseTheme();

        }

        public frmReleaseDetainedLicense(int DetainID)
        {
            InitializeComponent();
            ApplyReleaseLicenseTheme();
            this._DetainID = DetainID;
        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            if (_DetainID == -1)
                return;

            ctrlDriverLicenseInfoCardWithFilter1.FilterEnabled = false;
            llShowLicensesHistory.Enabled = true;

            LoadDetainedLicenseData();

        }


        private void LoadDetainedLicenseData()
        {

            clsDetainedLicense detainedLicense = clsDetainedLicense.FindByID(_DetainID);
            if (detainedLicense == null)
            {
                MessageBox.Show($"Clude not found any Detained with ID: {_DetainID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlDriverLicenseInfoCardWithFilter1.LoadLicenseInfo(detainedLicense.LicenseID);

            lblDetainID.Text = _DetainID.ToString();
            lblLicenseID.Text = detainedLicense.LicenseID.ToString();
            lblDetainDate.Text = detainedLicense.DetainDate.ToShortDateString();
            lblCreatedby.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            lblFineFees.Text = detainedLicense.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();


            btnRelease.Enabled = true;
        }


        private void ctrlDriverLicenseInfoCardWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
                return;

            if (!ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is not detained, choose another one.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled = false;
                return;
            }

            clsLicense _SelectedLicenseInfo = ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo;

            lblDetainID.Text = _SelectedLicenseInfo.DetainInfo.DetainID.ToString();
            lblDetainDate.Text = _SelectedLicenseInfo.DetainInfo.DetainDate.ToShortDateString();
            lblCreatedby.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            lblFineFees.Text = _SelectedLicenseInfo.DetainInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();


            btnRelease.Enabled = true;
        }


        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to release this license?", "Cofirm",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            bool IsReleased = ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID);

            if (!IsReleased)
            {
                MessageBox.Show("Faild to Release the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License released Successfully",
                  "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblReleaseApplicationID.Text = ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.DetainInfo.ReleaseApplicationID.ToString();

            llShowLicenseInfo.Enabled = true;
            ctrlDriverLicenseInfoCardWithFilter1.FilterEnabled = false;
            btnRelease.Enabled = false;

        }


        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }
        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form frm = new frmShowDriverLicenseInfo(ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseID);
            frm.ShowDialog();
        }

        private void frmReleaseDetainedLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoCardWithFilter1.FilterFocus();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyReleaseLicenseTheme()
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

            // =========================
            // 📊 Values
            // =========================
            lblReleaseApplicationID.ForeColor = primaryBlue;
            lblLicenseID.ForeColor = textWhite;
            lblCreatedby.ForeColor = textWhite;
            lblDetainDate.ForeColor = textWhite;
            lblDetainID.ForeColor = textWhite;

            lblApplicationFees.ForeColor = textWhite;
            lblFineFees.ForeColor = Color.Orange;   // 💰 تنبيه
            lblTotalFees.ForeColor = primaryBlue;   // 🔥 أهم رقم

            // =========================
            // 🔗 Links
            // =========================
            llShowLicenseInfo.LinkColor = primaryBlue;
            llShowLicensesHistory.LinkColor = primaryBlue;

            llShowLicenseInfo.ActiveLinkColor = Color.LightBlue;
            llShowLicensesHistory.ActiveLinkColor = Color.LightBlue;

            // =========================
            // 🔘 Buttons
            // =========================

            // Primary Action
            btnRelease.BackColor = primaryBlue;
            btnRelease.ForeColor = Color.White;
            btnRelease.FlatStyle = FlatStyle.Flat;
            btnRelease.FlatAppearance.BorderSize = 0;

            // Secondary
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            // Hover
            btnRelease.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
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
            pictureBox9.BackColor = Color.Transparent;
            pictureBox10.BackColor = Color.Transparent;

            // ❗ بدون تغيير Layout
        }
    }
}
