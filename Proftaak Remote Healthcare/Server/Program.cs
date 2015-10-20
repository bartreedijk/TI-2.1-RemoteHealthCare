using System;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;

namespace Server
{
    class Program
    {
        public static List<Client> Clients { get; private set; } = new List<Client>();

        TcpListener serverSocket;

        static void Main(string[] args)
        {
            new Program();
        }

        Program()
        {
            Console.WriteLine("Server gestart");

            // zorg dat AppGlobal bestaat...
            AppGlobal.Instance.ToString();
            // zorg dat de certificaat bestaat
            lib.SSLCrypto.CreateSelfSignedCert();

            serverSocket = new TcpListener(IPAddress.Any, 1288);
            serverSocket.Start();

            while (true)
            {
                Console.WriteLine("Waiting for clients..");
                Clients.Add(new Client(serverSocket.AcceptTcpClient()));
            }

        }
        // eigenlijk komt de server hier nooit maar toch...
        ~Program()
        {
            serverSocket.Stop();
            Console.WriteLine("Server afsluiten");
        }
        
        public static void RemoveClientFromList(Client client)
        {
            if (client.username != "")
                Console.WriteLine("Client " + client.iduser + " with username " + client.username + " has been disconnected.");
            Clients.Remove(client);
        }
    }

}
