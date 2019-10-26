using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class Add_Labwork_model
    {
        Connection db = new Connection();
        public DataTable getdoctrdetails()
        {
            DataTable dt = db.table("SELECT id,doctor_name from tbl_doctor");
            return dt;
        }
        public DataTable Lab_Medi_TemplateMain()
        {
            DataTable dt = db.table("SELECT id as'id',TemplateName as 'package' FROM Lab_Medi_TemplateMain");
            return dt;
        }
        public DataTable getLabdata()
        {
            DataTable dt = db.table("SELECT id,labname FROM tbl_laboratory WHERE labtype='Medical'");
            return dt;
        }
        public string selectid(string mtest)
        {
            string dt = db.scalar("SELECT A.id FROM tbl_Lab_Medi_MainTest A INNER JOIN Lab_Medi_Template B ON A.id = B.MainTestId inner join Lab_Medi_TemplateMain C on C.id = B.id where A.Main_Test = '" + mtest + "'");
            return dt;
        }
        public int inslabmain(string patid,string dr_id, string wrkname, string wrkid, string dte, string duedate, string rcvdate)
        {
            int i = db.execute("INSERT into tbl_lab_main(pt_id,dr_id,work_name,work_id,labname,lab_id,date,duedate,recievedate,status,type,trackingstatus)VALUES('" + Convert.ToInt32(patid) + "','" + Convert.ToInt32(dr_id) + "','" +wrkname + "','" + wrkid + "','','0','" + Convert.ToDateTime(dte).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(duedate).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(rcvdate).ToString("yyyy-MM-dd") + "','','Medical',' ')");
            return i;
        }
        public int inslabmain2(string patid, string dr_id, string work_name, string work_id, string date)
        {
            int j = db.execute("INSERT into tbl_lab_main(pt_id, dr_id, work_name, work_id, type, date,trackingstatus)values('" + Convert.ToInt32(patid) + "', '" + Convert.ToInt32(dr_id) + "', '" + work_name + "', '" + work_id + "', 'Dental', '" + Convert.ToDateTime(date).ToString("yyyy-MM-dd") + "','not null')");
            return j;
        }
        public int insdentlab(string resultmain, string work_name, string work_type, string aloytype, string shade, string patid, string toothnumber)
        {
            int k=db.execute("insert into tbl_dentallabresult(resultmain,work_name,work_type,aloytype,shade,pt_id,toothnumber)values('" + resultmain + "','" + work_name + "','" + work_type + "','" + aloytype + "','" + shade + "','" + patid+ "','" + toothnumber + "')");
            return k;
        }
        public string maxid()
        {
            string dt = db.scalar("SELECT max(id)from tbl_lab_main");
            return dt;
        }
        public int labresult(string rsltmid,string id,string maintstid,string testid,string patid,string units,string normvalue)
        {
            int i = db.execute("INSERT INTO Lab_Medi_LabResult(Resultmain_id,id,maintest_id,test_id,pt_id,results,Units,Normalvalue)VALUES('" + rsltmid + "','" + id + "','" + maintstid + "','" + testid + "','" + Convert.ToInt32(patid).ToString() + "','','" + units + "','" + normvalue + "')");
            return i;
        }
        public DataTable dentallab()
        {
            DataTable dt = db.table("select id,shade,aloytype,work_type,work_name from tbl_Dentallab");
            return dt;
        }
        public DataTable grid3data(string patid)
        {
            DataTable dt = db.table("SELECT B.name,C.name from Lab_Medi_LabResult A inner join Lab_Med1_mainTest B on A.id=B.maintest_id inner join Lab_Med1_Testtype C on A.test_id=C.id  WHERE pt_id='" + patid + "'");
            return dt;
        }
        public DataTable getwrkname(string wrkname)
        {
            DataTable dt = db.table("SELECT id,work_name,work_type from tbl_Dentallab WHERE work_name='" + wrkname + "'");
            return dt;
        }
        public DataTable testrslt(string id)
        {
            DataTable dt = db.table("SELECT D.Main_test as 'Test Name',C.Name as 'SampleType',B.Name as 'Speciality',E.name as 'Units',A.NormalValue as'Normal Value',B.id as 'Test_id',D.id as'Main Id' FROM Lab_Medi_Template A INNER JOIN  Lab_Medi_Test B ON A.TestId=B.id INNER JOIN tbl_Lab_Medi_TestType C ON C.id=B.TestTypeID INNER JOIN tbl_Lab_Medi_MainTest D ON D.id=A.MainTestId INNER JOIN Lab_Medi_Unit E ON E.name=A.Units inner join Lab_Medi_TemplateMain F on F.id=A.Id where A.id='" +id + "'");
            return dt;
        }
    }
}
