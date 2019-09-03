using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Calender_controller
    {
        Calender_model _model = new Calender_model();
        public DataTable get_practicetimingvalues()
        {
            DataTable dt = _model.get_practicetimingvalues();
            return dt;
        }
        public int update(string slot)
        {
            int i = _model.update(slot);
            return i;
        }
    }
}
