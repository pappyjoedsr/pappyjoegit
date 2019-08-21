using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Add_Vital_Signs_controller
    {
        Add_Vital_Signs_interface intr;
        Add_Vital_Signs_model _model = new Add_Vital_Signs_model();
        common_model model = new common_model();
        public string doctor_id = "0";
        public string staff_id = "0";
        public string patient_id = "0";
        public Add_Vital_Signs_controller(Add_Vital_Signs_interface inttr)
        {
            intr = inttr;
            intr.setcontroller(this);
        }
        public DataTable Get_CompanyNAme()
        {
            DataTable dt = model.Get_CompanyNAme();
            return dt;
        }
        public DataTable Get_DoctorName(string doctor_id)
        {
            DataTable d = model.Get_DoctorName(doctor_id);
            return d;
        }
        public DataTable Get_patient_id_name_gender(string patient_id)
        {
            DataTable d = model.Get_patient_id_name_gender(patient_id);
            return d;
        }
        public DataTable get_all_doctorname()
        {
            DataTable d = model.get_all_doctorname();
            return d;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string d = model.doctr_privillage_for_addnewPatient(doctor_id);
            return d;
        }
        public string permission_for_settings(string doctor_id)
        {
            string d = model.permission_for_settings(doctor_id);
            return d;
        }
        public DataTable Patient_search(string _Patientid)
        {
            DataTable d = model.Patient_search(_Patientid);
            return d;
        }
        public int submit(string patient_id, string dr_id, string doctor, string temp_type, string bp_type)
        {
            _model.bp = intr.bp;
            _model.bp_dias = intr.bp_dias;
            _model.date = intr.date;
            _model.height = intr.txtheight;
            _model.resp = intr.resp;
            _model.temp = intr.temp;
            _model.txtpulse = intr.txtpulse;
            _model.weight = intr.Weight;
            int i = _model.submit(patient_id,dr_id,doctor,temp_type,bp_type);
            return i;    
        }
    }
}
