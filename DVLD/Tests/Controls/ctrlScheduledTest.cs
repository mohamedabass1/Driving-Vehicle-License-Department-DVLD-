using DVLD.Properties;
using DVLDBusinessLayer;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Tests.Controls
{
    public partial class ctrlScheduledTest : UserControl
    {

        private int _LocalDrivingLicenseApplicationID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;


        private int _TestAppoinmentID = -1;
        private clsTestAppointment _TestAppoinment;


        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }

            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestTypeImage.Image = Resources.Vision_512;
                            lblTitle.Text = "Vision Test";

                        }
                        break;

                    case clsTestType.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbTestTypeImage.Image = Resources.Written_Test_512;
                            lblTitle.Text = "Written Test";

                        }
                        break;

                    case clsTestType.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Streat Test";
                            pbTestTypeImage.Image = Resources.driving_test_512;
                            lblTitle.Text = "Streat Test";

                        }
                        break;

                }
            }
        }

        public int TestID
        {
            get { return _TestID; }
            set
            {
                _TestID = value;
                lblTestID.Text = _TestID == -1 ? "Not Taken Yet" : _TestID.ToString();
            }
        }
        private int _TestID = -1;
        public void LoadInfo(int TestAppoinmentID)
        {
            _TestAppoinmentID = TestAppoinmentID;

            _TestAppoinment = clsTestAppointment.Find(_TestAppoinmentID);

            if (_TestAppoinment == null)
            {
                MessageBox.Show($"Ther is No Appointment with ID {_TestAppoinment}, Inter valid Test Appointment ID", "Erorr",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }



            _LocalDrivingLicenseApplicationID = _TestAppoinment.LocalDrivingLicenseApplicationID;

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(
                _LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($" Erorr No Local Application With ID {_LocalDrivingLicenseApplicationID} ",
                    "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            TestTypeID = (clsTestType.enTestType)_TestAppoinment.TestTypeID;
            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;

            lblFullName.Text = _LocalDrivingLicenseApplication.PersonFullName;

            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();

            lblDate.Text = _TestAppoinment.AppointmentDate.ToShortDateString();

            lblFees.Text = _TestAppoinment.PaidFees.ToString();



        }




        public ctrlScheduledTest()
        {
            InitializeComponent();
            ApplyScheduledTestTheme();
        }

        private void ctrlScheduledTest_Load(object sender, System.EventArgs e)
        {

        }

        private void ApplyScheduledTestTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);
            Color card = Color.FromArgb(30, 41, 59);

            // =========================
            // 📦 GroupBox = Card
            // =========================
            gbTestType.BackColor = card;
            gbTestType.ForeColor = Color.White;

            // =========================
            // 🏷️ Title
            // =========================
            lblTitle.ForeColor = primaryBlue;

            // =========================
            // 📝 Labels (Titles)
            // =========================
            foreach (Control ctrl in gbTestType.Controls)
            {
                if (ctrl is Label lbl && lbl.Font.Bold && lbl.Name.StartsWith("label"))
                {
                    lbl.ForeColor = textGray;
                }
            }

            // =========================
            // 📊 Values
            // =========================
            lblFullName.ForeColor = textWhite;
            lblDrivingClass.ForeColor = textWhite;
            lblLocalDrivingLicenseAppID.ForeColor = textWhite;

            lblDate.ForeColor = primaryBlue;   // مهم
            lblFees.ForeColor = Color.FromArgb(34, 197, 94); // 💰 أخضر
            lblTrial.ForeColor = textWhite;

            lblTestID.ForeColor = Color.Orange; // حالة

            // =========================
            // 🖼️ Images
            // =========================
            pbTestTypeImage.BackColor = Color.Transparent;

            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox7.BackColor = Color.Transparent;
            pictureBox8.BackColor = Color.Transparent;
        }
    }
}
