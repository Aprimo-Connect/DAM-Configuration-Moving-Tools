namespace Aprimo.DAM.ConfigurationMover
{
    partial class SettingsSelector
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
            this.lbSelectSettings = new System.Windows.Forms.ListBox();
            this.lbSelectUserGroups = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbSelectSettings
            // 
            this.lbSelectSettings.FormattingEnabled = true;
            this.lbSelectSettings.ItemHeight = 20;
            this.lbSelectSettings.Location = new System.Drawing.Point(21, 65);
            this.lbSelectSettings.Name = "lbSelectSettings";
            this.lbSelectSettings.ScrollAlwaysVisible = true;
            this.lbSelectSettings.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSelectSettings.Size = new System.Drawing.Size(514, 404);
            this.lbSelectSettings.TabIndex = 0;
            // 
            // lbSelectUserGroups
            // 
            this.lbSelectUserGroups.FormattingEnabled = true;
            this.lbSelectUserGroups.ItemHeight = 20;
            this.lbSelectUserGroups.Location = new System.Drawing.Point(577, 65);
            this.lbSelectUserGroups.Name = "lbSelectUserGroups";
            this.lbSelectUserGroups.ScrollAlwaysVisible = true;
            this.lbSelectUserGroups.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSelectUserGroups.Size = new System.Drawing.Size(514, 404);
            this.lbSelectUserGroups.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(498, 490);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(118, 38);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select settings to export:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(573, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select user groups to export setting values for:";
            // 
            // SettingsSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1115, 551);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbSelectUserGroups);
            this.Controls.Add(this.lbSelectSettings);
            this.Name = "SettingsSelector";
            this.Text = "SettingsSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox lbSelectSettings;
        public System.Windows.Forms.ListBox lbSelectUserGroups;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}