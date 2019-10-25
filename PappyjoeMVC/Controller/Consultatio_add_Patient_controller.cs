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
        public string patient_maxid()
        {
            string maxid = model.patient_maxid();
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
    }
}
