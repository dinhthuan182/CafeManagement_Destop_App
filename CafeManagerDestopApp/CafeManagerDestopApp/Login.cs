using System;
using System.Windows.Forms;

namespace CafeManagerDestopApp
{
    public partial class Login : Form
    {
        private Network.Network apiNetwork = new Network.Network();
        public Login()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btn_login_Click(object sender, EventArgs e)
        {

            btn_login.Enabled = false;
            if (string.IsNullOrWhiteSpace(txt_username.Text) || string.IsNullOrWhiteSpace(txt_password.Text) || txt_username.Text == "Username" || txt_password.Text == "Password")
            {
                MessageBox.Show("Please enter your username and password");
                btn_login.Enabled = true;
                return;
            }

            var token = await apiNetwork.LoginAsync(txt_username.Text, txt_password.Text);
            if (token == null) {
                MessageBox.Show("Username and password are incorrect");
            } else
            {
                if (token.Item1)
                {
                    var frm = new MainScreen
                    {
                        Location = this.Location,
                        StartPosition = FormStartPosition.Manual
                    };
                    frm.FormClosing += delegate { this.Show(); };
                    frm.Show();
                    this.Hide();
                } else
                {
                    MessageBox.Show(token.Item2);
                }  
            }
            btn_login.Enabled = true;
        }

    }
}
