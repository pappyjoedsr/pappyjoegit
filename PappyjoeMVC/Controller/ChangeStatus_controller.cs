using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class ChangeStatus_controller
    {
        ChangeStatus_interface intr;
        LabtrackingReport_model mdl = new LabtrackingReport_model();
        public ChangeStatus_controller(ChangeStatus_interface inttr)
        {
            intr = inttr;
            inttr.setController(this);
        }
        public int statusupdate(string trstatus,string id)
        {
            int i = mdl.statusupdate(trstatus,id);
            return i;
        }
    }
}
