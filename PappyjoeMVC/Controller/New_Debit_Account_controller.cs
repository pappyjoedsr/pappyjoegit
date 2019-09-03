using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class New_Debit_Account_controller
    {
        NewDebitAccount_model _model = new NewDebitAccount_model();
        public DataTable load_ledger()
        {
            DataTable dtb = _model.load_ledger();
            return dtb;
        }
        public DataTable Submit(string txtAccountName)
        {
            DataTable dtb = _model.Submit(txtAccountName);
            return dtb;
        }
        public int insert(string txtAccountName, string cmbLedge)
        {
            int i = _model.insert(txtAccountName, cmbLedge);
            return i;
        }
    }
}
