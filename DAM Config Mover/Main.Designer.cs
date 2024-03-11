namespace Aprimo.DAM.ConfigurationMover
{
    public partial class Main
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
            this.tbClassificationFilter = new System.Windows.Forms.TextBox();
            this.cbExportFieldDefinitions = new System.Windows.Forms.CheckBox();
            this.cbExportFieldGroups = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.gbExportDetails = new System.Windows.Forms.GroupBox();
            this.tbSettingDefinitionsFilter = new System.Windows.Forms.TextBox();
            this.cbExportSettingDefinitions = new System.Windows.Forms.CheckBox();
            this.tbSettingCategoriesFilter = new System.Windows.Forms.TextBox();
            this.cbExportSettingCategories = new System.Windows.Forms.CheckBox();
            this.btnSaveConnectionDetailsExport = new System.Windows.Forms.Button();
            this.btnGetConnectionDetailsExport = new System.Windows.Forms.Button();
            this.gbConnectionDetails = new System.Windows.Forms.GroupBox();
            this.tbClientIDSource = new System.Windows.Forms.TextBox();
            this.tbUserTokenSource = new System.Windows.Forms.TextBox();
            this.tbUsernameSource = new System.Windows.Forms.TextBox();
            this.tbRegistrationSource = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbRuleFilter = new System.Windows.Forms.TextBox();
            this.cbExportRules = new System.Windows.Forms.CheckBox();
            this.btnSelectSettings = new System.Windows.Forms.Button();
            this.tbFileTyepsFilter = new System.Windows.Forms.TextBox();
            this.cbExportFileTypes = new System.Windows.Forms.CheckBox();
            this.tbFieldGroupsFilter = new System.Windows.Forms.TextBox();
            this.cbExportSettings = new System.Windows.Forms.CheckBox();
            this.txtExportDirPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbFieldDefinitionsFilter = new System.Windows.Forms.TextBox();
            this.cbExportClassifications = new System.Windows.Forms.CheckBox();
            this.btnSaveConnectionDetailsImport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbImportSettingDefinitions = new System.Windows.Forms.CheckBox();
            this.cbImportSettingCategories = new System.Windows.Forms.CheckBox();
            this.btnGetConnectionDetailsImport = new System.Windows.Forms.Button();
            this.cbImportRules = new System.Windows.Forms.CheckBox();
            this.cbImportFileTypes = new System.Windows.Forms.CheckBox();
            this.cbImportClsFieldValues = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbClientIDDestination = new System.Windows.Forms.TextBox();
            this.tbUserTokenDestination = new System.Windows.Forms.TextBox();
            this.tbUsernameDestination = new System.Windows.Forms.TextBox();
            this.tbRegistrationDestination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbImportSettings = new System.Windows.Forms.CheckBox();
            this.tbImportDirPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbImportClassifications = new System.Windows.Forms.CheckBox();
            this.cbImportFieldDefinitions = new System.Windows.Forms.CheckBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.cbImportFieldGroups = new System.Windows.Forms.CheckBox();
            this.gbExportDetails.SuspendLayout();
            this.gbConnectionDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbClassificationFilter
            // 
            this.tbClassificationFilter.Location = new System.Drawing.Point(247, 347);
            this.tbClassificationFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbClassificationFilter.Name = "tbClassificationFilter";
            this.tbClassificationFilter.Size = new System.Drawing.Size(792, 26);
            this.tbClassificationFilter.TabIndex = 11;
            // 
            // cbExportFieldDefinitions
            // 
            this.cbExportFieldDefinitions.AutoSize = true;
            this.cbExportFieldDefinitions.Location = new System.Drawing.Point(2, 319);
            this.cbExportFieldDefinitions.Name = "cbExportFieldDefinitions";
            this.cbExportFieldDefinitions.Size = new System.Drawing.Size(198, 24);
            this.cbExportFieldDefinitions.TabIndex = 18;
            this.cbExportFieldDefinitions.Text = "Export Field Definitions";
            this.cbExportFieldDefinitions.UseVisualStyleBackColor = true;
            // 
            // cbExportFieldGroups
            // 
            this.cbExportFieldGroups.AutoSize = true;
            this.cbExportFieldGroups.Location = new System.Drawing.Point(2, 289);
            this.cbExportFieldGroups.Name = "cbExportFieldGroups";
            this.cbExportFieldGroups.Size = new System.Drawing.Size(176, 24);
            this.cbExportFieldGroups.TabIndex = 16;
            this.cbExportFieldGroups.Text = "Export Field Groups";
            this.cbExportFieldGroups.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(927, 579);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(112, 35);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1101, 18);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(791, 35);
            this.progressBar1.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(1101, 63);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(791, 1146);
            this.txtLog.TabIndex = 2;
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.Location = new System.Drawing.Point(1735, 1228);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(158, 33);
            this.btnSaveLog.TabIndex = 3;
            this.btnSaveLog.Text = "Save Log To File";
            this.btnSaveLog.UseVisualStyleBackColor = true;
            this.btnSaveLog.Click += new System.EventHandler(this.BtnSaveLog_Click);
            // 
            // gbExportDetails
            // 
            this.gbExportDetails.Controls.Add(this.tbSettingDefinitionsFilter);
            this.gbExportDetails.Controls.Add(this.cbExportSettingDefinitions);
            this.gbExportDetails.Controls.Add(this.tbSettingCategoriesFilter);
            this.gbExportDetails.Controls.Add(this.cbExportSettingCategories);
            this.gbExportDetails.Controls.Add(this.btnSaveConnectionDetailsExport);
            this.gbExportDetails.Controls.Add(this.btnGetConnectionDetailsExport);
            this.gbExportDetails.Controls.Add(this.gbConnectionDetails);
            this.gbExportDetails.Controls.Add(this.tbRuleFilter);
            this.gbExportDetails.Controls.Add(this.cbExportRules);
            this.gbExportDetails.Controls.Add(this.btnSelectSettings);
            this.gbExportDetails.Controls.Add(this.tbFileTyepsFilter);
            this.gbExportDetails.Controls.Add(this.cbExportFileTypes);
            this.gbExportDetails.Controls.Add(this.tbFieldGroupsFilter);
            this.gbExportDetails.Controls.Add(this.cbExportSettings);
            this.gbExportDetails.Controls.Add(this.txtExportDirPath);
            this.gbExportDetails.Controls.Add(this.label7);
            this.gbExportDetails.Controls.Add(this.tbFieldDefinitionsFilter);
            this.gbExportDetails.Controls.Add(this.tbClassificationFilter);
            this.gbExportDetails.Controls.Add(this.cbExportClassifications);
            this.gbExportDetails.Controls.Add(this.cbExportFieldDefinitions);
            this.gbExportDetails.Controls.Add(this.btnExport);
            this.gbExportDetails.Controls.Add(this.cbExportFieldGroups);
            this.gbExportDetails.Location = new System.Drawing.Point(19, 18);
            this.gbExportDetails.Name = "gbExportDetails";
            this.gbExportDetails.Size = new System.Drawing.Size(1059, 622);
            this.gbExportDetails.TabIndex = 4;
            this.gbExportDetails.TabStop = false;
            this.gbExportDetails.Tag = "200";
            this.gbExportDetails.Text = "Export details";
            // 
            // tbSettingDefinitionsFilter
            // 
            this.tbSettingDefinitionsFilter.Location = new System.Drawing.Point(246, 469);
            this.tbSettingDefinitionsFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSettingDefinitionsFilter.Name = "tbSettingDefinitionsFilter";
            this.tbSettingDefinitionsFilter.Size = new System.Drawing.Size(792, 26);
            this.tbSettingDefinitionsFilter.TabIndex = 43;
            // 
            // cbExportSettingDefinitions
            // 
            this.cbExportSettingDefinitions.AutoSize = true;
            this.cbExportSettingDefinitions.Location = new System.Drawing.Point(2, 469);
            this.cbExportSettingDefinitions.Name = "cbExportSettingDefinitions";
            this.cbExportSettingDefinitions.Size = new System.Drawing.Size(215, 24);
            this.cbExportSettingDefinitions.TabIndex = 44;
            this.cbExportSettingDefinitions.Text = "Export Setting Definitions";
            this.cbExportSettingDefinitions.UseVisualStyleBackColor = true;
            // 
            // tbSettingCategoriesFilter
            // 
            this.tbSettingCategoriesFilter.Location = new System.Drawing.Point(246, 439);
            this.tbSettingCategoriesFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSettingCategoriesFilter.Name = "tbSettingCategoriesFilter";
            this.tbSettingCategoriesFilter.Size = new System.Drawing.Size(792, 26);
            this.tbSettingCategoriesFilter.TabIndex = 41;
            // 
            // cbExportSettingCategories
            // 
            this.cbExportSettingCategories.AutoSize = true;
            this.cbExportSettingCategories.Location = new System.Drawing.Point(3, 439);
            this.cbExportSettingCategories.Name = "cbExportSettingCategories";
            this.cbExportSettingCategories.Size = new System.Drawing.Size(217, 24);
            this.cbExportSettingCategories.TabIndex = 42;
            this.cbExportSettingCategories.Text = "Export Setting Categories";
            this.cbExportSettingCategories.UseVisualStyleBackColor = true;
            // 
            // btnSaveConnectionDetailsExport
            // 
            this.btnSaveConnectionDetailsExport.Location = new System.Drawing.Point(792, 66);
            this.btnSaveConnectionDetailsExport.Name = "btnSaveConnectionDetailsExport";
            this.btnSaveConnectionDetailsExport.Size = new System.Drawing.Size(247, 34);
            this.btnSaveConnectionDetailsExport.TabIndex = 40;
            this.btnSaveConnectionDetailsExport.Text = "Save connection details";
            this.btnSaveConnectionDetailsExport.UseVisualStyleBackColor = true;
            this.btnSaveConnectionDetailsExport.Click += new System.EventHandler(this.BtnSaveConnectionDetailsExport_Click);
            // 
            // btnGetConnectionDetailsExport
            // 
            this.btnGetConnectionDetailsExport.Location = new System.Drawing.Point(793, 106);
            this.btnGetConnectionDetailsExport.Name = "btnGetConnectionDetailsExport";
            this.btnGetConnectionDetailsExport.Size = new System.Drawing.Size(247, 35);
            this.btnGetConnectionDetailsExport.TabIndex = 39;
            this.btnGetConnectionDetailsExport.Text = "Use saved connection details...";
            this.btnGetConnectionDetailsExport.UseVisualStyleBackColor = true;
            this.btnGetConnectionDetailsExport.Click += new System.EventHandler(this.BtnGetConnectionDetailsExport_Click);
            // 
            // gbConnectionDetails
            // 
            this.gbConnectionDetails.Controls.Add(this.tbClientIDSource);
            this.gbConnectionDetails.Controls.Add(this.tbUserTokenSource);
            this.gbConnectionDetails.Controls.Add(this.tbUsernameSource);
            this.gbConnectionDetails.Controls.Add(this.tbRegistrationSource);
            this.gbConnectionDetails.Controls.Add(this.label8);
            this.gbConnectionDetails.Controls.Add(this.label9);
            this.gbConnectionDetails.Controls.Add(this.label10);
            this.gbConnectionDetails.Controls.Add(this.label11);
            this.gbConnectionDetails.Location = new System.Drawing.Point(24, 45);
            this.gbConnectionDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbConnectionDetails.Name = "gbConnectionDetails";
            this.gbConnectionDetails.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbConnectionDetails.Size = new System.Drawing.Size(745, 200);
            this.gbConnectionDetails.TabIndex = 36;
            this.gbConnectionDetails.TabStop = false;
            this.gbConnectionDetails.Tag = "150";
            this.gbConnectionDetails.Text = "Connection Details For Export Environment";
            // 
            // tbClientIDSource
            // 
            this.tbClientIDSource.Location = new System.Drawing.Point(159, 159);
            this.tbClientIDSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbClientIDSource.Name = "tbClientIDSource";
            this.tbClientIDSource.Size = new System.Drawing.Size(571, 26);
            this.tbClientIDSource.TabIndex = 9;
            // 
            // tbUserTokenSource
            // 
            this.tbUserTokenSource.Location = new System.Drawing.Point(159, 119);
            this.tbUserTokenSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUserTokenSource.Name = "tbUserTokenSource";
            this.tbUserTokenSource.Size = new System.Drawing.Size(571, 26);
            this.tbUserTokenSource.TabIndex = 8;
            // 
            // tbUsernameSource
            // 
            this.tbUsernameSource.Location = new System.Drawing.Point(159, 80);
            this.tbUsernameSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUsernameSource.Name = "tbUsernameSource";
            this.tbUsernameSource.Size = new System.Drawing.Size(571, 26);
            this.tbUsernameSource.TabIndex = 7;
            // 
            // tbRegistrationSource
            // 
            this.tbRegistrationSource.Location = new System.Drawing.Point(159, 40);
            this.tbRegistrationSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbRegistrationSource.Name = "tbRegistrationSource";
            this.tbRegistrationSource.Size = new System.Drawing.Size(571, 26);
            this.tbRegistrationSource.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 163);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Client ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 123);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "User Token";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(68, 85);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "Username";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(52, 45);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Registration";
            // 
            // tbRuleFilter
            // 
            this.tbRuleFilter.Location = new System.Drawing.Point(247, 407);
            this.tbRuleFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbRuleFilter.Name = "tbRuleFilter";
            this.tbRuleFilter.Size = new System.Drawing.Size(792, 26);
            this.tbRuleFilter.TabIndex = 31;
            // 
            // cbExportRules
            // 
            this.cbExportRules.AutoSize = true;
            this.cbExportRules.Location = new System.Drawing.Point(3, 409);
            this.cbExportRules.Name = "cbExportRules";
            this.cbExportRules.Size = new System.Drawing.Size(126, 24);
            this.cbExportRules.TabIndex = 32;
            this.cbExportRules.Text = "Export Rules";
            this.cbExportRules.UseVisualStyleBackColor = true;
            // 
            // btnSelectSettings
            // 
            this.btnSelectSettings.Location = new System.Drawing.Point(246, 501);
            this.btnSelectSettings.Name = "btnSelectSettings";
            this.btnSelectSettings.Size = new System.Drawing.Size(232, 29);
            this.btnSelectSettings.TabIndex = 30;
            this.btnSelectSettings.Text = "Select settings...";
            this.btnSelectSettings.UseVisualStyleBackColor = true;
            this.btnSelectSettings.Click += new System.EventHandler(this.BtnSelectSettings_Click);
            // 
            // tbFileTyepsFilter
            // 
            this.tbFileTyepsFilter.Location = new System.Drawing.Point(247, 377);
            this.tbFileTyepsFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFileTyepsFilter.Name = "tbFileTyepsFilter";
            this.tbFileTyepsFilter.Size = new System.Drawing.Size(792, 26);
            this.tbFileTyepsFilter.TabIndex = 28;
            // 
            // cbExportFileTypes
            // 
            this.cbExportFileTypes.AutoSize = true;
            this.cbExportFileTypes.Location = new System.Drawing.Point(2, 379);
            this.cbExportFileTypes.Name = "cbExportFileTypes";
            this.cbExportFileTypes.Size = new System.Drawing.Size(156, 24);
            this.cbExportFileTypes.TabIndex = 29;
            this.cbExportFileTypes.Text = "Export File Types";
            this.cbExportFileTypes.UseVisualStyleBackColor = true;
            // 
            // tbFieldGroupsFilter
            // 
            this.tbFieldGroupsFilter.Location = new System.Drawing.Point(247, 289);
            this.tbFieldGroupsFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFieldGroupsFilter.Name = "tbFieldGroupsFilter";
            this.tbFieldGroupsFilter.Size = new System.Drawing.Size(792, 26);
            this.tbFieldGroupsFilter.TabIndex = 22;
            // 
            // cbExportSettings
            // 
            this.cbExportSettings.AutoSize = true;
            this.cbExportSettings.Location = new System.Drawing.Point(3, 501);
            this.cbExportSettings.Name = "cbExportSettings";
            this.cbExportSettings.Size = new System.Drawing.Size(144, 24);
            this.cbExportSettings.TabIndex = 27;
            this.cbExportSettings.Text = "Export Settings";
            this.cbExportSettings.UseVisualStyleBackColor = true;
            // 
            // txtExportDirPath
            // 
            this.txtExportDirPath.Location = new System.Drawing.Point(161, 255);
            this.txtExportDirPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExportDirPath.Name = "txtExportDirPath";
            this.txtExportDirPath.Size = new System.Drawing.Size(878, 26);
            this.txtExportDirPath.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-2, 258);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "Export directory path";
            // 
            // tbFieldDefinitionsFilter
            // 
            this.tbFieldDefinitionsFilter.Location = new System.Drawing.Point(247, 317);
            this.tbFieldDefinitionsFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFieldDefinitionsFilter.Name = "tbFieldDefinitionsFilter";
            this.tbFieldDefinitionsFilter.Size = new System.Drawing.Size(792, 26);
            this.tbFieldDefinitionsFilter.TabIndex = 21;
            // 
            // cbExportClassifications
            // 
            this.cbExportClassifications.AutoSize = true;
            this.cbExportClassifications.Location = new System.Drawing.Point(2, 349);
            this.cbExportClassifications.Name = "cbExportClassifications";
            this.cbExportClassifications.Size = new System.Drawing.Size(186, 24);
            this.cbExportClassifications.TabIndex = 19;
            this.cbExportClassifications.Text = "Export Classifications";
            this.cbExportClassifications.UseVisualStyleBackColor = true;
            // 
            // btnSaveConnectionDetailsImport
            // 
            this.btnSaveConnectionDetailsImport.Location = new System.Drawing.Point(776, 56);
            this.btnSaveConnectionDetailsImport.Name = "btnSaveConnectionDetailsImport";
            this.btnSaveConnectionDetailsImport.Size = new System.Drawing.Size(263, 35);
            this.btnSaveConnectionDetailsImport.TabIndex = 33;
            this.btnSaveConnectionDetailsImport.Text = "Save connection details";
            this.btnSaveConnectionDetailsImport.UseVisualStyleBackColor = true;
            this.btnSaveConnectionDetailsImport.Click += new System.EventHandler(this.BtnSaveConnectionDetailsImport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbImportSettingDefinitions);
            this.groupBox1.Controls.Add(this.cbImportSettingCategories);
            this.groupBox1.Controls.Add(this.btnGetConnectionDetailsImport);
            this.groupBox1.Controls.Add(this.btnSaveConnectionDetailsImport);
            this.groupBox1.Controls.Add(this.cbImportRules);
            this.groupBox1.Controls.Add(this.cbImportFileTypes);
            this.groupBox1.Controls.Add(this.cbImportClsFieldValues);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cbImportSettings);
            this.groupBox1.Controls.Add(this.tbImportDirPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbImportClassifications);
            this.groupBox1.Controls.Add(this.cbImportFieldDefinitions);
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.cbImportFieldGroups);
            this.groupBox1.Location = new System.Drawing.Point(19, 646);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1059, 616);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "200";
            this.groupBox1.Text = "Import details";
            // 
            // cbImportSettingDefinitions
            // 
            this.cbImportSettingDefinitions.AutoSize = true;
            this.cbImportSettingDefinitions.Location = new System.Drawing.Point(11, 477);
            this.cbImportSettingDefinitions.Name = "cbImportSettingDefinitions";
            this.cbImportSettingDefinitions.Size = new System.Drawing.Size(215, 24);
            this.cbImportSettingDefinitions.TabIndex = 38;
            this.cbImportSettingDefinitions.Text = "Import Setting Definitions";
            this.cbImportSettingDefinitions.UseVisualStyleBackColor = true;
            // 
            // cbImportSettingCategories
            // 
            this.cbImportSettingCategories.AutoSize = true;
            this.cbImportSettingCategories.Location = new System.Drawing.Point(11, 447);
            this.cbImportSettingCategories.Name = "cbImportSettingCategories";
            this.cbImportSettingCategories.Size = new System.Drawing.Size(217, 24);
            this.cbImportSettingCategories.TabIndex = 37;
            this.cbImportSettingCategories.Text = "Import Setting Categories";
            this.cbImportSettingCategories.UseVisualStyleBackColor = true;
            // 
            // btnGetConnectionDetailsImport
            // 
            this.btnGetConnectionDetailsImport.Enabled = false;
            this.btnGetConnectionDetailsImport.Location = new System.Drawing.Point(776, 97);
            this.btnGetConnectionDetailsImport.Name = "btnGetConnectionDetailsImport";
            this.btnGetConnectionDetailsImport.Size = new System.Drawing.Size(264, 35);
            this.btnGetConnectionDetailsImport.TabIndex = 36;
            this.btnGetConnectionDetailsImport.Text = "Use saved connection details...";
            this.btnGetConnectionDetailsImport.UseVisualStyleBackColor = true;
            this.btnGetConnectionDetailsImport.Click += new System.EventHandler(this.BtnGetConnectionDetailsImport_Click);
            // 
            // cbImportRules
            // 
            this.cbImportRules.AutoSize = true;
            this.cbImportRules.Location = new System.Drawing.Point(11, 417);
            this.cbImportRules.Name = "cbImportRules";
            this.cbImportRules.Size = new System.Drawing.Size(126, 24);
            this.cbImportRules.TabIndex = 31;
            this.cbImportRules.Text = "Import Rules";
            this.cbImportRules.UseVisualStyleBackColor = true;
            // 
            // cbImportFileTypes
            // 
            this.cbImportFileTypes.AutoSize = true;
            this.cbImportFileTypes.Location = new System.Drawing.Point(11, 387);
            this.cbImportFileTypes.Name = "cbImportFileTypes";
            this.cbImportFileTypes.Size = new System.Drawing.Size(156, 24);
            this.cbImportFileTypes.TabIndex = 30;
            this.cbImportFileTypes.Text = "Import File Types";
            this.cbImportFileTypes.UseVisualStyleBackColor = true;
            // 
            // cbImportClsFieldValues
            // 
            this.cbImportClsFieldValues.AutoSize = true;
            this.cbImportClsFieldValues.Location = new System.Drawing.Point(230, 357);
            this.cbImportClsFieldValues.Name = "cbImportClsFieldValues";
            this.cbImportClsFieldValues.Size = new System.Drawing.Size(257, 24);
            this.cbImportClsFieldValues.TabIndex = 29;
            this.cbImportClsFieldValues.Text = "Import classification field values";
            this.cbImportClsFieldValues.UseVisualStyleBackColor = true;
            this.cbImportClsFieldValues.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(11, 568);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(266, 35);
            this.btnReset.TabIndex = 28;
            this.btnReset.Text = "Reset to default configuration";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbClientIDDestination);
            this.groupBox2.Controls.Add(this.tbUserTokenDestination);
            this.groupBox2.Controls.Add(this.tbUsernameDestination);
            this.groupBox2.Controls.Add(this.tbRegistrationDestination);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(24, 38);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(745, 200);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "150";
            this.groupBox2.Text = "Connection Details For Import Environment";
            // 
            // tbClientIDDestination
            // 
            this.tbClientIDDestination.Location = new System.Drawing.Point(159, 159);
            this.tbClientIDDestination.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbClientIDDestination.Name = "tbClientIDDestination";
            this.tbClientIDDestination.Size = new System.Drawing.Size(554, 26);
            this.tbClientIDDestination.TabIndex = 9;
            // 
            // tbUserTokenDestination
            // 
            this.tbUserTokenDestination.Location = new System.Drawing.Point(159, 119);
            this.tbUserTokenDestination.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUserTokenDestination.Name = "tbUserTokenDestination";
            this.tbUserTokenDestination.Size = new System.Drawing.Size(554, 26);
            this.tbUserTokenDestination.TabIndex = 8;
            // 
            // tbUsernameDestination
            // 
            this.tbUsernameDestination.Location = new System.Drawing.Point(159, 80);
            this.tbUsernameDestination.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUsernameDestination.Name = "tbUsernameDestination";
            this.tbUsernameDestination.Size = new System.Drawing.Size(554, 26);
            this.tbUsernameDestination.TabIndex = 7;
            // 
            // tbRegistrationDestination
            // 
            this.tbRegistrationDestination.Location = new System.Drawing.Point(159, 40);
            this.tbRegistrationDestination.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbRegistrationDestination.Name = "tbRegistrationDestination";
            this.tbRegistrationDestination.Size = new System.Drawing.Size(554, 26);
            this.tbRegistrationDestination.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 163);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Client ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "User Token";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Registration";
            // 
            // cbImportSettings
            // 
            this.cbImportSettings.AutoSize = true;
            this.cbImportSettings.Location = new System.Drawing.Point(11, 507);
            this.cbImportSettings.Name = "cbImportSettings";
            this.cbImportSettings.Size = new System.Drawing.Size(144, 24);
            this.cbImportSettings.TabIndex = 27;
            this.cbImportSettings.Text = "Import Settings";
            this.cbImportSettings.UseVisualStyleBackColor = true;
            // 
            // tbImportDirPath
            // 
            this.tbImportDirPath.Location = new System.Drawing.Point(170, 263);
            this.tbImportDirPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbImportDirPath.Name = "tbImportDirPath";
            this.tbImportDirPath.Size = new System.Drawing.Size(878, 26);
            this.tbImportDirPath.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 266);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Import directory path";
            // 
            // cbImportClassifications
            // 
            this.cbImportClassifications.AutoSize = true;
            this.cbImportClassifications.Location = new System.Drawing.Point(11, 357);
            this.cbImportClassifications.Name = "cbImportClassifications";
            this.cbImportClassifications.Size = new System.Drawing.Size(186, 24);
            this.cbImportClassifications.TabIndex = 19;
            this.cbImportClassifications.Text = "Import Classifications";
            this.cbImportClassifications.UseVisualStyleBackColor = true;
            this.cbImportClassifications.CheckedChanged += new System.EventHandler(this.CbImportClassifications_CheckedChanged);
            // 
            // cbImportFieldDefinitions
            // 
            this.cbImportFieldDefinitions.AutoSize = true;
            this.cbImportFieldDefinitions.Location = new System.Drawing.Point(11, 327);
            this.cbImportFieldDefinitions.Name = "cbImportFieldDefinitions";
            this.cbImportFieldDefinitions.Size = new System.Drawing.Size(198, 24);
            this.cbImportFieldDefinitions.TabIndex = 18;
            this.cbImportFieldDefinitions.Text = "Import Field Definitions";
            this.cbImportFieldDefinitions.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(936, 568);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(112, 35);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // cbImportFieldGroups
            // 
            this.cbImportFieldGroups.AutoSize = true;
            this.cbImportFieldGroups.Location = new System.Drawing.Point(11, 297);
            this.cbImportFieldGroups.Name = "cbImportFieldGroups";
            this.cbImportFieldGroups.Size = new System.Drawing.Size(176, 24);
            this.cbImportFieldGroups.TabIndex = 16;
            this.cbImportFieldGroups.Text = "Import Field Groups";
            this.cbImportFieldGroups.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1905, 1281);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbExportDetails);
            this.Controls.Add(this.btnSaveLog);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.progressBar1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DAM Configuration Mover";
            this.Load += new System.EventHandler(this.Main_Load);
            this.gbExportDetails.ResumeLayout(false);
            this.gbExportDetails.PerformLayout();
            this.gbConnectionDetails.ResumeLayout(false);
            this.gbConnectionDetails.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox tbClassificationFilter;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.CheckBox cbExportFieldGroups;
        private System.Windows.Forms.CheckBox cbExportFieldDefinitions;
        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.GroupBox gbExportDetails;
        private System.Windows.Forms.CheckBox cbExportClassifications;
        private System.Windows.Forms.TextBox tbFieldGroupsFilter;
        private System.Windows.Forms.TextBox tbFieldDefinitionsFilter;
        private System.Windows.Forms.TextBox txtExportDirPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbExportSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbImportSettings;
        private System.Windows.Forms.TextBox tbImportDirPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbImportClassifications;
        private System.Windows.Forms.CheckBox cbImportFieldDefinitions;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.CheckBox cbImportFieldGroups;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbClientIDDestination;
        private System.Windows.Forms.TextBox tbUserTokenDestination;
        private System.Windows.Forms.TextBox tbUsernameDestination;
        private System.Windows.Forms.TextBox tbRegistrationDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox cbImportClsFieldValues;
        private System.Windows.Forms.TextBox tbFileTyepsFilter;
        private System.Windows.Forms.CheckBox cbExportFileTypes;
        private System.Windows.Forms.CheckBox cbImportFileTypes;
        private System.Windows.Forms.Button btnSelectSettings;
        private System.Windows.Forms.TextBox tbRuleFilter;
        private System.Windows.Forms.CheckBox cbExportRules;
        private System.Windows.Forms.CheckBox cbImportRules;
        private System.Windows.Forms.Button btnSaveConnectionDetailsImport;
        private System.Windows.Forms.Button btnGetConnectionDetailsImport;
        private System.Windows.Forms.GroupBox gbConnectionDetails;
        private System.Windows.Forms.TextBox tbClientIDSource;
        private System.Windows.Forms.TextBox tbUserTokenSource;
        private System.Windows.Forms.TextBox tbUsernameSource;
        private System.Windows.Forms.TextBox tbRegistrationSource;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnGetConnectionDetailsExport;
        private System.Windows.Forms.Button btnSaveConnectionDetailsExport;
        private System.Windows.Forms.TextBox tbSettingDefinitionsFilter;
        private System.Windows.Forms.CheckBox cbExportSettingDefinitions;
        private System.Windows.Forms.TextBox tbSettingCategoriesFilter;
        private System.Windows.Forms.CheckBox cbExportSettingCategories;
        private System.Windows.Forms.CheckBox cbImportSettingDefinitions;
        private System.Windows.Forms.CheckBox cbImportSettingCategories;
    }
}

