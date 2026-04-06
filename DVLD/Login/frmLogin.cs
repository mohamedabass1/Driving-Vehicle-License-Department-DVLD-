using DVLD_Utilities;
using DVLDBusinessLayer;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
            ApplyLoginTheme();
        }


        private void frmLogin_Load(object sender, System.EventArgs e)
        {
            string username = "", password = "";


            if (clsGlobal.GetStoredCredential(ref username, ref password))
            {
                txtUserName.Text = username;
                txtPassword.Text = password;
                chbRememberMe.Checked = true;
            }
            else
                chbRememberMe.Checked = false; ;


        }
        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            clsUser user = clsUser.FindUserByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());


            if (user != null)
            {
                if (chbRememberMe.Checked)
                {
                    //store username and password in Registry
                    clsGlobal.RememberUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                }
                else
                {
                    //store empty username and password
                    clsGlobal.RememberUserNameAndPassword("", "");


                }


                if (!user.IsActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your account is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = user;

                Form frm = new frmMain();
                this.Hide();
                frm.ShowDialog();

                // Log in Event Viewer
                clsEventLogger.Log("User logged into DVLD system", EventLogEntryType.Information);

                // to show login form after exiting from main form
                this.Show();

            }
            else
            {
                MessageBox.Show("Invalid UserName Or Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }



        private void chbShowPassword_CheckedChanged(object sender, System.EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = (!chbShowPassword.Checked);
        }
        private void lblClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ApplyLoginTheme()
        {
            // 🌙 الخلفية العامة
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🔵 Left Panel (Navy قوي)
            panel1.BackColor = Color.FromArgb(15, 23, 42);

            // 🧾 Right Panel (Card Light Dark)
            panel2.BackColor = Color.FromArgb(30, 41, 59);

            // 🎯 ألوان أساسية
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);

            // 📝 Title
            label4.ForeColor = textWhite;

            // 📝 Labels
            label2.ForeColor = textGray;
            label3.ForeColor = textGray;

            // 📅 Date
            lblDate.ForeColor = textGray;

            // 🧾 Inputs
            txtUserName.BackColor = Color.FromArgb(15, 23, 42);
            txtUserName.ForeColor = textWhite;
            txtUserName.BorderStyle = BorderStyle.FixedSingle;

            txtPassword.BackColor = Color.FromArgb(15, 23, 42);
            txtPassword.ForeColor = textWhite;

            // ✔️ Checkboxes
            chbShowPassword.ForeColor = textGray;
            chbRememberMe.ForeColor = textGray;

            // 🔘 Button
            btnLogin.BackColor = primaryBlue;
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(29, 78, 216);

            // ❌ Close Button
            lblClose.ForeColor = Color.FromArgb(239, 68, 68);

            // 🖼️ Icons (خليها شفافة)
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;

            pibEmail.BackColor = Color.Transparent;
            pibGithub.BackColor = Color.Transparent;
            pibLinkedIn.BackColor = Color.Transparent;

            // 🧠 تحسين الخط العام
            this.Font = new Font("Segoe UI", 11);

            // 🔥 مهم: لا نغير أي Layout
        }

        private void pibLinkedIn_Click(object sender, System.EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://www.linkedin.com/in/mohamed-abass-157a6a328?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app", UseShellExecute = true });

        }

        private void pibGithub_Click(object sender, System.EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/mohamedabass1", UseShellExecute = true });

        }
    }
}
