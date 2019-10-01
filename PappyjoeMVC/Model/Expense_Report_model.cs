using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class Expense_Report_model
    {
        Connection db = new Connection();
        //Expense Daily Report                                                                                                                                                                                                                                                                                       
        public DataTable getdctrdtls()
        {
            DataTable dt = db.table("select distinct id,name from tbl_expense_type");
            return dt;
        }
        public DataTable dailyexpense(string exptype,string type,string date1,string date2)
        {
            DataTable dt = db.table("select date,Type,nameofperson,expense_type,cast(amount as decimal(17,2)) as amount,cast(amountincome as decimal(17,2)) as amountincome ,description from tbl_expense where expense_type='" + exptype + "' and Type='" + type + "' and date between '" + date1 + "' and '" + date2 + "' ");
            return dt;
        }
        public DataTable dailyexpense2(string type, string date1, string date2)
        {
            DataTable dt = db.table("select  date,Type,nameofperson,expense_type,cast(amount as decimal(17,2)) as amount,cast(amountincome as decimal(17,2)) as amountincome ,description from tbl_expense where  Type='" + type + "' and date between '" + date1 + "' and '" + date2 + "' ");
            return dt;
        }
        public DataTable dailyexpense3(string exptype, string date1, string date2)
        {
            DataTable dt = db.table("select  date,Type,nameofperson,expense_type,cast(amount as decimal(17,2)) as amount,cast(amountincome as decimal(17,2)) as amountincome ,description from tbl_expense where  expense_type='" + exptype + "' and date between '" + date1 + "' and '" + date2 + "' ");
            return dt;
        }
        public DataTable dailyexpense4(string date1, string date2)
        {
            DataTable dt = db.table("select  date,Type,nameofperson,expense_type,cast(amount as decimal(17,2)) as amount,cast(amountincome as decimal(17,2)) as amountincome ,description from tbl_expense where  date between '" + date1 + "' and '" + date2 + "' ");
            return dt;
        }
        public DataTable DailyExpanseLoad(string d1, string d2)
        {
            DataTable query = db.table("select  date_format(date,'%a %Y') AS DAY,COUNT(*) AS 'EXPENSE' from tbl_expense  where  date between '" + d1 + "' and '" + d2 + "' group by  date_format(date,'%a %Y')");
            return query;
        }
        public DataTable DailyExpanseType(string d1, string d2, string type)
        {
            DataTable query = db.table("select  date_format(date,'%a %Y') AS DAY,COUNT(*) AS 'EXPENSE' from tbl_expense  where Type='" + type + "' and  date between '" + d1 + "' and '" + d2 + "' group by date_format(date,'%a %Y')");
            return query;
        }
        public DataTable DailyExpanseAccount(string d1, string d2, string Accname)
        {
            DataTable query = db.table("select date_format(date,'%a %Y') AS DAY,COUNT(*) AS 'EXPENSE' from tbl_expense  where expense_type='" + Accname + "' and  date between '" + d1 + "' and '" + d2 + "' group by   date_format(date,'%a %Y')");
            return query;
        }
        public DataTable DailyExpanse(string d1, string d2, string Accname, string type)
        {
            DataTable query = db.table("select  date_format(date,'%a %Y')  AS DAY,COUNT(*) AS 'EXPENSE' from tbl_expense  where Type='" + type + "' and expense_type='" + Accname + "' and date between '" + d1 + "' and '" + d2 + "' group by  date_format(date,'%a %Y')");
            return query;
        }//
    }
}
