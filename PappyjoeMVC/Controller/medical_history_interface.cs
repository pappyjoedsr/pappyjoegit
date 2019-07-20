using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Controller
{
  public  interface medical_history_interface
    {
        string medical { get; set; }
        string group { get; set; }
        void SetController(medical_history_controller controller);
        void LoadMedical(DataTable dtb);
        void LoadGroup(DataTable dt);
    }
}
