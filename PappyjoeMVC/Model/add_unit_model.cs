using System.Data;

namespace PappyjoeMVC.Model
{
    public class Add_Unit_model
    {
        Connection db = new Connection();
        public DataTable Load_Data()
        {
            DataTable dtb = db.table("select * from tbl_unit order by id");
            return dtb;
        }
        public int save(string _unit)
        {
            int i = db.execute("insert into tbl_unit (name) values('" + _unit + "')");
            return i;
        }
        public int update(string unit_id,string _unit)
        {
            int j = db.execute("update tbl_unit set name='" + _unit + "' where id='" + unit_id + "' ");
            return j;
        }
        public int delete(string unit_id)
        {
            int i = db.execute("delete from tbl_unit where id='" + unit_id + "'");
            return i;
        }
    }
}
