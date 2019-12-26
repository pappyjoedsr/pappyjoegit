using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface Communication_interface
    {
        string patid { get; set; }
        string patname { get; set; }
        string docname { get; set; }
        string starttime { get; set; }
        string endtime { get; set; }
        string template { get; set; }
        string startmonth { get; set; }
        string startday { get; set; }
        string endmonth { get; set; }
        string endday { get; set; }
        string smsname{get;set;}
        string smspass{get;set;}
        string message { get; set; }
        string grpid { get; set; }
        string brthpid { get; set; }
        void Get_CompanyNAme(DataTable dt);
        void Get_DoctorName(string dt);
        void Patient_search(DataTable dt);
        void setController(Communication_controller controller);
        //sms centre
        void LoadData(DataTable dt);
        void LoadGrp(DataTable dt);
        void LoadStaff(DataTable dt);
        void srch(DataTable dt);
        void srchstaff(DataTable dt);
        void back(DataTable dt);
        void staffback(DataTable dt);
        void selecttemp(DataTable dt);
        void selsms(DataTable dt);
        void selgrp(DataTable dt);
        //end
        //delivery report
        void status(DataTable dt);
        void failcount(DataTable dt);
        void smscount(DataTable dt);
        //end
        //upcoming followup and birthday wish
       void upfollowup(DataTable dt);
       void upbirthday(DataTable dt);
       void birthdaytemp(DataTable dt); 
    }
}
