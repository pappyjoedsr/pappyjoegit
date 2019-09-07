using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Sales_Return_Batch_Controller
    {
        Inventory_model model = new Inventory_model();
        public DataTable Get_unites(string Item_Id)
        {
            DataTable dtb = model.Get_unites(Item_Id);
            return dtb;
        }
        public DataTable dtb_load(string InvNum, string ItemCode)
        {
            DataTable dtb = model.dtb_load(InvNum, ItemCode);
            return dtb;
        }
        public DataTable get_item_unitmf(string Itemid)
        {
            DataTable dtb = model.get_item_unitmf(Itemid);
            return dtb;
        }

    }
}
