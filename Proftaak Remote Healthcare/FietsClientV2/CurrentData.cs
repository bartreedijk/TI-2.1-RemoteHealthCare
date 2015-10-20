using FietsLibrary.JSONObjecten;
using FietsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FietsClient
{
    public class CurrentData
    {//faggsd
        private string userID;
        public bool isDoctor { set; get; }
        public List<Session> sessions { get; private set; }


        public CurrentData(string id)
        {
            this.userID = id;
            sessions = new List<Session>();
        }

        public void setSessionList(List<Session> tests)
        {
            sessions = tests;
        }

        public List<Session> GetSessions()
        {
            return sessions;
        }

        public String GetUserID()
        {
            return userID;
        }

        public void setSession(Session s)
        {
            sessions.Add(s);
        }

        public void AddMeasurementToLastSession(Measurement measurment)
        {
            sessions.Last().AddMeasurement(measurment);
        }
    }
}
