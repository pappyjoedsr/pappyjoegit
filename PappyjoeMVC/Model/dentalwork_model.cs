using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class Dentalwork_model
    {
        Connection db = new Connection();
        public DataTable labdata()
        {
            DataTable dt = db.table("Select id,labname from tbl_Laboratory");
            return dt;
        }
        public DataTable dentalwrk(string patid,string wrkid)
        {
            DataTable dt = db.table("select id,work_id,work_name,labname,assign_date,duedate from tbl_lab_main where pt_id='" + patid + "' and type='Dental' and id='" + wrkid + "'");
            return dt;
        }
        public DataTable dentalproperty(string patid, string rsltmain)
        {
            DataTable dt = db.table("select toothnumber,aloytype,shade,work_type from tbl_dentallabresult  where pt_id= '" + patid + "' and resultmain ='" + rsltmain + "'  ");
            return dt;
        }
        public int labupdate(string labname, string assign_date, string duedate, string patid, string id)
        {
            int j = db.execute("update tbl_lab_main set labname='" +labname+ "' , assign_date ='" +assign_date + "', duedate='" + duedate+ "', status='Sent',trackingstatus='Sent' where pt_id='" + patid + "' and id ='" +id+ "' ");
            return j;
        }
    }
}
