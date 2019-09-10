using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Purchase_Return_Report_controller
    {
        Purchase_Return_interface intr;
        Purchase_Report_model mdl = new Purchase_Report_model();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
        public Purchase_Return_Report_controller(Purchase_Return_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void purchreturn(string frmdte,string todte)
        {
            DataTable dt = mdl.purchreturn(frmdte,todte);
            intr.purchreturn(dt);
        }
        public void practicedetails()
        {
            DataTable dt = dm.practicedetails();
            intr.practicedetails(dt);
        }
    }
}
