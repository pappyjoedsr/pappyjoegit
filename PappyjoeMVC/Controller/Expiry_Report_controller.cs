using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Expiry_Report_controller
    {
        Reports_model mdl=new Reports_model();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
        public DataTable datewiseexpiry(string dateFrom,string dateTo)
        {
            DataTable dt =mdl.datewiseexpiry(dateFrom, dateTo) ;
            return dt;
        }
        public DataTable practicedetails()
        {
            DataTable dt = dm.practicedetails();
            return dt;
        }
    }
}
