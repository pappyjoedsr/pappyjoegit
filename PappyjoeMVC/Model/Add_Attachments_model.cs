using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class Add_Attachments_model
    {
        Connection db = new Connection();
        public string selectdoctrid()
        {
            string dt = db.scalar("select id from tbl_doctor where login_type='admin'");
            return dt;
        }
        public string clinicname()
        {
            string e = db.scalar("select name from tbl_practice_details");
            return e;
        }
        public DataTable GetCategory()
        {
            DataTable dt = db.table("select * from tbl_AttachmentCategory");
            return dt;
        }
        public DataTable GetPatientDetails(string patntid)
        {
            DataTable dt = db.table("select pt_name,pt_id from tbl_patient where id='" + patntid+ "'");
            return dt;
        }
        public string GetPayment(string patntid)
        {
            string dt = db.scalar("select total_payment from tbl_invoices where pt_id='" + patntid + "'");
            return dt;
        }
        public string settingsprivilage(string doctrid)
        {
            string b = db.scalar("select id from tbl_User_Privilege where UserID=" + doctrid + " and Category='CLMS' and Permission='A'");
            return b;
        }
        public int insattach(string patientid, string imgname, string path,string doctrid,string catgryname)
        {
            int i = db.execute("insert into tbl_attachments(patient_id,photo_name,Path,dr_id,date,CategoryName)  values('" + patientid + "','" + imgname + "','" + path + "','" + doctrid + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + catgryname + "')");
            return i;
        }
    }
}
