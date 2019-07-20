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
        Connection c = new Connection();
        private string id = "";
        public string docid
        {
            get { return id; }
            set { id = value; }
        }
       private string name = "";
        public string cliname
        {
            get { return name; }
            set { name = value; }
        }
        private string docname = "";
        public string dname
        {
            get { return docname; }
            set { docname = value; }
        }
        private string catgry = "";
        public string category
        {
            get { return catgry; }
            set { catgry = value; }
        }
        private string catname = "";
        public string categryname
        {
            get { return catname; }
            set { catname = value; }
        }
        private string pid = "";
        public string patid
        {
            get { return pid; }
            set { pid = value; }
        }
        private string pth = "";
        public string path
        {
            get { return pth; }
            set { pth = value; }
        }
        private string img = "";
        public string image
        {
            get { return img; }
            set { img = value; }
        }
        private string pay = "";
        public string payment
        {
            get { return pay; }
            set { pay = value; }
        }
        private string mbno="";
        public string mobileno
        {
            get{return mbno;}
            set{mbno=value;}
        }
      
        public DataTable selid()
        {
            DataTable dt = c.table("select id from tbl_doctor where login_type='admin'");
            return dt;
        }
        public DataTable getcategory()
        {
            DataTable dt = c.table("select * from tbl_AttachmentCategory");
            return dt;
        }
        public DataTable getpatdetails(string id)
        {
            DataTable dt = c.table("select pt_name,pt_id from tbl_patient where id='" + id+ "'");
            return dt;
        }
        public DataTable getpayment(string patid)
        {
            DataTable dt = c.table("select total_payment from tbl_invoices where pt_id='" + patid + "'");
            return dt;
        }
        public int insattach()
        {
            int i = c.execute("insert into tbl_attachments(patient_id,photo_name,Path,dr_id,date,CategoryName)  values('" + pid + "','" + image + "','" + path + "','" + docid+ "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + catname+ "')");
            return i;
        }
    }
}
