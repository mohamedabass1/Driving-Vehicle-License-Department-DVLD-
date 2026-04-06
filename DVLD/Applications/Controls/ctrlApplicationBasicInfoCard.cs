using DVLDBusinessLayer;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Applications.Controls
{
    public partial class ctrlApplicationBasicInfoCard : UserControl
    {
        int _ApplicationID;
        clsApplication _Application1;


        public int SelectedApplicationID
        {
            get
            {
                return _ApplicationID;
            }
        }

        public clsApplication SelectedApplicationInfo
        {
            get { return _Application1; }
        }

        public ctrlApplicationBasicInfoCard()
        {
            InitializeComponent();
            ApplyApplicationCardTheme();
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application1 = clsApplication.FindBaseApplication(ApplicationID);

            if (_Application1 == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("Application is Not Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                _FillApplicationInfo();


        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application1.ApplicationID;
            lblApplicationID.Text = _ApplicationID.ToString();
            lblStatus.Text = _Application1.StatusText;
            lblFees.Text = _Application1.PaidFees.ToString();
            lblType.Text = _Application1.ApplicationTypeInfo.Title;
            lblApplicant.Text = _Application1.PersonInfo.FullName;
            lblDate.Text = _Application1.ApplicationDate.ToShortDateString();
            lblStatusDate.Text = _Application1.LastStatusDate.ToShortDateString();
            lblCreatedByUser.Text = _Application1.CreatedByUserInfo.UserName;

            llViewPersonInfo.Enabled = true;
        }

        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;
            lblApplicationID.Text = "[???}";
            lblStatus.Text = "[???}";
            lblFees.Text = "[???}";
            lblType.Text = "[???}";
            lblApplicant.Text = "[???}";
            lblDate.Text = "[???}";
            lblStatusDate.Text = "[???}";
            lblCreatedByUser.Text = "[???}";
            llViewPersonInfo.Enabled = false;

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonInfo(_Application1.ApplicantPersonID);
            frm.ShowDialog();


        }

        private void ApplyApplicationCardTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 📦 GroupBox
            groupBox1.BackColor = Color.FromArgb(30, 41, 59);
            groupBox1.ForeColor = Color.White;

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);

            // =========================
            // 📝 Titles (العناوين)
            // =========================
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is Label lbl)
                {
                    if (lbl.Font.Bold)
                        lbl.ForeColor = textGray;
                }
            }

            // =========================
            // 📊 Values (القيم)
            // =========================
            lblApplicationID.ForeColor = primaryBlue;
            lblApplicant.ForeColor = textWhite;
            lblType.ForeColor = primaryBlue;
            lblFees.ForeColor = textWhite;
            lblDate.ForeColor = textWhite;
            lblStatusDate.ForeColor = textWhite;
            lblCreatedByUser.ForeColor = textWhite;

            // =========================
            // 🟢 Status (🔥 مهم جداً)
            // =========================
            string status = lblStatus.Text.ToLower();

            if (status.Contains("new"))
                lblStatus.ForeColor = primaryBlue;
            else if (status.Contains("completed"))
                lblStatus.ForeColor = Color.FromArgb(34, 197, 94); // Green
            else if (status.Contains("cancel"))
                lblStatus.ForeColor = Color.FromArgb(239, 68, 68); // Red
            else
                lblStatus.ForeColor = textWhite;

            // =========================
            // 🔗 LinkLabel
            // =========================
            llViewPersonInfo.LinkColor = primaryBlue;
            llViewPersonInfo.ActiveLinkColor = Color.LightBlue;

            // =========================
            // 🖼️ Icons
            // =========================
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox6.BackColor = Color.Transparent;
            pictureBox7.BackColor = Color.Transparent;
            pictureBox8.BackColor = Color.Transparent;

            // ❗ بدون تغيير:
            // Size ❌
            // Location ❌
            // Font ❌
        }
    }
}
