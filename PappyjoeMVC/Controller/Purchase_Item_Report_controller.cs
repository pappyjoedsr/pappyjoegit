using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Purchase_Item_Report_controller
    {
        Purchase_Report_model mdl = new Purchase_Report_model();
        public DataTable purchitem(string purchno)
        {
            DataTable dt = mdl.purchitem(purchno);
            return dt;
        }
    }
}
