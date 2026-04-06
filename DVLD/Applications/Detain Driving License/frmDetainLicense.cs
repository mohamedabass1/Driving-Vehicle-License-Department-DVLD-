using DVLD.Licenses;
using DVLDBusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Applications.Detain_Driving_License
{
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
            ApplyDetainLicenseTheme();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ctrlDriverLicenseInfoCardWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblLicenseID.Text = SelectedLicenseID.ToString();

            llShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
                return;

            if (ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License already detained, choose another one.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llShowLicenseInfo.Enabled = true;
                btnDetain.Enabled = false;
                return;
            }


            btnDetain.Enabled = true;

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure want to detain this license?", "Cofirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            if (!this.ValidateChildren())
            {
                MessageBox.Show("Fees can not be empty, Enter the Fine Fees",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFineFees.Focus();
                return;
            }

            float FineFees = Convert.ToSingle(txtFineFees.Text);
            clsDetainedLicense DetainedLicseneInfo = ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.DetainLicense(FineFees, clsGlobal.CurrentUser.UserID);

            if (DetainedLicseneInfo == null)
            {
                MessageBox.Show("Filed to Detaine the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MessageBox.Show("License Detained Successfully",
                    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblDetainID.Text = DetainedLicseneInfo.DetainID.ToString();
            llShowLicenseInfo.Enabled = true;
            ctrlDriverLicenseInfoCardWithFilter1.FilterEnabled = false;
            btnDetain.Enabled = false;
            txtFineFees.Enabled = false;
        }

        private void frmDetainLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoCardWithFilter1.FilterFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFineFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fees can not be empty");
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);
            }
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // chick if the pressed Key is Enter (Key char 13)
            if (e.KeyChar == (char)13)
            {
                btnDetain.PerformClick();
            }

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowDriverLicenseInfo(ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseID);
            frm.ShowDialog();
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoCardWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();

        }

        private void ApplyDetainLicenseTheme()
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
            // 📦 GroupBox
            // =========================
            gpDetainInfo.BackColor = card;
            gpDetainInfo.ForeColor = Color.White;

            foreach (Control ctrl in gpDetainInfo.Controls)
            {
                if (ctrl is Label lbl && lbl.Font.Bold)
                {
                    lbl.ForeColor = textGray;
                }
            }

            // =========================
            // 📊 Values
            // =========================
            lblDetainID.ForeColor = primaryBlue;
            lblLicenseID.ForeColor = textWhite;
            lblCreatedByUser.ForeColor = textWhite;
            lblDetainDate.ForeColor = textWhite;

            // =========================
            // 💰 Fine Fees (🔥 أهم عنصر)
            // =========================
            txtFineFees.BackColor = Color.FromArgb(15, 23, 42);
            txtFineFees.ForeColor = textWhite;
            txtFineFees.BorderStyle = BorderStyle.FixedSingle;

            // =========================
            // 🔗 Links
            // =========================
            llShowLicenseInfo.LinkColor = primaryBlue;
            llShowLicensesHistory.LinkColor = primaryBlue;

            llShowLicenseInfo.ActiveLinkColor = Color.LightBlue;
            llShowLicensesHistory.ActiveLinkColor = Color.LightBlue;

            // =========================
            // 🔘 Buttons
            // =========================

            // Primary Action
            btnDetain.BackColor = primaryBlue;
            btnDetain.ForeColor = Color.White;
            btnDetain.FlatStyle = FlatStyle.Flat;
            btnDetain.FlatAppearance.BorderSize = 0;

            // Secondary
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            // Hover
            btnDetain.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // =========================
            // 🖼️ Icons
            // =========================
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox7.BackColor = Color.Transparent;

            // ❗ بدون تغيير Layout
        }
    }
}
