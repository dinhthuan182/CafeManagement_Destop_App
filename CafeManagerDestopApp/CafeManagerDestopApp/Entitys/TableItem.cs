using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagerDestopApp.Entitys
{

    public class TableItem
    {
        public int id;
        public string name;
        public string note;
        public string status;
        public int? user_id = null;
        public string created_at;
        public string updated_at;
    }

    public class TableDetailItem
    {
        public int? receipt_id = null;
        public int? current_total = null;
        public int? current_sale_total = null;
        public int? receipt_status = null;
        public string billing_at;
        public string receipt_at;
        public string export_at;
        public string created_at;
        public string created_by_name;
        public int? current_user_using = null;
        public List<orderItem> product_list = null;
        public string paid;
    }

    public class orderItem
    {
        public int id;
        public string name;
        public int price;
        public int? sale_price = null;
        public int? promotion_id = null;
        public int quantity;
        public string note;
        public string type;
        public string url;
    }
}
