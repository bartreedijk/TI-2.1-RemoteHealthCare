using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Fietsclient
{
    class KettlerBikeComm
    {
        private string _portname;
        private int baudrate = 9600;


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
        }
    }
}
