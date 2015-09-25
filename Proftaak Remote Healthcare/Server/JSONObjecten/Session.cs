using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Server.JSONObjecten
{
    public class Session
    {
        public int id { get; private set; }
        public List<Measurement> session { get; private set; }
        public bool isActive { get; private set; }
        public int deviceID { get; private set; }
        public int bikeMode { get; private set; }
        public DateTime date { get; private set; }
        public string note { get; private set; }
        public string modevalue { get; private set; }

        public Session( int deviceid, int bikeMode, string modevalue )
        {
            string[] fileEntries = Directory.GetFiles("JSONObjecten/JSON Files/");
            this.id = int.Parse(fileEntries[fileEntries.Length]);
            this.session = new List<Measurement>();
            this.isActive = true;
            this.deviceID = deviceid;
            this.bikeMode = bikeMode;
            this.modevalue = modevalue;
            this.date = DateTime.Now;
            this.note = "";
        }

    }
}
