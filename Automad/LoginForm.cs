using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automad
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    String user = username.Text;
                    String pass = password.Text;
                    connection conn = new connection();
                    String response = conn.login(user, pass);
                    if (response == "success")
                    {
                        Properties.Settings.Default.username = username.Text;
                        Properties.Settings.Default.password = password.Text;
                        Properties.Settings.Default.Save();
                        conn.log(user);
                        Main myform = new Main();
                        this.Hide();
                        myform.ShowDialog();
                        this.Close();
                    }
                    else if (response == "invalid")
                    {
                        MessageBox.Show("Invalid Username or Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (response == "blocked")
                    {
                        MessageBox.Show("Please contact your administrator", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }

                }
                else
                {
                    MessageBox.Show("Please check your internet connection");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                MessageBox.Show("Please check your internet connection");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.username != string.Empty)
            {
                username.Text = Properties.Settings.Default.username;
                password.Text = Properties.Settings.Default.password;

            }
        }
    }
}
