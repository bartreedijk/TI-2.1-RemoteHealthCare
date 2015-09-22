using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FietsClientV2
{
    class PatientModel
    {

        private static PatientModel _patientModel;
        public PatientForm patientform { private get; set; }

        public static PatientModel patientModel { get { return _patientModel ?? (_patientModel = new PatientModel()); } }

        private DataHandler dataHandler;
        private Thread workerThread;

        private PatientModel()
        {
            dataHandler = new DataHandler();
            DataHandler.IncomingDataEvent += HandleBikeData; //initialize event
        }

        public void startComPort(string portname)
        {
            dataHandler.initComm(portname);
        }

        public void startAskingData()
        {
            workerThread = new Thread(() => workerThreadLoop());
            workerThread.Start();
        }

        private void workerThreadLoop()
        {
            while (true)
            {
                Thread.Sleep(1000);
                dataHandler.sendData(DataHandler.STATUS);
            }
        }
        delegate void trySetText(string[] text);
        //event handler
        private void HandleBikeData(string[] data)
        {
            if (patientform.pulseBox.InvokeRequired)
            {
                trySetText t = new trySetText(HandleBikeData);
                patientform.Invoke(t, new object[] { data });
            }
            else
            {
                patientform.pulseBox.Text = data[0];
                patientform.rpmInfoBox.Text = data[1];
                patientform.speedInfoBox.Text = data[2];
                patientform.distanceInfoBox.Text = data[3];
                patientform.requestedBox.Text = data[4];
                patientform.energyInfoBox.Text = data[5];
                patientform.timeBox.Text = data[6];
                patientform.actualBox.Text = data[7];
            }
            
        }

        public void closeComPort()
        {
            if (workerThread != null)
                workerThread.Interrupt();
            dataHandler.closeComm();
        }

        //change bike values
        public void setTimeMode(string time)
        {
            dataHandler.sendData("CU");
            dataHandler.sendData("PT " + time);
        }

        public void setPower(string power)
        {
            dataHandler.sendData("CU");
            dataHandler.sendData("PW " + power);
        }

        public void setDistanceMode(string distance)
        {
            dataHandler.sendData("CU");
            dataHandler.sendData("PD " + distance);
        }

        public void reset()
        {
            dataHandler.sendData("RS");
        }
    }
}
