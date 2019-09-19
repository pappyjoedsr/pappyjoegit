using System.Data;

namespace PappyjoeMVC.Model
{
    public class Staff_model
    {
        Connection db = new Connection();
        public DataTable dtb_staff()
        {
            DataTable dtb = db.table("select id,doctor_name,mobile_number,login_type,activate_login from tbl_doctor order by id");
            return dtb;
        }
        public DataTable Get_DctrDetails()
        {
            DataTable dtb = db.table("select id,doctor_name from tbl_doctor order by id");
            return dtb;
        }
        public DataTable Get_NotificationValue()
        {
            DataTable dtb = db.table("SELECT tbl_doctor.id, tbl_doctor.doctor_name, tbl_doctors_notification.confirm_sms, tbl_doctors_notification.schedule_sms, tbl_doctors_notification.confirm_email,  tbl_doctors_notification.schedule_email FROM tbl_doctor INNER JOIN tbl_doctors_notification ON tbl_doctor.id = tbl_doctors_notification.dr_id");
            return dtb;
        }
        public DataTable Get_Dctr_Notification(string idd)
        {
            DataTable doc = db.table("select * from tbl_doctors_notification where dr_id='" + idd + "'");
            return doc;
        }
        public DataTable dtb_ifexists_dctrnotification(string idd)
        {
            DataTable dtb = db.table("select * from tbl_doctors_notification where dr_id='" + idd + "'");
            return dtb;
        }

        public void Update_Notification(DataTable dtb, string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + dtb.Rows[0]["dr_id"].ToString() + "',confirm_sms='1',schedule_sms='" + dtb.Rows[0]["schedule_sms"].ToString() + "',confirm_email='" + dtb.Rows[0]["confirm_email"].ToString() + "',schedule_email='" + dtb.Rows[0]["schedule_email"].ToString() + "'where dr_id='" + idd + "'");
        }
        public void Save_Notification(string idd)
        {
            int j = db.execute("insert into tbl_doctors_notification (dr_id, confirm_sms, schedule_sms, confirm_email, schedule_email) values('" + idd + "','1','0','0','0')");
        }
        public void update_confirm_sms(DataTable dtb, string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + dtb.Rows[0]["dr_id"].ToString() + "',confirm_sms='0',schedule_sms='" + dtb.Rows[0]["schedule_sms"].ToString() + "',confirm_email='" + dtb.Rows[0]["confirm_email"].ToString() + "',schedule_email='" + dtb.Rows[0]["schedule_email"].ToString() + "'where dr_id='" + idd + "'");
        }
        public void update_shedule_sms1(DataTable dtb, string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + dtb.Rows[0]["dr_id"].ToString() + "',confirm_sms='" + dtb.Rows[0]["confirm_sms"].ToString() + "',schedule_sms='1',confirm_email='" + dtb.Rows[0]["confirm_email"].ToString() + "',schedule_email='" + dtb.Rows[0]["schedule_email"].ToString() + "'where dr_id='" + idd + "'");
        }
        public void save_shedule_sms(string idd)
        {
            int j = db.execute("insert into tbl_doctors_notification (dr_id, confirm_sms, schedule_sms, confirm_email, schedule_email) values('" + idd + "','0','1','0','0')");
        }
        public void update_shedule_sms0(DataTable dtb, string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + dtb.Rows[0]["dr_id"].ToString() + "',confirm_sms='" + dtb.Rows[0]["confirm_sms"].ToString() + "',schedule_sms='0',confirm_email='" + dtb.Rows[0]["confirm_email"].ToString() + "',schedule_email='" + dtb.Rows[0]["schedule_email"].ToString() + "'where dr_id='" + idd + "'");
        }
        public void update_confirm_email1(DataTable dtb, string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + dtb.Rows[0]["dr_id"].ToString() + "',confirm_sms='" + dtb.Rows[0]["confirm_sms"].ToString() + "',schedule_sms='" + dtb.Rows[0]["schedule_sms"].ToString() + "',confirm_email='1',schedule_email='" + dtb.Rows[0]["schedule_email"].ToString() + "'where dr_id='" + idd + "'");
        }
        public void save_confirm_email(string idd)
        {
            int j = db.execute("insert into tbl_doctors_notification (dr_id, confirm_sms, schedule_sms, confirm_email, schedule_email) values('" + idd + "','0','0','1','0')");
        }
        public void update_confirmemail0(DataTable dtb, string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + idd + "',confirm_sms='" + dtb.Rows[0]["confirm_sms"].ToString() + "',schedule_sms='" + dtb.Rows[0]["schedule_sms"].ToString() + "',confirm_email='0',schedule_email='" + dtb.Rows[0]["schedule_email"].ToString() + "'where dr_id='" + idd + "'");
        }
        public void update_shedule_email1(DataTable dtb, string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + idd + "',confirm_sms='" + dtb.Rows[0]["confirm_sms"].ToString() + "',schedule_sms='" + dtb.Rows[0]["schedule_sms"].ToString() + "',confirm_email='" + dtb.Rows[0]["confirm_email"].ToString() + "',schedule_email='1' where dr_id='" + idd + "'");
        }
        public void save_shedule_email(string idd)
        {
            int j = db.execute("insert into tbl_doctors_notification (dr_id, confirm_sms, schedule_sms, confirm_email, schedule_email) values('" + idd + "','0','0','0','1')");
        }
        public void update_shedule_email0(DataTable dtb, string idd)
        {
            int j = db.execute("update tbl_doctors_notification set dr_id='" + idd + "',confirm_sms='" + dtb.Rows[0]["confirm_sms"].ToString() + "',schedule_sms='" + dtb.Rows[0]["schedule_sms"].ToString() + "',confirm_email='" + dtb.Rows[0]["confirm_email"].ToString() + "',schedule_email='0' where dr_id='" + idd + "'");
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
        public string get_mailId(string email)
        {
            string mail = db.scalar("select doctor_name from tbl_doctor where email_id='" + email + "'");
            return mail;
        }
        public int Save_Staff(string _sname, string _mobile, string _email, string _registratn, string _color, string _status, string _stafftype, string _confirmpswd)
        {
            int i = db.execute("insert into tbl_doctor(doctor_name,mobile_number,email_id,registration_number,calendar_color,status,login_type,activate_login,password) values('" + _sname + "','" + _mobile + "','" + _email + "','" + _registratn + "','" + _color + "','" + _status + "','" + _stafftype + "','" + _status + "','" + _confirmpswd + "')");
            int j = db.execute("insert into tbl_login(username,password,type) values ('" + _email + "','" + _confirmpswd + "','" + _stafftype + "')");
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
