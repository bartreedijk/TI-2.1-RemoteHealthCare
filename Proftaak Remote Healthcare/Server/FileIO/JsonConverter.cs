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
            File.WriteAllText(@"JSON Files\" + u.id + ".json", GetUser(u));
        }

        public static string GetUser(User u)
        {
           return JsonConvert.SerializeObject(u);
        }

        public static string GetUserSessions(User patient)
        {
            return JsonConvert.SerializeObject(patient.GetSessions());
        }
    
        public static string GetSessions(Session session)
        {
            return JsonConvert.SerializeObject(session);
        }

        public static string GetLastMeasurement(Session currentSession)
        {
            return JsonConvert.SerializeObject(currentSession.GetLastMeasurement());
        }

    }
}
