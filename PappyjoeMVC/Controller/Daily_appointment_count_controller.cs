using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Daily_Appointment_Count_controller
    {
        Appointment_report_model _model = new Appointment_report_model();
        Common_model model = new Common_model();
        public DataTable doctor_rs()
        {
            DataTable d = _model.doctor_rs();
            return d;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable dt = model.Get_practiceDlNumber();
            return dt;
        }
        public DataTable gridviewtabledailyappoiment(string date1, string date2, string select_dr_id)
        {
            DataTable dt = _model.gridviewtabledailyappoiment(date1, date2, select_dr_id);
            return dt;
        }
        public DataTable Dailyappointcount_dOCTORwISE(string d5, string d6, string drctr)
        {
            DataTable dt = _model.Dailyappointcount_dOCTORwISE(d5, d6, drctr);
            return dt;
        }
        public DataTable gridviewtabledailyappoiment1(string date1, string date2)
        {
            DataTable dt = _model.gridviewtabledailyappoiment(date1, date2);
            return dt;
        }
        public DataTable Dailyappointcount(string d5, string d6)
        {
            DataTable dt = _model.Dailyappointcount(d5, d6);
            return dt;
        }
        public string Get_DoctorId(string name)
        {
            string dt = model.Get_DoctorId(name);
            return dt;
        }
    }
}
