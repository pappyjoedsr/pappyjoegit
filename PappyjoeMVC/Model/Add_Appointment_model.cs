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
        private string cname = "";
        public string clname
        {
            get { return cname; }
            set { cname = value; }
        }
        private string msg = "";
        public string message
        {
            get { return msg; }
            set { msg = value; }
        }
        private string p_name = "";
        public string pt_name
        {
            get { return p_name; }
            set { p_name = value; }
        }
        private string p_mobile = "";
        public string pt_mobile
        {
            get { return p_mobile; }
            set { p_mobile = value; }
        }
        private string p_email = "";
        public string pt_email
        {
            get { return p_email; }
            set { p_email = value; }
        }
        private DateTime stime;
        public DateTime start_date
        {
            get { return stime; }
            set { stime = value; }
        }
        private DateTime btime;
        public DateTime book_datetime
        {
            get { return btime; }
            set { btime = value; }
        }
        private string dur = "";
        public string duration
        {
            get { return dur; }
            set { dur = value; }
        }
        private string not = "";
        public string note
        {
            get { return not; }
            set { not = value; }
        }
        private string procedure = "";
        public string plan_new_procedure
        {
            get { return procedure; }
            set { procedure = value; }
        }
        private string booked = "";
        public string booked_by
        {
            get { return booked; }
            set { booked = value; }
        }
        private string loclty = "";
        public string locality
        {
            get { return loclty; }
            set { loclty = value; }
        }
        private string cntactno = "";
        public string contactno
        {
            get { return cntactno; }
            set { cntactno = value; }
        }
        private string patid="";
        public string patient_id
        {
            get { return patid; }
            set { patid = value; }
        }
        private int apntid=0;
        public int appointment_id
        {
            get { return apntid; }
            set { apntid = value; }
        }
        private string d_id = "";
        public string dr_id
        {
            get { return d_id; }
            set { d_id = value; }
        }
        public DataTable clinicdetails()
        {
            DataTable dt = c.table("select Name,locality,contact_no from tbl_practice_details");
            return dt;
        }
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
        public DataTable getdays(string patid)
        {
            DataTable dt = c.table("select * from tbl_patient where id='" + patid + "'");
            return dt;
        }
        public DataTable get_All_proceure()
        {
            DataTable dt3 = c.table("select DISTINCT id,name from tbl_addproceduresettings");
            return dt3;
        }
        public DataTable dt_appointment(string apid)
        {
            DataTable dt3 = c.table("select  start_datetime,duration,note,dr_id,plan_new_procedure from tbl_appointment  where id='" + apid + "'");
            return dt3;
        }
        public string getapid()
        {
           string e = c.scalar("select tbl_appointment.id from tbl_appointment inner join tbl_patient on tbl_patient.id=tbl_appointment.pt_id");
            return e;
        }
        public DataTable getdocid(string d)
        {
            DataTable dt3 = c.table("select doctor_name from tbl_doctor where id='" +d + "' and login_type='doctor' or login_type='admin' and activate_login='yes' ");
            return dt3;
        }
        public DataTable getappointment()
        {
           DataTable dt= c.table("select calendar_color,doctor_name,mobile_number,email_id from tbl_doctor where  id=" + dr_id + " ORDER BY id");
            return dt;
        }
        public int update(string apid)
        {
            int i = c.execute("update  tbl_appointment SET start_datetime='" + Convert.ToDateTime(start_date).ToString("yyyy-MM-dd HH:mm") + "',duration='" +dur + "',note='" +not + "',dr_id ='" + dr_id + "',plan_new_procedure='" + procedure + "',booked_by='" + booked + "' WHERE id='" + apid+ "'");
            return i;
        }
        public int insappointment()
        {
            int i = c.execute("insert into tbl_appointment (book_datetime,start_datetime,duration,note,pt_id,pt_name,dr_id,mobile_no,email_id,notify_patient,notify_doctor,plan_new_procedure,status,booked_by ) values('" + Convert.ToDateTime(book_datetime).ToString("yyyy-MM-dd HH:mm") + "','" + Convert.ToDateTime(start_date).ToString("yyyy-MM-dd HH:mm") + "','" +dur + "','" + not + "','" + patient_id + "','" + pt_name + "','" + dr_id + "','" + pt_mobile + "','" + pt_email + "','yes','yes','" + procedure + "','scheduled','" + booked + "')");
            return i;
        }
        public int inssms()
        {
            int i = c.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + patient_id + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm") + "','patient','sent','"+message+"' )");
            return i;
        }
    }
}
