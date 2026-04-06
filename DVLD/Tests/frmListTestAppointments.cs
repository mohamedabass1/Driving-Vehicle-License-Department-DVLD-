using DVLD.Properties;
using DVLDBusinessLayer;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static DVLDBusinessLayer.clsTestType;

namespace DVLD.Tests
{
    public partial class frmListTestAppointments : Form
    {

        int _LocalDrivingLicenseApplicationID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private clsTestType.enTestType _TestTypeID = enTestType.VisionTest;

        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            ApplyAppointmentsListTheme();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            this._TestTypeID = TestTypeID;

        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID)
            {
                case enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        pbPersonImage.Image = Resources.Vision_512;
                    }
                    break;
                case enTestType.WrittenTest:
                    {
                        this.Text = "Written Test Appointments";
                        lblTitle.Text = this.Text;
                        pbPersonImage.Image = Resources.Written_Test_512;
                    }
                    break;
                case enTestType.StreetTest:
                    {
                        this.Text = "Street Test Appointments";
                        lblTitle.Text = this.Text;
                        pbPersonImage.Image = Resources.driving_test_512;
                    }
                    break;

            }
        }


        private bool _LoadInfo()
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($"No Local Driving Application with ID {_LocalDrivingLicenseApplicationID}", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ctrlLocalDrivingLicenseApplicationInfoCard1.LoadLocalDrivingLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);
            return true;
        }


        DataTable _dtTestApointments;
        private void frmListTestAppointments_Load(object sender, System.EventArgs e)
        {
            _LoadTestTypeImageAndTitle();

            if (_LoadInfo())
            {
                _dtTestApointments = clsTestAppointment.GetAppliationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, (int)_TestTypeID);
                dgvAppointments.DataSource = _dtTestApointments;


                lblRecordsCount.Text = dgvAppointments.Rows.Count.ToString();

                if (dgvAppointments.Rows.Count > 0)
                {
                    dgvAppointments.Columns[0].HeaderText = "Appointment ID";
                    dgvAppointments.Columns[0].Width = 120;

                    dgvAppointments.Columns[1].HeaderText = "Appointment Date";
                    dgvAppointments.Columns[1].Width = 150;

                    dgvAppointments.Columns[2].HeaderText = "Paid Fees";
                    dgvAppointments.Columns[2].Width = 100;

                    dgvAppointments.Columns[3].HeaderText = "Is Locked";
                    dgvAppointments.Columns[3].Width = 100;

                }
            }


        }
        private void EditMenuItem1_Click(object sender, System.EventArgs e)
        {
            Form frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID, (int)dgvAppointments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);

        }

        private void btnAddNewAppointment_Click(object sender, System.EventArgs e)
        {
            if (_LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show("Person already has an active Test appointment for this test type, You cannot add new appointment", "Erorr"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ---
            clsTest LastTest = _LocalDrivingLicenseApplication.GetLastTestPerTestType(_TestTypeID);


            // if the person has no test before 
            if (LastTest == null)
            {

                Form frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID);
                frm.ShowDialog();
                frmListTestAppointments_Load(null, null);

                return;
            }

            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Form frm2 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID);
            frm2.ShowDialog();

            frmListTestAppointments_Load(null, null);


        }

        private void TakeTestMenuItem1_Click(object sender, System.EventArgs e)
        {
            Form frm = new frmTakeTest((int)dgvAppointments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListTestAppointments_Load(null, null);
        }


        private void ApplyAppointmentsListTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);
            Color card = Color.FromArgb(30, 41, 59);

            // =========================
            // 🏷️ Title
            // =========================
            lblTitle.ForeColor = primaryBlue;

            // =========================
            // 📝 Labels
            // =========================
            label2.ForeColor = textGray;
            label3.ForeColor = textGray;
            lblRecordsCount.ForeColor = textWhite;

            // =========================
            // 🖼️ Image
            // =========================
            pbPersonImage.BackColor = Color.Transparent;

            // =========================
            // 🔘 Add Button (🔥 Guna تحسين)
            // =========================
            btnAddNewAppointment.FillColor = primaryBlue;
            btnAddNewAppointment.ForeColor = Color.White;
            btnAddNewAppointment.BorderThickness = 0;

            // =========================
            // 🔘 Close Button
            // =========================
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // =========================
            // 📊 DataGridView
            // =========================
            dgvAppointments.BackgroundColor = card;
            dgvAppointments.BorderStyle = BorderStyle.None;
            dgvAppointments.EnableHeadersVisualStyles = false;

            // Header
            dgvAppointments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 175);
            dgvAppointments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Rows
            dgvAppointments.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvAppointments.DefaultCellStyle.ForeColor = textWhite;
            dgvAppointments.DefaultCellStyle.SelectionBackColor = primaryBlue;
            dgvAppointments.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid
            dgvAppointments.GridColor = Color.FromArgb(51, 65, 85);

            // Row Header
            dgvAppointments.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvAppointments.RowHeadersDefaultCellStyle.ForeColor = textWhite;

            // =========================
            // 🧾 Context Menu
            // =========================
            contextMenuStrip1.BackColor = card;
            contextMenuStrip1.ForeColor = textWhite;

            foreach (ToolStripItem item in contextMenuStrip1.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.BackColor = card;
                    menuItem.ForeColor = textWhite;
                }
            }

            // =========================
            // 🧩 Card
            // =========================
            ctrlLocalDrivingLicenseApplicationInfoCard1.BackColor = Color.Transparent;

            // ❗ بدون تغيير Layout
        }
    }
}

