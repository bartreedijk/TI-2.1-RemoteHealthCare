using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FietsSimulator
{
    class FietsSimulator
    {
        private SerialPort comport;
        private Mode curmode;
        private int curvalue;
        private int _power;
        public int Power
        {
            get { return _power; }
            set
            {
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
            string message = comport.ReadLine().Trim();
            Console.WriteLine(message);
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
                if (curmode != Mode.NONE && message.Split().Length == 2)
                {
                    this.Power = Int32.Parse(message.Split(' ')[1]);
                }
                else
                {
                    SendData("ERROR");
                }
            }
            else if (message == "ST")
            {
                SendData("0\t100\t10\t20\t" + Power.ToString() + "\t600\t0504\t200\r");
                // pulse rpm speed * 10 distance requested_power energy mm:ss actual_power
            }
            else
            {
                SendData("ERROR");
            }
        }
        private void SendData(string message)
        {
            this.comport.WriteLine(message);
        }
    }
}
