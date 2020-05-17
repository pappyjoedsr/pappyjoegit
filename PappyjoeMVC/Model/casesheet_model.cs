using System.Data;
namespace PappyjoeMVC.Model
{
    class Casesheet_model
    {
        Connection db = new Connection();
        public DataTable vitalSign_btwn_date(string patient_id, string startDateTime, string startDateTime1)
        {
            DataTable sqlstring = db.table("select * from tbl_Vital_Signs where pt_id='" + patient_id + "' and date between  '" + startDateTime + "' AND '" + startDateTime1 + "' ORDER BY date");
            return sqlstring;
        }
        public DataTable vitalSign(string patient_id)
        {
            DataTable sqlstring = db.table("select * from tbl_Vital_Signs where pt_id='" + patient_id + "' order by date ");
            return sqlstring;
        }
        public DataTable complaints_btwn_date(string patient_id, string startDateTime, string startDateTime1)
        {
            DataTable sqlstring = db.table("SELECT tbl_pt_chief_compaints.complaint_id,tbl_clinical_findings.date FROM tbl_clinical_findings INNER JOIN tbl_pt_chief_compaints ON tbl_clinical_findings.id = tbl_pt_chief_compaints.clinical_finding_id where tbl_clinical_findings.pt_id='" + patient_id + "' and tbl_clinical_findings.date between  '" + startDateTime + "' AND '" + startDateTime1 + "' ORDER BY tbl_clinical_findings.date");
            return sqlstring;
        }
        public DataTable complaints(string patient_id)
        {
            DataTable sqlstring = db.table("SELECT tbl_pt_chief_compaints.complaint_id,tbl_clinical_findings.date FROM tbl_clinical_findings INNER JOIN tbl_pt_chief_compaints ON tbl_clinical_findings.id = tbl_pt_chief_compaints.clinical_finding_id where tbl_clinical_findings.pt_id='" + patient_id + "' order by tbl_clinical_findings.date");
            return sqlstring;
        }
        public DataTable observation_btwn_date(string patient_id, string startDateTime, string startDateTime1)
        {
            DataTable sqlstring = db.table("SELECT tbl_clinical_findings.date, tbl_pt_observation.observation_id FROM tbl_pt_observation INNER JOIN tbl_clinical_findings ON tbl_pt_observation.clinical_finding_id = tbl_clinical_findings.id where tbl_clinical_findings.pt_id='" + patient_id + "' and tbl_clinical_findings.date between  '" + startDateTime + "' AND '" + startDateTime1 + "' ORDER BY tbl_clinical_findings.date");
            return sqlstring;
        }
        public DataTable observation(string patient_id)
        {
            DataTable sqlstring = db.table("SELECT tbl_clinical_findings.date, tbl_pt_observation.observation_id FROM tbl_pt_observation INNER JOIN tbl_clinical_findings ON tbl_pt_observation.clinical_finding_id = tbl_clinical_findings.id where tbl_clinical_findings.pt_id='" + patient_id + "' order by tbl_clinical_findings.date");
            return sqlstring;
        }
        public DataTable investgstion_btwn_date(string patient_id, string startDateTime, string startDateTime1)
        {
            DataTable sqlstring = db.table("SELECT tbl_clinical_findings.date, tbl_pt_investigations.investigation_id FROM tbl_pt_investigations INNER JOIN tbl_clinical_findings ON tbl_pt_investigations.clinical_finding_id = tbl_clinical_findings.id where tbl_clinical_findings.pt_id='" + patient_id + "' and tbl_clinical_findings.date between  '" + startDateTime + "' AND '" + startDateTime1 + "' ORDER BY tbl_clinical_findings.date");
            return sqlstring;
        }
        public DataTable investgation(string patient_id)
        {
            DataTable sqlstring = db.table("SELECT tbl_clinical_findings.date, tbl_pt_investigations.investigation_id FROM tbl_pt_investigations INNER JOIN tbl_clinical_findings ON tbl_pt_investigations.clinical_finding_id = tbl_clinical_findings.id where tbl_clinical_findings.pt_id='" + patient_id + "' order by tbl_clinical_findings.date");
            return sqlstring;
        }
        public DataTable diagnosis_btwn_date(string patient_id, string startDateTime, string startDateTime1)
        {
            DataTable sqlstring = db.table("SELECT tbl_pt_diagnosis.diagnosis_id, tbl_clinical_findings.date FROM  tbl_clinical_findings INNER JOIN tbl_pt_diagnosis ON tbl_clinical_findings.id = tbl_pt_diagnosis.clinical_finding_id where tbl_clinical_findings.pt_id='" + patient_id + "' and tbl_clinical_findings.date between  '" + startDateTime + "' AND '" + startDateTime1 + "' ORDER BY tbl_clinical_findings.date");
            return sqlstring;
        }
        public DataTable diagnosis(string patient_id)
        {
            DataTable sqlstring = db.table("SELECT tbl_pt_diagnosis.diagnosis_id, tbl_clinical_findings.date FROM  tbl_clinical_findings INNER JOIN tbl_pt_diagnosis ON tbl_clinical_findings.id = tbl_pt_diagnosis.clinical_finding_id where tbl_clinical_findings.pt_id='" + patient_id + "' order by tbl_clinical_findings.date");
            return sqlstring;
        }
        public DataTable notes_btwn_date(string patient_id, string startDateTime, string startDateTime1)
        {
            DataTable sqlstring = db.table("SELECT tbl_clinical_findings.date, tbl_pt_note.note_name FROM tbl_pt_note INNER JOIN tbl_clinical_findings ON tbl_pt_note.clinical_findings_id = tbl_clinical_findings.id where tbl_clinical_findings.pt_id='" + patient_id + "'and tbl_clinical_findings.date between  '" + startDateTime + "' AND '" + startDateTime1 + "' ORDER BY tbl_clinical_findings.date");
            return sqlstring;
        }
        public DataTable notes(string patient_id)
        {
            DataTable sqlstring = db.table("SELECT tbl_clinical_findings.date, tbl_pt_note.note_name FROM tbl_pt_note INNER JOIN tbl_clinical_findings ON tbl_pt_note.clinical_findings_id = tbl_clinical_findings.id where tbl_clinical_findings.pt_id='" + patient_id + "' order by tbl_clinical_findings.date");
            return sqlstring;
        }
        public DataTable treatment_btewn_date(string patient_id, string startDateTime, string startDateTime1)
        {
            DataTable sqlstring = db.table("SELECT  tbl_treatment_plan_main.date, tbl_treatment_plan.id, tbl_treatment_plan.note, tbl_treatment_plan.procedure_name,tbl_treatment_plan.tooth FROM tbl_treatment_plan_main INNER JOIN  tbl_treatment_plan ON tbl_treatment_plan_main.id = tbl_treatment_plan.plan_main_id where tbl_treatment_plan.pt_id='" + patient_id + "' and tbl_treatment_plan_main.date between  '" + startDateTime + "' AND '" + startDateTime1 + "' ORDER BY id");
            return sqlstring;
        }
        public DataTable treatment(string patient_id)
        {
            DataTable sqlstring = db.table("SELECT  tbl_treatment_plan_main.date, tbl_treatment_plan.id, tbl_treatment_plan.note, tbl_treatment_plan.procedure_name,tbl_treatment_plan.tooth FROM tbl_treatment_plan_main INNER JOIN  tbl_treatment_plan ON tbl_treatment_plan_main.id = tbl_treatment_plan.plan_main_id where tbl_treatment_plan.pt_id='" + patient_id + "' ORDER BY id");
            return sqlstring;
        }
        public DataTable prescription_btwn_date(string patient_id, string startDateTime, string startDateTime1)
        {
            DataTable sqlstring = db.table("SELECT drug_name,strength,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,strength_gr,date FROM tbl_prescription where pt_id='" + patient_id + "' and date between  '" + startDateTime + "' AND '" + startDateTime1 + "' ORDER BY id");
            return sqlstring;
        }
        public DataTable prescription(string patient_id)
        {
            DataTable sqlstring = db.table("SELECT date,drug_name,strength,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,strength_gr FROM tbl_prescription where pt_id='" + patient_id + "' ORDER BY id");
            return sqlstring;
        }
        public DataTable payment_betwn_date(string patient_id, string startDateTime, string startDateTime1)
        {
            DataTable sqlstring = db.table("SELECT cost,unit,services, total,date,discountin_rs FROM  tbl_invoices where pt_id='" + patient_id + "'and date between  '" + startDateTime + "' AND '" + startDateTime1 + "' order by date");
            return sqlstring;
        }
        public DataTable payment(string patient_id)
        {
            DataTable sqlstring = db.table("SELECT cost,unit,services,total,date,discountin_rs FROM  tbl_invoices where pt_id='" + patient_id + "' order by date");
            return sqlstring;
        }
        public void insert(string richTxt_PresentIllness, string richTxt_LabInvestigations, string richTxt_SurgicalNotes, string richTxt_ConditionDischarge, string richTxt_AdviceDischarge, string startDateTime1, string txtTime, string startDateTime2, string patient_id)
        {
            int i = db.execute("insert into tbl_Casesheetaddmore(PRESENTILLNESS,LabInvestigations,SurgicalNotes,richConditionDischarge,richAdviceDischarge,NEXTdateREVIEW,Time,dateofcasesheet,pt_id) values('" + richTxt_PresentIllness + "','" + richTxt_LabInvestigations + "','" + richTxt_SurgicalNotes + "','" + richTxt_ConditionDischarge + "','" + richTxt_AdviceDischarge + "','" + startDateTime1 + "','" + txtTime + "','" + startDateTime2 + "','" + patient_id + "')");

        }
        public void save_casesheet(string patient_id,string frmdte,string todte,string casesheet,string clinic_name,string doctr_name,string ptnt_dtls,string chief_complants,string diagnosis,string investigatn,string observatn,string note,string vitalsign_dtls,string cmpleted,string prescriptn,string amnt_dtls,string doctr,string dischrg_date,string departmnt,string presnt_illness,string lab_investigatn,string surgical_notes,string dischrg_condn,string advice,string review_date,string time)
        {
            int i = db.execute("insert into tbl_casesheet(patient_id,from_date,to_date,casesheet,clinic_name,doctor_name,patient_dtls,chief_complaints,diagnosis,investigation,observation,note,vitalsign_details,completed,prescription,amount_details,doctor,dischrg_date,department,present_illness,lab_investigation,surgical_notes,dischrg_condition,advice,review_date,review_time)values('" + patient_id + "','" + frmdte + "','" + todte + "','"+casesheet+"','"+clinic_name+"','"+doctr_name+"','"+ptnt_dtls+"','"+chief_complants+"','"+diagnosis+"','"+investigatn+"','"+observatn+"','"+note+"','"+vitalsign_dtls+"','"+cmpleted+"','"+prescriptn+"','"+amnt_dtls+"','"+doctr+"','"+dischrg_date+"','"+departmnt+"','"+presnt_illness+"','"+lab_investigatn+"','"+surgical_notes+"','"+dischrg_condn+"','"+advice+"','"+review_date+"','"+time+"')");
        }
        public DataTable getdates(string patient_id)
        {
            DataTable dt = db.table("select from_date,to_date from tbl_casesheet where patient_id='" + patient_id + "'");
            return dt;
        }
        public DataTable loaddata(string from_date,string to_date)
        {
            DataTable dtb = db.table("select * from tbl_casesheet where from_date='" + from_date + "' and to_date='" + to_date + "'");
            return dtb;
        }
        public DataTable loadsummary(string patient_id)
        {
            DataTable dtb = db.table("select * from tbl_casesheet where patient_id='" + patient_id + "'");
            return dtb;
        }
    }
}
