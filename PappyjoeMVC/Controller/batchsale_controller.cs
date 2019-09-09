using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
   public class batchsale_controller
    {
        Connection db = new Connection();
        Inventory_model inv_model = new Inventory_model();
        public DataTable get_batchdetails(string ItemCode)
        {
            DataTable dtb = inv_model.get_batchdetails(ItemCode);
            return dtb;
        }
        public DataTable get_item_unitmf(string Itemid)
        {
            DataTable dtb = inv_model.get_item_unitmf(Itemid);
            return dtb;
        }
    }
    
}
