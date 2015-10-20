using FietsLibrary.JSONObjecten;
using FietsLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;
using System.IO;

namespace FietsClient
{
    public class TcpConnection
    {
        public TcpClient client;
        public bool isConnectedFlag { private set; get; }
        private SslStream sslStream;
        public CurrentData currentData { private set; get; }
        public string userID { private set; get; }

        private Thread receiveThread;

        public delegate void ChatmassegeDelegate(string[] data);
        public event ChatmassegeDelegate IncomingChatmessageEvent;
        public List<User> users = new List<User>();

        public TcpConnection()
        {
            client = new TcpClient();
            connect();
        }

        private void onIncomingChatMessage(string[] data)
        {
            ChatmassegeDelegate cMD = IncomingChatmessageEvent;
            if (cMD != null)
            {
                cMD(data);
            }
        }

        public bool isConnected()
        {
            return isConnectedFlag;
        }

        public void connect()
        {
            try
            {
                client.Connect("127.0.0.1", 1288);


                // create streams
                sslStream = new SslStream(client.GetStream(), false,
                    new RemoteCertificateValidationCallback(CertificateValidationCallback),
                    new LocalCertificateSelectionCallback(CertificateSelectionCallback));

                bool authenticationPassed = true;
                try
                {
                    string serverName = System.Environment.MachineName;

                    X509Certificate cert = GetServerCert();
                    X509CertificateCollection certs = new X509CertificateCollection();
                    certs.Add(cert);

                    sslStream.AuthenticateAsClient(
                        serverName,
                        certs,
                        SslProtocols.Default,
                        false); // check cert revokation
                }
                catch (AuthenticationException)
                {
                    authenticationPassed = false;
                }
                if (authenticationPassed)
                {
                    receiveThread = new Thread(receive);
                    receiveThread.Start();
                    isConnectedFlag = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Thread.Sleep(1000);
                isConnectedFlag = false;
            }
        }

        static X509Certificate CertificateSelectionCallback(object sender,
            string targetHost,
            X509CertificateCollection localCertificates,
            X509Certificate remoteCertificate,
            string[] acceptableIssuers)
        {
            return localCertificates[0];
        }

        private X509Certificate GetServerCert()
        {
            X509Certificate cert = new X509Certificate2(
                            @"testcert.pfx",
                            "jancoow");
            return cert;
        }

        private bool CertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public void disconnect()
        {

            sslStream.Close();
            client.Close();
            receiveThread.Abort();
            isConnectedFlag = false;
        }

        public void receive()
        {
            while (client.Connected)
            {
                byte[] bytesFrom = new byte[(int)client.ReceiveBufferSize];
                try
                {
                    sslStream.Read(bytesFrom, 0, client.ReceiveBufferSize);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.StackTrace);
                    break;
                }

                string response = Encoding.ASCII.GetString(bytesFrom);
                string[] response_parts = response.Split('|');

                if (response_parts.Length > 0)
                {
                    switch (response_parts[0])
                    {
                        case "0":   //login and display correct window after login
                            if (response_parts.Length == 4)
                            {


                                if (response_parts[1] == "1" && response_parts[2] == "1")
                                {
                                    currentData = new CurrentData(userID);
                                    currentData.isDoctor = true;
                                    SendGet(1);
                                }
                                else if (response_parts[2] == "0" && response_parts[1] == "1")
                                {

                                    currentData = new CurrentData(userID);
                                    currentData.isDoctor = false;
                                    SendGet(1);
                                }
                                else
                                    new Login("Geen gebruiker gevonden");
                            }
                            break;
                        case "1":
                            response_parts[1] = response_parts[1].TrimEnd('\0');
                            currentData.setSessionList(JsonConvert.DeserializeObject<List<Session>>(response_parts[1]));

                            if (currentData.isDoctor == true)
                            {
                                Form activeForm = Form.ActiveForm;
                                activeForm.Invoke((MethodInvoker)delegate ()
                               {
                                   DoctorForm doctorForm = new DoctorForm(this);
                                   activeForm.Hide();
                                   doctorForm.Show();
                               });
                            }
                            else
                            {
                                Form activeForm = Form.ActiveForm;
                                if (activeForm != null)
                                {
                                    activeForm.Invoke((MethodInvoker)delegate ()
                                    {
                                        PatientForm patientForm = new PatientForm(this);
                                        activeForm.Hide();
                                        patientForm.Show();
                                    });
                                }
                            }

                            break;
                        case "2":
                            currentData.GetSessions().Last().AddMeasurement(JsonConvert.DeserializeObject<Measurement>(response_parts[1]));
                            break;
                        case "7":
                            //                                        sender              receiver          message
                            onIncomingChatMessage(new string[] { response_parts[1], response_parts[2], response_parts[3].TrimEnd('\0') });
                            break;
                        case "8":
                            if (response_parts[1].TrimEnd('\0') != "-1")
                            {
                                DoctorModel.doctorModel.onlinePatients = response_parts[1].TrimEnd('\0').Split('\t').ToList();
                            }
                            else if (response_parts[1].TrimEnd('\0') == "-1")
                            {
                                DoctorModel.doctorModel.onlinePatients = new List<String>();
                            }
                            break;
                        case "9":
                            dynamic results = JsonConvert.DeserializeObject<dynamic>(response_parts[1]);

                            foreach (dynamic r in results)
                            {
                                User user = r as User;
                                users.Add(new User(r.id.ToString(), r.password.ToString(), Int32.Parse(r.age.ToString()),
                                    Boolean.Parse(r.gender.ToString()), Int32.Parse(r.weight.ToString()),
                                    Boolean.Parse(r.isDoctor.ToString())));

                                int i = 1;

                                foreach (dynamic ses in r.tests)
                                {
                                    Session tempSession = new Session(i, Int32.Parse(ses.bikeMode.ToString()), ses.modevalue.ToString());
                                    i++;

                                    foreach (dynamic m in ses.session)
                                    {
                                        Measurement measurement = new Measurement(Int32.Parse(m.pulse.ToString()), Int32.Parse(m.rpm.ToString()), Int32.Parse(m.speed.ToString()), Int32.Parse(m.wattage.ToString()), Int32.Parse(m.distance.ToString()), Int32.Parse(m.requestedPower.ToString()), Int32.Parse(m.energy.ToString()), Int32.Parse(m.actualPower.ToString()), Int32.Parse(m.time.ToString()), Int32.Parse(m.bpm.ToString()));
                                        tempSession.AddMeasurement(measurement);
                                    }

                                    users.Last().AddSession(tempSession);
                                }
                                Console.WriteLine(users);
                            }
                            break;
                    }
                }
            }
        }

