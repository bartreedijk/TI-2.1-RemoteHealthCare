using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace FietsClient
{
    class DoctorModel
    {

        private static DoctorModel _doctorModel;
        public DoctorForm doctorform { get; set; }

        public static DoctorModel doctorModel { get { return _doctorModel ?? (_doctorModel = new DoctorModel()); } }
        public TcpConnection tcpConnection { private get; set; }
        private Thread receiveDataLoop;

        public DoctorModel()
        {

        }

        public void startAskingData()
        {
            receiveDataLoop = new Thread(() => receiveDataThreadLoop());
            receiveDataLoop.Start();
        }

        private void receiveDataThreadLoop()
        {
            while (true)
            {
                Thread.Sleep(1000);
                //receive data and display in through handle bike data
                HandleBikeData(tcpConnection.currentData.GetSessions().Last().GetLastMeasurement());
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
                doctorform.pulseBox.Text = data.pulse.ToString();
                doctorform.rpmInfoBox.Text = data.rpm.ToString();
                doctorform.speedInfoBox.Text = data.speed.ToString();
                doctorform.distanceInfoBox.Text = data.distance.ToString();
                doctorform.requestedBox.Text = data.requestedPower.ToString();
                doctorform.energyInfoBox.Text = data.energy.ToString();
                doctorform.timeBox.Text = data.time.ToString() ;
                doctorform.actualBox.Text = data.actualPower.ToString();

                //fill graph speed
                speedPoints.Add(new DataPoint(Convert.ToDateTime(data.time.ToString()).ToOADate(), Convert.ToDouble(data.speed.ToString())));
                doctorform.speedChart.Series[0].Points.Clear();
                for (int i = 0; i < speedPoints.Count; i++)
                    doctorform.speedChart.Series[0].Points.Add(speedPoints[i]);
                if (speedPoints.Count > 25)
                    speedPoints.RemoveAt(0);
                doctorform.speedChart.Update();

                //fill graph pulse
                bpmPoints.Add(new DataPoint(Convert.ToDateTime(data.time.ToString()).ToOADate(), Convert.ToDouble(data.pulse.ToString())));
                doctorform.bpmChart.Series[0].Points.Clear();
                for (int i = 0; i < bpmPoints.Count; i++)
                    doctorform.bpmChart.Series[0].Points.Add(bpmPoints[i]);
                if (bpmPoints.Count > 25)
                    bpmPoints.RemoveAt(0);
                doctorform.speedChart.Update();

                //fill graph rpm
                rpmPoints.Add(new DataPoint(Convert.ToDateTime(data.time.ToString()).ToOADate(), Convert.ToDouble(data.rpm.ToString())));
                doctorform.rpmChart.Series[0].Points.Clear();
                for (int i = 0; i < rpmPoints.Count; i++)
                    doctorform.rpmChart.Series[0].Points.Add(rpmPoints[i]);
                if (rpmPoints.Count > 25)
                    rpmPoints.RemoveAt(0);
                doctorform.rpmChart.Update();
            }

        }
    }
}
