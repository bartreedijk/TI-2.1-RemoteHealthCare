using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FietsLibrary.JSONObjecten;

namespace FietsClient.Forms
{
    public partial class DoctorSessionUC : UserControl
    {
        public string patientID { get; private set; }
        public DoctorSessionUC(string patientID)
        {
            InitializeComponent();
            this.patientID = patientID;
        }

        private void setDistanceButton_Click(object sender, EventArgs e)
        {
            int distance;
            Int32.TryParse(setDistanceBox.Text, out distance);
            DoctorModel.doctorModel.tcpConnection.SendDistance(distance);
        }

        private void setTimeButton_Click(object sender, EventArgs e)
        {
            int minutes, seconds;
            Int32.TryParse(setTimeMinutesBox.Text, out minutes);
            Int32.TryParse(setTimeSecondsBox.Text, out seconds);
            DoctorModel.doctorModel.tcpConnection.SendTime(minutes, seconds);
        }

        private void setPowerButton_Click(object sender, EventArgs e)
        {
            int power;
            Int32.TryParse(setPowerBox.Text, out power);
            DoctorModel.doctorModel.tcpConnection.SendPower(power);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoctorModel.doctorModel.tcpConnection.SendStartStopSession(true, patientID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoctorModel.doctorModel.tcpConnection.SendStartStopSession(false, patientID);
        }

        public void ClearOldSession()
        {
            if (InvokeRequired)
                Invoke(new Action(() => ClearOldSession()));
            else
            {
                speedPoints.Clear();
                bpmPoints.Clear();
                rpmPoints.Clear();
                pulseBox.Clear();
                rpmInfoBox.Clear();
                speedInfoBox.Clear();
                distanceInfoBox.Clear();
                requestedBox.Clear();
                energyInfoBox.Clear();
                timeBox.Clear();
                actualBox.Clear();
            }
            
        }

        private List<DataPoint> speedPoints = new List<DataPoint>();
        private List<DataPoint> bpmPoints = new List<DataPoint>();
        private List<DataPoint> rpmPoints = new List<DataPoint>();

        public void HandleSessionBikeData(Measurement data)
        {

            if (InvokeRequired)
            {
                Invoke((new Action(() => HandleSessionBikeData(data))));
            }
            else
            {
                //fill fields
                pulseBox.Text = data.pulse.ToString();
                rpmInfoBox.Text = data.rpm.ToString();
                speedInfoBox.Text = data.speed.ToString();
                distanceInfoBox.Text = data.distance.ToString();
                requestedBox.Text = data.requestedPower.ToString();
                energyInfoBox.Text = data.energy.ToString();
                timeBox.Text = data.time.ToString();
                actualBox.Text = data.actualPower.ToString();

                //fill graph speed
                this.speedChart.Series[0].Points.Clear();
                for (int i = 0; i < speedPoints.Count; i++)
                    this.speedChart.Series[0].Points.Add(speedPoints[i]);
                this.speedChart.Update();

                //fill graph pulse
                this.bpmChart.Series[0].Points.Clear();
                for (int i = 0; i < bpmPoints.Count; i++)
                    this.bpmChart.Series[0].Points.Add(bpmPoints[i]);
                this.bpmChart.Update();

                //fill graph rpm
                this.rpmChart.Series[0].Points.Clear();
                for (int i = 0; i < rpmPoints.Count; i++)
                    this.rpmChart.Series[0].Points.Add(rpmPoints[i]);
                this.rpmChart.Update();
            }
        }
    }
}
