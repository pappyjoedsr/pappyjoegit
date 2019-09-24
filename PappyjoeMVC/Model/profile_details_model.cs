using System.Data;

namespace PappyjoeMVC.Model
{
    public class profile_Details_model
    {
        Connection db = new Connection();
        public string get_dctr_privillage(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='PAT' and Permission='E'");
            return id;
        }
        //public DataTable Get_Patient_details(string patient_id)
        //{
        //    DataTable rs_patients = db.table("select * from tbl_patient where id='" + patient_id + "'");
        //    return rs_patients;
        //}
        public DataTable pt_medical(string patient_id)
        {
            DataTable dt8 = db.table("select med_id from tbl_pt_medhistory where pt_id='" + patient_id + "'");
            return dt8;
        }
        public DataTable patrint_goup(string patient_id)
        {
            DataTable dt9 = db.table("Select group_id from tbl_pt_group where pt_id='" + patient_id + "'");
            return dt9;
        }
        public DataTable main_settings()
        {
            DataTable cunsultaionview = db.table("select name,status from Tbl_main_Settings where status='1' and name='Con'");
            return cunsultaionview;
        }
    }
}
