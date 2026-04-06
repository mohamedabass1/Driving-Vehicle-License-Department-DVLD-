using DVLDBusinessLayer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmAddUpdateUser : Form
    {
        // Mode
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        private int _UserID = -1;
        private clsUser _User1;

        #region constructors
        public frmAddUpdateUser()
        {
            InitializeComponent();
            ApplyUserFormTheme();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            ApplyUserFormTheme();


            _Mode = enMode.Update;
            this._UserID = UserID;
        }

        #endregion

        // Form Load 
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefulatValues();

            if (_Mode == enMode.Update)
                _LoadUserData();
        }

        // Data Load
        void _LoadUserData()
        {
            _User1 = clsUser.FindUserByUserID(this._UserID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;


            if (_User1 == null)
            {
                MessageBox.Show("No User with ID = " + _UserID,
                    "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found

            lblUserID.Text = _User1.UserID.ToString(); ;
            txtUserName.Text = _User1.UserName;
            txtPassword.Text = _User1.Password;
            txtConfermPassword.Text = _User1.Password;
            chbIsActive.Checked = _User1.IsActive;

            // Load Person Data
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User1.PersonID);


        }

        #region UI Helper Methods
        private void _ResetDefulatValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == enMode.AddNew)
            {
                lblFormTitle.Text = "Add New User";
                this.Text = "Add New User";
                _User1 = new clsUser();

                tabcLoginInfo.Enabled = false;

                ctrlPersonCardWithFilter1.FilterFoucs();
            }
            else
            {
                lblFormTitle.Text = "Update User";
                this.Text = "Update User";

                tabcLoginInfo.Enabled = true;
                btnSave.Enabled = true;

            }

            lblUserID.Text = "??";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfermPassword.Text = "";
            chbIsActive.Checked = true;
        }



        #endregion

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tabcLoginInfo.Enabled = true;
                tabUserInfo.SelectedTab = tabUserInfo.TabPages["tabcLoginInfo"];
                return;

            }

            //incase of add new mode.

            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                if (clsUser.IsUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person already has a User, Choose another one.",
                   "Select another person", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ctrlPersonCardWithFilter1.FilterFoucs();

                }
                else
                {
                    btnSave.Enabled = true;
                    tabcLoginInfo.Enabled = true;
                    tabUserInfo.SelectedTab = tabUserInfo.TabPages["tabcLoginInfo"];
                }
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
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Same fields are not valid! put the mouse over the red icon(s) to see error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User1.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User1.UserName = txtUserName.Text.Trim();
            _User1.Password = txtPassword.Text.Trim();
            _User1.IsActive = chbIsActive.Checked;




            if (_User1.Save())
            {
                lblUserID.Text = _User1.UserID.ToString();

                // change the Mode Update
                _Mode = enMode.Update;
                lblFormTitle.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        #region Validation
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Tepm = ((TextBox)sender);

            if (string.IsNullOrEmpty(Tepm.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Tepm, "This filed is required");
            }
            else
            {
                errorProvider1.SetError(Tepm, null);
                //e.Cancel = false;

            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmptyTextBox(sender, e);

            if (txtUserName.Text.Trim() != _User1.UserName && clsUser.IsUserExist(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "UserName is used by another user");

            }
            else
                errorProvider1.SetError(txtUserName, null);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmptyTextBox(sender, e);

        }

        private void txtConfermPassword_Validating(object sender, CancelEventArgs e)
        {

            if (txtConfermPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfermPassword, "Password Confirmation dose not match password");
            }
            else
                errorProvider1.SetError(txtConfermPassword, null);
        }

        #endregion
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyUserFormTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);

            // 🏷️ Title
            lblFormTitle.ForeColor = primaryBlue;

            // =========================
            // 🔥 FIX TabControl
            // =========================

            tabUserInfo.BackColor = Color.FromArgb(15, 23, 42);

            // أهم سطر 👇
            tabUserInfo.Appearance = TabAppearance.Normal;

            tabcPersonalInfo.BackColor = Color.FromArgb(15, 23, 42);
            tabcLoginInfo.BackColor = Color.FromArgb(15, 23, 42);

            // =========================
            // 🔥 FIX Labels داخل Login Tab
            // =========================

            foreach (Control ctrl in tabcLoginInfo.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = textGray;
                }
            }

            // رجّع القيم المهمة بلون واضح
            lblUserID.ForeColor = textWhite;

            // =========================
            // 🔥 FIX TextBoxes
            // =========================

            txtUserName.BackColor = Color.FromArgb(15, 23, 42);
            txtUserName.ForeColor = textWhite;

            txtPassword.BackColor = Color.FromArgb(15, 23, 42);
            txtPassword.ForeColor = textWhite;

            txtConfermPassword.BackColor = Color.FromArgb(15, 23, 42);
            txtConfermPassword.ForeColor = textWhite;

            // =========================
            // 🔥 Checkbox
            // =========================

            chbIsActive.ForeColor = textWhite;

            // =========================
            // 🔥 Buttons (بدون تغيير حجم)
            // =========================

            btnSave.BackColor = primaryBlue;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;

            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            btnNext.BackColor = primaryBlue;
            btnNext.ForeColor = Color.White;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.FlatAppearance.BorderSize = 0;

            // Hover
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);
            btnNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
        }
    }
}
