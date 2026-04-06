using DVLDBusinessLayer;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Users.Controls
{
    public partial class ctrlUserCard : UserControl
    {

        int _UserID;
        clsUser _User1;

        public int UserID
        {
            get { return _UserID; }
        }


        public ctrlUserCard()
        {
            InitializeComponent();
            ApplyUserCardTheme();
        }

        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;

            _User1 = clsUser.FindUserByUserID(UserID);

            if (_User1 == null)
            {
                MessageBox.Show("User is Not Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();

        }
        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User1.PersonID);
            lblUserID.Text = _User1.UserID.ToString();
            lblUserName.Text = _User1.UserName.ToString();

            lblisActive.Text = _User1.IsActive ? "Yes" : "No";

        }

        private void _RestUserInfo()
        {
            ctrlPersonCard1.ResetPersonInfo();

            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblisActive.Text = "[???]";
        }

        private void ctrlUserCard_Load(object sender, System.EventArgs e)
        {

        }
        private void ApplyUserCardTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 📦 GroupBox (بدون تغيير Size أو Padding)
            groupBox1.BackColor = Color.FromArgb(30, 41, 59);
            groupBox1.ForeColor = Color.White;

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);

            // 📝 Titles (فقط لون)
            label1.ForeColor = textGray;
            label3.ForeColor = textGray;
            label4.ForeColor = textGray;

            // 📊 Values (فقط لون)
            lblUserID.ForeColor = textWhite;
            lblUserName.ForeColor = primaryBlue;

            // 🟢 Status (بدون تغيير حجم أو Font)
            if (lblisActive.Text.ToLower().Contains("true"))
                lblisActive.ForeColor = Color.FromArgb(34, 197, 94);
            else
                lblisActive.ForeColor = Color.FromArgb(239, 68, 68);


        }
    }
}
