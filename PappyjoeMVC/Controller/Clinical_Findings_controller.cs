using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Clinical_Findings_controller
    {
        Clinical_Findings_model _model = new Clinical_Findings_model();
        Common_model model = new Common_model();
        Clinical_Notes_Add_model cmodel = new Clinical_Notes_Add_model();
        public string privilge_for_inventory(string doctor_id)
        {
            string s = model.privilge_for_inventory(doctor_id);
            return s;
        }
        public string user_priv_EMRCF_A(string doctor_id)
        {
            string s = _model.user_priv_EMRCF_A(doctor_id);
            return s;
        }
        public string user_priv_EMRC_E(string doctor_id)
        {
            string s = _model.user_priv_EMRC_E(doctor_id);
            return s;
        }
        public string usr_priv_EMRCF_D(string doctor_id)
        {
            string s = _model.usr_priv_EMRCF_D(doctor_id);
            return s;
        }
        public DataTable Get_CompanyNAme()
        {
            DataTable dt = model.Get_CompanyNAme();
            return dt;
        }
        public string Get_DoctorName(string doctor_id)
        {
            string dt = model.Get_DoctorName(doctor_id);
            return dt;
        }
        public DataTable Get_Patient_Details(string id)
        {
            DataTable dt = model.Get_Patient_Details(id);
            return dt;
        }
        public DataTable dt_cf_main(string patient_id)
        {
            DataTable dt = _model.dt_cf_main(patient_id);
            return dt;
        }
        public DataTable dt_cf_Complaints(string dt_cf_main)
        {
            DataTable dt = _model.dt_cf_Complaints(dt_cf_main);
            return dt;
        }
        public DataTable dt_cf_observe(string dt_cf_main)
        {
            DataTable dt = _model.dt_cf_observe(dt_cf_main);
            return dt;
        }
        public DataTable dt_cf_investigation(string dt_cf_main)
        {
            DataTable dt = _model.dt_cf_investigation(dt_cf_main);
            return dt;
        }
        public DataTable dt_cf_diagnosis(string dt_cf_main)
        {
            DataTable dt = _model.dt_cf_diagnosis(dt_cf_main);
            return dt;
        }
        public DataTable dt_cf_note(string dt_cf_main)
        {
            DataTable dt = _model.dt_cf_note(dt_cf_main);
            return dt;
        }
        public DataTable get_company_details()
        {
            DataTable dt = model.get_company_details();
            return dt;
        }
        public DataTable dt_medical(string patient_id)
        {
            DataTable dt = _model.dt_medical(patient_id);
            return dt;
        }
        public DataTable dt_cf(string clinic_id, string patient_id)
        {
            DataTable dt = _model.dt_cf(clinic_id, patient_id);
            return dt;
        }
        public DataTable dt_cf_Complaints_clinic_id(string clinic_id)
        {
            DataTable dt = _model.dt_cf_Complaints_clinic_id(clinic_id);
            return dt;
        }
        public DataTable dt_cf_observe_clinicid(string clinic_id)
        {
            DataTable dt = _model.dt_cf_observe_clinicid(clinic_id);
            return dt;
        }
        public DataTable dt_cf_investigation_clinicid(string clinic_id)
        {
            DataTable dt = _model.dt_cf_investigation_clinicid(clinic_id);
            return dt;
        }
        public DataTable dt_cf_diagnosis_clinicid(string clinic_id)
        {
            DataTable dt = _model.dt_cf_diagnosis_clinicid(clinic_id);
            return dt;
        }
        public DataTable dt_cf_note_clincid(string clinic_id)
        {
            DataTable dt = _model.dt_cf_note_clincid(clinic_id);
            return dt;
        }
        public DataTable Patient_search(string _Patientid)
        {
            DataTable dt = model.Patient_search(_Patientid);
            return dt;
        }
        public int del_clinic_findings(string clinic_id)
        {
            int i = _model.del_clinic_findings(clinic_id);
            return i;
        }
        public int del_cheif_comp(string clinic_id)
        {
            int i = _model.del_cheif_comp(clinic_id);
            return i;
        }
        public int del_observ(string clinic_id)
        {
            int i = _model.del_observ(clinic_id);
            return i;
        }
        public int del_invest(string clinic_id)
        {
            int i = _model.del_invest(clinic_id);
            return i;
        }
        public int del_diagno(string clinic_id)
        {
            int i = _model.del_diagno(clinic_id);
            return i;
        }
        public int del_note(string clinic_id)
        {
            int i = _model.del_note(clinic_id);
            return i;
        }
        public DataTable patient_information(string patient_id)
        {
            DataTable dt = _model.patient_information(patient_id);
            return dt;
        }
        public DataTable Get_Practice_details()
        {
            DataTable dt = model.Get_Practice_details();
            return dt;
        }
        public DataTable dt_cf_id_date(string clinic_id)
        {
            DataTable dt = _model.dt_cf_id_date(clinic_id);
            return dt;
        }
        public DataTable getpatemail(string patient_id)
        {
            DataTable dt = model.getpatemail(patient_id);
            return dt;
        }
        public DataTable send_email()
        {
            DataTable dt = model.send_email();
            return dt;
        }
        public DataTable dt_cf(string clinic_id)
        {
            DataTable dt = _model.dt_cf(clinic_id);
            return dt;
        }
        public void insertInto_clinical_findings(string ptid, string dt, string date)
        {
            cmodel.insertInto_clinical_findings(ptid, dt, date);
        }
        public string MaxId_clinic_findings()
        {
            string dt = cmodel.MaxId_clinic_findings();
            return dt;
        }
        public void insrtto_chief_comp(int treat, string one)
        {
            cmodel.insrtto_chief_comp(treat, one);
        }
        public void insrtto_obser(int treat, string one)
        {
            cmodel.insrtto_obser(treat, one);
        }
        public void insrtto_investi(int treat, string one)
        {
            cmodel.insrtto_investi(treat, one);
        }
        public void insrtto_diagno(int treat, string one)
        {
            cmodel.insrtto_diagno(treat, one);
        }
        public void insrtto_note(int treat, string one)
        {
             cmodel.insrtto_note(treat, one);
        }
    }
}
