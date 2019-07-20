using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface Add_Vital_Signs_interface
    {
        string txtpulse { get; set; }
        string temp { get; set; }
        string bp { get; set; }
        string bp_dias { get; set; }
        //string Bp_type { get; set; }
        //string temptype { get; set; }
        string Weight { get; set; }
        string resp { get; set; }
        string date { get; set; }
        string txtheight { get; set; }
        void setcontroller(Add_Vital_Signs_controller controller);
    }
}
