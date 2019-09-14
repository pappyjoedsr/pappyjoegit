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
        Sales_Report_model mdl = new Sales_Report_model();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
        public DataTable salesorder(string dateFrom, string dateTo)
        {
            DataTable dt = mdl.salesorder(dateFrom, dateTo);
            return dt;
        }
        public DataTable practicedetails()
        {
            DataTable dt = dm.practicedetails();
            return dt;
        }
    }
}
