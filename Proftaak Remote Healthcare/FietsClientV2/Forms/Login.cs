using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FietsClient
{
    public partial class Login : Form
    {
        private TcpConnection connection;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Login(TcpConnection conn)
        {
            connection = conn;
            InitializeComponent();
        }

        public Login(String message)
        {
            InitializeComponent();
            errorLBL.Text = message;
        }

        public void setError(String message)
        {
            errorLBL.Text = message;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(UsernameBox.Text))
            {
                errorLBL.Text = "Username is incorrect";
            }
            else if (string.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                errorLBL.Text = "Password is incorrect";
            }
            else
            {
                connection.sendLogin(UsernameBox.Text, PasswordBox.Text);
                PasswordBox.Text = "";
            }
        }

        private void menuBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            checkConnection();
        }

        private void checkConnection()
        {
            if (!connection.isConnected())
            {
                connLBL.Text = "No Connection established";
            }
            else
            {
                connLBL.Text = "";
            }
        }

        private void reconnectBTN_Click(object sender, EventArgs e)
        {
            if(!connection.isConnected())
            {
                connection.connect();
                checkConnection();
                this.Refresh();
            }
            
        }
    }
    
}
