using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FietsSimulator
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class FietsSimulator
    {
        private SerialPort comport;
        private Mode curmode;
        private int curvalue;
        private int _power;
        public int Power
        {
            get { return _power; }
            set {
                if (value >= 25 && value <= 400)
                    _power = value;
                if (value < 25)
                    _power = 25;
                if (value > 400)
                    _power = 400;
            }
        }

        private enum Mode
        {
            NONE,
            CONSOLE,
            DISTANCE,
            TIME
        }

        public FietsSimulator(String addr)
        {
            this.comport = new SerialPort(addr, 9600);
            comport.DataReceived += new SerialDataReceivedEventHandler(ReceiveData);
            comport.Open();
        }

        private void ReceiveData(object sender, SerialDataReceivedEventArgs e)
        {
            String message = comport.ReadLine().Trim();
            if (message == "RS")
            {
                curmode = Mode.NONE;
                curvalue = 0;
                Power = 25;
                SendData("ACK");
            }
            else if (message == "CU")
            {
                curmode = Mode.CONSOLE;
                SendData("ACK");
            }
            else if (message.Contains("PW"))
            {
                if(curmode != Mode.NONE && message.Split().Length == 2)
                {
                    this.Power = Int32.Parse(message.Split(' ')[1]);
                }
                else
                {
                    SendData("ERROR");
                }
            }
            else
            {
                SendData("ERROR");
            }
        }
        private void SendData(String message)
        {
            this.comport.WriteLine(message);
        }
    }
}
