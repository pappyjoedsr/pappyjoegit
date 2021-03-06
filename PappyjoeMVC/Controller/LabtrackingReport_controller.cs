﻿using PappyjoeMVC.Model;
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
        Communication_model c = new Communication_model();
        public DataTable selectall(string jobno)
        {
            DataTable dt = mdl.selectall(jobno);
            return dt;
        }
        public DataTable txtkeypress()
        {
            DataTable dt = mdl.txtkeypress();
            return dt;
        }
        public DataTable txtkeypress2(string phn_no)
        {
            DataTable dt = mdl.txtkeypress2(phn_no);
            return dt;
        }
        public DataTable txtkeyup()
        {
            DataTable dt = mdl.txtkeyup();
            return dt;
        }
        public DataTable txtkeyup2(string phn_no)
        {
            DataTable dt = mdl.txtkeyup2(phn_no);
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
        public string permission_for_settings(string doctor_id)
        {
            string dtb = cm.permission_for_settings(doctor_id);
            return dtb;
        }
        public DataTable practicedetails()
        {
            DataTable dt = cm.practicedetails();
            return dt;
        }
        public string doctr_privillage_for_addnewPatient(string doctrid)
        {
            string t = cm.doctr_privillage_for_addnewPatient(doctrid);
            return t;
        }
        public string frmInventory(string doctor_id)
        {
            string s = c.frmInventory(doctor_id);
            return s;
        }
    }
}
