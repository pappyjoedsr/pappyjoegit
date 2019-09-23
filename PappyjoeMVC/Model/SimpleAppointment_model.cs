using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
    public class SimpleAppointment_model
    {
        Connection db = new Connection();
       public DataTable get_drug_details()
        {
            DataTable dt_prescription = db.table("select id,name, type, strength_gr, strength,inventory_id from tbl_adddrug ORDER BY id DESC");
            return dt_prescription;
        }
        public DataTable get_pt_details(string patient_id)
        {
            DataTable dtb = db.table("select id, pt_id,pt_name,primary_mobile_number,gender,age,street_address,locality,city,pincode from tbl_patient where id='" + patient_id + "'");
            return dtb;
        }
        public DataTable get_EHR_details(string strApp_id)
        {
            DataTable App_dtb = db.table("select EHR_status,EHR_clinicalfindings,EHR_treatment,EHR_prescription,EHR_invoice from tbl_appointment where id='" + strApp_id + "' AND EHR_status='YES'");
            return App_dtb;
        }
    }
}
