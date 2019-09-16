using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Trackingnullstatus_controller
    {
        LabtrackingReport_model mdl = new LabtrackingReport_model();
        public DataTable trackngnullstatus()
        {
            DataTable dt = mdl.trackngnullstatus();
            return dt;
        }
    }
}
