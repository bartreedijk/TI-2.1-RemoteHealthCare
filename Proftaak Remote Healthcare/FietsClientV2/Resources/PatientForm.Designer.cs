using System.Windows.Forms.DataVisualization.Charting;

namespace FietsClient
{
    partial class PatientForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archiefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sESSIONSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bicycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.openPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closePortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTrainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distanceTraining = new System.Windows.Forms.ToolStripMenuItem();
            this.distanceBox = new System.Windows.Forms.ToolStripTextBox();
            this.confirmDistanceBox = new System.Windows.Forms.ToolStripMenuItem();
            this.setTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteBox = new System.Windows.Forms.ToolStripTextBox();
            this.secondBox = new System.Windows.Forms.ToolStripTextBox();
            this.confirmTimeBox = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTrainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerBox = new System.Windows.Forms.ToolStripTextBox();
            this.setPower = new System.Windows.Forms.ToolStripMenuItem();
            this.energyBox = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.speedBox = new System.Windows.Forms.GroupBox();
            this.speedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bpmBox = new System.Windows.Forms.GroupBox();
            this.bpmChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sessionInfoBox = new System.Windows.Forms.GroupBox();
            this.requestedBox = new System.Windows.Forms.TextBox();
            this.actualBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.sessionBox = new System.Windows.Forms.TextBox();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.pulseBox = new System.Windows.Forms.TextBox();
            this.rpmInfoBox = new System.Windows.Forms.TextBox();
            this.energyInfoBox = new System.Windows.Forms.TextBox();
            this.distanceInfoBox = new System.Windows.Forms.TextBox();
            this.speedInfoBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rpmBox = new System.Windows.Forms.GroupBox();
            this.rpmChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.chatArea = new System.Windows.Forms.GroupBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.speedBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).BeginInit();
            this.bpmBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bpmChart)).BeginInit();
            this.sessionInfoBox.SuspendLayout();
            this.rpmBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpmChart)).BeginInit();
            this.chatArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archiefToolStripMenuItem,
            this.bicycleToolStripMenuItem,
            this.startTrainingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1419, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archiefToolStripMenuItem
            // 
            this.archiefToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectSessionToolStripMenuItem});
            this.archiefToolStripMenuItem.Name = "archiefToolStripMenuItem";
            this.archiefToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.archiefToolStripMenuItem.Text = "Archive";
            // 
            // selectSessionToolStripMenuItem
            // 
            this.selectSessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sESSIONSToolStripMenuItem});
            this.selectSessionToolStripMenuItem.Name = "selectSessionToolStripMenuItem";
            this.selectSessionToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.selectSessionToolStripMenuItem.Text = "Select Session";
            // 
            // sESSIONSToolStripMenuItem
            // 
            this.sESSIONSToolStripMenuItem.Name = "sESSIONSToolStripMenuItem";
            this.sESSIONSToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.sESSIONSToolStripMenuItem.Text = "SESSIONS";
            // 
            // bicycleToolStripMenuItem
            // 
            this.bicycleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectPortToolStripMenuItem});
            this.bicycleToolStripMenuItem.Name = "bicycleToolStripMenuItem";
            this.bicycleToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.bicycleToolStripMenuItem.Text = "Bicycle";
            // 
            // selectPortToolStripMenuItem
            // 
            this.selectPortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.openPortToolStripMenuItem,
            this.requestDataToolStripMenuItem,
            this.closePortToolStripMenuItem});
            this.selectPortToolStripMenuItem.Name = "selectPortToolStripMenuItem";
            this.selectPortToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.selectPortToolStripMenuItem.Text = "Select port";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            // 
            // openPortToolStripMenuItem
            // 
            this.openPortToolStripMenuItem.Name = "openPortToolStripMenuItem";
            this.openPortToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.openPortToolStripMenuItem.Text = "Open port";
            this.openPortToolStripMenuItem.Click += new System.EventHandler(this.openPortToolStripMenuItem_Click);
            // 
            // requestDataToolStripMenuItem
            // 
            this.requestDataToolStripMenuItem.Enabled = false;
            this.requestDataToolStripMenuItem.Name = "requestDataToolStripMenuItem";
            this.requestDataToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.requestDataToolStripMenuItem.Text = "Request data";
            this.requestDataToolStripMenuItem.Click += new System.EventHandler(this.requestDataToolStripMenuItem_Click);
            // 
            // closePortToolStripMenuItem
            // 
            this.closePortToolStripMenuItem.Enabled = false;
            this.closePortToolStripMenuItem.Name = "closePortToolStripMenuItem";
            this.closePortToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.closePortToolStripMenuItem.Text = "Close port";
            this.closePortToolStripMenuItem.Click += new System.EventHandler(this.closePortToolStripMenuItem_Click);
            // 
            // startTrainingToolStripMenuItem
            // 
            this.startTrainingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.distanceToolStripMenuItem,
            this.stopTrainingToolStripMenuItem,
            this.setToolStripMenuItem,
            this.energyBox});
            this.startTrainingToolStripMenuItem.Name = "startTrainingToolStripMenuItem";
            this.startTrainingToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.startTrainingToolStripMenuItem.Text = "Start training";
            // 
            // distanceToolStripMenuItem
            // 
            this.distanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.distanceTraining,
            this.setTimeToolStripMenuItem});
            this.distanceToolStripMenuItem.Name = "distanceToolStripMenuItem";
            this.distanceToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.distanceToolStripMenuItem.Text = "Select training";
            // 
            // distanceTraining
            // 
            this.distanceTraining.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.distanceBox,
            this.confirmDistanceBox});
            this.distanceTraining.Name = "distanceTraining";
            this.distanceTraining.Size = new System.Drawing.Size(166, 26);
            this.distanceTraining.Text = "Set Distance";
            // 
            // distanceBox
            // 
            this.distanceBox.Name = "distanceBox";
            this.distanceBox.Size = new System.Drawing.Size(100, 27);
            // 
            // confirmDistanceBox
            // 
            this.confirmDistanceBox.Name = "confirmDistanceBox";
            this.confirmDistanceBox.Size = new System.Drawing.Size(196, 26);
            this.confirmDistanceBox.Text = "Confirm distance";
            this.confirmDistanceBox.Click += new System.EventHandler(this.confirmDistanceBox_Click);
            // 
            // setTimeToolStripMenuItem
            // 
            this.setTimeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minuteBox,
            this.secondBox,
            this.confirmTimeBox});
            this.setTimeToolStripMenuItem.Name = "setTimeToolStripMenuItem";
            this.setTimeToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.setTimeToolStripMenuItem.Text = "Set Time";
            // 
            // minuteBox
            // 
            this.minuteBox.Name = "minuteBox";
            this.minuteBox.Size = new System.Drawing.Size(100, 27);
            this.minuteBox.Text = "MM";
            // 
            // secondBox
            // 
            this.secondBox.Name = "secondBox";
            this.secondBox.Size = new System.Drawing.Size(160, 27);
            this.secondBox.Text = "SS";
            // 
            // confirmTimeBox
            // 
            this.confirmTimeBox.Name = "confirmTimeBox";
            this.confirmTimeBox.Size = new System.Drawing.Size(226, 26);
            this.confirmTimeBox.Text = "Confirm time";
            this.confirmTimeBox.Click += new System.EventHandler(this.confirmTimeBox_Click);
            // 
            // stopTrainingToolStripMenuItem
            // 
            this.stopTrainingToolStripMenuItem.Name = "stopTrainingToolStripMenuItem";
            this.stopTrainingToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.stopTrainingToolStripMenuItem.Text = "Reset training";
            this.stopTrainingToolStripMenuItem.Click += new System.EventHandler(this.stopTrainingToolStripMenuItem_Click);
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.powerBox,
            this.setPower});
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.setToolStripMenuItem.Text = "Power";
            // 
            // powerBox
            // 
            this.powerBox.Name = "powerBox";
            this.powerBox.Size = new System.Drawing.Size(100, 27);
            // 
            // setPower
            // 
            this.setPower.Name = "setPower";
            this.setPower.Size = new System.Drawing.Size(166, 26);
            this.setPower.Text = "Set power";
            this.setPower.Click += new System.EventHandler(this.setPower_Click);
            // 
            // energyBox
            // 
            this.energyBox.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox3,
            this.toolStripMenuItem1});
            this.energyBox.Name = "energyBox";
            this.energyBox.Size = new System.Drawing.Size(181, 26);
            this.energyBox.Text = "Energy";
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 26);
            this.toolStripMenuItem1.Text = "Set energy";
            // 
            // speedBox
            // 
            this.speedBox.Controls.Add(this.speedChart);
            this.speedBox.Location = new System.Drawing.Point(16, 33);
            this.speedBox.Margin = new System.Windows.Forms.Padding(4);
            this.speedBox.Name = "speedBox";
            this.speedBox.Padding = new System.Windows.Forms.Padding(4);
            this.speedBox.Size = new System.Drawing.Size(533, 382);
            this.speedBox.TabIndex = 2;
            this.speedBox.TabStop = false;
            this.speedBox.Text = "Kilometers per hour:";
            // 
            // speedChart
            // 
            chartArea4.Name = "ChartArea1";
            this.speedChart.ChartAreas.Add(chartArea4);
            this.speedChart.Location = new System.Drawing.Point(8, 23);
            this.speedChart.Margin = new System.Windows.Forms.Padding(4);
            this.speedChart.Name = "speedChart";
            series4.BorderWidth = 10;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Name = "Speed";
            series4.XValueMember = "Time";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series4.YValueMembers = "Speed";
            this.speedChart.Series.Add(series4);
            this.speedChart.Size = new System.Drawing.Size(517, 351);
            this.speedChart.TabIndex = 0;
            this.speedChart.Text = "Speed chart";
            // 
            // bpmBox
            // 
            this.bpmBox.Controls.Add(this.bpmChart);
            this.bpmBox.Location = new System.Drawing.Point(16, 421);
            this.bpmBox.Margin = new System.Windows.Forms.Padding(4);
            this.bpmBox.Name = "bpmBox";
            this.bpmBox.Padding = new System.Windows.Forms.Padding(4);
            this.bpmBox.Size = new System.Drawing.Size(533, 382);
            this.bpmBox.TabIndex = 3;
            this.bpmBox.TabStop = false;
            this.bpmBox.Text = "Beats per minute:";
            // 
            // bpmChart
            // 
            chartArea5.Name = "ChartArea1";
            this.bpmChart.ChartAreas.Add(chartArea5);
            this.bpmChart.Location = new System.Drawing.Point(8, 23);
            this.bpmChart.Margin = new System.Windows.Forms.Padding(4);
            this.bpmChart.Name = "bpmChart";
            series5.BorderWidth = 10;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Name = "Beats per minute";
            series5.XValueMember = "Time";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series5.YValueMembers = "Beats per minutes";
            this.bpmChart.Series.Add(series5);
            this.bpmChart.Size = new System.Drawing.Size(517, 351);
            this.bpmChart.TabIndex = 1;
            this.bpmChart.Text = "beats per second";
            // 
            // sessionInfoBox
            // 
            this.sessionInfoBox.Controls.Add(this.requestedBox);
            this.sessionInfoBox.Controls.Add(this.actualBox);
            this.sessionInfoBox.Controls.Add(this.nameBox);
            this.sessionInfoBox.Controls.Add(this.sessionBox);
            this.sessionInfoBox.Controls.Add(this.timeBox);
            this.sessionInfoBox.Controls.Add(this.pulseBox);
            this.sessionInfoBox.Controls.Add(this.rpmInfoBox);
            this.sessionInfoBox.Controls.Add(this.energyInfoBox);
            this.sessionInfoBox.Controls.Add(this.distanceInfoBox);
            this.sessionInfoBox.Controls.Add(this.speedInfoBox);
            this.sessionInfoBox.Controls.Add(this.label18);
            this.sessionInfoBox.Controls.Add(this.label17);
            this.sessionInfoBox.Controls.Add(this.label16);
            this.sessionInfoBox.Controls.Add(this.label15);
            this.sessionInfoBox.Controls.Add(this.label14);
            this.sessionInfoBox.Controls.Add(this.label13);
            this.sessionInfoBox.Controls.Add(this.label12);
            this.sessionInfoBox.Controls.Add(this.label11);
            this.sessionInfoBox.Controls.Add(this.label10);
            this.sessionInfoBox.Controls.Add(this.label9);
            this.sessionInfoBox.Controls.Add(this.label8);
            this.sessionInfoBox.Controls.Add(this.label7);
            this.sessionInfoBox.Controls.Add(this.label6);
            this.sessionInfoBox.Controls.Add(this.label5);
            this.sessionInfoBox.Controls.Add(this.label4);
            this.sessionInfoBox.Controls.Add(this.label3);
            this.sessionInfoBox.Controls.Add(this.label2);
            this.sessionInfoBox.Controls.Add(this.label1);
            this.sessionInfoBox.Location = new System.Drawing.Point(557, 33);
            this.sessionInfoBox.Margin = new System.Windows.Forms.Padding(4);
            this.sessionInfoBox.Name = "sessionInfoBox";
            this.sessionInfoBox.Padding = new System.Windows.Forms.Padding(4);
            this.sessionInfoBox.Size = new System.Drawing.Size(533, 382);
            this.sessionInfoBox.TabIndex = 4;
            this.sessionInfoBox.TabStop = false;
            this.sessionInfoBox.Text = "Session info:";
            // 
            // requestedBox
            // 
            this.requestedBox.Location = new System.Drawing.Point(132, 272);
            this.requestedBox.Margin = new System.Windows.Forms.Padding(4);
            this.requestedBox.Name = "requestedBox";
            this.requestedBox.ReadOnly = true;
            this.requestedBox.Size = new System.Drawing.Size(79, 22);
            this.requestedBox.TabIndex = 37;
            // 
            // actualBox
            // 
            this.actualBox.Location = new System.Drawing.Point(132, 304);
            this.actualBox.Margin = new System.Windows.Forms.Padding(4);
            this.actualBox.Name = "actualBox";
            this.actualBox.ReadOnly = true;
            this.actualBox.Size = new System.Drawing.Size(79, 22);
            this.actualBox.TabIndex = 36;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(132, 16);
            this.nameBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(79, 22);
            this.nameBox.TabIndex = 35;
            // 
            // sessionBox
            // 
            this.sessionBox.Location = new System.Drawing.Point(132, 48);
            this.sessionBox.Margin = new System.Windows.Forms.Padding(4);
            this.sessionBox.Name = "sessionBox";
            this.sessionBox.ReadOnly = true;
            this.sessionBox.Size = new System.Drawing.Size(79, 22);
            this.sessionBox.TabIndex = 34;
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(132, 240);
            this.timeBox.Margin = new System.Windows.Forms.Padding(4);
            this.timeBox.Name = "timeBox";
            this.timeBox.ReadOnly = true;
            this.timeBox.Size = new System.Drawing.Size(79, 22);
            this.timeBox.TabIndex = 33;
            // 
            // pulseBox
            // 
            this.pulseBox.Location = new System.Drawing.Point(132, 80);
            this.pulseBox.Margin = new System.Windows.Forms.Padding(4);
            this.pulseBox.Name = "pulseBox";
            this.pulseBox.ReadOnly = true;
            this.pulseBox.Size = new System.Drawing.Size(79, 22);
            this.pulseBox.TabIndex = 32;
            // 
            // rpmInfoBox
            // 
            this.rpmInfoBox.Location = new System.Drawing.Point(132, 112);
            this.rpmInfoBox.Margin = new System.Windows.Forms.Padding(4);
            this.rpmInfoBox.Name = "rpmInfoBox";
            this.rpmInfoBox.ReadOnly = true;
            this.rpmInfoBox.Size = new System.Drawing.Size(79, 22);
            this.rpmInfoBox.TabIndex = 31;
            // 
            // energyInfoBox
            // 
            this.energyInfoBox.Location = new System.Drawing.Point(132, 208);
            this.energyInfoBox.Margin = new System.Windows.Forms.Padding(4);
            this.energyInfoBox.Name = "energyInfoBox";
            this.energyInfoBox.ReadOnly = true;
            this.energyInfoBox.Size = new System.Drawing.Size(79, 22);
            this.energyInfoBox.TabIndex = 30;
            // 
            // distanceInfoBox
            // 
            this.distanceInfoBox.Location = new System.Drawing.Point(132, 176);
            this.distanceInfoBox.Margin = new System.Windows.Forms.Padding(4);
            this.distanceInfoBox.Name = "distanceInfoBox";
            this.distanceInfoBox.ReadOnly = true;
            this.distanceInfoBox.Size = new System.Drawing.Size(79, 22);
            this.distanceInfoBox.TabIndex = 29;
            // 
            // speedInfoBox
            // 
            this.speedInfoBox.Location = new System.Drawing.Point(132, 144);
            this.speedInfoBox.Margin = new System.Windows.Forms.Padding(4);
            this.speedInfoBox.Name = "speedInfoBox";
            this.speedInfoBox.ReadOnly = true;
            this.speedInfoBox.Size = new System.Drawing.Size(79, 22);
            this.speedInfoBox.TabIndex = 28;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(220, 249);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 17);
            this.label18.TabIndex = 27;
            this.label18.Text = "MM:SS";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(220, 281);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 17);
            this.label17.TabIndex = 26;
            this.label17.Text = "Watt";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(220, 313);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 17);
            this.label16.TabIndex = 25;
            this.label16.Text = "Watt";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(220, 217);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 17);
            this.label15.TabIndex = 24;
            this.label15.Text = "Watt";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(220, 185);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 17);
            this.label14.TabIndex = 23;
            this.label14.Text = "kilometers";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(220, 153);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 17);
            this.label13.TabIndex = 22;
            this.label13.Text = "kilometers per hour";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(220, 121);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 17);
            this.label12.TabIndex = 21;
            this.label12.Text = "rounds per minute";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(220, 89);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "Beats per minute";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 313);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Actual power";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 281);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Requested power:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 249);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Time:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 217);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Energy:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 185);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Distance:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 153);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Speed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "RPM:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Session:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pulse:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naam:";
            // 
            // rpmBox
            // 
            this.rpmBox.Controls.Add(this.rpmChart);
            this.rpmBox.Location = new System.Drawing.Point(557, 421);
            this.rpmBox.Margin = new System.Windows.Forms.Padding(4);
            this.rpmBox.Name = "rpmBox";
            this.rpmBox.Padding = new System.Windows.Forms.Padding(4);
            this.rpmBox.Size = new System.Drawing.Size(533, 382);
            this.rpmBox.TabIndex = 5;
            this.rpmBox.TabStop = false;
            this.rpmBox.Text = "Rounds per minute:";
            // 
            // rpmChart
            // 
            chartArea6.Name = "ChartArea1";
            this.rpmChart.ChartAreas.Add(chartArea6);
            this.rpmChart.Location = new System.Drawing.Point(8, 23);
            this.rpmChart.Margin = new System.Windows.Forms.Padding(4);
            this.rpmChart.Name = "rpmChart";
            series6.BorderWidth = 10;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Name = "Rounds per minute";
            series6.XValueMember = "Time";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series6.YValueMembers = "Rounds per minutes";
            this.rpmChart.Series.Add(series6);
            this.rpmChart.Size = new System.Drawing.Size(517, 351);
            this.rpmChart.TabIndex = 2;
            this.rpmChart.Text = "rounds per minute";
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(0, 23);
            this.chatBox.Margin = new System.Windows.Forms.Padding(4);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(303, 671);
            this.chatBox.TabIndex = 3;
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(0, 703);
            this.messageBox.Margin = new System.Windows.Forms.Padding(4);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(303, 22);
            this.messageBox.TabIndex = 6;
            this.messageBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.messageBox_KeyPress);
            // 
            // chatArea
            // 
            this.chatArea.Controls.Add(this.sendButton);
            this.chatArea.Controls.Add(this.chatBox);
            this.chatArea.Controls.Add(this.messageBox);
            this.chatArea.Location = new System.Drawing.Point(1099, 33);
            this.chatArea.Margin = new System.Windows.Forms.Padding(4);
            this.chatArea.Name = "chatArea";
            this.chatArea.Padding = new System.Windows.Forms.Padding(4);
            this.chatArea.Size = new System.Drawing.Size(304, 770);
            this.chatArea.TabIndex = 5;
            this.chatArea.TabStop = false;
            this.chatArea.Text = "Chat:";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(0, 735);
            this.sendButton.Margin = new System.Windows.Forms.Padding(4);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(304, 28);
            this.sendButton.TabIndex = 7;
            this.sendButton.Text = "send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // PatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1419, 838);
            this.Controls.Add(this.chatArea);
            this.Controls.Add(this.sessionInfoBox);
            this.Controls.Add(this.rpmBox);
            this.Controls.Add(this.bpmBox);
            this.Controls.Add(this.speedBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PatientForm";
            this.Text = "Patient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.speedBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).EndInit();
            this.bpmBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bpmChart)).EndInit();
            this.sessionInfoBox.ResumeLayout(false);
            this.sessionInfoBox.PerformLayout();
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
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.GroupBox chatArea;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ToolStripMenuItem bicycleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem requestDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closePortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startTrainingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distanceTraining;
        private System.Windows.Forms.ToolStripMenuItem stopTrainingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox powerBox;
        private System.Windows.Forms.ToolStripMenuItem setPower;
        private System.Windows.Forms.ToolStripMenuItem energyBox;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox distanceBox;
        private System.Windows.Forms.ToolStripMenuItem confirmDistanceBox;
        private System.Windows.Forms.ToolStripMenuItem setTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox minuteBox;
        private System.Windows.Forms.ToolStripTextBox secondBox;
        private System.Windows.Forms.ToolStripMenuItem confirmTimeBox;
        public System.Windows.Forms.TextBox requestedBox;
        public System.Windows.Forms.TextBox actualBox;
        public System.Windows.Forms.TextBox nameBox;
        public System.Windows.Forms.TextBox sessionBox;
        public System.Windows.Forms.TextBox timeBox;
        public System.Windows.Forms.TextBox pulseBox;
        public System.Windows.Forms.TextBox rpmInfoBox;
        public System.Windows.Forms.TextBox energyInfoBox;
        public System.Windows.Forms.TextBox distanceInfoBox;
        public System.Windows.Forms.TextBox speedInfoBox;
        public System.Windows.Forms.DataVisualization.Charting.Chart speedChart;
        public Chart bpmChart;
        public Chart rpmChart;
    }
}

