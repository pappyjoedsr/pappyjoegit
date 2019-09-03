using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface Finished_Procedure_interface
    {
        void Setcontroller(Finished_Procedre_controller controller);
        void Load_Data(DataTable dtb);
    }
}
