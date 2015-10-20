using Newtonsoft.Json;
using FietsLibrary.JSONObjecten;
using FietsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Security;
using System.IO;
using System.Security.Authentication;

namespace ServerV2
{
    class AppGlobal
    {
        public TcpListener listener { get; private set; }
        public List<Client> clients { get; private set; } = new List<Client>();
        public List<User> users { get; private set; } = new List<User>();

        public AppGlobal()
        {
            listener = new TcpListener(IPAddress.Any, 1288);
            listener.Start();
            TestMethode();
            while (true)
            {
                
                Console.WriteLine(FietsLibrary.JsonConverter.GetUserSessions(users.ElementAt(1)));
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
            Session session = new Session();
            for (int i = 0; i < 20; i++)
                session.AddMeasurement(new Measurement(r.Next(100, 200), r.Next(60, 100), r.Next(100, 150), r.Next(0, 100), i, r.Next(100), r.Next(100), r.Next(100), i, r.Next(100)));
            users.ElementAt(1).sessions.Add(session);

            Session session2 = new Session();
            for (int i = 0; i < 50; i++)
                session2.AddMeasurement(new Measurement(r.Next(100, 200), r.Next(60, 100), r.Next(100, 150), r.Next(0, 100), i, r.Next(100), r.Next(100), r.Next(100), i, r.Next(100)));
            users.ElementAt(1).sessions.Add(session2);
        }

        private SslStream InitialiseConnection(TcpClient client)
        {
            SslStream sslStream = new SslStream(client.GetStream());
            try
            {
                sslStream.AuthenticateAsServer(SSLCrypto.LoadCert(), false, SslProtocols.Default, false);
            }
            catch (IOException e)
            {
                Console.WriteLine("IOExeption occured while a client tried to connect.");
                Console.WriteLine(e.StackTrace);
                //Stop();
            }
            Console.WriteLine("New client connected");
            return sslStream;
        }

        

        private void receive(object obj)
        {
            TcpClient client = obj as TcpClient;
            User currentUser;

            SslStream sslStream = InitialiseConnection(client);

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
                    //Stop();
                }

                string[] response = Encoding.ASCII.GetString(bytesFrom).Split('|');

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
                                var user = users.FirstOrDefault(item => item.id == response[1]);
                                if (user == null)
                                {
                                    Console.WriteLine("received incorrect username or password");
                                    Communication.Send("0|0|0|", sslStream); // Does not exist
                                }
                                else if (user.isDoctor)
                                {
                                    Console.WriteLine("received login from docter username: " + response[1]);
                                    Communication.Send("0|1|1|", sslStream);   // Doctor
                                }
                                else if (!user.isDoctor)
                                {
                                    Console.WriteLine("received login from patient username: " + response[1]);
                                    Communication.Send("0|1|0|", sslStream);   //Patient
                                }
                                clients.Add(new Client(client, sslStream, response[1]));
                            }
                            else
                            {
                                Console.WriteLine("IOException");
                                Communication.Send("0|0|0|", sslStream); // Does not exist
                            }
                        }
                        break;
                    case "1":   //meetsessies ophalen
                        currentUser = users.First(item => item.id == response[1]);
                        Communication.Send("1|" + FietsLibrary.JsonConverter.GetUserSessions(currentUser), sslStream);
                        break;
                    case "2":   //Livedata PUSHEN/OPVRAGEN
                        currentUser = users.First(item => item.id == response[1]);
                        string lastMeasurement = FietsLibrary.JsonConverter.GetLastMeasurement(currentUser.sessions.Last());
                        Communication.Send("2|" + lastMeasurement + "|", sslStream);
                        break;
                    case "3":   //Nieuwe meetsessie aanmaken
                        if (true)
                        {
                            foreach (User u in users)
                            {
                                if (u.id == response[1])
                                    u.AddSession(new Session());
                            }
                        }
                        break;
                    case "4":  // Nieuwe patient
                        users.Add(new User(response[1], response[2], Int32.Parse(response[3]), Boolean.Parse(response[4]), Int32.Parse(response[5])));
                        break;
                    case "5":   //data pushen naar meetsessie
                        currentUser = users.FirstOrDefault(item => item.id == response[1]);
                        if (currentUser != null && currentUser.sessions.LastOrDefault() != null)
                        {
                            currentUser.sessions.Last().AddMeasurement(JsonConvert.DeserializeObject<Measurement>(response[2]));
                        }
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
                            Communication.Send(case6str, sslStream);
                            for (int i = 0; i < clients.Count; i++)
                            {
                                if (clients[i].username == receiver)
                                    Communication.Send("7|" + sender + "|" + receiver + "|" + message, clients[i].sslStream);
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
                                Communication.Send(strToSend.TrimEnd('\t'), sslStream);
                            }
                        }
                        break;
                    case "9": //alles doorsturen voor de dokter
                        Console.WriteLine("send users");
                        string file = "9|" + FietsLibrary.JsonConverter.GetUsers(users);
                        Communication.Send(file, sslStream);
                        break;
                    case "10":
                        if (response[1] == "1" || response[1] == "0") //start of stop sesie (met check)
                        {
                            Client Case10Client = clients.FirstOrDefault(item => item.username == response[2].TrimEnd('\0'));
                            string Case10String = "10|" + response[1] + "|";
                            Communication.Send(Case10String, Case10Client.sslStream);
                        }
                        break;
                    default:
                        break;
                }


            }
        }

    }

    class Client
    {
        public TcpClient client { get; private set; }
        public SslStream sslStream { get; private set; }
        public string username;

        public Client(TcpClient client, SslStream sslStream, string username)
        {
            this.client = client;
            this.sslStream = sslStream;
            this.username = username;
        }

        

    }
}


