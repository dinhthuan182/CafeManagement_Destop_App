using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagerDestopApp.Entitys
{
    class Table
    {
        public int id;
        public string name;
        public string note;
        public string status;
        public int user_id;
        public string created_at;
        public string updated_at;
    }

    class TableDetail
    {
        public int receipt_id;
        public int current_total;
        public int current_sale_total;
        public int receipt_status;
        public string billing_at;
        public string receipt_at;
        public string export_at;
        public string created_at;
        public string created_by_name;
        public int current_user_using;
        public List<orderItem> product_list;
    }

    class orderItem
    {
        public int id;
        public string name;
        public int price;
        public int sale_price;
        public int promotion_id;
        public int quantity;
        public string note;
        public string type;
        public string url;
    }
}
