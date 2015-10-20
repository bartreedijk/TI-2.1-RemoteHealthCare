using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FietsLibrary.JSONObjecten;

namespace FietsLibrary
{
    public class JsonConverter
    {
        public static string SerializeSession(Session s)
        {
            return JsonConvert.SerializeObject(s);
        }

	public static string SerializeUser(User user)
        {
            return JsonConvert.SerializeObject(user);
        }

	public static string SerializeLastMeasurement(Measurement measurement)
        {
            return JsonConvert.SerializeObject(measurement);
        }

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

        public static string GetUsers(List<User> user)
        {
            return JsonConvert.SerializeObject(user);
        }

    }
}
