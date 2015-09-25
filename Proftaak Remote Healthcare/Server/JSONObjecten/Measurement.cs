using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.JSONObjecten
{
    public class Measurement
    {
        public int rpm { get; private set; }
        public int wattage { get; private set; }
        public int distance { get; private set; }
        public DateTime date { get; private set; }
        public int bpm { get; private set; }

        public Measurement (int rpm, int wattage, int distance, int bpm)
        {
            this.rpm = rpm;
            this.wattage = wattage;
            this.distance = distance;
            this.bpm = bpm;
            this.date = DateTime.Now;
        }

    }
}
