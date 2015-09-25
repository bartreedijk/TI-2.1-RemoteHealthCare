using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Server.JSONObjecten;

namespace Server
{
    public class AppGlobal
    {
        private static AppGlobal _instance;

        private List<User> users;

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
    }
}
