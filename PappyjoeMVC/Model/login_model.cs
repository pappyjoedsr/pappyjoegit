using System.Data;
namespace PappyjoeMVC.Model
{
    public class Login_model
    {
        Connection db = new Connection();
        private string _uname = "";
        public string Username
        {
            get { return _uname; }
            set { _uname = value; }
        }
        private string paswrd = "";
        public string Password
        {
            get { return paswrd; }
            set { paswrd = value; }
        }
        public DataTable GetActivation()
        {
            DataTable choice = db.table("select * from tbl_activation");
            return choice;
        }
        public void update_activation()
        {
            db.execute("UPDATE tbl_activation set registrationdate=NULL,hexacode=NULL,actcode='0'");
        }
        public DataTable Get_userdetails()
        {
            DataTable sd = db.table("select * from tbl_login where username  ='" + _uname + "'and password  ='" + paswrd + "'");
            return sd;
        }
        public DataTable Get_Doctor_Activation()
        {
            DataTable doctor = db.table("select id,doctor_name,activate_login from tbl_doctor where email_id='" + _uname + "' and password='" + paswrd + "'");
            return doctor;
        }
        public DataTable Get_smsconfig()
        {
            DataTable sms = db.table("select smsName,smsPass,emailName,emailPass from tbl_SmsEmailConfig");
            return sms;
        }
    }
}
