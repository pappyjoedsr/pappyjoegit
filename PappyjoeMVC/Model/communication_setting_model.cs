using System.Data;

namespace PappyjoeMVC.Model
{
    public class Communication_Setting_model
    {
        Connection db = new Connection();
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
        public void update_sms(string _sms_uname, string _smspassword)
        {
            db.execute("update tbl_smsemailconfig set smsName='" + _sms_uname + "',smsPass='" + _smspassword+ "'");
        }
        public void save_sms(string _sms_uname, string _smspassword )
        {
            db.execute("insert into tbl_smsemailconfig (smsName,smsPass) values ('" + _sms_uname + "','" + _smspassword + "')");
        }
        public void update_email (string _emailuname, string _emailpaswsword)
        {
            db.execute("update tbl_smsemailconfig set emailName='" + _emailuname + "',emailPass='" + _emailpaswsword + "'");
        }
        public void Save_email(string _emailuname, string _emailpaswsword)
        {
            db.execute("insert into tbl_smsemailconfig (emailName,emailPass) values ('" + _emailuname + "','" + _emailpaswsword + "')");
        }
       
    }
}
