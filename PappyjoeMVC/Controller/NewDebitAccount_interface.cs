using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public interface NewDebitAccount_interface
    {
        string AccountName { get; set; }
        string Ledger { get; set; }
        void SetController(NewDebitAccount_controller controller);
    }
}
