using System.Data;
namespace PappyjoeMVC.Model
{
    public class Add_Invoice_model
    {
        Connection db = new Connection();
        public DataTable load_tax()
        {
            DataTable dt5 = db.table("select id,tax_name from tbl_tax");
            return dt5;
        }
        public DataTable get_completed_procedure_details(string patient_id)
        {
            DataTable dt_tp1 = db.table("SELECT id, procedure_name,procedure_id,cost from tbl_completed_procedures where pt_id='" + patient_id + "' and status='1'");
            return dt_tp1;
        }
        public DataTable get_planed_procedure(string patient_id)
        {
            DataTable dt_tp = db.table("SELECT id, plan_main_id,procedure_name,procedure_id,cost from tbl_treatment_plan where pt_id='" + patient_id + "' and status='1'");
            return dt_tp;
        }
        public DataTable Get_invoice_deatils(string ptid, string invoiceid)
        {
            DataTable dt2 = db.table("select * from tbl_invoices where pt_id='" + ptid + "' and invoice_no='" + invoiceid + "'");
            return dt2;
        }
        public DataTable load_completed_procedure(string id)
        {
            System.Data.DataTable rs_plan = db.table("select A.procedure_id,A.procedure_name,A.quantity,A.cost,A.discount_type,A.discount,A.total," +
                    "A.discount_inrs,A.note,A.date,A.dr_id,A.tooth,B.doctor_name,A.completed_id from tbl_completed_procedures as A join tbl_doctor as B on B.id=A.dr_id where A.id='" + id + "'");
            return rs_plan;
        }
        public DataTable Get_completed_table_details(string P_Completed_id)
        {
            DataTable dt_treatment = db.table("select procedure_name,quantity,cost,discount_type,discount,discount_inrs,note,tooth,total from tbl_completed_procedures where id ='" + P_Completed_id + "'");
            return dt_treatment;
        }
        public DataTable select_All_invoicedata(string billno)
        {
            DataTable receipt = db.table("select * from tbl_invoices_main where invoice='" + billno + "'");
            return receipt;
        }
        public DataTable get_taxValue(string name)
        {
            DataTable dt = db.table("select tax_value from tbl_tax where tax_name ='" + name + "'");
            return dt;
        }
        public DataTable Get_quantiry_fromStock(string stock_id)
        {
            DataTable testQty = db.table("select quantity from tbl_add_stock where id='" + stock_id + "'");
            return testQty;
        }
        public DataTable Load_invoice_mainDetails(string patient_id)
        {
            DataTable dt_invoice_main = db.table("SELECT id,date,invoice,status FROM tbl_invoices_main where pt_id='" + patient_id + "' ORDER BY date DESC");
            return dt_invoice_main;
        }
        public DataTable get_invoice_doctorname(string patient_id)
        {
            DataTable dt_cf = db.table("SELECT tbl_doctor.doctor_name, tbl_invoices_main.date,tbl_invoices.invoice_no FROM tbl_invoices INNER JOIN tbl_doctor ON tbl_invoices.dr_id = tbl_doctor.id INNER JOIN tbl_invoices_main ON tbl_invoices.invoice_main_id = tbl_invoices_main.id WHERE tbl_invoices_main.pt_id = '" + patient_id + "'");
            return dt_cf;
        }
    }
}