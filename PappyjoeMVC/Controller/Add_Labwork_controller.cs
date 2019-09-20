using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Add_Labwork_controller
    {
        Common_model cm = new Common_model();
        LabWorks_model lm = new LabWorks_model();
        Add_Labwork_model mdl = new Add_Labwork_model();
        public DataTable Get_Patient_Details(string patid)
        {
            DataTable dt = cm.Get_Patient_Details(patid);
            return dt;
        }
        public DataTable getdoctrdetails()
        {
            DataTable dt = mdl.getdoctrdetails();
            return dt;
        }
        public DataTable Lab_Medi_TemplateMain()
        {
            DataTable dt = mdl.Lab_Medi_TemplateMain();
            return dt;
        }
        public DataTable getLabdata()
        {
            DataTable dt = mdl.getLabdata();
            return dt;
        }
        public DataTable testrslt(string id)
        {
            DataTable dt = mdl.testrslt(id);
            return dt;
        }
        public string selectid(string mtest)
        {
            string dt = mdl.selectid(mtest);
            return dt;
        }
        public int inslabmain(string patid, string dr_id, string mtest, string wrkid, string dte, string duedate, string rcvdate)
        {
            int j = mdl.inslabmain(patid, dr_id, mtest, wrkid, dte, duedate, rcvdate);
            return j;
        }
        public int inslabmain2(string patid, string dr_id, string work_name, string work_id,string date)
        {
            int e = mdl.inslabmain2(patid, dr_id, work_name, work_id,date);
            return e;
        }
        public int insdentlab(string resultmain,string work_name,string work_type,string aloytype,string shade,string pt_id,string toothnumber)
        {
            int e = mdl.insdentlab(resultmain, work_name, work_type, aloytype, shade, pt_id, toothnumber);
            return e;
        }
        public string maxid()
        {
            string dt = mdl.maxid();
            return dt;
        }
        public int labresult(string rsltmid, string id, string maintstid, string testid, string patid, string units, string normvalue)
        {
            int k = mdl.labresult(rsltmid, id, maintstid, testid, patid, units, normvalue);
            return k;
        }
        public DataTable dentallab()
        {
            DataTable dt = mdl.dentallab();
            return dt;
        }
        public DataTable grid3data(string patid)
        {
            DataTable dt = mdl.grid3data(patid);
            return dt;
        }
        public DataTable getwrkname(string wrkname)
        {
            DataTable dt = mdl.getwrkname(wrkname);
            return dt;
        }
        public string getprev(string doctrid)
        {
            string e = lm.getprev(doctrid);
            return e;
        }
        public DataTable Patient_search(string txtbox)
        {
            DataTable dt = cm.Patient_search(txtbox);
            return dt;
        }
        public string doctr_privillage_for_addnewPatient(string doctrid)
        {
            string t = cm.doctr_privillage_for_addnewPatient(doctrid);
            return t;
        }
    }
}
