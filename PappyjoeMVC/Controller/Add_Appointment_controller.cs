using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Add_Appointment_controller
    {
        SMS_model s = new SMS_model();
        Common_model cmdl = new Common_model();
        Add_Appointment_model mdl = new Add_Appointment_model();
        public DataTable smsreminder()
        {
            DataTable dt = mdl.smsreminder();
            return dt;
        }
        public string privilge_for_inventory(string doctor_id)
        {
            string s = cmdl.privilge_for_inventory(doctor_id);
            return s;
        }
        public DataTable smsdetails()
        {
            DataTable dt = cmdl.smsdetails();
            return dt;
        }
        public string SendSMS(string User, string password, string Mobile_Number, string Message)
        {
            string val = s.SendSMS(User, password, Mobile_Number, Message);
            return val;
        }
        public string SendSMS(string User, string password, string Mobile_Number, string Message, string SID, string Sname, string scheduledDate, string systemdate)
        {
            string val = s.SendSMS(User, password, Mobile_Number, Message, SID, Sname, scheduledDate, systemdate);
            return val;
        }
        public DataTable Get_Patient_Details(string patntid)
        {
            DataTable dt = cmdl.Get_Patient_Details(patntid);
            return dt;
        }
        public DataTable send_email()
        {
            DataTable dt = cmdl.send_email();
            return dt;
        }
        public DataTable Get_Practice_details()
        {
            DataTable dt = cmdl.Get_Practice_details();
            return dt; ;
        }
        public string Get_DoctorName(string id)
        {
            string e = cmdl.Get_DoctorName(id);
            return e;
        }
        public DataTable get_all_doctorname()
        {
            DataTable dt = cmdl.get_all_doctorname();
            return dt;
        }
        public DataTable get_All_procedure()
        {
            DataTable dt = mdl.get_All_procedure();
            return dt;
        }
        public string getdoctrname(string id)
        {
            string t = mdl.getdoctrname(id);
            return t;
        }
        public DataTable dt_appointment(string appointmntid)
        {
            DataTable dt = mdl.dt_appointment(appointmntid);
            return dt;
        }
        public DataTable getpatdetails(string patid)
        {
            DataTable dt = mdl.getpatdetails(patid);
            return dt;
        }
        public DataTable getappointment(string doctrid)
        {
            DataTable dt = mdl.getappointment(doctrid);
            return dt;
        }
        public DataTable Patient_search(string txtbox)
        {
            DataTable dt = cmdl.Patient_search(txtbox);
            return dt;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string e = cmdl.doctr_privillage_for_addnewPatient(doctor_id);
            return e; ;
        }
        public string settingsprivilage(string doctrid)
        {
            string b = mdl.settingsprivilage(doctrid);
            return b;
        }
        public int inssms(string pt_id, string send_datetime, string message)
        {
            int j = mdl.inssms(pt_id, send_datetime, message);
            return j;
        }
        public int apntupdate(string strtdatetime, string duratn, string note, string dr_id, string procedure, string bookedby, string appointmentid)
        {
            int i = mdl.apntupdate(strtdatetime, duratn, note, dr_id, procedure, bookedby, appointmentid);
            return i;
        }
        public int insappointment(string book_datetime, string start_datetime, string duration, string note, string pt_id, string pt_name, string dr_id, string mob_no, string email_id, string procedure, string booked_by)
        {
            int j = mdl.insappointment(book_datetime, start_datetime, duration, note, pt_id, pt_name, dr_id, mob_no, email_id, procedure, booked_by);
            return j;
        }
    }
}
