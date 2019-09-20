using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class LabResultEntry_model
    {
        Connection db = new Connection();
        public DataTable LoadResult(string patid,string wrkid)
        {
            DataTable dt = db.table("SELECT distinct '' as 'SlNo', B.Main_test as'Main Test',D.Name as 'Test Type',C.Name as 'Test',A.results as 'Result',F.Units,F.Normalvalue as 'Normal Value',C.id as 'Typeid',A.id as 'id',A.Resultmain_id FROM Lab_Medi_LabResult A INNER JOIN tbl_Lab_Medi_MainTest B ON A.maintest_id=B.id INNER JOIN Lab_Medi_Test C ON A.test_id=C.id INNER JOIN tbl_Lab_Medi_TestType D On D.id=C.TestTypeID  inner join tbl_lab_main E ON E.id=A.Resultmain_id inner join Lab_Medi_Template F on F.TestId=C.id WHERE E.pt_id='" + patid+ "' and E.id='" + wrkid + "'");
            return dt;
        }
        public int rsltupdate(string rslts, string testid, string id, string rsltmainid)
        {
            int j = db.execute("UPDATE Lab_Medi_LabResult SET results='" + rslts + "' WHERE test_id='" + testid + "' and id='" + id + "' and Resultmain_id='" + rsltmainid + "'");
            return j;
        }
    }
}
