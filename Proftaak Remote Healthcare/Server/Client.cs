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
using System.Net.Security;
using System.Security.Authentication;
using Server.lib;
using System.IO;

namespace Server
{
    public class Client
    {
        TcpClient client;
        SslStream sslStream;
        private readonly AppGlobal _global;
        public int iduser { get; private set; }
        public string username { get; private set; }
        private Thread _workerThread;

        public Client(TcpClient socket)
        {
            client = socket;
            

            sslStream = new SslStream(client.GetStream());
            try
            {
                sslStream.AuthenticateAsServer(lib.SSLCrypto.LoadCert(), false, SslProtocols.Default, false);
            }
            catch (IOException e)
            {
                Console.WriteLine("IOExeption occured while a client tried to connect.");
                Console.WriteLine(e.StackTrace);
                Stop();
            }

            _global = AppGlobal.Instance;
            iduser = -1;
            Console.WriteLine("New client connected");
            _workerThread = new Thread(receive);
            _workerThread.Start();
        }

        public void receive()
        {
            while (!(client.Client.Poll(0, SelectMode.SelectRead) && client.Client.Available == 0))
            {
                byte[] bytesFrom = new byte[(int)client.ReceiveBufferSize];
                try
                {
                    sslStream.Read(bytesFrom, 0, (int)client.ReceiveBufferSize);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception occured while trying to get data from client. Disconnecting...");
                    Console.WriteLine(e.StackTrace);
                    Stop();
                }
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
                                String message = response_parts[3].TrimEnd('\0');
                                String receiver = response_parts[2];
                                String sender = response_parts[1];

                                string case6str = "7|" + sender + "|" + receiver + "|" + message;
                                Console.WriteLine(case6str);
                                sendString(case6str);

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
                                    }
                                    else
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
                        default:
                            break;

                    }
                }
            }
            Stop();
        }

        private void Stop()
        {
            Program.RemoveClientFromList(this);
            if (_workerThread != null)
                _workerThread.Abort();
        }

        public void sendString(string s)
        {
            byte[] b = Encoding.ASCII.GetBytes(s);
            sslStream.Write(b, 0, b.Length);
            sslStream.Flush();
        }
    }
}
