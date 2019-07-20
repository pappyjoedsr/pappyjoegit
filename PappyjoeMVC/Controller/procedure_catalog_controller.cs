using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public class procedure_catalog_controller
    {
        procedure_catalog_interface intr;
         procedure_catalog_model _model=new procedure_catalog_model();   
        public procedure_catalog_controller(procedure_catalog_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public void FormLoad()
        {
            DataTable dtb = _model.FormLoad();
            intr.FormLoad(dtb);
        }
        public void get_procedure_category_value()
        {
            DataTable dtb=_model.get_procedure_category_value();
            intr.AddCategory(dtb); 
        }
        public DataTable Get_category_name()
        {
            _model.TextCategory = intr.TextCategory;
            DataTable dt = _model.Get_category_name();
            return dt;
        }
        public void save()
        {
            _model.TextCategory = intr.TextCategory;
            _model.save();
        }
        public void get_procedureName()
        {
            _model.ProcedureName = intr.ProcedureName;
            DataTable dtb = _model.get_procedureName();
            intr.GetProcedureName(dtb);
        }
        public DataTable get_procedureid()
        {
            _model.ProcedureName = intr.ProcedureName;
            DataTable dtb = _model.get_procedureName();
            return dtb;
        }
        public int save_addprocedure()
        {
            _model.ProcedureName = intr.ProcedureName;
            _model.ProcedCost = intr.ProcedCost;
            _model.ComboCategory = intr.ComboCategory;
            _model.Notes = intr.Notes;
            int i = _model.save_addprocedure();
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
