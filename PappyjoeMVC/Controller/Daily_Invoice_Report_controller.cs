using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
   public class Daily_Invoice_Report_controller
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
       public DataTable getinvoice(string invdate)
       {
           DataTable dt = mdl.getinvoice(invdate);
           return dt;
       }
       public DataTable getinvoice2(string invdate, string doctrid)
       {
           DataTable dt = mdl.getinvoice2(invdate,doctrid);
           return dt;
       }
       public DataTable getpay(string invdate)
       {
           DataTable dt = mdl.getpay(invdate);
           return dt;
       }
       public DataTable getpay2(string invdate, string doctrid)
       {
           DataTable dt = mdl.getpay2(invdate, doctrid);
           return dt;
        }
       public string Get_DoctorId(string name)
       {
            string dt = cmdl.Get_DoctorId(name);
            return dt; ;
       }
    }
}

