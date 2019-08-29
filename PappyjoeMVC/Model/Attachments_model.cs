using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class Attachments_model
    {
        Connection c = new Connection();
        public string selid(string uid)
        {
            string i = c.scalar("select id from tbl_User_Previlege where UserID=" + uid + " and Category='EMRF' and Permission='A'");
            return i;
        }
        public string getprevid(string id)
        {
            string e = c.scalar("select id from tbl_User_Previlege where UserID=" + id + " and Category='EMRF' and Permission='D'");
            return e;
        }
        public DataTable getattachment(string patntid)
        {
            DataTable dt = c.table("select dr_id,patient_id,CategoryName,date,photo_name,id,path from tbl_attachments where patient_id='" + patntid + "' order by date");
            return dt;
        }
        public int inscatgry(string catgryname)
        {
            int i = c.execute("insert into tbl_AttachmentCategory (CategoryName) values('" + catgryname + "')");
            return i;
        }
        public int update(string catgryname, string catgryid)
        {
            int i = c.execute("update tbl_AttachmentCategory set CategoryName='" + catgryname + "' where id='" + catgryid + "'");
            return i;
        }
        public DataTable getattachment2(string patntid, string catgryname)
        {
            DataTable dt = c.table("select dr_id,patient_id,CategoryName,date,photo_name,id,path from tbl_attachments where patient_id='" + patntid + "' and CategoryName='" + catgryname + "' order by date");
            return dt;
        }
        public int delete(string catgryid)
        {
            int j = c.execute("delete from tbl_AttachmentCategory where id='" + catgryid + "'");
            return j;
        }
        public int delattach(int attachid)
        {
            int p = c.execute("delete from tbl_attachments where id='" + attachid + "'");
            return p;
        }
        public string getpath(int attachid)
        {
            string dt = c.scalar("SELECT path FROM tbl_attachments WHERE id='" + attachid + "'");
            return dt;
        }
        public DataTable attach(int attachid)
        {
            DataTable dt = c.table("SELECT tbl_patient.pt_name,tbl_patient.pt_id,tbl_patient.age,tbl_attachments.photo_name,tbl_attachments.path FROM tbl_patient,tbl_attachments WHERE tbl_patient.id=tbl_attachments.patient_id AND tbl_attachments.id='" + attachid + "'");
            return dt;
        }
    }
}
