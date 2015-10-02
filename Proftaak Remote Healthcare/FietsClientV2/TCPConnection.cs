using FietsClient.JSONObjecten;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FietsClient
{
    public class TcpConnection
    {
        public TcpClient client;
        public bool isConnectedFlag { private set; get; }
        private NetworkStream serverStream;
        private CurrentData currentData;
        private string userID;
        private Thread receiveThread;

        public TcpConnection()
        {
            client = new TcpClient();
            connect();
        }

        public void connect()
        {

            try
            {
                client.Connect("145.48.226.156", 1288);

                // create streams
                serverStream = client.GetStream();
                receiveThread = new Thread(receive);
                receiveThread.Start();
                isConnectedFlag = true;
            }
            catch (Exception)
            {
                Thread.Sleep(1000);
                isConnectedFlag = false;
            }
        }
        
        public void receive()
        {
            while (true)
            {
                byte[] bytesFrom = new byte[(int)client.ReceiveBufferSize];
                serverStream.Read(bytesFrom, 0, (int)client.ReceiveBufferSize);
                string response = Encoding.ASCII.GetString(bytesFrom);
                string[] response_parts = response.Split('|');

                if (response_parts.Length > 0)
                {
                    switch (response_parts[0])
                    {
                        case "0":   //login
                            if (response_parts.Length == 4)
                            {
                                if (response_parts[1] == "1" && response_parts[2] == "1")
                                {
                                    DoctorForm doctorForm = new DoctorForm();
                                    doctorForm.Show();
                                    currentData = new CurrentData(userID);
                                }
                                else if(response_parts[2] == "0" && response_parts[1] == "1")
                                {
                                    PatientForm form = new PatientForm(this);
                                    Form activeForm = Form.ActiveForm;

                                    activeForm.Invoke((MethodInvoker)delegate () {
                                        activeForm.Hide();
                                        form.Show();
                                    });
                                    currentData = new CurrentData(userID);
                                }
                                else
                                    new Login("Geen gebruiker gevonden");
                            }
                            break;
                        case "1":
                            currentData.setSessionList(JsonConvert.DeserializeObject<List<Session>>(response_parts[1]));
                            break;
                        case "2":
                            currentData.GetSessions().Last().AddMeasurement(JsonConvert.DeserializeObject<Measurement>(response_parts[1]));
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
            SendString(GetWhat + "|" + userID);
        }

        public void SendNewSession()
        {
            // send command ( cmdID | username )
            SendString("3|" + userID + lib.JsonConverter.SerializeSession(currentData.GetSessions().Last()));
        }

        public void SendNewMeasurement()
        {
            // send command ( cmdID | username )
            SendString("5|" + userID + lib.JsonConverter.SerializeLastMeasurement(currentData.GetSessions().Last().GetLastMeasurement()));
        }

        public void SendString(string s)
        {
            byte[] b = Encoding.ASCII.GetBytes(s);
            serverStream.Write(b, 0, b.Length);
            serverStream.Flush();
        }

    }
}
