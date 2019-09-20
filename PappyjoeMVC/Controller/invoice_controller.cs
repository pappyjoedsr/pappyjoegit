using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Invoice_controller
    {
        Connection db = new Connection();
        Add_Invoice_model Add_inv_model = new Add_Invoice_model();
        Inventory_model inv_model = new Inventory_model();
        Common_model cmodel = new Common_model();
        public string check_addprivillege(string doctor_id)
        {
            string privid = Add_inv_model.check_addprivillege(doctor_id);
            return privid;
        }
        public string check_delete_privillege(string doctor_id)
        {
            string privid = Add_inv_model.check_delete_privillege(doctor_id);
            return privid;
        }
        public string addpayment_privillege(string doctor_id)
        {
            string privid = Add_inv_model.addpayment_privillege(doctor_id);
            return privid;
        }
        public DataTable Get_invoice_mainDetails(string patient_id)
        {
            DataTable dt_invoice_main = Add_inv_model.Load_invoice_mainDetails(patient_id);
            return dt_invoice_main;
        }
        public DataTable get_invoiceDetails(string mainid)
        {
            DataTable dt_pt_sub = Add_inv_model.get_invoiceDetails(mainid);
            return dt_pt_sub;
        }
        public string Get_type(string invoice_plan_id)
        {
            string invoice_type = Add_inv_model.Get_type(invoice_plan_id);
            return invoice_type;
        }
        public DataTable InvoiceDetails(string invoice_plan_id)
        {
            DataTable dt_in_main = Add_inv_model.InvoiceDetails(invoice_plan_id);
            return dt_in_main;
        }
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
            Add_inv_model.set_completeProcedure_status1(completed_id);
        }
        public void delete_from_invoice(string invoice_plan_id)
        {
            Add_inv_model.delete_from_invoice(invoice_plan_id);
        }
        public DataTable get_total_payment(string ptid)
        {
            DataTable dtb = cmodel.get_total_payment(ptid);
            return dtb;
        }
        public DataTable Load_invoice_mainDetails(string patient_id)
        {
            DataTable dtb = Add_inv_model.Load_invoice_mainDetails(patient_id);
            return dtb;
        }
        public string Get_paymentid(string invno)
        {
            string dt_pay = Add_inv_model.Get_paymentid(invno);
            return dt_pay;
        }
        public DataTable Get_invoicePrintsettings()
        {
            DataTable print = Add_inv_model.Get_invoicePrintsettings();
            return print;
        }
        public DataTable get_invoice_doctorname(string patient_id)
        {
            DataTable dtb = Add_inv_model.get_invoice_doctorname(patient_id);
            return dtb;
        }
        public DataTable Get_date(string invoice_plan_id)
        {
            DataTable dt_invo = Add_inv_model.Get_date(invoice_plan_id);
            return dt_invo;
        }
        public string Get_TotalSum(string invoice_plan_id)
        {
            string num = Add_inv_model.Get_TotalSum(invoice_plan_id);
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
