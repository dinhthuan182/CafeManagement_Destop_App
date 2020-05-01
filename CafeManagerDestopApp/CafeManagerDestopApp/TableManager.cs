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
    public partial class TableManager : UserControl
    {
        public Network.Network apiNetwork = new Network.Network();
        public TableManager()
        {
            InitializeComponent();
            loadData();
        }
        private async void loadData()
        {
            var tables = apiNetwork.GetAllTable();
          
        }
    }
}
