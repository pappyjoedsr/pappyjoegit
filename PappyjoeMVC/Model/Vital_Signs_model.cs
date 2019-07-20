using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
    public class Vital_Signs_model
    {
        Connection db = new Connection();
        public DataTable vital(string patient_id)
        {
            DataTable dt = db.table("select * from tbl_Vital_Signs where pt_id='" + patient_id + "' order by date DESC");
            return dt;
        }
    }
}
