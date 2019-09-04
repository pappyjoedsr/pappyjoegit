using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Add_Unit_controller
    {
        add_unit_interface intr;
        Add_Unit_model _model = new Add_Unit_model();
        public Add_Unit_controller(add_unit_interface inttr)
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
