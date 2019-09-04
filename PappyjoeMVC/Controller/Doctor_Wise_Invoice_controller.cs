using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Doctor_Wise_Invoice_controller
    {
        Common_model cmdl = new Common_model();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
        public DataTable getdocname()
        {
            DataTable dt = dm.getdocname();
            return dt;
        }
        public string Get_DoctorId(string name)
        {
            string dt = cmdl.Get_DoctorId(name);
            return dt;
        }
        public DataTable getdata3(string invdate, string invdate2, int dr_id)
        {
            DataTable dt = dm.getdata3(invdate, invdate2, dr_id);
            return dt;
        }
        public DataTable getdata4(string invdate, string invdate2)
        {
            DataTable dt = dm.getdata4(invdate, invdate2);
            return dt;
        }
        public DataTable practicedetails()
        {
            DataTable dt = dm.practicedetails();
            return dt;
        }
    }
}
