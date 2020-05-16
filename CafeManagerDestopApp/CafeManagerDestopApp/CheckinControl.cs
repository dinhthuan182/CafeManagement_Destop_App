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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.txtCheckname.Text == "Username" || this.txtCheckname.Text == "") {
                MessageBox.Show("Please enter your username to checkin/checkout.");
                return;
            }

            var checkTask =  apiNetwork.CheckinAsync(this.txtCheckname.Text);
            var result = checkTask.Result;
            
            if (result == null)
            {
                MessageBox.Show("Call api null");
                return;
            }

            if ( result.Item1 )
            {
                MessageBox.Show("Call api checkin success");
            } else
            {
                MessageBox.Show("Call api checkin faild");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
