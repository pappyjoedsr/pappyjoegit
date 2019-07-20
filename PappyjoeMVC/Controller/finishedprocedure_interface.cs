using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface finishedprocedure_interface
    {
        void Setcontroller(finishedprocedre_controller controller);
        void Load_Data(DataTable dtb);
    }
}
