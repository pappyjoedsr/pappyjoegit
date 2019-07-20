using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Common_controller
    {
        Connection db = new Connection();

        public DataTable Get_CompanyNAme()
        {
            DataTable clinicname = db.table("select name from tbl_practice_details");
            return clinicname;
        }
       public DataTable Get_DoctorId(string doctor_id)
        {
            DataTable docnam = db.table("select doctor_name from tbl_doctor Where id='" + doctor_id + "'");
            return docnam;
        }
    }
}
