using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Expense_Daily_Report_controller
    {
        Expense_Report_model mdl = new Expense_Report_model();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
        public DataTable getdctrdtls()
        {
            DataTable dt = mdl.getdctrdtls();
            return dt;
        }
        public DataTable dailyexpense(string exptype, string type, string date1, string date2)
        {
            DataTable dt = mdl.dailyexpense(exptype,type,date1,date2);
            return dt;
        }
        public DataTable dailyexpense2(string type, string date1, string date2)
        {
            DataTable dt = mdl.dailyexpense2(type, date1, date2);
            return dt;
        }
        public DataTable dailyexpense3(string exptype, string date1, string date2)
        {
            DataTable dt = mdl.dailyexpense3(exptype, date1, date2);
            return dt;
        }
        public DataTable dailyexpense4(string date1, string date2)
        {
            DataTable dt = mdl.dailyexpense4(date1, date2);
            return dt;
        }
        public DataTable DailyExpanseLoad(string d1, string d2)
        {
            DataTable query = mdl.DailyExpanseLoad(d1, d2); 
            return query;
        }
        public DataTable DailyExpanseType(string d1, string d2, string type)
        {
            DataTable query = mdl.DailyExpanseType(d1, d2,type);
            return query;
        }
        public DataTable DailyExpanseAccount(string d1, string d2, string Accname)
        {
            DataTable query = mdl.DailyExpanseAccount(d1, d2,Accname); 
            return query;
        }
        public DataTable DailyExpanse(string d1, string d2, string Accname, string type)
        {
            DataTable query = mdl.DailyExpanse(d1, d2,Accname,type);
            return query;
        }
        public DataTable practicedetails()
        {
            DataTable dt = dm.practicedetails();
            return dt;
        }
    }
}
