using System.Data;

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
        public DataTable Submit(string txtAccountName)
        {
            DataTable i = db.table("Select * from tbl_expense_type where name ='" + txtAccountName + "' ");
            return i;
        }
        public int insert(string txtAccountName, string cmbLedger)
        {
            int i = db.execute("insert into tbl_expense_type (name,Group_Name,Expense_type) values('" + txtAccountName + "','" + cmbLedger + "','Dr')");
            return i;
        }
    }
}
