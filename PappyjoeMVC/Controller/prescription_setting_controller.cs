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
        public DataTable get_drug()
        {
            DataTable dt = _model.get_drug();
            return dt;
        }
        public DataTable fill_type_combo()
        {
            DataTable dtb = _model.fill_type_combo();
            return dtb;
        }
        public DataTable fill_unit_combo()
        {
            DataTable dtb = _model.Fill_unit_combo();
            return dtb;
        }
        public DataTable get_value_from_drugtype(string type)
        {
            DataTable dtb = _model.get_value_from_drugtype(type);
            return dtb;
        }
        public void SaveDrug(string StrType)
        {
            _model.save_drugtype(StrType);
        }
        public DataTable check_unit(string unit)
        {
            DataTable dtb = _model.check_unit(unit);
            return dtb;
        }
        public void save_unit(string StrUnit)
        {
            _model.save_unit( StrUnit);
        }
        public string check_drugname(string name)
        {
            string dtb = _model.check_drugname(name);
            return dtb;
        }
        public int Save_Drug(string _drugname, string _strtype, string _strunit, string _strengthgr, string _intstructuion)
        {
            int i = _model.Save_Drug(_drugname,_strtype,_strunit,_strengthgr,_intstructuion);
            return i;
        }
        public string check_exists_drug(string id)
        {
            string dtb=_model.check_exists_drug(id);
            return dtb;
        }
        public int Update_drug(string id, string _drugname, string _strtype, string _strunit, string _strengthgr, string _intstructuion)
        {
            int i = _model.Update_drug(id, _drugname, _strtype, _strunit, _strengthgr, _intstructuion);
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
