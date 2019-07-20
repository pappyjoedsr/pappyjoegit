using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Monthly_Invoice_Report_controller
    {
       Monthly_Invoice_Report_interface intr;
       common_model cmdl = new common_model();
       Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
       public Monthly_Invoice_Report_controller(Monthly_Invoice_Report_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
       public void getdocname()
       {
           DataTable dt = dm.getdocname();
           intr.getdocname(dt);
       }
       public void Get_DoctorId(string name)
       {
           DataTable dt = cmdl.Get_DoctorId(name);
           intr.Get_DoctorId(dt);
       }
        public void getdata(string invdate,string invdate2,int dr_id)
       {
           DataTable dt = dm.getdata(invdate,invdate2,dr_id);
           intr.getdata(dt);
       }
        public void getdata2(string invdate, string invdate2)
        {
            DataTable dt = dm.getdata2(invdate, invdate2);
            intr.getdata(dt);
        }
        public void practicedetails()
        {
            DataTable dt = dm.practicedetails();
            intr.practicedetails(dt);
        }
    }
}
