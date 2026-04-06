using DVLDBusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmScheduleTest : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private int _AppointmentID;
        private clsTestType.enTestType _TestTypeID;

        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID, int AppointmentID = -1)
        {
            InitializeComponent();
            ApplyScheduleTestFormTheme();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _AppointmentID = AppointmentID;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestTypeID;
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyScheduleTestFormTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🎯 Colors
            Color textWhite = Color.FromArgb(226, 232, 240);

            // =========================
            // 🔘 Close Button
            // =========================
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // =========================
            // 🧩 Control Container
            // =========================
            //ctrlScheduleTest1.BackColor = Color.Transparent;

            // ❗ لا تغير:
            // Size ❌
            // Location ❌
        }
    }
}
