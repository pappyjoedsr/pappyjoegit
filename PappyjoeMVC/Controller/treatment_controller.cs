using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Treatment_controller
    {
        Treatment_model _model = new Treatment_model();
        Common_model cmodel = new Common_model();
        Connection db = new Connection();
        public string check_privillege(string doctor_id)
        {
            string a = _model.check_privillege(doctor_id);
            return a;
        }
        public string check_edit_privillege(string doctor_id)
        {
            string a = _model.check_edit_privillege(doctor_id);
            return a;
        }
        public string delete_privillege(string doctor_id)
        {
            string a = _model.delete_privillege(doctor_id);
            return a;
        }
        public DataTable Get_CompanyNAme()
        {
            DataTable clinicname = cmodel.Get_CompanyNAme();
            return clinicname;
        }
        public string Get_DoctorName(string doctor_id)
        {
            string docnam = cmodel.Get_DoctorName(doctor_id);
            return docnam;
        }
        public string server()
        {
            string server = db.server();
            return server;
        }
        public DataTable Get_Patient_Details(string patient_id)
        {
            DataTable rs_patients = cmodel.Get_Patient_Details(patient_id);
            return rs_patients;
        }
        public DataTable get_treatments(string patient_id)
        {
            DataTable dtb = _model.Load_treatments(patient_id);
            return dtb;// intr.load_treatment(dtb);
        }
        public DataTable treatment_sub_details(string id)
        {
            DataTable dtb = _model.treatment_sub_details(id);
            return dtb;
        }
        public DataTable get_plan_id(string treatment_plan_id)
        {
            DataTable dtb = _model.get_plan_id(treatment_plan_id);
            return dtb;
        }
        public void delete_treatment(string treatment_plan_id)
        {
            _model.delete_treatment(treatment_plan_id);
        }
        public DataTable Get_treatment_details(string treatment_plan_id)
        {
            DataTable dtb = _model.get_treatments(treatment_plan_id);
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
        public DataTable getpatemail(string patient_id)
        {
            DataTable sr = cmodel.getpatemail(patient_id);
            return sr;
        }
        public DataTable send_email()
        {
            DataTable sms = cmodel.send_email();
            return sms;
        }
        public DataTable get_company_details()
        {
            DataTable dtp = cmodel.get_company_details();
            return dtp;
        }
    }
}
