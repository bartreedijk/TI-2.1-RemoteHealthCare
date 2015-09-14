using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace Fietsclient
{
    public partial class MainForm : Form
    {
        private readonly AppGlobal _global;
        public MainForm(AppGlobal global)
        {
            InitializeComponent();
            getAvailablePorts();
            _global = global;
            KettlerBikeComm.IncomingDataEvent += HandleBikeData;
        }

        private void getAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            ComPortComboBox.Items.AddRange(ports);
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
            ComPortProgressBar.Value = 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ComPortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(ComPortComboBox.Text == ""))
            {
                _global.startComPort(ComPortComboBox.Text);
                ComPortProgressBar.Value = 100;
            }
        }
    }
}
