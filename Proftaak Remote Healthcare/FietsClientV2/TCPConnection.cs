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
        public CurrentData currentData { private set; get; }
        public string userID { private set; get; }
        private Thread receiveThread;

        public delegate void ChatmassegeDelegate(string[] data);
        public event ChatmassegeDelegate IncomingChatmessageEvent;

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
                    serverStream = client.GetStream();
                    receiveThread = new Thread(receive);
                    receiveThread.Start();
                    isConnectedFlag = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Thread.Sleep(1000);
                    isConnectedFlag = false;
                }
        }

        public void disconnect()
        {
            receiveThread.Abort();
            serverStream.Close();
            client.Close();
            isConnectedFlag = false;
        }

        public void receive()
        {
            while (true)
            {
                byte[] bytesFrom = new byte[(int)client.ReceiveBufferSize];
                serverStream.Read(bytesFrom, 0, client.ReceiveBufferSize);
                string response = Encoding.ASCII.GetString(bytesFrom);
                string[] response_parts = response.Split('|');

                if (response_parts.Length > 0)
                {
                    switch (response_parts[0])
                    {
                        case "0":   //login and display correct window after login
                            if (response_parts.Length == 4)
                            {
                                SendGet(1);

                                if (response_parts[1] == "1" && response_parts[2] == "1")
                                {
                                    currentData = new CurrentData(userID);
                                    currentData.isDoctor = true;
                                }
                                else if (response_parts[2] == "0" && response_parts[1] == "1")
                                {

                                    currentData = new CurrentData(userID);
                                    currentData.isDoctor = false;
                                }
                                else
                                    new Login("Geen gebruiker gevonden");
                            }
                            break;
                        case "1":
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
                            //                  sender              receiver            message
                            string[] data = { response_parts[1], response_parts[2], response_parts[3] };
                            
                            onIncomingChatMessage(data);
                            break;
                        case "8":
                            if (response_parts[1].TrimEnd('\0') != "-1")
                            {
                                DoctorModel.doctorModel.onlinePatients = response_parts[1].TrimEnd('\0').Split('\t').ToList();
                            } else if (response_parts[1].TrimEnd('\0') == "-1")
                            {
                                DoctorModel.doctorModel.onlinePatients = new List<String>();
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
            SendString("3|" + userID + lib.JsonConverter.SerializeSession(currentData.GetSessions().Last()) + "|");
        }

        public void SendNewMeasurement()
        {
            // send command ( cmdID | username )
            SendString("5|" + userID + lib.JsonConverter.SerializeLastMeasurement(currentData.GetSessions().Last().GetLastMeasurement()) + "|");
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
            serverStream.Write(b, 0, b.Length);
            serverStream.Flush();
        }
    }
}
