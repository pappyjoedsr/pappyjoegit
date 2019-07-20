using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
    public class NewDebitAccount_controller
    {
        NewDebitAccount_interface intr;
        NewDebitAccount_model _model = new NewDebitAccount_model();
        public NewDebitAccount_controller(NewDebitAccount_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
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
        public int insert()
        {
            _model.AccountName = intr.AccountName;
            _model.Ledger = intr.Ledger;
            int i = _model.insert();
            return i;
        }
    }
}
