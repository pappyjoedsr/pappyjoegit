using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Daily_NewPatients_controller
    {
        Patients_Report_model _model = new Patients_Report_model();
        common_model mdl = new common_model();
        public DataTable doctor_rs()
        {
            DataTable rs = _model.doctor_rs();
            return rs;
        }
        public DataTable DailyNewPatient(string d1, string d2, string doctor)
        {
            DataTable d = _model.DailyNewPatient(d1, d2, doctor);
            return d;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable d = mdl.Get_practiceDlNumber();
            return d;
        }
        public DataTable Dailynewpatient(string d1, string d2, string doctor)
        {
            DataTable d = _model.Dailynewpatient(d1, d2, doctor);
            return d;
        }
        public DataTable griddailytrreatmenttable(string doctor, string date1, string date2)
        {
            DataTable d = _model.griddailytrreatmenttable(doctor, date1, date2);
            return d;
        }
        public DataTable griddailytrreatmenttable11(string date1, string date2)
        {
            DataTable d = _model.griddailytrreatmenttable11(date1, date2);
            return d;
        }
    }
}
