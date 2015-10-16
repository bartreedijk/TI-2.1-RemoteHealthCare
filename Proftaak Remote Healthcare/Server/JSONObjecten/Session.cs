using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Server.JSONObjecten
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
            if (!(Directory.Exists(@"JSON Files"))) 
            {
                Directory.CreateDirectory(@"JSON Files");
            }
            string[] fileEntries = Directory.GetFiles(@"JSON Files\");

            if (fileEntries.Length > 0)
                this.id = int.Parse(fileEntries[fileEntries.Length]);
            else
                this.id = 1;

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

    }
}
