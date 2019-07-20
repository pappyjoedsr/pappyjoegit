using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
   public class procedure_catalog_model
    {
        Connection db = new Connection();
        private string _procName = "";
        public string ProcedureName
        {
            get { return _procName; }
            set { _procName = value; }
        }
        private string _procost = "";
        public string ProcedCost
        {
            get { return _procost; }
            set { _procost = value; }
        }
        private string _notes = "";
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }
        private string _comboCategory= "";
        public string ComboCategory
        {
            get { return _comboCategory; }
            set { _comboCategory = value; }
        }
        private string _textCategory = "";
        public string TextCategory
        {
            get { return _textCategory; }
            set { _textCategory = value; }
        }
        public DataTable FormLoad()
        {
            DataTable dt = db.table(" select A.id,A.name,A.cost,A.category,A.notes,T.tax_name from tbl_addproceduresettings A left join tbl_proceduretax  P ON P.procedure_id = A.id left join tbl_tax T on T.id= P.tax_id ORDER BY A.id Desc");
            return dt;
        }
        public DataTable get_procedure_category_value ()
        {
            DataTable dt = db.table("select * from tbl_procedure_category");
            return dt;
        }
        public DataTable Get_category_name()
        {
            DataTable dt = db.table("select * from tbl_procedure_category where name='" + TextCategory + "'");
            return dt;
        }
        public void save()
        {
            db.execute("insert into tbl_procedure_category (name) values('" + TextCategory + "')");
        }
        public DataTable get_procedureName ()
        {
            DataTable checkdatacc = db.table("Select id,name from tbl_addproceduresettings where name ='" + _procName + "'");
            return checkdatacc;
        }
        public int save_addprocedure()
        {
            int i = db.execute("insert into tbl_addproceduresettings (name,cost,category,notes) values('" + _procName + "','" + _procost + "','" +_comboCategory + "','" + _notes + "')");
            return i;
        }
        public string Get_GST_id()
        {
            string s = db.scalar("select id from tbl_tax where tax_name= 'GST' ");
            return s;
        }
        public void save_proceduretax(int id1, int pid)
        {
            int j = db.execute("insert into tbl_proceduretax (tax_id,procedure_id) values('" + id1 + "','" + pid + "')");
        }
        public string Get_IGST_id()
        {
            string s = db.scalar("select id from tbl_tax where tax_name= 'IGST'");
            return s;
        }
    }
}
