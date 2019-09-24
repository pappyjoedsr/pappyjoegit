using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public class SimpleAppointment_controller
    {
        Common_model cmodel = new Common_model();
        SimpleAppointment_model model = new SimpleAppointment_model();
        Clinical_Notes_Add_model cn_model = new Clinical_Notes_Add_model();
        Add_Invoice_model Ainv_model = new Add_Invoice_model();
        Prescription_model Pmodel = new Prescription_model();
        Communication_model com_model = new Communication_model();
        Add_Finished_Treatment_model fmodel = new Add_Finished_Treatment_model();
        Receipt_Model rmodel = new Receipt_Model();
        Add_New_Patient_model nmodel = new Add_New_Patient_model();

        public DataTable get_All_proceure()
        {
            DataTable dtb = cmodel.get_All_proceure();
            return dtb;
        }
        public DataTable get_drug_details()
        {
            DataTable dtb = model.get_drug_details();
            return dtb;
        }
        public DataTable get_all_doctorname()
        {
            DataTable dtb = cmodel.get_all_doctorname();
            return dtb;
        }
        public DataTable show_compl()
        {
            DataTable dtb = cn_model.show_compl();
            return dtb;
        }
        public DataTable show_diagno()
        {
            DataTable dtb = cn_model.show_diagno();
            return dtb;
        }
        public DataTable show_note()
        {
            DataTable dtb = cn_model.show_note();
            return dtb;
        }
        public DataTable Fill_unit_combo()
        {
            DataTable dtb = cmodel.Fill_unit_combo();
            return dtb;
        }
        public DataTable Fill_LoadTax()
        {
            DataTable dtb = cmodel.Fill_LoadTax();
            return dtb;
        }
        public DataTable Get_invoice_prefix()
        {
            DataTable dtb = Ainv_model.Get_invoice_prefix();
            return dtb;
        }
        public DataTable get_pt_details(string patient_id)
        {
            DataTable dtb = model.get_pt_details(patient_id);
            return dtb;
        }
        public DataTable get_EHR_details(string strApp_id)
        {
            DataTable dtb = model.get_EHR_details(strApp_id);
            return dtb;
        }
        public DataTable getComplaints(string id)
        {
            DataTable dtb = cn_model.getComplaints(id);
            return dtb;
        }
        public DataTable get_diagno(string id)
        {
            DataTable dtb = cn_model.get_diagno(id);
            return dtb;
        }
        public DataTable get_note(string id)
        {
            DataTable dtb = cn_model.get_note(id);
            return dtb;
        }
        public DataTable get_treatment_details(string plan_main_id)
        {
            DataTable dtb = model.get_treatment_details(plan_main_id);
            return dtb;
        }
        public string get_review_date(string id)
        {
            string reviewdATE = model.get_review_date(id);
            return reviewdATE;
        }
        public DataTable get_allprescription(string prescription_id)
        {
            DataTable td_prescription_Sub = Pmodel.get_allprescription(prescription_id);
            return td_prescription_Sub;
        }
        public DataTable get_proceduresettings()
        {
            DataTable dtb = model.get_proceduresettings();
            return dtb;
        }
        public string get_doctorname(string strApp_id)
        {
            string doctorname = model.get_doctorname(strApp_id);
            return doctorname;
        }
        public DataTable practicedetails()
        {
            DataTable dtb = cmodel.practicedetails();
            return dtb;
        }
        public DataTable smsdetails()
        {
            DataTable dtb = cmodel.smsdetails();
            return dtb;
        }
        public DataTable Patient_search(string _Patientid)
        {
            DataTable dtb = cmodel.Patient_search(_Patientid);
            return dtb;
        }
        public DataTable get_patient_name(string patient_id)
        {
            DataTable dtb = model.get_patient_name(patient_id);
            return dtb;
        }
        public DataTable patient_id(string txtPatientID)
        {
            DataTable dtb = model.patient_id(txtPatientID);
            return dtb;
        }
        public void insertInto_clinical_findings(string ptid, string dt, string date)
        {
             cn_model.insertInto_clinical_findings(ptid, dt, date);
        }
        public string MaxId_clinic_findings()
        {
            string maxid = cn_model.MaxId_clinic_findings();
            return maxid;
        }
        public void insrtto_diagno(int treat, string one)
        {
          cn_model.insrtto_diagno(treat, one);
        }
        public void insrtto_note(int treat, string one)
        {
            cn_model.insrtto_note(treat, one);
        }
        public void insrtto_chief_comp(int treat, string one)
        {
            cn_model.insrtto_chief_comp(treat, one);
        }
        public DataTable get_inventoryid(string id)
        {
            DataTable dtb = Pmodel.get_inventoryid(id);
            return dtb;
        }
        public void save_prescriptionmain(string ptid, string d_id, string date, string prescription_bill_status, string note)
        {
            Pmodel.save_prescriptionmain( ptid,  d_id,  date,  prescription_bill_status,  note);
        }
        public string Maxid()
        {
            string maxid = Pmodel.Maxid();
            return maxid;
        }
        public void save_prescription(int pres_id, string pt_id, string dr_name, string dr_id, string date, string drug_name, string strength, string strength_gr, string duration_unit, string duration_period, string morning, string noon, string night, string food, string add_instruction, string drug_type, string status, string drug_id)
        {
            Pmodel.save_prescription( pres_id,  pt_id,  dr_name,  dr_id,  date,  drug_name,  strength,  strength_gr,  duration_unit,  duration_period,  morning,  noon,  night,  food,  add_instruction,  drug_type,  status,  drug_id);
        }
        public void inssms(string patntid, string msg)
        {
            com_model.inssms(patntid, msg);
        }
        public void save_completed_id(string date, string patient_id)
        {
            fmodel. save_completed_id(date, patient_id);
        }
        public string get_completedMaxid()
        {
            string maxid = fmodel.get_completedMaxid();
            return maxid;
        }
        public void Save_tbl_completed_procedures(int plan_main_id, string patient_id, string procedure_id, string procedure_name, string quantity, string cost, string discount_type, string discount, string total, string discount_inrs, string note, string dr_id, string completed_id, string tooth)
        {
            Ainv_model.Save_tbl_completed_procedures( plan_main_id,  patient_id,  procedure_id,  procedure_name,  quantity,  cost,  discount_type,  discount,  total,  discount_inrs,  note,  dr_id,  completed_id,  tooth);
        }
        public void update_review(string date, int j_Review)
        {
            fmodel.update_review(date,j_Review);
        }
        public DataTable get_reviewId(string patient_id, string reviewdate)
        {
            DataTable dtb = cmodel.get_reviewId(patient_id, reviewdate);
            return dtb;
        }
        public void save_review(string date, string patient_id)
        {
            cmodel.save_review(date,patient_id);
        }
        public void save_appointment(string date, string patient_id, string pat_name, string dr_id, string Patient_mobile, string dr_name)
        {
            cmodel.save_appointment( date,  patient_id,  pat_name,  dr_id,  Patient_mobile,  dr_name);
        }
        public void update_review_No(string date, int j_Review)
        {
            fmodel.update_review_No(date,j_Review);
        }
        public void save_invoice_main(string patient_id, string name, string billno)
        {
            Ainv_model.save_invoice_main(patient_id, name, billno);
        }
        public string get_invoiceMain_maxid()
        {
            string inv_maxid = Ainv_model.get_invoiceMain_maxid();
            return inv_maxid;
        }
        public void save_invoice(string invoice_no, string pt_name, string pt_id, string service_id, string services, string unit, string cost, string discount, string discount_type, string total_cost, string total_discount, string dr_id, string discountin_rs, string invoice_main_id, string tax_inrs, string tax, string total_tax)
        {
            model.save_invoice( invoice_no,  pt_name,  pt_id,  service_id,  services,  unit,  cost,  discount,  discount_type,  total_cost,  total_discount,  dr_id,  discountin_rs,  invoice_main_id,  tax_inrs,  tax,  total_tax);
        }
        public string get_invoicenumber()
        {
            string auto = model.get_invoicenumber();
            return auto;
        }
        public void update_invnumber(string invoautoup)
        {
            model.update_invnumber(invoautoup);
        }
        public DataTable receipt_number()
        {
            DataTable dtb = rmodel.receipt_number();
            return dtb;
        }
        public void save_receipt(string receipt_no, string amount_paid, string invoice_no, string procedure_name, string pt_id, string dr_id, string total, string cost, string pt_name)
        {
            model.save_receipt( receipt_no,  amount_paid,  invoice_no,  procedure_name,  pt_id,  dr_id,  total,  cost,  pt_name);
        }
        public string receipt_autoid()
        {
            string rnumber = rmodel.receipt_autoid();
            return rnumber;
        }
        public void update_receiptAutoid(int receip)
        {
            rmodel.update_receiptAutoid(receip);
        }
        public void save_appointmnt(string EHR_Clinical, string EHR_treat, string EHR_Pre, string EHR_invoice, string strApp_id)
        {
            model.save_appointmnt(EHR_Clinical,  EHR_treat,  EHR_Pre,  EHR_invoice,  strApp_id);
        }
        public DataTable data_from_automaticid()
        {
            DataTable dtb= nmodel.data_from_automaticid();
            return dtb;
        }
        public void save_patient(string pt_name, string pt_id, string primary_mobile_number, string gender, string age, string locality, string city, string Visited, string doctorname)
        {
            model.save_patient(pt_name, pt_id,primary_mobile_number, gender,age, locality,city,Visited,doctorname);
        }
        public void update_autogenerateid(int n)
        {
            nmodel.update_autogenerateid(n);
        }
        public string Get_DoctorName(string doctor_id)
        {
            string name=cmodel.Get_DoctorName(doctor_id);
            return name;
        }
        public DataTable Get_Patient_Details(string id)
        {
            DataTable dtb = cmodel.Get_Patient_Details(id);
            return dtb;
        }
        public DataTable get_company_details()
        {
            DataTable dtb = cmodel.get_company_details();
            return dtb;
        }
        public DataTable get_invoiceDetails(string mainid)
        {
            DataTable dtb = Ainv_model.get_invoiceDetails(mainid);
            return dtb;
        }
        public DataTable get_pres_details_wit_ptid(string patient_id, string EHR_Pre)
        {
            DataTable dtb = model.get_pres_details_wit_ptid(patient_id, EHR_Pre);
            return dtb;
        }
        public DataTable load_template()
        {
            DataTable dtb = model.load_template();
            return dtb;
        }
        public DataTable compsearch(string compsearchtext)
        {
            DataTable dtb = cn_model.compsearch(compsearchtext);
            return dtb;
        }
        public DataTable complaint_cell(string idcomp)
        {
            DataTable dtb = cn_model.complaint_cell(idcomp);
            return dtb;
        }
        public DataTable diagnosetxtsearch(string diagsearchtext)
        {
            DataTable dtb = cn_model.diagnosetxtsearch(diagsearchtext);
            return dtb;
        }
        public DataTable diagnose_cell(string iddiag)
        {
            DataTable dtb = cn_model.diagnose_cell(iddiag);
            return dtb;
        }
        public DataTable notesearch(string notesearchtext)
        {
            DataTable dtb = cn_model.notesearch(notesearchtext);
            return dtb;
        }
        public DataTable notes_cell(string idnote)
        {
            DataTable dtb = cn_model.notes_cell(idnote);
            return dtb;
        }
        public DataTable search_procedures(string search)
        {
            DataTable dtb = Ainv_model.search_procedures(search);
            return dtb;
        }
        public DataTable load_proceduresgrid()
        {
            DataTable dtb = fmodel.load_proceduresgrid();
            return dtb;
        }
        public DataTable get_procedure_Name(string id)
        {
            DataTable dtb = fmodel.get_procedure_Name(id);
            return dtb;
        }
        public DataTable search_template(string searchtext2)
        {
            DataTable dtb = Pmodel.search_template(searchtext2);
            return dtb;
        }
        public DataTable drug_search(string txt_Prescrptn)
        {
            DataTable dtb = model.drug_search(txt_Prescrptn);
            return dtb;
        }
        public DataTable get_drug_strength(string idpres)
        {
            DataTable dtb = model.get_drug_strength(idpres);
            return dtb;
        }
        public string drug_type(string Lab_DrugId)
        {
            string dtb = model.drug_type(Lab_DrugId);
            return dtb;
        }
        public string select_taxValue(string name)
        {
            string dtb = Ainv_model.select_taxValue(name);
            return dtb;
        }
        public DataTable template_main(string idpres)
        {
            DataTable dtb = model.template_main(idpres);
            return dtb;
        }
        public DataTable template_details(string idpres)
        {
            DataTable dtb = model.template_details(idpres);
            return dtb;
        }

    }
}
