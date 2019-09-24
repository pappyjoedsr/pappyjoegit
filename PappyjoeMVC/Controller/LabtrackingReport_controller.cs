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
        Common_model cm = new Common_model();
        LabtrackingReport_model mdl = new LabtrackingReport_model();
        Dentalwork_model dm = new Dentalwork_model();
        public DataTable selectall()
        {
            DataTable dt = mdl.selectall();
            return dt;
        }
        public DataTable txtkeypress()
        {
            DataTable dt = mdl.txtkeypress();
            return dt;
        }
        public DataTable txtkeypress2(string pt_name)
        {
            DataTable dt = mdl.txtkeypress2(pt_name);
            return dt;
        }
        public DataTable txtkeyup()
        {
            DataTable dt = mdl.txtkeyup();
            return dt;
        }
        public DataTable txtkeyup2(string pt_name)
        {
            DataTable dt = mdl.txtkeyup2(pt_name);
            return dt;
        }
        public DataTable stactive()
        {
            DataTable dt = mdl.stactive();
            return dt;
        }
        public DataTable statsent()
        {
            DataTable dt = mdl.statsent();
            return dt;
        }
        public DataTable statinproductn()
        {
            DataTable dt = mdl.statinproductn();
            return dt;
        }
        public DataTable statintransit()
        {
            DataTable dt = mdl.statintransit();
            return dt;
        }
        public DataTable statreceived()
        {
            DataTable dt = mdl.statreceived();
            return dt;
        }
        public DataTable statoverdue()
        {
            DataTable dt = mdl.statoverdue();
            return dt;
        }
        public DataTable notnullstatus()
        {
            DataTable dt = mdl.notnullstatus();
            return dt;
        }
        public DataTable duedtetoday(string today)
        {
            DataTable dt = mdl.duedtetoday(today);
            return dt;
        }
        public DataTable duedtetommarrow(string tommarrow)
        {
            DataTable dt = mdl.duedtetommarrow(tommarrow);
            return dt;
        }
        public DataTable Patient_search(string txtbox)
        {
            DataTable dt = cm.Patient_search(txtbox);
            return dt;
        }
        public string userprivilege(string doctrid)
        {
            string e = mdl.userprivilege(doctrid);
            return e;
        }
        public DataTable practicedetails()
        {
            DataTable dt = cm.practicedetails();
            return dt;
        }
    }
}
