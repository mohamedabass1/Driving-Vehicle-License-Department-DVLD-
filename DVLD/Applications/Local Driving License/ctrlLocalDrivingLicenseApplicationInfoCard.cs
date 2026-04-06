using DVLD.Licenses;
using DVLDBusinessLayer;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class ctrlLocalDrivingLicenseApplicationInfoCard : UserControl
    {

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public int SelectedLocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }


        public ctrlLocalDrivingLicenseApplicationInfoCard()
        {
            InitializeComponent();
            ApplyLocalAppCardTheme();
        }

        public void LoadLocalDrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalAppicationInfo();
                MessageBox.Show("Application is Not Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                _FillApplicationInfo();
        }

        private void _FillApplicationInfo()
        {
            llShowLicenseInfo.Enabled = _LocalDrivingLicenseApplication.IsLicenseIssued();
            _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseAppID;
            lblLocalApplicationID.Text = _LocalDrivingLicenseApplicationID.ToString();

            lblAppliedForLicense.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString();
            llShowLicenseInfo.Enabled = (_LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.Completed);

            // load the base application info 
            ctrlApplicationBasicInfoCard1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);
        }

        private void _ResetLocalAppicationInfo()
        {
            lblLocalApplicationID.Text = "[???]";
            lblAppliedForLicense.Text = "[???]";
            lblPassedTests.Text = "[0/0]";
            llShowLicenseInfo.Enabled = false;

            // Reset the base application info
            ctrlApplicationBasicInfoCard1.ResetApplicationInfo();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
            Form frm = new frmShowDriverLicenseInfo(LicenseID);
            frm.ShowDialog();

        }

        private void ApplyLocalAppCardTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 📦 GroupBox (العلوي)
            groupBox1.BackColor = Color.FromArgb(30, 41, 59);
            groupBox1.ForeColor = Color.White;

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);

            // =========================
            // 📝 Titles
            // =========================
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is Label lbl)
                {
                    if (lbl.Font.Bold)
                        lbl.ForeColor = textGray;
                }
            }

            // =========================
            // 📊 Values
            // =========================
            lblLocalApplicationID.ForeColor = primaryBlue;
            lblAppliedForLicense.ForeColor = primaryBlue;
            lblPassedTests.ForeColor = textWhite;

            // =========================
            // 🟢 Passed Tests (🔥 مهم)
            // =========================
            if (lblPassedTests.Text.Contains("/"))
            {
                string[] parts = lblPassedTests.Text.Split('/');
                if (parts.Length == 2 && parts[0] == parts[1])
                    lblPassedTests.ForeColor = Color.FromArgb(34, 197, 94); // Green ✔
                else
                    lblPassedTests.ForeColor = Color.FromArgb(234, 179, 8); // Yellow ⚠
            }

            // =========================
            // 🔗 Link
            // =========================
            llShowLicenseInfo.LinkColor = primaryBlue;
            llShowLicenseInfo.ActiveLinkColor = Color.LightBlue;

            // =========================
            // 🖼️ Icons
            // =========================
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;

            // ❗ بدون تغيير Layout
        }
    }
}
