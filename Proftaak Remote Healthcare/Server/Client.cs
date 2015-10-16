using System;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Server.JSONObjecten;
using JsonConverter = Server.FileIO.JsonConverter;
using System.Collections.Generic;

namespace Server
{
    public class Client
    {
        TcpClient client;
        NetworkStream networkStream;
        private readonly AppGlobal _global;
        public int iduser { get; private set; }
        public string username { get; private set; }
        private Thread _workerThread;

        public Client(TcpClient socket)
        {
            client = socket;
            networkStream = client.GetStream();
            _global = AppGlobal.Instance;
            iduser = -1;
            Console.WriteLine("New client connected");
            _workerThread = new Thread(recieve);
            _workerThread.Start();
        }

        public void recieve()
        {
            while (!(client.Client.Poll(0, SelectMode.SelectRead) && client.Client.Available == 0))
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
                                    this.username = response_parts[1];
                                    this.iduser = id;
                                    if (_global.GetUsers().First(item => item.id == response_parts[1]).isDoctor)
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
                        case "4":  // Nieuwe patient
                            User user = new User(response_parts[1], response_parts[2], Int32.Parse(response_parts[3]), Boolean.Parse(response_parts[4]), Int32.Parse(response_parts[5]));
                            _global.NewUser(user);
                            break;
                        case "5":   //data pushen naar meetsessie

                            currentUser = _global.GetUsers().First(item => item.id == response_parts[1]);
                            currentUser.tests.Last().AddMeasurement(JsonConvert.DeserializeObject<Measurement>(response_parts[2]));

                            break;

                        case "6": //chatberichten ontvangen van gebruikers

                            //controleren of het bericht wel tekens bevat
                            if (response_parts[3] != null)
                            {
                                String message = response_parts[3];
                                String receiver = response_parts[2];
                                String sender = response_parts[1];

                                sendString("7|" + sender + "|" + receiver + "|" + message);
                                foreach (var client in Program.Clients)
                                {
                                    if (client.username == receiver)
                                        client.sendString("7|" + sender + "|" + receiver + "|" + message);
                                }
                            }
                            break;
                        case "8": //alle online Patients sturen naar Doctorclient
                            if (response_parts[1] != null)
                            {
                                if (response_parts[1] == "doctor" || true) //TODO: doctor check
                                {
                                    string strToSend = "8|";
                                    List<string> activePatients = _global.GetActivePatients();
                                    if (!(activePatients.Count > 0))
                                    {
                                        strToSend += "-1";
                                    } else
                                    {
                                        foreach (string patient in _global.GetActivePatients())
                                        {
                                            strToSend += (patient + '\t');
                                        }
                                    }
                                    sendString(strToSend.TrimEnd('\t'));
                                }
                            }
                            break;
                    }
                }
            }
            Stop();
        }

        private void Stop()
        {
            Program.RemoveClientFromList(this);
            _workerThread.Abort();
        }

        public void sendString(string s)
        {
            byte[] b = Encoding.ASCII.GetBytes(s);
            networkStream.Write(b, 0, b.Length);
            networkStream.Flush();
        }
    }
}
