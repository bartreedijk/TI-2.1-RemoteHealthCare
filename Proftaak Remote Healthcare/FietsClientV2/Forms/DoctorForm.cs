using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FietsClient
{
    public partial class DoctorForm : Form
    {
        private TcpConnection connection;
        private DoctorModel doctorModel;

        public DoctorForm(TcpConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
            doctorModel = DoctorModel.doctorModel;
            doctorModel.doctorform = this;
            doctorModel.tcpConnection = connection;
            DataHandler.IncomingErrorEvent += HandleError;
        }

        private void HandleError(string error)
        {
            switch (error)
            {
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
