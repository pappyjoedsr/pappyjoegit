using System.Data;

namespace PappyjoeMVC.Model
{
    public class Ledger_model
    {
        Connection db = new Connection();
        public DataTable LedgerInvoice(string patient_id)
        {
            DataTable dtb = db.table("select * from tbl_invoices where pt_id='" + patient_id + "' ");
            return dtb;
        }
        public DataTable LedgerPay(string patient_id)
        {
            DataTable dtb = db.table("select receipt_no,payment_date,invoice_no,amount_paid from tbl_payment where pt_id='" + patient_id + "' AND payment_date!='' order by payment_date desc");
            return dtb;
        }
    }
}
