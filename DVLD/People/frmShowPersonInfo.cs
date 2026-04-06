using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            ApplyModernStyle();

            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }

        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();

            ctrlPersonCard1.LoadPersonInfo(NationalNo);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }

        private void ApplyModernStyle()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);
            this.ForeColor = Color.White;

            // 🏷️ Title
            lblTitle.ForeColor = Color.FromArgb(59, 130, 246); // Blue
            lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitle.Text = "PERSON DETAILS";

            // 🔘 Close Button
            btnClose.BackColor = Color.FromArgb(59, 130, 246);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnClose.Cursor = Cursors.Hand;

            // Hover Effect
            btnClose.MouseEnter += (s, e) =>
            {
                btnClose.BackColor = Color.FromArgb(37, 99, 235);
            };

            btnClose.MouseLeave += (s, e) =>
            {
                btnClose.BackColor = Color.FromArgb(59, 130, 246);
            };

            // 📦 تحسين توزيع الكنترول
            ctrlPersonCard1.BackColor = Color.Transparent;

            // 🧩 تحسين المسافات
            lblTitle.Location = new Point((this.Width - lblTitle.Width) / 2, 20);
        }
    }
}
