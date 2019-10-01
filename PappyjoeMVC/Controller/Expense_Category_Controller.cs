using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public class Expense_Category_Controller
    {
        Expense_Report_model model = new Expense_Report_model();
        public DataTable load_type()
        {
            DataTable dtb = model.load_type();
            return dtb;
        }
        public DataTable load_ledger()
        {
            DataTable dtb = model.load_ledger();
            return dtb;
        }
        public DataTable Load_details_wit_all(string AccountName, string LedgerName, string date1, string date2)
        {
            DataTable dtb = model.Load_details_wit_all(AccountName, LedgerName, date1, date2);
            return dtb;
        }
        public DataTable ExpanseCategory_Ledger_Account(string d1, string d2, string AccountName, string LedgerName)
        {
            DataTable dtb = model.ExpanseCategory_Ledger_Account(d1, d2, AccountName, LedgerName);
            return dtb;
        }
        public DataTable load_category_wit_date(string date1, string date2)
        {
            DataTable dtb = model.load_category_wit_date(date1, date2);
            return dtb;
        }
        public DataTable ExpanseCategoryLoad(string d1, string d2)
        {
            DataTable dtb = model.ExpanseCategoryLoad(d1,d2);
            return dtb;
        }
        public DataTable load_category_wit_account_date(string AccountName, string date1, string date2)
        {
            DataTable dtb = model.load_category_wit_account_date(AccountName,  date1,  date2);
            return dtb;
        }
        public DataTable ExpanseCategory_Account(string d1, string d2, string AccountName)
        {
            DataTable dtb = model.ExpanseCategory_Account(d1, d2, AccountName);
            return dtb;
        }
        public DataTable expensecategory_ledger_date(string date1, string date2, string LedgerName)
        {
            DataTable dtb = model.expensecategory_ledger_date(date1, date2, LedgerName);
            return dtb;
        }
        public DataTable ExpanseCategory_Ledger(string d1, string d2, string LedgerName)
        {
            DataTable dtb = model.ExpanseCategory_Ledger(d1, d2, LedgerName);
            return dtb;
        }
        public DataTable load_practicedetails()
        {
            DataTable dtb = model.load_practicedetails();
            return dtb;
        }
    }
}
