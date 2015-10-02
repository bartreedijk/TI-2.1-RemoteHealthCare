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

        public DoctorModel()
        {
        }

        //display values
        private List<DataPoint> speedPoints = new List<DataPoint>();
        private List<DataPoint> bpmPoints = new List<DataPoint>();
        private List<DataPoint> rpmPoints = new List<DataPoint>();
        private void HandleBikeData(string[] data)
        {
            if (doctorform.InvokeRequired)
            {
                doctorform.Invoke((new Action(() => HandleBikeData(data))));
            }
            else
            {
                //fill fields
                doctorform.pulseBox.Text = data[0];
                doctorform.rpmInfoBox.Text = data[1];
                doctorform.speedInfoBox.Text = data[2];
                doctorform.distanceInfoBox.Text = data[3];
                doctorform.requestedBox.Text = data[4];
                doctorform.energyInfoBox.Text = data[5];
                doctorform.timeBox.Text = data[6];
                doctorform.actualBox.Text = data[7];
                
                //fill graph speed
                speedPoints.Add(new DataPoint(Convert.ToDateTime(data[6]).ToOADate(), Convert.ToDouble(data[2])));
                doctorform.speedChart.Series[0].Points.Clear();
                for (int i = 0; i < speedPoints.Count; i++)
                    doctorform.speedChart.Series[0].Points.Add(speedPoints[i]);
                if (speedPoints.Count > 25)
                    speedPoints.RemoveAt(0);
                doctorform.speedChart.Update();

                //fill graph pulse
                bpmPoints.Add(new DataPoint(Convert.ToDateTime(data[6]).ToOADate(), Convert.ToDouble(data[0])));
                doctorform.bpmChart.Series[0].Points.Clear();
                for (int i = 0; i < bpmPoints.Count; i++)
                    doctorform.bpmChart.Series[0].Points.Add(bpmPoints[i]);
                if (bpmPoints.Count > 25)
                    bpmPoints.RemoveAt(0);
                doctorform.speedChart.Update();

                //fill graph rpm
                rpmPoints.Add(new DataPoint(Convert.ToDateTime(data[6]).ToOADate(), Convert.ToDouble(data[1])));
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
