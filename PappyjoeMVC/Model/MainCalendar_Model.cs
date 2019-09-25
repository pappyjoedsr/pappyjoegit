using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
   public class MainCalendar_Model
    {
        Connection db = new Connection();
        public string appoinmt_permission(string doctor_id)
        {
            string i = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='APT' and Permission='AP'");
            return i;
        }
        public DataTable admin_appointments(DateTime startDateTime, DateTime startDateTime1)
        {
          DataTable dtb= db.table( "SELECT id,pt_name,start_datetime,plan_New_procedure ,status,EHR_status FROM tbl_appointment where start_datetime between  '" + Convert.ToDateTime(startDateTime).ToString("yyyy-MM-dd HH:mm") + "' AND '" + Convert.ToDateTime(startDateTime1).ToString("yyyy-MM-dd HH:mm") + "' ORDER BY start_datetime");
            return dtb;
        }
        public DataTable doctor_appointments(DateTime startDateTime, DateTime startDateTime1, string doctor_id)
        {
          DataTable dtb =db.table("SELECT id,pt_name,start_datetime,plan_New_procedure ,status,EHR_status FROM tbl_appointment where start_datetime between  '" + Convert.ToDateTime(startDateTime).ToString("yyyy-MM-dd HH:mm") + "' AND '" + Convert.ToDateTime(startDateTime1).ToString("yyyy-MM-dd HH:mm") + "' AND dr_id='" + doctor_id + "' ORDER BY start_datetime");
            return dtb;
        }
        public DataTable all_dctr_appointment()
        {
          DataTable strSql = db.table( "SELECT id,start_datetime,duration,pt_id,pt_name,dr_id,status FROM tbl_appointment  ORDER BY id");
            return strSql;
        }//SELECT id,start_datetime,duration,pt_id,pt_name,dr_id FROM tbl_appointment ORDER BY id
        public DataTable get_dctr_wise_appointment(string doctor_id)
        {
            DataTable strSql =db.table( "SELECT id,start_datetime,duration,pt_id,pt_name,dr_id,status FROM tbl_appointment where  dr_id=" + doctor_id + " ORDER BY id");
            return strSql;
        }// DataTable dt = db.table("SELECT id,start_datetime,duration,pt_id,pt_name,dr_id FROM tbl_appointment where dr_id=" + dataGridViewdoctor.Rows[dataGridViewdoctor.CurrentCell.RowIndex].Cells[2].Value.ToString() + " ORDER BY id");
        public string get_calendar_color(string dr_id)
        {
            string drt = db.scalar("SELECT calendar_color FROM tbl_doctor where id=" + dr_id + " ORDER BY id");
            return drt;
        }
        public DataTable get_doctr(string doctor_id)
        {
          DataTable str_sql =db.table( "SELECT id,doctor_name,calendar_color FROM tbl_doctor Where id = " + doctor_id + " and activate_login='yes'");
            return str_sql;
        }
        public DataTable load_all_doctor()
        {
            DataTable str_sql =db.table( "SELECT id,doctor_name,calendar_color FROM tbl_doctor Where (login_type='doctor' or login_type='admin') and activate_login='yes'");
            return str_sql;
        }
        public string contactnumber()
        {
            string clinicname = db.scalar("select name,contact_no from tbl_practice_details");
            return clinicname;
        }
        public string get_slot()
        {
            string tb_slot = db.scalar("select slot from tbl_practice_timings");
            return tb_slot;
        }
        public string permission_for_add(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='APT' and Permission='A'");
            return id;
        }
        public string permission_for_edit(string doctor_id)
        {
          string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='APT' and Permission='E'");
            return id;
        }
        public string permission_for_delete(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='APT' and Permission='D'");
            return id;
        }
        public void delete_appointment(string ContextEvent)
        {
             db.execute("delete from tbl_appointment where id='" + ContextEvent + "'");
        }
        public void update_appointment_status(string ContextEvent)
        {
           db.execute("update tbl_appointment set status='CANCELLED'  where id='" + ContextEvent + "'");
        }
        //public DataTable get_sms_details()
        //{
        //    DataTable sms = db.table("select smsName,smsPass from tbl_SmsEmailConfig");
        //    return sms;
        //}
        public DataTable get_patient_details(string ContextEvent)
        {
            DataTable tl_appoitment = db.table("select pt_id,mobile_no,plan_new_procedure,pt_name from tbl_appointment where id='" +ContextEvent + "'");
            return tl_appoitment;
        }
        public void insert_sms(string pt_id, string pt_name,string procedure,string doctor)
        {
            db.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + pt_id + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm") + "','patient','sent','Dear " + pt_name + " " + " Your appointment for " + procedure + " has been cancelled..  Regards " + doctor + "')");
        }
        public DataTable get_appointment_details(string HitTest)
        {
            DataTable dt = db.table("SELECT id,start_datetime,duration,pt_id,pt_name,dr_id,booked_by,plan_new_procedure,note FROM tbl_appointment where id=" + HitTest + " ORDER BY id");
            return dt;
        }
        public DataTable patient_details(string id)
        {
            DataTable pt = db.table("SELECT pt_id,primary_mobile_number FROM tbl_patient where id=" + id + " ORDER BY id");
            return pt;
        }
        public void update_appointment_statrdatetime(string start_datetime, string totalTime,string id)
        {
            int j = db.execute("update tbl_appointment set start_datetime='" + Convert.ToDateTime(start_datetime) + "',duration='" + totalTime + "' where id='" + id + "'");
        }
        public void update_appointment_status_checkin(string Timeonly, string id)
        {
            int j = db.execute("update tbl_appointment set status='Check in',schedule='" + Timeonly + "',waiting='" + Timeonly + "' where id='" + id + "'");
        }
        public void update_appointment_status_engaged(string Timeonly, string id)
        {
            int j = db.execute("update tbl_appointment set status='Engage',engaged='" + Timeonly + "' where id='" + id + "'");
        }
        public void update_appointment_status_checkout(string Timeonly, string id)
        {
            int j = db.execute("update tbl_appointment set status='Checked Out',checkout='" + Timeonly + "' where id='" + id + "'");
        }
        public string inventory_privillage(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='INVENTORY' and Permission='A'");
            return id;
        }
        public DataTable get_pat_for_simpleappoint(string id1)
        {
            DataTable dtdr = db.table("SELECT pt_id,pt_name,id,book_datetime from tbl_appointment where id='" + id1 + "'");
            return dtdr;
        }
    }
}//select id from tbl_User_Privilege where UserID = " + doctor_id + " and Category='APT' and Permission='A'
