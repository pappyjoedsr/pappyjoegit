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
        SMS_model s = new SMS_model();
        Common_model cmdl = new Common_model();
        LabWorks_model mdl = new LabWorks_model();
        Prescription_model _model = new Prescription_model();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
        Connection db = new Connection();
        public DataTable Get_Patient_Details(string patid)
        {
            DataTable dt = cmdl.Get_Patient_Details(patid);
            return dt;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable dtb = cmdl.Get_practiceDlNumber();
            return dtb;
        }
        public DataTable patient_details(string patient_id)
        {
            System.Data.DataTable dt1 = _model.patient_details(patient_id);
            return dt1;
        }
        public DataTable tbmain(string patid,string workid)
        {
            DataTable dt = mdl.tbmain(patid,workid);
            return dt;
        }
        public DataTable printsettings()
        {
            DataTable print = _model.printsettings();
            return print;
        }
        public DataTable printsettings_details()
        {
            DataTable print = _model.printsettings_details();
            return print;
        }
        public string SendSMS(string User, string password, string Mobile_Number, string Message,string type)
        {
            string val = s.SendSMS(User, password, Mobile_Number, Message,type);
            return val;
        }
        public DataTable Get_Practice_details()
        {
            DataTable dt = cmdl.Get_Practice_details();
            return dt;
        }
        public DataTable tbshade(string patid, string wrkname, string workid)
        {
            DataTable dt = mdl.tbshade(patid,wrkname,workid);
            return dt;
        }
        public string Get_DoctorName(string doctrid)
        {
            string dt = cmdl.Get_DoctorName(doctrid);
            return dt;
        }
        public string server()
        {
            string server = db.server();
            return server;
        }
        public DataTable Getdata(string patid)
        {
            DataTable dt = mdl.Getdata(patid);
            return dt;
        }
        public DataTable practicedetails()
        {
            DataTable dt =dm.practicedetails();
            return dt;
        }
        public DataTable printdetails(string patid,string workname,string wrkiddental)
        {
            DataTable dt = mdl.printdetails(patid,workname,wrkiddental);
            return dt;
        }
        public string seltype(string patid,string id)
        {
            string dt = mdl.seltype(patid,id);
            return dt;
        }
        public string getprev(string doctrid)
        {
            string e = mdl.getprev(doctrid);
            return e;
        }
        public DataTable smsinfo()
        {
            DataTable dt = mdl.smsinfo();
            return dt;
        }
        public DataTable Patient_search(string txtbox)
        {
            DataTable dt= cmdl.Patient_search(txtbox);
            return dt;
        }
        public string doctr_privillage_for_addnewPatient(string doctrid)
        {
            string t = cmdl.doctr_privillage_for_addnewPatient(doctrid);
            return t;
        }
    }
}
