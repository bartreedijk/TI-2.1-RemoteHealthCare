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
        public MainForm(AppGlobal global)
        {
            InitializeComponent();
            _global = global;
            ucSettings1.Visible = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _global.startComPort();
        }





        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        

        private void cmbComport_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucGraph1.Visible = true;
            ucChat1.Visible = false;
            ucConsole1.Visible = false;
            ucSettings1.Visible = false;

        }

        private void setingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucGraph1.Visible = false;
            ucChat1.Visible = false;
            ucConsole1.Visible = false;
            ucSettings1.Visible = true;
        }

        private void chatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucGraph1.Visible = false;
            ucChat1.Visible = true;
            ucConsole1.Visible = false;
            ucSettings1.Visible = false;
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucGraph1.Visible = false;
            ucChat1.Visible = false;
            ucConsole1.Visible = true;
            ucSettings1.Visible = false;
        }
    }
}
