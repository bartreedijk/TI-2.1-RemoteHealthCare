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

        private void cmbChooseCom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((cmbChooseCom.Text == ""))
            {
                _global.startComPort(cmbChooseCom.SelectedItem.ToString());
                pgbInit.Value = 100;
            }
        }

        private void getAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            cmbChooseCom.Items.AddRange(ports);
        }


        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMode.SelectedItem.ToString() == "Distance" )
            {
                modeTXTBox.Visible = true;
                modeMinutes.Visible = false;
                modeSeconds.Visible = false;
                modeField.Text = cmbMode.SelectedItem.ToString() + " ( x 10 KM )";
            }
            else if(cmbMode.SelectedItem.ToString() == "Time")
            {
                modeTXTBox.Visible = false;
                modeMinutes.Visible = true;
                modeSeconds.Visible = true;
                modeField.Text = cmbMode.SelectedItem.ToString() + " ( Min:Sec )";
            }

            
        }

        private void setModeBTN_Click(object sender, EventArgs e)
        {
            int n, m;
            bool isNumeric = int.TryParse(modeTXTBox.Text, out n);

            if (cmbMode.SelectedItem.ToString() == "Distance")
            {
                if (isNumeric)
                {
                    _global.setDistanceMode(modeTXTBox.Text);
                }
                else
                {
                    MessageBox.Show("Distance is not a valid number.");
                }
            }
            else if (cmbMode.SelectedItem.ToString() == "Time")
            {
                bool isNumericS = int.TryParse(modeSeconds.Text, out n);
                bool isNumericM = int.TryParse(modeMinutes.Text, out m);

                if (isNumericM)
                {   
                    if (isNumericS)
                    {
                        _global.setTimeMode(modeMinutes + ":" + modeSeconds);
                    }
                    else
                    {
                        MessageBox.Show("Seconds is not a valid number.");
                    }
                }
                else
                {
                    MessageBox.Show("Minutes is not a valid number.");
                }
                
            }
        }

        private void setPWRBTN_Click(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(modeTXTBox.Text, out n);

            if (isNumeric)
            {
                _global.setPower(pwrBox.Text);
            }
            else
            {
                MessageBox.Show("Power is not a valid number.");
            }
        }
    }
}
