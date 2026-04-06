namespace DVLD.Applications.Inertnational_Driving_License
{
    partial class frmManageInternationalLicenseList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvInternationalDrivingLicesnses = new System.Windows.Forms.DataGridView();
            this.cmsInternationalApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicensesHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewInertnationalApplication = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterActiveLicense = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalDrivingLicesnses)).BeginInit();
            this.cmsInternationalApplication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInternationalDrivingLicesnses
            // 
            this.dgvInternationalDrivingLicesnses.AllowUserToAddRows = false;
            this.dgvInternationalDrivingLicesnses.AllowUserToDeleteRows = false;
            this.dgvInternationalDrivingLicesnses.AllowUserToResizeRows = false;
            this.dgvInternationalDrivingLicesnses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalDrivingLicesnses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInternationalDrivingLicesnses.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalDrivingLicesnses.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalDrivingLicesnses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInternationalDrivingLicesnses.ColumnHeadersHeight = 29;
            this.dgvInternationalDrivingLicesnses.ContextMenuStrip = this.cmsInternationalApplication;
            this.dgvInternationalDrivingLicesnses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInternationalDrivingLicesnses.Location = new System.Drawing.Point(25, 360);
            this.dgvInternationalDrivingLicesnses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvInternationalDrivingLicesnses.MultiSelect = false;
            this.dgvInternationalDrivingLicesnses.Name = "dgvInternationalDrivingLicesnses";
            this.dgvInternationalDrivingLicesnses.ReadOnly = true;
            this.dgvInternationalDrivingLicesnses.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalDrivingLicesnses.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInternationalDrivingLicesnses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvInternationalDrivingLicesnses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalDrivingLicesnses.Size = new System.Drawing.Size(1304, 283);
            this.dgvInternationalDrivingLicesnses.TabIndex = 164;
            this.dgvInternationalDrivingLicesnses.TabStop = false;
            // 
            // cmsInternationalApplication
            // 
            this.cmsInternationalApplication.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmsInternationalApplication.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsInternationalApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetilesToolStripMenuItem,
            this.showLicenseDetilesToolStripMenuItem,
            this.showPersonLicensesHistoryToolStripMenuItem});
            this.cmsInternationalApplication.Name = "cmsInternationalApplication";
            this.cmsInternationalApplication.Size = new System.Drawing.Size(291, 82);
            // 
            // showPersonDetilesToolStripMenuItem
            // 
            this.showPersonDetilesToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonDetails_321;
            this.showPersonDetilesToolStripMenuItem.Name = "showPersonDetilesToolStripMenuItem";
            this.showPersonDetilesToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.showPersonDetilesToolStripMenuItem.Text = "Show Person Detiles";
            this.showPersonDetilesToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetilesToolStripMenuItem_Click);
            // 
            // showLicenseDetilesToolStripMenuItem
            // 
            this.showLicenseDetilesToolStripMenuItem.Image = global::DVLD.Properties.Resources.License_View_32;
            this.showLicenseDetilesToolStripMenuItem.Name = "showLicenseDetilesToolStripMenuItem";
            this.showLicenseDetilesToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.showLicenseDetilesToolStripMenuItem.Text = "Show License Detiles";
            this.showLicenseDetilesToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetilesToolStripMenuItem_Click);
            // 
            // showPersonLicensesHistoryToolStripMenuItem
            // 
            this.showPersonLicensesHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicensesHistoryToolStripMenuItem.Name = "showPersonLicensesHistoryToolStripMenuItem";
            this.showPersonLicensesHistoryToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.showPersonLicensesHistoryToolStripMenuItem.Text = "Show Person Licenses History";
            this.showPersonLicensesHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicensesHistoryToolStripMenuItem_Click);
            // 
            // btnAddNewInertnationalApplication
            // 
            this.btnAddNewInertnationalApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewInertnationalApplication.Image = global::DVLD.Properties.Resources.New_Application_64;
            this.btnAddNewInertnationalApplication.Location = new System.Drawing.Point(1241, 277);
            this.btnAddNewInertnationalApplication.Name = "btnAddNewInertnationalApplication";
            this.btnAddNewInertnationalApplication.Size = new System.Drawing.Size(88, 75);
            this.btnAddNewInertnationalApplication.TabIndex = 163;
            this.btnAddNewInertnationalApplication.UseVisualStyleBackColor = true;
            this.btnAddNewInertnationalApplication.Click += new System.EventHandler(this.btnAddNewInertnationalApplication_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnClose.Location = new System.Drawing.Point(1182, 656);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(147, 43);
            this.btnClose.TabIndex = 162;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Tahoma", 14F);
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Internatonal License ID",
            "Application ID",
            "Driver ID",
            "Local License ID",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(145, 320);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(262, 31);
            this.cbFilterBy.TabIndex = 161;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtFilterValue.Location = new System.Drawing.Point(435, 321);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(276, 30);
            this.txtFilterValue.TabIndex = 160;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(31, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 26);
            this.label2.TabIndex = 159;
            this.label2.Text = "Filter By:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 15F);
            this.lblRecordsCount.Location = new System.Drawing.Point(144, 657);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(28, 24);
            this.lblRecordsCount.TabIndex = 158;
            this.lblRecordsCount.Text = "??";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(22, 656);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 157;
            this.label3.Text = "# Records:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.International_32;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(713, 87);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 156;
            this.pictureBox1.TabStop = false;
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::DVLD.Properties.Resources.Applications;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(537, 20);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(220, 189);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 155;
            this.pbPersonImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(371, 231);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(563, 39);
            this.label1.TabIndex = 154;
            this.label1.Text = "International License Applications";
            // 
            // cbFilterActiveLicense
            // 
            this.cbFilterActiveLicense.BackColor = System.Drawing.Color.White;
            this.cbFilterActiveLicense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterActiveLicense.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbFilterActiveLicense.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbFilterActiveLicense.FormattingEnabled = true;
            this.cbFilterActiveLicense.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbFilterActiveLicense.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbFilterActiveLicense.Location = new System.Drawing.Point(441, 320);
            this.cbFilterActiveLicense.Name = "cbFilterActiveLicense";
            this.cbFilterActiveLicense.Size = new System.Drawing.Size(150, 27);
            this.cbFilterActiveLicense.TabIndex = 166;
            this.cbFilterActiveLicense.Visible = false;
            this.cbFilterActiveLicense.SelectedIndexChanged += new System.EventHandler(this.cbFilterActiveLicense_SelectedIndexChanged);
            // 
            // frmManageInternationalLicenseList
            // 
            this.AcceptButton = this.btnAddNewInertnationalApplication;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 705);
            this.Controls.Add(this.dgvInternationalDrivingLicesnses);
            this.Controls.Add(this.btnAddNewInertnationalApplication);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFilterActiveLicense);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManageInternationalLicenseList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manag International License List";
            this.Load += new System.EventHandler(this.frmManagInternationalLicenseList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalDrivingLicesnses)).EndInit();
            this.cmsInternationalApplication.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInternationalDrivingLicesnses;
        private System.Windows.Forms.Button btnAddNewInertnationalApplication;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalApplication;
        private System.Windows.Forms.ComboBox cbFilterActiveLicense;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicensesHistoryToolStripMenuItem;
    }
}