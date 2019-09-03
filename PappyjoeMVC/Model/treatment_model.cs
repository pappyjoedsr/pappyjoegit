using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
    public class Treatment_model
    {
        Connection db = new Connection();
        public string check_privillege(string doctor_id)
        {
           string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRTP' and Permission='A'");
           return privid;
        }
        public string check_edit_privillege(string doctor_id)
        {
         string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRTP' and Permission='E'");
            return privid;
        }
        public string delete_privillege(string doctor_id)
        {
           string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRTP' and Permission='D'");
            return privid;
        }
        public DataTable get_treatments(string treatment_plan_id)
        {
            DataTable dt_pt_main = db.table("SELECT id,date,dr_name FROM tbl_treatment_plan_main where id='" + treatment_plan_id + "' ORDER BY date DESC");
            return dt_pt_main;
        }
        public DataTable treatment_sub_details(string id)
        {
          DataTable dt_pt_sub = db.table("SELECT id,procedure_name,cost,discount_inrs,discount_type,discount,total,note,status,tooth,quantity FROM tbl_treatment_plan where plan_main_id='" + id + "' ORDER BY id");
          return dt_pt_sub;
        }
      
        public DataTable Load_treatments(string patient_id)
        {
            System.Data.DataTable dt_pt_main = db.table("SELECT id,date,dr_name FROM tbl_treatment_plan_main where pt_id='" + patient_id + "' ORDER BY date DESC");
            return dt_pt_main;
        }
        public DataTable get_plan_id(string treatment_plan_id)
        {
            DataTable dt_pt_check = db.table("SELECT id FROM tbl_treatment_plan  where plan_main_id='" + treatment_plan_id + "' and status='0'");
            return dt_pt_check;
        }
        public void delete_treatment(string treatment_plan_id)
        {
            db.execute("delete from tbl_treatment_plan_main where id='" + treatment_plan_id + "'");
            db.execute("delete from tbl_treatment_plan where plan_main_id='" + treatment_plan_id + "'");
        }
    }
}
