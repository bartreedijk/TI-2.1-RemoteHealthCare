namespace Fietsclient.User_Controls
{
    partial class UcSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbChooseCom = new System.Windows.Forms.ComboBox();
            this.pgbInit = new System.Windows.Forms.ProgressBar();
            this.btnCloseCom = new System.Windows.Forms.Button();
            this.btnStartAsking = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.setModeBTN = new System.Windows.Forms.Button();
            this.modeField = new System.Windows.Forms.Label();
            this.modeTXTBox = new System.Windows.Forms.TextBox();
            this.modeSeconds = new System.Windows.Forms.TextBox();
            this.modeMinutes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pwrBox = new System.Windows.Forms.TextBox();
            this.setPWRBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbChooseCom
            // 
            this.cmbChooseCom.FormattingEnabled = true;
            this.cmbChooseCom.Location = new System.Drawing.Point(28, 34);
            this.cmbChooseCom.Name = "cmbChooseCom";
            this.cmbChooseCom.Size = new System.Drawing.Size(129, 24);
            this.cmbChooseCom.TabIndex = 0;
            this.cmbChooseCom.SelectionChangeCommitted += new System.EventHandler(this.cmbChooseCom_SelectionChangeCommitted);
            // 
            // pgbInit
            // 
            this.pgbInit.Location = new System.Drawing.Point(28, 64);
            this.pgbInit.Name = "pgbInit";
            this.pgbInit.Size = new System.Drawing.Size(129, 23);
            this.pgbInit.TabIndex = 1;
            // 
            // btnCloseCom
            // 
            this.btnCloseCom.Location = new System.Drawing.Point(177, 64);
            this.btnCloseCom.Name = "btnCloseCom";
            this.btnCloseCom.Size = new System.Drawing.Size(181, 23);
            this.btnCloseCom.TabIndex = 3;
            this.btnCloseCom.Text = "Close Comport";
            this.btnCloseCom.UseVisualStyleBackColor = true;
            this.btnCloseCom.Click += new System.EventHandler(this.btnCloseCom_Click);
            // 
            // btnStartAsking
            // 
            this.btnStartAsking.Location = new System.Drawing.Point(177, 34);
            this.btnStartAsking.Name = "btnStartAsking";
            this.btnStartAsking.Size = new System.Drawing.Size(181, 23);
            this.btnStartAsking.TabIndex = 4;
            this.btnStartAsking.Text = "Start Asking Status";
            this.btnStartAsking.UseVisualStyleBackColor = true;
            this.btnStartAsking.Click += new System.EventHandler(this.btnStartAsking_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choose mode...";
            // 
            // cmbMode
            // 
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "Distance",
            "Time"});
            this.cmbMode.Location = new System.Drawing.Point(154, 135);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(172, 24);
            this.cmbMode.TabIndex = 6;
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // setModeBTN
            // 
            this.setModeBTN.Location = new System.Drawing.Point(154, 222);
            this.setModeBTN.Name = "setModeBTN";
            this.setModeBTN.Size = new System.Drawing.Size(172, 33);
            this.setModeBTN.TabIndex = 7;
            this.setModeBTN.Text = "Set Mode";
            this.setModeBTN.UseVisualStyleBackColor = true;
            this.setModeBTN.Click += new System.EventHandler(this.setModeBTN_Click);
            // 
            // modeField
            // 
            this.modeField.AutoSize = true;
            this.modeField.Location = new System.Drawing.Point(14, 184);
            this.modeField.Name = "modeField";
            this.modeField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.modeField.Size = new System.Drawing.Size(0, 17);
            this.modeField.TabIndex = 9;
            this.modeField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // modeTXTBox
            // 
            this.modeTXTBox.Location = new System.Drawing.Point(154, 181);
            this.modeTXTBox.Name = "modeTXTBox";
            this.modeTXTBox.Size = new System.Drawing.Size(172, 22);
            this.modeTXTBox.TabIndex = 11;
            this.modeTXTBox.Visible = false;
            // 
            // modeSeconds
            // 
            this.modeSeconds.Location = new System.Drawing.Point(239, 181);
            this.modeSeconds.Name = "modeSeconds";
            this.modeSeconds.Size = new System.Drawing.Size(87, 22);
            this.modeSeconds.TabIndex = 12;
            this.modeSeconds.Visible = false;
            // 
            // modeMinutes
            // 
            this.modeMinutes.Location = new System.Drawing.Point(154, 181);
            this.modeMinutes.Name = "modeMinutes";
            this.modeMinutes.Size = new System.Drawing.Size(79, 22);
            this.modeMinutes.TabIndex = 13;
            this.modeMinutes.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Power";
            // 
            // pwrBox
            // 
            this.pwrBox.Location = new System.Drawing.Point(457, 134);
            this.pwrBox.Name = "pwrBox";
            this.pwrBox.Size = new System.Drawing.Size(100, 22);
            this.pwrBox.TabIndex = 15;
            // 
            // setPWRBTN
            // 
            this.setPWRBTN.Location = new System.Drawing.Point(457, 162);
            this.setPWRBTN.Name = "setPWRBTN";
            this.setPWRBTN.Size = new System.Drawing.Size(100, 39);
            this.setPWRBTN.TabIndex = 16;
            this.setPWRBTN.Text = "Set Power";
            this.setPWRBTN.UseVisualStyleBackColor = true;
            this.setPWRBTN.Click += new System.EventHandler(this.setPWRBTN_Click);
            // 
            // UcSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.setPWRBTN);
            this.Controls.Add(this.pwrBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modeMinutes);
            this.Controls.Add(this.modeSeconds);
            this.Controls.Add(this.modeTXTBox);
            this.Controls.Add(this.modeField);
            this.Controls.Add(this.setModeBTN);
            this.Controls.Add(this.cmbMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartAsking);
            this.Controls.Add(this.btnCloseCom);
            this.Controls.Add(this.pgbInit);
            this.Controls.Add(this.cmbChooseCom);
            this.Name = "UcSettings";
            this.Size = new System.Drawing.Size(1035, 596);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbChooseCom;
        private System.Windows.Forms.ProgressBar pgbInit;
        private System.Windows.Forms.Button btnCloseCom;
        private System.Windows.Forms.Button btnStartAsking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Button setModeBTN;
        private System.Windows.Forms.Label modeField;
        private System.Windows.Forms.TextBox modeTXTBox;
        private System.Windows.Forms.TextBox modeSeconds;
        private System.Windows.Forms.TextBox modeMinutes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pwrBox;
        private System.Windows.Forms.Button setPWRBTN;
    }
}
