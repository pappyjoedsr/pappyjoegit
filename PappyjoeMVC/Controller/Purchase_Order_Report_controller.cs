using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Purchase_Order_Report_controller
    {
        Purchase_Report_model mdl = new Purchase_Report_model();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
        public DataTable practicedetails()
        {
            DataTable dt = dm.practicedetails();
            return dt;
        }
        public DataTable purchorder(string frmdte, string todte)
        {
            DataTable dt = mdl.purchorder(frmdte, todte);
            return dt;
        }
    }
}
