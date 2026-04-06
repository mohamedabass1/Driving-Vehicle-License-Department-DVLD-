using DVLDBusinessLayer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Application_Type
{
    public partial class frmUpdateApplicationType : Form
    {

        clsApplicationType ApplicationType;
        private int _ApplicationTypeID = -1;
        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            // ApplyUpdateApplicationTypeTheme();
            _ApplicationTypeID = ApplicationTypeID;

        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);

            lblID.Text = _ApplicationTypeID.ToString();
            ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            if (ApplicationType != null)
            {
                lblID.Text = ApplicationType.ID.ToString();
                txtTitle.Text = ApplicationType.Title;
                txtFees.Text = ApplicationType.Fees.ToString();
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

            ApplicationType.Title = txtTitle.Text.Trim();
            ApplicationType.Fees = float.Parse(txtFees.Text.Trim());

            if (ApplicationType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "This filed is required");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
                //e.Cancel = false;

            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "This filed is required");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
                //e.Cancel = false;

            }
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyUpdateApplicationTypeTheme()
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
            label1.ForeColor = primaryBlue;

            // =========================
            // 📝 Labels
            // =========================
            label2.ForeColor = textGray;
            label4.ForeColor = textGray;
            label6.ForeColor = textGray;

            // =========================
            // 📊 Values
            // =========================
            lblID.ForeColor = textWhite;

            // =========================
            // 📥 Inputs (🔥 مهم)
            // =========================
            txtTitle.BackColor = Color.FromArgb(15, 23, 42);
            txtTitle.ForeColor = textWhite;
            txtTitle.BorderStyle = BorderStyle.FixedSingle;

            txtFees.BackColor = Color.FromArgb(15, 23, 42);
            txtFees.ForeColor = textWhite;
            txtFees.BorderStyle = BorderStyle.FixedSingle;

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
        }
    }
}
