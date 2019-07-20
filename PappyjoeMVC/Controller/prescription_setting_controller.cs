using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
  public class prescription_setting_controller
    {
        prescription_setting_model _model = new prescription_setting_model();
        prescription_setting_interface intr;
        public prescription_setting_controller(prescription_setting_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public DataTable get_drug()
        {
            DataTable dt = _model.get_drug();
            return dt;
        }
        public void fill_type_combo()
        {
            DataTable dtb = _model.fill_type_combo();
            intr.FillTypeCombo(dtb);
        }
        public void fill_unit_combo()
        {
            DataTable dtb = _model.Fill_unit_combo();
            intr.FillUnitCombo(dtb);
        }
        public void get_value_from_drugtype(string type)
        {
            DataTable dtb = _model.get_value_from_drugtype(type);
            intr.SaveDrugType(dtb);
        }
        public void SaveDrug()
        {
            _model.StrType = intr.StrType;
            _model.save_drugtype();
        }
        public void check_unit(string unit)
        {
            DataTable dtb = _model.check_unit(unit);
            intr.CheckUnit(dtb);
        }
        public void save_unit()
        {
            _model.StrUnit = intr.StrUnit;
            _model.save_unit();
        }
        public DataTable check_drugname(string name)
        {
            DataTable dtb = _model.check_drugname(name);
            return dtb;
        }
        public int Save_Drug()
        {
            _model.Drugname = intr.DrugName;
            _model.StrType = intr.StrType;
            _model.StrUnit = intr.StrUnit;
            _model.Strength_gr = intr.Strength_gr;
            _model.Instruction = intr.Instruction;
            int i = _model.Save_Drug();
            return i;
        }
        public DataTable check_exists_drug(string id)
        {
            DataTable dtb=_model.check_exists_drug(id);
            return dtb;
        }
        public int Update_drug(string id)
        {
            _model.Drugname = intr.DrugName;
            _model.StrType = intr.StrType;
            _model.StrUnit = intr.StrUnit;
            _model.Strength_gr = intr.Strength_gr;
            _model.Instruction = intr.Instruction;
            int i = _model.Update_drug(id);
            return i;
        }
        public int delete_drug(string id)
        {
            int i = _model.delete_drug(id);
            return i;
        }
        public DataTable drug_search(string text)
        {
            DataTable dtb = _model.drug_search(text);
            return dtb;
        }
    }
}
