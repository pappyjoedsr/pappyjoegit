using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Monthly_New_Patients_controller
    {
        Patients_Report_model _model = new Patients_Report_model();
        Common_model mdl = new Common_model();
        public DataTable doctor_rs()
        {
            DataTable d = _model.doctor_rs();
            return d;
        }
        public DataTable MonthlyNewPatient(string d11, string d22, string doctor_id)
        {
            DataTable d = _model.MonthlyNewPatient(d11, d22, doctor_id);
            return d;
        }
        public DataTable grdDailytrtmentTable(string doctor, string date1, string date2)
        {
            DataTable d = _model.grdDailytrtmentTable(doctor, date1, date2);
            return d;
        }
        public DataTable grdDailyTtrtmn1TB(string date1, string date2)
        {
            DataTable d = _model.grdDailyTtrtmn1TB(date1, date2);
            return d;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable m = mdl.Get_practiceDlNumber();
            return m;
        }
        public DataTable DailyNewPatient(string d1, string d2, string doctor)
        {
            DataTable c = _model.DailyNewPatient(d1, d2, doctor);
            return c;
        }
    }
}
