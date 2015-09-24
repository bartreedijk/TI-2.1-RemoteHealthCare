using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class User
    {
        public string name { get; private set; }
        public string username { get; private set; }
        public string password { get; private set; }
        public bool admin { get; private set; }

        public User(string name, string username, string password, bool admin)
        {
            this.name = name;
            this.username = username;
            this.password = password;
            this.admin = admin;
        }
    }
}
