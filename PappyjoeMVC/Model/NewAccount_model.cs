using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
    public class NewAccount_model
    {
        Connection db = new Connection();
        private string _accountname;
        private string _ledger;
        public DataTable load_credit_combo()
        {
            DataTable dt1 = db.table("select * from tbl_ledger_Group where type='Cr' order by Id");
            return dt1;
        }
        public string AccountName
        { 
            get { return _accountname; }
            set { _accountname = value; }
        }
        public string Ledger
        {
            get { return _ledger; }
            set { _ledger = value; }
        }
        public DataTable Submit(string _accountname)
        {
            DataTable i = db.table("Select * from tbl_expense_type where name ='" + _accountname + "' ");
            return i;
        }
        public int submit_data()
        {
            int i = db.execute("insert into tbl_expense_type (name,Group_Name,Expense_type) values('" + _accountname + "','" + _ledger + "','Cr')");
            return i;
        }
    }
}
