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
    public partial class TableDetail : UserControl
    {
        private Network.Network apiNetwork = new Network.Network();

        TableDetailItem detail = new TableDetailItem();
        TableItem table = new TableItem();
        public TableDetail()
        {
            InitializeComponent();
            SetupData();
        }

        private void SetupData()
        {
            detail = new TableDetailItem();
            table = new TableItem();;

            productGrid.Rows.Clear();
            lblName.Text = "Table: " + table.name;
            lblTotal.Text = detail.current_total.ToString();
            lblDiscount.Text = (detail.current_total - detail.current_sale_total).ToString();
            lblFinalTotal.Text = detail.current_sale_total.ToString();
        }

        public async void Update(TableDetailItem newDetail, TableItem newTable)
        {
            if (table.id != 0)
            {
                var result = await apiNetwork.UnstateAsync(table.id);
                SetupData();
            }

            detail = newDetail;
            table = newTable;

            if (newDetail.product_list != null)
            {
                for (int i = 0; i < newDetail.product_list.Count; i++)
                {
                    orderItem p = newDetail.product_list[i];
                    string[] row = new string[] { (i + 1).ToString(), p.name, p.quantity.ToString(), p.price.ToString(), p.sale_price == p.price ? "" : p.sale_price.ToString(), p.sale_price != p.price ? (p.sale_price.Value * p.quantity).ToString() : (p.price * p.quantity).ToString() };
                    productGrid.Rows.Add(row);

                    productGrid.Rows[i].ReadOnly = true;
                }
            }

            lblName.Text = "Table: " + newTable.name;
            lblTotal.Text = newDetail.current_total.ToString();
            lblDiscount.Text = (newDetail.current_total - newDetail.current_sale_total).ToString();
            lblFinalTotal.Text = newDetail.current_sale_total.ToString();
        }

        private async void btnExit_Click(object sender, EventArgs e)
        {
            //Call Api unstate
            var result = await apiNetwork.UnstateAsync(table.id);
                // resetdata
                SetupData();
        }

        private async void btnBill_Click(object sender, EventArgs e)
        {
            if (detail.receipt_id.HasValue)
            {
                var result = await apiNetwork.GetBillAsync(detail.receipt_id.Value);
            }
        }

        private async void btnReceipt_Click(object sender, EventArgs e)
        {
            if (detail.receipt_id.HasValue)
            {
                var response = await apiNetwork.GetReceiptAsync(detail.receipt_id.Value);

                if (response.Item1 == true)
                {
                    SetupData();
                } else
                {
                    MessageBox.Show(response.Item2);
                }
            }
        }
    }
}
