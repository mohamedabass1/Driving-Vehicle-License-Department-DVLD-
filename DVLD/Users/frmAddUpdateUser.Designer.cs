namespace DVLD.Users
{
    partial class frmAddUpdateUser
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
            this.tabUserInfo = new System.Windows.Forms.TabControl();
            this.tabcPersonalInfo = new System.Windows.Forms.TabPage();
            this.ctrlPersonCardWithFilter1 = new DVLD.People.Controls.ctrlPersonCardWithFilter();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabcLoginInfo = new System.Windows.Forms.TabPage();
            this.chbIsActive = new System.Windows.Forms.CheckBox();
            this.txtConfermPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox3 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lable1 = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabUserInfo.SuspendLayout();
            this.tabcPersonalInfo.SuspendLayout();
            this.tabcLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabUserInfo
            // 
            this.tabUserInfo.Controls.Add(this.tabcPersonalInfo);
            this.tabUserInfo.Controls.Add(this.tabcLoginInfo);
            this.tabUserInfo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tabUserInfo.ItemSize = new System.Drawing.Size(100, 29);
            this.tabUserInfo.Location = new System.Drawing.Point(12, 73);
            this.tabUserInfo.Name = "tabUserInfo";
            this.tabUserInfo.SelectedIndex = 0;
            this.tabUserInfo.Size = new System.Drawing.Size(1304, 642);
            this.tabUserInfo.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabUserInfo.TabIndex = 18;
            // 
            // tabcPersonalInfo
            // 
            this.tabcPersonalInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tabcPersonalInfo.Controls.Add(this.btnNext);
            this.tabcPersonalInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tabcPersonalInfo.Location = new System.Drawing.Point(4, 33);
            this.tabcPersonalInfo.Name = "tabcPersonalInfo";
            this.tabcPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabcPersonalInfo.Size = new System.Drawing.Size(1296, 605);
            this.tabcPersonalInfo.TabIndex = 0;
            this.tabcPersonalInfo.Text = "Personal Info";
            this.tabcPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(23, 20);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = false;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(1249, 504);
            this.ctrlPersonCardWithFilter1.TabIndex = 24;
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 2;
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnNext.Image = global::DVLD.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnNext.Location = new System.Drawing.Point(1082, 544);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(183, 52);
            this.btnNext.TabIndex = 23;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tabcLoginInfo
            // 
            this.tabcLoginInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabcLoginInfo.Controls.Add(this.chbIsActive);
            this.tabcLoginInfo.Controls.Add(this.txtConfermPassword);
            this.tabcLoginInfo.Controls.Add(this.label4);
            this.tabcLoginInfo.Controls.Add(this.guna2CirclePictureBox3);
            this.tabcLoginInfo.Controls.Add(this.txtPassword);
            this.tabcLoginInfo.Controls.Add(this.label2);
            this.tabcLoginInfo.Controls.Add(this.txtUserName);
            this.tabcLoginInfo.Controls.Add(this.guna2CirclePictureBox1);
            this.tabcLoginInfo.Controls.Add(this.label3);
            this.tabcLoginInfo.Controls.Add(this.lblUserID);
            this.tabcLoginInfo.Controls.Add(this.guna2CirclePictureBox2);
            this.tabcLoginInfo.Controls.Add(this.lable1);
            this.tabcLoginInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tabcLoginInfo.Location = new System.Drawing.Point(4, 33);
            this.tabcLoginInfo.Name = "tabcLoginInfo";
            this.tabcLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabcLoginInfo.Size = new System.Drawing.Size(1296, 605);
            this.tabcLoginInfo.TabIndex = 1;
            this.tabcLoginInfo.Text = "Login Info";
            // 
            // chbIsActive
            // 
            this.chbIsActive.AutoSize = true;
            this.chbIsActive.Checked = true;
            this.chbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIsActive.Location = new System.Drawing.Point(328, 323);
            this.chbIsActive.Name = "chbIsActive";
            this.chbIsActive.Size = new System.Drawing.Size(118, 28);
            this.chbIsActive.TabIndex = 94;
            this.chbIsActive.Text = "Is Active";
            this.chbIsActive.UseVisualStyleBackColor = true;
            // 
            // txtConfermPassword
            // 
            this.txtConfermPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtConfermPassword.Location = new System.Drawing.Point(328, 259);
            this.txtConfermPassword.Name = "txtConfermPassword";
            this.txtConfermPassword.Size = new System.Drawing.Size(227, 31);
            this.txtConfermPassword.TabIndex = 93;
            this.txtConfermPassword.UseSystemPasswordChar = true;
            this.txtConfermPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfermPassword_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 24);
            this.label4.TabIndex = 92;
            this.label4.Text = "Confirm Password:";
            // 
            // guna2CirclePictureBox3
            // 
            this.guna2CirclePictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox3.Image = global::DVLD.Properties.Resources.Number_32;
            this.guna2CirclePictureBox3.ImageRotate = 0F;
            this.guna2CirclePictureBox3.Location = new System.Drawing.Point(266, 256);
            this.guna2CirclePictureBox3.Name = "guna2CirclePictureBox3";
            this.guna2CirclePictureBox3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox3.Size = new System.Drawing.Size(49, 37);
            this.guna2CirclePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox3.TabIndex = 91;
            this.guna2CirclePictureBox3.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPassword.Location = new System.Drawing.Point(328, 208);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(227, 31);
            this.txtPassword.TabIndex = 90;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 24);
            this.label2.TabIndex = 88;
            this.label2.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUserName.Location = new System.Drawing.Point(328, 153);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(227, 31);
            this.txtUserName.TabIndex = 87;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = global::DVLD.Properties.Resources.Person_321;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(266, 150);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(49, 37);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 86;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 24);
            this.label3.TabIndex = 85;
            this.label3.Text = "UserName:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblUserID.Location = new System.Drawing.Point(324, 92);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(40, 22);
            this.lblUserID.TabIndex = 84;
            this.lblUserID.Text = "???";
            // 
            // guna2CirclePictureBox2
            // 
            this.guna2CirclePictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox2.Image = global::DVLD.Properties.Resources.Number_32;
            this.guna2CirclePictureBox2.ImageRotate = 0F;
            this.guna2CirclePictureBox2.Location = new System.Drawing.Point(266, 205);
            this.guna2CirclePictureBox2.Name = "guna2CirclePictureBox2";
            this.guna2CirclePictureBox2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox2.Size = new System.Drawing.Size(49, 37);
            this.guna2CirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox2.TabIndex = 83;
            this.guna2CirclePictureBox2.TabStop = false;
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(135, 92);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(94, 24);
            this.lable1.TabIndex = 0;
            this.lable1.Text = "User ID:";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.Red;
            this.lblFormTitle.Location = new System.Drawing.Point(503, 22);
            this.lblFormTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(296, 47);
            this.lblFormTitle.TabIndex = 17;
            this.lblFormTitle.Text = "Add New User";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_321;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSave.Location = new System.Drawing.Point(1105, 724);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(183, 52);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnClose.Location = new System.Drawing.Point(901, 724);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(183, 52);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1323, 797);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabUserInfo);
            this.Controls.Add(this.lblFormTitle);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "frmAddUpdateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit User";
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            this.tabUserInfo.ResumeLayout(false);
            this.tabcPersonalInfo.ResumeLayout(false);
            this.tabcLoginInfo.ResumeLayout(false);
            this.tabcLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabUserInfo;
        private System.Windows.Forms.TabPage tabcPersonalInfo;
        private System.Windows.Forms.TabPage tabcLoginInfo;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lable1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserID;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox2;
        private System.Windows.Forms.TextBox txtConfermPassword;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.CheckBox chbIsActive;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private People.Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
    }
}