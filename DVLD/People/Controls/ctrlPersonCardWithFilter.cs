using DVLDBusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID);
            }
        }


        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return btnAddNewPerson.Visible;
            }

            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }


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
                gbFilteres.Enabled = _FilterEnabled;
            }
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            ApplyFilterTheme();
        }

        private int _PersonID = -1;
        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCard1.SelectedPersonInfo; }
        }

        public void LoadPersonInfo(int PersonID)
        {
            // filter by Person ID
            cbFilterBy.SelectedIndex = 1;

            // Show Person ID in TextBox
            txtFilterValue.Text = PersonID.ToString();

            // Find Person
            _FindNow();
        }

        private void _FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    {
                        ctrlPersonCard1.LoadPersonInfo(int.Parse(txtFilterValue.Text));
                        break;
                    }

                case "National No":
                    {
                        ctrlPersonCard1.LoadPersonInfo(txtFilterValue.Text);
                        break;
                    }
                default:
                    break;
            }

            if (OnPersonSelected != null && FilterEnabled)
                // Raise the event the parameter
                PersonSelected(ctrlPersonCard1.PersonID);

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }


        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void txtFilterValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This filed is required");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
                //e.Cancel = false;

            }
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Same fields are not valid! put the mouse over the red icon(s) to see error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FindNow();
        }
        private void DataBackEvent(object sender, int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;

            txtFilterValue.Text = PersonID.ToString();

            ctrlPersonCard1.LoadPersonInfo(PersonID);

        }

        public void FilterFoucs()
        {
            txtFilterValue.Focus();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // chick if the pressed Key is Enter (Key char 13)
            if (e.KeyChar == (char)13)
            {
                btnFindPerson.PerformClick();
            }

            // this allow only digits if Person Id is selected
            if (cbFilterBy.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

        }

        private void btnAddNewPerson_Click_1(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += DataBackEvent; // subscribe to the Event

            frm.ShowDialog();
        }

        private void ApplyFilterTheme()
        {
            // 🌙 الخلفية العامة
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 📦 GroupBox (Filter Card)
            gbFilteres.BackColor = Color.FromArgb(30, 41, 59);
            gbFilteres.ForeColor = Color.White;
            gbFilteres.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gbFilteres.Text = "FILTER";

            // 🎯 ألوان
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);

            // 📝 Label
            label7.ForeColor = textGray;

            // 📥 ComboBox
            cbFilterBy.BackColor = Color.FromArgb(15, 23, 42);
            cbFilterBy.ForeColor = textWhite;
            cbFilterBy.FlatStyle = FlatStyle.Flat;

            // 🧾 TextBox
            txtFilterValue.BackColor = Color.FromArgb(15, 23, 42);
            txtFilterValue.ForeColor = textWhite;
            txtFilterValue.BorderStyle = BorderStyle.FixedSingle;

            // 🔘 Buttons
            btnFindPerson.BackColor = primaryBlue;
            btnFindPerson.FlatStyle = FlatStyle.Flat;
            btnFindPerson.FlatAppearance.BorderSize = 0;

            btnAddNewPerson.BackColor = primaryBlue;
            btnAddNewPerson.FlatStyle = FlatStyle.Flat;
            btnAddNewPerson.FlatAppearance.BorderSize = 0;

            // 🖼️ Icons داخل الأزرار
            btnFindPerson.ForeColor = Color.White;
            btnAddNewPerson.ForeColor = Color.White;

            // 🧠 الخط العام
            this.Font = new Font("Segoe UI", 10);

            // ❗ لا نغير أي Location أو Size
        }
    }

}
