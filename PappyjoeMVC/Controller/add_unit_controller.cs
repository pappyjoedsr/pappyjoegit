using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
  public  class add_unit_controller
    {
        add_unit_interface intr;
        add_unit_model _model = new add_unit_model();
        public add_unit_controller(add_unit_interface inttr )
        {
            intr = inttr;
            intr.SetController(this);
        }
        public void Load_Data()
        {
            DataTable dtb = _model.Load_Data();
            intr.LoadData(dtb);
        }
        public DataTable get_units()
        {
            DataTable dtb = _model.Load_Data();
            return dtb;
        }
        public int save()
        {
            _model.UNit = intr.Units;
            int i = _model.save();
            return i;
        }
        public int update(string unitid)
        {
            _model.UNit = intr.Units;
            int j = _model.update(unitid);
            return j;
        }
        public int delete(string id)
        {
            int j = _model.delete(id);
            return j;
        }
     

    }
}
