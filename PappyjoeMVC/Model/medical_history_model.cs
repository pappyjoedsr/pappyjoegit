using System.Data;

namespace PappyjoeMVC.Model
{
    public class Medical_history_model
    {
        Connection db = new Connection();
        public DataTable Check_medical(string name)
        {
            DataTable checkdatacc = db.table("Select * from tbl_medhistory where name ='" + name + "'");
            return checkdatacc;
        }
        public int save_medical(string _medical)
        {
            int i = db.execute("insert into tbl_medhistory (name) values('" + _medical + "')");
            return i;
        }
        public DataTable load_medical()
        {
            DataTable dt = db.table("select * from tbl_medhistory order by id");
            return dt;
        }
        public void update_medical(string id, string _medical)
        {
            int i = db.execute("update tbl_medhistory set name='" + _medical + "' where id='" + id + "'");
        }
        public void delete_medical(string id)
        {
            int i = db.execute("delete from tbl_medhistory where id='" + id + "'");
        }
        public DataTable seaerh_medical(string name)
        {
            DataTable dt = db.table("select * from tbl_medhistory where name like '%" + name + "%'");
            return dt;
        }
        //group
        public DataTable Load_Group()
        {
            DataTable dt_maintest = db.table("select id,name from tbl_group order by id");
            return dt_maintest;
        }
        public DataTable check_groupname(string name)
        {
            DataTable checkdatacc = db.table("Select * from tbl_group where name ='" + name + "'");
            return checkdatacc;
        }
        public int save_group(string _group)
        {
            int i = db.execute("insert into tbl_group (name) values('" + _group + "')");
            return i;
        }
        public int update_group(string groupid, string _group)
        {
            int i = db.execute("update tbl_group set name='" + _group + "' where id='" + groupid + "'");
            return i;
        }
        public DataTable exsists_ptgroup(string name)
        {
            DataTable dt = db.table("select * from tbl_pt_group where group_id='" + name + "'");
            return dt;
        }
        public void delete_group(string groupid)
        {
            db.execute("delete from tbl_group where id='" + groupid + "'");
        }
    }
}
