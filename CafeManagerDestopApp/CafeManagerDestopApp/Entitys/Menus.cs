using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagerDestopApp.Entitys
{
    class Menus
    {
        public List<MenuItem> product_list;
    }

    class MenuItem
    {
        public int id;
        public string name;
        public int price;
        public int sale_price;
        public int promotion_id;
        public string type;
        public string url;
    }
}
