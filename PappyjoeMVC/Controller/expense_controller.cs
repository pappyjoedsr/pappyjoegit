using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
    public class expense_controller
    {
        Connection db = new Connection();
        expense_interface intr;
        expense_model _model = new expense_model();
        public expense_controller(expense_interface inttr)
        {
            intr = inttr;
            intr.setcontroller(this);
        }
        public DataTable load_accountname()
        {
            DataTable dtb = _model.load_accountname();
            return dtb;
        }
        public void Fillgrid()
        {
            DataTable dtb = _model.Fill_dgv_credit();
            intr.Fill_dgv_credit(dtb);
        }
        public int submit_credit()
        {
            _model.date = intr.date;
            _model.expense = intr.expense;
            _model.description = intr.description;
            _model.amount_income = intr.amount_income;
            _model.name = intr.name;
            int i = _model.submit_credit();
            return i;
        }
        public int submit_debit()
        {
            _model.debit_date = intr.debit_date;
            _model.debit_description = intr.debit_description;
            _model.debit_ledger = intr.debit_ledger;
            _model.debit_amount = intr.debit_amount;
            _model.debit_accname = intr.debit_accname;
            int i = _model.submit_debit();
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
        public void fill_dgv_debit()
        {
            DataTable dtb = _model.fill_dgv_debit();
            intr.fill_dgv_debit(dtb);
        }
        public int update_dgv_credit(int Incom_ID)
        {
            _model.date = intr.date;
            _model.expense = intr.expense;
            _model.description = intr.description;
            _model.amount_income = intr.amount_income;
            _model.name = intr.name;
            int i = _model.Update_dgv_credit(Incom_ID);
            return i;
        }
        public int update_dgv_debit(int rowindex)
        {
            _model.debit_date = intr.debit_date;
            _model.debit_description = intr.debit_description;
            _model.debit_ledger = intr.debit_ledger;
            _model.debit_amount = intr.debit_amount;
            _model.debit_accname = intr.debit_accname;
            int i = _model.Update_dgv_debit(rowindex);
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
        public void expense_search(string account, string type, string date1, string date2)
        {
            DataTable dtb = _model.expense_search(account, type, date1, date2);
            intr.fill_search(dtb);
        }
        public void expense_search2(string type, string date1, string date2)
        {
            DataTable dtb = _model.expense_search2(type, date1, date2);
            intr.fill_search(dtb);
        }
        public void expense_search3(string account, string date1, string date2)
        {
            DataTable dtb = _model.expense_search3(account, date1, date2);
            intr.fill_search2(dtb);
        }
        public void expense_search4(string date1, string date2)
        {
            DataTable dtb = _model.expense_search4(date1, date2);
            intr.fill_search2(dtb);
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
