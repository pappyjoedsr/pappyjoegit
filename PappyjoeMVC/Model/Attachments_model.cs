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
        private string id = "";
        public string docid
        {
            get { return docid; }
            set { docid = value; }
        }
        private string pid = "";
        public string patid
        {
            get { return pid; }
            set { pid = value; }
        }
        private string catgryid = "";
        public string catid
        {
            get { return catgryid; }
            set { catgryid = value; }
        }
        private int attachid;
        public int atchid
        {
            get { return attachid; }
            set { attachid = value; }
        }
        private string catname = "";
        public string categryname
        {
            get { return catname; }
            set { catname = value; }
        }
        public string selid(string uid)
        {
            string i = c.scalar("select id from tbl_User_Previlege where UserID=" + uid + " and Category='EMRF' and Permission='A'");
            return i;
        }
        public DataTable getpath()
        {
            DataTable dt = c.table("SELECT path FROM tbl_attachments WHERE id='" + attachid + "'");
            return dt;
        }
        public string getid(string gid)
        {
            string e = c.scalar("select id from tbl_User_Previlege where UserID=" + gid + " and Category='EMRF' and Permission='D'");
            return e;
        }
        public DataTable getattachment()
        {
            DataTable dt = c.table("select dr_id,patient_id,CategoryName,date,photo_name,id,path from tbl_attachments where patient_id='" +pid + "' order by date");
            return dt;

        }
        public DataTable getattachment2()
        {
            DataTable dt = c.table("select dr_id,patient_id,CategoryName,date,photo_name,id,path from tbl_attachments where patient_id='" + pid + "' and CategoryName='" + categryname + "' order by date");
            return dt;

        }
        public int inscatgry()
        {
            int i = c.execute("insert into tbl_AttachmentCategory (CategoryName) values('" + categryname + "')");
            return i;
        }
        public int update()
        {
            int i=c.execute("update tbl_AttachmentCategory set CategoryName='" +categryname  + "' where id='" + catgryid+ "'");
            return i;
        }
        public int delete()
        {
            int j = c.execute("delete from tbl_AttachmentCategory where id='" + catgryid + "'");
            return j;
        }
        public int delattach()
        {
            int p = c.execute("delete from tbl_attachments where id='" + attachid + "'");
            return p;
        }
        public DataTable attach(int atid)
        {
            DataTable dt = c.table("SELECT tbl_patient.pt_name,tbl_patient.pt_id,tbl_patient.age,tbl_attachments.photo_name,tbl_attachments.path FROM tbl_patient,tbl_attachments WHERE tbl_patient.id=tbl_attachments.patient_id AND tbl_attachments.id='" + atid + "'");
            return dt;
        }
    }
}
