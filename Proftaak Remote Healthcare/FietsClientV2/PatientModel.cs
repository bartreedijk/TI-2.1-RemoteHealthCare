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

        //event handler
        private void HandleBikeData(string[] data)
        {
            //doe iets ermee...
        }

        public void closeComPort()
        {
            if (workerThread != null)
                workerThread.Interrupt();
            dataHandler.closeComm();
        }
    }
}
