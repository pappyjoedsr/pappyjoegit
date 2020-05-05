using System;
using System.Data;
namespace PappyjoeMVC.Model
{
    public class Add_New_Patient_model
    {
        Connection db = new Connection();

        public DataTable Get_patient_details(string name)
        {
            DataTable patSearch = db.table("select * from tbl_patient where pt_name ='" + name + "' and Profile_Status!='Cancelled' ");
            return patSearch;
        }
        public DataTable Get_patient_phoneno(string no, string name)
        {
            DataTable patSearch = db.table("select primary_mobile_number,pt_name from tbl_patient where pt_name ='" + name + "'and primary_mobile_number ='" + no + "' and Profile_Status!='Cancelled' ");
            return patSearch;
        }
        public DataTable get_patientid(string id)
        {
            DataTable dtb = db.table("select pt_id from tbl_patient where pt_id='" + id + "'");
            return dtb;
        }
        public int Save(string _name ,string _id , string _aadhar , string _gender, string _dob , string _age , string _blood , string _accompained , string _pmobile , string _smobile , string _landline , string _email , string _street , string
       _locality , string _city , string _pincode , string _referred , string _file , string _admit, string _doctor , string _occupation,string _nationality,string _passportno)
        {
            int i = db.execute("insert into tbl_patient (pt_name,pt_id,aadhar_id,gender,date_of_birth,age,blood_group,family,relation,primary_mobile_number,secondary_mobile_number,landline_number,email_address,street_address,locality,city,pincode,date,group_id,refferedby,Opticket,Visited,doctorname,Occupation,Profile_Status,nationality,passport_no)" +
      " values('" + _name + "','" + _id + "','" + _aadhar + "','" + _gender + "','" + _dob + "','" + _age + "','" + _blood + "','" + _accompained + "','null','" + _pmobile + "','" + _smobile + "','" + _landline + "','" + _email + "','" + _street + "'," +
      "'" + _locality + "','" + _city + "','" + _pincode + "','" + Convert.ToDateTime(DateTime.Now.Date).ToString("yyyy/MM/dd") + "','id4','" + _referred + "','" + _file + "','" + Convert.ToDateTime(_admit).ToString("yyyy/MM/dd") + "','" + _doctor + "','" + _occupation + "','Active','"+_nationality+"','"+_passportno+"')");
            return i;
        }
        public int save_log(string log_userid,string log_type,string log_descriptn,string log_stage)
        {
            int j = db.execute("insert into tbl_log(log_user_id,log_type,log_description,log_stage)values('" + log_userid + "','" + log_type + "','" + log_descriptn + "','" + log_stage + "')");
            return j;
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
            DataTable cmd = db.table("select patient_number from tbl_patient_automaticid");// where patient_automation='Yes'");
            return cmd;
        }
        public DataTable automaticid_when_automation_No()
        {
            DataTable cmd = db.table("select patient_number from tbl_patient_automaticid");
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
        public void insert_medical( string _medical)
        {
            db.execute("insert into tbl_medhistory (name) values('" + _medical + "')");
        }
        public void insert_group(string _group)
        {
            db.execute("insert into tbl_group (name) values('" + _group + "')");
        }
        public string Get_pnonenumber(string number)
        {
            string patSearchnumber = db.scalar("select primary_mobile_number from tbl_patient where primary_mobile_number ='" + number + "'  and Profile_Status !='Cancelled'");
            return patSearchnumber;
        }
        public DataTable check_group(string name)
        {
            DataTable checkdatacc = db.table("Select * from tbl_group where name ='" + name + "'");
            return checkdatacc;
        }
        public DataTable load_medical()
        {
            DataTable dtb = db.table("SELECT name FROM tbl_medhistory");
            return dtb;
        }
        public DataTable load_group()
        {
            DataTable dtb = db.table("select name from tbl_group");
            return dtb;
        }
    }
}
