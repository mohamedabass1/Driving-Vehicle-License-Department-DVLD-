using DVLD.Properties;
using DVLDBusinessLayer;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Licenses.Controls
{
    public partial class ctrlDriverLicenseInfoCard : UserControl
    {
        int _LicenseID = -1;
        clsLicense _License;

        public int SelectedLicenseID
        {
            get { return _LicenseID; }
        }
        public clsLicense SelectedLicenseInfo
        {
            get { return _License; }
        }


        public ctrlDriverLicenseInfoCard()
        {
            InitializeComponent();
            ApplyLicenseCardTheme();
        }
        public void LoadDriverLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.FindByLicenseID(_LicenseID);

            if (_License == null)
            {
                MessageBox.Show($"License with ID {LicenseID} dose not Exists ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }
            else
                _FillDriverLicenseInfo();
        }
        private void _FillDriverLicenseInfo()
        {

            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = (_License.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female");
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = (_License.Notes == "" ? "No Notes" : _License.Notes);
            lblIsActive.Text = (_License.IsActive ? "Yes" : "No");
            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString();

            if (_License.IsDetained)
                lblIsDetained.Text = "Yes";
            else
                lblIsDetained.Text = "No";


            _LoadPersonImage();
        }
        private void _LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.Gender == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Cloud not find this Image: " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void groupBox1_Enter(object sender, System.EventArgs e)
        {

        }

        private void ApplyLicenseCardTheme()
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
            // 📝 كل العناوين (Labels الثابتة)
            // =========================
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is Label lbl)
                {
                    // إذا كان Label عنوان (Bold)
                    if (lbl.Font.Bold)
                        lbl.ForeColor = textGray;
                }
            }

            // =========================
            // 📊 القيم (Values)
            // =========================

            lblLicenseID.ForeColor = textWhite;
            lblNationalNo.ForeColor = textWhite;
            lblGendor.ForeColor = textWhite;
            lblIssueDate.ForeColor = textWhite;
            lblNotes.ForeColor = textWhite;
            lblDateOfBirth.ForeColor = textWhite;
            lblDriverID.ForeColor = textWhite;
            lblExpirationDate.ForeColor = textWhite;
            lblClass.ForeColor = primaryBlue;
            lblIssueReason.ForeColor = textWhite;

            // 👑 أهم عنصر
            lblFullName.ForeColor = primaryBlue;

            // =========================
            // 🟢 Status Colors
            // =========================

            if (lblIsActive.Text.ToLower().Contains("true"))
                lblIsActive.ForeColor = Color.FromArgb(34, 197, 94);
            else
                lblIsActive.ForeColor = Color.FromArgb(239, 68, 68);

            if (lblIsDetained.Text.ToLower().Contains("true"))
                lblIsDetained.ForeColor = Color.FromArgb(239, 68, 68);
            else
                lblIsDetained.ForeColor = Color.FromArgb(34, 197, 94);

            // =========================
            // 🖼️ Images
            // =========================
            pbPersonImage.BackColor = Color.FromArgb(15, 23, 42);

            // ❗ بدون تغيير:
            // Size ❌
            // Location ❌
            // Font ❌
        }
    }
}
