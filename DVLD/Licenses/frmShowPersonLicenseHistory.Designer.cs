namespace DVLD.Licenses
{
    partial class frmShowPersonLicenseHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tapLocal = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalLocalDrivingLicenses = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvLocalDrivingLicesnses = new System.Windows.Forms.DataGridView();
            this.tapInternational = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalInternationalDrivingLicenses = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvInternationalDrivingLicesnses = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmsLocalDrivingLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlPersonCardWithFilter1 = new DVLD.People.Controls.ctrlPersonCardWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tapLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicesnses)).BeginInit();
            this.tapInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalDrivingLicesnses)).BeginInit();
            this.cmsLocalDrivingLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(612, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "License History";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_512;
            this.pictureBox1.Location = new System.Drawing.Point(12, 165);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.groupBox1.Location = new System.Drawing.Point(12, 493);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1296, 316);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licesnes";
            // 
            // tabControl1
            // 
            this.tabControl1.ContextMenuStrip = this.cmsLocalDrivingLicense;
            this.tabControl1.Controls.Add(this.tapLocal);
            this.tabControl1.Controls.Add(this.tapInternational);
            this.tabControl1.Location = new System.Drawing.Point(6, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1266, 272);
            this.tabControl1.TabIndex = 0;
            // 
            // tapLocal
            // 
            this.tapLocal.Controls.Add(this.label2);
            this.tapLocal.Controls.Add(this.lblTotalLocalDrivingLicenses);
            this.tapLocal.Controls.Add(this.label5);
            this.tapLocal.Controls.Add(this.dgvLocalDrivingLicesnses);
            this.tapLocal.Location = new System.Drawing.Point(4, 32);
            this.tapLocal.Name = "tapLocal";
            this.tapLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tapLocal.Size = new System.Drawing.Size(1258, 236);
            this.tapLocal.TabIndex = 0;
            this.tapLocal.Text = "Local";
            this.tapLocal.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(30, 202);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 22);
            this.label2.TabIndex = 81;
            this.label2.Text = "#Records:";
            // 
            // lblTotalLocalDrivingLicenses
            // 
            this.lblTotalLocalDrivingLicenses.AutoSize = true;
            this.lblTotalLocalDrivingLicenses.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalLocalDrivingLicenses.Location = new System.Drawing.Point(136, 203);
            this.lblTotalLocalDrivingLicenses.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalLocalDrivingLicenses.Name = "lblTotalLocalDrivingLicenses";
            this.lblTotalLocalDrivingLicenses.Size = new System.Drawing.Size(30, 22);
            this.lblTotalLocalDrivingLicenses.TabIndex = 82;
            this.lblTotalLocalDrivingLicenses.Text = "??";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 19);
            this.label5.TabIndex = 80;
            this.label5.Text = "Local Driving Licenses:";
            // 
            // dgvLocalDrivingLicesnses
            // 
            this.dgvLocalDrivingLicesnses.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicesnses.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicesnses.AllowUserToResizeRows = false;
            this.dgvLocalDrivingLicesnses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalDrivingLicesnses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLocalDrivingLicesnses.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalDrivingLicesnses.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalDrivingLicesnses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalDrivingLicesnses.ColumnHeadersHeight = 29;
            this.dgvLocalDrivingLicesnses.ContextMenuStrip = this.cmsLocalDrivingLicense;
            this.dgvLocalDrivingLicesnses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLocalDrivingLicesnses.Location = new System.Drawing.Point(24, 40);
            this.dgvLocalDrivingLicesnses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLocalDrivingLicesnses.MultiSelect = false;
            this.dgvLocalDrivingLicesnses.Name = "dgvLocalDrivingLicesnses";
            this.dgvLocalDrivingLicesnses.ReadOnly = true;
            this.dgvLocalDrivingLicesnses.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 14F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalDrivingLicesnses.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocalDrivingLicesnses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvLocalDrivingLicesnses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalDrivingLicesnses.Size = new System.Drawing.Size(1211, 157);
            this.dgvLocalDrivingLicesnses.TabIndex = 79;
            this.dgvLocalDrivingLicesnses.TabStop = false;
            // 
            // tapInternational
            // 
            this.tapInternational.Controls.Add(this.label3);
            this.tapInternational.Controls.Add(this.lblTotalInternationalDrivingLicenses);
            this.tapInternational.Controls.Add(this.label7);
            this.tapInternational.Controls.Add(this.dgvInternationalDrivingLicesnses);
            this.tapInternational.Location = new System.Drawing.Point(4, 32);
            this.tapInternational.Name = "tapInternational";
            this.tapInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tapInternational.Size = new System.Drawing.Size(1258, 236);
            this.tapInternational.TabIndex = 1;
            this.tapInternational.Text = "International";
            this.tapInternational.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(30, 204);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 22);
            this.label3.TabIndex = 77;
            this.label3.Text = "#Records:";
            // 
            // lblTotalInternationalDrivingLicenses
            // 
            this.lblTotalInternationalDrivingLicenses.AutoSize = true;
            this.lblTotalInternationalDrivingLicenses.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalInternationalDrivingLicenses.Location = new System.Drawing.Point(133, 203);
            this.lblTotalInternationalDrivingLicenses.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalInternationalDrivingLicenses.Name = "lblTotalInternationalDrivingLicenses";
            this.lblTotalInternationalDrivingLicenses.Size = new System.Drawing.Size(30, 22);
            this.lblTotalInternationalDrivingLicenses.TabIndex = 78;
            this.lblTotalInternationalDrivingLicenses.Text = "??";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(259, 19);
            this.label7.TabIndex = 76;
            this.label7.Text = "International Driving Licenses:";
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 14F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalDrivingLicesnses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInternationalDrivingLicesnses.ColumnHeadersHeight = 29;
            this.dgvInternationalDrivingLicesnses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInternationalDrivingLicesnses.Location = new System.Drawing.Point(24, 42);
            this.dgvInternationalDrivingLicesnses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvInternationalDrivingLicesnses.MultiSelect = false;
            this.dgvInternationalDrivingLicesnses.Name = "dgvInternationalDrivingLicesnses";
            this.dgvInternationalDrivingLicesnses.ReadOnly = true;
            this.dgvInternationalDrivingLicesnses.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 14F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalDrivingLicesnses.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInternationalDrivingLicesnses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvInternationalDrivingLicesnses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalDrivingLicesnses.Size = new System.Drawing.Size(1211, 157);
            this.dgvInternationalDrivingLicesnses.TabIndex = 38;
            this.dgvInternationalDrivingLicesnses.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnClose.Location = new System.Drawing.Point(1148, 810);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(147, 43);
            this.btnClose.TabIndex = 79;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmsLocalDrivingLicense
            // 
            this.cmsLocalDrivingLicense.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmsLocalDrivingLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.cmsLocalDrivingLicense.Name = "cmsLocalDrivingLicense";
            this.cmsLocalDrivingLicense.Size = new System.Drawing.Size(206, 52);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.Driver_License_481;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(237, 70);
            this.ctrlPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(1071, 410);
            this.ctrlPersonCardWithFilter1.TabIndex = 2;
            // 
            // frmShowPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 856);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmShowPersonLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowPersonLicenseHistory";
            this.Load += new System.EventHandler(this.frmShowPersonLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tapLocal.ResumeLayout(false);
            this.tapLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicesnses)).EndInit();
            this.tapInternational.ResumeLayout(false);
            this.tapInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalDrivingLicesnses)).EndInit();
            this.cmsLocalDrivingLicense.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private People.Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tapLocal;
        private System.Windows.Forms.TabPage tapInternational;
        private System.Windows.Forms.DataGridView dgvInternationalDrivingLicesnses;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalInternationalDrivingLicenses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalLocalDrivingLicenses;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicesnses;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsLocalDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}