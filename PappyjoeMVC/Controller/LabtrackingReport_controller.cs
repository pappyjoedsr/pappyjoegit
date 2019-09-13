using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class LabtrackingReport_controller
    {
        LabtrackingReport_interface intr;
        common_model cm = new common_model();
        dentalwork_model dm = new dentalwork_model();
        LabtrackingReport_model mdl = new LabtrackingReport_model();
        public LabtrackingReport_controller(LabtrackingReport_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void selectall()
        {
            DataTable dt = mdl.selectall();
            intr.selectall(dt);
        }
        public void txtkeypress()
        {
            DataTable dt = mdl.txtkeypress();
            intr.txtkeypress(dt);
        }
        public void txtkeypress2(string pt_name)
        {
            DataTable dt = mdl.txtkeypress2(pt_name);
            intr.txtkeypress2(dt);
        }
        public void txtkeyup()
        {
            DataTable dt = mdl.txtkeyup();
            intr.txtkeyup(dt);
        }
        public void txtkeyup2(string pt_name)
        {
            DataTable dt = mdl.txtkeyup2(pt_name);
            intr.txtkeyup2(dt);
        }
        public void stactive()
        {
            DataTable dt = mdl.stactive();
            intr.stactive(dt);
        }
        public void statsent()
        {
            DataTable dt = mdl.statsent();
            intr.statsent(dt);
        }
        public void statinproductn()
        {
            DataTable dt = mdl.statinproductn();
            intr.statinproductn(dt);
        }
        public void statintransit()
        {
            DataTable dt = mdl.statintransit();
            intr.statintransit(dt);
        }
        public void statreceived()
        {
            DataTable dt = mdl.statreceived();
            intr.statreceived(dt);
        }
        public void statoverdue()
        {
            DataTable dt = mdl.statoverdue();
            intr.statoverdue(dt);
        }
        public void notnullstatus()
        {
            DataTable dt = mdl.notnullstatus();
            intr.notnullstatus(dt);
        }
        public void duedtetoday(string today)
        {
            DataTable dt = mdl.duedtetoday(today);
            intr.duedtetoday(dt);
        }
        public void duedtetommarrow(string tommarrow)
        {
            DataTable dt = mdl.duedtetommarrow(tommarrow);
            intr.duedtetommarrow(dt);
        }
        public void Patient_search(string txtbox)
        {
            DataTable dt = cm.Patient_search(txtbox);
            intr.Patient_search(dt);
        }
        public void userprivilege(string doctrid)
        {
            string e = mdl.userprivilege(doctrid);
            intr.userprivilege(e);
        }
        public void practicedetails()
        {
            DataTable dt = dm.practicedetails();
            intr.practicedetails(dt);
        }
    }
}
