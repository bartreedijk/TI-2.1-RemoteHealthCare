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

        private void Form1_Load(object sender, EventArgs e)
        {

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
                data[0] = "This is a broadcast: " + messageBox.Text;
                //all patients:
                for (int tabs = 1; tabs <= doctorTabControl.TabCount -1; tabs++)
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
            string finalMessage = "\r\n" + data[0] + ":\t" + data[2];
            chatBox.Invoke((MethodInvoker) delegate ()
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
    }
}
