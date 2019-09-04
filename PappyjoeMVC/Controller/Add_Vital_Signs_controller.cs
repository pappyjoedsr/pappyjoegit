using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Add_Vital_Signs_controller
    {
        Add_Vital_Signs_model _model = new Add_Vital_Signs_model();
        Common_model model = new Common_model();
        public string doctor_id = "0";
        public string staff_id = "0";
        public string patient_id = "0";
        public DataTable Get_CompanyNAme()
        {
            DataTable dt = model.Get_CompanyNAme();
            return dt;
        }
        public string Get_DoctorName(string doctor_id)
        {
            string d = model.Get_DoctorName(doctor_id);
            return d;
        }
        public DataTable Get_patient_id_name_gender(string patient_id)
        {
            DataTable d = model.Get_patient_id_name_gender(patient_id);
            return d;
        }
        public DataTable get_all_doctorname()
        {
            DataTable d = model.get_all_doctorname();
            return d;
        }
        public string Load_CompanyName()
        {
            string dtb = model.Load_CompanyName();
            return dtb;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string d = model.doctr_privillage_for_addnewPatient(doctor_id);
            return d;
        }
        public string permission_for_settings(string doctor_id)
        {
            string d = model.permission_for_settings(doctor_id);
            return d;
        }
        public DataTable Patient_search(string _Patientid)
        {
            DataTable d = model.Patient_search(_Patientid);
            return d;
        }
        public int submit(string patient_id, string dr_id, string doctor, string temp_type, string bp_type, string pulse, string txttemp, string text_Bp_Syst, string text_Bp_Dias, string text_Weight, string text_Resp, string dtp_date, string Txtheight)
        {
            int i = _model.submit(patient_id, dr_id, doctor, temp_type, bp_type, pulse, txttemp, text_Bp_Syst, text_Bp_Dias, text_Weight, text_Resp, dtp_date, Txtheight);
            return i;
        }
    }
}
