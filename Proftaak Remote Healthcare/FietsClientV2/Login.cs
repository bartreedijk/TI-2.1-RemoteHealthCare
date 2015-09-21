using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FietsClientV2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;
            PasswordBox.Text = "";

            //temporary fake login as patient
            if (false)
            {
                PatientForm patientForm = new PatientForm();
                this.Hide();
                patientForm.Show();
            }
            else
            {
                DoctorForm doctorForm = new DoctorForm();
                this.Hide();
                doctorForm.Show();
            }

            //TO DO
            // add way to check if correct username or password
            // and if doctor or patient
            /*
            if (patient)
            {
                PatientForm patientForm = new PatientForm();
                this.Hide();
                patientForm.Show();
            }
            //else if (doctor)
            {
                DoctorForm doctorForm = new DoctorForm();
                this.Hide();
                doctorForm.Show();
            }
            */
        }
    }
}
