using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagerDestopApp
{
    public partial class CheckinControl : Form
    {
        private Network.Network apiNetwork = new Network.Network();
        public CheckinControl()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.txtCheckname.Text == "Username" || this.txtCheckname.Text == "") {
                MessageBox.Show("Please enter your username to checkin.");
                return;
            }

            var result = await apiNetwork.CheckinAsync(this.txtCheckname.Text);
            
            if (result == null)
            {
                MessageBox.Show("Can not checkout");
                return;
            }

            MessageBox.Show(result.Item2);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            if (this.txtCheckname.Text == "Username" || this.txtCheckname.Text == "")
            {
                MessageBox.Show("Please enter your username to checkout.");
                return;
            }

            var result = await apiNetwork.CheckoutAsync(this.txtCheckname.Text);

            if (result == null)
            {
                MessageBox.Show("Can not checkout");
                return;
            }

            MessageBox.Show(result.Item2);
        }
    }
}
