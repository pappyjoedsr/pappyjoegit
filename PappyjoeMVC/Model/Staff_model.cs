using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
    public class Staff_model
    {
        Connection db = new Connection();
        private string dr_id = "";
        public string DrID
        {
            get { return dr_id; }
            set { dr_id = value; }
        }
        private string _confirm_sms = "";
        public string confirm_sms
        {
            get { return _confirm_sms; }
            set { _confirm_sms = value; }
        }
        private string _schedule_sms = "";
        public string schedule_sms
        {
            get { return _schedule_sms; }
            set { _schedule_sms = value; }
        }
        private string _confirm_email = "";
        public string confirm_email
        {
            get { return _confirm_email; }
            set { _confirm_email = value; }
        }
        private string _schedule_email = "";
        public string schedule_email
        {
            get { return _schedule_email; }
            set { _schedule_email = value; }
        }
        //staff
        private string _stafftype = "";
        public string Staff_type
        {
            get { return _stafftype; }
            set { _stafftype = value; }
        }
        private string _sname = "";
        public string SName
        {
            get { return _sname; }
            set { _sname = value; }
        }
        private string _password = "";
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _confirmpswd = "";
        public string ConfirmPassword
        {
            get { return _confirmpswd; }
            set { _confirmpswd = value; }
        }
        private string _mobile = "";
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        private string _email = "";
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _registratn = "";
        public string Registration
        {
            get { return _registratn; }
            set { _registratn = value; }
        }
        private string _color = "";
        public string CColor
        {
            get { return _color; }
            set { _color = value; }
        }
        private string _activelogin = "";
        public string ActiveLogin
        {
            get { return _activelogin; }
            set { _activelogin = value; }
        }
        public DataTable dtb_staff()
        {
         DataTable dtb=db.table("select id,doctor_name,mobile_number,login_type,activate_login from tbl_doctor order by id");
            return dtb;
        }
        public DataTable Get_DctrDetails()
        {
            DataTable dtb= db.table("select id,doctor_name from tbl_doctor order by id");
            return dtb;
        }
        public DataTable Get_NotificationValue()
        {
            DataTable dtb= db.table("SELECT tbl_doctor.id, tbl_doctor.doctor_name, tbl_doctors_notification.confirm_sms, tbl_doctors_notification.schedule_sms, tbl_doctors_notification.confirm_email,  tbl_doctors_notification.schedule_email FROM tbl_doctor INNER JOIN tbl_doctors_notification ON tbl_doctor.id = tbl_doctors_notification.dr_id");
            return dtb;
        }
        public DataTable Get_Dctr_Notification(string idd)
        {
            DataTable doc = db.table("select * from tbl_doctors_notification where dr_id='" + idd + "'");
            return doc;
        }
        public DataTable dtb_ifexists_dctrnotification(string idd)
        {
          DataTable dtb= db.table("select * from tbl_doctors_notification where dr_id='" + idd + "'");
          return dtb;
        }

        public void Update_Notification(string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + dr_id + "',confirm_sms='1',schedule_sms='" + schedule_sms.ToString() + "',confirm_email='" + confirm_email.ToString() + "',schedule_email='" + schedule_email.ToString() + "'where dr_id='" + idd + "'");
        }
        public void Save_Notification(string idd)
        {
            int j = db.execute("insert into tbl_doctors_notification (dr_id, confirm_sms, schedule_sms, confirm_email, schedule_email) values('" + idd + "','1','0','0','0')");
        }
        public void update_confirm_sms(string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + idd + "',confirm_sms='0',schedule_sms='" + schedule_sms.ToString() + "',confirm_email='" + confirm_email.ToString() + "',schedule_email='" + schedule_email.ToString() + "'where dr_id='" + idd + "'");
        }
        public void update_shedule_sms1(string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + idd + "',confirm_sms='" + confirm_sms.ToString() + "',schedule_sms='1',confirm_email='" + confirm_email.ToString() + "',schedule_email='" + schedule_email.ToString() + "'where dr_id='" + idd + "'");
        }
        public void save_shedule_sms(string idd)
        {
            int j = db.execute("insert into tbl_doctors_notification (dr_id, confirm_sms, schedule_sms, confirm_email, schedule_email) values('" + idd + "','0','1','0','0')");
        }
        public void update_shedule_sms0(string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + idd + "',confirm_sms='" + confirm_sms.ToString() + "',schedule_sms='0',confirm_email='" + confirm_email.ToString() + "',schedule_email='" + schedule_email.ToString() + "'where dr_id='" + idd + "'");
        }
        public void update_confirm_email1(string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + idd + "',confirm_sms='" + confirm_sms.ToString() + "',schedule_sms='" + schedule_sms.ToString() + "',confirm_email='1',schedule_email='" + schedule_email.ToString() + "'where dr_id='" + idd + "'");
        }
        public void save_confirm_email(string idd)
        {
            int j = db.execute("insert into tbl_doctors_notification (dr_id, confirm_sms, schedule_sms, confirm_email, schedule_email) values('" + idd + "','0','1','0','0')");
        }
        public void update_confirmemail0(string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + idd + "',confirm_sms='" + confirm_sms.ToString() + "',schedule_sms='" + schedule_sms.ToString() + "',confirm_email='0',schedule_email='" + schedule_email.ToString() + "'where dr_id='" + idd + "'");
        }
        public void update_shedule_email1(string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + idd + "',confirm_sms='" + confirm_sms.ToString() + "',schedule_sms='" + schedule_sms.ToString() + "',confirm_email='" + confirm_email.ToString() + "',schedule_email='1' where dr_id='" + idd + "'");
        }
        public void save_shedule_email(string idd)
        {
            int j = db.execute("insert into tbl_doctors_notification (dr_id, confirm_sms, schedule_sms, confirm_email, schedule_email) values('" + idd + "','0','1','0','0')");
        }
        public void update_shedule_email0(string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + idd + "',confirm_sms='" + confirm_sms.ToString() + "',schedule_sms='" + schedule_sms.ToString() + "',confirm_email='" + confirm_email.ToString() + "',schedule_email='0' where dr_id='" + idd + "'");
        }

        public DataTable Get_DoctorId(string doctor_id)
        {
            DataTable d1 = db.table("select id,doctor_name,mobile_number,login_type from tbl_doctor where id='" + doctor_id + "'");
            return d1;
        }

        public DataTable User_privillage()
        {
            DataTable dtUserprivilege = db.table("select id,doctor_name as name,UPPER(login_type) as usertype from tbl_doctor where id !=1 ");
            return dtUserprivilege;
        }
        public void delete_userprivillage(string userid)
        {
            db.execute("delete from tbl_User_Privilege where userID= '" + userid + "'");
        }
        public void save_userprivillage(string strvalue1)
        {
            db.execute("insert into tbl_User_Privilege (UserID,Category,Permission) values " + strvalue1);
        }
        public DataTable get_userprivillageData(string userid)
        {
            DataTable dtUserprivilege = db.table("select Category,Permission from tbl_User_Privilege where UserID = '" + userid + "'");
            return dtUserprivilege;
        } 
       public DataTable get_mailId()
        {
            DataTable dtb= db.table("select doctor_name from tbl_doctor where email_id='gh' ");
            return dtb;
        }
        public int Save_Staff()
        {
         int i=db.execute("insert into tbl_doctor(doctor_name,mobile_number,email_id,registration_number,calendar_color,status,login_type,activate_login,password) values('" + _sname + "','" + _mobile + "','" + _email + "','" + _registratn + "','" + _color + "','" + _activelogin + "','" + _stafftype + "','" + _activelogin + "','" + _confirmpswd + "')");
         int j = db.execute("insert into tbl_login(username,password,type) values ('" + _email + "','" + _confirmpswd+ "','" + _stafftype + "')");
            return i;
        }
        public void update_loginstatus(string id)
        {
            db.execute("update tbl_doctor set activate_login='No' where id='" + id + "'");
        }
        public void update_loginstatus_Yes(string id)
        {
            db.execute("update tbl_doctor set activate_login='Yes' where id='" + id + "'");
        }
    }
}
