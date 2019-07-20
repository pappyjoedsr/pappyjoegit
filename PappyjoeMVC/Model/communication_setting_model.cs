using System.Data;

namespace PappyjoeMVC.Model
{
    public class communication_setting_model
    {
        Connection db = new Connection();
        private string _sms_uname = "";
        public string SMSUserName
        {
            get { return _sms_uname; }
            set { _sms_uname = value; }
        }
        private string _smspassword = "";
        public string SMSPassword
        {
            get { return _smspassword; }
            set { _smspassword = value; }
        }
        public string _emailuname = "";
        public string EmailUname
        {
            get {return _emailuname; }
            set { _emailuname = value; }
        }
        private string _emailpaswsword = "";
        public string EmailPassword
        {
            get { return _emailpaswsword; }
            set { _emailpaswsword = value; }
        }
            

        public DataTable getsmstabledata()
        {
            DataTable sms = db.table("select smsName,smsPass,emailName,emailPass from tbl_smsemailconfig");
            return sms;
        }
        public DataTable Getsmaname()
        {
            DataTable sms = db.table("select smsName,emailName from tbl_smsemailconfig");
            return sms;
        }
        public void update_sms()
        {
            db.execute("update tbl_smsemailconfig set smsName='" + _sms_uname + "',smsPass='" + _smspassword+ "'");
        }
        public void save_sms()
        {
            db.execute("insert into tbl_smsemailconfig (smsName,smsPass) values ('" + _sms_uname + "','" + _smspassword + "')");
        }
        public void update_email ()
        {
            db.execute("update tbl_smsemailconfig set emailName='" + _emailuname + "',emailPass='" + _emailpaswsword + "'");
        }
        public void Save_email()
        {
            db.execute("insert into tbl_smsemailconfig (emailName,emailPass) values ('" + _emailuname + "','" + _emailpaswsword + "')");
        }
       
    }
}
