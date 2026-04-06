using DVLD.Applications.Inertnational_Driving_License;
using DVLD.Licenses;
using DVLDBusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmAddNewInertrnationalDrivingLicense : Form
    {

        public frmAddNewInertrnationalDrivingLicense()
        {
            InitializeComponent();
            Theme.Apply(this);
            // ThemeEngine.Apply(this);
        }

        private void frmAddNewInertnationalDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoCardWithFilter1.Focus();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(clsLicenseClass.Find(3).DefaultValidityLength).ToShortDateString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
        }

        int _InternationalLicenseID = -1;

        private void ctrlDriverLicenseInfoCardWithFilter1_OnLicenseSelected(int LicenseID)
        {

            lblLocalLicenseID.Text = LicenseID.ToString();

            clsLicense selectedLicense = ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo;


            if (selectedLicense == null)
                return;


            llShowLicensesHistory.Enabled = true;

            if (selectedLicense.LicenseClassID != 3)
            {
                MessageBox.Show("Selected License Shoude be Class 3, Select another one.", "Not Allwod", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btnIssue.Enabled = false;
                llShowLicenseInfo.Enabled = false;



                return;
            }

            int activeLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(selectedLicense.DriverID);

            if (activeLicenseID != -1)
            {
                MessageBox.Show($"Person already have an active International license with ID = {activeLicenseID}",
                    "Not Allwod", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                _InternationalLicenseID = activeLicenseID;
                llShowLicenseInfo.Enabled = true;
                return;
            }

            btnIssue.Enabled = true;
        }


        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo == null)
                return;

            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            DateTime DateNow = DateTime.Now;
            clsLicense selectedLicense = ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo;


            // Create Application
            clsApplication Application = new clsApplication
            {
                ApplicantPersonID = selectedLicense.DriverInfo.PersonID,
                ApplicationDate = DateNow,
                ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense,
                ApplicationStatus = clsApplication.enApplicationStatus.New,
                LastStatusDate = DateNow,
                PaidFees = clsApplicationType
                    .Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees,
                CreatedByUserID = clsGlobal.CurrentUser.UserID
            };



            if (!Application.Save())
                return;


            lblApplicationID.Text = Application.ApplicationID.ToString();

            // Create International License
            clsInternationalLicense _InternationalLicense = new clsInternationalLicense
            {
                ApplicationID = Application.ApplicationID,
                DriverID = selectedLicense.DriverID,
                IssuedUsingLocalLicenseID = ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseID,
                IssueDate = DateNow,
                ExpirationDate = DateNow.AddYears(clsLicenseClass.Find(3).DefaultValidityLength),
                IsActive = true,
                CreatedByUserID = clsGlobal.CurrentUser.UserID
            };


            if (_InternationalLicense.Save())
            {
                Application.SetCompleted();

                MessageBox.Show($"Interational License Issude Successfully with ID {_InternationalLicense.InternationalLicenseID}"
                    , "License Issude", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _InternationalLicenseID = _InternationalLicense.InternationalLicenseID;
                lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                btnIssue.Enabled = false;

                llShowLicenseInfo.Enabled = true;
                ctrlDriverLicenseInfoCardWithFilter1.FilterEnabled = false;
            }
            else
            {
                MessageBox.Show($"Data was not saved"
                  , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                clsApplication.Delete(Application.ApplicationID);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_InternationalLicenseID != -1)
            {
                Form frm = new frmShowDriverInternationalLicenseInfo(_InternationalLicenseID);
                frm.ShowDialog();

            }
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo != null)
            {
                Form frm = new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
                frm.ShowDialog();
            }


        }
    }
}
