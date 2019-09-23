using System.Data;
namespace PappyjoeMVC.Model
{
    public class Clinical_Notes_Add_model
    {
        Connection db = new Connection();
        public DataTable investigation_cell(string idinv)
        {
            DataTable dt2 = db.table("select id,investigation from tbl_investigation where id='" + idinv + "'");
            return dt2;
        }
        public DataTable diagnose_cell(string iddiag)
        {
            DataTable dt3 = db.table("select id,diagnosis from tbl_diagnosis where id='" + iddiag + "'");
            return dt3;
        }
        public DataTable complaint_cell(string idcomp)
        {
            DataTable dt = db.table("select id,name from tbl_complaints where id='" + idcomp + "'");
            return dt;
        }
        public DataTable notes_cell(string idnote)
        {
            DataTable dt4 = db.table("select id,notes from tbl_notes where id='" + idnote + "'");
            return dt4;
        }
        public DataTable observation_cell(string idobs)
        {
            DataTable dt1 = db.table("select id,observations from tbl_observations where id='" + idobs + "'");
            return dt1;
        }
        public DataTable investsearchtxt(string investsearchtext)
        {
            DataTable dt2 = db.table("select id,investigation from tbl_investigation where investigation like '" + investsearchtext + "%'");
            return dt2;
        }
        public DataTable diagnosetxtsearch(string diagsearchtext)
        {
            DataTable dt3 = db.table("select id,diagnosis from tbl_diagnosis where diagnosis like '" + diagsearchtext + "%'");
            return dt3;
        }
        public DataTable compsearch(string compsearchtext)
        {
            DataTable dt = db.table("select id,name from tbl_complaints where name like '" + compsearchtext + "%'");
            return dt;
        }
        public DataTable notesearch(string notesearchtext)
        {
            DataTable dt4 = db.table("select * from tbl_notes where notes like'" + notesearchtext + "%'");
            return dt4;
        }
        public DataTable observsearch(string obsersearchtext)
        {
            DataTable dt1 = db.table("Select id,observations from tbl_observations where observations like'" + obsersearchtext + "%'");
            return dt1;
        }
        public DataTable CheckInvest(string investtextbox)
        {
            DataTable checkdataINVEST = db.table("Select * from tbl_investigation where investigation ='" + investtextbox);
            return checkdataINVEST;
        }
        public int investigation_insert(string investtextbox)
        {
            int i = db.execute("insert into tbl_investigation(investigation) values('" + investtextbox + "')");
            return i;
        }
        public DataTable Show_investigation()
        {
            DataTable dt2 = db.table("select id,investigation from tbl_investigation");
            return dt2;
        }
        public DataTable CheckdataDiag(string diagtext)
        {
            DataTable checkdataDIAG = db.table("Select * from tbl_diagnosis where diagnosis ='" + diagtext + "'");
            return checkdataDIAG;
        }
        public int Insert_diagno(string diagtext)
        {
            int i = db.execute("insert into tbl_diagnosis(diagnosis) values('" + diagtext + "')");
            return i;
        }
        public DataTable show_diagno()
        {
            DataTable dt3 = db.table("select id,diagnosis from tbl_diagnosis");
            return dt3;
        }
        public DataTable checkdataAcc(string comptext)
        {
            DataTable checkdatacc = db.table("Select * from tbl_complaints where name ='" + comptext + "'");
            return checkdatacc;
        }
        public int insert_compl(string comptextbox)
        {
            int i = db.execute("insert into tbl_complaints(name) values('" + comptextbox + "')");
            return i;
        }
        public DataTable show_compl()
        {
            DataTable dt = db.table("select id,name from tbl_complaints");
            return dt;
        }
        public int Update_compl(string comptextbox, int rowvalue)
        {
            int i = db.execute("update tbl_complaints set name='" + comptextbox + "' where id='" + rowvalue + "' ");
            return i;
        }
        public DataTable checkdataNote(string notetextbox)
        {
            DataTable checkdataNOTE = db.table("Select * from tbl_notes where notes ='" + notetextbox + "'");
            return checkdataNOTE;
        }
        public int insert_note(string notetextbox)
        {
            int i = db.execute("insert into tbl_notes(notes) values('" + notetextbox + "')");
            return i;
        }
        public DataTable show_note()
        {
            DataTable dt4 = db.table("select id,notes from tbl_notes");
            return dt4;
        }
        public DataTable checkdataOB(string obsertextbox)
        {
            DataTable checkdataOB = db.table("Select * from tbl_observations where observations ='" + obsertextbox + "'");
            return checkdataOB;
        }
        public int insert_Observ(string obsertextbox)
        {
            int i = db.execute("insert into tbl_observations(observations) values('" + obsertextbox + "')");
            return i;
        }
        public DataTable show_observation()
        {
            DataTable dt1 = db.table("select id,observations from tbl_observations");
            return dt1;
        }
        public string userPrivilege_for_ClinicalNotes_Add(string doctor_id)
        {
            string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRCF' and Permission='A'");
            return privid;
        }
        public DataTable getdatafrom_clinicalFindings(string id, string ptid)
        {
            DataTable dt_cf = db.table("SELECT tbl_clinical_findings.id,tbl_clinical_findings.date,tbl_doctor.doctor_name FROM tbl_clinical_findings join tbl_doctor on tbl_clinical_findings.dr_id=tbl_doctor.id where tbl_clinical_findings.id='" + id + "' and pt_id='" + ptid + "'");
            return dt_cf;
        }
        public string get_clinicId(string ptid)
        {
            string clincid = db.scalar("select id from tbl_clinical_findings where pt_id='"+ptid+"'");
            return clincid;
        }
        public DataTable getComplaints(string id)
        {
            System.Data.DataTable dt_cf_Complaints = db.table("SELECT  id,complaint_id FROM tbl_pt_chief_compaints where tbl_pt_chief_compaints.clinical_finding_id='" + id + "' ORDER BY tbl_pt_chief_compaints.id");
            return dt_cf_Complaints;
        }//SELECT complaint_id FROM tbl_pt_chief_compaints WHERE clinical_finding_id='" + App_dtb.Rows[0]["EHR_clinicalfindings"] +
        public DataTable get_observation(string id)
        {
            System.Data.DataTable dt_cf_observe = db.table("SELECT id,observation_id FROM tbl_pt_observation where tbl_pt_observation.clinical_finding_id='" + id + "' ORDER BY tbl_pt_observation.id");
            return dt_cf_observe;
        }
        public DataTable get_invest(string id)
        {
            System.Data.DataTable dt_cf_investigation = db.table("SELECT investigation_id,id FROM tbl_pt_investigations where tbl_pt_investigations.clinical_finding_id='" + id + "' ORDER BY tbl_pt_investigations.id");
            return dt_cf_investigation;
        }
        public DataTable get_diagno(string id)
        {
            System.Data.DataTable dt_cf_diagnosis = db.table("SELECT diagnosis_id,id FROM tbl_pt_diagnosis where tbl_pt_diagnosis.clinical_finding_id='" + id + "' ORDER BY tbl_pt_diagnosis.id");
            return dt_cf_diagnosis;
        }//SELECT diagnosis_id FROM  tbl_pt_diagnosis WHERE clinical_finding_id='" + App_dtb.Rows[0]["EHR_clinicalfindings"] +
        public DataTable get_note(string id)
        {
            System.Data.DataTable dt_cf_note = db.table("SELECT note_name,id FROM tbl_pt_note where tbl_pt_note.clinical_findings_id='" + id + "' ORDER BY tbl_pt_note.id");
            return dt_cf_note;
        }//SELECT note_name FROM tbl_pt_note WHERE clinical_findings_id='" + App_dtb.Rows[0]["EHR_clinicalfindings"] + "'
        public int insertInto_clinical_findings(string ptid, string dt, string date)
        {
            int i = db.execute("insert into tbl_clinical_findings (pt_id,dr_id,date) values ('" + ptid + "','" + dt + "','" + date + "')");
            return i;
        }
        public DataTable MaxId_clinic_findings()
        {
            DataTable treatment = db.table("select MAX(id) from tbl_clinical_findings");
            return treatment;
        }
        public int insrtto_investi(int treat, string one)
        {
            int i = db.execute("insert into tbl_pt_investigations (clinical_finding_id,investigation_id) values('" + treat + "','" + one.Replace("'", " ") + "')");
            return i;
        }
        public int insrtto_diagno(int treat, string one)
        {
            int i = db.execute("insert into tbl_pt_diagnosis (clinical_finding_id,diagnosis_id) values('" + treat + "','" + one.Replace("'", " ") + "')");
            return i;
        }
        public int insrtto_note(int treat, string one)
        {
            int i = db.execute("insert into tbl_pt_note (clinical_findings_id,note_name) values('" + treat + "','" + one.Replace("'", " ") + "')");
            return i;
        }
        public int insrtto_obser(int treat, string one)
        {
            int i = db.execute("insert into tbl_pt_observation (clinical_finding_id,observation_id) values('" + treat + "','" + one.Replace("'", " ") + "')");
            return i;
        }
        public int insrtto_chief_comp(int treat, string one)
        {
            int i = db.execute("insert into tbl_pt_chief_compaints (clinical_finding_id,complaint_id) values('" + treat + "','" + one.Replace("'", " ") + "')");
            return i;
        }
        public int Update_clinical_findings(string ptid, string dt, string id)
        {
            int i = db.execute("update tbl_clinical_findings set pt_id='" + ptid + "',dr_id='" + dt + "' where pt_id='" + ptid + "' and id='" + id + "'");
            return i;
        }
        public int Update_date_of_clinical(string date, string ptid, string id)
        {
            int i = db.execute("update  tbl_clinical_findings set date ='" + date + "' where pt_id='" + ptid + "' and id='" + id + "'");
            return i;
        }
        public int del_investi(string id)
        {
            int i = db.execute("delete from  tbl_pt_investigations where  clinical_finding_id='" + id + "'");
            return i;
        }
        public int del_diagno(string id)
        {
            int i = db.execute("delete from  tbl_pt_diagnosis where  clinical_finding_id='" + id + "'");
            return i;
        }
        public int del_note(string id)
        {
            int i = db.execute("delete from  tbl_pt_note where clinical_findings_id='" + id + "'");
            return i;
        }
        public int del_obser(string id)
        {
            int i = db.execute("delete from  tbl_pt_observation where  clinical_finding_id='" + id + "'");
            return i;
        }
        public int del_chiefComp(string id)
        {
            int i = db.execute("delete from  tbl_pt_chief_compaints where  clinical_finding_id='" + id + "'");
            return i;
        }
        public int Add_investi(string id, string grid)
        {
            int i = db.execute("insert into tbl_pt_investigations (clinical_finding_id,investigation_id) values('" + id + "','" + grid + "')");
            return i;
        }
        public int Add_diagno(string id, string grid)
        {
            int i = db.execute("insert into tbl_pt_diagnosis (clinical_finding_id,diagnosis_id) values('" + id + "','" + grid + "')");
            return i;
        }
        public int Add_note(string id, string grid)
        {
            int i = db.execute("insert into tbl_pt_note (clinical_findings_id,note_name) values('" + id + "','" + grid + "')");
            return i;
        }
        public int Add_observ(string id, string grid)
        {
            int i = db.execute("insert into tbl_pt_observation (clinical_finding_id,observation_id) values('" + id + "','" + grid + "')");
            return i;
        }
        public int Add_cheifComp(string id, string grid)
        {
            int i = db.execute("insert into tbl_pt_chief_compaints (clinical_finding_id,complaint_id) values('" + id + "','" + grid + "')");
            return i;
        }
        public int Del_Complaints(int row)
        {
            int i = db.execute("delete from tbl_complaints where id='" + row + "'");
            return i;
        }
        public DataTable COMP(int rowvalue)
        {
            DataTable dtb = db.table("select * from tbl_complaints where id='" + rowvalue + "'");
            return dtb;
        }
    }
}
