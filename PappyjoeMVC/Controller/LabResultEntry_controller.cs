using PappyjoeMVC.Model;
using PappyjoeMVC.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class LabResultEntry_controller
    {
        Common_model cmdl = new Common_model();
        LabResultEntry_model mdl = new LabResultEntry_model();
        public DataTable LoadResult(string patid,string wrkid)
        {
            DataTable dt = mdl.LoadResult(patid,wrkid);
            return dt;
        }
        public int rsltupdate(string rslts,string testid,string id,string rsltmainid)
        {
            int j = mdl.rsltupdate(rslts,testid,id,rsltmainid);
            return j;
        }

    }
}
