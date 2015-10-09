using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Linq;
using Server.JSONObjecten;
using JsonConverter = Server.FileIO.JsonConverter;

namespace Server
{
    public class AppGlobal
    {
        private static AppGlobal _instance;

        private List<User> users;
        private List<User> activePatient;
        private List<User> activeDoctor;

        public static AppGlobal Instance
        {
            get { return _instance ?? (_instance = new AppGlobal()); }
        }

        public AppGlobal()
        {
            users = new List<User>();
            TestMethode();
            Console.WriteLine(JsonConverter.GetUserSessions(users.ElementAt(1)));
        }

        private void TestMethode()
        {
            users.Add(new User("no", "no", 0, false, 0));
            users.Add(new User("JK123", "jancoow", 5, true, 100));
            users.Add(new User("TOM", "tommie", 80, false, 77, true));

            Random r = new Random();
            Session session = new Session(1, "100");
            for (int i = 0; i < 100; i++)
                session.AddMeasurement(new Measurement(r.Next(100, 200), r.Next(60, 100), r.Next(100, 150), r.Next(0, 100), i, r.Next(100), r.Next(100), r.Next(100), i, r.Next(100)));
            users.ElementAt(1).tests.Add(session);

            Session session2 = new Session(2, "100");
            for (int i = 0; i < 200; i++)
                session2.AddMeasurement(new Measurement(r.Next(100, 200), r.Next(60, 100), r.Next(100, 150), r.Next(0, 100), i, r.Next(100), r.Next(100), r.Next(100), i, r.Next(100)));
            users.ElementAt(1).tests.Add(session2);
        }

        public void CheckLogin(string username, string password, out int admin, out int id)
        {
            id = -1;
            admin = 0;
            foreach (User u in users)
            {
                if (u.id == username && u.password == password)
                {
                    admin = u.isDoctor ? 1 : 0;
                    id = users.IndexOf(u);
                    /* if (u.isDoctor)
                     {
                         activeDoctor.Add(u);
                     }
                     activePatient.Add(u);*/
                }
            }
        }

        public List<User> GetUsers()
        {
            return users;
        }
        
        public List<string> GetActivePatients()
        {
            List<string> patients = new List<string>();
            foreach (Client client in Program.Clients)
            {
                User user = users.FirstOrDefault(item => item.id == client.username);
                if (user != null)
                    if (!user.isDoctor)
                        patients.Add(user.id);
            }
            return patients;
        }

        public List<Session> GetTests(string patientid)
        {
            foreach (User u in users)
            {
                if (u.id == patientid)
                {
                    return u.tests;
                }
            }

            return null;
        }

        public void AddSession(string patientid, int mode, string modevalue)
        {
            foreach (User u in users)
            {
                if (u.id == patientid)
                {
                    u.AddSession(new Session(mode, modevalue));
                }
            }
        }
    }
}
