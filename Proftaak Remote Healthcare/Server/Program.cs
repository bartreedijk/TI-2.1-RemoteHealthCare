using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Net;
using Server;
using System.Collections.Generic;

namespace Server
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Server gestart");

            //zorg dat AppGlobal bestaat...
            AppGlobal.Instance.ToString();
            TcpListener serverSocket = new TcpListener(1288);
            serverSocket.Start();

            while (true)
            {
                Console.WriteLine("Waiting for clients..");
               new Client(serverSocket.AcceptTcpClient(), AppGlobal.Instance);
            }

            serverSocket.Stop();
            Console.WriteLine("Server afsluiten");
        }
    }

}
