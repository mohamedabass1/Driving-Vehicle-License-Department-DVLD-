using DVLDBusinessLayer;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmIssueDrivingLicenseFristTime : Form
    {
        int _LocalDrivingLicenseApplicationID = -1;

        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public frmIssueDrivingLicenseFristTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            ApplyIssueLicenseTheme();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmIssueDrivingLicenseFristTime_Load(object sender, System.EventArgs e)
        {
            txtNotes.Focus();
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {

                MessageBox.Show("Application is Not Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!_LocalDrivingLicenseApplication.PassedAllTests())
            {
                MessageBox.Show("Person shoude passed all tests first", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            if (LicenseID != -1)
            {
                MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlLocalDrivingLicenseApplicationInfoCard1.LoadLocalDrivingLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);

        }

        private void btnIssue_Click(object sender, System.EventArgs e)
        {
            int NewLicenseID = _LocalDrivingLicenseApplication.IssueLicenseFirstTime(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (NewLicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + NewLicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ApplyIssueLicenseTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);

            // =========================
            // 📝 Label
            // =========================
            label3.ForeColor = textGray;

            // =========================
            // 📥 Notes TextBox
            // =========================
            txtNotes.BackColor = Color.FromArgb(15, 23, 42);
            txtNotes.ForeColor = textWhite;

            // =========================
            // 🔘 Buttons
            // =========================

            // Issue (Primary)
            btnIssue.BackColor = primaryBlue;
            btnIssue.ForeColor = Color.White;
            btnIssue.FlatStyle = FlatStyle.Flat;
            btnIssue.FlatAppearance.BorderSize = 0;

            // Close (Secondary)
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            // Hover Effects
            btnIssue.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // =========================
            // 🖼️ Icon
            // =========================
            pictureBox4.BackColor = Color.Transparent;

            // ❗ بدون تغيير:
            // Size ❌
            // Location ❌
            // Font ❌
        }
    }
}
