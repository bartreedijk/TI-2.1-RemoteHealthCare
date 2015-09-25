using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FietsClientV2
{
    [Serializable]
    public class Meetsessie
    {
        //public List<Meting> metingen = new List<Meting>()
        public int idMeting;
        public int idUser;
        public string name;
        public Boolean active;
        public List<Meting> metingen { get; private set; } = new List<Meting>();

        public void AddMeting(Meting meting)
        {
            metingen.Add(meting);
        }

        public List<Meting> getMetingen()
        {
            return metingen;
        }

        public void PrintAll()
        {
            Console.WriteLine("pulse" + "\t" + "rpm" + "\t" + "speed" + "\t" + " dist" + "\t" + "req pow" + "\t" + "energy" + "\t" + "time" + "\t\t" + "act pow");
            for (int i = 0; i < metingen.Count; i++)
            {
                Console.WriteLine(metingen[i].pulse + "\t" + metingen[i].rpm + "\t" + metingen[i].speed + "\t " + metingen[i].distance + "\t" + metingen[i].requestedPower + "\t" + metingen[i].energy + "\t" + metingen[i].time + "\t" + metingen[i].actualPower);
            }
        }
    }
}
