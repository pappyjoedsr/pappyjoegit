using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class LabWorks_model
    {
        Connection db = new Connection();
        public DataTable Getdata(string patid)
        {
            DataTable docnam = db.table("SELECT distinct A.id as'Work ID',A.date as'Date',A.work_name as'Work Name',A.type as 'Work Type',A.trackingstatus as'Status' from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE A.pt_id='" +patid + "' order by A.ID DESC ");
            return docnam;
        }
        public DataTable printdetails(string patid,string workname,string wrkiddental)
        {
            DataTable tbmain = db.table(" SELECT distinct B.work_name,D.Main_test,C.NormalValueM,C.Name,C.NormalValueF,B.id,A.results,A.Units FROM lab_medi_labresult A INNER JOIN tbl_lab_main B ON A.Resultmain_id=B.id INNER JOIN lab_medi_test C ON A.test_id=C.id inner join tbl_lab_medi_maintest D on D.id=A.maintest_id WHERE B.pt_id='" + patid + "' and B.id='" + wrkiddental + "'");
            return tbmain;
        }
        public DataTable seltype(string patid, string id)
        {
            DataTable type = db.table("SELECT distinct A.type from tbl_lab_main A inner join tbl_patient B on A.pt_id=B.id inner join tbl_doctor C on A.dr_id=C.id WHERE A.pt_id='" + patid + "'and A.id='" + id + "'");
            return type;
        }
        public string getprev(string doctrid)
        {
            string e = db.scalar("select id from tbl_User_Privilege where UserID=" + doctrid + " and Category='INVENTORY' and Permission='A'");
            return e;
        }
        public DataTable smsinfo()
        {
            DataTable dt = db.table("select smsName,smsPass,emailName,emailPass from tbl_SmsEmailConfig");
            return dt;
        }
        public DataTable tbmain(string patid,string workid)
        {
            DataTable dt = db.table("SELECT distinct B.work_name,D.Main_test,B.id FROM Lab_Medi_LabResult A INNER JOIN tbl_lab_main B ON A.Resultmain_id=B.id INNER JOIN Lab_Medi_Test C ON A.test_id=C.id inner join tbl_Lab_Medi_MainTest D on D.id=A.maintest_id WHERE B.pt_id='" + patid + "'and B.id='" + workid + "'");
            return dt;
        }
        public DataTable tbshade(string patid,string wrkname,string workid)
        {
            DataTable dt = db.table("SELECT D.Main_test,C.Name,A.results,C.NormalValueM,C.NormalValueF,A.Units FROM Lab_Medi_LabResult A INNER JOIN tbl_lab_main B ON A.Resultmain_id=B.id INNER JOIN Lab_Medi_Test C ON A.test_id=C.id inner join tbl_Lab_Medi_MainTest D on D.id=A.maintest_id WHERE B.pt_id='" + patid + "' and B.work_name='" + wrkname + "' and B.id='" + workid+ "'");
            return dt;
        }
    }
}
