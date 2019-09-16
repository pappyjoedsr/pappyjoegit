using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class LabWorks_controller
    {
        LabWorks_interface intr;
        LabWorks_model mdl = new LabWorks_model();
        common_model cmdl = new common_model();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
        public LabWorks_controller(LabWorks_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void Get_Patient_Details(string patid)
        {
            DataTable dt = cmdl.Get_Patient_Details(patid);
            intr.Get_Patient_Details(dt);
        }
        public void tbmain(string patid,string workid)
        {
            DataTable dt = mdl.tbmain(patid,workid);
            intr.tbmain(dt);
        }
        public void Get_Practice_details()
        {
            DataTable dt = cmdl.Get_Practice_details();
            intr.Get_Practice_details(dt);
        }
        public void Get_DoctorName(string doctrid)
        {
            string dt = cmdl.Get_DoctorName(doctrid);
            intr.Get_DoctorName(dt);
        }
        public void Getdata(string patid)
        {
            DataTable dt = mdl.Getdata(patid);
            intr.Getdata(dt);
        }
        public void practicedetails()
        {
            DataTable dt =dm.practicedetails();
            intr.practicedetails(dt);
        }
        public void printdetails(string patid,string workname,string wrkiddental)
        {
            DataTable dt = mdl.printdetails(patid,workname,wrkiddental);
            intr.printdetails(dt);
        }
        public void seltype(string patid,string id)
        {
            DataTable dt = mdl.seltype(patid,id);
            intr.seltype(dt);
        }
        public void getprev(string doctrid)
        {
            string e = mdl.getprev(doctrid);
            intr.getprev(e);
        }
        public void smsinfo()
        {
            DataTable dt = mdl.smsinfo();
            intr.smsinfo(dt);
        }
        public void Patient_search(string txtbox)
        {
            DataTable dt= cmdl.Patient_search(txtbox);
            intr.Patient_search(dt);
        }
        public void doctr_privillage_for_addnewPatient(string doctrid)
        {
            string t = cmdl.doctr_privillage_for_addnewPatient(doctrid);
            intr.doctr_privillage_for_addnewPatient(t);
        }
    }
}
