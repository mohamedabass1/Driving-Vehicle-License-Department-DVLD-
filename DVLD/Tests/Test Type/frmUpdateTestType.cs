using DVLD.Global_Classes;
using DVLDBusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Tests.Test_Type
{
    public partial class frmUpdateTestType : Form
    {
        private clsTestType.enTestType _TestTypeID;
        clsTestType _Test;
        public frmUpdateTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            ApplyUpdateTestTypeTheme();
            this._TestTypeID = TestTypeID;

        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _Test = clsTestType.Find(_TestTypeID);

            if (_Test != null)
            {
                lblID.Text = ((int)_Test.ID).ToString(); ;
                txtTitle.Text = _Test.Title;
                txtDescription.Text = _Test.Description;
                txtFees.Text = _Test.Fees.ToString();
            }
            else
            {
                MessageBox.Show("Could not find Test Type with id = " + _TestTypeID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

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

            _Test.Title = txtTitle.Text.Trim();
            _Test.Description = txtDescription.Text.Trim();
            _Test.Fees = Convert.ToSingle(txtFees.Text.Trim());

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title Can,t be empty");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
                //e.Cancel = false;

            }
        }

        private void txtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Description Can,t be empty");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
                //e.Cancel = false;

            }
        }

        private void txtFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees Can,t be empty");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
                //e.Cancel = false;
            }


            if (!clsValidatoin.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            };




        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplyUpdateTestTypeTheme()
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
            label1.ForeColor = primaryBlue;

            // =========================
            // 📝 Labels
            // =========================
            label2.ForeColor = textGray;
            label3.ForeColor = textGray;
            label4.ForeColor = textGray;
            label6.ForeColor = textGray;

            // =========================
            // 📊 Values
            // =========================
            lblID.ForeColor = textWhite;

            // =========================
            // 📥 TextBoxes (🔥 مهم)
            // =========================

            txtTitle.BackColor = Color.FromArgb(15, 23, 42);
            txtTitle.ForeColor = textWhite;
            txtTitle.BorderStyle = BorderStyle.FixedSingle;

            txtFees.BackColor = Color.FromArgb(15, 23, 42);
            txtFees.ForeColor = textWhite;
            txtFees.BorderStyle = BorderStyle.FixedSingle;

            txtDescription.BackColor = Color.FromArgb(15, 23, 42);
            txtDescription.ForeColor = textWhite;
            txtDescription.BorderStyle = BorderStyle.FixedSingle;

            // =========================
            // 🔘 Buttons
            // =========================

            // Save (Primary)
            btnSave.BackColor = primaryBlue;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;

            // Close (Secondary)
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
            pictureBox3.BackColor = Color.Transparent;
        }

    }
}
