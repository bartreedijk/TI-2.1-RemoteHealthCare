namespace FietsClient
{
    partial class DoctorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archiefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PatientBox = new System.Windows.Forms.ToolStripComboBox();
            this.sessionsBox = new System.Windows.Forms.ToolStripComboBox();
            this.selectSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.chatArea = new System.Windows.Forms.GroupBox();
            this.messageButton = new System.Windows.Forms.Button();
            this.doctorTabControl = new System.Windows.Forms.TabControl();
            this.tabPageSummary = new System.Windows.Forms.TabPage();
            this.doctorSummaryUC1 = new FietsClient.Forms.DoctorSummaryUC();
            this.loadUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.chatArea.SuspendLayout();
            this.doctorTabControl.SuspendLayout();
            this.tabPageSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archiefToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1445, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archiefToolStripMenuItem
            // 
            this.archiefToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadUsersToolStripMenuItem,
            this.PatientBox,
            this.sessionsBox,
            this.selectSessionToolStripMenuItem});
            this.archiefToolStripMenuItem.Name = "archiefToolStripMenuItem";
            this.archiefToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.archiefToolStripMenuItem.Text = "Archive";
            // 
            // PatientBox
            // 
            this.PatientBox.Name = "PatientBox";
            this.PatientBox.Size = new System.Drawing.Size(121, 28);
            this.PatientBox.SelectedIndexChanged += new System.EventHandler(this.PatientBox_SelectedIndexChanged);
            // 
            // sessionsBox
            // 
            this.sessionsBox.Name = "sessionsBox";
            this.sessionsBox.Size = new System.Drawing.Size(121, 28);
            // 
            // selectSessionToolStripMenuItem
            // 
            this.selectSessionToolStripMenuItem.Name = "selectSessionToolStripMenuItem";
            this.selectSessionToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.selectSessionToolStripMenuItem.Text = "Select session";
            this.selectSessionToolStripMenuItem.Click += new System.EventHandler(this.selectSessionToolStripMenuItem_Click);
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(0, 16);
            this.chatBox.Margin = new System.Windows.Forms.Padding(4);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(303, 688);
            this.chatBox.TabIndex = 3;
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(0, 713);
            this.messageBox.Margin = new System.Windows.Forms.Padding(4);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(303, 22);
            this.messageBox.TabIndex = 6;
            this.messageBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.messageBox_KeyPress);
            // 
            // chatArea
            // 
            this.chatArea.Controls.Add(this.messageButton);
            this.chatArea.Controls.Add(this.chatBox);
            this.chatArea.Controls.Add(this.messageBox);
            this.chatArea.Location = new System.Drawing.Point(1132, 62);
            this.chatArea.Margin = new System.Windows.Forms.Padding(4);
            this.chatArea.Name = "chatArea";
            this.chatArea.Padding = new System.Windows.Forms.Padding(4);
            this.chatArea.Size = new System.Drawing.Size(304, 789);
            this.chatArea.TabIndex = 5;
            this.chatArea.TabStop = false;
            this.chatArea.Text = "Chat:";
            // 
            // messageButton
            // 
            this.messageButton.Location = new System.Drawing.Point(0, 745);
            this.messageButton.Margin = new System.Windows.Forms.Padding(4);
            this.messageButton.Name = "messageButton";
            this.messageButton.Size = new System.Drawing.Size(304, 37);
            this.messageButton.TabIndex = 7;
            this.messageButton.Text = "send";
            this.messageButton.UseVisualStyleBackColor = true;
            this.messageButton.Click += new System.EventHandler(this.messageButton_Click);
            // 
            // doctorTabControl
            // 
            this.doctorTabControl.Controls.Add(this.tabPageSummary);
            this.doctorTabControl.Location = new System.Drawing.Point(17, 34);
            this.doctorTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.doctorTabControl.Name = "doctorTabControl";
            this.doctorTabControl.SelectedIndex = 0;
            this.doctorTabControl.Size = new System.Drawing.Size(1107, 820);
            this.doctorTabControl.TabIndex = 6;
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.BackColor = System.Drawing.Color.Transparent;
            this.tabPageSummary.Controls.Add(this.doctorSummaryUC1);
            this.tabPageSummary.Location = new System.Drawing.Point(4, 25);
            this.tabPageSummary.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Size = new System.Drawing.Size(1099, 791);
            this.tabPageSummary.TabIndex = 0;
            this.tabPageSummary.Text = "Summary";
            // 
            // doctorSummaryUC1
            // 
            this.doctorSummaryUC1.BackColor = System.Drawing.SystemColors.Control;
            this.doctorSummaryUC1.Location = new System.Drawing.Point(0, 0);
            this.doctorSummaryUC1.Margin = new System.Windows.Forms.Padding(5);
            this.doctorSummaryUC1.Name = "doctorSummaryUC1";
            this.doctorSummaryUC1.Size = new System.Drawing.Size(1096, 788);
            this.doctorSummaryUC1.TabIndex = 0;
            // 
            // loadUsersToolStripMenuItem
            // 
            this.loadUsersToolStripMenuItem.Name = "loadUsersToolStripMenuItem";
            this.loadUsersToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.loadUsersToolStripMenuItem.Text = "Load users";
            this.loadUsersToolStripMenuItem.Click += new System.EventHandler(this.loadUsersToolStripMenuItem_Click);
            // 
            // DoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1445, 875);
            this.Controls.Add(this.doctorTabControl);
            this.Controls.Add(this.chatArea);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "DoctorForm";
            this.Text = "Doctor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DoctorForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.chatArea.ResumeLayout(false);
            this.chatArea.PerformLayout();
            this.doctorTabControl.ResumeLayout(false);
            this.tabPageSummary.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.GroupBox chatArea;
        private System.Windows.Forms.Button messageButton;
        private System.Windows.Forms.TabControl doctorTabControl;
        private Forms.DoctorSummaryUC doctorSummaryUC1;
        public System.Windows.Forms.ToolStripMenuItem archiefToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox PatientBox;
        public System.Windows.Forms.TabPage tabPageSummary;
        public System.Windows.Forms.ToolStripComboBox sessionsBox;
        private System.Windows.Forms.ToolStripMenuItem selectSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadUsersToolStripMenuItem;
    }
}

