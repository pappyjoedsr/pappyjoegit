using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Paymode_Wise_Receipt_controller
    {
        Paymode_Wise_Receipt_interface intr;
        Common_model cmdl = new Common_model();
        Daily_Invoice_Report_model mdl = new Daily_Invoice_Report_model();
        public Paymode_Wise_Receipt_controller(Paymode_Wise_Receipt_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void getdocname()
        {
            DataTable dt = mdl.getdocname();
            intr.getdocname(dt);
        }
        public void getinvdata(string invno, string service)
        {
            DataTable dt = mdl.getinvdata(invno, service);
            intr.getinvdata(dt);
        }
        public void practicedetails()
        {
            DataTable dt = mdl.practicedetails();
            intr.practicedetails(dt);
        }
        public DataTable ReceiptReceivedModeofPayment(string d1, string d2)
        {
            DataTable dt = mdl.ReceiptReceivedModeofPayment(d1, d2);
            return dt;
        }
        public DataTable ReceiptReceivedModeofPayment_Both(string d1, string d2, string dr, string mode)
        {
            DataTable dt = mdl.ReceiptReceivedModeofPayment_Both(d1, d2, dr, mode);
            return dt;
        }
        public DataTable ReceiptReceivedModeofPayment_Mode(string d1, string d2, string mode)
        {
            DataTable dt = mdl.ReceiptReceivedModeofPayment_Mode(d1, d2, mode);
            return dt;
        }
        public DataTable ReceiptReceivedModeofPayment_Doctor(string d1, string d2, string dr)
        {
            DataTable dt = mdl.ReceiptReceivedModeofPayment_Doctor(d1, d2, dr);
            return dt;
        }
    }
}
