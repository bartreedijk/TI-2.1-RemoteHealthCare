using System;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Server.JSONObjecten;
using JsonConverter = Server.FileIO.JsonConverter;

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
            Thread t = new Thread(recieve);
            t.Start();
        }

        public void recieve()
        {
            while (true)
            {
                byte[] bytesFrom = new byte[(int)client.ReceiveBufferSize];
                networkStream.Read(bytesFrom, 0, (int)client.ReceiveBufferSize);
                String response = Encoding.ASCII.GetString(bytesFrom);
                String[] response_parts = response.Split('|');
                if (response_parts.Length > 0)
                {
                    User currentUser = null;
                    switch (response_parts[0])
                    {
                        case "0":   //login
                            if (response_parts.Length == 4)
                            {
                                int admin, id;
                                _global.CheckLogin(response_parts[1], response_parts[2], out admin, out id);
                                if (id > -1)
                                {
                                    if(_global.GetUsers().First(item => item.id == response_parts[1]).isDoctor)
                                    {
                                        sendString("0|1|1|");   // Doctor
                                    }
                                    else
                                    {
                                        sendString("0|1|0|");   //Patient
                                    }  
                                }
                                else
                                {
                                    sendString("0|0|0|");
                                }
                            }
                            break;
                        case "1":   //meetsessies ophalen

                            currentUser = _global.GetUsers().First(item => item.id == response_parts[1]);
                            sendString("1|" + JsonConverter.GetUserSessions(currentUser));
                            break;
                        case "2":   //Livedata opvragen

                            currentUser = _global.GetUsers().First(item => item.id == response_parts[1]);

                            JsonConverter.GetLastMeasurement(currentUser.tests.Last());
                            break;
                        case "3":   //Nieuwe meetsessie aanmaken
                            if (response_parts.Length == 6 && iduser != -1)
                            {
                                _global.AddSession(response_parts[1], int.Parse(response_parts[2]), response_parts[3]);
                            }
                            break;
                        case "4":   //Check nieuwe meetsessie



                            break;
                        case "5":   //data pushen naar meetsessie

                            currentUser = _global.GetUsers().First(item => item.id == response_parts[1]);
                            currentUser.tests.Last().AddMeasurement(JsonConvert.DeserializeObject<Measurement>(response_parts[2]));

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
