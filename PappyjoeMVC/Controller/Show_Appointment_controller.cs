using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Show_Appointment_controller
    {
        Show_Appointment_model mdl = new Show_Appointment_model();
        Common_model cmdl = new Common_model();
        Add_Appointment_model am = new Add_Appointment_model();
        public string privilege_A(string doctor_id)
        {
            string e= mdl.privilege_A(doctor_id);
            return e;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string e = cmdl.doctr_privillage_for_addnewPatient(doctor_id);
            return e;
        }
        public string settingsprivilage(string doctrid)
        {
            string b = mdl.settingsprivilage(doctrid);
            return b;
        }
        public DataTable Get_Patient_Details(string patientid)
        {
            DataTable dt = cmdl.Get_Patient_Details(patientid);
            return dt;
        }
        public string privilege_D(string doctor_id)
        {
            string e = mdl.privilege_D(doctor_id);
            return e;
        }
        public string privilege_E(string doctor_id)
        {
            string e = mdl.privilege_E(doctor_id);
            return e;
        }
        public DataTable Get_CompanyNAme()
        {
            DataTable dt = cmdl.Get_CompanyNAme();
            return dt;
        }
        public string Get_DoctorName(string id)
        {
            string dt = cmdl.Get_DoctorName(id);
            return dt;
        }
        public DataTable show(string patid)
        {
            DataTable dt = mdl.show(patid);
            return dt;
        }
        public DataTable Patient_search(string txtbox)
        {
            DataTable dt = cmdl.Patient_search(txtbox);
            return dt;
        }
        public int delete(string apntid)
        {
            int j = mdl.delete(apntid);
            return j;
        }
    }
}
