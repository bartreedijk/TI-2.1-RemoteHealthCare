using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Opslag_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Meetsessie sessie = new Meetsessie();
            sessie.AddMeting(new Meting(1,  2,  3,  4, 5,  6, new TimeSpan(00, 00, 01), 8));
            sessie.AddMeting(new Meting(18, 22, 3, 54, 5,  6, new TimeSpan(00, 00, 10), 8));
            sessie.AddMeting(new Meting(15, 27, 3, 54, 5, 76, new TimeSpan(00, 01, 00), 8));
            sessie.AddMeting(new Meting(12, 52,53, 48, 5, 76, new TimeSpan(00, 10, 00),87));
            sessie.AddMeting(new Meting(51, 25, 3,54, 5, 476, new TimeSpan(00, 10, 01),87));
            sessie.AddMeting(new Meting(71, 2, 37, 44, 5, 46, new TimeSpan(00, 11, 00), 8));
            
            FileStream fileStream = System.IO.File.Open(Environment.CurrentDirectory+"\\test.json", FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            JsonWriter jsontTextWriter = new JsonTextWriter(streamWriter);
            JsonSerializer jsonSerializer = new JsonSerializer();

            using (jsontTextWriter)
            {
                jsonSerializer.Serialize(jsontTextWriter, sessie.getMetingen().ToArray());
            }

            using (StreamReader r = new StreamReader("test.json"))
            {
                string json = r.ReadToEnd();
                List<Meetsessie> items = JsonConvert.DeserializeObject<List<Meetsessie>>(json);
                //items[0].PrintAll();
                Console.WriteLine(items[0].getMetingen().Count);

            }

            //Console.WriteLine(sessie.getMetingen()[0]);
            //sessie.PrintAll();
            Console.Read();
        }
    }
}
