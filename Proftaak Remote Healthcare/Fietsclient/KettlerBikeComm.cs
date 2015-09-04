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
        private string _portname;
        private int baudrate = 9600;
        private string _bufferOut;
        private string[] _bufferIn;


        private SerialPort ComPort;
        public KettlerBikeComm(string port)
        {
            this._portname = port;
        }

        public void initComm()
        {
            ComPort = new SerialPort(_portname, this.baudrate);
            ComPort.Open();
            Console.WriteLine("test");
            ComPort.WriteLine("RS");
            Console.Write(ComPort.ReadLine());
            Console.WriteLine("end of message");
            ComPort.DataReceived += new SerialDataReceivedEventHandler(ComPort_DataReceived);

            while(true)
            {
                Thread.Sleep(1000);
                ComPort.WriteLine("ST");
            }
        }

        private void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string buffer = ComPort.ReadLine();
            buffer = buffer.TrimEnd('\r');
            Console.WriteLine(buffer);
            _bufferIn = buffer.Split('\t');
            
        }
    }
}
