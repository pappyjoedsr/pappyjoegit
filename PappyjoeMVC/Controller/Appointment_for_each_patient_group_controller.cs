using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Appointment_for_each_patient_group_controller
    {
        Appointment_report_model _model = new Appointment_report_model();
        Common_model model = new Common_model();
        public DataTable gp_rs()
        {
            DataTable dt = _model.gp_rs();
            return dt;
        }
        public string grp_id(string gpid)
        {
            string tf = _model.grp_id(gpid);
            return tf;
        }
        public DataTable dtb_grid(string date1, string date2)
        {
            DataTable dt = _model.dtb_grid(date1, date2);
            return dt;
        }
        public DataTable Appointmenteachpatientgroup(string d30, string d31)
        {
            DataTable dt = _model.Appointmenteachpatientgroup(d30, d31);
            return dt;
        }
        public DataTable dtb_grid_gpid(string gpid, string date1, string date2)
        {
            DataTable d = _model.dtb_grid_gpid(gpid, date1, date2);
            return d;
        }
        public DataTable Appointmenteachpatientgroup_DrWise(string d30, string d31, string Drctr)//aswini
        {
            DataTable dt = _model.Appointmenteachpatientgroup_DrWise(d30, d31, Drctr);
            return dt;
        }
        public DataTable dt_group(string dtb_grid)
        {
            DataTable dt = _model.dt_group(dtb_grid);
            return dt;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable dt = model.Get_practiceDlNumber();
            return dt;
        }
    }
}
