using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
    public class NewCreditAccount_controller
    {
        NewCreditAccount_interface intr;
        NewAccount_model _model = new NewAccount_model();
        
        public NewCreditAccount_controller(NewCreditAccount_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
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

        public int submit_data()
        {
            _model.AccountName = intr.AccountName;
            _model.Ledger = intr.Ledger;
            int i = _model.submit_data();
            return i;
        }
    }
}
