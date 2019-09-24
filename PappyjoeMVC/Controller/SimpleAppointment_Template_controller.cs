using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
   public class SimpleAppointment_Template_controller
    {
        Common_model cmodel = new Common_model();
        Prescription_model pmodel = new Prescription_model();
        public DataTable get_all_doctorname()
        {
            DataTable dtb = cmodel.get_all_doctorname();
            return dtb;
        }
        public DataTable ge_drug(string id1)
        {
            DataTable dtb = pmodel.ge_drug(id1);
            return dtb;
        }
        public void save_template(string template)
        {
            pmodel.save_template(template);
        }
        public string get_templateid(string tempnametext)
        {
            string name = pmodel.get_templateid(tempnametext);
            return name;
        }
        public void save_template(string temp_id, string pt_id, string pt_name, string dr_id, string dr_name, string date, string drug_name, string strength, string strength_gr, string duration, string morning, string noon, string night, string food, string add_instruction, string drug_type, string drug_id, string pres_id, string duration_period, string status)
        {
            pmodel.save_template(temp_id,  pt_id,  pt_name,  dr_id,  dr_name,  date,  drug_name,  strength,  strength_gr,  duration,  morning,  noon,  night,  food,  add_instruction,  drug_type,  drug_id,  pres_id,  duration_period,  status);
        }
        public DataTable get_drug_name()
        {
            DataTable dtb = pmodel.get_drug_name();
            return dtb;
        }
        public string get_patientname(string ptid)
        {
            string name = pmodel.get_patientname(ptid);
            return name;
        }
    }
}
