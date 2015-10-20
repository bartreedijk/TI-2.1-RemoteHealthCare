namespace FietsClient.Forms
{
    partial class DoctorSessionUC
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rpmChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bpmBox = new System.Windows.Forms.GroupBox();
            this.bpmChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.speedBox = new System.Windows.Forms.GroupBox();
            this.speedChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sessionInfoBox = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.setTimeSecondsBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.setPowerBox = new System.Windows.Forms.TextBox();
            this.setTimeMinutesBox = new System.Windows.Forms.TextBox();
            this.setDistanceBox = new System.Windows.Forms.TextBox();
            this.setPowerButton = new System.Windows.Forms.Button();
            this.requestedBox = new System.Windows.Forms.TextBox();
            this.setTimeButton = new System.Windows.Forms.Button();
            this.setDistanceButton = new System.Windows.Forms.Button();
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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rpmChart)).BeginInit();
            this.bpmBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bpmChart)).BeginInit();
            this.speedBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).BeginInit();
            this.sessionInfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rpmChart);
            this.groupBox1.Location = new System.Drawing.Point(411, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 310);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rounds per minute:";
            // 
            // rpmChart
            // 
            chartArea10.Name = "ChartArea1";
            this.rpmChart.ChartAreas.Add(chartArea10);
            this.rpmChart.Location = new System.Drawing.Point(6, 19);
            this.rpmChart.Name = "rpmChart";
            series10.BorderWidth = 10;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Name = "Rounds per minute";
            series10.XValueMember = "Time";
            series10.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series10.YValueMembers = "Rounds per minutes";
            this.rpmChart.Series.Add(series10);
            this.rpmChart.Size = new System.Drawing.Size(388, 285);
            this.rpmChart.TabIndex = 2;
            this.rpmChart.Text = "rounds per minute";
            // 
            // bpmBox
            // 
            this.bpmBox.Controls.Add(this.bpmChart);
            this.bpmBox.Location = new System.Drawing.Point(5, 320);
            this.bpmBox.Name = "bpmBox";
            this.bpmBox.Size = new System.Drawing.Size(400, 310);
            this.bpmBox.TabIndex = 8;
            this.bpmBox.TabStop = false;
            this.bpmBox.Text = "Beats per minute:";
            // 
            // bpmChart
            // 
            chartArea11.Name = "ChartArea1";
            this.bpmChart.ChartAreas.Add(chartArea11);
            this.bpmChart.Location = new System.Drawing.Point(6, 19);
            this.bpmChart.Name = "bpmChart";
            series11.BorderWidth = 10;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Name = "Beats per minute";
            series11.XValueMember = "Time";
            series11.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series11.YValueMembers = "Beats per minutes";
            this.bpmChart.Series.Add(series11);
            this.bpmChart.Size = new System.Drawing.Size(388, 285);
            this.bpmChart.TabIndex = 1;
            this.bpmChart.Text = "beats per second";
            // 
            // speedBox
            // 
            this.speedBox.Controls.Add(this.speedChart);
            this.speedBox.Location = new System.Drawing.Point(3, 3);
            this.speedBox.Name = "speedBox";
            this.speedBox.Size = new System.Drawing.Size(400, 310);
            this.speedBox.TabIndex = 11;
            this.speedBox.TabStop = false;
            this.speedBox.Text = "Kilometers per hour:";
            // 
            // speedChart
            // 
            chartArea12.Name = "ChartArea1";
            this.speedChart.ChartAreas.Add(chartArea12);
            this.speedChart.Location = new System.Drawing.Point(6, 19);
            this.speedChart.Name = "speedChart";
            series12.BorderWidth = 10;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Name = "Speed";
            series12.XValueMember = "Time";
            series12.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series12.YValueMembers = "Speed";
            this.speedChart.Series.Add(series12);
            this.speedChart.Size = new System.Drawing.Size(388, 285);
            this.speedChart.TabIndex = 0;
            this.speedChart.Text = "Speed chart";
            // 
            // sessionInfoBox
            // 
            this.sessionInfoBox.Controls.Add(this.button2);
            this.sessionInfoBox.Controls.Add(this.setTimeSecondsBox);
            this.sessionInfoBox.Controls.Add(this.button1);
            this.sessionInfoBox.Controls.Add(this.setPowerBox);
            this.sessionInfoBox.Controls.Add(this.setTimeMinutesBox);
            this.sessionInfoBox.Controls.Add(this.setDistanceBox);
            this.sessionInfoBox.Controls.Add(this.setPowerButton);
            this.sessionInfoBox.Controls.Add(this.requestedBox);
            this.sessionInfoBox.Controls.Add(this.setTimeButton);
            this.sessionInfoBox.Controls.Add(this.setDistanceButton);
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
            this.sessionInfoBox.Location = new System.Drawing.Point(411, 3);
            this.sessionInfoBox.Name = "sessionInfoBox";
            this.sessionInfoBox.Size = new System.Drawing.Size(400, 310);
            this.sessionInfoBox.TabIndex = 10;
            this.sessionInfoBox.TabStop = false;
            this.sessionInfoBox.Text = "Session info:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(99, 281);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 41;
            this.button2.Text = "Stop sessie";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // setTimeSecondsBox
            // 
            this.setTimeSecondsBox.Location = new System.Drawing.Point(342, 197);
            this.setTimeSecondsBox.Margin = new System.Windows.Forms.Padding(2);
            this.setTimeSecondsBox.Name = "setTimeSecondsBox";
            this.setTimeSecondsBox.Size = new System.Drawing.Size(38, 20);
            this.setTimeSecondsBox.TabIndex = 90;
            this.setTimeSecondsBox.Text = "SS";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Start sessie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // setPowerBox
            // 
            this.setPowerBox.Location = new System.Drawing.Point(304, 223);
            this.setPowerBox.Margin = new System.Windows.Forms.Padding(2);
            this.setPowerBox.Name = "setPowerBox";
            this.setPowerBox.Size = new System.Drawing.Size(76, 20);
            this.setPowerBox.TabIndex = 89;
            // 
            // setTimeMinutesBox
            // 
            this.setTimeMinutesBox.Location = new System.Drawing.Point(304, 197);
            this.setTimeMinutesBox.Margin = new System.Windows.Forms.Padding(2);
            this.setTimeMinutesBox.Name = "setTimeMinutesBox";
            this.setTimeMinutesBox.Size = new System.Drawing.Size(38, 20);
            this.setTimeMinutesBox.TabIndex = 88;
            this.setTimeMinutesBox.Text = "MM";
            // 
            // setDistanceBox
            // 
            this.setDistanceBox.Location = new System.Drawing.Point(305, 142);
            this.setDistanceBox.Margin = new System.Windows.Forms.Padding(2);
            this.setDistanceBox.Name = "setDistanceBox";
            this.setDistanceBox.Size = new System.Drawing.Size(76, 20);
            this.setDistanceBox.TabIndex = 87;
            // 
            // setPowerButton
            // 
            this.setPowerButton.Location = new System.Drawing.Point(224, 219);
            this.setPowerButton.Name = "setPowerButton";
            this.setPowerButton.Size = new System.Drawing.Size(75, 23);
            this.setPowerButton.TabIndex = 86;
            this.setPowerButton.Text = "Set power";
            this.setPowerButton.UseVisualStyleBackColor = true;
            this.setPowerButton.Click += new System.EventHandler(this.setPowerButton_Click);
            // 
            // requestedBox
            // 
            this.requestedBox.Location = new System.Drawing.Point(99, 221);
            this.requestedBox.Name = "requestedBox";
            this.requestedBox.ReadOnly = true;
            this.requestedBox.Size = new System.Drawing.Size(60, 20);
            this.requestedBox.TabIndex = 37;
            // 
            // setTimeButton
            // 
            this.setTimeButton.Location = new System.Drawing.Point(224, 195);
            this.setTimeButton.Name = "setTimeButton";
            this.setTimeButton.Size = new System.Drawing.Size(75, 23);
            this.setTimeButton.TabIndex = 85;
            this.setTimeButton.Text = "Set time";
            this.setTimeButton.UseVisualStyleBackColor = true;
            this.setTimeButton.Click += new System.EventHandler(this.setTimeButton_Click);
            // 
            // setDistanceButton
            // 
            this.setDistanceButton.Location = new System.Drawing.Point(224, 141);
            this.setDistanceButton.Name = "setDistanceButton";
            this.setDistanceButton.Size = new System.Drawing.Size(75, 23);
            this.setDistanceButton.TabIndex = 84;
            this.setDistanceButton.Text = "Set distance";
            this.setDistanceButton.UseVisualStyleBackColor = true;
            this.setDistanceButton.Click += new System.EventHandler(this.setDistanceButton_Click);
            // 
            // actualBox
            // 
            this.actualBox.Location = new System.Drawing.Point(99, 247);
            this.actualBox.Name = "actualBox";
            this.actualBox.ReadOnly = true;
            this.actualBox.Size = new System.Drawing.Size(60, 20);
            this.actualBox.TabIndex = 36;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(99, 13);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(60, 20);
            this.nameBox.TabIndex = 35;
            // 
            // sessionBox
            // 
            this.sessionBox.Location = new System.Drawing.Point(99, 39);
            this.sessionBox.Name = "sessionBox";
            this.sessionBox.ReadOnly = true;
            this.sessionBox.Size = new System.Drawing.Size(60, 20);
            this.sessionBox.TabIndex = 34;
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(99, 195);
            this.timeBox.Name = "timeBox";
            this.timeBox.ReadOnly = true;
            this.timeBox.Size = new System.Drawing.Size(60, 20);
            this.timeBox.TabIndex = 33;
            // 
            // pulseBox
            // 
            this.pulseBox.Location = new System.Drawing.Point(99, 65);
            this.pulseBox.Name = "pulseBox";
            this.pulseBox.ReadOnly = true;
            this.pulseBox.Size = new System.Drawing.Size(60, 20);
            this.pulseBox.TabIndex = 32;
            // 
            // rpmInfoBox
            // 
            this.rpmInfoBox.Location = new System.Drawing.Point(99, 91);
            this.rpmInfoBox.Name = "rpmInfoBox";
            this.rpmInfoBox.ReadOnly = true;
            this.rpmInfoBox.Size = new System.Drawing.Size(60, 20);
            this.rpmInfoBox.TabIndex = 31;
            // 
            // energyInfoBox
            // 
            this.energyInfoBox.Location = new System.Drawing.Point(99, 169);
            this.energyInfoBox.Name = "energyInfoBox";
            this.energyInfoBox.ReadOnly = true;
            this.energyInfoBox.Size = new System.Drawing.Size(60, 20);
            this.energyInfoBox.TabIndex = 30;
            // 
            // distanceInfoBox
            // 
            this.distanceInfoBox.Location = new System.Drawing.Point(99, 143);
            this.distanceInfoBox.Name = "distanceInfoBox";
            this.distanceInfoBox.ReadOnly = true;
            this.distanceInfoBox.Size = new System.Drawing.Size(60, 20);
            this.distanceInfoBox.TabIndex = 29;
            // 
            // speedInfoBox
            // 
            this.speedInfoBox.Location = new System.Drawing.Point(99, 117);
            this.speedInfoBox.Name = "speedInfoBox";
            this.speedInfoBox.ReadOnly = true;
            this.speedInfoBox.Size = new System.Drawing.Size(60, 20);
            this.speedInfoBox.TabIndex = 28;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(164, 197);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 13);
            this.label18.TabIndex = 27;
            this.label18.Text = "MM:SS";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(164, 223);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 13);
            this.label17.TabIndex = 26;
            this.label17.Text = "Watt";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(164, 249);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Watt";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(164, 171);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "Watt";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(164, 145);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "kilometers";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(164, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "kilometers per hour";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(164, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "rounds per minute";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(164, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Beats per minute";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Actual power";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Requested power:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Time:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Energy:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Distance:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Speed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "RPM:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Session:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pulse:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naam:";
            // 
            // DoctorSessionUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bpmBox);
            this.Controls.Add(this.speedBox);
            this.Controls.Add(this.sessionInfoBox);
            this.Name = "DoctorSessionUC";
            this.Size = new System.Drawing.Size(822, 640);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rpmChart)).EndInit();
            this.bpmBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bpmChart)).EndInit();
            this.speedBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedChart)).EndInit();
            this.sessionInfoBox.ResumeLayout(false);
            this.sessionInfoBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataVisualization.Charting.Chart rpmChart;
        private System.Windows.Forms.GroupBox bpmBox;
        public System.Windows.Forms.DataVisualization.Charting.Chart bpmChart;
        private System.Windows.Forms.GroupBox speedBox;
        public System.Windows.Forms.DataVisualization.Charting.Chart speedChart;
        private System.Windows.Forms.GroupBox sessionInfoBox;
        public System.Windows.Forms.TextBox setTimeSecondsBox;
        public System.Windows.Forms.TextBox setPowerBox;
        public System.Windows.Forms.TextBox setTimeMinutesBox;
        public System.Windows.Forms.TextBox setDistanceBox;
        private System.Windows.Forms.Button setPowerButton;
        public System.Windows.Forms.TextBox requestedBox;
        private System.Windows.Forms.Button setTimeButton;
        private System.Windows.Forms.Button setDistanceButton;
        public System.Windows.Forms.TextBox actualBox;
        public System.Windows.Forms.TextBox nameBox;
        public System.Windows.Forms.TextBox sessionBox;
        public System.Windows.Forms.TextBox timeBox;
        public System.Windows.Forms.TextBox pulseBox;
        public System.Windows.Forms.TextBox rpmInfoBox;
        public System.Windows.Forms.TextBox energyInfoBox;
        public System.Windows.Forms.TextBox distanceInfoBox;
        public System.Windows.Forms.TextBox speedInfoBox;
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
