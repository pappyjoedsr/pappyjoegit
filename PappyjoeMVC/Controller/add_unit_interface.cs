using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface add_unit_interface
    {
        string Units { get; set; }
        void SetController(add_unit_controller controller);
        void LoadData(DataTable dtb);
    }
}
