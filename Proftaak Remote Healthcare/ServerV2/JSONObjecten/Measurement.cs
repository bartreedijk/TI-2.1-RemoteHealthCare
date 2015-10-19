using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerV2.JSONObjecten

{
    [Serializable]
    public class Measurement
    {
        public int pulse { get; private set; }
        public int rpm { get; private set; }
        public int speed { get; private set; }
        public int wattage { get; private set; }
        public int distance { get; private set; }
        public int requestedPower { get; private set; }
        public int energy { get; private set; }
        public int actualPower { get; private set; }
        public int time { get; private set; }
        public int bpm { get; private set; }

        public Measurement(int pulse, int rpm, int speed, int wattage, int distance, int requestedPower, int energy, int actualPower, int time, int bpm)
        {
            this.pulse = pulse;
            this.rpm = rpm;
            this.speed = speed;
            this.wattage = wattage;
            this.distance = distance;
            this.requestedPower = requestedPower;
            this.energy = energy;
            this.actualPower = actualPower;
            this.time = time;
            this.bpm = bpm;
        }


        public override string ToString()
        {
            return "pulse: " + pulse + " - RPM: " + rpm + " speed: " + speed + " - distance: " + distance + " - requested power: " + requestedPower + " - energy: " + energy + " - time: " + time + " - actual power: " + actualPower;
        }
    }
}
