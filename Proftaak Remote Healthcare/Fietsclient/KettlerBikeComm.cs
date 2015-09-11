using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace Fietsclient
{
    class KettlerBikeComm
    {

        // vaste waarden
        public static readonly string COMMAND = "CM";
        public static readonly string CMD_TIME = "PT";
        public static readonly string CMD_DISTANCE = "PD";
        public static readonly string CMD_POWER = "PW";
        public static readonly string CMD_ENERGY = "PE";
        public static readonly string RESET = "RS";
        public static readonly string STATUS = "ST";

        // private fields
        private string _portname;
        private int baudrate = 9600;
        private string _bufferOut;
        private string[] _bufferIn;

        // public fields
        public enum State { notConnected, connected, reset, command }
        public enum ReturnData { ERROR, ACK, RUN, STATUS }

        public State state = State.notConnected;
        public ReturnData returnData;

        private SerialPort ComPort;

        // custom events
        public delegate void DataDelegate(string[] data);
        public static event DataDelegate IncomingDataEvent;

        public KettlerBikeComm()
        {
            
        }

        private static void OnIncomingDataEvent(string[] data)
        {
            DataDelegate handler = IncomingDataEvent;
            if (handler != null) handler(data);
        }

        public void initComm(string portname)
        {
            if (ComPort != null)
            {
                ComPort.Close();
            }
            _portname = portname;
            ComPort = new SerialPort(_portname, this.baudrate);
            ComPort.Open();
            Console.WriteLine("test");
            ComPort.WriteLine(RESET);
            Console.Write(ComPort.ReadLine());
            Console.WriteLine("end of message");
            ComPort.DataReceived += new SerialDataReceivedEventHandler(ComPort_DataReceived);
        }

        public void closeComm()
        {
            ComPort.Close();
        }

        public void sendData(string data)
        {
            _bufferOut = data;
            ComPort.WriteLine(data);
        }

        private void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string buffer = ComPort.ReadLine();
            switch(buffer) //kijk wat er binnenkomt
            {
                case "ERROR": //wanneer "Error"
                    //if (_bufferOut == "RS") sendData("RS"); //gewoon nog een keer proberen...
                    returnData = ReturnData.ERROR;
                    break;
                case "ACK": // ACK betekent acknowledged.
                    returnData = ReturnData.ACK;
                    break;
                case "RUN":
                    returnData = ReturnData.RUN;
                    break;
                default:    // alle andere waarden.
                    returnData = ReturnData.STATUS;
                    handleBikeValues(buffer);
                    break;
            }
        }

        private void handleBikeValues(string buffer)
        {
            buffer = buffer.TrimEnd('\r');
            Console.WriteLine(buffer);
            _bufferIn = buffer.Split('\t');
            OnIncomingDataEvent(_bufferIn);
        }

        private bool checkBikeState()
        {
            bool success = false;
            switch(state)
            {
                case State.reset:
                    setCommandMode();
                    
                    if(returnData != ReturnData.ERROR)
                    {
                        success = true;
                    }
                    break;
                case State.connected:
                    setCommandMode();                   
                    success = true;
                    break;
                case State.command:
                    success = true;
                    break;
                case State.notConnected:
                    Console.WriteLine("ERROR: not connected to bike.");
                    success = false;
                    break;
            }
            return success;
        }

        public void setCommandMode()
        {
            sendData(COMMAND);
        }

        public void setTime()
        {
            if (!checkBikeState())
                return;
            sendData(CMD_TIME);
        }

        public void setDistance()
        {
            if (!checkBikeState())
                return;
            sendData(CMD_DISTANCE);
        }

        public void setPower()
        {
            if (!checkBikeState())
                return;
            sendData(CMD_POWER);
        }

        public void setEnergy()
        {
            if (!checkBikeState())
                return;
            sendData(CMD_ENERGY);
        }
    }
}


