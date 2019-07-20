using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Controller;
using PappyjoeMVC.View;
namespace PappyjoeMVC.Model
{
  public  class expense_model
    {
        Connection db = new Connection();
        private string comboBoxincomacc;
        private string datevisitedincome;
        private string textBoxdescincome;
        private string textBoxnameofincome;
        private string txtamountincome;
        public string AccountName
        {
            get { return comboBoxincomacc; }
            set { comboBoxincomacc = value; }
        }
        public string date
        {
            get { return datevisitedincome; }
            set { datevisitedincome = value; }
        }
        public string expense
        {
            get { return comboBoxincomacc; }
            set { comboBoxincomacc = value; }
        }
        public string description
        {
            get { return textBoxdescincome; }
            set { textBoxdescincome = value; }
        }
        public string name
        {
            get { return textBoxnameofincome; }
            set { textBoxnameofincome = value; }
        }
        public string amount_income
        {
            get { return txtamountincome; }
            set { txtamountincome = value; }
        }
        private string comboaccountname;
        public string ledger
        {
            get { return textBoxnameofincome; }
            set { textBoxnameofincome = value; }
        }
        private string datevisited; 
        public string debit_date
        {
            get { return datevisited; }
            set { datevisited = value; }
        }
        private string textBox_add_template;
        public string debit_description
        {
            get { return textBox_add_template; }
            set { textBox_add_template = value; }
        }
        private string textamount;
        public string debit_amount
        {
            get { return textamount; }
            set { textamount = value; }
        }
        private string textperson;
        public string debit_ledger
        {
            get { return textperson; }
            set { textperson = value; }
        }
        public string debit_accname
        {
            get { return comboaccountname; }
            set { comboaccountname = value; }
        }
        private string _accounthead = "";
        public string Accounthead
        {
            get { return _accounthead; }
            set { _accounthead = value; }
        }
        public DataTable load_accountname()
        {
            DataTable dtb=db.table("select * from tbl_expense_type where Expense_type='Cr'");
            return dtb;
        }
        public DataTable Fill_dgv_credit()
        {
            DataTable dtb = db.table("select id,expense_type,description,nameofperson,amountincome, date from tbl_expense where Type='Income' order by id");
            return dtb;
        }
        public int submit_credit()
        {
            int i = db.execute("insert into tbl_expense(date,expense_type,description,amount,nameofperson,Type,amountincome)values('" + Convert.ToDateTime(datevisitedincome).ToString("yyyy/MM/dd") + "','" + comboBoxincomacc + "','" + textBoxdescincome + "','0','" + textBoxnameofincome + "','Income','" + txtamountincome + "')");
            return i;
        }
        public DataTable show_ledger(string comboBoxincomacc)
        {
            DataTable dtb = db.table("select name,Group_Name from tbl_expense_type where name='" + comboBoxincomacc + "' and expense_type='Cr'");
            return dtb;
        }
        public int dgv_credit_delete(int Incom_ID)
        {
            int i = db.execute("delete from tbl_expense where id='" + Incom_ID + "'");
            return i;
        }
        public DataTable debit_accountname()
        {
            DataTable dt = db.table("select * from tbl_expense_type where Expense_type='Dr'");
            return dt;
        }
        public DataTable debit_loadledger(string comboaccountname)
        {
            DataTable dtb = db.table("select name,Group_Name from tbl_expense_type where name='" + comboaccountname + "' and expense_type='Dr'");
            return dtb;
        }
        public int submit_debit()
        {
            int i = db.execute("insert into tbl_expense(date,expense_type,description,amount,nameofperson,Type,amountincome)values('" + Convert.ToDateTime(datevisited).ToString("yyyy/MM/dd") + "','" + comboaccountname + "','" + textBox_add_template + "','" + textamount + "','" + textperson + "','Expense','0')");
            return i;
        }
        public DataTable fill_dgv_debit()
        {
            DataTable dtb = db.table("select id,expense_type,description,amount,nameofperson,date from tbl_expense where Type='Expense' order by id");
            return dtb;
        }
        public int Update_dgv_credit(int Incom_ID)
        {
            int i = db.execute("update tbl_expense set date='" + Convert.ToDateTime(datevisitedincome).ToString("yyyy/MM/dd") + "',expense_type='" + comboBoxincomacc + "',description='" + textBoxdescincome + "',amountincome='" + txtamountincome + "',nameofperson='" + textBoxnameofincome + "',Type='Income',amount='0' where id='" + Incom_ID + "'");
            return i;
        }
        public int Update_dgv_debit(int rowindex)
        {
            int i=db.execute("update tbl_expense set date='" + Convert.ToDateTime(datevisited).ToString("yyyy/MM/dd") + "',expense_type='" + comboaccountname + "',description='" + textBox_add_template + "',amount='" + textamount + "',nameofperson='" + textperson + "',Type='Expense',amountincome='0' where id='" + rowindex + "'");
            return i;
        }
        public int dgv_debit_delete(int rowindex)
        {
            int i = db.execute("delete from tbl_expense where id='" + rowindex + "'");
            return i;
        }
        public DataTable check_type_creditselect()
        {
            DataTable dtb = db.table("select * from tbl_expense_type where Expense_type='Cr'");
            return dtb;
        }
        public DataTable check_type_exp1()
        {
            DataTable dt = db.table("select * from tbl_expense_type");
            return dt;
        }
        public DataTable check_type_exp2()
        {
            DataTable d = db.table("select * from tbl_expense_type");
            return d;
        }
        public DataTable expense_checked()
        {
            DataTable d = db.table("select * from tbl_expense_type where Expense_type='Dr'");
            return d;
        }
        public DataTable expense_search(string account,string type,string date1,string date2)
        {
            DataTable dt_templates = db.table("select id,date,Type,nameofperson,expense_type,amount+amountincome as amountbind,amount,description,amountincome from tbl_expense where expense_type like '%" + account + "%' and Type='" + type + "' and date between '" + date1 + "' and '" +date2 + "' ");///aswini
            return dt_templates;
        }
        public DataTable expense_search2(string type,string date1,string date2)
        {
            DataTable dt_templates = db.table("select id,date,Type,nameofperson,expense_type,amount+amountincome as amountbind,amount,description,amountincome from tbl_expense where Type='" + type + "' and date between '" + date1 + "' and '" + date2 + "' "); ///aswini
            return dt_templates;
        }
        public DataTable expense_search3(string account,string date1,string date2)
        {
            DataTable dt_templates = db.table("select id,date,Type,nameofperson,expense_type,amount+amountincome as amountbind,amount,description,amountincome from tbl_expense where expense_type like '%" + account + "%' and date between '" + date1 + "' and '" + date2 + "' "); ///aswini
            return dt_templates;
        }
        public DataTable expense_search4(string date1,string date2)
        {
            DataTable dt_templates = db.table("select id,date,Type,nameofperson,expense_type,amount+amountincome as amountbind,amount,description,amountincome from tbl_expense where date between '" + date1 + "' and '" + date2 + "' "); ///aswini
            return dt_templates;
        }
        public DataTable print()
        {
            DataTable dtp = db.table("select name,contact_no,street_address from tbl_practice_details");
            return dtp;
        }
        public DataTable Bindcomboincome()
        {
            DataTable dt = db.table("select id,name from tbl_expense_type where Expense_type='Cr'");
            return dt;
        }
        public DataTable databindcombo()
        {
            DataTable dt = db.table("select id,name from tbl_expense_type where Expense_type='Dr'");
            return dt;
        }
        public DataTable databindcombo2()
        {
            DataTable dt = db.table("select distinct id,name from tbl_expense_type");
            return dt;
        }
    }
}
