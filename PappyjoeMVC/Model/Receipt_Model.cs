using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
    public class Receipt_Model
    {
        Connection db = new Connection();
        public DataTable receipt_number()
        {
            DataTable receipt = db.table("select receipt_number,receipt_prefix from tbl_receipt_automationid where receipt_automation='Yes'");
            return receipt;
        }
        public DataTable Get_invoice_details(string patient_id)
        {
            DataTable dt1 = db.table("select tbl_invoices_main.invoice,tbl_invoices_main.pt_id,tbl_invoices_main.pt_name,tbl_invoices.services,tbl_invoices_main.date,tbl_invoices.total  from tbl_invoices_main inner join tbl_invoices on tbl_invoices_main.id=tbl_invoices.invoice_main_id where tbl_invoices_main.status='1' and tbl_invoices_main.pt_id='" + patient_id + "' and tbl_invoices.total<>0");
            return dt1;
        }
        public DataTable Patient_invoice(string patient_id, string invoices)
        {
            DataTable dt1 = db.table("select invoice_no,services,pt_id,total,dr_id from tbl_invoices where total!='" + 0 + "' and pt_id='" + patient_id + "' and invoice_no='" + invoices + "'");
            return dt1;
        }
        public DataTable select_invoice(string invoices)
        {
            DataTable dt2 = db.table("select invoice_no,services,total,pt_id from tbl_invoices where invoice_no='" + invoices+ "' and total<>0");
            return dt2;
        }
        public void update_advance(decimal adv,string patient_id)
        {
            db.execute("update tbl_payment set advance='" + adv + "' where pt_id='" + patient_id + "'");
        }
        public void save_advance(decimal adv, string patient_id)
        {
            db.execute("insert into tbl_payment(advance,pt_id) values('" + adv + "','" + patient_id + "')");
        }
        public DataTable Get_All_paymenttbl_details(string ReceiptNo)
        {
            DataTable receipt = db.table("select * from tbl_payment where receipt_no='" + ReceiptNo+ "'");
            return receipt;
        }
        public DataTable  Procedurewisw_receipt_report(string invoice_no, string patient_id, string services)
        {
            DataTable totalinv = db.table("select total_payment,invoice_main_id,total,dr_id,CAST(cost AS DECIMAL(17,1))  * CAST(unit AS DECIMAL(17,1)) AS cost,pt_name from tbl_invoices where invoice_no='" + invoice_no + "' and pt_id='" + patient_id + "' and services='" + services + "'");  
            return totalinv;
        }
        public int updatetotal(decimal total,string invoice_no,string patient_id,string services)
        {
          int i= db.execute("update tbl_invoices set total='" + total + "' where invoice_no='" + invoice_no + "' and pt_id='" + patient_id + "' and services='" + services + "'");
          return i;
        }
        public int save_payment_checkwise (string advance, string receipt_no, decimal  amount_paid, string invoice_no, string procedure_name, string mode_of_payment, string pt_id, string payment_date, string dr_id, string payment_due, string total, string cost,string pt_name, string BankName, string Number)
        {
           int  inv = db.execute("insert into tbl_payment(advance,receipt_no,amount_paid,invoice_no,procedure_name,mode_of_payment,pt_id,payment_date,dr_id,payment_due,total,cost,pt_name,BankName,Number)values('" + advance + "','" + receipt_no + "','" + amount_paid + "','" + invoice_no + "','" + procedure_name + "','" + mode_of_payment + "','" + pt_id + "','" + payment_date + "','" + dr_id + "','" + payment_due + "','" + total + "','" + cost + "','" + pt_name + "','" + BankName + "','" + Number + "')");
           return inv;
        }
        public int save_payment_cardWise(string advance, string receipt_no, decimal amount_paid, string invoice_no, string procedure_name, string mode_of_payment, string pt_id, string payment_date, string dr_id, string payment_due, string total, string cost, string pt_name, string CardNo, string DigitNo)
        {
          int inv = db.execute("insert into tbl_payment(advance,receipt_no,amount_paid,invoice_no,procedure_name,mode_of_payment,pt_id,payment_date,dr_id,payment_due,total,cost,pt_name,CardNo,4DigitNo)values('" + advance + "','" + receipt_no + "','" + amount_paid + "','" + invoice_no + "','" + procedure_name + "','" + mode_of_payment + "','" + pt_id + "','" + payment_date + "','" + dr_id + "','" + payment_due + "','" + total + "','" + cost + "','" + pt_name + "','" + CardNo + "','" + DigitNo + "')");
          return inv;
        }
        public int Save_payment_DD(string advance, string receipt_no, decimal amount_paid, string invoice_no, string procedure_name, string mode_of_payment, string pt_id, string payment_date, string dr_id, string payment_due, string total, string cost, string pt_name, string BankName, string DDNumber)
        {
           int inv = db.execute("insert into tbl_payment(advance,receipt_no,amount_paid,invoice_no,procedure_name,mode_of_payment,pt_id,payment_date,dr_id,payment_due,total,cost,pt_name,BankName,DDNumber)values('" + advance + "','" + receipt_no + "','" + amount_paid + "','" + invoice_no + "','" + procedure_name + "','" + mode_of_payment + "','" + pt_id + "','" + payment_date + "','" + dr_id + "','" + payment_due + "','" + total + "','" + cost + "','" + pt_name + "','" + BankName + "','" + DDNumber + "')");
            return inv;
        }
        public DataTable SumofTotal(string invoice_no,string patient_id)
        {
            DataTable invocetotal = db.table("select sum(total) as I_total from tbl_invoices where invoice_no='" + invoice_no + "' and pt_id='" + patient_id + "'");
            return invocetotal;
        }
        public void update_invoice_status0(decimal invoice_main_id)
        {
            db.execute("update tbl_invoices_main set status='0' where id='" + invoice_main_id + "'");
        }
        public int save_payment(string advance, string receipt_no, decimal amount_paid, string invoice_no, string procedure_name, string mode_of_payment, string pt_id, string payment_date, string dr_id, string payment_due, string total, string cost, string pt_name)
        {
            int inv1 = db.execute("insert into tbl_payment(advance,receipt_no,amount_paid,invoice_no,procedure_name,mode_of_payment,pt_id,payment_date,dr_id,payment_due,total,cost,pt_name)values('" + advance + "','" + receipt_no + "','" + amount_paid + "','" + invoice_no + "','" + procedure_name + "','" + mode_of_payment + "','" + pt_id + "','" + payment_date + "','" + dr_id + "','" + payment_due + "','" + total + "','" + cost + "','" + pt_name + "')");
            return inv1;
        }
        public DataTable receipt_autoid()
        {
            DataTable rec = db.table("select receipt_number from tbl_receipt_automationid");
            return rec;
        }
        public void update_receiptAutoid(int receip)
        {
            db.execute("update tbl_receipt_automationid set receipt_number='" + receip + "'");
        }
        public DataTable get_patientDetails(string patient_id)
        {
            DataTable dt_patent = db.table("select pt_name,pt_id,age,gender,street_address from tbl_patient where id='" + patient_id + "'");
            return dt_patent;
        }
       public DataTable payment_details(string date,string patient_id)
        {
          DataTable Payments = db.table("select receipt_no,amount_paid,invoice_no,procedure_name from tbl_payment where payment_date='" + date + "' and pt_id='" + patient_id + "'");
            return Payments;
        }
    }
}
