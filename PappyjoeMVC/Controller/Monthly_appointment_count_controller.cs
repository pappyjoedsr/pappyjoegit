using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Monthly_Appointment_count_controller
    {
        Appointment_report_model _model = new Appointment_report_model();
        Common_model model = new Common_model();
        public DataTable doctor_rs()
        {
            DataTable dt = _model.doctor_rs();
            return dt;
        }
        public DataTable Monthlyappointcount(string d1, string d2)
        {
            DataTable dt = _model.Monthlyappointcount(d1, d2);
            return dt;
        }
        public DataTable datatableeachdoctorappoinment(string d1, string d2)
        {
            DataTable dt = _model.datatableeachdoctorappoinment(d1, d2);
            return dt;
        }
        public DataTable datatableeachdoctorappoinment1(string d1, string d2, string select_dr_id)
        {
            DataTable d = _model.datatableeachdoctorappoinment1(d1, d2, select_dr_id);
            return d;
        }
        public DataTable Monthlyappointcount_DoctrWise(string d1, string d2, string drctr)
        {
            DataTable d = _model.Monthlyappointcount_DoctrWise(d1, d2, drctr);
            return d;
        }
        public string Docname_logDocAdmin(string drctid)
        {
            string dt = _model.Docname_logDocAdmin(drctid);
            return dt;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable dt = model.Get_practiceDlNumber();
            return dt;
        }
    }
}
