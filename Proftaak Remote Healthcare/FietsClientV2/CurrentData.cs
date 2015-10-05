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
        private List<Session> testResult;


        public CurrentData(string id)
        {
            this.userID = id;
            testResult = new List<Session>();
        }

        public void setSessionList(List<Session> tests)
        {
            testResult = tests;
        }

        public List<Session> GetSessions()
        {
            return testResult;
        }

        public String GetUserID()
        {
            return userID;
        }

        public void setSession(Session s)
        {
            testResult.Add(s);
        }

        public void SetMeasurment(Measurement measurment)
        {
            testResult.Last().AddMeasurement(measurment);
        }
    }
}
