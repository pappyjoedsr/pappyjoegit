using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
   public class Expense_Report_model
    {
        Connection db = new Connection();
        //expense category wise
        public DataTable load_type()
        {
           DataTable dtb = db.table("select distinct id,name from tbl_expense_type order by id");
            return dtb;
        }
        public DataTable load_ledger()
        {
          DataTable Ledger = db.table("select distinct id,Group_Name from tbl_ledger_Group order by id ");
          return Ledger;
        }
        public DataTable Load_details_wit_all(string AccountName,string LedgerName, string date1, string date2)
        {
            DataTable dtb = db.table("select date ,Type,nameofperson,expense_type,cast(amount as decimal(17,2))amount ,cast(amountincome as decimal(17,2))amountincome,description from tbl_expense where expense_type='" + AccountName + "' and nameofperson='" + LedgerName + "' and date between '" + date1 + "' and '" + date2 + "' ");
            return dtb;
        }
        public DataTable ExpanseCategory_Ledger_Account(string d1, string d2, string AccountName, string LedgerName)
        {
            DataTable  query =db.table( "select  nameofperson AS 'LEDGER', COUNT(tbl_expense.id) AS 'EXPENSE' from tbl_expense  where  expense_type='" + AccountName + "' and nameofperson='" + LedgerName + "' and  date between '" + d1 + "' and '" + d2 + "'  group by  nameofperson");
            return query;
        }
        public DataTable load_category_wit_date(string date1, string date2)
        {
            DataTable dtb = db.table("select  date ,Type,nameofperson,expense_type,cast(amount as decimal(17,2))amount ,cast(amountincome as decimal(17,2))amountincome,description from tbl_expense where  date between '" + date1 + "' and '" + date2 + "' ");
            return dtb;
        }
        public DataTable ExpanseCategoryLoad(string d1, string d2)
        {
            DataTable query =db.table(" SELECT  nameofperson AS 'LEDGER', COUNT(tbl_expense.id) AS 'EXPENSE' FROM  tbl_expense  where  date between '" + d1 + "' and '" + d2 + "' group by nameofperson");
            return query;
        }
        public DataTable load_category_wit_account_date (string AccountName, string date1, string date2)
        {
            DataTable dtb = db.table("select  date ,Type,nameofperson,expense_type,cast(amount as decimal(17,2))amount ,cast(amountincome as decimal(17,2))amountincome,description from tbl_expense where expense_type='" + AccountName + "' and  date between '" + date1 + "' and '" + date2 + "' ");
            return dtb;
        }
        public DataTable ExpanseCategory_Account(string d1, string d2, string AccountName)
        {
            DataTable query =db.table("select  nameofperson AS LEDGER, COUNT(tbl_expense.id) AS EXPENSE from tbl_expense  where  expense_type='" + AccountName + "'  and  date between '" + d1 + "' and '" + d2 + "'  group by nameofperson ");
            return query;
        }
        public DataTable expensecategory_ledger_date(string date1, string date2, string LedgerName)
        {
            DataTable dtb = db.table("select date ,Type,nameofperson,expense_type,cast(amount as decimal(17,2))amount ,cast(amountincome as decimal(17,2))amountincome,description from tbl_expense where nameofperson='" + LedgerName + "'  and  date between '" + date1 + "' and '" + date2 + "' ");
            return dtb;
        }
        public DataTable ExpanseCategory_Ledger(string d1, string d2, string LedgerName)
        {
            DataTable query =db.table("select  nameofperson AS LEDGER, COUNT(tbl_expense.id) AS EXPENSE from tbl_expense  where  nameofperson='" + LedgerName + "' and  date between '" + d1 + "' and '" + d2 + "'  group by  nameofperson");
            return query;
        }
        public DataTable load_practicedetails()
        {
            DataTable dtp = db.table("select name,contact_no,street_address,email,website from tbl_practice_details");
            return dtp;
        }
    public class Expense_Report_model
    {
        Connection db = new Connection();
        public DataTable Expense_type_data()
        {
            System.Data.DataTable doctor_rs = db.table("select distinct id,name from tbl_expense_type");
            return doctor_rs;
        }
        public DataTable Expense_data(string AccountName,string Type,string date1,string date2)
        {
            DataTable dtb = db.table("select  date,Type,nameofperson,expense_type,amount,amountincome,description from tbl_expense where expense_type='" + AccountName + "' and Type='" + Type + "' and date between '" + date1 + "' and '" + date2 + "' ");
            return dtb;
        }
        public DataTable MonthlyExpanse(string d1, string d2, string Accname, string type)
        {
            DataTable dfd = db.table("select date_format(date,'%b %Y') AS 'MONTH', COUNT(*) AS 'EXPENSE' from tbl_expense where Type='" + type + "' and  expense_type='" + Accname + "'  and date between '" + d1 + "' and '" + d2 + "' GROUP BY date_format(date,'%b %Y')");
            return dfd;
        }
        public DataTable expense_by_type(string Type,string date1,string date2)
        {
            DataTable dtb = db.table("select  date,Type,nameofperson,expense_type,amount,amountincome,description from tbl_expense where  Type='" + Type + "' and date between '" + date1 + "' and '" + date2 + "' ");
            return dtb;
        }
        public DataTable MonthlyExpanseType(string d1, string d2, string type)
        {
            DataTable  dfd = db.table("select date_format(date,'%b %Y') AS 'MONTH', COUNT(*) AS 'EXPENSE' from tbl_expense where Type='" + type + "' and date between '" + d1 + "' and '" + d2 + "' GROUP BY date_format(date,'%b %Y')");
            return dfd;
        }
        public DataTable Expense_by_Accountname(string AccountName,string date1,string date2)
        {
            DataTable dtb = db.table("select date,Type,nameofperson,expense_type,amount,amountincome,description from tbl_expense where  expense_type='" + AccountName + "' and date between '" + date1 + "' and '" + date2 + "' ");
            return dtb;
        }
        public DataTable MonthlyExpanseAccount(string d1, string d2, string Accname)
        {
            DataTable dfd = db.table("select date_format(date,'%b %Y') AS 'MONTH', COUNT(*) AS 'EXPENSE' from tbl_expense where expense_type='" + Accname + "'  and date between '" + d1 + "' and '" + d2 + "' GROUP BY date_format(date,'%b %Y')");
            return dfd;
        }
        public DataTable Expense_by_date(string date1,string date2)
        {
            DataTable dtb = db.table("select date,Type,nameofperson,expense_type,amount,amountincome,description from tbl_expense where  date between '" + date1 + "' and '" + date2 + "' ");
            return dtb;
        }
        public DataTable MonthlyExpanseLoad(string d1, string d2)
        {
            DataTable dfd = db.table("select date_format(date,'%b %Y') AS 'MONTH', COUNT(*) AS 'EXPENSE' from tbl_expense where date between '" + d1 + "' and '" + d2 + "' GROUP BY date_format(date,'%b %Y') ");
            return dfd;
        }
    }
}
