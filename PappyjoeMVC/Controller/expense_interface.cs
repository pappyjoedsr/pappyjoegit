using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface expense_interface
    {
        string AccountName { get; set; }
        string date { get; set; }
        string expense { get; set; }
        string description { get; set; }
        string name { get; set; }
        string amount_income { get; set; }
        string debit_date { get; set; }
        string debit_description { get; set; }
        string debit_amount { get; set; }
        string debit_ledger { get; set; }
        string debit_accname { get; set; }
        void setcontroller(expense_controller controller);
        void Fill_dgv_credit(DataTable dtb);
        void fill_dgv_debit(DataTable dtb);
        void fill_search(DataTable dtb);
        void fill_search2(DataTable dtb);
    }
}
