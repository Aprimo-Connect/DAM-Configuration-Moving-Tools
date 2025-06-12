namespace Aprimo.DAM.ConfigurationMover
{
    partial class ConnectionsDetails
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
            this.btnSelectEnv = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSelectEnvironment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRegistration = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbClientID = new System.Windows.Forms.TextBox();
            this.tbClientSecret = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbConnectionName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelectEnv);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbSelectEnvironment);
            this.groupBox2.Location = new System.Drawing.Point(23, 365);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 178);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Use saved connection details";
            // 
            // btnSelectEnv
            // 
            this.btnSelectEnv.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelectEnv.Location = new System.Drawing.Point(43, 116);
            this.btnSelectEnv.Name = "btnSelectEnv";
            this.btnSelectEnv.Size = new System.Drawing.Size(226, 41);
            this.btnSelectEnv.TabIndex = 21;
            this.btnSelectEnv.Text = "Use Selected Environmet";
            this.btnSelectEnv.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Environment to use: ";
            // 
            // cbSelectEnvironment
            // 
            this.cbSelectEnvironment.FormattingEnabled = true;
            this.cbSelectEnvironment.Location = new System.Drawing.Point(42, 69);
            this.cbSelectEnvironment.Name = "cbSelectEnvironment";
            this.cbSelectEnvironment.Size = new System.Drawing.Size(333, 28);
            this.cbSelectEnvironment.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(73, 72);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Client ID";
            // 
            // tbRegistration
            // 
            this.tbRegistration.Location = new System.Drawing.Point(151, 29);
            this.tbRegistration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbRegistration.Name = "tbRegistration";
            this.tbRegistration.Size = new System.Drawing.Size(323, 26);
            this.tbRegistration.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 111);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 30);
            this.label9.TabIndex = 12;
            this.label9.Text = "Client Secret";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 35);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "Registration";
            // 
            // tbClientID
            // 
            
            this.tbClientID.Location = new System.Drawing.Point(151, 72);
            this.tbClientID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbClientID.Name = "tbClientID";
            this.tbClientID.Size = new System.Drawing.Size(323, 26);
            this.tbClientID.TabIndex = 17;
            // 
            // tbClientSecret
            // 
            this.tbClientSecret.Location = new System.Drawing.Point(151, 108);
            this.tbClientSecret.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbClientSecret.Name = "tbClientSecret";
            this.tbClientSecret.Size = new System.Drawing.Size(323, 26);
            this.tbClientSecret.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 193);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Save As (Name)";
            // 
            // tbConnectionName
            // 
            this.tbConnectionName.Location = new System.Drawing.Point(151, 193);
            this.tbConnectionName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbConnectionName.Name = "tbConnectionName";
            this.tbConnectionName.Size = new System.Drawing.Size(323, 26);
            this.tbConnectionName.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(162, 249);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 41);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.tbConnectionName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbClientSecret);
            this.groupBox1.Controls.Add(this.tbClientID);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbRegistration);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(23, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 319);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save Connection Details";
            // 
            // ConnectionsDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 558);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConnectionsDetails";
            this.Text = "ConnectionsDetails";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSelectEnv;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbSelectEnvironment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRegistration;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbClientID;
        private System.Windows.Forms.TextBox tbClientSecret;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbConnectionName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}