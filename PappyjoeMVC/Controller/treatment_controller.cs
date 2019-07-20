using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class treatment_controller
    {
        treatment_interface intr;
        treatment_model _model = new treatment_model();
        common_model cmodel = new common_model();
        public treatment_controller(treatment_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
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
       
        public void get_treatments(string patient_id)
        {
            DataTable dtb = _model.Load_treatments(patient_id);
            intr.load_treatment(dtb);
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
    }
}
