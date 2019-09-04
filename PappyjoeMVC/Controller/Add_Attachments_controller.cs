using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Add_Attachments_controller
    {
        Connection db = new Connection();
        Common_model cmdl = new Common_model();
        Add_Attachments_model mdl = new Add_Attachments_model();
        public string selectdoctrid()
        {
            string id = mdl.selectdoctrid();
            return id;
        }
        public string clinicname()
        {
            string dt = mdl.clinicname();
            return dt;
        }
        public string Get_DoctorName(string doctrid)
        {
            string id = cmdl.Get_DoctorName(doctrid);
            return id;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string e = cmdl.doctr_privillage_for_addnewPatient(doctor_id);
            return e;
        }
        public DataTable GetCategory()
        {
            DataTable dt = mdl.GetCategory();
            return dt;
        }
        public DataTable GetPatientDetails(string patntid)
        {
            DataTable dt = mdl.GetPatientDetails(patntid);
            return dt;
        }
        public string GetPayment(string patntid)
        {
            string pay = mdl.GetPayment(patntid);
            return pay;
        }
        public DataTable Patient_search(string txtbox)
        {
            DataTable dt = cmdl.Patient_search(txtbox);
            return dt;
        }
        public string getserver()
        {
            string server = db.server();
            return server;
        }
        public string settingsprivilage(string doctrid)
        {
            string id = mdl.settingsprivilage(doctrid);
            return id;
        }
        public int insattach(string patientid, string imgname, string path, string doctrid, string catgryname)
        {
            int j = mdl.insattach(patientid, imgname, path, doctrid, catgryname);
            return j;
        }

    }
}
