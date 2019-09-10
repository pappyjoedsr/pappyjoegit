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
        Purchase_Order_Report_interface intr;
        Purchase_Report_model mdl = new Purchase_Report_model();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
        public Purchase_Order_Report_controller(Purchase_Order_Report_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void practicedetails()
        {
            DataTable dt = dm.practicedetails();
            intr.practicedetails(dt);
        }
        public void purchorder(string frmdte, string todte)
        {
            DataTable dt = mdl.purchorder(frmdte, todte);
            intr.purchorder(dt);
        }
    }
}
