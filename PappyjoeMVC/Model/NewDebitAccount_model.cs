using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Controller;

namespace PappyjoeMVC.Model
{
    class NewDebitAccount_model
    {
        Connection db = new Connection();
        public DataTable load_ledger()
        {
            DataTable dtb = db.table("select * from tbl_ledger_Group where type='Dr' order by Id");
            return dtb;
        }
        public string AccountName
        {
            get { return txtAccountName; }
            set { txtAccountName = value; }
        }
        public string Ledger
        {
            get { return cmbLedger; }
            set { cmbLedger = value; }
        }
        private string txtAccountName;
        public  DataTable Submit(string txtAccountName)
        {
            DataTable i = db.table("Select * from tbl_expense_type where name ='" + txtAccountName + "' ");
            return i;
        }
        private string cmbLedger;
        public int insert()
        {
            int i = db.execute("insert into tbl_expense_type (name,Group_Name,Expense_type) values('" + txtAccountName + "','" + cmbLedger + "','Dr')");
            return i;
        }
    }
}
