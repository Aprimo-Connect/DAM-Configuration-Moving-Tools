namespace Aprimo.SecurityImporter
{
    partial class Main
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.cbImportFuncPermissions = new System.Windows.Forms.CheckBox();
            this.cbImportClsPermissions = new System.Windows.Forms.CheckBox();
            this.cbImportUserGroups = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPathToXlsx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbClientID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUserToken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRegistration = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.cbImportFuncPermissions);
            this.groupBox1.Controls.Add(this.cbImportClsPermissions);
            this.groupBox1.Controls.Add(this.cbImportUserGroups);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbPathToXlsx);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbClientID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbUserToken);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbUsername);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbRegistration);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1144, 396);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import Details";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(989, 340);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(122, 40);
            this.btnImport.TabIndex = 15;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // cbImportFuncPermissions
            // 
            this.cbImportFuncPermissions.AutoSize = true;
            this.cbImportFuncPermissions.Location = new System.Drawing.Point(605, 299);
            this.cbImportFuncPermissions.Name = "cbImportFuncPermissions";
            this.cbImportFuncPermissions.Size = new System.Drawing.Size(288, 24);
            this.cbImportFuncPermissions.TabIndex = 13;
            this.cbImportFuncPermissions.Text = "Import DAM Functional Permissions";
            this.cbImportFuncPermissions.UseVisualStyleBackColor = true;
            // 
            // cbImportClsPermissions
            // 
            this.cbImportClsPermissions.AutoSize = true;
            this.cbImportClsPermissions.Location = new System.Drawing.Point(332, 299);
            this.cbImportClsPermissions.Name = "cbImportClsPermissions";
            this.cbImportClsPermissions.Size = new System.Drawing.Size(267, 24);
            this.cbImportClsPermissions.TabIndex = 12;
            this.cbImportClsPermissions.Text = "Import Classification Permissions";
            this.cbImportClsPermissions.UseVisualStyleBackColor = true;
            // 
            // cbImportUserGroups
            // 
            this.cbImportUserGroups.AutoSize = true;
            this.cbImportUserGroups.Location = new System.Drawing.Point(150, 299);
            this.cbImportUserGroups.Name = "cbImportUserGroups";
            this.cbImportUserGroups.Size = new System.Drawing.Size(176, 24);
            this.cbImportUserGroups.TabIndex = 11;
            this.cbImportUserGroups.Text = "Import User Groups";
            this.cbImportUserGroups.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "What to import:";
            // 
            // tbPathToXlsx
            // 
            this.tbPathToXlsx.Location = new System.Drawing.Point(150, 225);
            this.tbPathToXlsx.Name = "tbPathToXlsx";
            this.tbPathToXlsx.Size = new System.Drawing.Size(961, 26);
            this.tbPathToXlsx.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Path to XLSX";
            // 
            // tbClientID
            // 
            this.tbClientID.Location = new System.Drawing.Point(150, 181);
            this.tbClientID.Name = "tbClientID";
            this.tbClientID.Size = new System.Drawing.Size(961, 26);
            this.tbClientID.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Client ID";
            // 
            // tbUserToken
            // 
            this.tbUserToken.Location = new System.Drawing.Point(150, 133);
            this.tbUserToken.Name = "tbUserToken";
            this.tbUserToken.Size = new System.Drawing.Size(961, 26);
            this.tbUserToken.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "User Token";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(150, 88);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(961, 26);
            this.tbUsername.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // tbRegistration
            // 
            this.tbRegistration.Location = new System.Drawing.Point(150, 41);
            this.tbRegistration.Name = "tbRegistration";
            this.tbRegistration.Size = new System.Drawing.Size(961, 26);
            this.tbRegistration.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registration";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 430);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1144, 39);
            this.progressBar1.TabIndex = 1;
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(12, 491);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(1144, 401);
            this.tbLog.TabIndex = 2;
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.Location = new System.Drawing.Point(933, 916);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(190, 37);
            this.btnSaveLog.TabIndex = 3;
            this.btnSaveLog.Text = "Save Log To File";
            this.btnSaveLog.UseVisualStyleBackColor = true;
            this.btnSaveLog.Click += new System.EventHandler(this.BtnSaveLog_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 980);
            this.Controls.Add(this.btnSaveLog);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "DAM Security Importer Tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUserToken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRegistration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbClientID;
        private System.Windows.Forms.CheckBox cbImportFuncPermissions;
        private System.Windows.Forms.CheckBox cbImportClsPermissions;
        private System.Windows.Forms.CheckBox cbImportUserGroups;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPathToXlsx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSaveLog;
    }
}

