using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
   public  class EMR_model
    {
        Connection db = new Connection();
        //complaints
        public DataTable Fii_ComplaintsGrid()
        {
            DataTable dtb = db.table("select * from tbl_complaints order by id");
            return dtb;
        }
        public DataTable Check_complaints(string complaints)
        {
            DataTable checkdatacc = db.table("Select * from tbl_complaints where name ='" + complaints + "'");
            return checkdatacc;
        }
        public void save_complaints(string Complaints)
        {
            int i = db.execute("insert into tbl_complaints (name,display_status) values('" + Complaints + "','Yes')");
        }
        public void update_complaints(string id_comp,string Complaints)
        {
            int i = db.execute("update tbl_complaints set name='" + Complaints + "',display_status='Yes' where id='" + id_comp + "'");
        }
        public void Delete_complaints(string id_comp)
        {
            int i = db.execute("delete from tbl_complaints where id='" + id_comp + "'");
        }
        public DataTable search_complaints(string text)
        {
            DataTable dt2 = db.table("select * from tbl_complaints where name like '%" + text + "%'");
            return dt2;
        }
        //observation
        public DataTable Fill_observationGrid()
        {
            DataTable dt2 = db.table("select * from tbl_observations order by id");
            return dt2;
        }
        public DataTable Check_observation(string name)
        {
            DataTable checkdataOB = db.table("Select * from tbl_observations where observations ='" + name + "'");
            return checkdataOB;
        }
        public int save_observation(string _observation)
        {
            int i = db.execute("insert into tbl_observations (observations,display_status) values('" + _observation + "','Yes')");
            return i;
        }
        public void delete_observation(string id)
        {
            int i = db.execute("delete from tbl_observations where id='" + id + "'");
        }
        public int Update_observation(string id, string _observation)
        {
            int i = db.execute("update tbl_observations set observations='" + _observation+ "',display_status='Yes' where id= '" + id + "'");
            return i;
        }
        public DataTable search_observation(string text)
        {
            DataTable dt2 = db.table("select * from tbl_observations where observations like '%" + text + "%'");
            return dt2;
        }
        //Diagnosis
        public DataTable fill_diagnosisGrid()
        {
            DataTable dt2 = db.table("select * from tbl_diagnosis order by id");
            return dt2;
        }
        public DataTable check_diagnosis(string name)
        {
            DataTable checkdataDIAG = db.table("Select * from tbl_diagnosis where diagnosis ='" + name + "'");
            return checkdataDIAG;
        }
        public void save_diagnosis(string _diagnosis)
        {
            int i = db.execute("insert into tbl_diagnosis (diagnosis,display_status) values('" + _diagnosis + "','Yes')");
        }
        public void update_diagnosis(string id_diag,string _diagnosis)
        {
            int i = db.execute("Update tbl_diagnosis set diagnosis='" + _diagnosis + "',display_status='Yes' where id='" + id_diag + "'");
        }
        public void delete(string id_diag)
        {
            int i = db.execute("delete from tbl_diagnosis where id='" + id_diag + "'");
        }
        public DataTable search_diagnosis(string mname)
        {
            DataTable dt2 = db.table("select * from tbl_diagnosis where diagnosis like '%" + mname + "%'");
            return dt2;
        }
        //investgation
        public DataTable Fill_investgation()
        {
            DataTable dt2 = db.table("select * from tbl_investigation order by id");
            return dt2;
        }
        public DataTable check_invest(string name)
        {
            DataTable checkdataINVEST = db.table("Select * from tbl_investigation where investigation ='" + name + "'");
            return checkdataINVEST;
        }
        public void save_investgation(string _investgation)
        {
            int i = db.execute("insert into tbl_investigation (investigation,display_status) values ('" + _investgation + "','Yes')");
        }
        public void update_investgation(string id_invest,string _investgation)
        {
            int i = db.execute("update tbl_investigation set investigation='" + _investgation + "',display_status='Yes'where id='" + id_invest + "'");
        }
        public void delete_investigation(string id_invest)
        {
            int i = db.execute("delete from tbl_investigation where id='" + id_invest + "'");
        }
        public DataTable search_investgation(string name)
        {
            DataTable dt2 = db.table("select * from tbl_investigation where investigation like '%" + name + "%'");
            return dt2;
        }
        //note
        public DataTable Fill_notegrid()
        {
            DataTable dt2 = db.table("select * from tbl_notes order by id");
            return dt2;
        }
        public DataTable check_notes(string note)
        {
            DataTable checkdataNOTE = db.table("Select * from tbl_notes where notes ='" + note + "'");
            return checkdataNOTE;
        }
        public void save_note(string _note)
        {
            int i = db.execute("insert into tbl_notes (notes) values ('" + _note + "')");
        }
        public void update_note(string id_notes,string _note)
        {
            int i = db.execute("update tbl_notes set notes='" + _note + "'where id='" + id_notes + "'");
        }
        public void delete_note(string id_notes)
        {
            int i = db.execute("delete from tbl_notes where id='" + id_notes + "'");
        }
        public DataTable search_note(string text)
        {
            DataTable dt2 = db.table("select * from tbl_notes where notes like '%" + text + "%'");
            return dt2;
        }
    }
}
