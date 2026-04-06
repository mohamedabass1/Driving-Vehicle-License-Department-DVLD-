using DVLD.Properties;
using DVLDBusinessLayer;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Applications.Inertnational_Driving_License
{
    public partial class ctrlInternationalLicenseInfoCard : UserControl
    {
        private int _InternationalLicenseID = -1;
        private clsInternationalLicense _InternationalLicense;

        public int SelectedInternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }

        public clsInternationalLicense SelectedInternationalLicense
        {
            get { return _InternationalLicense; }
        }
        public ctrlInternationalLicenseInfoCard()
        {
            InitializeComponent();
            ApplyInternationalLicenseTheme();
        }


        public void LoadDriverInternationalLicenseInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);

            if (_InternationalLicense == null)
            {
                MessageBox.Show($"International license with ID{_InternationalLicense} does not exist", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillCardInfo();
        }

        private void _FillCardInfo()
        {
            lblFullName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName;
            lblinternationaltLicenseID.Text = _InternationalLicenseID.ToString();
            lblLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = (_InternationalLicense.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female");
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            lblAppliationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = (_InternationalLicense.IsActive ? "Yes" : "No");
            lblDateOfBirth.Text = (_InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString());
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();

            _LoadPersonImage();

        }

        private void _LoadPersonImage()
        {
            if (_InternationalLicense.DriverInfo.PersonInfo.Gender == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Cloud not find this Image: " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void groupBox1_Enter(object sender, System.EventArgs e)
        {

        }
        private void ApplyInternationalLicenseTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 📦 GroupBox
            groupBox1.BackColor = Color.FromArgb(30, 41, 59);
            groupBox1.ForeColor = Color.White;

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);

            // =========================
            // 📝 Titles (Bold Labels)
            // =========================
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is Label lbl && lbl.Font.Bold)
                {
                    lbl.ForeColor = textGray;
                }
            }

            // =========================
            // 📊 Values
            // =========================
            lblinternationaltLicenseID.ForeColor = primaryBlue;
            lblAppliationID.ForeColor = textWhite;
            lblDriverID.ForeColor = textWhite;
            lblNationalNo.ForeColor = textWhite;
            lblGendor.ForeColor = textWhite;
            lblIssueDate.ForeColor = textWhite;
            lblDateOfBirth.ForeColor = textWhite;
            lblExpirationDate.ForeColor = textWhite;
            lblLicenseID.ForeColor = textWhite;

            // 👑 أهم عنصر
            lblFullName.ForeColor = primaryBlue;

            // =========================
            // 🟢 Status (IsActive)
            // =========================
            if (lblIsActive.Text.ToLower().Contains("true"))
                lblIsActive.ForeColor = Color.FromArgb(34, 197, 94); // Green
            else
                lblIsActive.ForeColor = Color.FromArgb(239, 68, 68); // Red

            // =========================
            // 🖼️ Images
            // =========================
            pbPersonImage.BackColor = Color.FromArgb(15, 23, 42);

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

            // ❗ بدون تغيير Layout
        }
    }
}
