using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class dentalwork_controller
    {
        dentalwork_interface intr;
        common_model cm = new common_model();
        LabWorks_model lm = new LabWorks_model();
        dentalwork_model mdl = new dentalwork_model();
        public dentalwork_controller(dentalwork_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void labdata()
        {
            DataTable dt= mdl.labdata();
            intr.labdata(dt);
        }
        public void practicedetails()
        {
            DataTable dt = mdl.practicedetails();
            intr.practicedetails(dt);
        }
        public void smsinfo()
        {
            DataTable dt = lm.smsinfo();
            intr.smsinfo(dt);
        }
        public void Get_Patient_Details(string patid)
        {
            DataTable dt = cm.Get_Patient_Details(patid);
            intr.Get_Patient_Details(dt);
        }
        public void dentalwrk(string patid,string wrkid)
        {
            DataTable dt = mdl.dentalwrk(patid,wrkid);
            intr.dentalwrk(dt);
        }
        public void dentalproperty(string patid, string rsltmain)
        {
            DataTable dt = mdl.dentalproperty(patid, rsltmain);
            intr.dentalproperty(dt);
        }
        public int labupdate(string labname, string assign_date, string duedate, string patid,string id)
        {
            int j = mdl.labupdate(labname,assign_date,duedate,patid,id);
            return j;
        }
    }
}
