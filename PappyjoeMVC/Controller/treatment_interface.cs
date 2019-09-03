using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
   public interface treatment_interface
    {
        void SetController(Treatment_controller controller);
        void load_treatment(DataTable dtb);
    }
}
