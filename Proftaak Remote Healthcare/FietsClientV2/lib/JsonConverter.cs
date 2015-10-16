using FietsClient.JSONObjecten;
using Newtonsoft.Json;

namespace FietsClient.lib
{
    class JsonConverter
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
    }
}
