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
        public static List<Client> Clients { get; private set; } = new List<Client>();

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
                Clients.Add(new Client(serverSocket.AcceptTcpClient()));
            }

            serverSocket.Stop();
            Console.WriteLine("Server afsluiten");
        }
        
        public static void RemoveClientFromList(Client client)
        {
            string s = "Client " + client.iduser + " with username " + client.username + " has been disconnected.";
            Clients.Remove(client);
            Console.WriteLine(s);
        }
    }

}
