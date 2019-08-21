using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Vital_Signs_controller
    {
        Vital_Signs_interface intr;
        Vital_Signs_model _model = new Vital_Signs_model();
        common_model cmodel = new common_model();
        public string doctor_id = "0";
        public string staff_id = "0";
        public string patient_id = "0";
        public Vital_Signs_controller(Vital_Signs_interface inttr)
        {
            intr = inttr;
            intr.setcontroller(this);
        }
        public DataTable vital(string patient_id)
        {
            DataTable dt = _model.vital(patient_id);
            return dt;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string dtb = cmodel.doctr_privillage_for_addnewPatient(doctor_id);
            return dtb;
        }
        public string permission_for_settings(string doctor_id)
        {
            string s = cmodel.permission_for_settings(doctor_id);
            return s;
        }
        public DataTable Get_CompanyNAme()
        {
            DataTable dt = cmodel.Get_CompanyNAme();
            return dt;
        }
        public DataTable Get_DoctorName(string doctor_id)
        {
            DataTable dt = cmodel.Get_DoctorName(doctor_id);
            return dt;
        }
        public DataTable Get_patient_id_name_gender(string patient_id)
        {
            DataTable dt = cmodel.Get_patient_id_name_gender(patient_id);
            return dt;
        }
        public DataTable Patient_search(string _Patientid)
        {
            DataTable dt = cmodel.Patient_search(_Patientid);
            return dt;
        }
    }
}
