using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class DoctorWise_appointment_report_controller
    {
        Appointment_report_model _model = new Appointment_report_model();
        Common_model model = new Common_model();
        public DataTable get_all_doctorname()
        {
            DataTable dt = model.get_all_doctorname();
            return dt;
        }
        public string Get_DoctorId(string name)
        {
            string dt = model.Get_DoctorId(name);
            return dt;
        }
        public DataTable dt_docApt(string date1, string date2)
        {
            DataTable dt = _model.dt_docApt(date1, date2);
            return dt;
        }
        public DataTable Appointcountforeachdoctor(string d1, string d2)
        {
            DataTable dt = _model.Appointcountforeachdoctor(d1, d2);
            return dt;
        }
        public DataTable dt_docApt1(string date1, string date2, string select_dr_id)
        {
            DataTable dt = _model.dt_docApt1(date1, date2, select_dr_id);
            return dt;
        }
        public DataTable Appointcountforeachdoctor_DoctrWise(string d1, string d2, string drctr)
        {
            DataTable dt = _model.Appointcountforeachdoctor_DoctrWise(d1, d2, drctr);
            return dt;
        }
        public string get_docId(string drid)
        {
            string dt = _model.get_docId(drid);
            return dt;
        }
        public string doc_name_login(string drid)
        {
            string dt = _model.doc_name_login(drid);
            return dt;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable d = model.Get_practiceDlNumber();
            return d;
        }
    }
}
