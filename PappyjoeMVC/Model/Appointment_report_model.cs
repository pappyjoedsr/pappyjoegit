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
        public string grp_id(string gpid)
        {
            string query = db.scalar("SELECT DISTINCT id from tbl_pt_group where group_id='" + gpid + "'");
            return query;
        }
        public DataTable dtb_grid(string date1, string date2)
        {
            DataTable dtb_grid = db.table("select A.pt_name,A.book_datetime,C.primary_mobile_number,A.duration,A.start_datetime, A.booked_by,A.note, C.pt_id,C.email_address,D.doctor_name,C.id   from tbl_appointment A inner join tbl_patient C on A.pt_id=C.id inner join tbl_doctor D on A.dr_id=D.id where  A.start_datetime between '" + date1 + "' and '" + date2 + "' and C.Profile_Status!='Cancelled' order by A.book_datetime desc");
            return dtb_grid;
        }
        public DataTable Appointmenteachpatientgroup(string d30, string d31)
        {
            DataTable dfd = db.table("SELECT  tbl_pt_group.group_id AS 'GROUP', COUNT(tbl_appointment.id) AS 'APPOINTMENT' FROM  tbl_pt_group INNER JOIN  tbl_appointment ON tbl_pt_group.pt_id = tbl_appointment.pt_id  inner join tbl_patient P on P.id= tbl_appointment.pt_id where  tbl_appointment.book_datetime between '" + d30 + "' and '" + d31 + "' and P.Profile_Status!='Cancelled' group by tbl_pt_group.group_id");
            return dfd;
        }
        public DataTable dtb_grid_gpid(string gpid, string date1, string date2)//aswini
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
        public DataTable dt_docApt(string date1, string date2)
        {
            DataTable dt = db.table("select  A.pt_name,A.book_datetime,A.start_datetime,A.duration,C.primary_mobile_number,C.Pt_id,C.email_address, B.doctor_name,A.schedule,A.waiting,A.engaged,A.checkout from tbl_appointment A inner join tbl_doctor B on A.dr_id=B.id inner join tbl_patient C on A.pt_id=C.id where A.start_datetime between '" + date1 + "' and  '" + date2 + "' and C.Profile_Status !='Cancelled' order by A.book_datetime desc");
            return dt;
        }
        public DataTable Appointcountforeachdoctor(string d1, string d2)
        {
            DataTable dfd = db.table("SELECT tbl_doctor.doctor_name AS 'DOCTOR',COUNT(*) AS 'APPOINTMENTS' FROM tbl_appointment INNER JOIN tbl_doctor ON tbl_appointment.dr_id = tbl_doctor.id right join tbl_patient  on tbl_patient.id = tbl_appointment.pt_id where  tbl_appointment.start_datetime >= '" + d1 + "' and tbl_appointment.start_datetime<='" + d2 + "' and tbl_patient.Profile_Status !='Cancelled'  group by tbl_doctor.doctor_name");
            return dfd;
        }
        public DataTable dt_docApt1(string date1, string date2, string select_dr_id)
        {
            DataTable datatableeachdoctorappoinment = db.table("select A.pt_name,A.book_datetime,A.start_datetime ,A.duration,C.primary_mobile_number,C.Pt_id,C.email_address, B.doctor_name,A.schedule,A.waiting,A.engaged,A.checkout from tbl_appointment A inner join tbl_doctor B on A.dr_id=B.id inner join tbl_patient C on A.pt_id=C.id where A.start_datetime between '" + date1 + "' and  '" + date2 + "' and A.dr_id = '" + select_dr_id + "' and C.Profile_Status !='Cancelled'  order by A.book_datetime desc");
            return datatableeachdoctorappoinment;
        }
        public DataTable Appointcountforeachdoctor_DoctrWise(string d1, string d2, string drctr)
        {
            DataTable dfd = db.table("SELECT tbl_doctor.doctor_name AS 'DOCTOR',COUNT(*) AS 'APPOINTMENTS' FROM tbl_appointment INNER JOIN tbl_doctor ON tbl_appointment.dr_id = tbl_doctor.id  right join tbl_patient  on tbl_patient.id = tbl_appointment.pt_id      where  tbl_appointment.book_datetime >= '" + d1 + "' and tbl_appointment.book_datetime<='" + d2 + "' and tbl_appointment.dr_id ='" + drctr + "'   group by tbl_doctor.doctor_name");
            return dfd;
        }
        public string get_docId(string drid)
        {
            string query = db.scalar("SELECT id from tbl_doctor where doctor_name='" + drid + "' and  login_type='doctor'");
            return query;
        }
        public string doc_name_login(string drid)
        {
            string query = db.scalar("SELECT id from tbl_doctor where doctor_name='" + drid + "' and  (login_type='doctor' or login_type='admin' ) and activate_login='yes'");
            return query;
        }
        public DataTable doctor_rs()
        {
            System.Data.DataTable doctor_rs = db.table("select DISTINCT id,doctor_name from tbl_doctor   where login_type='doctor' or login_type='admin' and activate_login='yes' order by doctor_name");
            return doctor_rs;
        }
        public DataTable Monthlyappointcount(string d1, string d2)
        {
            DataTable dfd = db.table("select date_format(start_datetime,'%b %Y') AS 'MONTH', COUNT(*) AS 'APPOINTMENT' from tbl_appointment right join tbl_patient  on tbl_patient.id = tbl_appointment.pt_id  where start_datetime between '" + d1 + "' and '" + d2 + "' and tbl_patient.Profile_Status !='Cancelled' GROUP BY date_format(start_datetime,'%b %Y')");
            return dfd;
        }
        public DataTable datatableeachdoctorappoinment(string d1, string d2)
        {
            DataTable datatableeachdoctorappoinment = db.table("select A.pt_name,B.primary_mobile_number ,B.email_address,B.pt_id,A.book_datetime,A.start_datetime,A.booked_by,C.doctor_name  from tbl_appointment A inner join tbl_patient B on A.pt_id=B.id  inner join tbl_doctor C on A.dr_id=C.id  where start_datetime between '" + d1 + " 00:01:00" + "' and '" + d2 + " 23:59:00" + " 23:59:00" + "' and B.Profile_Status !='Cancelled' order by A.pt_id asc");
            return datatableeachdoctorappoinment;
        }
        public DataTable datatableeachdoctorappoinment1(string d1, string d2, string select_dr_id)
        {
            DataTable datatableeachdoctorappoinment = db.table("select A.pt_name,B.primary_mobile_number ,B.email_address,B.pt_id,A.book_datetime,A.start_datetime,A.booked_by,C.doctor_name  from tbl_appointment A inner join tbl_patient B on A.pt_id=B.id  inner join tbl_doctor C on A.dr_id=C.id  where start_datetime between '" + d1 + " 00:01:00" + "' and '" + d2 + " 23:59:00" + "' and dr_id='" + select_dr_id + "' and B.Profile_Status !='Cancelled' order by A.pt_id asc");
            return datatableeachdoctorappoinment;
        }
        public DataTable Monthlyappointcount_DoctrWise(string d1, string d2, string drctr)
        {
            DataTable dfd = db.table("select date_format(book_datetime,'%b %Y') AS 'MONTH', COUNT(*) AS 'APPOINTMENT' from tbl_appointment right join tbl_patient  on tbl_patient.id = tbl_appointment.pt_id  where book_datetime between '" + d1 + "' and '" + d2 + "' and tbl_appointment.dr_id  ='" + drctr + "' and tbl_patient.Profile_Status !='Cancelled' GROUP BY date_format(book_datetime,'%b %Y')");
            return dfd;
        }
        public string Docname_logDocAdmin(string drctid)
        {
            string dt = db.scalar("SELECT id from tbl_doctor where doctor_name = '" + drctid + "' and(login_type= 'doctor' or login_type = 'admin') ");
            return dt;
        }

        public DataTable gridviewtabledailyappoiment(string date1, string date2, string select_dr_id)
        {
            DataTable gridviewtabledailyappoiment = db.table("SELECT B.pt_id,A.pt_name, B.primary_mobile_number ,B.email_address,A.start_datetime,A.booked_by,C.doctor_name  from tbl_appointment A inner join tbl_patient B on A.pt_id=B.id  inner join tbl_doctor C on A.dr_id=C.id where A.start_datetime   between '" + date1 + "' and '" + date2 + "' and A.dr_id='" + select_dr_id + "' and B.Profile_Status !='Cancelled'  order by book_datetime desc");
            return gridviewtabledailyappoiment;
        }
        public DataTable Dailyappointcount_dOCTORwISE(string d5, string d6, string drctr)
        {
            DataTable dfd = db.table("select cast( book_datetime as date) AS 'APPOINTMENT DATE', COUNT(*) AS 'APPOINTMENT' from tbl_appointment right join tbl_patient  on tbl_patient.id = tbl_appointment.pt_id where start_datetime between '" + d5 + "' and '" + d6 + "' and tbl_appointment.dr_id='" + drctr + "' and tbl_patient.Profile_Status !='Cancelled'  group by start_datetime");
            return dfd;
        }
        public DataTable gridviewtabledailyappoiment(string date1, string date2)
        {
            DataTable gridviewtabledailyappoiment = db.table("SELECT B.pt_id,A.pt_name,  B.primary_mobile_number ,B.email_address,A.start_datetime,A.booked_by,C.doctor_name  from tbl_appointment A inner join tbl_patient B on A.pt_id=B.id  inner join tbl_doctor C on A.dr_id=C.id where A.start_datetime   between '" + date1 + "' and '" + date2 + "' and B.Profile_Status !='Cancelled'   order by book_datetime desc");
            return gridviewtabledailyappoiment;
        }
        public DataTable Dailyappointcount(string d5, string d6)
        {
            DataTable dfd = db.table("select cast( book_datetime as date) AS 'APPOINTMENT DATE', COUNT(*) AS 'APPOINTMENT' from tbl_appointment right join tbl_patient  on tbl_patient.id = tbl_appointment.pt_id  where start_datetime between '" + d5 + "' and '" + d6 + "' and tbl_patient.Profile_Status !='Cancelled' group by book_datetime");
            return dfd;
        }
        public DataTable btn_shwClick(string d1, string d2, string cmbCon)
        {
            DataTable dt1 = db.table("select TA.pt_id,TP.pt_id AS patient_id,TA.pt_name ,DATE_FORMAT(TA.book_datetime, '%d-%m-%Y') AS 'book_datetime',TA.status,DATE_FORMAT(TA.start_datetime, '%d-%m-%Y %h:%l %p') AS 'start_datetime',TA.duration,TA.booked_by from tbl_appointment TA inner join tbl_patient TP  on(TP.id=TA.pt_id) where TA.start_datetime between '" + d1 + " 00:01:00" + "' and '" + d2 + " 23:59:00" + "' and TA.status='" + cmbCon + "' and TP.Profile_Status !='Cancelled' ");
            return dt1;
        }
        public DataTable showMissing(string d1, string d2)
        {
            DataTable dt = db.table(" select TA.pt_id,TP.pt_id AS patient_id,TA.pt_name ,DATE_FORMAT(TA.book_datetime, '%d-%m-%Y') AS 'book_datetime',TA.status,DATE_FORMAT(TA.start_datetime, '%d-%m-%Y %h:%l %p') AS 'start_datetime',TA.duration,TA.booked_by from tbl_appointment TA inner join tbl_patient TP on(TP.id = TA.pt_id) where TA.start_datetime between '" + d1 + " 00:01:00" + "' and '" + d2 + " 23:59:00" + "' and TA.status = 'scheduled'and TP.Profile_Status != 'Cancelled'");
            return dt;
        }
        public DataTable DocComb(string d1, string d2)
        {
            DataTable dt1 = db.table("select TA.pt_id,TP.pt_id AS patient_id,TA.pt_name ,TA.book_datetime,TA.status,TA.start_datetime,TA.duration,TA.booked_by from tbl_appointment TA inner join tbl_patient TP  on(TP.id=TA.pt_id) where TA.book_datetime between '" + d1 + "' and '" + d2 + "' and TA.status='Checked Out'and  TP.Profile_Status !='Cancelled'");
            return dt1;
        }
        public DataTable DocComb1(string d1, string d2, string Selected_drid)
        {
            DataTable dt1 = db.table("select TA.pt_id,TP.pt_id AS patient_id,TA.pt_name ,TA.book_datetime,TA.status,TA.start_datetime,TA.duration,TA.booked_by from tbl_appointment TA inner join tbl_patient TP  on(TP.id=TA.pt_id) where TA.book_datetime between '" + d1 + "' and '" + d2 + "' and TA.status='Checked Out' and dr_id='" + Selected_drid + "' and TP.Profile_Status !='Cancelled'");
            return dt1;
        }
        public DataTable DocComb2(string d1, string d2)
        {
            DataTable dt1 = db.table("select TA.pt_id,TP.pt_id AS patient_id,TA.pt_name ,TA.book_datetime,TA.status,TA.start_datetime,TA.duration,TA.booked_by from tbl_appointment TA inner join tbl_patient TP on(TP.id=TA.pt_id) where TA.book_datetime between '" + d1 + "' and '" + d2 + "' and TA.status='scheduled' and TP.Profile_Status !='Cancelled'");
            return dt1;
        }
        public DataTable DocComb3(string d1, string d2, string Selected_drid)
        {
            DataTable dt1 = db.table("select TA.pt_id,TP.pt_id AS patient_id,TA.pt_name ,TA.book_datetime,TA.status,TA.start_datetime,TA.duration,TA.booked_by from tbl_appointment TA inner join tbl_patient TP on(TP.id=TA.pt_id) where TA.book_datetime between '" + d1 + "' and '" + d2 + "' and TA.status='scheduled' and dr_id='" + Selected_drid + "' and TP.Profile_Status !='Cancelled'");
            return dt1;
        }
        public DataTable search(string d1,string d2)
        {
            DataTable dt1 = db.table("select TA.pt_id,TA.pt_name,TA.booked_by,DATE_FORMAT(TA.book_datetime, '%d-%m-%Y') AS 'book_datetime',DATE_FORMAT(TA.start_datetime, '%d-%m-%Y %h:%l %p') AS 'start_datetime',TA.duration,TA.status,TA.schedule,TA.waiting,TA.checkout,TP.pt_id AS patient_id from tbl_appointment TA inner join tbl_patient TP on(TP.id=TA.pt_id) where TA.book_datetime between '" + d1 + "' and '" + d2 + "' and TA.status='Checked Out' and TP.Profile_Status !='Cancelled'");
            return dt1;
        }
        public DataTable vishistCombo(string d1,string d2)
        {
            DataTable dt1 = db.table("select TA.pt_id,TA.pt_name,TA.booked_by,TA.book_datetime,TA.start_datetime,TA.duration,TA.status,TA.schedule,TA.waiting,TA.checkout,TP.pt_id AS patient_id from tbl_appointment TA inner join tbl_patient TP on(TP.id=TA.pt_id) where TA.book_datetime between '" + d1 + "' and '" + d2 + "' and TA.status='Checked Out' and TP.Profile_Status !='Cancelled'");
            return dt1;
        }
        public DataTable vishistCombo1(string d1,string d2,string Selected_drid)
        {
            DataTable dt1 = db.table("select TA.pt_id,TA.pt_name,TA.booked_by,TA.book_datetime,TA.start_datetime,TA.duration,TA.status,TA.schedule,TA.waiting,TA.checkout,TP.pt_id AS patient_id from tbl_appointment TA inner join tbl_patient TP on(TP.id=TA.pt_id) where TA.book_datetime between '" + d1 + "' and '" + d2 + "' and TA.status='Checked Out' and dr_id='" + Selected_drid + "' and TP.Profile_Status !='Cancelled'");
            return dt1;
        }
    }
}
