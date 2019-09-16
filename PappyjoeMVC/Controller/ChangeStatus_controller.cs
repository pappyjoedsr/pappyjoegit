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
        LabtrackingReport_model mdl = new LabtrackingReport_model();
        public int statusupdate(string trstatus,string id)
        {
            int i = mdl.statusupdate(trstatus,id);
            return i;
        }
    }
}
