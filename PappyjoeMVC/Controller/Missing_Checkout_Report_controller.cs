using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Missing_Checkout_Report_controller
    {
        Appointment_report_model _model = new Appointment_report_model();
        Common_model model = new Common_model();
        public DataTable doctor_rs()
        {
            DataTable d = _model.doctor_rs();
            return d;
        }
        public DataTable btn_shwClick(string d1, string d2, string cmbCon)
        {
            DataTable d = _model.btn_shwClick(d1, d2, cmbCon);
            return d;
        }
        public DataTable showMissing(string d1, string d2)
        {
            DataTable d = _model.showMissing(d1, d2);
            return d;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable dt = model.Get_practiceDlNumber();
            return dt;
        }
        public string Get_DoctorId(string name)
        {
            string d = model.Get_DoctorId(name);
            return d;
        }
        public DataTable DocComb(string d1, string d2)
        {
            DataTable d = _model.DocComb(d1, d2);
            return d;
        }
        public DataTable DocComb1(string d1, string d2, string Selected_drid)
        {
            DataTable d = _model.DocComb1(d1, d2, Selected_drid);
            return d;
        }
        public DataTable DocComb2(string d1, string d2)
        {
            DataTable d = _model.DocComb2(d1, d2);
            return d;
        }
        public DataTable DocComb3(string d1, string d2, string Selected_drid)
        {
            DataTable d = _model.DocComb3(d1, d1, Selected_drid);
            return d;
        }
    }
}
