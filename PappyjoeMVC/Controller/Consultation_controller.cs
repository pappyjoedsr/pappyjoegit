using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
   public class Consultation_controller
    {
        Consultation_model model = new Consultation_model();
        Add_Finished_Treatment_model fmodel =new Add_Finished_Treatment_model();
        Prescription_model pmodel = new Prescription_model();
        Common_model cmodel = new Common_model();
        Add_Invoice_model imodel = new Add_Invoice_model();
        SimpleAppointment_model smodel = new SimpleAppointment_model();
        Receipt_Model rmodel = new Receipt_Model();
        Connection db = new Connection();
        public DataTable search_patient(string search)
        {
            DataTable dtb = model.search_patient(search);
            return dtb;
        }
        public DataTable patient_details(string value)
        {
            DataTable dtb = model.patient_details(value);
            return dtb;
        }
        public DataTable search_procedure(string search)
        {
            DataTable dtb = model.search_procedure(search);
            return dtb;
        }
        public DataTable procedure_details(string value)
        {
            DataTable dtb = model.procedure_details(value);
            return dtb;
        }
        public DataTable Load_temlate()
        {
            DataTable dtb = model.Load_temlate();
            return dtb;
        }
        public DataTable Load_doctor()
        {
            DataTable dtb = model.Load_doctor();
            return dtb;
        }
        public DataTable Load_dctrname(string doctor_id)
        {
            DataTable dtb = model.Load_dctrname(doctor_id);
            return dtb;
        }
        public DataTable get_procedure()
        {
            DataTable dtb = model.get_procedure();
            return dtb;
        }
        public DataTable get_tempid(string pres_id)
        {
            DataTable dtb = model.get_tempid(pres_id);
            return dtb;
        }
        public DataTable get_templateid(string presid)
        {
            DataTable dtb = model.get_templateid(presid);
            return dtb;
        }
        public DataTable get_invid(string drugid)
        {
            DataTable dtb = model.get_invid(drugid);
            return dtb;
        }
        public void save_prescriptionMain(string patient_id, int d_id, string Prescription_bill_status, string notes)
        {
            model.save_prescriptionMain(patient_id,  d_id,  Prescription_bill_status,  notes);
        }
        public string max_presid()
        {
            string id= model.max_presid();
            return id;
        }
        public void save_prescription(int presid, string patient_id, string dr_name, string dr_id, string drug_name, string strength, string strength_gr, string duration_period, string morning, string noon, string night, string food, string add_instruction, string drug_type, string status, string drug_id)
        {
            model.save_prescription( presid,  patient_id,  dr_name,  dr_id,  drug_name,  strength,  strength_gr,    duration_period,  morning,  noon,  night,  food,  add_instruction,  drug_type,  status,  drug_id);
        }
        public void save_completedid(string patient_id)
        {
            model.save_completedid(patient_id);
        }
        public string max_completedid()
        {
           string com_id= model.max_completedid();
            return com_id;
        }
        public void save_completed_details(int plan_main_id, string pt_id, string procedure_id, string procedure_name, string cost, string total, string note, string dr_id)
        {
            model.save_completed_details(plan_main_id,  pt_id,  procedure_id,  procedure_name,  cost,  total,  note,  dr_id);
        }
        public string max_completeProcedure()
        {
           string max_id= model.max_completeProcedure();
            return max_id;
        }
        public void update_review(string date, int j_Review)
        {
            fmodel.update_review(date, j_Review);
        }
        public void update_prescription_review(string date, int presid)
        {
            pmodel.update_prescription_review(date,presid);
        }
        public DataTable get_reviewId(string patient_id, string reviewdate)
        {
          DataTable dtb= cmodel.get_reviewId(patient_id,reviewdate);
          return dtb;
        }
        public void save_review(string date, string patient_id)
        {
             cmodel.save_review(date,patient_id);
        }
        public void update_review_No(string date, int j_Review)
        {
            fmodel.update_review_No(date, j_Review);
        }
        public void update_prescription_review_NO(string date, int presid)
        {
            pmodel.update_prescription_review_NO(date, presid);
        }
        public DataTable Get_invoice_prefix()
        {
            DataTable dtb = imodel.Get_invoice_prefix();
            return dtb;
        }
        public void save_invoice_main(string patient_id, string pt_name, string invoice)
        {
            model.save_invoice_main(patient_id, pt_name, invoice);
        }
        public string get_invoiceMain_maxid()
        {
            string max_id = imodel.get_invoiceMain_maxid();
            return max_id;
        }
        public void save_invoice_details(string invoice, string pt_name, string patient_id, string service_id, string services, string cost, string total, string dr_id, long Invoice_main_id, long completed_procedures_id)
        {
            model.save_invoice_details(invoice,  pt_name,  patient_id,  service_id,  services,  cost,  total,  dr_id,  Invoice_main_id,  completed_procedures_id);
        }
        public string get_invoicenumber()
        {
            string numbr= smodel.get_invoicenumber();
            return numbr;
        }
        public void update_invnumber(int invoautoup)
        {
            smodel.update_invnumber(invoautoup.ToString());
        }
        public DataTable receipt_number()
        {
            DataTable dtb = rmodel.receipt_number();
            return dtb;
        }
        public DataTable Get_Advance(string patient_id)
        {
            DataTable dtb = cmodel.Get_Advance(patient_id);
            return dtb;
        }
        public void save_receipt(string receipt, decimal advance, string amount_paid, string invoice, string procedure_name, string patient_id, string dr_id, string total, string pt_name, long Invoice_main_id)
        {
            model.save_receipt(receipt,  advance,  amount_paid,  invoice,  procedure_name,  patient_id,  dr_id,  total,  pt_name,  Invoice_main_id);
        }
        public string receipt_autoid()
        {
            string numbr = rmodel.receipt_autoid();
            return numbr;
        }
        public void update_receiptAutoid(int receip)
        {
            rmodel.update_receiptAutoid(receip);
        }
        public DataTable get_receipt_details(string payment_date, string patient_id, string receipt)
        {
            DataTable dtb = model.get_receipt_details(payment_date,  patient_id,  receipt);
            return dtb;
        }
        public DataTable get_payment_details(string payment_date, string patient_id, string receipt)
        {
            DataTable dtb = model.get_payment_details(payment_date, patient_id, receipt);
            return dtb;
        }
        public DataTable get_receipt_print_setting()
        {
            DataTable dtb = model.get_receipt_print_setting();
            return dtb;
        }
        public string server()
        {
            string server = db.server();
            return server;
        }
        public string Get_DoctorName(string doctor_id)
        {
            string name = cmodel.Get_DoctorName(doctor_id);
            return name;
        }
        public DataTable get_company_details()
        {
            DataTable dtb = cmodel.get_company_details();
            return dtb;
        }
        public DataTable Get_Patient_Details(string id)
        {
            DataTable dtb = cmodel.Get_Patient_Details(id);
            return dtb;
        }
        public DataTable get_patient_details(string newptid)
        {
            DataTable dtb = model.get_patient_details(newptid);
            return dtb;
        }
        public DataTable get_inventoryid(string id)
        {
            DataTable dtb = pmodel.get_inventoryid(id);
            return dtb;
        }
    }
}
