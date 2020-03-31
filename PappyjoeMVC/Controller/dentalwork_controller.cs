using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Dentalwork_controller
    {
        Common_model cm = new Common_model();
        LabWorks_model lm = new LabWorks_model();
        SMS_model s = new SMS_model();
        Dentalwork_model mdl = new Dentalwork_model();
        public DataTable labdata()
        {
            DataTable dt= mdl.labdata();
            return dt;
        }
        public DataTable practicedetails()
        {
            DataTable dt = cm.practicedetails();
            return dt;
        }
        public DataTable smsinfo()
        {
            DataTable dt = lm.smsinfo();
            return dt;
        }
        public DataTable Get_Patient_Details(string patid)
        {
            DataTable dt = cm.Get_Patient_Details(patid);
            return dt;
        }
        public DataTable dentalwrk(string patid,string wrkid)
        {
            DataTable dt = mdl.dentalwrk(patid,wrkid);
            return dt;
        }
        public DataTable dentalproperty(string patid, string rsltmain)
        {
            DataTable dt = mdl.dentalproperty(patid, rsltmain);
            return dt;
        }
        public int labupdate(string labname, string assign_date, string duedate, string patid,string id)
        {
            int j = mdl.labupdate(labname,assign_date,duedate,patid,id);
            return j;
        }
        public string SendSMS(string User, string password, string Mobile_Number, string Message,string type)
        {
            string val = s.SendSMS(User, password, Mobile_Number, Message,type);
            return val;
        }
    }
}
