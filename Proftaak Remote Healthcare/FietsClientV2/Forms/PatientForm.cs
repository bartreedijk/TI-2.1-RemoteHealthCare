using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FietsClient.JSONObjecten;
using System.Windows.Forms.DataVisualization.Charting;

namespace FietsClient
{
    public partial class PatientForm : Form
    {
        private TcpConnection _connection;
        private PatientModel patienModel;

        public PatientForm(TcpConnection connection)
        {
            this._connection = connection;
            InitializeComponent();
            patienModel = PatientModel.patientModel;
            patienModel.patientform = this;
            DataHandler.IncomingErrorEvent += HandleError; //initialize event

            _connection.IncomingChatmessageEvent += new TcpConnection.ChatmassegeDelegate(printMessage);
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
            MenuSessionItems();
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

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (messageBox.Text != null)
            {
                string message = messageBox.Text;
                messageBox.Clear();
                _connection.SendChatMessage(message);
            }
        }

        private void messageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sendButton_Click(sender, e);
        }


        private void MenuSessionItems()
        {
            foreach (Session s in _connection.currentData.GetSessions())
            {
                selectSessionToolStripMenuItem.DropDownItems.Add(
                    new ToolStripMenuItem(s.id.ToString(), null, delegate
                    {
                        this.sessionBox.Text = s.id.ToString();
                        this.nameBox.Text = _connection.userID;
                        //get measurments
                        List<Measurement> measurments = s.session;
                        //fill boxes

                        this.pulseBox.Text = measurments[measurments.Count - 1].bpm.ToString();
                        this.rpmInfoBox.Text = measurments[measurments.Count - 1].rpm.ToString();
                        this.speedInfoBox.Text = measurments[measurments.Count - 1].speed.ToString();
                        this.distanceInfoBox.Text = measurments[measurments.Count - 1].distance.ToString();
                        this.requestedBox.Text = measurments[measurments.Count - 1].requestedPower.ToString();
                        this.energyInfoBox.Text = measurments[measurments.Count - 1].energy.ToString();
                        this.timeBox.Text = measurments[measurments.Count - 1].time.ToString();
                        this.actualBox.Text = measurments[measurments.Count - 1].actualPower.ToString();

                        //fill speedpoints
                        patienModel.speedPoints = new List<DataPoint>();
                        for (int i = 0; i < measurments.Count; i++)
                        {
                            patienModel.speedPoints.Add(new DataPoint(measurments[i].time, measurments[i].speed));
                        }
                        //fill speedgraph
                        this.speedChart.Series[0].Points.Clear();
                        for (int i = 0; i < patienModel.speedPoints.Count; i++)
                            this.speedChart.Series[0].Points.Add(patienModel.speedPoints[i]);
                        this.speedChart.Update();

                        //fill bpm
                        patienModel.bpmPoints = new List<DataPoint>();
                        for (int i = 0; i < measurments.Count; i++)
                        {
                            patienModel.bpmPoints.Add(new DataPoint(measurments[i].time, measurments[i].bpm));
                        }
                        //fill bpmgraph
                        this.bpmChart.Series[0].Points.Clear();
                        for (int i = 0; i < patienModel.bpmPoints.Count; i++)
                            this.bpmChart.Series[0].Points.Add(patienModel.bpmPoints[i]);
                        this.bpmChart.Update();

                        //fill rpm
                        patienModel.rpmPoints = new List<DataPoint>();
                        for (int i = 0; i < measurments.Count; i++)
                        {
                            patienModel.rpmPoints.Add(new DataPoint(measurments[i].time, measurments[i].rpm));
                        }
                        //fill rpmgraph
                        this.rpmChart.Series[0].Points.Clear();
                        for (int i = 0; i < patienModel.rpmPoints.Count; i++)
                            this.rpmChart.Series[0].Points.Add(patienModel.rpmPoints[i]);
                        this.rpmChart.Update();
                    })
                );

            }
        }
        private void printMessage(string[] data)
        {

            string finalMessage = data[1] + ":\t\t" + data[3] + "\r\n";
            chatBox.AppendText(finalMessage);
        }
    }
}
