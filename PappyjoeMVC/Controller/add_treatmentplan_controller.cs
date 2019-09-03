using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
  public class Add_Treatmentplan_controller
    {
        add_treatmentplan_interface intr;
        Add_Treatmentplan_model _Model=new Add_Treatmentplan_model();
        Common_model cmodel=new Common_model();
        Connection db = new Connection();
        public Add_Treatmentplan_controller(add_treatmentplan_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public DataTable get_ProcedureTreatment(string id)
        {
            DataTable dtb = _Model.get_ProcedureTreatment(id);
            return dtb;
        }
        public void check_procedurename()
        {
            _Model.AddProcedureName = intr.AddProcedureName;
            DataTable dtb = _Model.check_procedurename();
            intr.insertTreatment(dtb);
        }
        public void save_Procedure()
        {
            _Model.AddProcedureName = intr.AddProcedureName;
            _Model.ProcedureCost = intr.ProcedureCost;
            _Model.save_Procedure();
        }
        public string Procedure_maxid()
        {
            string s = _Model.Procedure_maxid();
            return s;
        }
        public DataTable Get_all_procedures()
        {
            DataTable dtb = _Model.Get_all_procedures();
            return dtb;
        }
        public void Save_treatment(string dr_id, string patient_id)
        {
            _Model.Date = intr.Date;
            _Model.Doctor = intr.Doctor;
            _Model.PatientName = intr.PatientName;
            _Model.TotalCost = intr.TotalCost;
            _Model.TotalDiscount = intr.TotalDiscount;
            _Model.GrandTotal = intr.GrandTotal;
            _Model.Save_treatment(dr_id, patient_id);
        }
        public DataTable get_treatmentmaxid()
        {
            DataTable dt = _Model.get_treatmentmaxid();
            return dt;
        }
        public void Save_treatmentgrid(int j, string procedure_id, string pt_id, string procedure_name, string quantity, string cost, string discount_type, string discount, string total, string discount_inrs, string note,string tooth)
        {
            _Model.Save_treatmentgrid(j, procedure_id , pt_id, procedure_name, quantity, cost, discount_type, discount, total, discount_inrs, note,tooth);
        }
        public DataTable Get_CompanyNAme()
        {
            DataTable dtb = cmodel.Get_CompanyNAme();
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
