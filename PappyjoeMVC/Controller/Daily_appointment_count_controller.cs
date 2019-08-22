using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
    public class Daily_appointment_count_controller
    {
        Daily_appointment_count_interface intr;
        Appointment_report_model _model = new Appointment_report_model();
        common_model model = new common_model();
        public Daily_appointment_count_controller(Daily_appointment_count_interface inttr)
        {
            intr = inttr;
            intr.setcontroller(this);
        }
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
        public DataTable gridviewtabledailyappoiment(string date1,string date2,string select_dr_id)
        {
            DataTable dt = _model.gridviewtabledailyappoiment(date1,date2, select_dr_id);
            return dt;
        }
        public DataTable Dailyappointcount_dOCTORwISE(string d5, string d6, string drctr)
        {
            DataTable dt = _model.Dailyappointcount_dOCTORwISE(d5,d6,drctr);
            return dt;
        }
        public DataTable gridviewtabledailyappoiment1(string date1, string date2)
        {
            DataTable dt = _model.gridviewtabledailyappoiment(date1,date2);
            return dt;
        }
        public DataTable Dailyappointcount(string d5, string d6)
        {
            DataTable dt = _model.Dailyappointcount(d5,d6);
            return dt;
        }
        public string Get_DoctorId(string name)
        {
            string dt = model.Get_DoctorId(name);
            return dt;
        }
    }
}
