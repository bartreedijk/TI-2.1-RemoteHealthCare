using ServerV2.JSONObjecten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerV2
{
    class Client
    {
        public TcpClient tcpClient;
        public string username;

        public Client(TcpClient tcpClient, string username)
        {
            this.tcpClient = tcpClient;
            this.username = username;
        }

    }
}
