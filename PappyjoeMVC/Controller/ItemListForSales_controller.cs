using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
    public class ItemListForSales_controller
    {
        //ItemListForSales_interface intr;
        Connection db = new Connection();
        Inventory_model inv_model = new Inventory_model();
        //public ItemListForSales_controller(ItemListForSales_interface inttr)
        //{
        //    intr = inttr;
        //    intr.setcontroller(this);
        //}
        public DataTable Load_items_wit_itemcode(string Item_Code)
        {
            DataTable dt = inv_model.Load_items_wit_itemcode(Item_Code);
            return dt;// intr.fill_Grid(dt);
        }
        public string get_itemid(string Item_Code)
        {
            string str = inv_model.get_itemid(Item_Code);
            return str;
        }
        public DataTable Load_items()
        {
            DataTable dt = inv_model.Load_items();
            return dt;// intr.fill_Grid(dt);
        }
        public DataTable search_wit_itemcode(string name)
        {
            DataTable dtb = inv_model.search_wit_itemcode(name);
            return dtb;// intr.fill_Grid(dtb);
        }
        public string check_batch(string item_code)
        {
            string dt = inv_model.check_batch(item_code);
            return dt;
        }
    }
}
