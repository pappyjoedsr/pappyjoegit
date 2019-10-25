using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class New_Credit_Account_controller
    {
        NewAccount_model _model = new NewAccount_model();
        public DataTable load_credit_combo()
        {
            DataTable dtb = _model.load_credit_combo();
            return dtb;
        }
        public DataTable Submit(string _accountname)
        {
            DataTable str = _model.Submit(_accountname);
            return str;
        } 

        public int submit_data(string _accountname, string _ledger)
        {
            int i = _model.submit_data(_accountname, _ledger);
            return i;
        } 
    }
}