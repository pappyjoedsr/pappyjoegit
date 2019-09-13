using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Sales_Return_Report_controller
    {
        Sales_Return_Report_interface intr;
        Sales_Report_model mdl = new Sales_Report_model();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
        public Sales_Return_Report_controller(Sales_Return_Report_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void salesreturn(string dateFrom, string dateTo)
        {
            DataTable dt = mdl.salesreturn(dateFrom,dateTo);
            intr.salesreturn(dt);
        }
        public void practicedetails()
        {
            DataTable dt = dm.practicedetails();
            intr.practicedetails(dt);
        }
    }
}
