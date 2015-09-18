using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Fietsclient.User_Controls
{
    public partial class UcSettings : UserControl
    {
        private AppGlobal _global;

        public UcSettings()
        {
            InitializeComponent();
            _global = AppGlobal.Instance;
            getAvailablePorts();
        }

        private void btnCloseCom_Click(object sender, EventArgs e)
        {
            _global.closeComPort();
        }

        private void btnStartAsking_Click(object sender, EventArgs e)
        {
            _global.startAskingData();
        }

        private void chkChooseData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbChooseCom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!(cmbChooseCom.Text == ""))
            {
                _global.startComPort(cmbChooseCom.Text);
                pgbInit.Value = 100;
            }
        }

        private void getAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            cmbChooseCom.Items.AddRange(ports);
        }
    }
}
