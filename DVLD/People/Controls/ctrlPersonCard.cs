using DVLD.Properties;
using DVLDBusinessLayer;
using DVLDBusinessLayer.Properties;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlPersonCard : UserControl
    {

        private clsPerson _Person1;
        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return _Person1; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
            ApplyProfessionalTheme();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person1 = clsPerson.Find(PersonID);

            if (_Person1 == null)
            {
                ResetPersonInfo();
                MessageBox.Show("Person is Not Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                _FillPersonInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person1 = clsPerson.Find(NationalNo);

            if (_Person1 == null)
            {
                MessageBox.Show("Person is Not Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                _FillPersonInfo();
        }
        private void _LoadPersonImage()
        {
            if (_Person1.Gender == 0)
                pibPersonImage.Image = Resources.Male_512;
            else
                pibPersonImage.Image = Resources.Female_512;

            string ImagePath = _Person1.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pibPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Cloud not find this Image: " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void _FillPersonInfo()
        {
            lblEditPersonInfo.Enabled = true;
            _PersonID = _Person1.PersonID;
            lblPersonID.Text = _Person1.PersonID.ToString();
            lblNationalNo.Text = _Person1.NationalNo;
            lblFullName.Text = _Person1.FullName;
            lblGender.Text = _Person1.Gender == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = _Person1.DateOfBirth.ToShortDateString();
            lblCountry.Text = clsCountry.Find(_Person1.NationalityCountryID).CountryName;
            lblAddress.Text = _Person1.Address;
            lblEmail.Text = _Person1.Email;
            lblPhone.Text = _Person1.Phone;

            _LoadPersonImage();
        }

        public void ResetPersonInfo()
        {
            lblEditPersonInfo.Enabled = false;

            _PersonID = -1;
            lblPersonID.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblFullName.Text = "[???]";
            lblGender.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
            lblCountry.Text = "[???]";
            lblAddress.Text = "[???]";
            lblEmail.Text = "[???]";
            lblPhone.Text = "[???]";
            pibPersonImage.Image = Resources.Male_512;
        }

        private void lblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson editPerson = new frmAddUpdatePerson(int.Parse(lblPersonID.Text));
            editPerson.ShowDialog();

            LoadPersonInfo(PersonID);
        }

        private void groupBox1_Enter(object sender, System.EventArgs e)
        {

        }

        private void ApplyProfessionalTheme()
        {
            // 🌙 الخلفية العامة
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 📦 نفس الـ GroupBox بدون تغيير موقعه
            groupBox1.BackColor = Color.FromArgb(30, 41, 59);
            groupBox1.ForeColor = Color.White;
            groupBox1.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // 🎯 ألوان موحدة
            Color titleColor = Color.FromArgb(148, 163, 184); // رمادي فاتح
            Color valueColor = Color.FromArgb(226, 232, 240); // أبيض مريح
            Color primaryBlue = Color.FromArgb(59, 130, 246);

            // 📝 العناوين (بدون تغيير مكانها)
            label1.ForeColor = titleColor;
            label2.ForeColor = titleColor;
            label4.ForeColor = titleColor;
            label5.ForeColor = titleColor;
            label7.ForeColor = titleColor;
            label8.ForeColor = titleColor;
            label11.ForeColor = titleColor;
            label12.ForeColor = titleColor;
            label13.ForeColor = titleColor;

            // 📊 القيم
            lblFullName.ForeColor = primaryBlue;
            lblFullName.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            lblPersonID.ForeColor = Color.Gray;
            lblNationalNo.ForeColor = valueColor;
            lblGender.ForeColor = valueColor;
            lblEmail.ForeColor = valueColor;
            lblAddress.ForeColor = valueColor;
            lblDateOfBirth.ForeColor = valueColor;
            lblPhone.ForeColor = valueColor;
            lblCountry.ForeColor = valueColor;

            // 🔗 الرابط
            lblEditPersonInfo.LinkColor = primaryBlue;
            lblEditPersonInfo.ActiveLinkColor = Color.LightBlue;

            // 🖼️ الصورة (بدون تغيير الحجم أو المكان)
            pibPersonImage.BackColor = Color.FromArgb(30, 41, 59);

            // 🎯 مهم: لا نغير أي Margin أو Location ❗
        }
    }
}
