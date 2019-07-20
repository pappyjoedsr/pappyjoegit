using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
    public class Appointment_report_model
    {
        Connection db = new Connection();
        public DataTable gp_rs()
        {
            System.Data.DataTable gp_rs = db.table("SELECT id,group_id FROM tbl_pt_group WHERE id IN (SELECT MAX(id) FROM tbl_pt_group GROUP BY group_id)");
            return gp_rs;
        }
        public DataTable grp_id(string gpid)
        {
            DataTable query = db.table("SELECT DISTINCT id from tbl_pt_group where group_id='" + gpid + "'");
            return query;
        }
        public DataTable dtb_grid(string date1,string date2)
        {
            DataTable  dtb_grid = db.table("select A.pt_name,A.book_datetime,C.primary_mobile_number,A.duration,A.start_datetime, A.booked_by,A.note, C.pt_id,C.email_address,D.doctor_name,C.id   from tbl_appointment A inner join tbl_patient C on A.pt_id=C.id inner join tbl_doctor D on A.dr_id=D.id where  A.start_datetime between '" + date1 + "' and '" + date2 + "' and C.Profile_Status!='Cancelled' order by A.book_datetime desc");
            return dtb_grid;
        }
        public DataTable Appointmenteachpatientgroup(string d30, string d31) 
        {
            DataTable dfd = db.table("SELECT  tbl_pt_group.group_id AS 'GROUP', COUNT(tbl_appointment.id) AS 'APPOINTMENT' FROM  tbl_pt_group INNER JOIN  tbl_appointment ON tbl_pt_group.pt_id = tbl_appointment.pt_id  inner join tbl_patient P on P.id= tbl_appointment.pt_id where  tbl_appointment.book_datetime between '" + d30 + "' and '" + d31 + "' and P.Profile_Status!='Cancelled' group by tbl_pt_group.group_id");
            return dfd;
        }
        public DataTable dtb_grid_gpid(string gpid,string date1,string date2)//aswini
        {
            DataTable dtb_grid = db.table("SELECT  A.pt_name, A.book_datetime, C.primary_mobile_number, A.duration, A.start_datetime, A.booked_by, A.note, C.pt_id, C.email_address, B.group_id, D.doctor_name, C.id from tbl_appointment A inner join tbl_pt_group B on A.pt_id = B.pt_id inner join tbl_patient C on A.pt_id = C.id inner join tbl_doctor D on A.dr_id = D.id   where B.group_id = '" + gpid + "' and  A.start_datetime between '" + date1 + "' and '" + date2 + "'  order by  A.book_datetime desc   ");
            return dtb_grid;
        }
        public DataTable Appointmenteachpatientgroup_DrWise(string d30, string d31, string Drctr)//aswini
        {
            DataTable dfd = db.table("SELECT  tbl_pt_group.group_id AS 'GROUP', COUNT(tbl_appointment.id) AS 'APPOINTMENT' FROM  tbl_pt_group INNER JOIN  tbl_appointment ON tbl_pt_group.pt_id = tbl_appointment.pt_id where  tbl_appointment.book_datetime between '" + d30 + "' and '" + d31 + "' and tbl_pt_group.group_id='" + Drctr + "'  group by tbl_pt_group.group_id");
            return dfd;
        }
        public DataTable dt_group(string dtb_grid)
        {
            System.Data.DataTable dt_group = db.table(" select * from tbl_pt_group where pt_id='" + dtb_grid + "'");
            return dt_group;
        }
        public DataTable dt_docApt(string date1,string date2)
        {
            DataTable dt= db.table("select  A.pt_name,A.book_datetime,A.start_datetime,A.duration,C.primary_mobile_number,C.Pt_id,C.email_address, B.doctor_name,A.schedule,A.waiting,A.engaged,A.checkout from tbl_appointment A inner join tbl_doctor B on A.dr_id=B.id inner join tbl_patient C on A.pt_id=C.id where A.start_datetime between '" + date1 + "' and  '" + date2 + "' and C.Profile_Status !='Cancelled' order by A.book_datetime desc");
            return dt;
        }
        public DataTable Appointcountforeachdoctor(string d1, string d2)
        {
            DataTable dfd = db.table("SELECT tbl_doctor.doctor_name AS 'DOCTOR',COUNT(*) AS 'APPOINTMENTS' FROM tbl_appointment INNER JOIN tbl_doctor ON tbl_appointment.dr_id = tbl_doctor.id right join tbl_patient  on tbl_patient.id = tbl_appointment.pt_id where  tbl_appointment.book_datetime >= '" + d1 + "' and tbl_appointment.book_datetime<='" + d2 + "' and tbl_patient.Profile_Status !='Cancelled'  group by tbl_doctor.doctor_name");
            return dfd;
        }
        public DataTable dt_docApt1(string date1,string date2,string select_dr_id)
        {
            DataTable datatableeachdoctorappoinment = db.table("select A.pt_name,A.book_datetime,A.start_datetime ,A.duration,C.primary_mobile_number,C.Pt_id,C.email_address, B.doctor_name,A.schedule,A.waiting,A.engaged,A.checkout from tbl_appointment A inner join tbl_doctor B on A.dr_id=B.id inner join tbl_patient C on A.pt_id=C.id where A.start_datetime between '" + date1 + "' and  '" + date2 + "' and A.dr_id = '" + select_dr_id + "' and C.Profile_Status !='Cancelled'  order by A.book_datetime desc");
            return datatableeachdoctorappoinment;
        }
        public DataTable Appointcountforeachdoctor_DoctrWise(string d1, string d2, string drctr)
        {
            DataTable dfd = db.table("SELECT tbl_doctor.doctor_name AS 'DOCTOR',COUNT(*) AS 'APPOINTMENTS' FROM tbl_appointment INNER JOIN tbl_doctor ON tbl_appointment.dr_id = tbl_doctor.id  right join tbl_patient  on tbl_patient.id = tbl_appointment.pt_id      where  tbl_appointment.book_datetime >= '" + d1 + "' and tbl_appointment.book_datetime<='" + d2 + "' and tbl_appointment.dr_id ='" + drctr + "'   group by tbl_doctor.doctor_name");
            return dfd;
        }
        public DataTable get_docId(string drid)
        {
            DataTable query = db.table("SELECT id from tbl_doctor where doctor_name='" + drid + "' and  login_type='doctor'");
            return query;
        }
        public DataTable doc_name_login(string drid)
        {
            DataTable query = db.table("SELECT id from tbl_doctor where doctor_name='" + drid + "' and  (login_type='doctor' or login_type='admin' ) and activate_login='yes'");
            return query;
        }
    }
}
