using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.View;
using PappyjoeMVC.Controller;
using System.Data;

namespace PappyjoeMVC.Model
{
    public class contact_model
    {
        Connection db = new Connection();
        private string _contactname;
        public string ContactName
        {
            get { return _contactname; }
            set { _contactname = value; }
        }

        public int Save_data()
        {
           int i = db.execute("insert into tbl_contacts (contact) values('" + _contactname + "')");
            return i;
        }

        public DataTable FillGrid()
        {
            DataTable dtb = db.table("select * from tbl_contacts order by id");
            return dtb;
        }
        public int Update_data(string id)
        {
            int i = db.execute("update tbl_contacts  set contact='" + _contactname + "' where id='"+id+"'");
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
