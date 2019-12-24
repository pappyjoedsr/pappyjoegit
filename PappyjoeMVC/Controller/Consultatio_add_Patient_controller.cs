using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
   public class Consultatio_add_Patient_controller
    {
        Consultation_model model = new Consultation_model();
        Add_New_Patient_model pmodel = new Add_New_Patient_model();
        public int save_patient(string pt_name, string pt_id, string gender, string primary_mobile_number)
        {
         int i=   model.save_patient(pt_name,  pt_id,  gender,  primary_mobile_number);
            return i;
        }
        public DataTable patient_maxid()
        {
            DataTable maxid = model.patient_maxid();
            return maxid;
        }
        public DataTable automaticid()
        {
            DataTable dtb = pmodel.automaticid();
            return dtb;
        }
        public void update_autogenerateid(int n)
        {
            pmodel.update_autogenerateid(n);
        }
        public DataTable data_from_automaticid()
        {
            DataTable dtb = pmodel.data_from_automaticid();
            return dtb;
        }
        public DataTable get_practice_details()
        {
            DataTable dtb = model.get_practice_details();
            return dtb;
        }
        public int save_patient_else(string txtpatname, string txtPatientId, string gender, string txtmobile, string txtxAge, string txtxStreet, string txtLocality, string txtCity, string txtFileNo, string ddldoctor)
        {
            int i = model.save_patient_else(txtpatname, txtPatientId, gender, txtmobile, txtxAge, txtxStreet, txtLocality, txtCity, txtFileNo, ddldoctor);
            return i; 
        }
        public DataTable select_patnt_num()
        {
            DataTable dt = model.select_patnt_num();
            return dt;
        }
        public int update_autoId(int n)
        {
            int i = model.update_autoId(n);
            return i;
        }
        public int med_hist(string id, string grmedical)
        {
            int i = model.med_hist(id, grmedical);
            return i;
        }
        public DataTable name_medhistory()
        {
            DataTable dt = model.name_medhistory();
            return dt;
        }
        public DataTable autom_id()
        {
            DataTable dt = model.autom_id();
            return dt;
        }
        public DataTable Load_doctor()
        {
            DataTable dt = model.Load_doctor();
            return dt;
        }
        public DataTable doc_info()
        {
            DataTable dt = model.doc_info();
            return dt;
        }
    }
}
