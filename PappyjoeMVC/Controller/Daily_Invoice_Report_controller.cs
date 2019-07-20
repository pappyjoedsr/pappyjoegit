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
       Daily_Invoice_Report_interface intr;
       common_model cmdl = new common_model();
       Daily_Invoice_Report_model mdl=new Daily_Invoice_Report_model();
       public Daily_Invoice_Report_controller(Daily_Invoice_Report_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
       public void getdocname()
       {
           DataTable dt = mdl.getdocname();
           intr.getdocname(dt);
       }
       public void practicedetails()
       {
           DataTable dt = mdl.practicedetails();
           intr.practicedetails(dt);
       }
       public void getinvoice(string invdate)
       {
           DataTable dt = mdl.getinvoice(invdate);
           intr.getinvoice(dt);
       }
       public void getinvoice2(string invdate, string doctrid)
       {
           DataTable dt = mdl.getinvoice2(invdate,doctrid);
           intr.getinvoice2(dt);
       }
       public void getpay(string invdate)
       {
           DataTable dt = mdl.getpay(invdate);
           intr.getpay(dt);
       }
       public void getpay2(string invdate, string doctrid)
       {
           DataTable dt = mdl.getpay2(invdate, doctrid);
           intr.getpay2(dt);
       }
       public void Get_DoctorId(string name)
       {
           DataTable dt = cmdl.Get_DoctorId(name);
           intr.Get_DoctorId(dt);
       }
    }
}

