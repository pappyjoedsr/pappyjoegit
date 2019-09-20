using System.Data;
using System;
namespace PappyjoeMVC.Model
{
    public class Login_model
    {
        Connection db = new Connection();
       
        public DataTable GetActivation()
        {
            DataTable choice = db.table("select * from tbl_activation");
            return choice;
        }
        public void update_activation()
        {
            db.execute("UPDATE tbl_activation set registrationdate=NULL,hexacode=NULL,actcode='0'");
        }
        public DataTable Get_userdetails(string Username, string Password)
        {
            DataTable sd = db.table("select * from tbl_login where username  ='" + Username + "'and password  ='" + Password + "'");
            return sd;
        }
        public DataTable Get_Doctor_Activation(string Username, string Password)
        {
            DataTable doctor = db.table("select id,doctor_name,activate_login from tbl_doctor where email_id='" + Username + "' and password='" + Password + "'");
            return doctor;
        }
        public DataTable Get_smsconfig()
        {
            DataTable sms = db.table("select smsName,smsPass,emailName,emailPass from tbl_SmsEmailConfig");
            return sms;
        }
        public void delete_activation()
        {
            db.execute("DELETE from tbl_activation");
        }
        public void save_activation(string listgetcode, string listactcode, string lblhexcode)
        {
            int medi = db.execute("insert into tbl_activation(getcode,actcode,registrationdate,hexacode ) values('" + listgetcode + "','" + listactcode + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + lblhexcode + "')");
        }
        public void Save_activation_Null()
        {
            db.execute("insert into tbl_activation (getcode,actcode,registrationdate,hexacode) values('10','10',NULL,NULL)");
        }
    }
}
