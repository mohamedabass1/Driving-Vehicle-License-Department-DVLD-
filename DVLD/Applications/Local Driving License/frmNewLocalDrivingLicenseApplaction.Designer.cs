namespace DVLD.Applications.Local_Driving_License
{
    partial class frmAddUpdateLocalDrivingLicenseApplication
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
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.tabLocalApplicationInfo = new System.Windows.Forms.TabControl();
            this.tabcPersonalInfo = new System.Windows.Forms.TabPage();
            this.ctrlPersonCardWithFilter1 = new DVLD.People.Controls.ctrlPersonCardWithFilter();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabcApplicationInfo = new System.Windows.Forms.TabPage();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox5 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox4 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.lblApplactionDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox3 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLocalApplactionID = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lable1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabLocalApplicationInfo.SuspendLayout();
            this.tabcPersonalInfo.SuspendLayout();
            this.tabcApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.Red;
            this.lblFormTitle.Location = new System.Drawing.Point(252, 27);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(616, 39);
            this.lblFormTitle.TabIndex = 18;
            this.lblFormTitle.Text = "New Local Driving License Applaction";
            // 
            // tabLocalApplicationInfo
            // 
            this.tabLocalApplicationInfo.Controls.Add(this.tabcPersonalInfo);
            this.tabLocalApplicationInfo.Controls.Add(this.tabcApplicationInfo);
            this.tabLocalApplicationInfo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tabLocalApplicationInfo.ItemSize = new System.Drawing.Size(100, 29);
            this.tabLocalApplicationInfo.Location = new System.Drawing.Point(12, 82);
            this.tabLocalApplicationInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLocalApplicationInfo.Name = "tabLocalApplicationInfo";
            this.tabLocalApplicationInfo.SelectedIndex = 0;
            this.tabLocalApplicationInfo.Size = new System.Drawing.Size(1132, 544);
            this.tabLocalApplicationInfo.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabLocalApplicationInfo.TabIndex = 19;
            // 
            // tabcPersonalInfo
            // 
            this.tabcPersonalInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tabcPersonalInfo.Controls.Add(this.btnNext);
            this.tabcPersonalInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tabcPersonalInfo.Location = new System.Drawing.Point(4, 33);
            this.tabcPersonalInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabcPersonalInfo.Name = "tabcPersonalInfo";
            this.tabcPersonalInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabcPersonalInfo.Size = new System.Drawing.Size(1124, 507);
            this.tabcPersonalInfo.TabIndex = 0;
            this.tabcPersonalInfo.Text = "Personal Info";
            this.tabcPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(13, 28);
            this.ctrlPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(1071, 410);
            this.ctrlPersonCardWithFilter1.TabIndex = 24;
            this.ctrlPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonCardWithFilter1_OnPersonSelected);
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 2;
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnNext.Image = global::DVLD.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnNext.Location = new System.Drawing.Point(927, 442);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(157, 42);
            this.btnNext.TabIndex = 23;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tabcApplicationInfo
            // 
            this.tabcApplicationInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabcApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.tabcApplicationInfo.Controls.Add(this.label7);
            this.tabcApplicationInfo.Controls.Add(this.guna2CirclePictureBox5);
            this.tabcApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.tabcApplicationInfo.Controls.Add(this.label6);
            this.tabcApplicationInfo.Controls.Add(this.guna2CirclePictureBox4);
            this.tabcApplicationInfo.Controls.Add(this.cbLicenseClasses);
            this.tabcApplicationInfo.Controls.Add(this.lblApplactionDate);
            this.tabcApplicationInfo.Controls.Add(this.label5);
            this.tabcApplicationInfo.Controls.Add(this.guna2CirclePictureBox3);
            this.tabcApplicationInfo.Controls.Add(this.guna2CirclePictureBox1);
            this.tabcApplicationInfo.Controls.Add(this.label3);
            this.tabcApplicationInfo.Controls.Add(this.lblLocalApplactionID);
            this.tabcApplicationInfo.Controls.Add(this.guna2CirclePictureBox2);
            this.tabcApplicationInfo.Controls.Add(this.lable1);
            this.tabcApplicationInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tabcApplicationInfo.Location = new System.Drawing.Point(4, 33);
            this.tabcApplicationInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabcApplicationInfo.Name = "tabcApplicationInfo";
            this.tabcApplicationInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabcApplicationInfo.Size = new System.Drawing.Size(1124, 507);
            this.tabcApplicationInfo.TabIndex = 1;
            this.tabcApplicationInfo.Text = "Application Info";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblCreatedBy.Location = new System.Drawing.Point(285, 271);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(35, 18);
            this.lblCreatedBy.TabIndex = 103;
            this.lblCreatedBy.Text = "???";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 19);
            this.label7.TabIndex = 102;
            this.label7.Text = "Created By:";
            // 
            // guna2CirclePictureBox5
            // 
            this.guna2CirclePictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox5.Image = global::DVLD.Properties.Resources.Number_32;
            this.guna2CirclePictureBox5.ImageRotate = 0F;
            this.guna2CirclePictureBox5.Location = new System.Drawing.Point(221, 256);
            this.guna2CirclePictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2CirclePictureBox5.Name = "guna2CirclePictureBox5";
            this.guna2CirclePictureBox5.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox5.Size = new System.Drawing.Size(42, 30);
            this.guna2CirclePictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox5.TabIndex = 101;
            this.guna2CirclePictureBox5.TabStop = false;
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblApplicationFees.Location = new System.Drawing.Point(285, 224);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(35, 18);
            this.lblApplicationFees.TabIndex = 100;
            this.lblApplicationFees.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 19);
            this.label6.TabIndex = 99;
            this.label6.Text = "Applaction Fees:";
            // 
            // guna2CirclePictureBox4
            // 
            this.guna2CirclePictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox4.Image = global::DVLD.Properties.Resources.Number_32;
            this.guna2CirclePictureBox4.ImageRotate = 0F;
            this.guna2CirclePictureBox4.Location = new System.Drawing.Point(221, 208);
            this.guna2CirclePictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2CirclePictureBox4.Name = "guna2CirclePictureBox4";
            this.guna2CirclePictureBox4.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox4.Size = new System.Drawing.Size(42, 30);
            this.guna2CirclePictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox4.TabIndex = 98;
            this.guna2CirclePictureBox4.TabStop = false;
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.Font = new System.Drawing.Font("Tahoma", 13F);
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Location = new System.Drawing.Point(288, 166);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(253, 29);
            this.cbLicenseClasses.TabIndex = 97;
            // 
            // lblApplactionDate
            // 
            this.lblApplactionDate.AutoSize = true;
            this.lblApplactionDate.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblApplactionDate.Location = new System.Drawing.Point(285, 119);
            this.lblApplactionDate.Name = "lblApplactionDate";
            this.lblApplactionDate.Size = new System.Drawing.Size(35, 18);
            this.lblApplactionDate.TabIndex = 96;
            this.lblApplactionDate.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 19);
            this.label5.TabIndex = 95;
            this.label5.Text = "Applaction Date:";
            // 
            // guna2CirclePictureBox3
            // 
            this.guna2CirclePictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox3.Image = global::DVLD.Properties.Resources.Number_32;
            this.guna2CirclePictureBox3.ImageRotate = 0F;
            this.guna2CirclePictureBox3.Location = new System.Drawing.Point(221, 160);
            this.guna2CirclePictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2CirclePictureBox3.Name = "guna2CirclePictureBox3";
            this.guna2CirclePictureBox3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox3.Size = new System.Drawing.Size(42, 30);
            this.guna2CirclePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox3.TabIndex = 91;
            this.guna2CirclePictureBox3.TabStop = false;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = global::DVLD.Properties.Resources.Person_321;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(221, 64);
            this.guna2CirclePictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(42, 30);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 86;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 19);
            this.label3.TabIndex = 85;
            this.label3.Text = "License Class:";
            // 
            // lblLocalApplactionID
            // 
            this.lblLocalApplactionID.AutoSize = true;
            this.lblLocalApplactionID.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblLocalApplactionID.Location = new System.Drawing.Point(285, 72);
            this.lblLocalApplactionID.Name = "lblLocalApplactionID";
            this.lblLocalApplactionID.Size = new System.Drawing.Size(35, 18);
            this.lblLocalApplactionID.TabIndex = 84;
            this.lblLocalApplactionID.Text = "???";
            // 
            // guna2CirclePictureBox2
            // 
            this.guna2CirclePictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox2.Image = global::DVLD.Properties.Resources.Number_32;
            this.guna2CirclePictureBox2.ImageRotate = 0F;
            this.guna2CirclePictureBox2.Location = new System.Drawing.Point(221, 112);
            this.guna2CirclePictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2CirclePictureBox2.Name = "guna2CirclePictureBox2";
            this.guna2CirclePictureBox2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox2.Size = new System.Drawing.Size(42, 30);
            this.guna2CirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox2.TabIndex = 83;
            this.guna2CirclePictureBox2.TabStop = false;
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(60, 64);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(157, 19);
            this.lable1.TabIndex = 0;
            this.lable1.Text = "D.L Applaction ID:";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_321;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSave.Location = new System.Drawing.Point(943, 639);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(157, 42);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnClose.Location = new System.Drawing.Point(768, 639);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(157, 42);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddUpdateLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 692);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabLocalApplicationInfo);
            this.Controls.Add(this.lblFormTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAddUpdateLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Local Driving License Applaction";
            this.Activated += new System.EventHandler(this.frmAddUpdateLocalDrivingLicenseApplication_Activated);
            this.Load += new System.EventHandler(this.frmNewLocalDrivingLicenseApplaction_Load);
            this.tabLocalApplicationInfo.ResumeLayout(false);
            this.tabcPersonalInfo.ResumeLayout(false);
            this.tabcApplicationInfo.ResumeLayout(false);
            this.tabcApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.TabControl tabLocalApplicationInfo;
        private System.Windows.Forms.TabPage tabcPersonalInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage tabcApplicationInfo;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox3;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLocalApplactionID;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox2;
        private System.Windows.Forms.Label lable1;
        private People.Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox5;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox4;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.Label lblApplactionDate;
        private System.Windows.Forms.Label label5;
    }
}