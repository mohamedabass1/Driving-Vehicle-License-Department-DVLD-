using DVLDBusinessLayer;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmShowUsersList : Form
    {
        public frmShowUsersList()
        {
            InitializeComponent();
            ApplyUsersListTheme();
        }

        private static DataTable _dtUserList;
        private void frmShowUsersList_Load(object sender, System.EventArgs e)
        {

            _dtUserList = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtUserList;

            cbFilterBy.SelectedIndex = 0;
            lblTotalRecords.Text = dgvUsers.Rows.Count.ToString();

            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 150;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 150;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 320;

                dgvUsers.Columns[3].HeaderText = "User Name";
                dgvUsers.Columns[3].Width = 200;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 100;
            }
        }


        private void cbFilterBy_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbFilterActiveUsers.Visible = true;
                cbFilterActiveUsers.Focus();
                cbFilterActiveUsers.SelectedIndex = 0;

            }

            else
            {
                cbFilterActiveUsers.Visible = false;
                txtFilterValue.Visible = (cbFilterBy.Text != "None");

                txtFilterValue.Text = "";
                txtFilterValue.Focus();

            }

        }
        private void cbFilterActiveUsers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbFilterActiveUsers.Text;

            switch (FilterValue)
            {
                case "All":
                    break;

                case "Yes":
                    FilterValue = "1";
                    break;

                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _dtUserList.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtUserList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);


            lblTotalRecords.Text = dgvUsers.Rows.Count.ToString();

        }

        private void ApplayFitring()
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "User Name":
                    FilterColumn = "UserName";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtUserList.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvUsers.Rows.Count.ToString();
                return;
            }



            if (FilterColumn == "UserID" || FilterColumn == "PersonID")
                _dtUserList.DefaultView.RowFilter = $" [{FilterColumn}] = {txtFilterValue.Text.Trim()}";

            else
                _dtUserList.DefaultView.RowFilter = $" [{FilterColumn}] LIKE  '{txtFilterValue.Text.Trim()}%'";


            lblTotalRecords.Text = dgvUsers.Rows.Count.ToString();

        }
        private void txtFilterValue_TextChanged(object sender, System.EventArgs e)
        {
            ApplayFitring();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // this allow only digits if Person Id is selected
            if (cbFilterBy.Text == "User ID" || cbFilterBy.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }


        private void btnAddNewUser_Click_1(object sender, System.EventArgs e)
        {

            Form frm = new frmAddUpdateUser();
            frm.ShowDialog();
            frmShowUsersList_Load(null, null);

        }
        private void addNewUserToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Form frm = new frmAddUpdateUser();
            frm.ShowDialog();
            frmShowUsersList_Load(null, null);

        }
        private void editToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int UserID = int.Parse(dgvUsers.CurrentRow.Cells[0].Value.ToString());
            Form frm = new frmAddUpdateUser(UserID);

            frm.ShowDialog();
            frmShowUsersList_Load(null, null);
        }
        private void deleteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

            int UserID = int.Parse(dgvUsers.CurrentRow.Cells[0].Value.ToString());

            if (MessageBox.Show("Are you sure you want to delete User [" + UserID + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show("User Deleted Successfully", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmShowUsersList_Load(null, null);
                }
                else
                    MessageBox.Show("User was not deleted because it has data link to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void showDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Form frm = new frmShowUserInfo(int.Parse(dgvUsers.CurrentRow.Cells[0].Value.ToString()));
            frm.ShowDialog();

        }
        private void changPasswordtoolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            Form frm = new frmChangePassword(int.Parse(dgvUsers.CurrentRow.Cells[0].Value.ToString()));
            frm.ShowDialog();
        }


        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void sendEmailToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("This feature dos not implement yet ", "Incomplete Feature",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private void phoneCallToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("This feature dos not implement yet ", "Incomplete Feature",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void ApplyUsersListTheme()
        {
            // 🌙 Background
            this.BackColor = Color.FromArgb(15, 23, 42);

            // 🎯 Colors
            Color primaryBlue = Color.FromArgb(59, 130, 246);
            Color textWhite = Color.FromArgb(226, 232, 240);
            Color textGray = Color.FromArgb(148, 163, 184);
            Color card = Color.FromArgb(30, 41, 59);

            // 🏷️ Title
            label1.ForeColor = primaryBlue;

            // 📝 Labels
            label2.ForeColor = textGray;
            label3.ForeColor = textGray;
            lblTotalRecords.ForeColor = textWhite;

            // 📥 ComboBox
            cbFilterBy.BackColor = Color.FromArgb(15, 23, 42);
            cbFilterBy.ForeColor = textWhite;
            cbFilterBy.FlatStyle = FlatStyle.Flat;

            cbFilterActiveUsers.BackColor = Color.FromArgb(15, 23, 42);
            cbFilterActiveUsers.ForeColor = textWhite;
            cbFilterActiveUsers.FlatStyle = FlatStyle.Flat;

            // 📥 TextBox
            txtFilterValue.BackColor = Color.FromArgb(15, 23, 42);
            txtFilterValue.ForeColor = textWhite;

            // 🔘 Add Button (Guna)
            btnAddNewUser.FillColor = primaryBlue;
            btnAddNewUser.BorderThickness = 0;

            // 🔘 Close Button
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;

            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // 🖼️ Image
            pictureBox1.BackColor = Color.Transparent;

            // =========================
            // 📊 DataGridView (🔥 مهم)
            // =========================

            dgvUsers.BackgroundColor = card;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.EnableHeadersVisualStyles = false;

            // Header
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 175);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Rows
            dgvUsers.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvUsers.DefaultCellStyle.ForeColor = textWhite;
            dgvUsers.DefaultCellStyle.SelectionBackColor = primaryBlue;
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid
            dgvUsers.GridColor = Color.FromArgb(51, 65, 85);

            // Row Header
            dgvUsers.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvUsers.RowHeadersDefaultCellStyle.ForeColor = textWhite;

            // =========================
            // 🧾 Context Menu
            // =========================

            contextMenuStrip1.BackColor = Color.FromArgb(30, 41, 59);
            contextMenuStrip1.ForeColor = textWhite;

            foreach (ToolStripItem item in contextMenuStrip1.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.BackColor = Color.FromArgb(30, 41, 59);
                    menuItem.ForeColor = textWhite;
                }
            }

            // ❗ بدون تغيير:
            // Size ❌
            // Location ❌
            // Font ❌
        }


    }
}
