using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Add_New_patient_controller
    {

        Connection db = new Connection();
        Common_model mdl = new Common_model();
        SMS_model s = new SMS_model();
        Add_New_Patient_model _model = new Add_New_Patient_model();
        public string Get_pnonenumber(string number)
        {
            string patSearchnumber = _model.Get_pnonenumber(number);
            return patSearchnumber;
        }
        public string server()
        {
            string server = db.server();
            return server;
        }
        public string SendSMS(string User, string password, string Mobile_Number, string Message)
        {
            string val = s.SendSMS(User, password, Mobile_Number, Message);
            return val;
        }
        public DataTable Get_patient_details(string name)
        {
            DataTable dtb = _model.Get_patient_details(name);
            return dtb;
        }
        public DataTable get_patientid(string id)
        {
            DataTable dtb = _model.get_patientid(id);
            return dtb;
        }
        public int Save(string _name, string _id, string _aadhar, string _gender, string _dob, string _age, string _blood, string _accompained, string _pmobile, string _smobile, string _landline, string _email, string _street, string
       _locality, string _city, string _pincode, string _referred, string _file, string _admit, string _doctor, string _occupation,string _nationality,string _passportno)
        {
            int i = _model.Save(_name, _id, _aadhar, _gender, _dob, _age, _blood, _accompained, _pmobile, _smobile, _landline, _email, _street, _locality, _city, _pincode, _referred, _file, _admit, _doctor, _occupation,_nationality,_passportno);
            return i;
        }
        public int save_log(string log_usrid,string log_type,string log_descriptn,string log_stage)
        {
            int j = _model.save_log(log_usrid, log_type, log_descriptn, log_stage);
            return j;
        }
        public string get_maxId()
        {
            string dtb = _model.get_maxId();
            return dtb;
        }
        public void save_medical(string pat_id, string medical)
        {
            _model.save_medical(pat_id, medical);
        }
        public void save_group(string pat_id, string medical)
        {
            _model.save_group(pat_id, medical);
        }
        public DataTable automaticid()
        {
            DataTable dtb = _model.automaticid();
            return dtb;
        }
        public void update_autogenerateid(int n)
        {
            _model.update_autogenerateid(n);
        }
        public DataTable data_from_automaticid()
        {
            DataTable dtb = _model.data_from_automaticid();
            return dtb;
        }
        public DataTable get_all_doctorname()
        {
            DataTable dtb = mdl.get_all_doctorname();
            return dtb;
        }
        public string Load_CompanyName()
        {
            string dtb = mdl.Load_CompanyName();
            return dtb;
        }
        public DataTable load_medical()
        {
            DataTable dtb = _model.load_medical();
            return dtb;
        }
        public DataTable load_group()
        {
            DataTable dtb = _model.load_group();
            return dtb;
        }
        public DataTable check_medical(string name)
        {
            DataTable dtb = _model.check_medical(name);
            return dtb;
        }
        public void insert_medical(string Medical)
        {
            _model.insert_medical(Medical);
        }
        public DataTable check_group(string name)
        {
            DataTable checkdatacc = _model.check_group(name);
            return checkdatacc;
        }
        public void insert_group(string Group)
        {
            _model.insert_group(Group);
        }
        public string getserver()
        {
            string ret = db.server();
            return ret;
        }
        public string Get_DoctorName(string doctor_id)
        {
            string dctr = mdl.Get_DoctorName(doctor_id);
            return dctr;
        }
        public string privilge_for_inventory(string doctor_id)
        {
            string id = mdl.privilge_for_inventory(doctor_id);
            return id;
        }
        public DataTable Patient_search(string patid)
        {
            DataTable dtb = mdl.Patient_search(patid);
            return dtb;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string dtb = mdl.doctr_privillage_for_addnewPatient(doctor_id);
            return dtb;
        }
        public string permission_for_settings(string doctor_id)
        {
            string dtb = mdl.permission_for_settings(doctor_id);
            return dtb;
        }
    }
}
