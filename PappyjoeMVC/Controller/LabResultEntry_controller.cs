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
        LabResultEntry_interface intr;
        common_model cmdl = new common_model();
        LabResultEntry_model mdl = new LabResultEntry_model();
        public LabResultEntry_controller(LabResultEntry_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void LoadResult(string patid,string wrkid)
        {
            DataTable dt = mdl.LoadResult(patid,wrkid);
            intr.LoadResult(dt);
        }
        public int rsltupdate(string rslts,string testid,string id,string rsltmainid)
        {
            int j = mdl.rsltupdate(rslts,testid,id,rsltmainid);
            return j;
        }

    }
}
