using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Expense_controller
    {
        Expense_model _model = new Expense_model();
        public DataTable load_accountname()
        {
            DataTable dtb = _model.load_accountname();
            return dtb;
        }
        public DataTable Fillgrid()
        {
            DataTable dtb = _model.Fill_dgv_credit();
            return dtb;
        }
        public int submit_credit(string datevisitedincome, string comboBoxincomacc, string textBoxdescincome, string textBoxnameofincome, string txtamountincome)
        {
            int i = _model.submit_credit(datevisitedincome, comboBoxincomacc, textBoxdescincome, textBoxnameofincome, txtamountincome);
            return i;
        }
        public int submit_debit(string datevisited, string comboaccountname, string textBox_add_template, string textamount, string textperson)
        {
            int i = _model.submit_debit(datevisited, comboaccountname, textBox_add_template, textamount, textperson);
            return i;
        }
        public DataTable show_ledger(string comboBoxincomacc)
        {
            DataTable dtb = _model.show_ledger(comboBoxincomacc);
            return dtb;
        }
        public int dgv_credit_delete(int Incom_ID)
        {
            int i = _model.dgv_credit_delete(Incom_ID);
            return i;
        }
        public DataTable debit_accountname()
        {
            DataTable dtb = _model.debit_accountname();
            return dtb;
        }
        public DataTable debit_ledgerload(string comboaccountname)
        {
            DataTable dtb = _model.debit_loadledger(comboaccountname);
            return dtb;
        }
        public DataTable fill_dgv_debit()
        {
            DataTable dtb = _model.fill_dgv_debit();
            return dtb;
            //intr.fill_dgv_debit(dtb);
        }
        public int update_dgv_credit(int Incom_ID, string datevisitedincome, string comboBoxincomacc, string textBoxdescincome, string txtamountincome, string textBoxnameofincome)
        {
            int i = _model.Update_dgv_credit(Incom_ID, datevisitedincome, comboBoxincomacc, textBoxdescincome, txtamountincome, textBoxnameofincome);
            return i;
        }
        public int update_dgv_debit(int rowindex, string datevisited, string comboaccountname, string textBox_add_template, string textamount, string textperson)
        {
            int i = _model.Update_dgv_debit(rowindex, datevisited, comboaccountname, textBox_add_template, textamount, textperson);
            return i;
        }
        public int dgv_debit_delete(int rowindex)
        {
            int i = _model.dgv_debit_delete(rowindex);
            return i;
        }
        public DataTable check_type_creditselect()
        {
            DataTable dt = _model.check_type_creditselect();
            return dt;
        }
        public DataTable check_type_exp1()
        {
            DataTable d = _model.check_type_exp1();
            return d;
        }
        public DataTable check_type_exp2()
        {
            DataTable d = _model.check_type_exp2();
            return d;
        }
        public DataTable expense_checked()
        {
            DataTable dt = _model.expense_checked();
            return dt;
        }
        public DataTable expense_search(string account, string type, string date1, string date2)
        {
            DataTable dtb = _model.expense_search(account, type, date1, date2);
            return dtb;
        }
        public DataTable expense_search2(string type, string date1, string date2)
        {
            DataTable dtb = _model.expense_search2(type, date1, date2);
            return dtb;
        }
        public DataTable expense_search3(string account, string date1, string date2)
        {
            DataTable dtb = _model.expense_search3(account, date1, date2);
            return dtb;
        }
        public DataTable expense_search4(string date1, string date2)
        {
            DataTable dtb = _model.expense_search4(date1, date2);
            return dtb;
        }
        public DataTable print()
        {
            DataTable dtb = _model.print();
            return dtb;
        }
        public DataTable Bindcomboincome()
        {
            DataTable dtb = _model.Bindcomboincome();
            return dtb;
        }
        public DataTable databindcombo()
        {
            DataTable dtb = _model.databindcombo();
            return dtb;
        }
        public DataTable databindcombo2()
        {
            DataTable dtb = _model.databindcombo2();
            return dtb;
        }
    }
}
