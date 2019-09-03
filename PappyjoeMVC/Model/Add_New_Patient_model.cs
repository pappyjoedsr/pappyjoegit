using System;
using System.Data;
namespace PappyjoeMVC.Model
{
    public class Add_New_Patient_model
    {
        Connection db = new Connection();
        private string _name = "";
        public string PatientName
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _id = "";
        public string PatientId
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _aadhar = "";
        public string Aadhaar
        {
            get { return _aadhar; }
            set { _aadhar = value; }
        }
        private string _gender = "";
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        private string _dob = "";
        public string DOB
        {
            get { return _dob; }
            set { _dob = value; }
        }
        private string _referred = "";
        public string ReferredBy
        {
            get { return _referred; }
            set { _referred = value; }
        }
        private string _blood = "";
        public string Blood
        {
            get { return _blood; }
            set { _blood = value; }
        }
        private string _accompained = "";
        public string Accompainedby
        {
            get { return _accompained; }
            set { _accompained = value; }
        }
        private string _file = "";
        public string FileNo
        {
            get { return _file; }
            set { _file = value; }
        }
        private string _age = "";
        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }
        private string _admit = "";
        public string DateofAdmit
        {
            get { return _admit; }
            set { _admit = value; }
        }
        private string _occupation = "";
        public string Occupation
        {
            get { return _occupation; }
            set { _occupation = value; }
        }
        private string _doctor = "";
        public string Doctor
        {
            get { return _doctor; }
            set { _doctor = value; }
        }
        private string _pmobile = "";
        public string PrimaryMob
        {
            get { return _pmobile; }
            set { _pmobile = value; }
        }
        private string _smobile = "";
        public string SecondaryMob
        {
            get { return _smobile; }
            set { _smobile = value; }
        }
        private string _landline = "";
        public string Landline
        {
            get { return _landline; }
            set { _landline = value; }
        }
        private string _email = "";
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _street = "";
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        private string _locality = "";
        public string Locality
        {
            get { return _locality; }
            set { _locality = value; }
        }
        private string _city = "";
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _pincode = "";
        public string Pincode
        {
            get { return _pincode; }
            set { _pincode = value; }
        }
        private string _medical = "";
        public string Medical
        {
            get { return _medical; }
            set { _medical = value; }
        }
        private string _group = "";
        public string Group
        {
            get { return _group; }
            set { _group = value; }
        }

        public DataTable Get_patient_details(string name)
        {
            DataTable patSearch = db.table("select * from tbl_patient where pt_name ='" + name + "'");
            return patSearch;
        }
        public DataTable get_patientid(string id)
        {
            DataTable dtb = db.table("select pt_id from tbl_patient where pt_id='" + id + "'");
            return dtb;
        }
        public int Save()
        {
            int i = db.execute("insert into tbl_patient (pt_name,pt_id,aadhar_id,gender,date_of_birth,age,blood_group,family,relation,primary_mobile_number,secondary_mobile_number,landline_number,email_address,street_address,locality,city,pincode,date,group_id,refferedby,Opticket,Visited,doctorname,Occupation,Profile_Status)" +
      " values('" + _name + "','" + _id + "','" + _aadhar + "','" + _gender + "','" + _dob + "','" + _age + "','" + _blood + "','" + _accompained + "','null','" + _pmobile + "','" + _smobile + "','" + _landline + "','" + _email + "','" + _street + "'," +
      "'" + _locality + "','" + _city + "','" + _pincode + "','" + Convert.ToDateTime(DateTime.Now.Date).ToString("yyyy/MM/dd") + "','id4','" + _referred + "','" + _file + "','" + Convert.ToDateTime(_admit).ToString("yyyy/MM/dd") + "','" + _doctor + "','" + _occupation + "','Active')");
            return i;
        }
        public string get_maxId()
        {
            string rs_patient = db.scalar("SELECT MAX(Id) FROM tbl_patient");
            return rs_patient;
        }
        public void save_medical(string pat_id, string medical)
        {
            db.execute("insert into tbl_pt_medhistory (pt_id,med_id) values('" + pat_id + "','" + medical + "')");
        }
        public void save_group(string pt_id, string group)
        {
            db.execute("insert into tbl_pt_group (pt_id,group_id) values('" + pt_id + "','" + group + "')");
        }
        public DataTable automaticid()
        {
            DataTable cmd = db.table("select patient_number from tbl_patient_automaticid where patient_automation='Yes'");
            return cmd;
        }
        public void update_autogenerateid(int n)
        {
            db.execute("update tbl_patient_automaticid set patient_number='" + n + "'");
        }
        public DataTable data_from_automaticid()
        {
            DataTable auto = db.table("select * from tbl_patient_automaticid ");
            return auto;
        }
        public DataTable check_medical(string name)
        {
            DataTable dtb = db.table("Select * from tbl_medhistory where name ='" + name + "'");
            return dtb;
        }
        public void insert_medical()
        {
            db.execute("insert into tbl_medhistory (name) values('" + _medical + "')");
        }
        public void insert_group()
        {
            db.execute("insert into tbl_group (name) values('" + _group + "')");
        }
    }
}
