using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
   public class prescription_setting_model
    {
        Connection db = new Connection();
        private string _strtype = "";
        public string StrType
        {
            get { return _strtype; }
            set { _strtype = value; }
        }
        private string _strunit = "";
        public string StrUnit
        {
            get { return _strunit; }
            set { _strunit = value; }
        }
        private string _drugname = "";
        public string Drugname
        {
            get { return _drugname; }
            set { _drugname = value; }
        }
        private string _strengthgr = "";
        public string Strength_gr
        {
            get { return _strengthgr; }
            set { _strengthgr = value; }
        }
        private string _intstructuion = "";
        public string Instruction
        {
            get { return _intstructuion; }
            set { _intstructuion = value; }
        }
        public DataTable get_drug()
        {
            DataTable dt = db.table("select * from tbl_adddrug ");
            return dt;
        }
        public DataTable fill_type_combo()
        {
            DataTable dt2 = db.table("select * from tbl_drug_type");
            return dt2;
        }
        public DataTable Fill_unit_combo()
        {
            DataTable dt3 = db.table("select * from tbl_unit");
            return dt3;
        }
        public DataTable get_value_from_drugtype(string strtype)
        {
            DataTable dt_drug_type = db.table("select * from tbl_drug_type where dr_type='" + strtype + "'");
            return dt_drug_type;
        }
        public void save_drugtype()
        {
            int ii = db.execute("insert into tbl_drug_type (dr_type) values('" + StrType + "')");
        }
        public DataTable check_unit(string strunit)
        {
            DataTable dt_drug_unit = db.table("select * from tbl_unit where name='" + strunit + "'");
            return dt_drug_unit;
        }
        public void save_unit()
        {
            int iii = db.execute("insert into tbl_unit (name) values('" + _strunit + "')");
        }

        public DataTable check_drugname(string name)
        {
            DataTable checkdataname = db.table("Select * from tbl_adddrug where name ='" + name + "'");
            return checkdataname;
        }
        public int Save_Drug()
        {
            int i = db.execute("insert into tbl_adddrug (name,type,strength,strength_gr,instructions,display_status,inventory_id) values('" + _drugname + "','" + _strtype + "','" + _strunit + "','" + _strengthgr+ "','" + _intstructuion + "','Yes','0')");
            return i;
        }

        public DataTable check_exists_drug(string id)
        {
            DataTable dt_drug = db.table("select id from tbl_prescription where drug_id='" + id + "'");
            return dt_drug;
        }
        public int Update_drug(string id)
        {
            int i = db.execute("update tbl_adddrug set name='" + _drugname + "',type='" + _strtype + "',strength='" + _strunit + "',strength_gr='" + _strengthgr + "',instructions='" + _intstructuion + "',display_status='Yes',inventory_id='0' where id='" + id + "'");
            return i;
        }
        public int delete_drug(string id)
        {
            int i = db.execute("delete from tbl_adddrug where id='" + id + "'");
            return i;
        }
        public DataTable drug_search(string text)
        {
            DataTable dt = db.table("select * from tbl_adddrug where name like '%" + text + "%'");
            return dt;
        }
       
    }
}
