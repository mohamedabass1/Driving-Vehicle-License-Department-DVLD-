using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmShowDriverLicenseInfo : Form
    {
        int _LicenseID = -1;
        public frmShowDriverLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            ApplyDriverLicenseFormTheme();
            _LicenseID = LicenseID;
        }
        private void frmShowDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoCard1.LoadDriverLicenseInfo(_LicenseID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ApplyDriverLicenseFormTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textGray = Color.FromArgb(148, 163, 184);

            // =========================
            // 🏷️ Title
            // =========================
            label1.ForeColor = primaryBlue;

            // =========================
            // 🖼️ Image
            // =========================
            pbPersonImage.BackColor = Color.Transparent;

            // =========================
            // 🔘 Close Button
            // =========================
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // ❗ بدون تغيير:
            // Size ❌
            // Location ❌
            // Font ❌
        }
    }
}
