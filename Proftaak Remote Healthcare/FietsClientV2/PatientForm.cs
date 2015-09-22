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

namespace FietsClientV2
{
    public partial class PatientForm : Form
    {
        private PatientModel patienModel;
        public PatientForm()
        {
            InitializeComponent();
            patienModel = PatientModel.patientModel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            toolStripComboBox1.Items.AddRange(ports);
        }

        private void requestDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patienModel.startAskingData();
        }

        private void closePortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patienModel.closeComPort();
        }

        private void openPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patienModel.startComPort(toolStripComboBox1.SelectedItem.ToString());
            requestDataToolStripMenuItem.Enabled = true;
            closePortToolStripMenuItem.Enabled = true;
        }
    }
}
