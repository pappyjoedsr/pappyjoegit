using System.Data;
namespace PappyjoeMVC.Model
{
    public class Add_Category_model
    {
        Connection db = new Connection();
        public DataTable Load_data()
        {
            DataTable dt = db.table("select * from tbl_Category");
            return dt;
        }
        public DataTable get_details(string Id)
        {
            DataTable dt = db.table("select * from tbl_Category where id='" + Id + "'");
            return dt;
        }
        public int delete(string id)
        {
            int i = db.execute("delete from tbl_Category where id='" + id + "'");
            return i;
        }
        public DataTable Get_catdetails(string name, string number)
        {
            DataTable dt = db.table("select Name,Cat_Number from tbl_Category where Name='" + name + "' and Cat_Number='" + number + "'");
            return dt;
        }
        public void save(string Name, string Cat_Number, string Description)
        {
            db.execute("insert into tbl_Category (Name,Cat_Number,Description) values('" + Name + "','" + Cat_Number + "','" + Description + "')");
        }
        public void update(string Name, string Cat_Number, string Description,string Id)
        {
            db.execute("update tbl_Category set Name='" + Name + "',Cat_Number='" + Cat_Number + "',Description='" + Description + "' where id='" + Id + "'");
        }
    }
}