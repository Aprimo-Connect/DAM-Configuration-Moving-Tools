namespace Aprimo.SecurityExporter
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbExportClsPermissions = new System.Windows.Forms.CheckBox();
            this.cbExportDAMPermissions = new System.Windows.Forms.CheckBox();
            this.cbExportUserGroups = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtClassificationFilter = new System.Windows.Forms.TextBox();
            this.txtPathToXlsx = new System.Windows.Forms.TextBox();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.txtUserToken = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtSubDomain = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbExportClsPermissions);
            this.groupBox2.Controls.Add(this.cbExportDAMPermissions);
            this.groupBox2.Controls.Add(this.cbExportUserGroups);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.txtClassificationFilter);
            this.groupBox2.Controls.Add(this.txtPathToXlsx);
            this.groupBox2.Controls.Add(this.txtClientId);
            this.groupBox2.Controls.Add(this.txtUserToken);
            this.groupBox2.Controls.Add(this.txtUserName);
            this.groupBox2.Controls.Add(this.txtSubDomain);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(18, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1140, 371);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection Details";
            // 
            // cbExportClsPermissions
            // 
            this.cbExportClsPermissions.AutoSize = true;
            this.cbExportClsPermissions.Location = new System.Drawing.Point(341, 280);
            this.cbExportClsPermissions.Name = "cbExportClsPermissions";
            this.cbExportClsPermissions.Size = new System.Drawing.Size(267, 24);
            this.cbExportClsPermissions.TabIndex = 18;
            this.cbExportClsPermissions.Text = "Export Classification Permissions";
            this.cbExportClsPermissions.UseVisualStyleBackColor = true;
            // 
            // cbExportDAMPermissions
            // 
            this.cbExportDAMPermissions.AutoSize = true;
            this.cbExportDAMPermissions.Location = new System.Drawing.Point(614, 279);
            this.cbExportDAMPermissions.Name = "cbExportDAMPermissions";
            this.cbExportDAMPermissions.Size = new System.Drawing.Size(288, 24);
            this.cbExportDAMPermissions.TabIndex = 17;
            this.cbExportDAMPermissions.Text = "Export DAM Functional Permissions";
            this.cbExportDAMPermissions.UseVisualStyleBackColor = true;
            // 
            // cbExportUserGroups
            // 
            this.cbExportUserGroups.AutoSize = true;
            this.cbExportUserGroups.Location = new System.Drawing.Point(159, 280);
            this.cbExportUserGroups.Name = "cbExportUserGroups";
            this.cbExportUserGroups.Size = new System.Drawing.Size(176, 24);
            this.cbExportUserGroups.TabIndex = 16;
            this.cbExportUserGroups.Text = "Export User Groups";
            this.cbExportUserGroups.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 280);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "What to export:";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1017, 323);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(112, 35);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtClassificationFilter
            // 
            this.txtClassificationFilter.Location = new System.Drawing.Point(159, 228);
            this.txtClassificationFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtClassificationFilter.Name = "txtClassificationFilter";
            this.txtClassificationFilter.Size = new System.Drawing.Size(970, 26);
            this.txtClassificationFilter.TabIndex = 11;
            // 
            // txtPathToXlsx
            // 
            this.txtPathToXlsx.Location = new System.Drawing.Point(159, 188);
            this.txtPathToXlsx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPathToXlsx.Name = "txtPathToXlsx";
            this.txtPathToXlsx.Size = new System.Drawing.Size(970, 26);
            this.txtPathToXlsx.TabIndex = 10;
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(159, 148);
            this.txtClientId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(970, 26);
            this.txtClientId.TabIndex = 9;
            // 
            // txtUserToken
            // 
            this.txtUserToken.Location = new System.Drawing.Point(159, 108);
            this.txtUserToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserToken.Name = "txtUserToken";
            this.txtUserToken.Size = new System.Drawing.Size(970, 26);
            this.txtUserToken.TabIndex = 8;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(159, 69);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(970, 26);
            this.txtUserName.TabIndex = 7;
            // 
            // txtSubDomain
            // 
            this.txtSubDomain.Location = new System.Drawing.Point(159, 29);
            this.txtSubDomain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubDomain.Name = "txtSubDomain";
            this.txtSubDomain.Size = new System.Drawing.Size(970, 26);
            this.txtSubDomain.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 232);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(141, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "Classification Filter";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 192);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Path to XLSX";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 152);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Client ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 112);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "User Token";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(68, 74);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "Username";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(52, 34);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Registration";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(22, 399);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1136, 35);
            this.progressBar1.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(20, 444);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1136, 398);
            this.txtLog.TabIndex = 2;
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.Location = new System.Drawing.Point(989, 866);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(158, 33);
            this.btnSaveLog.TabIndex = 3;
            this.btnSaveLog.Text = "Save Log To File";
            this.btnSaveLog.UseVisualStyleBackColor = true;
            this.btnSaveLog.Click += new System.EventHandler(this.BtnSaveLog_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 932);
            this.Controls.Add(this.btnSaveLog);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DAM Security Exporter Tool";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtClassificationFilter;
        private System.Windows.Forms.TextBox txtPathToXlsx;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.TextBox txtUserToken;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtSubDomain;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbExportUserGroups;
        private System.Windows.Forms.CheckBox cbExportClsPermissions;
        private System.Windows.Forms.CheckBox cbExportDAMPermissions;
        private System.Windows.Forms.Button btnSaveLog;
    }
}

