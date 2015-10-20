using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FietsClient.Forms;
using FietsLibrary.JSONObjecten;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace FietsClient
{
    public partial class DoctorForm : Form
    {
        private DoctorModel doctorModel;
        public Forms.DoctorSummaryUC summaryUserControl { get; private set; }

        public DoctorForm(TcpConnection connection)
        {
            InitializeComponent();
            doctorModel = DoctorModel.doctorModel;
            doctorModel.doctorform = this;
            doctorModel.tcpConnection = connection;
            this.summaryUserControl = doctorSummaryUC1;
            DataHandler.IncomingErrorEvent += HandleError;
            connection.IncomingChatmessageEvent += new TcpConnection.ChatmassegeDelegate(printMessage);

        }

        private void HandleError(string error)
        {
            switch (error)
            {
                default:
                    break;
            }
        }

        private List<User> users = new List<User>();
        private void Form1_Load(object sender, EventArgs e)
        {
            users = doctorModel.requestUsers();
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
            if (messageBox.Text != null && doctorTabControl.SelectedTab.Name != "tabPageSummary")
            {
                String[] data = new String[2];
                data[0] = messageBox.Text;
                //current patient:
                data[1] = doctorTabControl.SelectedTab.Name;
                messageBox.Clear();

                doctorModel.tcpConnection.SendChatMessage(data);
            }

            else if (messageBox.Text != null && doctorTabControl.SelectedTab.Name == "tabPageSummary")
            {
                String[] data = new String[2];
                data[0] = "This is a broadcast: " + messageBox.Text + "\r\n";
                //all patients:
                for (int tabs = 1; tabs <= doctorTabControl.TabCount - 1; tabs++)
                {
                    doctorTabControl.SelectTab(tabs);
                    data[1] = doctorTabControl.SelectedTab.Name;
                    doctorModel.tcpConnection.SendChatMessage(data);
                }
                messageBox.Clear();

            }
        }

        private void printMessage(string[] data)
        {
            string finalMessage = data[0] + ":\t" + data[2] + "\r\n";
            chatBox.Invoke((MethodInvoker)delegate ()
           {
               chatBox.AppendText(finalMessage);
           });
        }

        public void AddSessionToTabcontrol(string patientID)
        {
            TabPage page = new TabPage("Patientsession " + patientID);
            page.Name = patientID;
            Forms.DoctorSessionUC sessionUC = new Forms.DoctorSessionUC(patientID);
            sessionUC.Name = "sessionUC" + patientID;
            doctorModel.doctorSessions.Add(patientID, sessionUC);
            doctorModel.doctorSessions.TryGetValue(patientID, out sessionUC);
            page.Controls.Add(sessionUC);
            doctorTabControl.TabPages.Add(page);

        }

        public void RemoveSessionFromTabcontrol(string patientID)
        {
            doctorTabControl.TabPages.RemoveByKey(patientID);
        }

        private void DoctorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            doctorModel.stopAskingData();
            doctorModel.tcpConnection.disconnect();
            Application.Exit();
        }

        private void nieuwePatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newPatient = new NewPatientForm(doctorModel.tcpConnection);
            newPatient.Show();
        }

        private List<DataPoint> speedPoints = new List<DataPoint>();
        private List<DataPoint> bpmPoints = new List<DataPoint>();
        private List<DataPoint> rpmPoints = new List<DataPoint>();
        private void selectSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get measurments
            List<Measurement> measurments = new List<Measurement>();
            User user = null;
            foreach (User userx in users)
            {
                user = userx;
                if (PatientBox.Text == user.id)
                {
                    List<Session> sessions = user.GetSessions();
                    foreach (Session session in sessions)
                    {
                        if (sessionsBox.Text == session.date.ToString())
                        {
                            measurments = session.session;
                        }
                    }
                }
            }
            //fill boxes

            summaryUserControl.sessionBox.Text = user.id;
            summaryUserControl.nameBox.Text = user.id;
            summaryUserControl.pulseBox.Text = measurments[measurments.Count - 1].bpm.ToString();
            summaryUserControl.rpmInfoBox.Text = measurments[measurments.Count - 1].rpm.ToString();
            summaryUserControl.speedInfoBox.Text = measurments[measurments.Count - 1].speed.ToString();
            summaryUserControl.distanceInfoBox.Text = measurments[measurments.Count - 1].distance.ToString();
            summaryUserControl.requestedBox.Text = measurments[measurments.Count - 1].requestedPower.ToString();
            summaryUserControl.energyInfoBox.Text = measurments[measurments.Count - 1].energy.ToString();
            summaryUserControl.timeBox.Text = measurments[measurments.Count - 1].time.ToString();
            summaryUserControl.actualBox.Text = measurments[measurments.Count - 1].actualPower.ToString();

            //fill speedpoints
            for (int i = 0; i < measurments.Count; i++)
            {
                speedPoints.Add(new DataPoint(measurments[i].time, measurments[i].speed));
            }
            //fill speedgraph
            summaryUserControl.speedChart.Series[0].Points.Clear();
            for (int i = 0; i < speedPoints.Count; i++)
                summaryUserControl.speedChart.Series[0].Points.Add(speedPoints[i]);
            summaryUserControl.speedChart.Update();

            //fill bpm
            for (int i = 0; i < measurments.Count; i++)
            {
                bpmPoints.Add(new DataPoint(measurments[i].time, measurments[i].bpm));
            }
            //fill bpmgraph
            summaryUserControl.bpmChart.Series[0].Points.Clear();
            for (int i = 0; i < bpmPoints.Count; i++)
                summaryUserControl.bpmChart.Series[0].Points.Add(bpmPoints[i]);
            summaryUserControl.bpmChart.Update();

            //fill rpm
            for (int i = 0; i < measurments.Count; i++)
            {
                rpmPoints.Add(new DataPoint(measurments[i].time, measurments[i].rpm));
            }
            //fill rpmgraph
            summaryUserControl.rpmChart.Series[0].Points.Clear();
            for (int i = 0; i < rpmPoints.Count; i++)
                summaryUserControl.rpmChart.Series[0].Points.Add(rpmPoints[i]);
            summaryUserControl.rpmChart.Update();
        }

        private void PatientBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (User user in users)
            {
                if (user.id == PatientBox.Text)
                    foreach (Session session in user.GetSessions())
                    {
                        sessionsBox.Items.Add(session.date.ToString());
                    }
            }
        }

        private void loadUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            users = doctorModel.tcpConnection.users;
            foreach (User user in users)
            {
                PatientBox.Items.Add(user.id);
            }
        }
    }
}
