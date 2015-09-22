using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Diagnostics;

namespace FietsSimulator
{
    class FietsSimulator
    {
        //connection with PC
        private SerialPort comport;

        //bicycle modes
        private Mode curmode;
        private enum Mode
        {
            NONE,
            CONSOLE,
            DISTANCE,
            TIME
        }

        //bicycle variables
        private int power, heartbeat, rpm, speed, distance, energy;
        private long maxtime;
        private Stopwatch stopwatch;
        private Random r = new Random();

        public int Power
        {
            get { return this.power; }
            set
            {
                if (value >= 25 && value <= 400)
                    this.power = value;
                if (value < 25)
                    this.power = 25;
                if (value > 400)
                    this.power = 400;
            }
        }

        public int Heartbeat
        {
            //generate random heartbeat between 60 and 160 bpm
            get { return r.Next(60, 160); }
        }

        public FietsSimulator(String addr)
        {
            this.comport = new SerialPort(addr, 9600);
            comport.DataReceived += new SerialDataReceivedEventHandler(ReceiveData);
            comport.Open();
            stopwatch = new Stopwatch();
            stopwatch.Stop();
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
        }

        private void ReceiveData(object sender, SerialDataReceivedEventArgs e)
        {
            string message = comport.ReadLine();
            string command = message.Substring(0, 2);
            Console.WriteLine(message);

            switch (command)
            {
                case "RS":
                    curmode = Mode.NONE;
                    rpm = speed = distance = energy = 0;
                    Power = 25;
                    stopwatch.Stop();
                    SendData("ACK");
                    break;
                case "CU":
                    curmode = Mode.CONSOLE;
                    SendData("ACK");
                    break;
                case "PD":
                    if (curmode == Mode.CONSOLE)
                    {
                        distance = Int32.Parse(message.Split(' ')[1]);
                        curmode = Mode.DISTANCE;
                        stopwatch.Reset();
                        stopwatch.Start();
                        rpm = 100;
                        speed = 10;
                    }
                    else
                        SendData("ERROR");
                    break;
                case "PT":
                    if (curmode == Mode.CONSOLE)
                    {
                        string[] time = message.Split(' ')[1].Split(':');
                        maxtime = Int32.Parse(time[0]) * 60000 + Int32.Parse(time[1]) * 1000;
                        curmode = Mode.TIME;
                        stopwatch.Reset();
                        stopwatch.Start();
                        rpm = 100;
                        speed = 10;
                    }
                    else
                        SendData("ERROR");
                    break;
                case "PW":
                    if (curmode != Mode.NONE)
                        this.Power = Int32.Parse(message.Split(' ')[1]);
                    else
                        SendData("ERROR");
                    break;
                case "ST":
                    if (curmode != Mode.NONE)
                        SendStatus();
                    break;
                default:
                    SendData("ERROR");
                    break;
            }
        }

        private void SendData(string message)
        {
            Console.WriteLine("RETURN:" + message);
            this.comport.WriteLine(message);
        }

        private void SendStatus()
        {
            SendData(Heartbeat.ToString() + "\t" + rpm + "\t" + speed * 10 + "\t" + distance + "\t" + Power.ToString() + "\t600\t" + getTimeElapsed() + "\t200\r");
        }

        private string getTimeElapsed()
        {
            if (curmode == Mode.DISTANCE)
            {
                long seconds = (stopwatch.ElapsedMilliseconds / 1000) % 60;
                long minutes = ((stopwatch.ElapsedMilliseconds - seconds) / 1000) / 60;
                return minutes + ":" + seconds;
            }
            else if (curmode == Mode.TIME)
            {
                long seconds = ((maxtime - stopwatch.ElapsedMilliseconds) / 1000) % 60;
                long minutes = (((maxtime - stopwatch.ElapsedMilliseconds) - seconds) / 1000) / 60;
                return minutes + ":" + seconds;
            }
            else
            {
                return "00:00";
            }
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (curmode == Mode.DISTANCE)
            {
                distance -= 1;
            }
            else if (curmode == Mode.TIME)
            {
                distance += 1;
            }
        }
    }
}
