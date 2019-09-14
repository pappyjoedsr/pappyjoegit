using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class SalesReport_Items_controller
    {
        Sales_Report_model mdl = new Sales_Report_model();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model(); 
        public DataTable salesrprtitms(string invno)
        {
            DataTable dt = mdl.salesrprtitms(invno);
            return dt;
        }
        public string slctbatchno(string invno,string itmcode)
        {
            string dt = mdl.slctbatchno(invno,itmcode);
            return dt;
        }
        public DataTable invdtls(string invno)
        {
            DataTable dt = mdl.invdtls(invno);
            return dt;
        }
        public DataTable practicedetails()
        {
            DataTable dt = dm.practicedetails();
            return dt;
        }
    }
}
