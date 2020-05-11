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
    public partial class TableCardCell : UserControl
    {
        public Network.Network apiNetwork = new Network.Network();
        private int id = -1;

        public TableCardCell()
        {
            InitializeComponent();
        }

        public void setTable(int id, string name, int state)
        {
            this.id = id;
            lbl_table_name.Text = name;
            switch (state)
            {
                case 1:
                    // have user
                    img_state.Image = Image.FromFile("C://Users/PC/Desktop/TDTU_DA2/DesktopApp/icons/table_ordering.png");
                    break;
                case 2:
                    // using
                    img_state.Image = Image.FromFile("C://Users/PC/Desktop/TDTU_DA2/DesktopApp/icons/table_active.png");
                    break;
                default:
                    // empty
                    img_state.Image = Image.FromFile("C://Users/PC/Desktop/TDTU_DA2/DesktopApp/icons/table_unactive.png");
                    break;
            }
        }

        private async void getdetail()
        {
            var detail = await apiNetwork.getTableDetail(id);
            MessageBox.Show("selected: " + detail.receipt_id);
        }
    }
}
