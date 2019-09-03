using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Invoice_controller
    {
        invoice_interface intr;
        Connection db = new Connection();
        Add_Invoice_model Add_inv_model = new Add_Invoice_model();
        Inventory_model inv_model = new Inventory_model();
        Common_model cmodel = new Common_model();
        public Invoice_controller(invoice_interface inttr)
        {
            intr = inttr;
            intr.Setcontroller(this);
        }
        public string check_addprivillege(string doctor_id)
        {
            string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRI' and Permission='A'");
            return privid;
        }
        public string check_delete_privillege(string doctor_id)
        {
            string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRI' and Permission='D'");
            return privid;
        }
        public string addpayment_privillege(string doctor_id)
        {
            string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='PMT' and Permission='A'");
            return privid;
        }
        public void Get_invoice_mainDetails(string patient_id)
        {
            DataTable dt_invoice_main = Add_inv_model.Load_invoice_mainDetails(patient_id);// db.table("SELECT id,date,invoice,status FROM tbl_invoices_main where pt_id='" + patient_id + "' ORDER BY date DESC");
            intr.Load_MainTable(dt_invoice_main);
        }
        public DataTable get_invoiceDetails(string mainid)
        {
            DataTable dt_pt_sub = db.table("SELECT id,services,unit,cost,discount,discount_type,tax,total,notes,total_cost,total_discount,total_tax,discountin_rs,tax_inrs,dr_id,invoice_no FROM tbl_invoices where invoice_main_id='" + mainid + "' ORDER BY id");
            return dt_pt_sub;
        }
        public DataTable Get_type(string invoice_plan_id)
        {
            DataTable invoice_type = db.table("SELECT type FROM tbl_invoices_main where id='" + invoice_plan_id + "' ");
            return invoice_type;
        }
        public DataTable InvoiceDetails(string invoice_plan_id)
        {
            DataTable dt_in_main = db.table("SELECT * FROM tbl_invoices where invoice_main_id='" + invoice_plan_id + "' ");
            return dt_in_main;
        }//SELECT invoice_no,services,cost,discountin_rs,total_tax,total,unit,notes FROM tbl_invoices WHERE invoice_main_id 
        public DataTable geGet_quantiry_fromStockt(string stockid)
        {
            DataTable dtb = Add_inv_model.Get_quantiry_fromStock(stockid);
            return dtb;
        }
        public void update_addStock_qty(decimal current_Stock, string completedid)
        {
            inv_model.update_addStock_qty(current_Stock, completedid);
        }
        public void update_inventoryStock(decimal total_Stock, string Plan_id)
        {
            inv_model.update_inventoryStock(total_Stock, Plan_id);
        }
        public void set_completeProcedure_status1(string completed_id)
        {
            db.execute("update tbl_completed_procedures set status='1' where id= '" + completed_id + "'");
        }
        public void delete_invoice(string invoice_plan_id)
        {
            db.execute("delete from tbl_invoices_main where id='" + invoice_plan_id + "'");
            db.execute("delete from tbl_invoices where invoice_main_id='" + invoice_plan_id + "'");
        }
        public void get_total_payment(string ptid)
        {
            DataTable dtb = cmodel.get_total_payment(ptid);
            intr.set_totalPayment(dtb);
        }
        public DataTable Load_invoice_mainDetails(string patient_id)
        {
            DataTable dtb = Add_inv_model.Load_invoice_mainDetails(patient_id);
            return dtb;
        }
        public DataTable Get_paymentid(string invno)
        {
            DataTable dt_pay = db.table("SELECT id FROM tbl_payment where invoice_no='" + invno + "' ");
            return dt_pay;
        }
        public DataTable Get_invoicePrintsettings()
        {
            DataTable print = db.table("select * from  tbl_invoice_printsettings");
            return print;
        }
        public DataTable get_invoice_doctorname(string patient_id)
        {
            DataTable dtb = Add_inv_model.get_invoice_doctorname(patient_id);
            return dtb;
        }
        public DataTable Get_date(string invoice_plan_id)
        {
            DataTable dt_invo = db.table("SELECT invoice,date FROM tbl_invoices_main WHERE id = '" + invoice_plan_id + "'");
            return dt_invo;
        }
        public string Get_TotalSum(string invoice_plan_id)
        {
            string num = db.scalar("SELECT sum(total) FROM tbl_invoices WHERE invoice_main_id ='" + invoice_plan_id + "'");
            return num;
        }
        public DataTable Patient_search(string patid)
        {
            DataTable dtb = cmodel.Patient_search(patid);
            return dtb;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string dtb = cmodel.doctr_privillage_for_addnewPatient(doctor_id);
            return dtb;
        }
        public string permission_for_settings(string doctor_id)
        {
            string dtb = cmodel.permission_for_settings(doctor_id);
            return dtb;
        }
    }
}
