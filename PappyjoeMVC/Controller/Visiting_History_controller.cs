using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Visiting_History_controller
    {
        Appointment_report_model _model = new Appointment_report_model();
        Common_model model = new Common_model();
        public DataTable doctor_rs()
        {
            DataTable d = _model.doctor_rs();
            return d;
        }
        public DataTable search(string d1, string d2)
        {
            DataTable dt = _model.search(d1, d2);
            return dt;
        }
        public string Get_DoctorId(string name)
        {
            string d = model.Get_DoctorId(name);
            return d;
        }
        public DataTable vishistCombo(string d1, string d2)
        {
            DataTable d = _model.vishistCombo(d1, d2);
            return d;
        }
        public DataTable vishistCombo1(string d1, string d2, string Selected_drid)
        {
            DataTable d = _model.vishistCombo1(d1, d2, Selected_drid);
            return d;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable d = model.Get_practiceDlNumber();
            return d;
        }
    }
}
