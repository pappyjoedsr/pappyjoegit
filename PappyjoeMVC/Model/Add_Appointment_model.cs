using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class Add_Appointment_model
    {
        Connection c = new Connection();
        public DataTable smsreminder()
        {
            DataTable dt = c.table("select * from tbl_appt_reminder_sms");
            return dt;
        }
        public DataTable getpatdetails(string patid)
        {
            DataTable dt = c.table("select pt_name,pt_id,gender,primary_mobile_number,email_address from tbl_patient where id='" + patid + "'");
            return dt;
        }
        public DataTable get_All_procedure()
        {
            DataTable dt3 = c.table("select DISTINCT id,name from tbl_addproceduresettings");
            return dt3;
        }
        public DataTable dt_appointment(string appointmntid)
        {
            DataTable dt3 = c.table("select  start_datetime,duration,note,dr_id,plan_new_procedure from tbl_appointment  where id='" + appointmntid + "'");
            return dt3;
        }
        public DataTable getdoctrname(string doctrid)
        {
            DataTable dt3 = c.table("select doctor_name from tbl_doctor where id='" +doctrid + "' and login_type='doctor' and activate_login='yes' ");
            return dt3;
        }
        public DataTable getappointment(string doctrid)
        {
           DataTable dt= c.table("select calendar_color,doctor_name,mobile_number,email_id from tbl_doctor where  id=" + doctrid + " ORDER BY id");
            return dt;
        }
        public int apntupdate(string strtdatetime,string duratn,string note,string dr_id,string procedure,string bookedby,string appointmentid)
        {
            int i = c.execute("update  tbl_appointment SET start_datetime='" + strtdatetime + "',duration='" + duratn + "',note='" + note + "',dr_id ='" + dr_id + "',plan_new_procedure='" + procedure + "',booked_by='" + bookedby + "' WHERE id='" + appointmentid + "'");
            return i;
        }
        public int insappointment(string book_datetime, string start_datetime, string duration, string note, string pt_id, string pt_name, string dr_id, string mob_no, string email_id,string procedure,string booked_by)
        {
            int i = c.execute("insert into tbl_appointment (book_datetime,start_datetime,duration,note,pt_id,pt_name,dr_id,mobile_no,email_id,notify_patient,notify_doctor,plan_new_procedure,status,booked_by ) values('" + book_datetime + "','" + start_datetime + "','" +duration + "','" + note + "','" + pt_id + "','" + pt_name + "','" + dr_id + "','" +mob_no + "','" +email_id + "','yes','yes','" + procedure + "','scheduled','" + booked_by + "')");
            return i;
        }
        public int inssms(string pt_id,string send_datetime,string message)
        {
            int i = c.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + pt_id + "','" + send_datetime + "','patient','sent','"+message+"' )");
            return i;
        }
        public string settingsprivilage(string doctrid)
        {
            string b = c.scalar("select id from tbl_User_Privilege where UserID=" + doctrid + " and Category='CLMS' and Permission='A'");
            return b;
        }
        public DataTable smsdetails()
        {
            DataTable dt = c.table("select smsName,smsPass from tbl_SmsEmailConfig");
            return dt;
        }
    }
}
