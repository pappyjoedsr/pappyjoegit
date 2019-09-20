using PappyjoeMVC.Model;
using System;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Add_Invoice_controller
    {
        Connection db = new Connection();
        Add_Invoice_model _model = new Add_Invoice_model();
        Add_Finished_Treatment_model fmodel = new Add_Finished_Treatment_model();
        Common_model cmodel = new Common_model();
        public string get_adminid()
        {
            string admin = cmodel.Get_adminId();
            return admin;
        }
        public string Load_CompanyName()
        {
            string dtb = cmodel.Load_CompanyName();
            return dtb;
        }
        public DataTable Get_invoice_prefix()
        {
            DataTable invno = _model.Get_invoice_prefix();
            return invno;
        }
        public DataTable load_tax()
        {
            DataTable dtb = _model.load_tax();
            return dtb;
        }
        public DataTable get_completed_procedure_details(string patient_id)
        {
            DataTable dtb = _model.get_completed_procedure_details(patient_id);
            return dtb;
        }
        public DataTable get_planed_procedure(string patient_id)
        {
            DataTable dtb = _model.get_planed_procedure(patient_id);
            return dtb;
        }
        public DataTable Get_invoice_deatils(string ptid, string invoiceid)
        {
            DataTable dtb = _model.Get_invoice_deatils(ptid, invoiceid);
            return dtb;
        }
        public DataTable load_completed_procedure(string id)
        {
            DataTable dtb = _model.load_completed_procedure(id);
            return dtb;
        }
        public DataTable search_procedure_completed(string patient_id, string search)
        {
            DataTable dt_tp1 = _model.search_procedure_completed(patient_id, search);
            return dt_tp1;
        }
        public DataTable Search_procedure_planed(string patient_id, string search)
        {
            DataTable dt_tp = _model.Search_procedure_planed(patient_id, search);
            return dt_tp;
        }
        public DataTable search_procedures(string search)
        {
            DataTable dt_pt = _model.search_procedures(search);
            return dt_pt;
        }
        public DataTable load_AllProcedures()
        {
            DataTable dtb = fmodel.load_proceduresgrid();
            return dtb;
        }
        public DataTable get_procedure_Name(string id)
        {
            DataTable dtb = fmodel.get_procedure_Name(id);
            return dtb;
        }
        public DataTable Get_treatment_details(string plan_p_id)
        {
            DataTable dtb = fmodel.Get_treatment_details(plan_p_id);
            return dtb;
        }
        public DataTable Get_completed_table_details(string P_Completed_id)
        {
            DataTable dtb = _model.Get_completed_table_details(P_Completed_id);
            return dtb;
        }
        public DataTable Get_quantiry_fromStock(string stock_id)
        {
            DataTable testQty = _model.Get_quantiry_fromStock(stock_id);

            return testQty;
        }
        public DataTable select_All_invoicedata(string billno)
        {
            DataTable dtb = _model.select_All_invoicedata(billno);
            return dtb;
        }
        public void save_invoice_main(string patient_id, string name, string billno)
        {
            _model.save_invoice_main(patient_id, name, billno);
        }
        public string get_invoiceMain_maxid()
        {
            string dt1 = _model.get_invoiceMain_maxid();
            return dt1;
        }
        public void save_completedid(string date, string patient_id)
        {
            _model.save_completedid(date, patient_id);
        }
        public string get_completed_procedure_maxid()
        {
            string dt_procedure = _model.get_completed_procedure_maxid();
            return dt_procedure;
        }
        public void save_invoice_details(string invoice_no, string pt_name, string patient_id, string service_id, string services, string unit, string cost, string discount, string discount_type, string tax, string total, string notes, string total_discount, string total_tax, string dr_id, string discountin_rs, string tax_inrs, int invoice_main_id, int completed_id)
        {
            _model.save_invoice_details(invoice_no, pt_name, patient_id, service_id, services, unit, cost, discount, discount_type, tax, total, notes, total_discount, total_tax, dr_id, discountin_rs, tax_inrs, invoice_main_id, completed_id);
        }
        public void Save_tbl_completed_procedures(int plan_main_id, string patient_id, string procedure_id, string procedure_name, string quantity, string cost, string discount_type, string discount, string total, string discount_inrs, string note, string dr_id, string completed_id, string tooth)
        {
            _model.Save_tbl_completed_procedures(plan_main_id, patient_id, procedure_id, procedure_name, quantity, cost, discount_type, discount, total, discount_inrs, note, dr_id, completed_id, tooth);
        }
        public void save_invoice_items(string invoice_no, string pt_name, string patient_id, string service_id, string services, string unit, string cost, string discount, string discount_type, string tax, string total, string notes, string total_discount, string total_tax, string dr_id, string discountin_rs, string tax_inrs, int invoice_main_id, string plan_id, int completed_id)
        {
            _model.save_invoice_items(invoice_no, pt_name, patient_id, service_id, services, unit, cost, discount, discount_type, tax, total, notes, total_discount, total_tax, dr_id, discountin_rs, tax_inrs, invoice_main_id, plan_id, completed_id);
        }
        public void Set_completed_status0(string id)
        {
            _model.Set_completed_status0(id);
        }
        public void update_invoice_autoid(int a)
        {
            _model.update_invoice_autoid(a);
        }
        public string Get_invoiceDate(string invno)
        {
            string dt0 = _model.Get_invoiceDate(invno);
            return dt0;
        }
        public void delete_invoice(string billno)
        {
            _model.delete_invoice(billno);
        }
        public DataTable get_taxValue(string name)
        {
            DataTable dtb = _model.get_taxValue(name);
            return dtb;
        }
        public void save_incove_items(string invoice_no, string pt_name, string pt_id, string services, string unit, string cost, string discount, string discount_type, string tax, string total, string date, string notes, string total_cost, string total_discount, string total_tax, string grant_total, string dr_id, string discountin_rs, string tax_inrs, string total_payment)
        {
            _model.save_incove_items(invoice_no, pt_name, pt_id, services, unit, cost, discount, discount_type, tax, total, date, notes, total_cost, total_discount, total_tax, grant_total, dr_id, discountin_rs, tax_inrs, total_payment);
        }
        public string select_taxValue(string name)
        {
            string dt = _model.select_taxValue(name);
            return dt;
        }
        public DataTable Patient_search(string patid)
        {
            DataTable dtb = cmodel.Patient_search(patid);
            return dtb;
        }
        public string permission_for_settings(string doctor_id)
        {
            string dtb = cmodel.permission_for_settings(doctor_id);
            return dtb;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string dtb = cmodel.doctr_privillage_for_addnewPatient(doctor_id);
            return dtb;
        }
        public DataTable get_completed_id(string patient_id, string DTP_Date)
        {
            DataTable dt_pt = fmodel.get_completed_id(patient_id, DTP_Date);
            return dt_pt;
        }
        public string get_completedMaxid()
        {
            string dt = fmodel.get_completedMaxid();
            return dt;
        }
        public void update_treatment_status(string id)
        {
            fmodel.update_treatment_status(id);
        }

    }
}
