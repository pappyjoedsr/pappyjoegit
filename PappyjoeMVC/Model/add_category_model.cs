using System.Data;
namespace PappyjoeMVC.Model
{
    public class Add_Category_model
    {
        Connection db = new Connection();
        private string _number = "";
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }
        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _description = "";
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
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
        public void save()
        {
            db.execute("insert into tbl_Category (Name,Cat_Number,Description) values('" + _name + "','" + _number + "','" + _description + "')");
        }
        public void update(string Id)
        {
            db.execute("update tbl_Category set Name='" + _name + "',Cat_Number='" + _number + "',Description='" + _description + "' where id='" + Id + "'");
        }
    }
}