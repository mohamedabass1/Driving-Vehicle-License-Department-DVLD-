using DVLDBusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmTakeTest : Form
    {



        private int _TestAppointmentID = -1;
        private clsTestAppointment _TestAppoinment;


        private clsTest _Test;

        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            ApplyTakeTestTheme();
            this._TestAppointmentID = TestAppointmentID;
        }



        private void _LoadInfo()
        {


            _TestAppoinment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppoinment == null)
            {
                MessageBox.Show($"Ther is No Appointment with ID {_TestAppoinment}, Inter valid Test Appointment ID", "Erorr",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // load the control info
            ctrlScheduledTest1.LoadInfo(_TestAppointmentID);


            // if the Test Appointment is locked that mean it update mod
            if (_TestAppoinment.IsLocked)
            {
                _Test = clsTest.GetTestByTestAppointmentID(_TestAppointmentID);

                if (_Test == null)
                {

                    MessageBox.Show($"Ther is No Test with ID {_TestAppointmentID}, Inter valid Test ID", "Erorr",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                ctrlScheduledTest1.TestID = _Test.TestID;

                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;


                rbPass.Enabled = false;
                rbFail.Enabled = false;

                txtNotes.Text = _Test.Notes;
                lblUserMessage.Visible = true;

            }
            else
            {
                _Test = new clsTest();

                rbPass.Checked = true;
                rbPass.Enabled = true;
                rbFail.Enabled = true;


                lblUserMessage.Visible = false;
            }

        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to save? After that you cannot change the Pass/Fail results after you save", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            // if Pass checked that mean it pass the result else it falid
            _Test.TestResult = rbPass.Checked;

            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _Test.Notes = txtNotes.Text;



            if (_Test.Save())
            {

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ctrlScheduledTest1.TestID = _Test.TestID;

                rbPass.Enabled = false;
                rbFail.Enabled = false;
                btnSave.Enabled = false;
                this.Close();

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyTakeTestTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);

            // =========================
            // 📝 Labels
            // =========================
            label5.ForeColor = textGray;
            label1.ForeColor = textGray;

            // =========================
            // ✅ Result (🔥 مهم)
            // =========================
            rbPass.ForeColor = Color.FromArgb(34, 197, 94); // أخضر
            rbFail.ForeColor = Color.FromArgb(239, 68, 68); // أحمر

            // =========================
            // 📥 Notes
            // =========================
            txtNotes.BackColor = Color.FromArgb(15, 23, 42);
            txtNotes.ForeColor = textWhite;
            txtNotes.BorderStyle = BorderStyle.FixedSingle;

            // =========================
            // ⚠️ Message
            // =========================
            lblUserMessage.ForeColor = Color.FromArgb(251, 191, 36); // Yellow (أفضل من الأحمر)

            // =========================
            // 🔘 Buttons
            // =========================

            // Save = Primary
            btnSave.BackColor = primaryBlue;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;

            // Close = Secondary
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            // Hover
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // =========================
            // 🖼️ Icons
            // =========================
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;

            // =========================
            // 🧩 Card Container
            // =========================
            ctrlScheduledTest1.BackColor = Color.Transparent;

            // ❗ بدون تغيير Layout
        }
    }
}
