using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
    public  class Ledger_controller
    {
        Ledger_interface intr;
        common_model cmodel = new common_model();
        Ledger_model _model = new Ledger_model();
        public Ledger_controller(Ledger_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public string Get_DoctorName(string doctor_id)
        {
            string dtb = cmodel.Get_DoctorName(doctor_id); 
            return dtb;
        }
        public DataTable Get_CompanyNAme()  
        {
            DataTable dtb = cmodel.Get_CompanyNAme();
            return dtb;
        }
        public DataTable Get_Advance(string patient_id)
        {
            DataTable dtb = cmodel.Get_Advance(patient_id);
            return dtb;
        }
        public DataTable Get_pat_iDName(string patient_id)
        {
            DataTable dtb = cmodel.Get_pat_iDName(patient_id);
            return dtb;
        }
        public DataTable LedgerInvoice(string patient_id)
        {
            DataTable dtb = _model.LedgerInvoice(patient_id);
            return dtb;
        }
        public DataTable LedgerPay(string patient_id)
        {
            DataTable dtb = _model.LedgerPay(patient_id);
            return dtb;
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
        public DataTable getpatemail(string patient_id)
        {
            DataTable dtb = cmodel.getpatemail(patient_id);
            return dtb;
        }
        public DataTable send_email()
        {
            DataTable dtb = cmodel.send_email();
            return dtb;
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
    }
}
