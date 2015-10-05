using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FietsClient
{
    public partial class DoctorForm : Form
    {
        private TcpConnection connection;
        private DoctorModel doctorModel;

        public DoctorForm(TcpConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
            doctorModel = DoctorModel.doctorModel;
            doctorModel.doctorform = this;
            doctorModel.tcpConnection = connection;
            DataHandler.IncomingErrorEvent += HandleError;
        }

        private void HandleError(string error)
        {
            switch (error)
            {
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void setDistanceButton_Click(object sender, EventArgs e)
        {
            int distance;
            Int32.TryParse(setDistanceBox.Text,out distance);
            connection.SendDistance(distance);
        }

        private void setTimeButton_Click(object sender, EventArgs e)
        {
            int minutes,seconds;
            Int32.TryParse(setTimeMinutesBox.Text, out minutes);
            Int32.TryParse(setTimeSecondsBox.Text, out seconds);
            connection.SendTime(minutes, seconds);
        }

        private void setPowerButton_Click(object sender, EventArgs e)
        {
            int power; 
            Int32.TryParse(setPowerBox.Text, out power);
            connection.SendPower(power);
        }

        private void messageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                messageButton_Click(sender, e);
            }
        }

        private void messageButton_Click(object sender, EventArgs e)
        {
            if (messageBox.Text != null)
            {
                string message = messageBox.Text;
                messageBox.Clear();
                connection.SendChatMessage(message);
            }
        }
    }
}
