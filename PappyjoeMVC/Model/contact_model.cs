using System.Data;

namespace PappyjoeMVC.Model
{
    public class Contact_model
    {
        Connection db = new Connection();
        public int Save_data(string _contactname,string _mobno,string _notes)
        {
            int i = db.execute("insert into tbl_contacts (contact,Mobile_no,Notes) values('" + _contactname + "','"+_mobno+"','"+_notes+"')");
            return i;
        }
        public DataTable FillGrid()
        {
            DataTable dtb = db.table("select * from tbl_contacts order by id");
            return dtb;
        }
        public int Update_data(string id, string _contactname,string _mobno,string _notes)
        {
            int i = db.execute("update tbl_contacts  set contact='" + _contactname + "',Mobile_no='"+_mobno+"',Notes='"+_notes+"' where id='" + id + "'");
            return i;
        }
        public int Delete_data(string id)
        {
            int i = db.execute("delete from tbl_contacts  where id='" + id + "'");
            return i;
        }
        public DataTable search(string name)
        {
            DataTable dt = db.table("select * from tbl_contacts where contact like '%" + name + "%'"); ;
            return dt;
        }
    }
}
