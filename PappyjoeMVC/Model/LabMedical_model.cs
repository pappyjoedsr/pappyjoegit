using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
    public class LabMedical_model
    {
        Connection db = new Connection();
        private string txtMainTest;
        public string MainTest
        {
            get { return txtMainTest; }
            set { txtMainTest = value; }
        }
        private string txtTestType;
        public string Test_Type
        {
            get { return txtTestType; }
            set { txtTestType = value; }
        }
        private string txtUnitadd;
        public string Unit
        {
            get { return txtUnitadd; }
            set { txtUnitadd = value; }
        }
        private string txtName, txtNVMale, txtNVFemale;
        public string testName
        {
            get { return txtName; }
            set { txtName = value; }
        }
        public string txtNVmale
        {
            get { return txtNVMale; }
            set { txtNVMale = value; }
        }
        public string txtNVfemale
        {
            get { return txtNVFemale; }
            set { txtNVFemale = value; }
        }
        private int cmbTesttype, CcmbUnit;
        public int Cmbtesttype
        {
            get { return cmbTesttype; }
            set { cmbTesttype = value; }
        }
        public int CmbUnit
        {
            get { return CcmbUnit; }
            set { CcmbUnit = value; }
        }
        private string txttemp;
        public string Temp_Name
        {
            get { return txttemp; }
            set { txttemp = value; }
        }
        public DataTable Main_test()
        {
            DataTable dt = db.table("select id,Main_test  from tbl_Lab_Medi_MainTest");
            return dt;
        }
        public DataTable Test_type()
        {
            DataTable tb = db.table("SELECT id, Name from tbl_Lab_Medi_TestType");
            return tb;
        }
        public DataTable tbUnit()
        {
            DataTable tbUnit = db.table("select id, Name from Lab_Medi_Unit");
            return tbUnit;
        }
        public DataTable test_temp()
        {
            DataTable tbMaintesttemp = db.table("select id,Main_test from tbl_Lab_Medi_MainTest");
            return tbMaintesttemp;
        }
        public int Main_test_save(string txtMainTest)
        {
            int s = db.execute("insert into tbl_Lab_Medi_MainTest (Main_test) values('" + txtMainTest + "')");
            return s;
        }
        public int Update_Maintest(string mtid)
        {
            int i = db.execute("Update tbl_Lab_Medi_MainTest set Main_test= '" + txtMainTest + "' where id ='" + Convert.ToInt32(mtid) + "'");
            return i;
        }
        public DataTable tpMain_testtype()
        {
            DataTable TEST_TYPE = db.table("select id, Name as'Test Type' from tbl_Lab_Medi_TestType");
            return TEST_TYPE;
        }
        public DataTable tpMain_unit()
        {
            DataTable Unit = db.table("select id,Name as'Unit' from Lab_Medi_Unit");
            return Unit;
        }
        public DataTable tpMain_test()
        {
            DataTable Test = db.table("SELECT Lab_Medi_Test.id, Lab_Medi_Test.Name as test,tbl_Lab_Medi_TestType.Name as Test_Type,Lab_Medi_Test.NormalValueM,Lab_Medi_Test.NormalValueF, Lab_Medi_Unit.Name as Unit FROM Lab_Medi_Unit INNER JOIN Lab_Medi_Test ON Lab_Medi_Unit.id=Lab_Medi_Test.UnitId Inner join tbl_Lab_Medi_TestType on tbl_Lab_Medi_TestType.id=Lab_Medi_Test.TestTypeID");
            return Test;
        }
        public DataTable tpMain_template()
        {
            DataTable TEMPLATE = db.table("select id,TemplateName from Lab_Medi_TemplateMain ");
            return TEMPLATE;
        }
        public DataTable Template_view()
        {
            DataTable TEMPLATE_View = db.table("select Lab_Medi_Template.Id  as id,Lab_Medi_Template.Id AS  SlNo , Lab_Medi_TemplateMain.id as templatemain_id, tbl_Lab_Medi_MainTest.Main_test , tbl_Lab_Medi_TestType.Name as Test_types,Lab_Medi_Test.Name as test,Lab_Medi_Unit.Name as Unit,Lab_Medi_Test.NormalValueM,Lab_Medi_Test.NormalValueF from Lab_Medi_Template inner join tbl_Lab_Medi_MainTest on Lab_Medi_Template.MainTestId = tbl_Lab_Medi_MainTest.id inner join Lab_Medi_TemplateMain on Lab_Medi_Template.id=Lab_Medi_TemplateMain.id inner join Lab_Medi_Test on Lab_Medi_Test.id= TestId inner join  tbl_Lab_Medi_TestType  on Lab_Medi_Test.TestTypeID= tbl_Lab_Medi_TestType.id inner join Lab_Medi_Unit on Lab_Medi_Unit.id=Lab_Medi_Test.UnitId");
            return TEMPLATE_View;
        }
        public DataTable tbtesttemp()
        {
            System.Data.DataTable tbtesttemp = db.table("select id,Name from Lab_Medi_Test");
            return tbtesttemp;
        }
        public int Save_testtype()
        {
            int i = db.execute("insert into tbl_Lab_Medi_TestType (Name) values('" + txtTestType + "') ");
            return i;
        }
        public int Update_testtype(string txtTtypeid)
        {
            int i = db.execute("Update tbl_Lab_Medi_TestType set Name= '" + txtTestType + "' where id ='" + Convert.ToInt32(txtTtypeid) + "'");
            return i;
        }
        public int Save_unit()
        {
            int i = db.execute("insert into Lab_Medi_Unit (Name) values('" + txtUnitadd + "') ");
            return i;
        }
        public int Update_unit(int txtunitid)
        {
            int i = db.execute("Update Lab_Medi_Unit set Name= '" + txtUnitadd + "' where id ='" + Convert.ToInt32(txtunitid) + "'");
            return i;
        }
        public int Save_test()
        {
            int i = db.execute("INSERT INTO Lab_Medi_Test (Name,NormalValueM,NormalValueF,TestTypeID,UnitId)VALUES('" + txtName + "','" + txtNVMale + "','" + txtNVFemale + "','" + cmbTesttype + "','" + CcmbUnit + "')");
            return i;
        }
        public int Update_test(int txttestid)
        {
            int i = db.execute("Update Lab_Medi_Test set Name= '" + txtName + "' ,TestTypeID='" + Convert.ToInt32(cmbTesttype) + "',NormalValueM = '" + txtNVMale + "', NormalValueF= '" + txtNVFemale + "',UnitId ='" + Convert.ToInt32(CcmbUnit) + "'  where id ='" + Convert.ToInt32(txttestid) + "'");
            return i;
        }
        public int TempName_save()
        {
            int i = db.execute("insert into Lab_Medi_TemplateMain (TemplateName) values('" + txttemp + "') ");
            return i;
        }
        public int select_Maxid()
        {
            int id = db.execute("select MAX(id) from Lab_Medi_TemplateMain");
            return id;
        }
        public DataTable Get_testnameid_ById(int cmbTesttemp)
        {
            DataTable test = db.table("select id , Name from Lab_Medi_Test where id ='" + cmbTesttemp + "' ");
            return test;
        }
        public DataTable Normavalue(int test)
        {
            DataTable Normavalue = db.table("select (NormalValueM +',' + NormalValueF ) as Normalvalue from Lab_Medi_Test  where id = '" + test + "' ");
            return Normavalue;
        }
        public int Insert_mediTemplate(int Id, int MainTestId, int TestId, object Units, string NormalValue)
        {
            int i = db.execute("insert into Lab_Medi_Template (Id,MainTestId,TestId,Units,NormalValue)values('" + Id + "', '" + MainTestId + "','" + TestId + "','" + Units + "','" + NormalValue + "')");
            return i;
        }
        public int Update_temp_name(int txtId)
        {
            int i = db.execute("Update Lab_Medi_TemplateMain set TemplateName= '" + txttemp + "' where id ='" + txtId + "'");
            return i;
        }
        public int Update_temp_Ids(int cmbmaintesttemp, int cmbTesttemp, int txtId)
        {
            int i = db.execute("Update Lab_Medi_Template set  MainTestId='" + cmbmaintesttemp + "',TestId='" + cmbTesttemp + "' where id ='" + txtId + "'");
            return i;
        }
        public DataTable TempAddItem_mainTest(string cmbmaintesttemp)
        {
            DataTable Maintest = db.table("select id,Main_test from tbl_Lab_Medi_MainTest where id= '" + cmbmaintesttemp + "' ");
            return Maintest;
        }
        public DataTable TempAddItem_testtype(string cmbtesttypetmp)
        {
            DataTable testtype = db.table("select id, Name from tbl_Lab_Medi_TestType where id = '" + cmbtesttypetmp + "' ");
            return testtype;
        }
        public DataTable TempAddItem_testname(string cmbTesttemp)
        {
            DataTable testname = db.table("select id,Name from Lab_Medi_Test where id ='" + cmbTesttemp + "'");
            return testname;
        }
        public DataTable TempAddItem_unitname(string cmbTesttemp)
        {
            DataTable Unitname = db.table("select A.Name from   Lab_Medi_Unit A inner join Lab_Medi_Test B on A.id=B.UnitId where B.id ='" + cmbTesttemp + "'");
            return Unitname;
        }
        public DataTable TempAddItem_test(int cmbTesttemp)
        {
            DataTable test = db.table("select id , Name from Lab_Medi_Test where id ='" + cmbTesttemp + "' ");
            return test;
        }
        public string TempAddItem_normM(int test)
        {
            string NormavalueM = db.scalar("select NormalValueM  from Lab_Medi_Test  where id = '" + test + "' ");
            return NormavalueM;
        }
        public string TempAddItem_normF(int test)
        {
            string NormavalueF = db.scalar("select NormalValueF  from Lab_Medi_Test  where id = '" + test + "' ");
            return NormavalueF;
        }
        public DataTable TempAddItem_normal(int test)
        {
            DataTable Normavalue = db.table("select (NormalValueM +',' + NormalValueF ) as Normalvalue from Lab_Medi_Test  where id = '" + test + "' ");
            return Normavalue;
        }
        public DataTable MainTest_byId(int txtMtid)
        {
            DataTable MAIN_TEST = db.table("select * from tbl_Lab_Medi_MainTest where id='" + txtMtid + "' ");
            return MAIN_TEST;
        }
        public string MainTest_countById(int txtMtid)
        {
            string MAIN_TEST = db.scalar("select count(*) from Lab_Medi_Template where MainTestId ='" + txtMtid + "'");
            return MAIN_TEST;
        }
        public int delete_Maintest(string id)
        {
            int d = db.execute("delete from tbl_Lab_Medi_MainTest where id='" + id + "'");
            return d;
        }
        public DataTable Testtype_byID(int txtTtypeid)
        {
            DataTable TEST_TYPE = db.table("select * from tbl_Lab_Medi_TestType where id='" + txtTtypeid + "' ");
            return TEST_TYPE;
        }
        public string testtype_countById(int txtTtypeid)
        {
            string MAIN_TEST = db.scalar("select count(*) from Lab_Medi_Test where TestTypeID ='" + txtTtypeid + "'");
            return MAIN_TEST;
        }
        public int delete_testtype(string id)
        {
            int d = db.execute("delete from tbl_Lab_Medi_TestType where id='" + id + "'");
            return d;
        }
        public DataTable Unit_byID(int txtunitid)
        {
            DataTable Unit = db.table("select * from Lab_Medi_Unit where id='" + txtunitid + "' ");
            return Unit;
        }
        public string UnitCount_byID(int txtunitid)
        {
            string Unitcheck = db.scalar("select count(*) from Lab_Medi_Test where UnitId ='" + txtunitid + "'");
            return Unitcheck;
        }
        public int del_unit(string id)
        {
            int d = db.execute("delete from Lab_Medi_Unit where id='" + id + "'");
            return d;
        }
        public DataTable test_ByID(int txttestid)
        {
            DataTable Test = db.table("select * from Lab_Medi_Test where id='" + txttestid + "' ");
            return Test;
        }
        public int testCount_byId(int txttestid)
        {
            int Testcheck = db.execute("select count(*) from Lab_Medi_Template where TestId ='" + txttestid + "' ");
            return Testcheck;
        }
        public int test_delete(string id)
        {
            int d = db.execute("delete from Lab_Medi_Test where id='" + id + "'");
            return d;
        }
        public DataTable temp_byId(int txtId)
        {
            DataTable TEMPLATE = db.table("select * from Lab_Medi_TemplateMain where id='" + txtId + "' ");
            return TEMPLATE;
        }
        public DataTable tb_mainShade(int txtId)
        {
            System.Data.DataTable tbshade = db.table("SELECT D.Main_test as 'Test Name',C.Name as 'SampleType',B.Name as 'Speciality',B.NormalValueM,B.NormalValueF,E.name as 'Units',A.NormalValue as'Normal Value',B.id as 'Test_id',D.id as'Main Id' FROM Lab_Medi_Template A INNER JOIN  Lab_Medi_Test B ON A.TestId=B.id INNER JOIN tbl_Lab_Medi_TestType C ON C.id=B.TestTypeID INNER JOIN tbl_Lab_Medi_MainTest D ON D.id=A.MainTestId INNER JOIN Lab_Medi_Unit E ON E.name=A.Units inner join Lab_Medi_TemplateMain F on F.id=A.Id where A.id='" + txtId + "'");
            return tbshade;
        }
        public int dele_temp(string id)
        {
            int d = db.execute("delete from Lab_Medi_TemplateMain where id='" + id + "'");
            return d;
        }
        public int delete_labTemp_main(int txtId)
        {
            int i=db.execute("Delete  from Lab_Medi_Template where Id='" + txtId + "'");
            return i;
        }
        public DataTable id_name_meditest(object cmbtesttypetmp)
        {
            System.Data.DataTable tbtesttemp = db.table("select id,Name from Lab_Medi_Test where TestTypeID ='" + cmbtesttypetmp + "' ");
            return tbtesttemp;
        }
    }
}