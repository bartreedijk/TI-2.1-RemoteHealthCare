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
using FietsLibrary.JSONObjecten;
using FietsLibrary;
using System.Windows.Forms.DataVisualization.Charting;

namespace FietsClient
{
    public partial class PatientForm : Form
    {
        public TcpConnection _connection { get; private set; }
        private PatientModel patientModel;

        public PatientForm(TcpConnection connection)
        {
            this._connection = connection;
            InitializeComponent();
            patientModel = PatientModel.patientModel;
            patientModel.patientform = this;
            DataHandler.IncomingErrorEvent += HandleError; //initialize event

            _connection.IncomingChatmessageEvent += new TcpConnection.ChatmassegeDelegate(printMessage);

            //TIJDELIJK STUK CODE OM MESSAGE TE TESTEN
            //_connection.SendString("6|TOM|TOM|Je bent een homo");
            //Console.WriteLine("Bericht versturen");
            //EINDE TESTCODE
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
            patientModel.startAskingData();
        }

        private void closePortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patientModel.closeComPort();
        }

        private void openPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patientModel.startComPort(toolStripComboBox1.SelectedItem.ToString());
            requestDataToolStripMenuItem.Enabled = true;
            closePortToolStripMenuItem.Enabled = true;
        }

        private void confirmDistanceBox_Click(object sender, EventArgs e)
        {
            int n;
            if (patientModel.askdata)
            {
                MessageBox.Show("Er is nog een sessie bezig, deze moet eerst gestopt worden");
            }
            else if (int.TryParse(distanceBox.Text, out n))
            {
                patientModel.setDistanceMode(distanceBox.Text);
                this.label19.Text = "Huidige sessie: Afstand: " + n;
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
	    if (patientModel.askdata)
            {
                MessageBox.Show("Er is nog een sessie bezig, deze moet eerst gestopt worden");
            }
            else if (isNumericM)
            {
                if (isNumericS)
                {
                    patientModel.setTimeMode($"{ minutes:00}{seconds:00}");
                    this.label19.Text = "Huidige sessie: Tijd: " + minutes + ":" + seconds;
                }
                else MessageBox.Show("Minutes is not a valid number.");
            }
            else MessageBox.Show("Seconds is not a valid number.");

        }

        private void stopTrainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patientModel.reset();
        }

        private void setPower_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(powerBox.Text, out n))
                patientModel.setPower(powerBox.Text);
            else
                MessageBox.Show("Power is not a valid number.");
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (messageBox.Text != null && patientModel.CurrentDoctorID != "")
            {
                String[] data = new String[2];
                data[0] = messageBox.Text;
                //receiver ID of doctor
                data[1] = patientModel.CurrentDoctorID;
                messageBox.Clear();
                _connection.SendChatMessage(data);
            }
        }

        private void messageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                sendButton_Click(sender, e);
            }
            
        }


        private void MenuSessionItems()
        {
            foreach (Session s in _connection.currentData.GetSessions())
            {
                selectSessionToolStripMenuItem.DropDownItems.Add(
                    new ToolStripMenuItem(s.id.ToString(), null, delegate
                    {
                        patientModel.stopAskingData();
                        this.sessionBox.Text = s.id.ToString();
                        this.nameBox.Text = _connection.userID;
                        //get measurments
                        List<Measurement> measurments = s.measurements;
                        //fill boxes

                        this.pulseBox.Text = measurments[measurments.Count - 1].pulse.ToString();
                        this.rpmInfoBox.Text = measurments[measurments.Count - 1].rpm.ToString();
                        this.speedInfoBox.Text = measurments[measurments.Count - 1].speed.ToString();
                        this.distanceInfoBox.Text = measurments[measurments.Count - 1].distance.ToString();
                        this.requestedBox.Text = measurments[measurments.Count - 1].requestedPower.ToString();
                        this.energyInfoBox.Text = measurments[measurments.Count - 1].energy.ToString();
                        this.timeBox.Text = measurments[measurments.Count - 1].time.ToString();
                        this.actualBox.Text = measurments[measurments.Count - 1].actualPower.ToString();

                        //fill speedpoints
                        patientModel.speedPoints = new List<DataPoint>();
                        for (int i = 0; i < measurments.Count; i++)
                        {
                            patientModel.speedPoints.Add(new DataPoint(measurments[i].time, measurments[i].speed));
                        }
                        //fill speedgraph
                        this.speedChart.Series[0].Points.Clear();
                        for (int i = 0; i < patientModel.speedPoints.Count; i++)
                            this.speedChart.Series[0].Points.Add(patientModel.speedPoints[i]);
                        this.speedChart.Update();

                        //fill bpm
                        patientModel.bpmPoints = new List<DataPoint>();
                        for (int i = 0; i < measurments.Count; i++)
                        {
                            patientModel.bpmPoints.Add(new DataPoint(measurments[i].time, measurments[i].pulse));
                        }
                        //fill bpmgraph
                        this.bpmChart.Series[0].Points.Clear();
                        for (int i = 0; i < patientModel.bpmPoints.Count; i++)
                            this.bpmChart.Series[0].Points.Add(patientModel.bpmPoints[i]);
                        this.bpmChart.Update();

                        //fill rpm
                        patientModel.rpmPoints = new List<DataPoint>();
                        for (int i = 0; i < measurments.Count; i++)
                        {
                            patientModel.rpmPoints.Add(new DataPoint(measurments[i].time, measurments[i].rpm));
                        }
                        //fill rpmgraph
                        this.rpmChart.Series[0].Points.Clear();
                        for (int i = 0; i < patientModel.rpmPoints.Count; i++)
                            this.rpmChart.Series[0].Points.Add(patientModel.rpmPoints[i]);
                        this.rpmChart.Update();
                    })
                );

            }
        }
        private void printMessage(string[] data)
        {
	    if (data[2].StartsWith("This is a broadcast: "))
            {
                string finalMessage = data[2] + "\r\n";

                chatBox.Invoke((MethodInvoker)delegate ()
                {
                    chatBox.AppendText(finalMessage);
                });
            }

            else
            {
                if (data[0] != _connection.userID)
                    patientModel.CurrentDoctorID = data[0];
                string finalMessage = data[0] + ":\t" + data[2] + "\r\n";

                chatBox.Invoke((MethodInvoker)delegate ()
                {
                    chatBox.AppendText(finalMessage);
                });
            }

        }

        private void PatientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _connection.disconnect();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _connection.StartNewSession();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _connection.StopSessoin();
        }
    }
}
