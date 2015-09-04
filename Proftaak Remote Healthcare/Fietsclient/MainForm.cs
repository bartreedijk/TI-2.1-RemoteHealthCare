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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _global.startComPort();
        }


    }
}
