using System.Data;
namespace PappyjoeMVC.Model
{
    public class Patient_Edit_model
    {
        Connection db = new Connection();
        public DataTable  get_medicalId(string idd)
        {
            DataTable dt8 = db.table("select med_id from tbl_pt_medhistory where pt_id='" + idd + "'");
            return dt8;
        }
        public DataTable  Get_medicalname()
        {
            DataTable dt35 = db.table("select name from tbl_medhistory order by name");
            return dt35;
        }
        public string patient_medical(string idd, string medid)
        {
            string mht = db.scalar("select med_id from tbl_pt_medhistory where pt_id='" + idd + "' and med_id='" + medid + "'");
            return mht;
        }
        public DataTable  get_groupid(string idd)
        {
            DataTable group = db.table("select group_id from tbl_pt_group where pt_id='" + idd + "'");
            return group;
        }
        public DataTable groupname()
        {
            DataTable dt9 = db.table("Select name from tbl_group");
            return dt9;
        }
        public string patient_group(string idd, string grpid)
        {
            string gt = db.scalar("select group_id from tbl_pt_group where pt_id='" + idd + "' and group_id='" + grpid + "'");
            return gt;
        }
        public int update(string patname, string patId, string aadhar, string Gender, string age, string Dob, string blood, string family, string Pmob, string Smob, string Landline, string email, string street, string locality, string city, string pin, string refferedby, string opticket, string Visited, string occupation, string doctername, string nationality, string passport,string pt_id)
        {
            int i = db.execute("update tbl_patient set pt_name='" + patname + "',pt_id='" + patId + "',aadhar_id='" + aadhar + "',gender='" + Gender + "',age='" + age + "',date_of_birth='" + Dob + "',blood_group='" + blood + "',family='" + family + "',primary_mobile_number='" + Pmob + "',secondary_mobile_number='" + Smob + "',landline_number='" + Landline + "',email_address='" + email + "',street_address='" + street + "',locality='" + locality + "',city='" + city + "',pincode='" + pin + "',group_id='',refferedby='" + refferedby + "',Opticket='" + opticket + "',Visited='" + Visited + "',Occupation='" + occupation + "',doctorname='" + doctername + "',nationality='"+nationality+"',passport_no='"+passport+"'  where id='" + pt_id + "'");
            return i;
        }
        public int delete_patient(string pt_id)
        {
            int i = db.execute("update tbl_patient set Profile_Status='Cancelled' where id='" + pt_id + "'");
            return i;
        }
        public int save(string medical)
        {
            int i = db.execute("insert into tbl_medhistory (name) values('" + medical + "')");
            return i;
        }
        public int save_group(string group)
        {
            int i = db.execute("insert into tbl_group (name) values('" + group + "')");
            return i;
        }
        public int delete_pt_medhistory(string patient_id)
        {
            int j=db.execute("delete  from tbl_pt_medhistory where pt_id='" + patient_id + "'");
            return j;
        }
        public int insert_pt_medhistory(string patient_id, string medical)
        {
            int k=db.execute("insert into tbl_pt_medhistory (pt_id,med_id) values('" + patient_id + "','" + medical + "')");
            return k;
        }
        public int  delete_pt_group(string patient_id)
        {
            int e=db.execute("delete from tbl_pt_group where pt_id='" + patient_id + "'");
            return e;
        }
        public int  insert_pt_group(string patient_id, string group)
        {
            int k=db.execute("insert into  tbl_pt_group(pt_id,group_id) values('" + patient_id + "','" + group + "')");
            return k;
        }
    }
}
