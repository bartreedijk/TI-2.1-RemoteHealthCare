using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Net;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server gestart");

            TcpListener serverSocket = new TcpListener(80);
            serverSocket.Start();

            while (true)
            {
                Console.WriteLine("Waiting for clients..");
               new Client(serverSocket.AcceptTcpClient());
            }

            serverSocket.Stop();
            Console.WriteLine("Server afsluiten");
        }
    }
    public class Client
    {
        TcpClient client;
        NetworkStream networkStream;
        public Client(TcpClient socket)
        {
            client = socket;
            networkStream = client.GetStream();
            Console.WriteLine("New client connected");
            Thread t = new Thread(receive);
            t.Start();
        }

        public void receive()
        {
            while (true)
            {
                byte[] bytesFrom = new byte[(int)client.ReceiveBufferSize];
                networkStream.Read(bytesFrom, 0, (int)client.ReceiveBufferSize);
                String response = Encoding.ASCII.GetString(bytesFrom);
                //Hier moet wat met de response gedaan worden.
            }
        }
        public void sendString(string s)
        {
            byte[] b = Encoding.ASCII.GetBytes(s);
            networkStream.Write(b, 0, b.Length);
            networkStream.Flush();
        }
    }
}
