using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public interface export_interface
    {
        void SetController(export_controller controller);
        void Fill_Combo(DataTable dtb);
    }
}
