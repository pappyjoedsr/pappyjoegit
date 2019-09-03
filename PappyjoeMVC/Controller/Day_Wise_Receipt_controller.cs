using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Day_Wise_Receipt_controller
    {
       common_model cmdl = new common_model();
       Daily_Invoice_Report_model mdl=new Daily_Invoice_Report_model();
       public DataTable getdocname()
       {
           DataTable dt = mdl.getdocname();
           return dt;
       }
       public DataTable practicedetails()
       {
           DataTable dt = mdl.practicedetails();
           return dt;
       }
       public DataTable getinvdata(string invno,string service)
       {
           DataTable dt = mdl.getinvdata(invno,service);
           return dt;
       }
       public DataTable ReceiptReceivedPerDay(string d1, string d2)
       {
           DataTable dt = mdl.ReceiptReceivedPerDay(d1, d2);
           return dt;
       }
       public DataTable ReceiptReceivedPerDay_DoctrWise(string d1, string d2, string dr)
       {
           DataTable dt = mdl.ReceiptReceivedPerDay_DoctrWise(d1, d2,dr);
           return dt;
       }
    }
}
