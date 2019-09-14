using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class SalesReturnItemsReport_controller
    {
        Sales_Report_model mdl = new Sales_Report_model();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
        public DataTable salesrtrnitms(string retno)
        {
            DataTable dt = mdl.salesrtrnitms(retno);
            return dt;
        }
        public DataTable slctgst(string invno,string itmcode)
        {
            DataTable dt = mdl.slctgst(invno, itmcode);
            return dt;
        }
        public DataTable slctunits(string itmcode)
        {
            DataTable dt = mdl.slctunits(itmcode);
            return dt;
        }
        public DataTable retrndtls(string retno)
        {
            DataTable dt = mdl.retrndtls(retno);
            return dt;                               
        }
        public DataTable practicedetails()
        {
            DataTable dt = dm.practicedetails();
            return dt;
        }
    }
}
