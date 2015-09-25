using System.Collections.Generic;
using System.Threading;
using Fietsclient;
using System.Threading.Tasks;
using System;

namespace Server
{
    public class AppGlobal
    {
        private static AppGlobal _instance;

        Thread workerThread;
        private List<User> users;
        private List<Meetsessie> meetsessies;

        public static AppGlobal Instance
        {
            get { return _instance ?? (_instance = new AppGlobal()); }
        }

        private AppGlobal()
        {
            users = new List<User>();
            users.Add(new User("no", "no", "no", false));
            users.Add(new User("Janco Kock", "jancoow", "test", true));
            users.Add(new User("Tom Remeeus", "tommie", "jemoeder", false));
        }

        public void CheckLogin(string username, string password, out int admin, out int id)
        {
            id = -1;
            admin = 0;
            foreach (User u in users)
            {
                if (u.username == username && u.password == password)
                {
                    admin = u.admin ? 1 : 0;
                    id = users.IndexOf(u);
                }
            }
        }

        public List<Meetsessie> GetMeetsessies(int patientid)
        {
            List<Meetsessie> sessies = new List<Meetsessie>();
            foreach(Meetsessie m in meetsessies){
                if(m.idUser == patientid)
                {
                    sessies.Add(m);
                }
            }
            return sessies;
        }
    }
}
