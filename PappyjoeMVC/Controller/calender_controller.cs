using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
  public class calender_controller
    {
        calender_model _model = new calender_model();
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
