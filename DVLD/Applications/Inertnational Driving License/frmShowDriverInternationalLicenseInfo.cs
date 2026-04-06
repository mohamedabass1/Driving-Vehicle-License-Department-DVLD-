using System;
using System.Windows.Forms;

namespace DVLD.Applications.Inertnational_Driving_License
{
    public partial class frmShowDriverInternationalLicenseInfo : Form
    {
        int _InternationalLicenseID = -1;
        public frmShowDriverInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            Theme.Apply(this);

            _InternationalLicenseID = InternationalLicenseID;
        }

        private void frmShowDriverInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseInfoCard1.LoadDriverInternationalLicenseInfo(_InternationalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
