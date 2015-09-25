using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Server.JSONObjecten;

namespace Server.FileIO
{
    class JsonConverter
    {
        public static void SaveUser(User u)
        {
            File.WriteAllText(Environment.CurrentDirectory + "\\" + u.id + ".json", u.ToJSON());
        }
        
    }
}
