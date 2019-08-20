using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Communication_controller
    {
        Communication_interface intr;
        Communication_model mdl = new Communication_model();
        common_model cmdl = new common_model();
        public Communication_controller(Communication_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void Get_CompanyNAme()
        {
            DataTable dt = cmdl.Get_CompanyNAme();
            intr.Get_CompanyNAme(dt);
        }
        public void Get_DoctorName(string id)
        {
            string dt = cmdl.Get_DoctorName(id);
            intr.Get_DoctorName(dt);
        }
        public void Patient_search(string txtbox)
        {
            DataTable dt = cmdl.Patient_search(txtbox);
            intr.Patient_search(dt);
        }
        //sms centre 
        public int insmsstaff()
        {
            mdl.patid = intr.patid;
            mdl.message = intr.message;
            int j = mdl.insmsstaff();
            return j;
        }
        public int inssmsgrp()
        {
            mdl.patid = intr.patid;
            mdl.message = intr.message;
            int k = mdl.insmsgrp();
            return k;
        }
        public int insbrthsms()
        {
            mdl.brthpid = intr.brthpid;
            mdl.message = intr.message;
            int s = mdl.insbrthsms();
            return s;
        }
       public void selgrp()
        {
            DataTable dt = mdl.selgrp();
            intr.selgrp(dt);
        }
       
        public void selsms()
        {
            DataTable dt = mdl.selsms();
            intr.selsms(dt);
        }
        public int inssms()
        {
            mdl.patid = intr.patid;
            mdl.message = intr.message;
            int j = mdl.inssms();
            return j;
        }
        public int Save()
        {
            mdl.template = intr.template;
            int i = mdl.Save_data();
            return i;
        }
        public void LoadData()
        {
            DataTable dt = mdl.LoadData();
            intr.LoadData(dt);
        } 
        public void selecttemp()
        {
            DataTable dt = mdl.selecttemp();
            intr.selecttemp(dt);
        }
        public void LoadGrp()
        {
            DataTable dt = mdl.LoadGrp();
            intr.LoadGrp(dt);
        }     
        public void LoadStaff()
        {
            DataTable dt = mdl.LoadStaff();
            intr.LoadStaff(dt);
        } 
        public void srch(string pname)
        {
            DataTable dt = mdl.srch(pname);
            intr.srch(dt);
        }
        public void srchstaff(string dname)
        {
            DataTable dt = mdl.srchstaff(dname);
            intr.srchstaff(dt);
        }
        public void back()
        {
            DataTable dt = mdl.back();
            intr.back(dt);
        }
        public void staffback()
        {
            DataTable dt = mdl.Staffback();
            intr.staffback(dt);
        }
        //end
        //delivery report
        public void status(string stime,string etime)
        {
            DataTable dt = mdl.status(stime, etime);
            intr.status(dt);
        }
        public void failcount(string stime, string etime)
        {
            DataTable dt = mdl.failcount(stime, etime);
            intr.failcount(dt);
        }
        public void smscount(string stime, string etime)
        {
            DataTable dt = mdl.smscount(stime, etime);
            intr.smscount(dt);
        }
        //end
        //upcoming followup and birthday wish
        public void upfollowup(string stime, string etime)
        {
            DataTable dt = mdl.upfollowup(stime, etime);
            intr.upfollowup(dt);
        }
        public void upbirthday(string smonth,string sday,string emonth,string eday)
        {
            DataTable dt = mdl.upbirthday(smonth, sday, emonth, eday);
            intr.upbirthday(dt);
        }
        public void birthdaytemp()
        {
            DataTable dt = mdl.birthdaytemp();
            intr.birthdaytemp(dt);
        }
       
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string dtb = cmdl.doctr_privillage_for_addnewPatient(doctor_id);
            return dtb;
        }
        public string permission_for_settings(string doctor_id)
        {
            string dtb = cmdl.permission_for_settings(doctor_id);
            return dtb;
        }
    }
}
