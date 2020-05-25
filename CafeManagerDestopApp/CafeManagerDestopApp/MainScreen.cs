using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using PusherClient;

namespace CafeManagerDestopApp
{
    public partial class MainScreen : Form
    {
        private Network.Network apiNetwork = new Network.Network();
        private static Pusher _pusher;
        private static Channel _orderChannel;

        public MainScreen()
        {
            InitializeComponent();
            setupUser();
            InitPusher();
        }

        public void setupUser()
        {
            lblName.Text = "User: " + AuthGlobals.user.name;
            lblRole.Text = AuthGlobals.user.role;
        }

        // Pusher Initiation / Connection
        private async void InitPusher()
        {
            _pusher = new Pusher("625e6f2e093b6e564050", new PusherOptions()
            {
                Encrypted = true,
                Cluster = "ap1"
            });

            // Setup private channel
            _orderChannel = _pusher.SubscribeAsync("desktop-app").Result;

            // Inline binding!
            _orderChannel.Bind("orderProducts-event", (dynamic data) =>
            {
                var jObject = JObject.Parse(data.data.ToString());
                var fileName = jObject.GetValue("url").ToString();
                var host = jObject.GetValue("host").ToString();
                apiNetwork.DownloadFileToLocal(host, fileName, Network.PrintType.Order);
            });
            await _pusher.ConnectAsync();
        }

        private async void logout_btn_Click(object sender, EventArgs e)
        {
            
            DialogResult conform = MessageBox.Show("Are you sure you want to log out?",
                    "Notification",
                    MessageBoxButtons.YesNo);
            if (conform == DialogResult.Yes)
            {
                Boolean res = await apiNetwork.LogoutAsync();
                if (res)
                {
                    var frm = new Login();
                    frm.Location = this.Location;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.FormClosing += delegate { this.Show(); };
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Logout failed, Please try again.", "Notification");
                }
            }
            
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            var frm = new CheckinControl();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
        }
    }
}
