using DVLD.Applications;
using DVLD.Applications.Detain_Driving_License;
using DVLD.Applications.Inertnational_Driving_License;
using DVLD.Applications.Local_Driving_License;
using DVLD.Applications.Renew_License_Application;
using DVLD.Applications.Replace_Dammaged_Or_Lost_License;
using DVLD.Applications.Rlease_Detained_License;
using DVLD.Drivers;
using DVLD.Tests.Test_Type;
using DVLD.Users;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            ApplyMainTheme();

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPeopleList frm = new frmShowPeopleList();
            frm.ShowDialog();

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowUsersList();
            frm.ShowDialog();
        }
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            this.Close();
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }
        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void manageApplactionTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListTestTypes();
            frm.ShowDialog();

        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void manageLocalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowLocalDrivingLicenseApplicationsList();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowLocalDrivingLicenseApplicationsList();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmDriversList();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddNewInertrnationalDrivingLicense();
            frm.ShowDialog();
        }

        private void ManageInternationaDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageInternationalLicenseList();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmRenewLicenseApplication();
            frm.ShowDialog();
        }

        private void ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReplaceDammagedOrLostLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainLicense();
            frm.Show();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageDetainedLicensesList();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();

        }

        private void ApplyMainTheme()
        {
            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color dark = Color.FromArgb(15, 23, 42);
            Color darker = Color.FromArgb(10, 18, 28);
            Color text = Color.FromArgb(226, 232, 240);

            // 🌙 الفورم
            this.BackColor = dark;

            // =========================
            // 📌 MenuStrip
            // =========================

            menuStrip1.BackColor = dark;
            menuStrip1.ForeColor = text;

            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.ForeColor = text;

                // Hover effect
                item.MouseEnter += (s, e) =>
                {
                    item.BackColor = Color.FromArgb(30, 41, 59);
                };

                item.MouseLeave += (s, e) =>
                {
                    item.BackColor = Color.Transparent;
                };

                // Dropdown Styling
                StyleDropDown(item, dark, text);
            }

            // =========================
            // 📌 Bottom Panel
            // =========================

            pnlBottom.BackColor = darker;

            lblSystemStatus.ForeColor = primaryBlue;
            lblVersion.ForeColor = Color.FromArgb(100, 116, 139);

            // =========================
            // 📌 Background Image
            // =========================

            pictureBox1.BackColor = dark;
        }
        private void StyleDropDown(ToolStripMenuItem menu, Color back, Color fore)
        {
            foreach (ToolStripItem item in menu.DropDownItems)
            {
                item.BackColor = back;
                item.ForeColor = fore;

                if (item is ToolStripMenuItem subMenu)
                {
                    subMenu.MouseEnter += (s, e) =>
                    {
                        subMenu.BackColor = Color.FromArgb(30, 41, 59);
                    };

                    subMenu.MouseLeave += (s, e) =>
                    {
                        subMenu.BackColor = back;
                    };

                    // recursion 👇
                    StyleDropDown(subMenu, back, fore);
                }
            }
        }
    }
}
