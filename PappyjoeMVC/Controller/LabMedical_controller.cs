using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class LabMedical_controller
    {
        LabMedical_model _model = new LabMedical_model();

        public DataTable Main_test_Dgv()
        {
            DataTable dt = _model.Main_test();
            return dt;
        }
        public DataTable fill_TestType()
        {
            DataTable dt = _model.Test_type();
            return dt;
        }
        public DataTable fill_Unit()
        {
            DataTable dt = _model.tbUnit();
            return dt;
        }
        public DataTable fill_Test()
        {
            DataTable dt = _model.test_temp();
            return dt;
        }
        public int Maintest_save(string txtMainTest)
        {
            int i = _model.Main_test_save(txtMainTest);
            return i;
        }
        public int Update_Main_test(string mtid,string txtMainTest)
        {
            int i = _model.Update_Maintest(mtid, txtMainTest);
            return i;
        }
        public DataTable tpMain_testtype()
        {
            DataTable dt = _model.tpMain_testtype();
            return dt;
        }
        public DataTable tpMain_unit()
        {
            DataTable dt = _model.tpMain_unit();
            return dt;
        }
        public DataTable tpMain_test()
        {
            DataTable dt = _model.tpMain_test();
            return dt;
        }
        public DataTable tpMain_template()
        {
            DataTable dt = _model.tpMain_template();
            return dt;
        }
        public DataTable Template_view()
        {
            DataTable dt = _model.Template_view();
            return dt;
        }
        public DataTable tbtesttemp()
        {
            DataTable dt = _model.tbtesttemp();
            return dt;
        }
        public int Save_Testtype(string txtTestType)
        {
            int i = _model.Save_testtype(txtTestType);
            return i;
        }
        public int Update_testtype(string txtTtypeid,string txtTestType)
        {
            int i = _model.Update_testtype(txtTtypeid, txtTestType);
            return i;
        }
        public int SaveUnit(string txtUnitadd)
        {
            int i = _model.Save_unit(txtUnitadd);
            return i;
        }
        public int UpdateUnit(int txtunitid,string txtUnitadd)
        {
            int i = _model.Update_unit(txtunitid, txtUnitadd);
            return i;
        }
        public int SaveTest(string txtName, string txtNVMale, string txtNVFemale, int cmbTesttype, int cmbUnit)
        {
            int i = _model.Save_test(txtName,txtNVMale, txtNVFemale,cmbTesttype, cmbUnit);
            return i;
        }
        public int Update_test( string txtName, int cmbTesttype, string txtNVMale, string txtNVFemale, int cmbUnit,int txttestid)
        {
            int i = _model.Update_test(txttestid, txtName, cmbTesttype, txtNVMale, txtNVFemale, cmbUnit);
            return i;
        }
        public int Tempname_save(string txttemp)
        {
            int i = _model.TempName_save(txttemp);
            return i;
        }
        public int Get_Maxid()
        {
            int dt = _model.select_Maxid();
            return dt;
        }
        public DataTable Get_test_byId(int cmbTesttemp)
        {
            DataTable dt = _model.Get_testnameid_ById(cmbTesttemp);
            return dt;
        }
        public DataTable Normavalue(int test)
        {
            DataTable dt = _model.Normavalue(test);
            return dt;
        }
        public int Insert_mediTemplate(int Id, int MainTestId, int TestId, object Units, string NormalValue)
        {
            int i = _model.Insert_mediTemplate(Id, MainTestId, TestId, Units, NormalValue);
            return i;
        }
        public int Update_temp_name(int txtId,string txttemp)
        {
            int i = _model.Update_temp_name(txtId, txttemp);
            return i;
        }
        public int Update_temp_Ids(int cmbmaintesttemp, int cmbTesttemp, int txtId)
        {
            int i = _model.Update_temp_Ids(cmbmaintesttemp, cmbTesttemp, txtId);
            return i;
        }
        public DataTable TempAddItem_mainTest(string cmbmaintesttemp)
        {
            DataTable dt = _model.TempAddItem_mainTest(cmbmaintesttemp);
            return dt;
        }
        public DataTable TempAddItem_testtype(string cmbtesttypetmp)
        {
            DataTable testtype = _model.TempAddItem_testtype(cmbtesttypetmp);
            return testtype;
        }
        public DataTable TempAddItem_testname(string cmbTesttemp)
        {
            DataTable db = _model.TempAddItem_testname(cmbTesttemp);
            return db;
        }
        public DataTable TempAddItem_unitname(string cmbTesttemp)
        {
            DataTable dt = _model.TempAddItem_unitname(cmbTesttemp);
            return dt;
        }
        public DataTable TempAddItem_test(int cmbTesttemp)
        {
            DataTable dt = _model.TempAddItem_test(cmbTesttemp);
            return dt;
        }
        public string TempAddItem_normM(int test)
        {
            string dt = _model.TempAddItem_normM(test);
            return dt;
        }
        public string TempAddItem_normF(int test)
        {
            string dt = _model.TempAddItem_normF(test);
            return dt;
        }
        public DataTable TempAddItem_normal(int test)
        {
            DataTable dt = _model.TempAddItem_normal(test);
            return dt;
        }
        public DataTable MainTest_byId(int txtMtid)
        {
            DataTable dt = _model.MainTest_byId(txtMtid);
            return dt;
        }
        public string MainTest_countById(int txtMtid)
        {
            string dt = _model.MainTest_countById(txtMtid);
            return dt;
        }
        public int delete_Maintest(string id)
        {
            int i = _model.delete_Maintest(id);
            return i;
        }
        public DataTable Testtype_byID(int txtTtypeid)
        {
            DataTable dt = _model.Testtype_byID(txtTtypeid);
            return dt;
        }
        public string testtype_countById(int txtTtypeid)
        {
            string dt = _model.testtype_countById(txtTtypeid);
            return dt;
        }
        public int delete_testtype(string id)
        {
            int i = _model.delete_testtype(id);
            return i;
        }
        public DataTable Unit_byID(int txtunitid)
        {
            DataTable dt = _model.Unit_byID(txtunitid);
            return dt;
        }
        public string UnitCount_byID(int txtunitid)
        {
            string dt = _model.UnitCount_byID(txtunitid);
            return dt;
        }
        public int del_unit(string id)
        {
            int i = _model.del_unit(id);
            return i;
        }
        public DataTable test_ByID(int txttestid)
        {
            DataTable dt = _model.test_ByID(txttestid);
            return dt;
        }
        public int testCount_byId(int txttestid)
        {
            int dt = _model.testCount_byId(txttestid);
            return dt;
        }
        public int test_delete(string id)
        {
            int i = _model.test_delete(id);
            return i;
        }
        public DataTable temp_byId(int txtId)
        {
            DataTable dt = _model.temp_byId(txtId);
            return dt;
        }
        public DataTable tb_mainShade(int txtId)
        {
            DataTable dt = _model.tb_mainShade(txtId);
            return dt;
        }
        public int dele_temp(string id)
        {
            int i = _model.dele_temp(id);
            return i;
        }
        public int delete_labTemp_main(int txtId)
        {
            int i = _model.delete_labTemp_main(txtId);
            return i;
        }
        public DataTable id_name_meditest(object cmbtesttypetmp)
        {
            DataTable dt = _model.id_name_meditest(cmbtesttypetmp);
            return dt;
        }
    }
}
