using System.Data;

namespace PappyjoeMVC.Model
{
    public class Treatment_Report_model
    {
        Connection db = new Connection();
        public DataTable doctor_rs()
        {
            System.Data.DataTable doctor_rs = db.table("select DISTINCT id,doctor_name from tbl_doctor where login_type='doctor' or login_type='admin' and activate_login='yes' order by doctor_name");
            return doctor_rs;
        }
        public DataTable grdDailytrtmnt(string date1, string date2)
        {
            DataTable griddailytrreatmenttable = db.table("SELECT  C.pt_id ,C.pt_name ,DATE_FORMAT(A.date,'%d-%m-%Y') as date,A.procedure_name,B.doctor_name,A.cost as 'COST' FROM tbl_completed_procedures A INNER JOIN tbl_doctor B ON A.dr_id=B.id INNER JOIN tbl_patient C ON A.pt_id=C.id WHERE A.date between '" + date1 + "' and '" + date2 + "'and C.Profile_Status !='Cancelled'");
            return griddailytrreatmenttable;
        }
        public DataTable DailytreatmentLoad(string d1, string d2)
        {
            DataTable dfd = db.table("select date_format(C.date,'%a %Y') AS DAY,COUNT(*) AS TREATMENT from tbl_completed_procedures C  right join tbl_patient  on tbl_patient.id = C.pt_id  where  C.date between '" + d1 + "' and '" + d2 + "' and tbl_patient.Profile_Status !='Cancelled' group by  date_format(C.date,'%a %Y')");
            return dfd;
        }
        public DataTable grddlytrtment(string d1, string d2, string drid)
        {
            DataTable griddailytrreatmenttable = db.table("SELECT  C.pt_id ,C.pt_name ,DATE_FORMAT(A.date,'%d-%m-%Y') as date,A.procedure_name,B.doctor_name,A.cost  as 'COST' FROM tbl_completed_procedures A INNER JOIN tbl_doctor B ON A.dr_id=B.id INNER JOIN tbl_patient C ON A.pt_id=C.id WHERE A.date between '" + d1 + "' and '" + d2 + "' and A.dr_id='" + drid + "' and C.Profile_Status !='Cancelled'");
            return griddailytrreatmenttable;
        }
        public DataTable Dailytreatment(string d1, string d2, string drid)
        {
            DataTable dfd = db.table("select date_format(C.date,'%a %Y') AS DAY,COUNT(*) AS TREATMENT from tbl_completed_procedures C  right join tbl_patient  on tbl_patient.id = C.pt_id  where  dr_id='" + drid + "'and  C.date between'" + d1 + "' and '" + d2 + "' and tbl_patient.Profile_Status !='Cancelled' group by  date_format(C.date,'%a %Y')");
            return dfd;
        }
        public DataTable gridtreatment1(string d1, string d2)
        {
            DataTable griddailytrreatmenttable = db.table("SELECT C.pt_id ,C.pt_name , DATE_FORMAT(A.date,'%d-%m-%Y') as date,A.procedure_name,B.doctor_name FROM tbl_completed_procedures A INNER JOIN tbl_doctor B ON A.dr_id=B.id INNER JOIN tbl_patient C ON A.pt_id=C.id WHERE A.date between '" + d1 + "' and '" + d2 + "' and C.Profile_Status !='Cancelled'");
            return griddailytrreatmenttable;
        }
        public DataTable Gridtrtment2(string d1, string d2, string drid)
        {
            DataTable griddailytrreatmenttable = db.table("SELECT  C.pt_id ,C.pt_name ,DATE_FORMAT(A.date,'%d-%m-%Y') as date,A.procedure_name,B.doctor_name FROM tbl_completed_procedures A INNER JOIN tbl_doctor B ON A.dr_id=B.id INNER JOIN tbl_patient C ON A.pt_id=C.id WHERE A.date between '" + d1 + "' and '" + d2 + "' and dr_id='" + drid + "' and C.Profile_Status !='Cancelled'");
            return griddailytrreatmenttable;
        }
        public DataTable addproset()
        {
            DataTable dt = db.table("select DISTINCT id,name from tbl_addproceduresettings order by name");
            return dt;
        }
        public DataTable TreatmenteachcatLoad(string d7, string k7)
        {
            DataTable dfd = db.table("select tbl_completed_procedures.procedure_name as CATEGORY,COUNT(tbl_completed_procedures.id) AS TREATMENTS  from  tbl_completed_procedures inner join tbl_patient P on p.id=tbl_completed_procedures.pt_id where tbl_completed_procedures.date>='" + d7 + "' and tbl_completed_procedures.date<='" + k7 + "'  and p.Profile_Status !='Cancelled' group by tbl_completed_procedures.procedure_name ");
            return dfd;
        }
        public DataTable prosetDocId(string drid)
        {
            DataTable d = db.table("SELECT id from tbl_addproceduresettings where name='" + drid + "'");
            return d;
        }
        public DataTable drgDailytreatmentTB(int select_dr_id, string date1, string date2)
        {
            DataTable griddailytrreatmenttable = db.table("SELECT  DATE_FORMAT(A.date,'%d-%m-%Y') as date,A.procedure_name,B.doctor_name FROM tbl_completed_procedures A INNER JOIN tbl_doctor B ON A.dr_id=B.id inner join tbl_patient P on p.id=A.pt_id WHERE A.procedure_id='" + select_dr_id + "'and A.date between '" + date1 + "' and '" + date2 + "' and P.Profile_Status !='Cancelled' ");
            return griddailytrreatmenttable;
        }
        public DataTable Treatmenteachcat(string d7, string k7, string dr_id)
        {
            DataTable dfd = db.table("select tbl_completed_procedures.procedure_name as CATEGORY,COUNT(tbl_completed_procedures.id) AS TREATMENTS  from  tbl_completed_procedures inner join tbl_patient P on p.id=tbl_completed_procedures.pt_id where tbl_completed_procedures.procedure_id='" + dr_id + "' and tbl_completed_procedures.date>='" + d7 + "' and tbl_completed_procedures.date<='" + k7 + "' and p.Profile_Status !='Cancelled'  group by tbl_completed_procedures.procedure_name ");
            return dfd;
        }
        public DataTable GridDLYTTMNTtb(string date1, string date2)
        {
            DataTable griddailytrreatmenttable = db.table("SELECT  DATE_FORMAT(A.date,'%d-%m-%Y') as date,A.procedure_name,B.doctor_name FROM tbl_completed_procedures A INNER JOIN tbl_doctor B ON A.dr_id=B.id inner join tbl_patient P on p.id=A.pt_id where A.date between '" + date1 + "' and '" + date2 + "' and P.Profile_Status !='Cancelled' ");
            return griddailytrreatmenttable;
        }
        public DataTable practceDetls()
        {
            System.Data.DataTable dtp = db.table("select name,contact_no,street_address,path,email,website  from tbl_practice_details");
            return dtp;
        }
        public DataTable docId(string drctid)
        {
            DataTable d = db.table("select DISTINCT id from tbl_addproceduresettings where name='" + drctid + "'");
            return d;
        }
        public DataTable ProPat(string date1, string date2)
        {
            DataTable dt1 = db.table("SELECT  DATE_FORMAT(A.date,'%d-%m-%Y') as date,A.procedure_name,B.doctor_name FROM tbl_completed_procedures A INNER JOIN tbl_doctor B ON A.dr_id=B.id inner join tbl_patient P on p.id=A.pt_id WHERE  A.date between '" + date1 + "' and '" + date2 + "' and P.Profile_Status !='Cancelled' ");
            return dt1;
        }
        public DataTable Propat2(int Selected_drid, string date1, string date2)
        {
            DataTable dt1 = db.table("SELECT DATE_FORMAT(A.date,'%d-%m-%Y') as date,A.procedure_name,B.doctor_name FROM tbl_completed_procedures A INNER JOIN tbl_doctor B ON A.dr_id=B.id inner join tbl_patient P on p.id=A.pt_id WHERE A.procedure_id='" + Selected_drid + "'and A.date between '" + date1 + "' and '" + date2 + "' and P.Profile_Status !='Cancelled'"); //WHERE date between '" + date1 + "' and '" + date2 + "'
            return dt1;
        }
        public DataTable DoctoreachtreatmentLoad(string d11, string d12)
        {
            DataTable dfd = db.table("select D.doctor_name as DOCTOR, COUNT(*) AS TREATMENTS from tbl_completed_procedures C inner join tbl_doctor D on C.dr_id=D.id inner join tbl_patient P on p.id=C.pt_id where C.date >='" + d11 + "' and C.date <='" + d12 + "' and P.Profile_Status !='Cancelled' group by doctor_name");
            return dfd;
        }
        public DataTable grdDailytreatmntTble(int select_dr_id, string date1, string date2)
        {
            DataTable griddailytrreatmenttable = db.table("SELECT  DATE_FORMAT(A.date,'%d-%m-%Y') as date,A.procedure_name,B.doctor_name FROM tbl_completed_procedures A INNER JOIN tbl_doctor B ON A.dr_id=B.id inner join tbl_patient P on p.id=A.pt_id WHERE B.id='" + select_dr_id + "'and A.date between '" + date1 + "'and '" + date2 + "' and P.Profile_Status !='Cancelled' ");
            return griddailytrreatmenttable;
        }
        public DataTable Dr_ID_logn(string drid)
        {
            DataTable query = db.table("SELECT id from tbl_doctor where doctor_name='" + drid + "' and login_type='doctor'");
            return query;
        }
        public DataTable Doctoreachtreatment(string d11, string d12, string dr_id)
        {
            DataTable dfd = db.table("select D.doctor_name as DOCTOR, COUNT(*) AS TREATMENTS from tbl_completed_procedures C inner join tbl_doctor D on C.dr_id=D.id inner join tbl_patient P on p.id=C.pt_id where dr_id='" + dr_id + "' and C.date >='" + d11 + "' and C.date <='" + d12 + "' and P.Profile_Status !='Cancelled' group by doctor_name");
            return dfd;
        }
        public DataTable DocId_frm_DocTbl(string drctid)
        {
            DataTable query = db.table("SELECT id from tbl_doctor where doctor_name='" + drctid + "'");
            return query;
        }
        public DataTable gridTable(string date1, string date2)
        {
            DataTable griddailytrreatmenttable = db.table("SELECT DATE_FORMAT(A.date,'%d-%m-%Y') as date,A.procedure_name,B.doctor_name FROM tbl_completed_procedures A INNER JOIN tbl_doctor B ON A.dr_id=B.id inner join tbl_patient P on p.id=A.pt_id WHERE A.date between '" + date1 + "' and '" + date2 + "' ");
            return griddailytrreatmenttable;
        }
        public DataTable MonthtreatmentcountLoad(string d9, string k9)
        {
            DataTable dfd = db.table("select date_format(tbl_completed_procedures.date,'%b %Y') AS MONTH,COUNT(*) AS TREATMENT from tbl_completed_procedures  inner join tbl_patient P on p.id=tbl_completed_procedures.pt_id where tbl_completed_procedures.date >='" + d9 + "' and tbl_completed_procedures.date<='" + k9 + "' and P.Profile_Status !='Cancelled'  group by date_format(tbl_completed_procedures.date,'%b %Y')");
            return dfd;
        }
        public DataTable Monthtreatmentcount(string d9, string k9, string dr_id)
        {
            DataTable dfd = db.table("select date_format(tbl_completed_procedures.date,'%b %Y') AS 'MONTH' ,COUNT(*) AS TREATMENT from tbl_completed_procedures inner join tbl_patient P on p.id=tbl_completed_procedures.pt_id where dr_id='" + dr_id + "' and tbl_completed_procedures.date >='" + d9 + "' and tbl_completed_procedures.date<='" + k9 + "' and P.Profile_Status !='Cancelled' group by date_format(tbl_completed_procedures.date,'%b %Y')");
            return dfd;
        }
        public DataTable DailyTablE(string d1, string d2, string dr)
        {
            DataTable griddailytrreatmenttable = db.table("SELECT DATE_FORMAT(A.date,'%d-%m-%Y') as date,A.procedure_name,B.doctor_name FROM tbl_completed_procedures A INNER JOIN tbl_doctor B ON A.dr_id=B.id inner join tbl_patient P on p.id=A.pt_id WHERE A.date between '" + d1 + "' and '" + d2 + "' and A.dr_id='" + dr + "' and P.Profile_Status !='Cancelled'");
            return griddailytrreatmenttable;
        }
    }
}
