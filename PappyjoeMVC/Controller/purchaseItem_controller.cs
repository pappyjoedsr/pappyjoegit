using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public class purchaseItem_controller
    {
        Inventory_model imodel = new Inventory_model();
        public DataTable LoadItems()
        {
            DataTable dt = imodel.LoadItems();
            return dt;
        }
        public DataTable Load_itemcode_details(string item_)
        {
            DataTable dt = imodel.Load_itemcode_details(item_);
            return dt;
        }

        public DataTable Search(string item)
        {
            DataTable dtb = imodel.Search(item);
            return dtb;
        }
        public string get_itemid(string Item_Code)
        {
            string id = imodel.get_itemid(Item_Code);
            return id;
        }
    }
}
