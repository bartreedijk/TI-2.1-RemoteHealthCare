using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FietsClientV2
{
    public partial class PatientForm : Form
    {
        private PatientModel patienModel;
        public PatientForm()
        {
            InitializeComponent();
            patienModel = PatientModel.patientModel;
            patienModel.patientform = this;
            DataHandler.IncomingErrorEvent += HandleError; //initialize event
        }

        private void HandleError(string error)
        {
            switch (error)
            {
                case "WrongComPort":
                    toolStripComboBox1.Text = "";
                    MessageBox.Show("ERROR: Comport not initialized... trying to close the comport", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "NotConnectedToBike":
                    MessageBox.Show("ERROR: Not connected to bike.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            toolStripComboBox1.Items.AddRange(ports);
        }

        private void requestDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patienModel.startAskingData();
        }

        private void closePortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patienModel.closeComPort();
        }

        private void openPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patienModel.startComPort(toolStripComboBox1.SelectedItem.ToString());
            requestDataToolStripMenuItem.Enabled = true;
            closePortToolStripMenuItem.Enabled = true;
        }

        private void confirmDistanceBox_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(distanceBox.Text, out n))
            {
                patienModel.setDistanceMode(distanceBox.Text);
            }
            else
            {
                MessageBox.Show("Distance is not a valid number.");
            }
        }

        private void confirmTimeBox_Click(object sender, EventArgs e)
        {
            int minutes, seconds;
            bool isNumericS = int.TryParse(minuteBox.Text, out minutes);
            bool isNumericM = int.TryParse(secondBox.Text, out seconds);

            if (isNumericM)
            {
                if (isNumericS)
                    patienModel.setTimeMode(minutes + ":" + seconds);
                else MessageBox.Show("Minutes is not a valid number.");
            }
            else MessageBox.Show("Seconds is not a valid number.");
        }

        private void stopTrainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patienModel.reset();
        }

        private void setPower_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(powerBox.Text, out n))
                patienModel.setPower(powerBox.Text);
            else
                MessageBox.Show("Power is not a valid number.");
        }
    }
}
