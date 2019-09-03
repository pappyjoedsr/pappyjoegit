using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public  class Finished_Procedre_controller
    {
        Finished_Procedure_interface intr;
        Add_Finished_Treatment_model _model = new Add_Finished_Treatment_model();
        Connection db = new Connection();
        Common_model cmodel = new Common_model();
        public Finished_Procedre_controller(Finished_Procedure_interface inttr)
        {
            intr = inttr;
            intr.Setcontroller(this);
        }
        public string Add_privilliege(string doctor_id)
        {
          string  privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRFP' and Permission='A'");
          return privid;
        }
        public string  edit_privillege(string doctor_id)
        {
           string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRFP' and Permission='E'");
            return privid;
        }
        public string delete_privillage(string doctor_id)
        {
          string  privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRFP' and Permission='D'");
          return privid;
        }
        public void get_completed_id_date(string patient_id)
        {
            DataTable dtb = _model.get_completed_id_date(patient_id);
            intr.Load_Data(dtb);
        }
        public DataTable get_completed_details(string mainid)
        {
            DataTable dtb = _model.get_completed_details(mainid);
            return dtb;
        }
        public DataTable get_plamManin_id(string treatment_complete_id)
        {
            DataTable dtb = _model.get_plamManin_id(treatment_complete_id);
            return dtb;
        }
        public void delete(string treatment_complete_id)
        {
            db.execute("delete from tbl_completed_procedures where id='" + treatment_complete_id + "'");
        }
        public void update_status1(string plan_main_id)
        {
            _model.update_status1(plan_main_id);
        }
        public DataTable chek_planmain_id(string completed_main_id)
        {
            DataTable dt_pt_complete2 = db.table("SELECT plan_main_id FROM tbl_completed_procedures  where plan_main_id='" + completed_main_id + "'");
            return dt_pt_complete2;
        }
        public void delete_completedid(string completed_main_id)
        {
            db.execute("delete from tbl_completed_id where id='" + completed_main_id + "'");
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
        public DataTable Get_Patient_id_NAme(string id)
        {
            DataTable dtb = cmodel.Get_Patient_id_NAme(id);
            return dtb;
        }
    }
}
