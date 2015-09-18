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
            this.chkChooseData = new System.Windows.Forms.CheckedListBox();
            this.btnCloseCom = new System.Windows.Forms.Button();
            this.btnStartAsking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbChooseCom
            // 
            this.cmbChooseCom.FormattingEnabled = true;
            this.cmbChooseCom.Location = new System.Drawing.Point(283, 194);
            this.cmbChooseCom.Name = "cmbChooseCom";
            this.cmbChooseCom.Size = new System.Drawing.Size(129, 24);
            this.cmbChooseCom.TabIndex = 0;
            this.cmbChooseCom.SelectionChangeCommitted += new System.EventHandler(this.cmbChooseCom_SelectionChangeCommitted);
            // 
            // pgbInit
            // 
            this.pgbInit.Location = new System.Drawing.Point(283, 224);
            this.pgbInit.Name = "pgbInit";
            this.pgbInit.Size = new System.Drawing.Size(129, 23);
            this.pgbInit.TabIndex = 1;
            // 
            // chkChooseData
            // 
            this.chkChooseData.FormattingEnabled = true;
            this.chkChooseData.Items.AddRange(new object[] {
            "Pulse",
            "Rpm",
            "Speed",
            "Distance",
            "Requestedpower",
            "Energy",
            "Time",
            "Actualpower"});
            this.chkChooseData.Location = new System.Drawing.Point(23, 435);
            this.chkChooseData.Name = "chkChooseData";
            this.chkChooseData.Size = new System.Drawing.Size(153, 140);
            this.chkChooseData.TabIndex = 2;
            this.chkChooseData.SelectedIndexChanged += new System.EventHandler(this.chkChooseData_SelectedIndexChanged);
            // 
            // btnCloseCom
            // 
            this.btnCloseCom.Location = new System.Drawing.Point(432, 224);
            this.btnCloseCom.Name = "btnCloseCom";
            this.btnCloseCom.Size = new System.Drawing.Size(181, 23);
            this.btnCloseCom.TabIndex = 3;
            this.btnCloseCom.Text = "Close Comport";
            this.btnCloseCom.UseVisualStyleBackColor = true;
            this.btnCloseCom.Click += new System.EventHandler(this.btnCloseCom_Click);
            // 
            // btnStartAsking
            // 
            this.btnStartAsking.Location = new System.Drawing.Point(432, 194);
            this.btnStartAsking.Name = "btnStartAsking";
            this.btnStartAsking.Size = new System.Drawing.Size(181, 23);
            this.btnStartAsking.TabIndex = 4;
            this.btnStartAsking.Text = "Start Asking Status";
            this.btnStartAsking.UseVisualStyleBackColor = true;
            this.btnStartAsking.Click += new System.EventHandler(this.btnStartAsking_Click);
            // 
            // UcSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStartAsking);
            this.Controls.Add(this.btnCloseCom);
            this.Controls.Add(this.chkChooseData);
            this.Controls.Add(this.pgbInit);
            this.Controls.Add(this.cmbChooseCom);
            this.Name = "UcSettings";
            this.Size = new System.Drawing.Size(1035, 596);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbChooseCom;
        private System.Windows.Forms.ProgressBar pgbInit;
        private System.Windows.Forms.CheckedListBox chkChooseData;
        private System.Windows.Forms.Button btnCloseCom;
        private System.Windows.Forms.Button btnStartAsking;
    }
}
