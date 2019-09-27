using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Doctor_Wise_Receipt_controller
    {
        Common_model cmdl = new Common_model();
        Daily_Invoice_Report_model mdl = new Daily_Invoice_Report_model();
        public DataTable getdocname()
        {
            DataTable dt = mdl.getdocname();
            return dt;
        }
        public string getdocid(string drname)
        {
            string e = mdl.getdocid(drname);
            return e;
        }                                                 
        public DataTable getinvdata(string invno, string service)
        {
            DataTable dt = mdl.getinvdata(invno, service);
            return dt;
        }                                                                     
        public DataTable mnthrcpt(string rcdte, string rcdte2)
        {
            DataTable dt = mdl.mnthrcpt(rcdte, rcdte2);
            return dt;
        }
        public DataTable mnthrcpt2(string rcdte, string rcdte2, string dr_id)
        {
            DataTable dt = mdl.mnthrcpt2(rcdte, rcdte2, dr_id);
            return dt;
        }
        public DataTable practicedetails()
        {
            DataTable dt = mdl.practicedetails();
            return dt;
        }
    }
}
