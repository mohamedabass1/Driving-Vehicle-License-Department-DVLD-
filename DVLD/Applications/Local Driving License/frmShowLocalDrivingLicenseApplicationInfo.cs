using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmShowLocalDrivingLicenseApplicationInfo : Form
    {
        private int _LocalAppID = -1;
        public frmShowLocalDrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            ApplyShowLocalAppTheme();
            this._LocalAppID = LocalDrivingLicenseApplicationID;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmShowLocalDrivingLicenseApplicationInfo_Load(object sender, System.EventArgs e)
        {
            ctrlLocalDrivingLicenseApplicationInfoCard1.LoadLocalDrivingLicenseApplicationInfo(_LocalAppID);

        }

        private void ApplyShowLocalAppTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🔘 Close Button
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            // Hover (آمن)
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // ❗ بدون تغيير:
            // Size ❌
            // Location ❌
            // Font ❌
        }
    }
}
