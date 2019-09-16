using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Add_Unit_controller
    {
        Add_Unit_model _model = new Add_Unit_model();
        public DataTable Load_Data()
        {
            DataTable dtb = _model.Load_Data();
            return dtb;
        }
        public DataTable get_units()
        {
            DataTable dtb = _model.Load_Data();
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
