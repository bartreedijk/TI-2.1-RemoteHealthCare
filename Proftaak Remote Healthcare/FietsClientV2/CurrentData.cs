using FietsClient.JSONObjecten;
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
        public List<Session> testResultSessions { get; private set; }


        public CurrentData(string id)
        {
            this.userID = id;
            testResultSessions = new List<Session>();
        }

        public void setSessionList(List<Session> tests)
        {
            testResultSessions = tests;
        }

        public List<Session> GetSessions()
        {
            return testResultSessions;
        }

        public String GetUserID()
        {
            return userID;
        }

        public void setSession(Session s)
        {
            testResultSessions.Add(s);
        }

        public void SetMeasurment(Measurement measurment)
        {
            testResultSessions.Last().AddMeasurement(measurment);
        }
    }
}
