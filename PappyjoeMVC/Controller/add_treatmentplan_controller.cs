using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Add_Treatmentplan_controller
    {
        
        Add_Treatmentplan_model _Model = new Add_Treatmentplan_model();
        Common_model cmodel = new Common_model();
        Connection db = new Connection();
        Add_Finished_Treatment_model fmodel = new Add_Finished_Treatment_model();
        public DataTable get_ProcedureTreatment(string id)
        {
            DataTable dtb = _Model.get_ProcedureTreatment(id);
            return dtb;
        }
        public string privilge_for_inventory(string doctor_id)
        {
            string s = cmodel.privilge_for_inventory(doctor_id);
            return s;
        }
        public DataTable check_procedurename(string AddProcedureName)
        {
            DataTable dtb = _Model.check_procedurename(AddProcedureName);
            return dtb;
        }
        public void save_Procedure(string _addProcedurename, string _procedurecost)
        {
            _Model.save_Procedure( _addProcedurename,  _procedurecost);
        }
        public string Procedure_maxid()
        {
            string s = _Model.Procedure_maxid();
            return s;
        }
        public DataTable Get_all_procedures()
        {
            DataTable dtb = cmodel.get_All_proceure();
            return dtb;
        }
        public void Save_treatment(string dr_id, string patient_id, string _date, string _doctor, string _patientname, string _totalcost, string _totaldiscount, string _grandtotal)
        {
            _Model.Save_treatment( dr_id,  patient_id,  _date,  _doctor,  _patientname,  _totalcost,  _totaldiscount,  _grandtotal);
        }
        public string get_treatmentmaxid()
        {
            string dt = _Model.get_treatmentmaxid();
            return dt;
        }
        public void Save_treatmentgrid(int j, string procedure_id, string pt_id, string procedure_name, string quantity, string cost, string discount_type, string discount, string total, string discount_inrs, string note, string tooth)
        {
            _Model.Save_treatmentgrid(j, procedure_id, pt_id, procedure_name, quantity, cost, discount_type, discount, total, discount_inrs, note, tooth);
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
        public DataTable Search_procedure(string _search)
        {
            DataTable dtb = fmodel.Search_procedure(_search);
            return dtb;
        }
    }
}
