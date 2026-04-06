using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmFindPerson : Form
    {

        public delegate void DataBackEventHander(object sender, int PersonID);
        public event DataBackEventHander DataBack;
        public frmFindPerson()
        {
            InitializeComponent();
            ApplyFindPersonTheme();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlPersonCardWithFilter1.PersonID);
            this.Close();
        }
        private void ApplyFindPersonTheme()
        {
            // 🌙 الخلفية
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);

            // 🏷️ Title
            lblTitle.ForeColor = primaryBlue;

            // 📦 الكنترول الداخلي (نخليه يندمج مع الثيم)
            ctrlPersonCardWithFilter1.BackColor = Color.FromArgb(15, 23, 42);

            // 🔘 Close Button
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            // Hover effect
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // 🧠 Font
            this.Font = new Font("Segoe UI", 10);

            // ❗ بدون تغيير Layout
        }
    }
}
