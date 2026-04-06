using DVLD.Properties;
using DVLDBusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;
using static DVLDBusinessLayer.clsTestType;

namespace DVLD.Tests
{
    public partial class ctrlScheduleTest : UserControl
    {

        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        private enum enCreationMode { FirstTimeSchedule = 0, RetakeTestApplintment = 1 };
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestType.enTestType _TestTypeID = enTestType.VisionTest;

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;


        private int _TestAppointmentID = -1;
        private clsTestAppointment _TestAppointment;

        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }

            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestTypeImage.Image = Resources.Vision_512;

                            break;
                        }
                    case enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbTestTypeImage.Image = Resources.Written_Test_512;

                            break;
                        }
                    case enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            pbTestTypeImage.Image = Resources.driving_test_512;

                            break;
                        }
                }
            }
        }


        public void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {

            // if no appointment id this means Addnew mode otherwise it's update mode.
            if (AppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;


            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(
                _LocalDrivingLicenseApplicationID);


            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($" Erorr No Local Application With ID {LocalDrivingLicenseApplicationID} ",
                    "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;
                return;
            }



            // deside if the creation mode is retake or not based if the person attend to test type or not
            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))
                _CreationMode = enCreationMode.RetakeTestApplintment;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;



            if (_CreationMode == enCreationMode.RetakeTestApplintment)
            {
                lblRetakeAppFees.Text = clsApplicationType.Find((int)_TestTypeID).Fees.ToString();
                gbRetakeTestInfo.Enabled = true;

                lblTitle.Text = "Schedule Retak Test";
                lblRetakeTestAppID.Text = "0";

            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblRetakeAppFees.Text = "0";
                lblTitle.Text = "Schdule Test";
                lblRetakeTestAppID.Text = "N/A";
            }

            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LocalDrivingLicenseApplication.PersonFullName;

            // this will show the Trials for this Test before
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();


            if (_Mode == enMode.AddNew)
            {
                lblFees.Text = clsTestType.Find(_TestTypeID).Fees.ToString();
                dtpTestDate.MinDate = DateTime.Now;
                lblRetakeTestAppID.Text = "N/A";

                _TestAppointment = new clsTestAppointment();
            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }

            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeAppFees.Text)).ToString();


            if (!_HandelActiveTestAppointmentConstraint())
                return;

            if (!_HandelAppointmentLockedConstraint())
                return;

            if (!_HandelPrivousTestConstraint())
                return;


        }

        private bool _HandelPrivousTestConstraint()
        {

            //we need to make sure that this person passed the prvious required test before apply to the new test.
            //person cannno apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.

            switch (TestTypeID)
            {
                case enTestType.VisionTest:
                    lblUserMessage.Visible = false;
                    return true;

                case enTestType.WrittenTest:

                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(enTestType.VisionTest))
                    {
                        lblUserMessage.Text = "Can't schedule, you moust to pass Vision test first.";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;

                    }

                    break;

                case enTestType.StreetTest:

                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(enTestType.WrittenTest))
                    {
                        lblUserMessage.Text = "Can't schedule, you moust to pass Written test first.";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;

                    }
                    break;


            }
            return true;
        }
        private bool _HandelAppointmentLockedConstraint()
        {

            // if the appointment is locked the means , the person already sat for the test
            // we can not update locked appointment
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person is already sat for the test, appointment is locked";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandelActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew && _LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                lblUserMessage.Text = "Person already has an active Test appointment for this test type";
                lblUserMessage.Visible = true;
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;

                return false;
            }
            else
                lblUserMessage.Visible = false;


            return true;
        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show($" Erorr No Test Appinment With ID {_TestAppointmentID} ",
                   "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointment.PaidFees.ToString();

            // we compere the current date with the appointment date to set the min date
            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpTestDate.MinDate = DateTime.Now;
            else
                dtpTestDate.MinDate = _TestAppointment.AppointmentDate;


            dtpTestDate.Value = _TestAppointment.AppointmentDate;

            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }
            else
            {
                lblRetakeAppFees.Text = _TestAppointment.RetakeTestApplicationInfo.PaidFees.ToString();
                gbRetakeTestInfo.Enabled = true;

                lblTitle.Text = "Schedule Retak Test";
                lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationInfo.ApplicationID.ToString();


            }


            return true;
        }

        private bool _HandleRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestApplintment)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.

                //First Create Applicaiton 
                clsApplication Application = new clsApplication();

                Application.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).Fees;
                Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;

            }
            return true;
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
            ApplyScheduleTestTheme();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!_HandleRetakeApplication())
                return;

            _TestAppointment.TestTypeID = (int)_TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseAppID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void gbTestType_Enter(object sender, EventArgs e)
        {

        }
        private void ApplyScheduleTestTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);
            Color card = Color.FromArgb(30, 41, 59);

            // =========================
            // 📦 Main Card
            // =========================
            gbTestType.BackColor = card;
            gbTestType.ForeColor = Color.White;

            // =========================
            // 🏷️ Title
            // =========================
            lblTitle.ForeColor = primaryBlue;

            // =========================
            // 📝 Labels
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
            lblTrial.ForeColor = textWhite;

            lblFees.ForeColor = Color.FromArgb(34, 197, 94); // 💰

            // =========================
            // 📅 Date Input (🔥 مهم)
            // =========================
            dtpTestDate.CalendarMonthBackground = card;
            dtpTestDate.CalendarForeColor = textWhite;

            // =========================
            // ⚠️ User Message
            // =========================
            lblUserMessage.ForeColor = Color.FromArgb(251, 191, 36); // Yellow warning

            // =========================
            // 🔘 Save Button
            // =========================
            btnSave.BackColor = primaryBlue;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;

            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);

            // =========================
            // 📦 Retake Section (🔥 مهم)
            // =========================
            gbRetakeTestInfo.BackColor = Color.Transparent;
            gbRetakeTestInfo.ForeColor = Color.White;

            lblRetakeAppFees.ForeColor = Color.FromArgb(251, 191, 36); // warning
            lblTotalFees.ForeColor = primaryBlue; // total

            // =========================
            // 🖼️ Images
            // =========================
            pbTestTypeImage.BackColor = Color.Transparent;

            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox6.BackColor = Color.Transparent;
            pictureBox7.BackColor = Color.Transparent;
            pictureBox8.BackColor = Color.Transparent;
            pictureBox9.BackColor = Color.Transparent;
        }
    }
}




