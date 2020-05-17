using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagerDestopApp
{
    public partial class MainScreen : Form
    {
        private Network.Network apiNetwork = new Network.Network();
        public MainScreen()
        {
            InitializeComponent();
            setupUser();
        }

        public void setupUser()
        {
            lblName.Text = "User: " + AuthGlobals.user.name;
            lblRole.Text = AuthGlobals.user.role;
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
