using DVLDBusinessLayer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Licenses.Controls
{
    public partial class ctrlDriverLicenseInfoCardWithFilter : UserControl
    {
        public event Action<int> OnLicenseSelected;
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID);
            }
        }

        public int SelectedLicenseID { get { return ctrlDriverLicenseInfoCard1.SelectedLicenseID; } }
        public clsLicense SelectedLicenseInfo { get { return ctrlDriverLicenseInfoCard1.SelectedLicenseInfo; } }


        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }

            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = value;
            }
        }

        public ctrlDriverLicenseInfoCardWithFilter()
        {
            InitializeComponent();
            ApplyLicenseFilterTheme();
        }

        private void ctrlDriverLicenseInfoCardWithFilter_Load(object sender, EventArgs e)
        {
            FilterFocus();
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            ctrlDriverLicenseInfoCard1.LoadDriverLicenseInfo(LicenseID);
        }
        public void FilterFocus()
        {
            txtLicenseID.Focus();
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("Same fields are not valid! put the mouse over the red icon(s) to see error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FilterFocus();
                return;

            }

            ctrlDriverLicenseInfoCard1.LoadDriverLicenseInfo(int.Parse(txtLicenseID.Text));

            if (OnLicenseSelected != null && FilterEnabled)
                LicenseSelected(SelectedLicenseID);
        }



        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // chick if the pressed Key is Enter (Key char 13)
            if (e.KeyChar == (char)13)
            {
                btnFindLicense.PerformClick();
            }

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "This filed is required");
            }
            else
            {
                errorProvider1.SetError(txtLicenseID, null);
            }
        }

        private void ApplyLicenseFilterTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);
            Color card = Color.FromArgb(30, 41, 59);

            // =========================
            // 📦 Filter GroupBox
            // =========================

            gbFilter.BackColor = card;
            gbFilter.ForeColor = Color.White;

            // =========================
            // 📝 Label
            // =========================

            label22.ForeColor = textGray;

            // =========================
            // 📥 TextBox
            // =========================

            txtLicenseID.BackColor = Color.FromArgb(15, 23, 42);
            txtLicenseID.ForeColor = textWhite;

            // =========================
            // 🔘 Button
            // =========================

            btnFindLicense.BackColor = primaryBlue;
            btnFindLicense.FlatStyle = FlatStyle.Flat;
            btnFindLicense.FlatAppearance.BorderSize = 0;

            btnFindLicense.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);

            // =========================
            // 🧠 مهم
            // =========================
            // لا نغير Size
            // لا نغير Location
            // لا نغير Font
        }
    }
}
