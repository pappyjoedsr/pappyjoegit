using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Add_Appointment_controller
    {
        Add_Appointment_interface intr;
        Add_Appointment_model mdl = new Add_Appointment_model();
        common_model cmdl = new common_model();
        sms_model s = new sms_model();
        public Add_Appointment_controller(Add_Appointment_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void smsreminder()
        {
           DataTable dt = mdl.smsreminder();
           intr.smsreminder(dt);
        }
        public void smsdetails()
        {
            DataTable dt = mdl.smsdetails();
            intr.smsdetails(dt);
        }
        public string SendSMS(string User, string password, string Mobile_Number, string Message)
        {
            string val = s.SendSMS(User, password, Mobile_Number, Message);
            return val;
        }
        public string SendSMS2(string User, string password, string Mobile_Number, string Message, string SID, string Sname, string scheduledDate, string systemdate)
        {
            string val = s.SendSMS(User, password, Mobile_Number, Message, SID, Sname, scheduledDate, systemdate);
            return val;
        }
        public void Get_Patient_Details(string patntid)
        {
            DataTable dt = cmdl.Get_Patient_Details(patntid);
            intr.Get_Patient_Details(dt);
        }
        public void send_email()
        {
            DataTable dt = cmdl.send_email();
            intr.send_email(dt);
        }
        public void Get_Practice_details()
        {
            DataTable dt = cmdl.Get_Practice_details();
            intr.Get_Practice_details(dt);
        }
        public void Get_DoctorName(string id)
        {
            string e = cmdl.Get_DoctorName(id);
            intr.Get_DoctorName(e);
        }
        public void get_all_doctorname()
        {
            DataTable dt = cmdl.get_all_doctorname();
            intr.get_all_doctorname(dt);
        }
        public void get_All_procedure()
        {
            DataTable dt = mdl.get_All_procedure();
            intr.get_All_procedure(dt);
        }
        public void getdoctrname(string id)
        {
            DataTable dt = mdl.getdoctrname(id);
            intr.getdoctrname(dt);
        }
        public void dt_appointment(string appointmntid)
        {
            DataTable dt = mdl.dt_appointment(appointmntid);
            intr.dt_appointment(dt);
        }
        public void getpatdetails(string patid)
        {
            DataTable dt = mdl.getpatdetails(patid);
            intr.getpatdetails(dt);
        }
        public void getappointment(string doctrid)
        {
            DataTable dt = mdl.getappointment(doctrid);
            intr.getappointment(dt);
        }
        public void Patient_search(string txtbox)
        {
            DataTable dt = cmdl.Patient_search(txtbox);
            intr.Patient_search(dt);
        }
        public void doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string e = cmdl.doctr_privillage_for_addnewPatient(doctor_id);
            intr.doctr_privillage_for_addnewPatient(e);
        }
        public void settingsprivilage(string doctrid)
        {
            string b = mdl.settingsprivilage(doctrid);
            intr.settingsprivilage(b);
        }
        public int inssms(string pt_id, string send_datetime, string message)
        {
            int j = mdl.inssms(pt_id, send_datetime, message);
            return j;
        }
        public int apntupdate(string strtdatetime, string duratn, string note, string dr_id, string procedure, string bookedby, string appointmentid)
        {
            int i = mdl.apntupdate(strtdatetime,duratn,note,dr_id,procedure, bookedby, appointmentid);
            return i;
        }
        public int insappointment(string book_datetime,string start_datetime,string duration,string note,string pt_id,string pt_name,string dr_id,string mob_no,string email_id,string procedure,string booked_by)
        {
            int j = mdl.insappointment(book_datetime,start_datetime,duration,note,pt_id,pt_name,dr_id,mob_no,email_id,procedure,booked_by);
            return j;
        }
    }
}
