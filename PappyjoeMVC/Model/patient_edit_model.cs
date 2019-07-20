using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
  public class patient_edit_model
    {
        Connection db = new Connection();
        private string _patname = "";
        public string patname
        {
            get { return _patname; }
            set { _patname = value; }
        }
        private string _patId = "";
        public string patId
        {
            get { return _patId; }
            set { _patId = value; }
        }
        private string _aadhar = "";
        public string aadhar
        {
            get { return _aadhar; }
            set { _aadhar = value; }
        }
        private string _age = "";
        public string age
        {
            get { return _age; }
            set { _age = value; }
        }
        private string _blood = "";
        public string blood
        {
            get { return _blood; }
            set { _blood = value; }
        }
        private string _family = "";
        public string family
        {
            get { return _family; }
            set { _family = value; }
        }
        private string _Pmob = "";
        public string Pmob
        {
            get { return _Pmob; }
            set { _Pmob = value; }
        }
        private string _Smob = "";
        public string Smob
        {
            get { return _Smob; }
            set { _Smob = value; }
        }
        private string _Landline = "";
        public string Landline
        {
            get { return _Landline; }
            set { _Landline = value; }
        }
        private string _street = "";
        public string street
        {
            get { return _street; }
            set { _street = value; }
        }
        private string _email = "";
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _locality = "";
        public string locality
        {
            get { return _locality; }
            set { _locality = value; }
        }
        private string _city = "";
        public string city
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _pin = "";
        public string pin
        {
            get { return _pin; }
            set { _pin = value; }
        }
        private string _groupid = "";
        //public string groupid
        //{
        //    get { return _groupid; }
        //    set { _groupid = value; }
        //}
        private string _refferedby = "";
        public string refferedby
        {
            get { return _refferedby; }
            set { _refferedby = value; }
        }
        private string _opticket = "";
        public string opticket
        {
            get { return _opticket; }
            set { _opticket = value; }
        }
        private string _doctername = "";
        public string doctername
        {
            get { return _doctername; }
            set { _doctername = value; }
        }
        private string _occupation = "";
        public string occupation
        {
            get { return _occupation; }
            set { _occupation = value; }
        }
        private string _admintdate = "";
        public string AdmitDate
        {
            get { return _admintdate; }
            set { _admintdate = value; }
        }
        private string _visited = "";
        public string Visited
        {
            get { return _visited; }
            set { _visited = value; }
        }
        private string _dob = "";
        public string Dob
        {
            get { return _dob; }
            set { _dob = value; }
        }
        private string _gender = "";
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public DataTable get_medicalId(string idd)
        {
            DataTable dt8 = db.table("select med_id from tbl_pt_medhistory where pt_id='" + idd + "'");
            return dt8;
        }
        public DataTable Get_medicalname()
        {
            DataTable dt35 = db.table("select name from tbl_medhistory order by name");
            return dt35;
        }
        public DataTable patient_medical(string idd,string medid)
        {
            DataTable mht = db.table("select med_id from tbl_pt_medhistory where pt_id='" + idd + "' and med_id='" + medid + "'");
            return mht;
        }
        public DataTable get_groupid(string idd)
        {
            DataTable group = db.table("select group_id from tbl_pt_group where pt_id='" + idd + "'");
            return group;
        }
       public DataTable groupname()
        {
            DataTable dt9 = db.table("Select name from tbl_group");
            return dt9;
        }
        public DataTable patient_group(string idd,string grpid)
        {
            DataTable gt = db.table("select group_id from tbl_pt_group where pt_id='" + idd + "' and group_id='" + grpid + "'");
            return gt;
        }

        public int update(string pt_id)
        {
           int i = db.execute("update tbl_patient set pt_name='" + _patname + "',pt_id='" + _patId + "',aadhar_id='" + _aadhar + "',gender='" + _gender + "',age='" + _age + "',date_of_birth='" + _dob + "',blood_group='" + _blood + "',family='" + _family + "',primary_mobile_number='" + _Pmob + "',secondary_mobile_number='" + _Smob + "',landline_number='" + _Landline + "',email_address='" + _email + "',street_address='" + _street + "',locality='" + _locality + "',city='" + _city + "',pincode='" + _pin + "',group_id='',refferedby='" + _refferedby + "',Opticket='" + _opticket + "',Visited='" + _visited + "',Occupation='" + _occupation + "',doctorname='" + _doctername + "'  where id='" + pt_id + "'");
            return i;
        }
        public int delete_patient(string pt_id)
        {
           int  i = db.execute("update tbl_patient set Profile_Status='Cancelled' where id='" + pt_id + "'");
            return i;
        }
        public void save(string medical)
        {
            int i = db.execute("insert into tbl_medhistory (name) values('" + medical + "')");
        }
        public void save_group(string group)
        {
            int i = db.execute("insert into tbl_group (name) values('" + group + "')");
        }
    }
}
