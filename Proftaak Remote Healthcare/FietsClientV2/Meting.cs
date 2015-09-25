using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FietsClientV2

{
    [Serializable]
    public class Meting
    {
        public int pulse { get; private set; }          //BPM
        public int rpm { get; private set; }            //RPM
        public int speed { get; private set; }          //meter per seconden
        public int distance { get; private set; }       //meter
        public int requestedPower { get; private set; } //Watt
        public int energy { get; private set; }         //Watt
        public TimeSpan time { get; private set; }      // minuten: seconden
        public int actualPower { get; private set; }    //Watt

        public Meting(int pulse, int rpm, int speed, int distance, int requestedPower, int energy, TimeSpan time, int actualPower)
        {
            this.pulse = pulse;
            this.rpm = rpm;
            this.speed = speed;
            this.distance = distance;
            this.requestedPower = requestedPower;
            this.energy = energy;
            this.time = time;
            this.actualPower = actualPower;
        }

        public override string ToString()
        {
            return "pulse: " + pulse + " - RPM: " + rpm + " speed: " + speed + " - distance: " + distance + " - requested power: " + requestedPower + " - energy: " + energy + " - time: " + time + " - actual power: " + actualPower;
        }
    }
}
