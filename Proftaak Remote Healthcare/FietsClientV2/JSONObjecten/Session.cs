using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace FietsClient.JSONObjecten
{
    [Serializable]
    public class Session
    {
        public int id { get; private set; }
        public List<Measurement> session { get; private set; }
        public bool isActive { get; private set; }
        public int bikeMode { get; private set; }
        public DateTime date { get; private set; }
        public string note { get; private set; }
        public string modevalue { get; private set; }

        public Session(int bikeMode, string modevalue)
        {
            string[] fileEntries = Directory.GetFiles(@"../../JSONObjecten/JSON Files/");

            if (fileEntries.Length > 0)
            {
                this.id = int.Parse(fileEntries[fileEntries.Length]);
            }
            else
            {
                this.id = 1;
            }

            this.session = new List<Measurement>();
            this.isActive = true;
            this.bikeMode = bikeMode;
            this.modevalue = modevalue;
            this.date = DateTime.Now;
            this.note = "";
        }

        public void AddMeasurement(Measurement m)
        {
            session.Add(m);
        }

        public Measurement GetMeasurement()
        {
            return session.Last();
        }

        public void PrintAll()
        {
            Console.WriteLine("pulse" + "\t" + "rpm" + "\t" + "speed" + "\t" + " dist" + "\t" + "req pow" + "\t" + "energy" + "\t" + "time" + "\t\t" + "act pow");

            for (int i = 0; i < session.Count; i++)
            {
                Console.WriteLine(session[i].pulse + "\t" + session[i].rpm + "\t" + session[i].speed + "\t " + session[i].distance + "\t" + session[i].requestedPower + "\t" + session[i].energy + "\t" + session[i].time + "\t" + session[i].actualPower);
            }
        }
    }
}
