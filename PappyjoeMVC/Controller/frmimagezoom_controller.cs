using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class frmimagezoom_controller
    {

        frmimagezoom_interface intr;
        Attachments_model mdl = new Attachments_model();
        public frmimagezoom_controller(frmimagezoom_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void attach(int atid)
        {
            DataTable dt = mdl.attach(atid);
            intr.attach(dt);
        }
    }
}
