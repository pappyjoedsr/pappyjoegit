using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public class Purchase_Return_ItemList_controller
    {
        purchase_return_model mdl = new purchase_return_model();
        public DataTable Load_Items(int pur_no1)
        {
            DataTable dtb = mdl.Load_Items(pur_no1);
            return dtb;
        }
        public DataTable search_items(int pur_no1, string search)
        {
            DataTable dtb = mdl.search_items(pur_no1, search);
            return dtb;
        }
    }
}
