using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FietsLibrary;
using FietsLibrary.JSONObjecten;

namespace FietsClient.Forms
{
    public partial class NewPatientForm : Form
    {
        private TcpConnection connection;
        public NewPatientForm(TcpConnection tcpConnections)
        {
            InitializeComponent();
            connection = tcpConnections;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int age;
            int weight;
            if (!int.TryParse(textBox2.Text, out age) || !int.TryParse(textBox4.Text, out weight))
            {
                MessageBox.Show("Leeftijd en Gewicht moeten numeriek zijn.");
            }
            else
            {
                bool gender;
                if (comboBox1.SelectedText == "Man")
                {
                    gender = true;
                }
                else
                {
                    gender = false;
                }

                User user = new User(textBox1.Text, passBox.Text, age, gender,
                    weight, false);
                connection.SendNewPatient(user);
                this.Visible = false;
            }
        }
    }
}
