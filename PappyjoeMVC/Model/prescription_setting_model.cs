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
        public void save_drugtype(string StrType)
        {
            int ii = db.execute("insert into tbl_drug_type (dr_type) values('" + StrType + "')");
        }
        public DataTable check_unit(string strunit)
        {
            DataTable dt_drug_unit = db.table("select * from tbl_unit where name='" + strunit + "'");
            return dt_drug_unit;
        }
        public void save_unit(string _strunit)
        {
            int iii = db.execute("insert into tbl_unit (name) values('" + _strunit + "')");
        }
        public string check_drugname(string name)
        {
            string checkdataname = db.scalar("Select name from tbl_adddrug where name ='" + name + "'");
            return checkdataname;
        }
        public int Save_Drug(string _drugname , string _strtype , string _strunit,string  _strengthgr ,string _intstructuion)
        {
            int i = db.execute("insert into tbl_adddrug (name,type,strength,strength_gr,instructions,display_status,inventory_id) values('" + _drugname + "','" + _strtype + "','" + _strunit + "','" + _strengthgr+ "','" + _intstructuion + "','Yes','0')");
            return i;
        }
        public string check_exists_drug(string id)
        {
            string dt_drug = db.scalar("select id from tbl_prescription where drug_id='" + id + "'");
            return dt_drug;
        }
        public int Update_drug(string id, string _drugname, string _strtype, string _strunit, string _strengthgr, string _intstructuion)
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
