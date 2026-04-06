using DVLD.Global_Classes;
using DVLD.Properties;
using DVLDBusinessLayer;
using DVLDBusinessLayer.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddUpdatePerson : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // declare an event using delegate
        public event DataBackEventHandler DataBack;

        clsPerson _Person;
        int _PersonID = -1;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            ApplyAddPersonTheme();

            _Mode = enMode.AddNew;


        }
        public frmAddUpdatePerson(int PersonID)
        {

            InitializeComponent();
            ApplyAddPersonTheme();



            _Mode = enMode.Update;
            _PersonID = PersonID;

        }
        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {

            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();

        }
        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }

        }
        void _ResetDefaultValues()
        {
            // fill countries in combo-box
            _FillCountriesInComoboBox();

            if (_Mode == enMode.AddNew)
            {

                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();

            }
            else
            {
                lblTitle.Text = "Update Person";
            }

            // set default image for the person
            if (rbMale.Checked)
                pibPersonImage.Image = Resources.Male_512;
            else
                pibPersonImage.Image = Resources.Female_512;

            // hide\show remove link in case there is no image for person
            lblRemoveImage.Visible = (pibPersonImage.ImageLocation != null);

            // set the max Date to 18 years, 
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);


            // this will set the default country is Yemen
            cbCountries.SelectedIndex = cbCountries.FindString("Yemen");


            lblPersonID.Text = "";
            txtNationalNo.Text = "";
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";

        }

        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID [" + _PersonID + "]", "Person not found.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // the following code will not executed if the person not found

            lblPersonID.Text = _Person.PersonID.ToString();
            txtNationalNo.Text = _Person.NationalNo;
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            dtpDateOfBirth.Value = _Person.DateOfBirth;


            if (_Person.Gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;

            cbCountries.SelectedIndex = cbCountries.FindString(_Person.Country.CountryName);



            // Load Person Image in case it was set
            if (_Person.ImagePath != "")
            {
                pibPersonImage.ImageLocation = _Person.ImagePath;
            }

            lblRemoveImage.Visible = (_Person.ImagePath != "");

        }
        private bool _HandelPersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pibPersonImage.ImageLocation)
            {

                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException iox)
                    {
                        return false;
                    }

                }

                if (pibPersonImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it

                    string SourceImageFile = pibPersonImage.ImageLocation.ToString();

                    if (clsUitl.CopyThePersonImageToProjectFolder(ref SourceImageFile))
                    {
                        pibPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }


            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Same fields are not valid! put the mouse over the red icon(s) to see error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandelPersonImage())
            {
                return;
            }

            int NationalCountryID = clsCountry.Find(cbCountries.Text).CountryID;



            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;

            if (rbMale.Checked)
                _Person.Gender = 0;
            else
                _Person.Gender = 1;

            _Person.NationalityCountryID = NationalCountryID;


            if (pibPersonImage.ImageLocation != null)
                _Person.ImagePath = pibPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();

                // change the Mode Update
                _Mode = enMode.Update;
                lblTitle.Text = "Update Person";


                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send DataBack to the caller of form
                DataBack?.Invoke(this, _Person.PersonID);
            }

        }

        private void lblOpenFileDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pibPersonImage.Load(selectedFilePath);
                lblRemoveImage.Visible = true;
                // ...
            }
        }
        private void lblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pibPersonImage.ImageLocation = null;

            if (rbMale.Checked)
                pibPersonImage.Image = Resources.Male_512;
            else
                pibPersonImage.Image = Resources.Female_512;

            lblRemoveImage.Visible = false;
        }


        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pibPersonImage.ImageLocation == null)
                pibPersonImage.Image = Resources.Male_512;
        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pibPersonImage.ImageLocation == null)
                pibPersonImage.Image = Resources.Female_512;
        }
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
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;

            if (!clsValidatoin.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address format");

            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
                //e.Cancel = false;

            }
        }
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This filed is required");
            }
            else
                errorProvider1.SetError(txtNationalNo, null);



            if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used by another person");
            }
            else
                errorProvider1.SetError(txtNationalNo, null);

        }

        private void ApplyAddPersonTheme()
        {
            // 🌙 الخلفية العامة
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 📦 Main Panel (Card)
            panel1.BackColor = Color.FromArgb(30, 41, 59);
            panel1.BorderStyle = BorderStyle.None;

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);

            // 🏷️ Title
            lblTitle.ForeColor = primaryBlue;

            // 🆔 Person ID
            lblPersonID.ForeColor = Color.Gray;


            // 📝 Labels (كلها نفس اللون)
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = textGray;
                }
            }
            label7.ForeColor = textGray;

            // 📊 Inputs (TextBoxes)
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.BackColor = Color.FromArgb(15, 23, 42);
                    txt.ForeColor = textWhite;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
            }

            // 📥 ComboBox
            cbCountries.BackColor = Color.FromArgb(15, 23, 42);
            cbCountries.ForeColor = textWhite;
            cbCountries.FlatStyle = FlatStyle.Flat;

            // 📅 DatePicker
            dtpDateOfBirth.CalendarMonthBackground = Color.FromArgb(15, 23, 42);
            dtpDateOfBirth.CalendarForeColor = textWhite;

            // 🔘 Radio Buttons
            rbMale.ForeColor = textWhite;
            rbFemale.ForeColor = textWhite;

            // 🔘 Buttons
            btnSave.BackColor = primaryBlue;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;

            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            // 🔗 Links
            lblOpenFileDialog.LinkColor = primaryBlue;
            lblRemoveImage.LinkColor = Color.FromArgb(239, 68, 68);

            // 🖼️ Image
            pibPersonImage.BackColor = Color.FromArgb(15, 23, 42);

            // 🧠 Font عام
            this.Font = new Font("Segoe UI", 10);

            // ❗ مهم: لا نغير أي Layout
        }
    }
}
