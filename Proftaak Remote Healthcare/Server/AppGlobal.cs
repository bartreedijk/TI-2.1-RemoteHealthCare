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
        public List<Client> Clients { get; set; }

        public static AppGlobal Instance
        {
            get { return _instance ?? (_instance = new AppGlobal()); }
        }

        public AppGlobal() 
        {
            users = new List<User>();
            users.Add(new User("no", "no", 0, false, 0));
            users.Add(new User("JK123", "jancoow", 5, true, 100));
            users.Add(new User("TOM", "tommie", 80, false, 77, true));

            users.ElementAt(1).tests.Add(new Session(1, "100"));
            users.ElementAt(1).tests.Add(new Session(2, "110"));
            users.ElementAt(0).tests.Add(new Session(3, "230"));
            users.ElementAt(2).tests.Add(new Session(4, "300"));

            Console.WriteLine(JsonConverter.GetUserSessions(users.ElementAt(1)));
        }

        public void CheckLogin(string username, string password, out int admin, out int id)
        {
            id = -1;
            admin = 0;
            foreach (User u in users)
            {
                if(u.id == username && u.password == password)
                {
                    admin = u.isDoctor ? 1 : 0;
                    id = users.IndexOf(u);
                }
            }
        }

        public List<User> GetUsers()
        {
            return users;
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
                    u.AddSession(new Session( mode, modevalue ));
                }
            }

        }
    }
}
