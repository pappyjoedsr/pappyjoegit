using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class purchase_return_batch_controller
    {
        Inventory_model invmodel = new Inventory_model();
        purchase_return_model mdl = new purchase_return_model();
        public DataTable Get_unites(string Item_Id)
        {
            DataTable dtb = invmodel.Get_unites(Item_Id);
            return dtb;
        }
        public string get_unti2(int Pur_no1, string itemcode1)
        {
            string unit2 = mdl.get_unti2(Pur_no1,itemcode1);
            return unit2;
        }
        public DataTable get_batch_details(int Pur_no1, string itemcode1)
        {
            DataTable dtb = mdl.get_batch_details(Pur_no1, itemcode1);
            return dtb;
        }
    }
}
