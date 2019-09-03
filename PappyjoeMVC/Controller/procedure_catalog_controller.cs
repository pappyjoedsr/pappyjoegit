using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public class Procedure_Catalog_controller
    {
        Procedure_Catalog_model _model=new Procedure_Catalog_model();  
        public DataTable FormLoad()
        {
            DataTable dtb = _model.FormLoad();
            return dtb;
        }
        public DataTable get_procedure_category_value()
        {
            DataTable dtb=_model.get_procedure_category_value();
            return dtb; 
        }
        public DataTable Get_category_name(string TextCategory)
        {
             DataTable dt = _model.Get_category_name(TextCategory);
            return dt;
        }
        public void save(string TextCategory)
        {
            _model.save(TextCategory);
        }
        public DataTable get_procedureName(string ProcedureName)
        {
            DataTable dtb = _model.get_procedureName(ProcedureName);
            return dtb;
        }
        public DataTable get_procedureid(string ProcedureName)
        {
            DataTable dtb = _model.get_procedureName(ProcedureName);
            return dtb;
        }
        public int save_addprocedure(string _procName, string _procost, string _comboCategory, string _notes)
        {
            int i = _model.save_addprocedure(_procName,  _procost,  _comboCategory,  _notes);
            return i;
        }
        public string Get_GST_id()
        {
            string s = _model.Get_GST_id();
            return s;
        }
        public void save_proceduretax(int id1, int pid)
        {
            _model.save_proceduretax(id1,pid);
        }
        public string Get_IGST_id()
        {
            string s = _model.Get_IGST_id();
            return s;
        }
    }
}
