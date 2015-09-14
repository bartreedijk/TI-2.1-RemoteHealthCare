using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Fietsclient
{
    public partial class MainForm : Form
    {
        private readonly AppGlobal _global;
        public MainForm(AppGlobal global)
        {
            InitializeComponent();
            _global = global;
            KettlerBikeComm.IncomingDataEvent += HandleBikeData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _global.startComPort();
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

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
