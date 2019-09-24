using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Addfinsed_Treatment_controller
    {
        Add_Finished_Treatment_model _model = new Add_Finished_Treatment_model();
        Common_model cmodel = new Common_model();
        public DataTable Load_finishedtreatments(string patient_id)
        {
            DataTable dtb = _model.Load_finishedtreatments(patient_id);
            return dtb;
        }
        public string privilge_for_inventory(string doctor_id)
        {
            string s = cmodel.privilge_for_inventory(doctor_id);
            return s;
        }
        public DataTable load_proceduresgrid()
        {
            DataTable dt_pt = _model.load_proceduresgrid();
            return dt_pt;
        }
        public DataTable Load_treatmentPlans(string id)
        {
            DataTable dtb = _model.Load_treatmentPlans(id);
            return dtb;
        }
        public void save_procedure_plans(string name, string cost)
        {
            _model.save_procedure_plans(name, cost);
        }
        public string Get_max_procedureid()
        {
            string p = _model.Get_max_procedureid();
            return p;
        }
        public DataTable Search_procedure(string _search)
        {
            DataTable dtb = _model.Search_procedure(_search);
            return dtb;
        }
        public DataTable get_procedure_Name(string id)
        {
            DataTable dtb = _model.get_procedure_Name(id);
            return dtb;
        }
        public DataTable Get_treatment_details(string plan_p_id)
        {
            DataTable dtb = _model.Get_treatment_details(plan_p_id);
            return dtb;
        }
        public DataTable get_completed_id(string patient_id, string date)
        {
            DataTable dtb = _model.get_completed_id(patient_id, date);
            return dtb;
        }
        public void save_completed_id(string date, string patient_id)
        {
            _model.save_completed_id(date, patient_id);
        }
        public string get_completedMaxid()
        {
            string dtb = _model.get_completedMaxid();
            return dtb;
        }
        public void save_completed_items(int plan_main_id, string patient_id, string procedure_id, string procedure_name, string quantity, string cost, string discount_type, string discount, string total, string discount_inrs, string note, string date, string dr_id, string completed_id, string tooth)
        {
            _model.save_completed_items(plan_main_id, patient_id, procedure_id, procedure_name, quantity, cost, discount_type, discount, total, discount_inrs, note, date, dr_id, completed_id, tooth);
        }
        public void update_treatment_status(string id)
        {
            _model.update_treatment_status(id);
        }
        public void update_review(string date, int j_Review)
        {
            _model.update_review(date, j_Review);
        }
        public DataTable get_reviewid(string patient_id,string date1)
        {
            DataTable dtb = cmodel.get_reviewId(patient_id, date1);
            return dtb;
        }
        public void save_review(string date, string patient_id)
        {
            cmodel.save_review(date, patient_id);
        }
        public void save_appointment(string date, string patient_id, string pat_name, string dr_id, string Patient_mobile, string dr_name)
        {
            cmodel.save_appointment(date, patient_id, pat_name, dr_id, Patient_mobile, dr_name);
        }
        public void update_review_No(string date, int j_Review)
        {
            _model.update_review_No(date, j_Review);
        }
        public string Load_CompanyName()
        {
            string dtb = cmodel.Load_CompanyName();
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
        public string Get_DoctorName(string doctor_id)
        {
            string dtb = cmodel.Get_DoctorName(doctor_id);
            return dtb;
        }
        public DataTable get_all_doctorname()
        {
            DataTable dtb = cmodel.get_all_doctorname();
            return dtb;
        }
        public DataTable Get_Patient_Details(string id)
        {
            DataTable dtb = cmodel.Get_Patient_Details(id);
            return dtb;
        }
    }
}
