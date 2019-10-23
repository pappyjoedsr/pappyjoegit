using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
   public class Consultation_controller
    {
        Consultation_model model = new Consultation_model();
        public DataTable search_patient(string search)
        {
            DataTable dtb = model.search_patient(search);
            return dtb;
        }
        public DataTable patient_details(string value)
        {
            DataTable dtb = model.patient_details(value);
            return dtb;
        }
        public DataTable search_procedure(string search)
        {
            DataTable dtb = model.search_procedure(search);
            return dtb;
        }














    }
}
