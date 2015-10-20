using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FietsLibrary.JSONObjecten

{
    [Serializable]
    public class Measurement
    {
        public int pulse { get; private set; }
        public int rpm { get; private set; }
        public int speed { get; private set; }
        public int distance { get; private set; }
        public int requestedPower { get; private set; }
        public int energy { get; private set; }
        public int actualPower { get; private set; }
        public int time { get; private set; }

        public Measurement()
        {

        }

        public Measurement(int pulse, int rpm, int speed, int wattage, int distance, int requestedPower, int energy, int actualPower, int time, int bpm)
        {
            this.pulse = pulse;
            this.rpm = rpm;
            this.speed = speed;
            this.distance = distance;
            this.requestedPower = requestedPower;
            this.energy = energy;
            this.actualPower = actualPower;
            this.time = time;
        }

        public Measurement(string[] data)
        {
            pulse = int.Parse(data[0]);
            rpm = int.Parse(data[1]);
            speed = int.Parse(data[2]);
            distance = int.Parse(data[3]);
            requestedPower = int.Parse(data[4]);
            energy = int.Parse(data[5]);
            int time = 0;
            string[] timeArray = data[6].Split(':');
            time += (int.Parse(timeArray[0]) * 100);
            time += int.Parse(timeArray[1]);
            actualPower = int.Parse(data[7]);
        }
    }
}
