using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
    public class LabMedical_controller
    {
        LabMedical_model _model = new LabMedical_model();
        LabMedical_interface intr;
        public LabMedical_controller(LabMedical_interface inttr)
        {
            intr = inttr;
            intr.setcontroller(this);
        }

        public void Main_test_Dgv()
        {
            DataTable dt = _model.Main_test();
            intr.Fill_dgvMainTest(dt);
        }
        public DataTable fill_TestType()
        {
            DataTable dt = _model.Test_type();
            return dt;
            //intr.fill_TestType(dt);
        }
        public DataTable fill_Unit()
        {
            DataTable dt = _model.tbUnit();
            return dt;
            //intr.fill_Unit(dt);
        }
        public DataTable fill_Test()
        {
            DataTable dt = _model.test_temp();
            return dt;
            //intr.fill_Test(dt);
        }
        //public DataTable fill_Template()
        //{
        //    DataTable dt = _model.testtypetemp();
        //    return dt;
        //    //intr.fill_Template(dt);
        //}
        public int Maintest_save(string txtMainTest)
        {
            _model.MainTest = intr.Main_Test;
            int i = _model.Main_test_save(txtMainTest);
            return i;
        }
        public int Update_Main_test(string mtid)
        {
            _model.MainTest = intr.Main_Test;
            int i = _model.Update_Maintest(mtid);
            return i;
        }
        public void tpMain_testtype()
        {
            DataTable dt = _model.tpMain_testtype();
            intr.fill_TestType(dt);
        }
        public void tpMain_unit()
        {
            DataTable dt = _model.tpMain_unit();
            intr.fill_Unit(dt);
        }
        public void tpMain_test()
        {
            DataTable dt = _model.tpMain_test();
            intr.fill_Test(dt);
        }
        public void tpMain_template()
        {
            DataTable dt = _model.tpMain_template();
            intr.fill_Template(dt);
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
        public int Save_Testtype()
        {
            _model.Test_Type = intr.Test_type;
            int i = _model.Save_testtype();
            return i;
        }
        public int Update_testtype(string txtTtypeid)
        {
            _model.Test_Type = intr.Test_type;
            int i = _model.Update_testtype(txtTtypeid);
            return i;
        }
        public int SaveUnit()
        {
            _model.Unit = intr.Units;
            int i = _model.Save_unit();
            return i;
        }
        public int UpdateUnit(int txtunitid)
        {
            _model.Unit = intr.Units;
            int i = _model.Update_unit(txtunitid);
            return i;
        }
        public int SaveTest()
        {
            _model.testName = intr.TestName;
            _model.txtNVfemale = intr.txtNVfemale;
            _model.txtNVmale = intr.txtNVmale;
            _model.Cmbtesttype = intr.Cmbtesttype;
            _model.CmbUnit = intr.CmbUnit;
            int i = _model.Save_test();
            return i;
        }
        public int Update_test(int txttestid)
        {
            _model.testName = intr.TestName;
            _model.txtNVfemale = intr.txtNVfemale;
            _model.txtNVmale = intr.txtNVmale;
            _model.Cmbtesttype = intr.Cmbtesttype;
            _model.CmbUnit = intr.CmbUnit;
            int i = _model.Update_test(txttestid);
            return i;
        }
        public int Tempname_save()
        {
            _model.Temp_Name = intr.TempName;
            int i = _model.TempName_save();
            return i;
        }
        public DataTable Get_Maxid()
        {
            DataTable dt = _model.select_Maxid();
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
        public int Insert_mediTemplate(int Id, int MainTestId, int TestId,object Units, string NormalValue)
        {
            //_model.Temp_id = intr.id;
            //_model.TempItem = intr.tempitem;
            //_model.cmbMainTemp = intr.cmbmaintemp;
            //_model.CmbUnit = intr.cmbUnit;
            //_model.Normal = intr.norm;
            int i = _model.Insert_mediTemplate(Id, MainTestId, TestId, Units, NormalValue);
            return i;
        }
        public int Update_temp_name(int txtId)
        {
            _model.Temp_Name = intr.TempName;
            int i = _model.Update_temp_name(txtId);
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
        public DataTable TempAddItem_normM(int test)
        {
            DataTable dt = _model.TempAddItem_normM(test);
            return dt;
        }
        public DataTable TempAddItem_normF(int test)
        {
            DataTable dt = _model.TempAddItem_normF(test);
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
        public DataTable MainTest_countById(int txtMtid)
        {
            DataTable dt = _model.MainTest_countById(txtMtid);
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
        public DataTable testtype_countById(int txtTtypeid)
        {
            DataTable dt = _model.testtype_countById(txtTtypeid);
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
        public DataTable UnitCount_byID(int txtunitid)
        {
            DataTable dt = _model.UnitCount_byID(txtunitid);
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
        public DataTable testCount_byId(int txttestid)
        {
            DataTable dt = _model.testCount_byId(txttestid);
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
