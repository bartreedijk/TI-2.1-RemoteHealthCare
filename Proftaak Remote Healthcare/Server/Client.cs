using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using Server.FileIO;

namespace Server
{
    public class Client
    {
        TcpClient client;
        NetworkStream networkStream;
        private readonly AppGlobal _global;
        private int iduser;

        public Client(TcpClient socket, AppGlobal global)
        {
            client = socket;
            networkStream = client.GetStream();
            _global = global;
            iduser = -1;
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
                String[] response_parts = response.Split('|');
                if (response_parts.Length > 0)
                {
                    switch (response_parts[0])
                    {
                        case "0":   //login
                            if (response_parts.Length == 4)
                            {
                                int admin, id;
                                _global.CheckLogin(response_parts[1], response_parts[2], out admin, out id);
                                if (id > -1)
                                {
                                    this.iduser = id;
                                    sendString("0|" + id + "|" + admin + "|");
                                }
                                else
                                {
                                    sendString("0|0|0|");
                                }
                            }
                            break;
                        case "1":   //meetsessies ophalen

                            foreach (User u in _global.testU())
                            {
                                JsonConverter.SaveUser(u);
                            }

                            break;
                        case "2":   //Livedata opvragen

                            break;
                        case "3":   //Nieuwe meetsessie aanmaken
                            if (response_parts.Length == 6 && iduser != -1)
                            {
                                _global.addSession(response_parts[1], Int32.Parse(response_parts[2]), response_parts[3]);
                            }
                            break;
                        case "4":   //Check nieuwe meetsessie

                            break;
                        case "5":   //data pushen naar meetsessie

                            break;
                    }
                }
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
