using DVLDBusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        int _LocalAppID = -1;
        int _SelectedPersonID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            ApplyLocalLicenseFormTheme();
            _Mode = enMode.AddNew;

        }

        public frmAddUpdateLocalDrivingLicenseApplication(int LocalApplicationID)
        {
            InitializeComponent();
            ApplyLocalLicenseFormTheme();

            this._LocalAppID = LocalApplicationID;
            _Mode = enMode.Update;
        }


        private void _FillLicenseClassesInComboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClasses.Items.Add(row["ClassName"]);
            }

        }
        private void _ResetDefulteValues()
        {
            _FillLicenseClassesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                //lblFormTitle.Text = "New Local Driving License Application";
                //this.Text = "New Local Driving License Application";

                ctrlPersonCardWithFilter1.FilterFoucs();

                tabcApplicationInfo.Enabled = false;
                btnSave.Enabled = false;

                cbLicenseClasses.SelectedIndex = 2;

                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();

                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblApplactionDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
                lblLocalApplactionID.Text = "[???]";




            }
            else
            {
                //lblFormTitle.Text = "Update Local Driving License Application";
                //this.Text = "Update Local Driving License Application";

                tabcApplicationInfo.Enabled = true;
                btnNext.Enabled = true;
                btnSave.Enabled = true;
            }

            lblFormTitle.Text = this.Text = (_Mode == enMode.AddNew ? "Add New " : "Update ") + "Local Driving License Application";


        }

        private void _LoadData()
        {

            ctrlPersonCardWithFilter1.FilterEnabled = false;


            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalAppID);

            if (_LocalDrivingLicenseApplication == null)
            {

                MessageBox.Show("No Application with ID = " + _LocalAppID,
                    "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            _SelectedPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblLocalApplactionID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseAppID.ToString();
            lblApplactionDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = clsUser.FindUserByUserID(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;

            cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);

        }
        private void frmNewLocalDrivingLicenseApplaction_Load(object sender, EventArgs e)
        {
            _ResetDefulteValues();



            if (_Mode == enMode.Update)
                _LoadData();

        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                tabLocalApplicationInfo.SelectedTab = tabLocalApplicationInfo.TabPages["tabcApplicationInfo"];
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                btnSave.Enabled = true;
                tabcApplicationInfo.Enabled = true;
                tabLocalApplicationInfo.SelectedTab = tabLocalApplicationInfo.TabPages["tabcApplicationInfo"];


            }
            else
            {
                MessageBox.Show("Please Select Person", "Select person",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFoucs();
                return;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClass.Find(cbLicenseClasses.Text).ID;


            // check if the person has already active application for the same license class
            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);
            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClasses.Focus();
                return;
            }

            //check if user already have issued license of the same driving  class.
            if (clsLicense.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID, LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _LocalDrivingLicenseApplication.ApplicantPersonID = _SelectedPersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewDrivingLicense;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;


            if (_LocalDrivingLicenseApplication.Save())
            {
                _Mode = enMode.Update;
                lblLocalApplactionID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseAppID.ToString();
                lblFormTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Data NOT Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFoucs();
        }

        private void ApplyLocalLicenseFormTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);

            // =========================
            // 🏷️ Title
            // =========================
            lblFormTitle.ForeColor = primaryBlue;

            // =========================
            // 🔥 TabControl FIX
            // =========================

            tabLocalApplicationInfo.BackColor = Color.FromArgb(15, 23, 42);

            tabcPersonalInfo.BackColor = Color.FromArgb(15, 23, 42);
            tabcApplicationInfo.BackColor = Color.FromArgb(15, 23, 42);

            // =========================
            // 📝 Labels داخل Application Tab
            // =========================

            foreach (Control ctrl in tabcApplicationInfo.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = textGray;
                }
            }

            // =========================
            // 📊 Values
            // =========================

            lblLocalApplactionID.ForeColor = primaryBlue;
            lblApplactionDate.ForeColor = textWhite;
            lblApplicationFees.ForeColor = textWhite;
            lblCreatedBy.ForeColor = textWhite;

            // =========================
            // 📥 ComboBox
            // =========================

            cbLicenseClasses.BackColor = Color.FromArgb(15, 23, 42);
            cbLicenseClasses.ForeColor = textWhite;
            cbLicenseClasses.FlatStyle = FlatStyle.Flat;

            // =========================
            // 🔘 Buttons
            // =========================

            btnNext.BackColor = primaryBlue;
            btnNext.ForeColor = Color.White;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.FlatAppearance.BorderSize = 0;

            btnSave.BackColor = primaryBlue;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;

            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            // Hover (آمن)
            btnNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // =========================
            // 🖼️ Icons
            // =========================

            guna2CirclePictureBox1.BackColor = Color.Transparent;
            guna2CirclePictureBox2.BackColor = Color.Transparent;
            guna2CirclePictureBox3.BackColor = Color.Transparent;
            guna2CirclePictureBox4.BackColor = Color.Transparent;
            guna2CirclePictureBox5.BackColor = Color.Transparent;

            // ❗ بدون تغيير:
            // Size ❌
            // Location ❌
            // Font ❌
        }
    }
}
