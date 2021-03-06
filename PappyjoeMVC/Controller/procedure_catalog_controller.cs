﻿using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Procedure_Catalog_controller
    {
        Procedure_Catalog_model _model = new Procedure_Catalog_model();
        public DataTable FormLoad()
        {
            DataTable dtb = _model.FormLoad();
            return dtb;
        }
        public DataTable get_procedure_category_value()
        {
            DataTable dtb = _model.get_procedure_category_value();
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
            int i = _model.save_addprocedure(_procName, _procost, _comboCategory, _notes);
            return i;
        }
        public int update_addprocedure(string _procName, string _procost, string _comboCategory, string _notes, string pro_id)
        {
            int i = _model.update_addprocedure(_procName, _procost, _comboCategory, _notes,pro_id);
            return i;
        }
        public string Get_GST_id()
        {
            string s = _model.Get_GST_id();
            return s;
        }
        public void save_proceduretax(int id1, int pid)
        {
            _model.save_proceduretax(id1, pid);
        }
        public void update_proceduretax(int id1, int pid)
        {
            _model.update_proceduretax(id1, pid);
        }
        public string Get_IGST_id()
        {
            string s = _model.Get_IGST_id();
            return s;
        }
        public DataTable srchprocedure(string name)
        {
            DataTable dtb = _model.srchprocedure(name);
            return dtb;
        }
        public int delproceduretax(int procid)
        {
           int i=_model.delproceduretax(procid);
           return i;
        }
        public int delprocdresetngs(int procid)
        {
            int ii=_model.delprocdresetngs(procid);
            return ii;
        }
        public DataTable check_procedureid(string procid)
        {
            DataTable dtb = _model.check_procedureid(procid);
            return dtb;
        }

    }
}
