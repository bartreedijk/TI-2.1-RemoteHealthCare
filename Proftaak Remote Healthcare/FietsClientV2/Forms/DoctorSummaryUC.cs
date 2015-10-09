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
    public partial class DoctorSummaryUC : UserControl
    {
        public DoctorSummaryUC()
        {
            InitializeComponent();
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

    }
}
