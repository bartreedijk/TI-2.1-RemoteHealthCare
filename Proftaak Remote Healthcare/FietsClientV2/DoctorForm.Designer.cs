namespace FietsClientV2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archiefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sESSIONSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedBox = new System.Windows.Forms.GroupBox();
            this.speedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bpmBox = new System.Windows.Forms.GroupBox();
            this.bpmChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sessionInfoBox = new System.Windows.Forms.GroupBox();
            this.rpmBox = new System.Windows.Forms.GroupBox();
            this.rpmChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.chatArea = new System.Windows.Forms.GroupBox();
            this.selectArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauzeSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.speedBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).BeginInit();
            this.bpmBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bpmChart)).BeginInit();
            this.rpmBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpmChart)).BeginInit();
            this.chatArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archiefToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1064, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archiefToolStripMenuItem
            // 
            this.archiefToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectSessionToolStripMenuItem,
            this.selectArchiveToolStripMenuItem,
            this.startNewSessionToolStripMenuItem,
            this.pauzeSessionToolStripMenuItem,
            this.stopSessionToolStripMenuItem});
            this.archiefToolStripMenuItem.Name = "archiefToolStripMenuItem";
            this.archiefToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.archiefToolStripMenuItem.Text = "Patient";
            // 
            // selectSessionToolStripMenuItem
            // 
            this.selectSessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sESSIONSToolStripMenuItem});
            this.selectSessionToolStripMenuItem.Name = "selectSessionToolStripMenuItem";
            this.selectSessionToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.selectSessionToolStripMenuItem.Text = "Select patient";
            // 
            // sESSIONSToolStripMenuItem
            // 
            this.sESSIONSToolStripMenuItem.Name = "sESSIONSToolStripMenuItem";
            this.sESSIONSToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sESSIONSToolStripMenuItem.Text = "Patients";
            // 
            // speedBox
            // 
            this.speedBox.Controls.Add(this.speedChart);
            this.speedBox.Location = new System.Drawing.Point(12, 27);
            this.speedBox.Name = "speedBox";
            this.speedBox.Size = new System.Drawing.Size(400, 310);
            this.speedBox.TabIndex = 2;
            this.speedBox.TabStop = false;
            this.speedBox.Text = "Speed:";
            // 
            // speedChart
            // 
            chartArea1.Name = "ChartArea1";
            this.speedChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.speedChart.Legends.Add(legend1);
            this.speedChart.Location = new System.Drawing.Point(6, 19);
            this.speedChart.Name = "speedChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.speedChart.Series.Add(series1);
            this.speedChart.Size = new System.Drawing.Size(388, 285);
            this.speedChart.TabIndex = 0;
            this.speedChart.Text = "Speed chart";
            // 
            // bpmBox
            // 
            this.bpmBox.Controls.Add(this.bpmChart);
            this.bpmBox.Location = new System.Drawing.Point(12, 343);
            this.bpmBox.Name = "bpmBox";
            this.bpmBox.Size = new System.Drawing.Size(400, 310);
            this.bpmBox.TabIndex = 3;
            this.bpmBox.TabStop = false;
            this.bpmBox.Text = "Beats per second:";
            // 
            // bpmChart
            // 
            chartArea2.Name = "ChartArea1";
            this.bpmChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.bpmChart.Legends.Add(legend2);
            this.bpmChart.Location = new System.Drawing.Point(6, 19);
            this.bpmChart.Name = "bpmChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.bpmChart.Series.Add(series2);
            this.bpmChart.Size = new System.Drawing.Size(388, 285);
            this.bpmChart.TabIndex = 1;
            this.bpmChart.Text = "beats per second";
            // 
            // sessionInfoBox
            // 
            this.sessionInfoBox.Location = new System.Drawing.Point(418, 27);
            this.sessionInfoBox.Name = "sessionInfoBox";
            this.sessionInfoBox.Size = new System.Drawing.Size(400, 310);
            this.sessionInfoBox.TabIndex = 4;
            this.sessionInfoBox.TabStop = false;
            this.sessionInfoBox.Text = "Session info:";
            // 
            // rpmBox
            // 
            this.rpmBox.Controls.Add(this.rpmChart);
            this.rpmBox.Location = new System.Drawing.Point(418, 343);
            this.rpmBox.Name = "rpmBox";
            this.rpmBox.Size = new System.Drawing.Size(400, 310);
            this.rpmBox.TabIndex = 5;
            this.rpmBox.TabStop = false;
            this.rpmBox.Text = "Rounds per minute:";
            // 
            // rpmChart
            // 
            chartArea3.Name = "ChartArea1";
            this.rpmChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.rpmChart.Legends.Add(legend3);
            this.rpmChart.Location = new System.Drawing.Point(6, 19);
            this.rpmChart.Name = "rpmChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.rpmChart.Series.Add(series3);
            this.rpmChart.Size = new System.Drawing.Size(388, 285);
            this.rpmChart.TabIndex = 2;
            this.rpmChart.Text = "rounds per minute";
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(0, 19);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(228, 581);
            this.chatBox.TabIndex = 3;
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(0, 606);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(228, 20);
            this.messageBox.TabIndex = 6;
            // 
            // chatArea
            // 
            this.chatArea.Controls.Add(this.chatBox);
            this.chatArea.Controls.Add(this.messageBox);
            this.chatArea.Location = new System.Drawing.Point(824, 27);
            this.chatArea.Name = "chatArea";
            this.chatArea.Size = new System.Drawing.Size(228, 626);
            this.chatArea.TabIndex = 5;
            this.chatArea.TabStop = false;
            this.chatArea.Text = "Chat:";
            // 
            // selectArchiveToolStripMenuItem
            // 
            this.selectArchiveToolStripMenuItem.Name = "selectArchiveToolStripMenuItem";
            this.selectArchiveToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.selectArchiveToolStripMenuItem.Text = "Select archive";
            // 
            // startNewSessionToolStripMenuItem
            // 
            this.startNewSessionToolStripMenuItem.Name = "startNewSessionToolStripMenuItem";
            this.startNewSessionToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.startNewSessionToolStripMenuItem.Text = "Start new session";
            // 
            // pauzeSessionToolStripMenuItem
            // 
            this.pauzeSessionToolStripMenuItem.Name = "pauzeSessionToolStripMenuItem";
            this.pauzeSessionToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.pauzeSessionToolStripMenuItem.Text = "Pauze session";
            // 
            // stopSessionToolStripMenuItem
            // 
            this.stopSessionToolStripMenuItem.Name = "stopSessionToolStripMenuItem";
            this.stopSessionToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.stopSessionToolStripMenuItem.Text = "Stop session";
            // 
            // DoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.chatArea);
            this.Controls.Add(this.sessionInfoBox);
            this.Controls.Add(this.rpmBox);
            this.Controls.Add(this.bpmBox);
            this.Controls.Add(this.speedBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DoctorForm";
            this.Text = "Doctor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.speedBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).EndInit();
            this.bpmBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bpmChart)).EndInit();
            this.rpmBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rpmChart)).EndInit();
            this.chatArea.ResumeLayout(false);
            this.chatArea.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archiefToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sESSIONSToolStripMenuItem;
        private System.Windows.Forms.GroupBox speedBox;
        private System.Windows.Forms.GroupBox bpmBox;
        private System.Windows.Forms.GroupBox sessionInfoBox;
        private System.Windows.Forms.GroupBox rpmBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart speedChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart bpmChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart rpmChart;
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.GroupBox chatArea;
        private System.Windows.Forms.ToolStripMenuItem selectArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNewSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauzeSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopSessionToolStripMenuItem;
    }
}

