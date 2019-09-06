using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Daily_Treatment_Count_controller
    {
        Treatment_Report_model _model = new Treatment_Report_model();
        Common_model cmn = new Common_model();
        public DataTable doctor_rs()
        {
            DataTable d = _model.doctor_rs();
            return d;
        }
        public DataTable grdDailytrtmnt(string date1, string date2)
        {
            DataTable d = _model.grdDailytrtmnt(date1, date2);
            return d;
        }
        public DataTable DailytreatmentLoad(string d1, string d2)
        {
            DataTable d = _model.DailytreatmentLoad(d1, d2);
            return d;
        }
        public DataTable grddlytrtment(string d1, string d2, string drid)
        {
            DataTable d = _model.grddlytrtment(d1, d2, drid);
            return d;
        }
        public DataTable Dailytreatment(string d1, string d2, string drid)
        {
            DataTable d = _model.Dailytreatment(d1, d2, drid);
            return d;
        }
        public DataTable gridtreatment1(string d1, string d2)
        {
            DataTable d = _model.gridtreatment1(d1, d2);
            return d;
        }
        public DataTable Gridtrtment2(string d1, string d2, string drid)
        {
            DataTable d = _model.Gridtrtment2(d1, d2, drid);
            return d;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable d = cmn.Get_practiceDlNumber();
            return d;
        }
        public string Get_DoctorId(string name)
        {
            string d = cmn.Get_DoctorId(name);
            return d;
        }
    }
}
