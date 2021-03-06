﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace FietsLibrary.JSONObjecten
{
    [Serializable]
    public class Session
    {
        public int id { get; private set; }
        public List<Measurement> measurements { get; private set; }
        public bool isActive { get; private set; }
        public DateTime date { get; private set; }
        public string note { get; private set; }

        public Session(int id)
        {
            this.id = id;

            this.measurements = new List<Measurement>();
            this.isActive = true;
            this.date = DateTime.Now;
            this.note = "";
        }

        public void AddMeasurement(Measurement m)
        {
            measurements.Add(m);
        }

        public Measurement GetLastMeasurement()
        {
            return measurements.Last();
        }
	
	public void PrintAll()
        {
            Console.WriteLine("pulse" + "\t" + "rpm" + "\t" + "speed" + "\t" + " dist" + "\t" + "req pow" + "\t" + "energy" + "\t" + "time" + "\t\t" + "act pow");

            for (int i = 0; i < measurements.Count; i++)
            {
                Console.WriteLine(measurements[i].pulse + "\t" + measurements[i].rpm + "\t" + measurements[i].speed + "\t " + measurements[i].distance + "\t" + measurements[i].requestedPower + "\t" + measurements[i].energy + "\t" + measurements[i].time + "\t" + measurements[i].actualPower);
            }
        }
    }
}
