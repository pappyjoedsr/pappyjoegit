using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Patients_first_appointment_controller
    {
        Patients_Report_model _model = new Patients_Report_model();
        common_model mdl = new common_model();
        public Patients_first_appointment_controller(Patients_first_appointment_interface intr)
        {
            intr.setcontroller(this);
        }
        public DataTable doctor_rs()
        {
            DataTable d = _model.doctor_rs();
            return d;
        }
        public DataTable FirstAppointment(string dr_id,string d9, string d10)
        {
            DataTable d = _model.FirstAppointment(dr_id,d9, d10);
            return d;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable d = mdl.Get_practiceDlNumber();
            return d;
        }
    }
}
