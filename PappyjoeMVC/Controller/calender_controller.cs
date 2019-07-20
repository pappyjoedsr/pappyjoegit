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
        Connection db = new Connection();
        calender_interface intr;
        calender_model _model = new calender_model();
        public calender_controller(calender_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
       
        public void get_practicetimingvalues()
        {
            DataTable dt = _model.get_practicetimingvalues();
            intr.FormLoad(dt);
        }
        public int update(string slot)
        {
            int i = _model.update(slot);
            return i;
        }
    }
}
