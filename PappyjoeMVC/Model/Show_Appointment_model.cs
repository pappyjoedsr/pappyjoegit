using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class Show_Appointment_model
    {
        Connection c = new Connection();
        private string ap_id = "";
        public string apid
        {
            get { return ap_id; }
            set { ap_id = value; }
        }
        public string privilege_A(string doctor_id)
        {
            string id = c.scalar("select id from tbl_User_Previlege where UserID=" + doctor_id + " and Category='APT' and Permission='A'");
            return id;
        }
    
        public string privilege_D(string doctor_id)
        {
            string id = c.scalar("select id from tbl_User_Previlege where UserID=" + doctor_id + " and Category='APT' and Permission='D'");
            return id;
        }
        public string privilege_E(string doctor_id)
        {
            string id = c.scalar("select id from tbl_User_Previlege where UserID=" + doctor_id + " and Category='APT' and Permission='E'");
            return id;
        }
        public DataTable show(string patid)
        {
            DataTable dt = c.table("SELECT  tbl_patient.id,tbl_patient.pt_id,tbl_patient.pt_name, tbl_patient.gender,tbl_patient.age, tbl_patient.primary_mobile_number " +
            ",tbl_appointment.start_datetime,tbl_appointment.status,tbl_appointment.schedule,tbl_appointment.waiting,tbl_appointment.engaged,tbl_appointment.checkout,tbl_appointment.id as a_id,tbl_doctor.doctor_name FROM  tbl_appointment LEFT JOIN tbl_patient on tbl_appointment.pt_id=tbl_patient.ID LEFT JOIN tbl_doctor ON tbl_appointment.dr_id=tbl_doctor.id  WHERE  tbl_appointment.pt_id= '" + patid + "'");
            return dt;
        }
        public int delete()
        {
            int j = c.execute("delete from tbl_appointment where id='" + ap_id + "'");
            return j;
        }
    }
}
