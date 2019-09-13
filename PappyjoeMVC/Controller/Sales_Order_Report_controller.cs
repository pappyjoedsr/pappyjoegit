using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Sales_Order_Report_controller
    {
        Sales_Order_Report_interface intr;
        Sales_Report_model mdl = new Sales_Report_model();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
        public Sales_Order_Report_controller(Sales_Order_Report_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void salesorder(string dateFrom, string dateTo)
        {
            DataTable dt = mdl.salesorder(dateFrom, dateTo);
            intr.salesorder(dt);
        }
        public void practicedetails()
        {
            DataTable dt = dm.practicedetails();
            intr.practicedetails(dt);
        }
    }
}
