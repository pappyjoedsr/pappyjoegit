using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class Communication_model
    {
        Connection c = new Connection();
        private string grpid = "";
        public string groupid
        {
            get { return grpid; }
            set { grpid = value; }
        }
        private string bpid = "";
        public string brthpid
        {
            get { return bpid; }
            set { bpid = value; }
        }
        private string pid = "";
        public string patid
        {
            get { return pid; }
            set { pid = value; }
        }
        private string msg = "";
        public string message
        {
            get { return msg; }
            set { msg = value; }
        }
        private string temp = "";
        public string template
        {
            get { return temp; }
            set { temp = value; }
        }
        public int Save_data()
        {
            int i = c.execute("insert  into tbl_templates(template) values('" + temp + "')");
            return i;
        }
        public int inssms()
        {
            int i = c.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + patid + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','patient','sent','" + message + "')");
            return i;
        }
        public int insbrthsms()
        {
            int i = c.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + brthpid + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','patient','sent','" + message + "')");
            return i;
        }
        public int insmsstaff()
        {
            int i = c.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + patid + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','staff','sent','" + message + "')");
            return i;
        }
        public int insmsgrp()
        {
            int i = c.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + patid + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','group','sent','" + message + "')");
            return i;
        }
        private string dname = "";
        public string doctorname
        {
            get { return dname; }
            set { dname = value; }
        }
        private string gname = "";
        public string nameg
        {
            get { return gname; }

            set { gname = value; }
        }
        private string pname = "";
        public string patientname
        {
            get
            { return pname; }
            set
            { pname = value; }
        }
        private string mobno = "";
        public string mobileno
        {
            get
            { return mobno; }
            set
            { mobno = value; }
        }
        private string stime = "";
        public string starttime
        {
            get
            { return stime; }
            set
            { stime = value; }
        }
        private string etime = "";
        public string endtime
        {
            get
            { return etime; }
            set
            {
                etime = value;
            }
        }
        private string smonth = "";
        public string startmonth
        {
            get
            { return smonth; }
            set
            {
                smonth = value;
            }
        }
        private string sday = "";
        public string startday
        {
            get
            { return sday; }
            set
            {
                sday = value;
            }
        }
        private string emonth = "";
        public string endmonth
        {
            get
            { return emonth; }
            set
            {
                emonth = value;
            }
        }
        private string eday = "";
        public string endday
        {
            get
            { return eday; }
            set
            {
                eday = value;
            }
        }
        private string sname = "";
        public string smsname
        {
            get
            {
                return sname;
            }
            set
            {
                sname = value;
            }
        }
        private string spass = "";
        public string smspass
        {
            get
            {
                return spass;
            }
            set
            {
                spass = value;
            }
        }
        //sms centre

        public DataTable selsms()
        {
            DataTable dt = c.table("select smsName,smsPass from tbl_SmsEmailConfig");
            return dt;
        }
        public DataTable selgrp()
        {
            DataTable dt = c.table("select tbl_pt_group.pt_id,tbl_pt_group.group_id,tbl_patient.pt_name,tbl_patient.primary_mobile_number from tbl_pt_group inner join tbl_patient on tbl_pt_group.group_id=tbl_patient.group_id");
            return dt;
        }
        public DataTable selecttemp()
        {
            DataTable dt = c.table("select * from tbl_templates");
            return dt;
        }
        public DataTable back()
        {
            DataTable dt = c.table("select pt_id,pt_name,primary_mobile_number from tbl_patient where primary_mobile_number <> '' and  Profile_Status !='Cancelled'");
            return dt;
        }
        public DataTable LoadData()
        {
            DataTable dt = c.table("select pt_id,pt_name,primary_mobile_number from tbl_patient where primary_mobile_number <> '' and  Profile_Status !='Cancelled'");
            return dt;
        }
        public DataTable LoadGrp()
        {
            DataTable dt = c.table("select name,group_id from tbl_group");
            return dt;
        }

        public DataTable LoadStaff()
        {
            DataTable dt = c.table("select  id,doctor_name,mobile_number from tbl_doctor where login_type ='staff'");
            return dt;
        }
        public DataTable Staffback()
        {
            DataTable dt = c.table("select  id,doctor_name,mobile_number from tbl_doctor where login_type ='staff'");
            return dt;
        }
        public DataTable srch(string pname)
        {
            DataTable dt = c.table("select pt_id,pt_name,primary_mobile_number from tbl_patient where pt_name like '" + pname + "%' and  primary_mobile_number <> '' and Profile_Status !='Cancelled'");
            return dt;
        }
        public DataTable srchstaff(string dname)
        {
            DataTable dt = c.table("select id,doctor_name,mobile_number from tbl_Doctor where doctor_name like '" + dname + "%' and  mobile_number <> '' and login_type ='staff'");
            return dt;
        }
        //delivery report
        public DataTable status(string stime, string etime)
        {
            DataTable dt = c.table("select S.message_status,P.pt_id,P.pt_name,S.message,S.send_datetime from tbl_pt_sms_communication S INNER JOIN tbl_patient P ON S.pt_id=P.pt_id where S.send_datetime between '" + stime + "' and '" + etime + "'");
            return dt;
        }
        public DataTable failcount(string stime, string etime)
        {
            DataTable dt = c.table("select count(*) from tbl_pt_sms_communication where send_datetime between '" + stime + "' and '" + etime + "' and message_status='failure'  group by message_status");
            return dt;
        }
        public DataTable smscount(string stime, string etime)
        {
            DataTable dt = c.table("select count(*) from tbl_pt_sms_communication where send_datetime between '" + stime + "' and '" + etime + "' and message_status='Sent' group by message_status");
            return dt;
        }
        //end
        //upcoming followup and birthday wish
        public DataTable upfollowup(string stime, string etime)
        {
            DataTable dt = c.table("select P.pt_id as 'PATIENT ID',P.pt_name as 'PATIENT NAME',mobile_no as 'MOBILE NO',start_datetime as 'APPOINTMENT DATE' from tbl_appointment A inner join tbl_patient P on  P.pt_id=A.pt_id where book_datetime between'" + stime + "' and '" + etime + "'");
            return dt;
        }
        public DataTable upbirthday(string smonth, string sday, string emonth, string eday)
        {
            DataTable dt = c.table("select pt_id,pt_name,primary_mobile_number,date_of_birth from tbl_patient where (MONTH(date_of_birth) between'" + smonth + "' and'" + emonth + "') and (DAY(date_of_birth) between '" + sday + "'and '" + eday + "') and date_of_birth !='" + "" + "' ");
            return dt;
        }
        public DataTable birthdaytemp()
        {
            DataTable dt = c.table("select id,template from tbl_templates");
            return dt;
        }
    }
}

