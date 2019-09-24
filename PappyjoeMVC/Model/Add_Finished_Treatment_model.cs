using System.Data;
namespace PappyjoeMVC.Model
{
    public class Add_Finished_Treatment_model
    {
        Connection db = new Connection();
       
        public DataTable Load_finishedtreatments(string patient_id)
        {
            DataTable dt_tp = db.table("SELECT id, plan_main_id,procedure_name,procedure_id,cost from tbl_treatment_plan where pt_id='" + patient_id + "' and status='1'");
            return dt_tp;
        }
        public DataTable load_proceduresgrid()
        {
            DataTable dt_pt = db.table("SELECT id,name,cost FROM tbl_addproceduresettings ORDER BY id");
            return dt_pt;
        }
        public DataTable Load_treatmentPlans(string id)
        {
            System.Data.DataTable rs_plan = db.table("select tbl_treatment_plan.procedure_id," +
                   "tbl_treatment_plan.procedure_name,tbl_treatment_plan.quantity,tbl_treatment_plan.cost," +
                   "tbl_treatment_plan.discount_type,tbl_treatment_plan.discount,tbl_treatment_plan.total," +
                   "tbl_treatment_plan.discount_inrs,tbl_treatment_plan.note,tbl_treatment_plan_main.date," +
                   "tbl_treatment_plan_main.dr_id,tbl_treatment_plan.id,tbl_treatment_plan.tooth from tbl_treatment_plan join tbl_treatment_plan_main on tbl_treatment_plan_main.id=tbl_treatment_plan.plan_main_id where tbl_treatment_plan.id='" + id + "'");
            return rs_plan;
        }
        public void save_procedure_plans(string name, string cost)
        {
            db.execute("insert into tbl_addproceduresettings(name,cost) values('" + name + "','" + cost + "')");
        }
        public string Get_max_procedureid()
        {
            string p = db.scalar("select MAX(id) from tbl_addproceduresettings");
            return p;
        }
        public DataTable Search_procedure(string _search)
        {
            DataTable dtb = db.table("SELECT id,name,cost from tbl_addproceduresettings where name like'" + _search + "%' ORDER BY id DESC");
            return dtb;
        } 
        public DataTable get_procedure_Name(string id)
        {
            DataTable dt = db.table("select id,name,cost from tbl_addproceduresettings where id ='" + id + "'");
            return dt;
        }
        public DataTable Get_treatment_details(string plan_p_id)
        {
            DataTable dt_treatment = db.table("select procedure_name,quantity,cost,discount_type,discount,discount_inrs,note,tooth,total from tbl_treatment_plan where id ='" + plan_p_id + "'");
            return dt_treatment;
        }
        public DataTable get_completed_id(string patient_id, string date)
        {
            DataTable dt_pt = db.table("SELECT id FROM tbl_completed_id where patient_id='" + patient_id + "' and completed_date='" + date + "' ORDER BY id");
            return dt_pt;
        }
        public void save_completed_id(string date, string patient_id)
        {
            db.execute("insert into tbl_completed_id (completed_date,patient_id,review) values('" + date + "','" + patient_id + "','NO')");
        }
        public string get_completedMaxid()
        {
            string dt = db.scalar("select MAX(id) from tbl_completed_id");
            return dt;
        }
        public void save_completed_items(int plan_main_id, string patient_id, string procedure_id, string procedure_name, string quantity, string cost, string discount_type, string discount, string total, string discount_inrs, string note, string date, string dr_id, string completed_id, string tooth)
        {
            db.execute("insert into tbl_completed_procedures (plan_main_id,pt_id,procedure_id,procedure_name,quantity,cost,discount_type,discount,total,discount_inrs,note,status,date,dr_id,completed_id,tooth)" + " values('" + plan_main_id + "','" + patient_id + "','" + procedure_id + "','" + procedure_name + "','" + quantity + "','" + cost + "','" + discount_type + "','" + discount + "','" + total + "','" + discount_inrs + "','" + note + "','1','" + date + "','" + dr_id + "','" + completed_id + "','" + tooth + "')");
        }
        public void update_treatment_status(string id)
        {
            db.execute("update  tbl_treatment_plan set status='0' where id= '" + id + "'");
        }
        public void update_review(string date, int j_Review)
        {
            db.execute("UPDATE tbl_completed_id SET review='YES',Review_date='" + date + "' WHERE id='" + j_Review + "'");
        }
        public void update_review_No(string date, int j_Review)
        {
            db.execute("UPDATE tbl_completed_id SET review='NO' ,Review_date='" + date + "'  WHERE id='" + j_Review + "'");
        }
        public DataTable get_completed_id_date(string patient_id)
        {
            DataTable dt_pt_main = db.table("SELECT id,completed_date FROM tbl_completed_id where patient_id='" + patient_id + "' ORDER BY completed_date DESC");
            return dt_pt_main;
        }
        public DataTable get_completed_details(string mainid)
        {
            DataTable dt_pt_sub = db.table("SELECT tbl_completed_procedures.id,tbl_completed_procedures.procedure_name,tbl_completed_procedures.cost,tbl_completed_procedures.discount_inrs,tbl_completed_procedures.discount_type,tbl_completed_procedures.discount,tbl_completed_procedures.total,tbl_completed_procedures.note,tbl_completed_procedures.status,tbl_completed_procedures.tooth,tbl_doctor.doctor_name,tbl_completed_procedures.quantity FROM tbl_completed_procedures join tbl_doctor on tbl_completed_procedures.dr_id=tbl_doctor.id  where tbl_completed_procedures.plan_main_id='" + mainid + "' ORDER BY tbl_completed_procedures.date");
            return dt_pt_sub;
        }
        public DataTable get_plamManin_id(string treatment_complete_id)
        {
            DataTable dtb = db.table("SELECT plan_main_id,completed _id FROM tbl_completed_procedures  where id='" + treatment_complete_id + "'");
            return dtb;
        }
        public void update_status1(string plan_main_id)
        {
            db.execute("update  tbl_treatment_plan set status='1' where id= '" + plan_main_id + "'");
        }
        //finished procedure
        public string Add_privilliege(string doctor_id)
        {
            string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRFP' and Permission='A'");
            return privid;
        }
        public string edit_privillege(string doctor_id)
        {
            string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRFP' and Permission='E'");
            return privid;
        }
        public string delete_privillage(string doctor_id)
        {
            string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRFP' and Permission='D'");
            return privid;
        }
        public void delete(string treatment_complete_id)
        {
            db.execute("delete from tbl_completed_procedures where id='" + treatment_complete_id + "'");
        }
        public DataTable chek_planmain_id(string completed_main_id)
        {
            DataTable dt_pt_complete2 = db.table("SELECT plan_main_id FROM tbl_completed_procedures  where plan_main_id='" + completed_main_id + "'");
            return dt_pt_complete2;
        }
        public void delete_completedid(string completed_main_id)
        {
            db.execute("delete from tbl_completed_id where id='" + completed_main_id + "'");
        }
    }
}