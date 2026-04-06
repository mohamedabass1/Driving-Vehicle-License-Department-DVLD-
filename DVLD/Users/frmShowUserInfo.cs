using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmShowUserInfo : Form
    {
        int _UserID;
        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();
            ApplyShowUserTheme();
            this._UserID = UserID;

        }
        private void frmShowUserInfo_Load(object sender, System.EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_UserID);

        }
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void ApplyShowUserTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);

            // 🔘 Close Button
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            // Hover (آمن)
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // 🧠 مهم:
            // لا نغير Size
            // لا نغير Font
            // لا نغير Location
        }

    }
}
