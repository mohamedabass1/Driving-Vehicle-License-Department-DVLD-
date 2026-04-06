using DVLDBusinessLayer;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmChangePassword : Form
    {
        int _UserID;
        clsUser _User1;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            ApplyChangePasswordTheme();
            _UserID = UserID;

        }

        private void _ResetDefultValues()
        {
            txtCurrentPasswoed.Text = "";
            txtNewPassword.Text = "";
            txtConfermPassword.Text = "";
            txtCurrentPasswoed.Focus();
        }
        private void frmChangePassword_Load(object sender, System.EventArgs e)
        {
            _ResetDefultValues();

            _User1 = clsUser.FindUserByUserID(_UserID);

            if (_User1 == null)
            {
                //Here we font continue because the form is not valid
                MessageBox.Show("Could not Find User with id = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;
            }


            ctrlUserCard1.LoadUserInfo(_UserID);

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
        private void txtCurrentPasswoed_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmptyTextBox(txtCurrentPasswoed, e);


            if (txtCurrentPasswoed.Text.Trim() != _User1.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPasswoed, "Current Password is wrong");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPasswoed, null);

            }


        }
        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmptyTextBox(sender, e);

            // if the new password = old password
            if (txtNewPassword.Text.Trim() == txtCurrentPasswoed.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Please enter another password.");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }

        }
        private void txtConfermPassword_Validating(object sender, CancelEventArgs e)
        {

            if (txtConfermPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfermPassword, "Password Confirmation dose not match password");
            }
            else
                errorProvider1.SetError(txtConfermPassword, null);

        }
        #endregion

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Same fields are not valid! put the mouse over the red icon(s) to see error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User1.Password = txtNewPassword.Text.Trim();

            if (_User1.ChangePassword(_User1.Password))
            {
                MessageBox.Show("Password Changed Successfully.", "Completed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _ResetDefultValues();

            }
            else
                MessageBox.Show("Password dose not Changed .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);




        }
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ApplyChangePasswordTheme()
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

            label2.ForeColor = textGray;
            label3.ForeColor = textGray;
            label4.ForeColor = textGray;

            // =========================
            // 📥 TextBoxes (فقط ألوان)
            // =========================

            txtCurrentPasswoed.BackColor = Color.FromArgb(15, 23, 42);
            txtCurrentPasswoed.ForeColor = textWhite;

            txtNewPassword.BackColor = Color.FromArgb(15, 23, 42);
            txtNewPassword.ForeColor = textWhite;

            txtConfermPassword.BackColor = Color.FromArgb(15, 23, 42);
            txtConfermPassword.ForeColor = textWhite;

            // =========================
            // 🔘 Buttons
            // =========================

            btnSave.BackColor = primaryBlue;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;

            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            // Hover (آمن)
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // =========================
            // 🖼️ Icons
            // =========================

            guna2CirclePictureBox1.BackColor = Color.Transparent;
            guna2CirclePictureBox2.BackColor = Color.Transparent;
            guna2CirclePictureBox3.BackColor = Color.Transparent;

            // ❗ لا تغيير:
            // Size ❌
            // Location ❌
            // Font ❌
        }
    }
}
