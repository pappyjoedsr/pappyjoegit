using System;
using System.Data;

namespace PappyjoeMVC.Model
{
    public class Communication_model
    {
        Connection db = new Connection();
        public int Save_data(string tmplate)
        {
            int i = db.execute("insert  into tbl_templates(template) values('" + tmplate + "')");
            return i;
        }
        public int inssms(string patntid, string msg)
        {
            int i = db.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + patntid + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','patient','sent','" + msg + "')");
            return i;
        }
        public int insbrthsms(string patntid, string msg)
        {
            int i = db.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + patntid + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','patient','sent','" + msg + "')");
            return i;
        }
        public int insmsstaff(string patntid, string msg)
        {
            int i = db.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + patntid + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','staff','sent','" + msg + "')");
            return i;
        }
        public int insmsgrp(string patntid, string msg)
        {
            int i = db.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + patntid + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','group','sent','" + msg + "')");
            return i;
        }
        //sms centre

        public DataTable selsms()
        {
            DataTable dt = db.table("select smsName,smsPass from tbl_SmsEmailConfig");
            return dt;
        }
        public DataTable selgrp()
        {
            DataTable dt = db.table("select tbl_pt_group.pt_id,tbl_pt_group.group_id,tbl_patient.pt_name,tbl_patient.primary_mobile_number from tbl_pt_group inner join tbl_patient on tbl_pt_group.pt_id=tbl_patient.id");
            return dt;
        }
        public DataTable selecttemp()
        {
            DataTable dt = db.table("select * from tbl_templates");
            return dt;
        }
        public DataTable back()
        {
            DataTable dt = db.table("select pt_id,pt_name,primary_mobile_number from tbl_patient where primary_mobile_number <> '' and  Profile_Status !='Cancelled'");
            return dt;
        }
        public DataTable LoadData()
        {
            DataTable dt = db.table("select pt_id,pt_name,primary_mobile_number from tbl_patient where primary_mobile_number <> '' and  Profile_Status !='Cancelled'");
            return dt;
        }
        public DataTable LoadGrp()
        {
            DataTable dt = db.table("select name,id from tbl_group");
            return dt;
        }
        public DataTable LoadStaff()
        {
            DataTable dt = db.table("select  id,doctor_name,mobile_number from tbl_doctor where login_type ='staff'");
            return dt;
        }
        public DataTable Staffback()
        {
            DataTable dt = db.table("select  id,doctor_name,mobile_number from tbl_doctor where login_type ='staff'");
            return dt;
        }
        public DataTable srch(string pname)
        {
            DataTable dt = db.table("select pt_id,pt_name,primary_mobile_number from tbl_patient where pt_name like '" + pname + "%' and  primary_mobile_number <> '' and Profile_Status !='Cancelled'");
            return dt;
        }
        public DataTable srchstaff(string dname)
        {
            DataTable dt = db.table("select id,doctor_name,mobile_number from tbl_Doctor where doctor_name like '" + dname + "%' and  mobile_number <> '' and login_type ='staff'");
            return dt;
        }
        //delivery report
        public DataTable status(string stime, string etime)
        {
            DataTable dt = db.table("select S.message_status,P.pt_id,P.pt_name,S.message,S.send_datetime from tbl_pt_sms_communication S INNER JOIN tbl_patient P ON S.pt_id=P.id where S.send_datetime between '" + stime + "' and '" + etime + "'");
            return dt;
        }
        public string failcount(string stime, string etime)
        {
            string t = db.scalar("select count(*) from tbl_pt_sms_communication where send_datetime between '" + stime + "' and '" + etime + "' and message_status='failure'  group by message_status");
            return t;
        }
        public string smscount(string stime, string etime)
        {
            string dt = db.scalar("select count(*) from tbl_pt_sms_communication where send_datetime between '" + stime + "' and '" + etime + "' and message_status='sent' group by message_status");
            return dt;
        }
        //end
        //upcoming followup and birthday wish
        public DataTable upfollowup(string stime, string etime)
        {
            DataTable dt = db.table("select P.pt_id as 'PATIENT ID',P.pt_name as 'PATIENT NAME',mobile_no as 'MOBILE NO',start_datetime as 'APPOINTMENT DATE' from tbl_appointment A inner join tbl_patient P on  P.id=A.pt_id where book_datetime between'" + stime + "' and '" + etime + "'");
            return dt;
        }
        public DataTable upbirthday(string smonth, string sday, string emonth, string eday)
        {
            DataTable dt = db.table("select pt_id,pt_name,primary_mobile_number,date_of_birth from tbl_patient where (MONTH(date_of_birth) between'" + smonth + "' and'" + emonth + "') and (DAY(date_of_birth) between '" + sday + "'and '" + eday + "') and date_of_birth !='" + "" + "' ");
            return dt;
        }
        public DataTable birthdaytemp()
        {
            DataTable dt = db.table("select id,template from tbl_templates");
            return dt;
        }
        public string frmInventory(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='INVENTORY' and Permission='A'");
            return id;
        }
    }
}

