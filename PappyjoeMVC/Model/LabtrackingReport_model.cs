using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class LabtrackingReport_model
    {
        Connection db = new Connection();
        public DataTable selectall(string jobno)
        {
            DataTable dt = db.table("select * from tbl_lab_main where type='Dental' and id='"+jobno+"' ");
            return dt;
        }
        public DataTable txtkeypress()
        {
            DataTable dt = db.table("SELECT distinct A.id as'JOB.NO',B.pt_name as 'PATIENT INFO',C.doctor_name as'DOCTOR' ,A.labname as'LAB',A.work_name as'WORK NAME',A.duedate as'DUE',A.trackingstatus as'STATUS' from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE A.type='Dental' ");
            return dt;
        }
        public DataTable txtkeypress2(string pt_name)
        {
            DataTable dt = db.table("SELECT distinct A.id as'JOB.NO',B.pt_name as 'PATIENT INFO',C.doctor_name as'DOCTOR' ,A.labname as'LAB',A.work_name as'WORK NAME',A.duedate as'DUE',A.trackingstatus as'STATUS' from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE A.type='Dental' and B.pt_name like '" + pt_name + "%'");
            return dt;
        }
        public DataTable txtkeyup()
        {
            DataTable dt = db.table("SELECT distinct A.id as'JOB.NO',B.pt_name as 'PATIENT INFO',C.doctor_name as'DOCTOR' ,A.labname as'LAB',A.work_name as'WORK NAME',A.duedate as'DUE',A.trackingstatus as'STATUS' from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id A.type='Dental' ");
            return dt;
        }
        public DataTable txtkeyup2(string pt_name)
        {
            DataTable dt = db.table("SELECT distinct A.id as'JOB.NO',B.pt_name as 'PATIENT INFO',C.doctor_name as'DOCTOR' ,A.labname as'LAB',A.work_name as'WORK NAME',A.duedate as'DUE',A.trackingstatus as'STATUS' from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE A.type='Dental' and B.pt_name like '" + pt_name + "%'");
            return dt;
        }
        public DataTable stactive()
        {
            DataTable dt = db.table("SELECT distinct A.id as'JOB.NO',B.pt_name as 'PATIENT INFO',C.doctor_name as'DOCTOR' ,A.labname as'LAB',A.work_name as'WORK NAME',A.duedate as'DUE',A.trackingstatus as'STATUS' from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE A.type='Dental' and trackingstatus='Active' ");
            return dt;
        }
        public DataTable statsent()
        {
            DataTable dt = db.table("SELECT distinct A.id as'JOB.NO',B.pt_name as 'PATIENT INFO',C.doctor_name as'DOCTOR' ,A.labname as'LAB',A.work_name as'WORK NAME',A.duedate as'DUE',A.trackingstatus as'STATUS' from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE A.type='Dental' and trackingstatus='Sent'");
            return dt;
        }
        public DataTable statinproductn()
        {
            DataTable dt = db.table("SELECT distinct A.id as'JOB.NO',B.pt_name as 'PATIENT INFO',C.doctor_name as'DOCTOR' ,A.labname as'LAB',A.work_name as'WORK NAME',A.duedate as'DUE',A.trackingstatus as'STATUS' from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE A.type='Dental' and trackingstatus='In Production'");
            return dt;
        }
        public DataTable statintransit()
        {
            DataTable dt = db.table("SELECT distinct A.id as'JOB.NO',B.pt_name as 'PATIENT INFO',C.doctor_name as'DOCTOR' ,A.labname as'LAB',A.work_name as'WORK NAME',A.duedate as'DUE',A.trackingstatus as'STATUS' from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE A.type='Dental' and trackingstatus='In Transit'");
            return dt;
        }
        public DataTable statreceived()
        {
            DataTable dt = db.table("SELECT distinct A.id as'JOB.NO',B.pt_name as 'PATIENT INFO',C.doctor_name as'DOCTOR' ,A.labname as'LAB',A.work_name as'WORK NAME',A.duedate as'DUE',A.trackingstatus as'STATUS' from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE A.type='Dental' and trackingstatus='Received'");
            return dt;
        }
        public DataTable statoverdue()
        {
            DataTable dt = db.table("SELECT distinct A.id as'JOB.NO',B.pt_name as 'PATIENT INFO',C.doctor_name as'DOCTOR' ,A.labname as'LAB',A.work_name as'WORK NAME',A.duedate as'DUE',A.trackingstatus as'STATUS' from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE A.type='Dental' and trackingstatus='Over Due'");
            return dt;
        }
        public DataTable notnullstatus()
        {
            DataTable dt = db.table("SELECT distinct A.id as'JOB.NO',B.pt_name as 'PATIENT INFO',C.doctor_name as'DOCTOR' ,A.labname as'LAB',A.work_name as'WORK NAME',A.duedate as'DUE',A.trackingstatus as'STATUS' from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE A.type='Dental' and  A.trackingstatus is not null");
            return dt;
        }
        public DataTable duedtetoday(string today)
        {
            DataTable dt = db.table("SELECT distinct A.id as'JOB.NO',B.pt_name as 'PATIENT INFO',C.doctor_name as'DOCTOR' ,A.labname as'LAB',A.work_name as'WORK NAME',A.duedate as'DUE',A.trackingstatus as'STATUS' from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE  A.type='Dental' and duedate='" + today + "' ");
            return dt;
        }
        public DataTable duedtetommarrow(string tommarrow)
        {
            DataTable dt = db.table("SELECT distinct A.id as'JOB.NO',B.pt_name as 'PATIENT INFO',C.doctor_name as'DOCTOR' ,A.labname as'LAB',A.work_name as'WORK NAME',A.duedate as'DUE',A.trackingstatus as'STATUS' from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE  A.type='Dental' and duedate='" + tommarrow + "' ");
            return dt;
        }
        public string userprivilege(string doctrid)
        {
            string e = db.scalar("select id from tbl_User_Privilege where UserID=" + doctrid + " and Category='CLMS' and Permission='A'");
            return e;
        }
        public int statusupdate(string trstatus,string id)
        {
            int i = db.execute("UPDATE  tbl_lab_main SET trackingstatus='" + trstatus + "' WHERE id='" + id + "'");
            return i;
        }
        public DataTable trackngnullstatus()
        {
            DataTable dt = db.table("SELECT distinct A.id as'Work ID',A.work_name as'Work Name',A.type as 'Work Type',B.pt_name ,A.pt_id from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE A.trackingstatus='null' and A.type='Dental'");
            return dt;
        }
    }
}
