using System.Data;

namespace PappyjoeMVC.Model
{
    public class Clinical_Findings_model
    {
        Connection db = new Connection();

        public string user_priv_EMRCF_A(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRCF' and Permission='A'");
            return id;
        }
        public string user_priv_EMRC_E(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRCF' and Permission='E'");
            return id;
        }
        public string usr_priv_EMRCF_D(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRCF' and Permission='D'");
            return id;
        }
        public DataTable dt_cf_main(string patient_id)
        {
            System.Data.DataTable dt_cf_main = db.table("SELECT tbl_clinical_findings.id,tbl_clinical_findings.date,tbl_doctor.doctor_name FROM tbl_clinical_findings join tbl_doctor on tbl_clinical_findings.dr_id=tbl_doctor.id  where tbl_clinical_findings.pt_id='" + patient_id + "' ORDER BY tbl_clinical_findings.date DESC");
            return dt_cf_main;
        }
        public DataTable dt_cf_Complaints(string dt_cf_main)
        {
            System.Data.DataTable dt_cf_Complaints = db.table("SELECT complaint_id FROM tbl_pt_chief_compaints where tbl_pt_chief_compaints.clinical_finding_id='" + dt_cf_main + "' ORDER BY tbl_pt_chief_compaints.id");
            return dt_cf_Complaints;
        }
        public DataTable dt_cf_observe(string dt_cf_main)
        {
            System.Data.DataTable dt_cf_observe = db.table("SELECT observation_id FROM tbl_pt_observation where tbl_pt_observation.clinical_finding_id='" + dt_cf_main + "' ORDER BY tbl_pt_observation.id");
            return dt_cf_observe;
        }
        public DataTable dt_cf_investigation(string dt_cf_main)
        {
            System.Data.DataTable dt_cf_investigation = db.table("SELECT investigation_id FROM tbl_pt_investigations where tbl_pt_investigations.clinical_finding_id='" + dt_cf_main + "' ORDER BY tbl_pt_investigations.id");
            return dt_cf_investigation;
        }
        public DataTable dt_cf_diagnosis(string dt_cf_main)
        {
            System.Data.DataTable dt_cf_diagnosis = db.table("SELECT diagnosis_id FROM tbl_pt_diagnosis where tbl_pt_diagnosis.clinical_finding_id='" + dt_cf_main + "' ORDER BY tbl_pt_diagnosis.id");
            return dt_cf_diagnosis;
        }
        public DataTable dt_cf_note(string dt_cf_main)
        {
            System.Data.DataTable dt_cf_note = db.table("SELECT note_name FROM tbl_pt_note where tbl_pt_note.clinical_findings_id='" + dt_cf_main + "' ORDER BY tbl_pt_note.id");
            return dt_cf_note;
        }
        public DataTable dt_medical(string patient_id)
        {
            DataTable dt_medical = db.table("SELECT med_id FROM  tbl_pt_medhistory WHERE pt_id = '" + patient_id + "'");
            return dt_medical;
        }
        public DataTable dt_cf(string clinic_id, string patient_id)
        {
            System.Data.DataTable dt_cf = db.table("SELECT tbl_clinical_findings.id,tbl_clinical_findings.date,tbl_doctor.doctor_name FROM tbl_clinical_findings join tbl_doctor on tbl_clinical_findings.dr_id=tbl_doctor.id where tbl_clinical_findings.id='" + clinic_id + "' and tbl_clinical_findings.pt_id='" + patient_id + "'");
            return dt_cf;
        }
        public DataTable dt_cf_Complaints_clinic_id(string clinic_id)
        {
            System.Data.DataTable dt_cf_Complaints = db.table("SELECT  complaint_id FROM tbl_pt_chief_compaints  where tbl_pt_chief_compaints.clinical_finding_id='" + clinic_id + "' ORDER BY tbl_pt_chief_compaints.id");
            return dt_cf_Complaints;
        }
        public DataTable dt_cf_observe_clinicid(string clinic_id)
        {
            System.Data.DataTable dt_cf_observe = db.table("SELECT observation_id FROM tbl_pt_observation where tbl_pt_observation.clinical_finding_id='" + clinic_id + "' ORDER BY tbl_pt_observation.id");
            return dt_cf_observe;
        }
        public DataTable dt_cf_investigation_clinicid(string clinic_id)
        {
            System.Data.DataTable dt_cf_investigation = db.table("SELECT investigation_id FROM tbl_pt_investigations where tbl_pt_investigations.clinical_finding_id='" + clinic_id + "' ORDER BY tbl_pt_investigations.id");
            return dt_cf_investigation;
        }
        public DataTable dt_cf_diagnosis_clinicid(string clinic_id)
        {
            System.Data.DataTable dt_cf_diagnosis = db.table("SELECT diagnosis_id FROM tbl_pt_diagnosis where tbl_pt_diagnosis.clinical_finding_id='" + clinic_id + "' ORDER BY tbl_pt_diagnosis.id");
            return dt_cf_diagnosis;
        }
        public DataTable dt_cf_note_clincid(string clinic_id)
        {
            System.Data.DataTable dt_cf_note = db.table("SELECT note_name FROM tbl_pt_note where tbl_pt_note.clinical_findings_id='" + clinic_id + "' ORDER BY tbl_pt_note.id");
            return dt_cf_note;
        }
        public int del_clinic_findings(string clinic_id)
        {
            int u = db.execute("delete from tbl_clinical_findings where id='" + clinic_id + "'");
            return u;
        }
        public int del_cheif_comp(string clinic_id)
        {
            int i = db.execute("delete from tbl_pt_chief_compaints where clinical_finding_id='" + clinic_id + "'");
            return i;
        }
        public int del_observ(string clinic_id)
        {
            int i = db.execute("delete from tbl_pt_observation where clinical_finding_id='" + clinic_id + "'");
            return i;
        }
        public int del_invest(string clinic_id)
        {
            int i = db.execute("delete from tbl_pt_investigations where clinical_finding_id='" + clinic_id + "'");
            return i;
        }
        public int del_diagno(string clinic_id)
        {
            int i = db.execute("delete from tbl_pt_diagnosis where clinical_finding_id='" + clinic_id + "'");
            return i;
        }
        public int del_note(string clinic_id)
        {
            int i = db.execute("delete from tbl_pt_note where clinical_findings_id='" + clinic_id + "'");
            return i;
        }
        public DataTable patient_information(string patient_id)
        {
            System.Data.DataTable patient = db.table("select pt_name,gender,street_address,city,primary_mobile_number,date,date_of_birth,age from tbl_patient where id='" + patient_id + "'");
            return patient;
        }
        public DataTable dt_cf_id_date(string clinic_id)
        {
            System.Data.DataTable dt_clinical_Findings = db.table("SELECT id , date FROM tbl_clinical_findings  where id='" + clinic_id + "' ");
            return dt_clinical_Findings;
        }
    }
}
