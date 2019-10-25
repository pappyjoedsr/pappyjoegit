using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
  public class Consultation_prescription_template_controller
   {
        Consultation_model model = new Consultation_model();
        public DataTable get_tempid(string pres_id)
        {
            DataTable dtb = model.get_tempid(pres_id);
            return dtb;
        }
        public DataTable get_templateid(string presid)
        {
            DataTable dtb = model.get_templateid(presid);
            return dtb;
        }
    }
}
