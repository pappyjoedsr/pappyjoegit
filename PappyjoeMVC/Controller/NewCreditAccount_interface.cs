using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
    public interface NewCreditAccount_interface
    {
        string AccountName { get; set; }
        string Ledger { get; set; }
        void SetController(NewCreditAccount_controller controller);
    }
}
