namespace Fietsclient
{
    partial class MainForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusButton = new System.Windows.Forms.Button();
            this.closeComportButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComPortProgressBar = new System.Windows.Forms.ProgressBar();
            this.ComPortComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(12, 187);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(806, 142);
            this.textBox1.TabIndex = 1;
            // 
            // statusButton
            // 
            this.statusButton.Location = new System.Drawing.Point(10, 46);
            this.statusButton.Name = "statusButton";
            this.statusButton.Size = new System.Drawing.Size(119, 23);
            this.statusButton.TabIndex = 2;
            this.statusButton.Text = "Status";
            this.statusButton.UseVisualStyleBackColor = true;
            this.statusButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // closeComportButton
            // 
            this.closeComportButton.Location = new System.Drawing.Point(10, 75);
            this.closeComportButton.Name = "closeComportButton";
            this.closeComportButton.Size = new System.Drawing.Size(119, 23);
            this.closeComportButton.TabIndex = 3;
            this.closeComportButton.Text = "Close port";
            this.closeComportButton.UseVisualStyleBackColor = true;
            this.closeComportButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComPortProgressBar);
            this.groupBox1.Controls.Add(this.statusButton);
            this.groupBox1.Controls.Add(this.ComPortComboBox);
            this.groupBox1.Controls.Add(this.closeComportButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 145);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Com port options";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ComPortProgressBar
            // 
            this.ComPortProgressBar.Location = new System.Drawing.Point(10, 104);
            this.ComPortProgressBar.Name = "ComPortProgressBar";
            this.ComPortProgressBar.Size = new System.Drawing.Size(119, 30);
            this.ComPortProgressBar.TabIndex = 8;
            // 
            // ComPortComboBox
            // 
            this.ComPortComboBox.FormattingEnabled = true;
            this.ComPortComboBox.Location = new System.Drawing.Point(10, 19);
            this.ComPortComboBox.Name = "ComPortComboBox";
            this.ComPortComboBox.Size = new System.Drawing.Size(119, 21);
            this.ComPortComboBox.TabIndex = 6;
            this.ComPortComboBox.SelectedIndexChanged += new System.EventHandler(this.ComPortComboBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(830, 343);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button statusButton;
        private System.Windows.Forms.Button closeComportButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ComPortComboBox;
        private System.Windows.Forms.ProgressBar ComPortProgressBar;
    }
}

