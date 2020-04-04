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
            string token = await apiNetwork.LoginAsync(txt_username.Text, txt_password.Text);
            //txt_username.Text = token;
        }

    }
}
