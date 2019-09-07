using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
    public class Sales_Retuen_Itemlist_Controller
    {
        Sales_Return_Model model = new Sales_Return_Model();
        public DataTable search_itemlist(string invNumber, string name)
        {
            DataTable dtb = model.search_itemlist(invNumber,name);
            return dtb;
        }
        public DataTable itemdetails_from_salesit(string InvNumber)
        {
            DataTable dtb = model.itemdetails_from_salesit(InvNumber);
            return dtb;
        }
    }
}
