using Newtonsoft.Json;
using ServerV2.FileIO;
using ServerV2.JSONObjecten;
using ServerV2.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerV2
{
    class AppGlobal
    {
        private TcpListener listener;
        private List<Client> clients = new List<Client>();
        private List<User> users = new List<User>();

        public AppGlobal()
        {
            listener = new TcpListener(IPAddress.Any, 1288);
            listener.Start();
            while (true)
            {
                TestMethode();
                Console.WriteLine(FileIO.JsonConverter.GetUserSessions(users.ElementAt(1)));
                Console.WriteLine("waiting for clients...");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("connection received");
                new Thread(receive).Start(client);
            }
        }

        private void TestMethode()
        {
            users.Add(new User("JK123", "jancoow", 5, true, 100));
            users.Add(new User("patient", "patient", 0, false, 0));
            users.Add(new User("doctor", "doctor", 0, false, 0, true));
            users.Add(new User("admin", "admin", 80, false, 77, true));

            Random r = new Random();
            Session session = new Session(1, "100");
            for (int i = 0; i < 20; i++)
                session.AddMeasurement(new Measurement(r.Next(100, 200), r.Next(60, 100), r.Next(100, 150), r.Next(0, 100), i, r.Next(100), r.Next(100), r.Next(100), i, r.Next(100)));
            users.ElementAt(1).tests.Add(session);

            Session session2 = new Session(2, "100");
            for (int i = 0; i < 50; i++)
                session2.AddMeasurement(new Measurement(r.Next(100, 200), r.Next(60, 100), r.Next(100, 150), r.Next(0, 100), i, r.Next(100), r.Next(100), r.Next(100), i, r.Next(100)));
            users.ElementAt(1).tests.Add(session2);
        }

        private void receive(object obj)
        {
            TcpClient client = obj as TcpClient;
            User currentUser;
            while (!(client.Client.Poll(0, SelectMode.SelectRead) && client.Client.Available == 0))
            {
                string[] response = Encoding.ASCII.GetString(new byte[(int)client.ReceiveBufferSize]).Split('|');
                switch (response[0])
                {
                    case "0":
                        if (response.Length == 4)
                        {
                            int admin, id = 0;
                            //check username and password
                            foreach (User u in users)
                            {
                                if (u.id == response[1] && u.password == response[2])
                                {
                                    admin = u.isDoctor ? 1 : 0;
                                    id = users.IndexOf(u);
                                }
                            }

                            if (id > -1)
                            {
                                if (users.First(item => item.id == response[1]).isDoctor)
                                {
                                    Console.WriteLine($"received login from docter username: {response[1]} ");
                                    Communication.SendMessage(client, "0|1|1|");   // Doctor
                                }
                                else
                                {
                                    Console.WriteLine($"received login from patient username: {response[1]} ");
                                    Communication.SendMessage(client, "0|1|0|");   //Patient
                                }
                                clients.Add(new Client(client, response[1]));
                            }
                            else
                            {
                                Console.WriteLine("received incorrect username or password");
                                Communication.SendMessage(client, "0|0|0|"); // Does not exist
                            }
                        }
                        break;
                    case "1":   //meetsessies ophalen
                        currentUser = users.First(item => item.id == response[1]);
                        Communication.SendMessage(client, "1|" + FileIO.JsonConverter.GetUserSessions(currentUser));
                        break;
                    case "2":   //Livedata opvragen
                        currentUser = users.First(item => item.id == response[1]);
                        FileIO.JsonConverter.GetLastMeasurement(currentUser.tests.Last());
                        break;
                    case "3":   //Nieuwe meetsessie aanmaken
                        if (response.Length == 6)
                        {
                            foreach (User u in users)
                            {
                                if (u.id == response[1])
                                    u.AddSession(new Session(int.Parse(response[2]), response[3]));
                            }
                        }
                        break;
                    case "4":  // Nieuwe patient
                        users.Add(new User(response[1], response[2], Int32.Parse(response[3]), Boolean.Parse(response[4]), Int32.Parse(response[5])));
                        break;
                    case "5":   //data pushen naar meetsessie
                        currentUser = users.First(item => item.id == response[1]);
                        currentUser.tests.Last().AddMeasurement(JsonConvert.DeserializeObject<Measurement>(response[2]));
                        break;
                    case "6": //chatberichten ontvangen van gebruikers
                        //controleren of het bericht wel tekens bevat
                        if (response[3] != null)
                        {
                            string message = response[3].TrimEnd('\0');
                            string receiver = response[2];
                            string sender = response[1];

                            string case6str = "7|" + sender + "|" + receiver + "|" + message;
                            Console.WriteLine(case6str);
                            Communication.SendMessage(client, case6str);
                            for (int i = 0; i < clients.Count; i++)
                            {
                                if (clients[i].username == receiver)
                                    Communication.SendMessage(clients[i].tcpClient, "7|" + sender + "|" + receiver + "|" + message);
                            }
                        }
                        break;
                    case "8": //alle online Patients sturen naar Doctorclient
                        if (response[1] != null)
                        {
                            if (response[1] == "doctor" || true) //TODO: doctor check
                            {
                                List<string> patients = new List<string>();
                                foreach (Client c in clients)
                                {
                                    User user = users.FirstOrDefault(item => item.id == c.username);
                                    if (user != null)
                                        if (!user.isDoctor)
                                            patients.Add(user.id);
                                }

                                string strToSend = "8|";
                                if (!(patients.Count > 0))
                                    strToSend += "-1";
                                else
                                    foreach (string patient in patients)
                                    {
                                        strToSend += (patient + '\t');
                                    }
                                Communication.SendMessage(client, strToSend.TrimEnd('\t'));
                            }
                        }
                        break;
                    case "9": //alles doorsturen voor de dokter
                        Communication.SendMessage(client, FileIO.JsonConverter.GetUsers(users));
                        break;
                    default:
                        break;
                }
            }
        }

    }

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


