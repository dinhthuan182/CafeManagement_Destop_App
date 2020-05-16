using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafeManagerDestopApp.Entitys;

namespace CafeManagerDestopApp
{
    public partial class TableCardCell : UserControl
    {
        public Network.Network apiNetwork = new Network.Network();
        private TableItem table = new TableItem();
        public TableCardCell()
        {
            InitializeComponent();
        }

        public void setTable(TableItem initTable)
        {
            this.table = initTable;
            lbl_table_name.Text = initTable.name;

            if (initTable.user_id != null)
            {
                // have user
                img_state.Image = Image.FromFile("C://Users/PC/Desktop/TDTU_DA2/DesktopApp/icons/table_ordering.png");
            }
            else
            {
                if (initTable.status == "Using")
                {
                    // using
                    img_state.Image = Image.FromFile("C://Users/PC/Desktop/TDTU_DA2/DesktopApp/icons/table_active.png");
                }
                else
                {
                    // empty
                    img_state.Image = Image.FromFile("C://Users/PC/Desktop/TDTU_DA2/DesktopApp/icons/table_unactive.png");
                }
            }
        }

        private async void getdetail()
        {
            var detail = await apiNetwork.getTableDetail(this.table.id);
            ((TableManager)this.Parent.Parent).ShowDetail(detail, this.table);
        }

        private void img_state_Click(object sender, EventArgs e)
        {
            getdetail();
        }

        private void lbl_table_name_Click(object sender, EventArgs e)
        {
            getdetail();
        }
    }
}
