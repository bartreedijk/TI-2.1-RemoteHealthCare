using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
