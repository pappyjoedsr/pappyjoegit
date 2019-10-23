using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
  public class Consultation_model
  {
        Connection db = new Connection();
        public DataTable search_patient(string search)
        {
            DataTable dtdr = db.table("select pt_id,pt_name from tbl_patient where pt_name like '%" + search + "%'  ");
            return dtdr;
        }
        public DataTable patient_details(string value)
        {
            DataTable patient = db.table("select id, pt_name,pt_id from tbl_patient where pt_id='" + value + "'");
            return patient;
        }
        public DataTable search_procedure(string search)
        {
            DataTable dtdr = db.table("select id,name from tbl_addproceduresettings where name like '%" + search + "%'  ");
            return dtdr;
        }



  }
}
