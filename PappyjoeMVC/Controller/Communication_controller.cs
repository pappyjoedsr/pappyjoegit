using PappyjoeMVC.Model;
using System;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Communication_controller
    {
        SMS_model s = new SMS_model();
        Common_model cmdl = new Common_model();
        Communication_model mdl = new Communication_model();
        public DataTable Get_CompanyNAme()
        {
            DataTable dt = cmdl.Get_CompanyNAme();
            return dt;
        }
        public string SendSMS(string User, string password, string Mobile_Number, string Message,string type)
        {
            string val = s.SendSMS(User, password, Mobile_Number, Message,type);
            return val;
        }
        public string SendSMS(string User, string password, string Mobile_Number, string Message, string SID, string Sname, string scheduledDate, string systemdate)
        {
            string val = s.SendSMS(User, password, Mobile_Number, Message, SID, Sname, scheduledDate, systemdate);
            return val;
        }
        public string Get_DoctorName(string id)
        {
            string dt = cmdl.Get_DoctorName(id);
            return dt;
        }
        public DataTable Patient_search(string txtbox)
        {
            DataTable dt = cmdl.Patient_search(txtbox);
            return dt;
        }
        //sms centre 
        public int insmsstaff(string patntid, string msg)
        {
            int j = mdl.insmsstaff(patntid, msg);
            return j;
        }
        public int inssmsgrp(string patntid, string msg)
        {
            int k = mdl.insmsgrp(patntid, msg);
            return k;
        }
        public int insbrthsms(string patntid, string msg)
        {
            int s = mdl.insbrthsms(patntid, msg);
            return s;
        }
        public DataTable selgrp()
        {
            DataTable dt = mdl.selgrp();
            return dt;
        }
        public DataTable selsms()
        {
            DataTable dt = cmdl.smsdetails();
            return dt;
        }
        public int inssms(string patntid, string date, string msg)
        {
            int j = mdl.inssms(patntid, msg);
            return j;
        }
        public int Save(string tmplate)
        {
            int i = mdl.Save_data(tmplate);
            return i;
        }
        public DataTable LoadData()
        {
            DataTable dt = mdl.LoadData();
            return dt;
        }
        public DataTable selecttemp()
        {
            DataTable dt = mdl.selecttemp();
            return dt;
        }
        public DataTable LoadGrp()
        {
            DataTable dt = mdl.LoadGrp();
            return dt;
        }
        public DataTable LoadStaff()
        {
            DataTable dt = mdl.LoadStaff();
            return dt;
        }
        public DataTable srch(string pname)
        {
            DataTable dt = mdl.srch(pname);
            return dt;
        }
        public DataTable srchstaff(string dname)
        {
            DataTable dt = mdl.srchstaff(dname);
            return dt;
        }
        public DataTable staffback()
        {
            DataTable dt = mdl.Staffback();
            return dt;
        }
        //end
        //delivery report
        public DataTable status(string stime, string etime)
        {
            DataTable dt = mdl.status(stime, etime);
            return dt;
        }
        public string failcount(string stime, string etime)
        {
            string t = mdl.failcount(stime, etime);
            return t;
        }
        public string smscount(string stime, string etime)
        {
            string dt = mdl.smscount(stime, etime);
            return dt;
        }
        //end
        //upcoming followup and birthday wish
        public DataTable upfollowup(string stime, string etime)
        {
            DataTable dt = mdl.upfollowup(stime, etime);
            return dt;
        }
        public DataTable upbirthday(string smonth, string sday, string emonth, string eday)
        {
            DataTable dt = mdl.upbirthday(smonth, sday, emonth, eday);
            return dt;
        }
        public DataTable birthdaytemp()
        {
            DataTable dt = mdl.birthdaytemp();
            return dt;
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
        public string frmInventory(string doctor_id)
        {
            string s = mdl.frmInventory(doctor_id);
            return s;
        }
        public int delete(string id)
        {
            int i = mdl.delete(id);
            return i;
        }
        public int update_temp(string id, string temp)
        {
            int i = mdl.update_temp(id,temp);
            return i;
        }
    }
}
