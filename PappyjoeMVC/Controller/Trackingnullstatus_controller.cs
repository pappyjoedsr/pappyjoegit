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
        Trackingnullstatus_interface intr;
        LabtrackingReport_model mdl = new LabtrackingReport_model();
        public Trackingnullstatus_controller(Trackingnullstatus_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void trackngnullstatus()
        {
            DataTable dt = mdl.trackngnullstatus();
            intr.trackngnullstatus(dt);
        }
    }
}
