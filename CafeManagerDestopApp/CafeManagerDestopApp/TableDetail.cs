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
            lblSubTotal.Text = detail.current_sale_total.ToString();
            lblFinalTotal.Text = detail.current_sale_total.ToString();
        }

        public void Update(TableDetailItem newDetail, TableItem newTable)
        {
            detail = newDetail;
            table = newTable;

            for (int i = 0; i < newDetail.product_list.Count; i++)
            {
                orderItem p = newDetail.product_list[i];
                string[] row = new string[] { p.name, p.quantity.ToString(), p.price.ToString() };
                productGrid.Rows.Add(row);

                productGrid.Rows[i].ReadOnly = true;
            }


            lblName.Text = "Table: " + newTable.name;
            lblTotal.Text = newDetail.current_total.ToString();
            lblDiscount.Text = (newDetail.current_total - newDetail.current_sale_total).ToString();
            lblSubTotal.Text = newDetail.current_sale_total.ToString();
            lblFinalTotal.Text = newDetail.current_sale_total.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //CalApi unstate

            var result = apiNetwork.UnstateAsync(table.id);
                // resetdata
                SetupData();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            if (detail.receipt_id.HasValue)
            {
                var result = apiNetwork.GetBillAsync(detail.receipt_id.Value);
            }
            
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            if (detail.receipt_id.HasValue)
            {
                var result = apiNetwork.GetReceiptAsync(detail.receipt_id.Value);
            }
        }
    }
}
