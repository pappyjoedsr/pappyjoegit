using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Monthly_Expense_controller
    {
        Expense_Report_model model = new Expense_Report_model();
        Common_model cmodel = new Common_model();
        public DataTable Expense_type_data()
        {
            DataTable dt = model.Expense_type_data();
            return dt;
        }
        public DataTable Expense_data(string AccountName, string Type, string date1, string date2)
        {
            DataTable dt = model.Expense_data( AccountName,  Type,  date1,  date2);
            return dt;
        }
        public DataTable MonthlyExpanse(string d1, string d2, string Accname, string type)
        {
            DataTable dt = model.MonthlyExpanse( d1,  d2,  Accname,  type);
            return dt;
        }
        public DataTable expense_by_type(string Type, string date1, string date2)
        {
            DataTable dt = model.expense_by_type( Type,  date1,  date2);
            return dt;
        }
        public DataTable MonthlyExpanseType(string d1, string d2, string type)
        {
            DataTable dt = model.MonthlyExpanseType(d1,d2,type);
            return dt;
        }
        public DataTable Expense_by_Accountname(string AccountName, string date1, string date2)
        {
            DataTable dt = model.Expense_by_Accountname( AccountName,  date1,  date2);
            return dt;
        }
        public DataTable MonthlyExpanseAccount(string d1, string d2, string Accname)
        {
            DataTable dt = model.MonthlyExpanseAccount( d1,  d2,  Accname);
            return dt;
        }
        public DataTable Expense_by_date(string date1, string date2)
        {
            DataTable dt = model.Expense_by_date( date1,  date2);
            return dt;
        }
        public DataTable MonthlyExpanseLoad(string d1, string d2)
        {
            DataTable dt = model.MonthlyExpanseLoad(d1,d2);
            return dt;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable dt = cmodel.Get_practiceDlNumber();
            return dt;
        }
    }
}
