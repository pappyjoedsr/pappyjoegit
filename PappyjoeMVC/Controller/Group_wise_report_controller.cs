using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Group_Wise_Report_controller
    {
        Patients_Report_model _model = new Patients_Report_model();
        Common_model mdl = new Common_model();
        public DataTable dt_grp()
        {
            DataTable dt = _model.dt_grp();
            return dt;
        }
        public DataTable dtb_group(string cmb, string d1, string d2)
        {
            DataTable d = _model.dtb_group(cmb, d1, d2);
            return d;
        }
        public DataTable dtb_procedure(string cmb, string d1, string d2)
        {
            DataTable d = _model.dtb_procedure(cmb, d1, d2);
            return d;
        }
        public DataTable dtb_invoice(string d1, string d2, string cmb)
        {
            DataTable d = _model.dtb_invoice(d1, d2, cmb);
            return d;
        }
        public DataTable dtb_receipt(string d1, string d2, string cmb)
        {
            DataTable d = _model.dtb_receipt(d1, d2, cmb);
            return d;
        }
        public DataTable dt_inv(string dtp1, string dtp2)
        {
            DataTable d = _model.dt_inv(dtp1, dtp2);
            return d;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable d = mdl.Get_practiceDlNumber();
            return d;
        }
    }
}
