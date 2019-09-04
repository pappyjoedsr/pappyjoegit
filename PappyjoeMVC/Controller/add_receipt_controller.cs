using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Add_Receipt_controller
    {
        add_receipt_interface intr;
        Receipt_Model _model = new Receipt_Model();
        Common_model cmodel = new Common_model();
        Connection db = new Connection();
        public Add_Receipt_controller(add_receipt_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public DataTable receipt_number()
        {
            DataTable dtb = _model.receipt_number();
            return dtb;
        }
        public void Get_invoice_details(string patient_id)
        {
            DataTable dtb = _model.Get_invoice_details(patient_id);
            intr.LoadGrid_status0(dtb);
        }
        public DataTable Patient_invoice(string patient_id, string invoices)
        {
            DataTable dtb = _model.Patient_invoice(patient_id, invoices);
            return dtb;
        }
        public DataTable select_invoice(string invoices)
        {
            DataTable dtb = _model.select_invoice(invoices);
            return dtb;
        }
        public string Load_CompanyName()
        {
            string dtb = cmodel.Load_CompanyName();
            return dtb;
        }
        public DataTable Get_Advance(string invoices)
        {
            DataTable dtb = cmodel.Get_Advance(invoices);
            return dtb;
        }
        public void update_advance(decimal adv, string patient_id)
        {
            _model.update_advance(adv, patient_id);
        }
        public void save_advance(decimal adv, string patient_id)
        {
            _model.save_advance(adv, patient_id);
        }
        public DataTable Get_All_paymenttbl_details(string ReceiptNo)
        {
            DataTable dtb = _model.Get_All_paymenttbl_details(ReceiptNo);
            return dtb;
        }
        public DataTable Procedurewisw_receipt_report(string invoice_no, string patient_id, string services)
        {
            DataTable dtb = _model.Procedurewisw_receipt_report(invoice_no, patient_id, services);
            return dtb;
        }
        public int updatetotal(decimal total, string invoice_no, string patient_id, string services)
        {
            int i = _model.updatetotal(total, invoice_no, patient_id, services);
            return i;
        }
        public int save_payment_checkwise(string advance, string receipt_no, decimal amount_paid, string invoice_no, string procedure_name, string mode_of_payment, string pt_id, string payment_date, string dr_id, string payment_due, string total, string cost, string stringpt_name, string BankName, string Number)
        {
            int i = _model.save_payment_checkwise(advance, receipt_no, amount_paid, invoice_no, procedure_name, mode_of_payment, pt_id, payment_date, dr_id, payment_due, total, cost, stringpt_name, BankName, Number);
            return i;
        }
        public int save_payment_cardWise(string advance, string receipt_no, decimal amount_paid, string invoice_no, string procedure_name, string mode_of_payment, string pt_id, string payment_date, string dr_id, string payment_due, string total, string cost, string stringpt_name, string CardNo, string DigitNo)
        {
            int i = _model.save_payment_cardWise(advance, receipt_no, amount_paid, invoice_no, procedure_name, mode_of_payment, pt_id, payment_date, dr_id, payment_due, total, cost, stringpt_name, CardNo, DigitNo);
            return i;
        }
        public int Save_payment_DD(string advance, string receipt_no, decimal amount_paid, string invoice_no, string procedure_name, string mode_of_payment, string pt_id, string payment_date, string dr_id, string payment_due, string total, string cost, string pt_name, string BankName, string DDNumber)
        {
            int i = _model.Save_payment_DD(advance, receipt_no, amount_paid, invoice_no, procedure_name, mode_of_payment, pt_id, payment_date, dr_id, payment_due, total, cost, pt_name, BankName, DDNumber);
            return i;
        }
        public DataTable SumofTotal(string invoice_no, string patient_id)
        {
            DataTable dtb = _model.SumofTotal(invoice_no, patient_id);
            return dtb;
        }
        public void update_invoice_status0(decimal invoice_main_id)
        {
            _model.update_invoice_status0(invoice_main_id);
        }
        public int save_payment(string advance, string receipt_no, decimal amount_paid, string invoice_no, string procedure_name, string mode_of_payment, string pt_id, string payment_date, string dr_id, string payment_due, string total, string cost, string pt_name)
        {
            int inv = _model.save_payment(advance, receipt_no, amount_paid, invoice_no, procedure_name, mode_of_payment, pt_id, payment_date, dr_id, payment_due, total, cost, pt_name);
            return inv;
        }
        public DataTable receipt_autoid()
        {
            DataTable dtb = _model.receipt_autoid();
            return dtb;
        }
        public void update_receiptAutoid(int receip)
        {
            _model.update_receiptAutoid(receip);
        }
        public DataTable get_patientDetails(string patient_id)
        {
            DataTable dtb = _model.get_patientDetails(patient_id);
            return dtb;
        }
        public DataTable get_company_details()
        {
            DataTable dtb = cmodel.get_company_details();
            return dtb;
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
