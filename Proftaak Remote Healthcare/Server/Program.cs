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
        private String response;

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
                response = Encoding.ASCII.GetString(bytesFrom);
                //Hier moet wat met de response gedaan worden.
            }
        }
        public void sendString(string s)
        {
            byte[] b = Encoding.ASCII.GetBytes(s);
            networkStream.Write(b, 0, b.Length);
            networkStream.Flush();
        }

        public Boolean LoginClient(String username, String password, out String GUI_switch)
        {
            GUI_switch = null;
            Boolean signed_in = false;  
            String ip = "192.168.1.1"; //log maar in op die kutrouter van je HERPADERP
            int port = 0;

            try
            {
               client.Connect(ip, port);
            } catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            if (client.Connected)
            {
                String sendData = "0|" + username + "|" + password;
                sendString(sendData);

                receive();

                if (response == "0|1|1")
                {
                    signed_in = true;
                    GUI_switch = "docter";
                }
                if (response == "0|1|0")
                {
                    signed_in = true;
                    GUI_switch = "patient";
                }
            }

            return signed_in;
        }
    }
}
