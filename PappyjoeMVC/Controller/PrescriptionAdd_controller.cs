using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
    public class PrescriptionAdd_controller
    {
        prescriptionAdd_interface intr;
        common_model cmodel = new common_model();
        prescription_setting_model pmodel = new prescription_setting_model();
        prescription_model _model = new prescription_model();
        Inventory_model inmodel = new Inventory_model();
        //addfinsed_treatment_model fmodel = new addfinsed_treatment_model();
        public PrescriptionAdd_controller(prescriptionAdd_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public DataTable Get_CompanyNAme()
        {
            DataTable dtb = cmodel.Get_CompanyNAme();
            return dtb;
        }
        public DataTable Get_patient_id_name_gender(string patient_id)
        {
            DataTable dtb = cmodel.Get_patient_id_name_gender(patient_id);
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
        public DataTable Fill_unit_combo()
        {
            DataTable dtb = pmodel.Fill_unit_combo();
            return dtb;
        }
        public DataTable fill_type_combo()
        {
            DataTable dtb = pmodel.fill_type_combo();
            return dtb;
        }
        public DataTable getPrescriptionMain(string prescription_id, string ptid)
        {
            DataTable dtb = _model.getPrescriptionMain(prescription_id, ptid);
            return dtb;
        }
        public DataTable get_prescription_Data(string prescription_id, string ptid)
        {
            DataTable dtb = _model.get_prescription_Data(prescription_id, ptid);
            return dtb;
        }
        public DataTable drug_load()
        {
            DataTable dtb = _model.drug_load();
            return dtb;
        }
        public DataTable drug_instock(string id)
        {
            DataTable dtb = _model.drug_instock(id);
            return dtb;
        }
        public DataTable load_template()
        {
            DataTable dtb = _model.load_template();
            return dtb;
        }
        public string check_drugname(string name)
        {
            string dtb = pmodel.check_drugname(name);
            return dtb;
        }
        public void  Save_Drug(string name,string type,string unit,string strength,string instruction)
        {
            //pmodel.Drugname = name;
            //pmodel.StrType = type;
            //pmodel.StrUnit = unit;
            //pmodel.Strength_gr = strength;
            //pmodel.Instruction = instruction;
            pmodel.Save_Drug(name, type, unit, strength, instruction);
        }
        public DataTable Get_Stock(string id)
        {
            DataTable dtb = inmodel.Get_Stock(id);
            return dtb;
        }
        public DataTable drug_search(string search)
        {
            DataTable dtb = _model.drug_search(search);
            return dtb;
        }
        public DataTable search_template(string searchtext2)
        {
            DataTable dtb = _model.search_template(searchtext2);
            return dtb;
        }
        public DataTable ge_drug(string id1)
        {
            DataTable dtb = _model.ge_drug(id1);
            return dtb;
        }
        public DataTable get_template(string idtemp)
        {
            DataTable dtb = _model.get_template(idtemp);
            return dtb;
        }
        public string Get_DoctorId(string name)
        {
            string dtb = cmodel.Get_DoctorId(name);
            return dtb;
        }
        public DataTable get_inventoryid(string id)
        {
            DataTable dtb = _model.get_inventoryid(id);
            return dtb;
        }
        public void save_prescriptionmain(string ptid, string d_id, string date, string prescription_bill_status, string note)
        {
            _model.save_prescriptionmain(ptid,d_id,date,prescription_bill_status,note);
        }
        public DataTable Maxid()
        {
            DataTable dtb = _model.Maxid();
            return dtb;
        }
        public void save_prescription(int pres_id, string pt_id, string dr_name, string dr_id, string date, string drug_name, string strength, string strength_gr, string duration_unit, string duration_period, string morning, string noon, string night, string food, string add_instruction, string drug_type, string status, string drug_id)
        {
            _model.save_prescription(pres_id, pt_id, dr_name, dr_id, date, drug_name, strength, strength_gr, duration_unit, duration_period, morning, noon, night, food, add_instruction, drug_type, status, drug_id);
        }
        public void update_prescription_review(string date, int presid)
        {
            _model.update_prescription_review(date,presid);
        }
        public DataTable get_reviewId(string patient_id, string reviewdate)
        {
            DataTable dtb = cmodel.get_reviewId(patient_id,reviewdate);
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
        public void update_prescription_review_NO(string date, int presid)
        {
            _model.update_prescription_review_NO(date,presid);
        }
        public void update_prescription_main(string note, string Prescription_bill_status, string prescription_id)
        {
            _model.update_prescription_main(note, Prescription_bill_status, prescription_id);
        }
        public void delete_prescription(string prescription_id)
        {
            _model.delete_prescription(prescription_id);
        }
        public void save_template(string template)
        {
            _model.save_template(template);
        }
        public string get_templateid(string tempnametext)
        {
            string id = _model.get_templateid(tempnametext);
            return id;
        }
        public void save_template(string temp_id, string pt_id, string pt_name, string dr_id, string dr_name, string date, string drug_name, string strength, string strength_gr, string duration, string morning, string noon, string night, string food, string add_instruction, string drug_type, string drug_id, string pres_id, string duration_period, string status)
        {
            _model.save_template(temp_id, pt_id, pt_name, dr_id, dr_name, date, drug_name, strength, strength_gr, duration, morning, noon, night, food, add_instruction, drug_type, drug_id, pres_id, duration_period, status);
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
