namespace DVLD.Licenses
{
    partial class frmIssueDrivingLicenseFristTime
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.ctrlLocalDrivingLicenseApplicationInfoCard1 = new DVLD.Applications.Local_Driving_License.ctrlLocalDrivingLicenseApplicationInfoCard();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 397);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 192;
            this.label3.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtNotes.Location = new System.Drawing.Point(130, 398);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(858, 194);
            this.txtNotes.TabIndex = 194;
            // 
            // btnIssue
            // 
            this.btnIssue.FlatAppearance.BorderSize = 2;
            this.btnIssue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnIssue.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_321;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnIssue.Location = new System.Drawing.Point(831, 605);
            this.btnIssue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(157, 42);
            this.btnIssue.TabIndex = 196;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnClose.Location = new System.Drawing.Point(656, 605);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(157, 42);
            this.btnClose.TabIndex = 195;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD.Properties.Resources.Notes_32;
            this.pictureBox4.Location = new System.Drawing.Point(81, 397);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 26);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 193;
            this.pictureBox4.TabStop = false;
            // 
            // ctrlLocalDrivingLicenseApplicationInfoCard1
            // 
            this.ctrlLocalDrivingLicenseApplicationInfoCard1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ctrlLocalDrivingLicenseApplicationInfoCard1.Location = new System.Drawing.Point(13, 13);
            this.ctrlLocalDrivingLicenseApplicationInfoCard1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlLocalDrivingLicenseApplicationInfoCard1.Name = "ctrlLocalDrivingLicenseApplicationInfoCard1";
            this.ctrlLocalDrivingLicenseApplicationInfoCard1.Size = new System.Drawing.Size(985, 363);
            this.ctrlLocalDrivingLicenseApplicationInfoCard1.TabIndex = 0;
            // 
            // frmIssueDrivingLicenseFristTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 658);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApplicationInfoCard1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmIssueDrivingLicenseFristTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Driving License Frist Time";
            this.Load += new System.EventHandler(this.frmIssueDrivingLicenseFristTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.Local_Driving_License.ctrlLocalDrivingLicenseApplicationInfoCard ctrlLocalDrivingLicenseApplicationInfoCard1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
    }
}