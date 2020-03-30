using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Patient_Edit_controller
    {
        Connection db = new Connection();
        Common_model mdl = new Common_model();
        Patient_Edit_model _model = new Patient_Edit_model();
        public DataTable get_medicalId(string pt_id)
        {
            DataTable dtb = _model.get_medicalId(pt_id);
            return dtb;
        }
        public DataTable get_all_doctorname()
        {
            DataTable dt = mdl.get_all_doctorname();
            return dt;
        }
        public DataTable Get_Patient_Details(string id)
        {
            DataTable dt = mdl.Get_Patient_Details(id);
            return dt;
        }
        public string privillage_E(string doctor_id)
        {
            string e = mdl.privillage_E(doctor_id);
            return e;
        }
        public string privillage_D(string doctor_id)
        {
            string e = mdl.privillage_D(doctor_id);
            return e;
        }
        public DataTable  Get_medicalname()
        {
            DataTable dtb = _model.Get_medicalname();
            return dtb;
        }
        public string patient_medical(string idd, string medid)
        {
            string dtb = _model.patient_medical(idd, medid);
            return dtb;
        }
        public DataTable get_groupid(string idd)
        {
            DataTable dtb = _model.get_groupid(idd);
            return dtb;
        }
        public DataTable groupname()
        {
            DataTable dtb = _model.groupname();
            return dtb;
        }
        public string patient_group(string idd, string grpid)
        {
            string dtb = _model.patient_group(idd, grpid);
            return dtb;
        }
        public int save_log(string log_usrid, string log_type, string log_descriptn, string log_stage)
        {
            int j = _model.save_log(log_usrid, log_type, log_descriptn, log_stage);
            return j;
        }
        public int update(string patname,string patId,string aadhar,string Gender,string age,string Dob,string blood,string family,string Pmob,string Smob,string Landline,string email,string street,string locality,string city,string pin,string refferedby,string opticket,string Visited,string occupation,string doctername, string nationality, string passport,string pt_id)
        {
            int i = _model.update( patname,  patId,  aadhar,  Gender,  age,  Dob,  blood,  family,  Pmob,  Smob,  Landline,  email,  street,  locality,  city,  pin,  refferedby,  opticket,  Visited,  occupation,  doctername,nationality, passport, pt_id);
            return i;
        }
        public int delete_patient(string pt_id)
        {
            int i = _model.delete_patient(pt_id);
            return i;
        }
        public int save(string medical)
        {
            int j=_model.save(medical);
            return j;
        }
        public int save_group(string group)
        {
            int i=_model.save_group(group);
            return i;
        }
        public int delete_pt_medhistory(string patient_id)
        {
            int d=_model.delete_pt_medhistory(patient_id);
            return d;
        }
        public string getserver()//connection
        {
            string ret = db.server();
            return ret;
        }
        public int insert_pt_medhistory(string patient_id, string medical)
        {
            int i=_model.insert_pt_medhistory(patient_id, medical);
            return i;
        }
        public int delete_pt_group(string patient_id)
        {
           int p= _model.delete_pt_group(patient_id);
           return p;
        }
        public int insert_pt_group(string patient_id, string group)
        {
            int n=_model.insert_pt_group(patient_id, group);
            return n;
        }
    }
}
