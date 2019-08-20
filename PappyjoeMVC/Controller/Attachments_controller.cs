using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Attachments_controller
    {
        Attachments_interface intr;
        Add_Attachments_model m = new Add_Attachments_model();
        Attachments_model mdl = new Attachments_model();
        common_model cmdl = new common_model();
        Connection db = new Connection();
        public Attachments_controller(Attachments_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void selid(string id)
        {
            string t = mdl.selid(id);
            intr.selid(t);
        }
        public void getid(string gid)
        {
            string k = mdl.getid(gid);
            intr.getid(k);
        }
        public string Load_CompanyName()
        {
            string dtb = cmdl.Load_CompanyName();
            return dtb;
        }
        public void Get_DoctorName(string id)
        {
            DataTable dt = cmdl.Get_DoctorName(id);
            intr.Get_DoctorName(dt);
        }
        public void getcategory()
        {
            DataTable dt =m.getcategory();
            intr.getcategory(dt);
        }
        public void getpath()
        {
            mdl.atchid = intr.attachid;
            string dt = mdl.getpath();
            intr.getpath(dt);
        }
        public void getpatdetails(string id)
        {
            DataTable dt = m.getpatdetails(id);
            intr.getpatdetails(dt);
        }
        public void getattachment()
        {
            mdl.patid = intr.patid;
            DataTable dt = mdl.getattachment();
            intr.getattachment(dt);
        }
        public void getattachment2()
        {
            mdl.patid = intr.patid;
            mdl.categryname = intr.catgryname;
            DataTable dt = mdl.getattachment2();
            intr.getattachment2(dt);
        }
        public int inscatgry()
        {
            mdl.categryname = intr.catgryname;
            int j = mdl.inscatgry();
            return j;
        }
        public void Patient_search(string txtbox)
        {
            DataTable dt = cmdl.Patient_search(txtbox);
            intr.Patient_search(dt);
        }
        public int update()
        {
            mdl.catid = intr.catgryid;
            mdl.categryname = intr.catgryname;
            int i=mdl.update();
            return i;
        }
        public int delete()
        {
            mdl.catid = intr.catgryid;
            int j = mdl.delete();
            return j;
        }
        public int delattach()
        {
            mdl.atchid = intr.attachid;
            int p = mdl.delattach();
            return p;
        }
        public string getserver()
        {
            string ret = db.server();
            return ret;
        }
    }
}
