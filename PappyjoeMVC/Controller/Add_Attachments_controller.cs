using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Add_Attachments_controller
    {
        Add_Attachments_interface intr;
        Add_Attachments_model mdl = new Add_Attachments_model();
        common_model cmdl = new common_model();
        public Add_Attachments_controller(Add_Attachments_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void selid()
        {
            DataTable dt = mdl.selid();
            intr.selid(dt);
        }
        public void Get_CompanyNAme()
        {
            DataTable dt = cmdl.Get_CompanyNAme();
            intr.Get_CompanyNAme(dt);
        }
        public void Get_DoctorName(string id)
        {
            DataTable dt = cmdl.Get_DoctorName(id);
            intr.Get_DoctorName(dt);
        }
        public void getcategory()
        {
            DataTable dt = mdl.getcategory();
            intr.getcategory(dt);
        }
        public void getpatdetails(string id)
        {
            DataTable dt = mdl.getpatdetails(id);
            intr.getpatdetails(dt);
        }
        public void getpayment(string patid)
        {
            DataTable dt = mdl.getpayment(patid);
            intr.getpayment(dt);
        }
        public int insattach()
        {
            mdl.patid = intr.patid;
            mdl.image = intr.image;
            mdl.docid = intr.id;
            mdl.path = intr.path;
            mdl.categryname = intr.catgryname;
            int j = mdl.insattach();
            return j;
        }
        public void Patient_search(string txtbox)
        {
            DataTable dt = cmdl.Patient_search(txtbox);
            intr.Patient_search(dt);
        }
    }
}
