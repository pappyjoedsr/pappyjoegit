using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public interface LabDental_interface
    {
        string worktypes { get; set; }
        string worknames { get; set; }
        string shades { get; set; }
        string alloys { get; set; }
        string labnames { get; set; }
        string address { get; set; }
        string phones { get; set; }
        string excecutive { get; set; }
        string cmbLabtype { get; set; }
        void SetController(LabDental_controller controller);
    }
}