        public void SendLogin(string username, string password)
        {
            // send command ( cmdID | username | password )
            this.userID = username;
            SendString("0|" + username + "|" + password + "|");
        }

        public void SendGet(int GetWhat)
        {
            // send command ( cmdID | username )
            SendString(GetWhat + "|" + userID + "|");
        }

        public void SendNewSession()
        {
            // send command ( cmdID | username )
            SendString("3|" + userID + FietsLibrary.JsonConverter.SerializeSession(currentData.GetSessions().Last()) + "|");
        }

        public void SendNewPatient(User user)
        {
            // send command ( cmdID | username )
            SendString("4|" + user.id + "|" + user.password + "|" + user.age + "|" + user.gender + "|" + user.weight + "|");
        }

        public void SendNewMeasurement()
        {
            // send command ( cmdID | username )
            SendString("5|" + userID + FietsLibrary.JsonConverter.SerializeLastMeasurement(currentData.GetSessions().Last().GetLastMeasurement()) + "|");
        }

        public void SendChatMessage(string[] data)
        {
            String receiverID = data[1];

            if (currentData != null)
            {
                String message = data[0];

                // send command ( cmdID | username sender | username receiverID | message )
                string protocol = "6|" + this.userID + "|" + receiverID + "|" + message;
                SendString(protocol);
            }
        }
        public void SendGetActivePatients()
        {
            SendString("8|" + userID + "|");
        }

        public void requestUsers()
        {
            SendString("9|");
        }
        public void SendDistance(int distance)
        {
            SendString("10|" + userID + "|" + distance + "|");
        }

        public void SendTime(int Minutes, int seconds)
        {
            SendString("11|" + userID + "|" + Minutes + ":" + seconds + "|");
        }

        public void SendPower(int power)
        {
            SendString("12|" + userID + "|" + power + "|");
        }


        public void SendString(string s)
        {

            byte[] b = Encoding.ASCII.GetBytes(s);
            sslStream.Write(b, 0, b.Length);
            sslStream.Flush();
        }
    }
}
