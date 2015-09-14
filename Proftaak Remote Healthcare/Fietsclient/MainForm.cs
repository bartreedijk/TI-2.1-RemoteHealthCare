using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Fietsclient
{
    public partial class MainForm : Form
    {
        private readonly AppGlobal _global;
        private SerialPort ComPort;
        string port;

        public MainForm(AppGlobal global)
        {
            InitializeComponent();
            _global = global;
            KettlerBikeComm.IncomingDataEvent += HandleBikeData;
            foreach (String item in getComports())
            {
                cmbComport.Items.Add(item);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            _global.startComPort(port);

        }

        private void HandleBikeData(string[] data)
        {
            addTextToLog("pulse: " + data[0] + ", rpm: " + data[1] + ",  speed*10: " + data[2] + ",  distance: " + data[3] +
                ",  requested_power: " + data[4] + ", energy: " + data[5] + ", mm:ss: " + data[6] + ", actual_power: " + data[7]);
        }

        private void addTextToLog(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((new Action(() => addTextToLog(text))));
                return;
            }

            textBox1.AppendText(text + "\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _global.startAskingData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _global.closeComPort();
        }

        private String[] getComports()
        {
            return SerialPort.GetPortNames();
        }

        private void cmbComport_SelectionChangeCommitted(object sender, EventArgs e)
        {
            port = cmbComport.SelectedItem.ToString();
        }
    }
}
