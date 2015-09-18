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

            addTextToLog("pulse: " + data[0] + ", rpm: " + data[1] + ",  speed*10: " + data[2] + ",  distance: " + data[3] +
                ",  requested_power: " + data[4] + ", energy: " + data[5] + ", mm:ss: " + data[6] + ", actual_power: " + data[7]);
        }
    }
}
