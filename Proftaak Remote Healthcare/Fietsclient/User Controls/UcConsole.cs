using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fietsclient.User_Controls
{
    public partial class UcConsole : UserControl
    {
        public UcConsole()
        {
            InitializeComponent();
            KettlerBikeComm.IncomingDataEvent += HandleBikeData;
            KettlerBikeComm.IncomingDebugLineEvent += addTextToLog;
        }

        private void addTextToLog(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((new Action(() => addTextToLog(text))));
                return;
            }

            tbConsole.AppendText(text + "\n");
        }

        private void HandleBikeData(string[] data)
        {

            addTextToLog("Pulse: " + data[0] + ", Rpm: " + data[1] + ",  Speed: " + data[2] + ",  Distance: " + data[3] +
                ",  Requestedpower: " + data[4] + ", Energy: " + data[5] + ", Time: " + data[6] + ", Actualpower: " + data[7]);
        }
    }
}
