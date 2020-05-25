using System;
using System.Drawing;
using System.Windows.Forms;
using CafeManagerDestopApp.Entitys;

namespace CafeManagerDestopApp
{
    public partial class TableCardCell : UserControl
    {
        private readonly Network.Network apiNetwork = new Network.Network();
        private TableItem table = new TableItem();

        public TableCardCell()
        {
            InitializeComponent();
        }

        public void SetTable(TableItem initTable)
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

        private async void Getdetail()
        {
            if (table.user_id == null)
            {
                var detail = await apiNetwork.getTableDetail(table.id);
                if (detail == null)
                {
                    MessageBox.Show("Not checkin yet, Please checkin.");
                    return;
                }

                ((TableManager)this.Parent.Parent).ShowDetail(detail, this.table);
            } else
            {
                MessageBox.Show("The table is being accessed by other users.");
            }            
        }

        private void img_state_Click(object sender, EventArgs e)
        {
            Getdetail();
        }

        private void lbl_table_name_Click(object sender, EventArgs e)
        {
            Getdetail();
        }
    }
}
