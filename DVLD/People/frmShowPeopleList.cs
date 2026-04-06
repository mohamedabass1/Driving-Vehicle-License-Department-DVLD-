using DVLDBusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmShowPeopleList : Form
    {
        public frmShowPeopleList()
        {
            InitializeComponent();
            ApplyPeopleListTheme();
        }

        DataView PeopleDataView;
        private void _RefreshPeopleList()
        {
            PeopleDataView = clsPerson.GetAllPeople().DefaultView;

            dgvPeopleList.DataSource = PeopleDataView;

            // Number of record in DataView
            lblTotalRecords.Text = (dgvPeopleList.Rows.Count).ToString();

        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {

            _RefreshPeopleList();
            cbFillter.SelectedIndex = 0;


        }
        private void ApplyFilter()
        {


            string selectedFilter = cbFillter.SelectedItem.ToString();
            string filterValue = txtSearsh.Text.Trim();


            if (string.IsNullOrEmpty(filterValue) || selectedFilter == "None")
            {
                PeopleDataView.RowFilter = "";
                lblTotalRecords.Text = (dgvPeopleList.Rows.Count).ToString();

                return;
            }


            if (selectedFilter == "Person ID")
                PeopleDataView.RowFilter = $"[{selectedFilter}] = {int.Parse(filterValue)}";
            else
                PeopleDataView.RowFilter = $"[{selectedFilter}] LIKE '{filterValue}%'";

            lblTotalRecords.Text = (dgvPeopleList.Rows.Count).ToString();

        }
        private void txtSearsh_TextChanged_1(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cbFillter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtSearsh.Visible = (cbFillter.SelectedItem.ToString() != "None");

            // if the filter is None  
            if (!txtSearsh.Visible)
            {
                txtSearsh.Text = string.Empty;
            }

        }

        // this Event allow User to Enter Digit for Person Id Filtering
        private void txtSearsh_KeyPress(object sender, KeyPressEventArgs e)
        {
            // this allow only digits if Person Id is selected
            if (cbFillter.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

        }


        private void btnAddNewPerson_Click_1(object sender, EventArgs e)
        {
            frmAddUpdatePerson AddNewPerson = new frmAddUpdatePerson();
            AddNewPerson.ShowDialog();

            _RefreshPeopleList();

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson AddNewPerson = new frmAddUpdatePerson();
            AddNewPerson.ShowDialog();

            _RefreshPeopleList();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson Edit = new frmAddUpdatePerson((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            Edit.ShowDialog();

            _RefreshPeopleList();


        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo PersonDetails = new frmShowPersonInfo((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            PersonDetails.ShowDialog();


        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int PersonIDToDelete = int.Parse(dgvPeopleList.CurrentRow.Cells[0].Value.ToString());

            if (MessageBox.Show("Are you sure you want to delete Person [" + PersonIDToDelete + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson(PersonIDToDelete))
                {
                    MessageBox.Show("Person Deleted Successfully", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }
                else
                    MessageBox.Show("Person was not deleted because it has data link to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature dos not implement yet ", "Incomplete Feature", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature dos not implement yet ", "Incomplete Feature", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }


        private void ApplyPeopleListTheme()
        {
            // 🌙 الخلفية
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
            cbFillter.BackColor = Color.FromArgb(15, 23, 42);
            cbFillter.ForeColor = textWhite;
            cbFillter.FlatStyle = FlatStyle.Flat;

            // 🔍 Search (Guna)
            txtSearsh.FillColor = Color.FromArgb(15, 23, 42);
            txtSearsh.ForeColor = textWhite;
            txtSearsh.BorderColor = primaryBlue;

            // 🔘 Add Button (Guna)
            btnAddNewPerson.FillColor = primaryBlue;
            btnAddNewPerson.BorderThickness = 0;

            // 🔘 Close Button
            btnClose.BackColor = Color.FromArgb(71, 85, 105);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 116, 139);

            // 🖼️ Image
            pictureBox1.BackColor = Color.Transparent;

            // 📊 DataGridView (🔥 أهم جزء)
            dgvPeopleList.BackgroundColor = card;
            dgvPeopleList.BorderStyle = BorderStyle.None;
            dgvPeopleList.EnableHeadersVisualStyles = false;

            // Header
            dgvPeopleList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 175);
            dgvPeopleList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPeopleList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // Rows
            dgvPeopleList.DefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvPeopleList.DefaultCellStyle.ForeColor = textWhite;
            dgvPeopleList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dgvPeopleList.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid lines
            dgvPeopleList.GridColor = Color.FromArgb(51, 65, 85);

            // Row headers
            dgvPeopleList.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvPeopleList.RowHeadersDefaultCellStyle.ForeColor = textWhite;

            // 🧾 Context Menu
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

            // 🧠 Font عام
            this.Font = new Font("Segoe UI", 10);

            // ❗ بدون تغيير Layout
        }
    }
}
