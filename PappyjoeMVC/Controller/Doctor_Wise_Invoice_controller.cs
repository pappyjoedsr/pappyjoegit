using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Doctor_Wise_Invoice_controller
    {
       Doctor_Wise_Invoice_interface intr;
       common_model cmdl = new common_model();
       Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
       public Doctor_Wise_Invoice_controller(Doctor_Wise_Invoice_interface inttr)
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
            string dt = cmdl.Get_DoctorId(name);
           intr.Get_DoctorId(dt);
       }
       public void getdata3(string invdate, string invdate2, int dr_id)
       {
           DataTable dt = dm.getdata3(invdate, invdate2, dr_id);
           intr.getdata3(dt);
       }
       public void getdata4(string invdate, string invdate2)
       {
           DataTable dt = dm.getdata4(invdate, invdate2);
           intr.getdata4(dt);
       }
       public void practicedetails()
       {
           DataTable dt = dm.practicedetails();
           intr.practicedetails(dt);
       }
    }
}
