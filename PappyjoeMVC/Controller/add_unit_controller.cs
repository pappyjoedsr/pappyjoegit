using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Add_Unit_controller
    {
        Add_Unit_model _model = new Add_Unit_model();
        Common_model cmodel = new Common_model();
        public DataTable Load_Data()
        {
            DataTable dtb = cmodel.Fill_unit_combo();
            return dtb;
        }
        public DataTable get_units()
        {
            DataTable dtb = cmodel.Fill_unit_combo();
            return dtb;
        }
        public int save(string Units)
        {
            int i = _model.save(Units);
            return i;
        }
        public int update(string unitid, string _unit)
        {

            int j = _model.update(unitid, _unit);
            return j;
        }
        public int delete(string id)
        {
            int j = _model.delete(id);
            return j;
        }
    }
}
