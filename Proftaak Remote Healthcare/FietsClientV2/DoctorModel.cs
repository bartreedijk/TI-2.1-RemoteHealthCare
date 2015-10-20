using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Measurement = FietsLibrary.JSONObjecten.Measurement;
using FietsLibrary.JSONObjecten;
using FietsLibrary;

namespace FietsClient
{
    class DoctorModel
    {

        private static DoctorModel _doctorModel;
        public DoctorForm doctorform { get; set; }

        public static DoctorModel doctorModel { get { return _doctorModel ?? (_doctorModel = new DoctorModel()); } }
        public TcpConnection tcpConnection { get; set; }
        private Thread receiveDataThread;

        public List<string> onlinePatients { get; set; } = new List<string>();
        public Dictionary<string, Forms.DoctorSessionUC> doctorSessions { get; set; } = new Dictionary<string, Forms.DoctorSessionUC>();



        private DoctorModel()
        {
            startAskingData();
        }

        public void startAskingData()
        {
            receiveDataThread = new Thread(() => receiveDataThreadLoop());
            receiveDataThread.Start();
        }

        public void stopAskingData()
        {
            receiveDataThread.Abort();
        }

        internal List<User> requestUsers()
        {
            tcpConnection.requestUsers();
            return tcpConnection.users;
        }

        private void receiveDataThreadLoop()
        {
            while (true)
            {
                Thread.Sleep(1000);
                //receive data and display in through handle bike data
                //HandleBikeData(tcpConnection.currentData.GetSessions().Last().GetLastMeasurement());
                CheckOnlineUsersUpdated(); //misschien alleen als er wat binnenkomt? ff over nadenken nog
            }
        }

        public void CheckOnlineUsersUpdated()
        {
            tcpConnection.SendGetActivePatients();
            if (onlinePatients.Count != doctorSessions.Count || true)
            {
                // ruim eerst alle doctorSessions op die niet van toepassing zijn
                List<string> temp = doctorSessions.Keys.ToList();
                foreach (string str in temp)
                {
                    if (!(onlinePatients.Any(s => str.Contains(s))))
                    {
                        doctorform.Invoke(new Action(() => doctorform.RemoveSessionFromTabcontrol(str)));
                        doctorform.Invoke(new Action(() => doctorSessions.Remove(str)));
                    }
                    //onlinePatients.Find(username => username.Equals(str));

                }

                //voeg een onlinePatient toe aan een doctorSession
                foreach (string onlinePatient in onlinePatients)
                {
                    if (!(doctorSessions.Keys.Any(s => onlinePatient.Contains(s))))
                        doctorform.Invoke(new Action(() => doctorform.AddSessionToTabcontrol(onlinePatient)));
                }
            }
        }

        //display values
        private List<DataPoint> speedPoints = new List<DataPoint>();
        private List<DataPoint> bpmPoints = new List<DataPoint>();
        private List<DataPoint> rpmPoints = new List<DataPoint>();
        private void HandleBikeData(Measurement data)
        {

            if (doctorform.InvokeRequired)
            {
                doctorform.Invoke((new Action(() => HandleBikeData(data))));
            }
            else
            {
                //fill fields
                doctorform.summaryUserControl.pulseBox.Text = data.pulse.ToString();
                doctorform.summaryUserControl.rpmInfoBox.Text = data.rpm.ToString();
                doctorform.summaryUserControl.speedInfoBox.Text = data.speed.ToString();
                doctorform.summaryUserControl.distanceInfoBox.Text = data.distance.ToString();
                doctorform.summaryUserControl.requestedBox.Text = data.requestedPower.ToString();
                doctorform.summaryUserControl.energyInfoBox.Text = data.energy.ToString();
                doctorform.summaryUserControl.timeBox.Text = data.time.ToString();
                doctorform.summaryUserControl.actualBox.Text = data.actualPower.ToString();

                //fill graph speed
                speedPoints.Add(new DataPoint(Convert.ToDateTime(data.time.ToString()).ToOADate(), Convert.ToDouble(data.speed.ToString())));
                doctorform.summaryUserControl.speedChart.Series[0].Points.Clear();
                for (int i = 0; i < speedPoints.Count; i++)
                    doctorform.summaryUserControl.speedChart.Series[0].Points.Add(speedPoints[i]);
                if (speedPoints.Count > 25)
                    speedPoints.RemoveAt(0);
                doctorform.summaryUserControl.speedChart.Update();

                //fill graph pulse
                bpmPoints.Add(new DataPoint(Convert.ToDateTime(data.time.ToString()).ToOADate(), Convert.ToDouble(data.pulse.ToString())));
                doctorform.summaryUserControl.bpmChart.Series[0].Points.Clear();
                for (int i = 0; i < bpmPoints.Count; i++)
                    doctorform.summaryUserControl.bpmChart.Series[0].Points.Add(bpmPoints[i]);
                if (bpmPoints.Count > 25)
                    bpmPoints.RemoveAt(0);
                doctorform.summaryUserControl.speedChart.Update();

                //fill graph rpm
                rpmPoints.Add(new DataPoint(Convert.ToDateTime(data.time.ToString()).ToOADate(), Convert.ToDouble(data.rpm.ToString())));
                doctorform.summaryUserControl.rpmChart.Series[0].Points.Clear();
                for (int i = 0; i < rpmPoints.Count; i++)
                    doctorform.summaryUserControl.rpmChart.Series[0].Points.Add(rpmPoints[i]);
                if (rpmPoints.Count > 25)
                    rpmPoints.RemoveAt(0);
                doctorform.summaryUserControl.rpmChart.Update();
            }

        }
    }
}
