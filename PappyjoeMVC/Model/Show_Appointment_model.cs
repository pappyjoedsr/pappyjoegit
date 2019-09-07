using System.Data;

namespace PappyjoeMVC.Model
{
    public class Show_Appointment_model
    {
        Connection db = new Connection();
        public string privilege_A(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='APT' and Permission='A'");
            return id;
        }
        public string privilege_D(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='APT' and Permission='D'");
            return id;
        }
        public string settingsprivilage(string doctrid)
        {
            string b = db.scalar("select id from tbl_User_Privilege where UserID=" + doctrid + " and Category='CLMS' and Permission='A'");
            return b;
        }
        public string privilege_E(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='APT' and Permission='E'");
            return id;
        }
        public DataTable show(string patid)
        {
            DataTable dt = db.table("SELECT  tbl_patient.id,tbl_patient.pt_id,tbl_patient.pt_name, tbl_patient.gender,tbl_patient.age, tbl_patient.primary_mobile_number " +
            ",tbl_appointment.start_datetime,tbl_appointment.status,tbl_appointment.schedule,tbl_appointment.waiting,tbl_appointment.engaged,tbl_appointment.checkout,tbl_appointment.id as a_id,tbl_doctor.doctor_name FROM  tbl_appointment LEFT JOIN tbl_patient on tbl_appointment.pt_id=tbl_patient.ID LEFT JOIN tbl_doctor ON tbl_appointment.dr_id=tbl_doctor.id  WHERE  tbl_appointment.pt_id= '" + patid + "'");
            return dt;
        }
        public int delete(string apntid)
        {
            int j = db.execute("delete from tbl_appointment where id='" + apntid + "'");
            return j;
        }
    }//fgadsxghSAFc
}
