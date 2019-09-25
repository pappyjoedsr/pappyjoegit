using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Attachments_controller
    {
        Common_model cmdl = new Common_model();
        Connection db = new Connection();
        Attachments_model mdl = new Attachments_model();
        Add_Attachments_model m = new Add_Attachments_model();
        public string privillage_A(string doctrid)
        {
            string id = cmdl.privillage_A(doctrid);
            return id;
        }
        public string privilge_for_inventory(string doctor_id)
        {
            string s = cmdl.privilge_for_inventory(doctor_id);
            return s;
        }
        public string getprevid(string id)
        {
            string k = mdl.getprevid(id);
            return k;
        }
        public string Load_CompanyName()
        {
            string dtb = cmdl.Load_CompanyName();
            return dtb;
        }
        public string Get_DoctorName(string doctr)
        {
            string dt = cmdl.Get_DoctorName(doctr);
            return dt;
        }
        public string GetPayment(string paymnt)
        {
            string dt = m.GetPayment(paymnt);
            return dt;
        }
        public DataTable GetCategory()
        {
            DataTable dt = m.GetCategory();
            return dt;
        }
        public DataTable GetPatientDetails(string id)
        {
            DataTable dt = m.GetPatientDetails(id);
            return dt;
        }
        public DataTable getattachment(string patntid)
        {
            DataTable dt = mdl.getattachment(patntid);
            return dt;
        }
        public string getserver()
        {
            string server = db.server();
            return server;
        }
        public int inscatgry(string catgryname)
        {
            int j = mdl.inscatgry(catgryname);
            return j;
        }
        public int update(string catgryname, string catgryid)
        {
            int i = mdl.update(catgryname, catgryid);
            return i;
        }
        public DataTable getattachment2(string patntid, string catgryname)
        {
            DataTable dt = mdl.getattachment2(patntid, catgryname);
            return dt;
        }
        public int delete(string catgryid)
        {
            int j = mdl.delete(catgryid);
            return j;
        }
        public int delattach(int attachid)
        {
            int p = mdl.delattach(attachid);
            return p;
        }
        public string getpath(int attachid)
        {
            string dt = mdl.getpath(attachid);
            return dt;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string e = cmdl.doctr_privillage_for_addnewPatient(doctor_id);
            return e;
        }
        public string settingsprivilage(string doctor_id)
        {
            string e = m.settingsprivilage(doctor_id);
            return e;
        }
        public DataTable Patient_search(string txtbox)
        {
            DataTable dt = cmdl.Patient_search(txtbox);
            return dt;
        }
    }
}
