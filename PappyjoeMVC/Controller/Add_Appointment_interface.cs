using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public interface Add_Appointment_interface
    {
        string clname { get; set; }
        string locality { get; set; }
        string contactno { get; set; }
        string patient_id { get; set; }
        string docid { get; set; }
        string dr_id { get; set; }
        string message { get; set; }
        string pt_name { get; set; }
        string pt_mobile { get; set; }
        string pt_email { get; set; }
        //string appointment_id { get; set; }
        DateTime book_datetime { get; set; }
        DateTime start_date { get; set; }
        string duration { get; set; }
        string note { get; set; }
        string plan_new_procedure { get; set; }
        string booked_by { get; set; }
        void getapid(string apid);
        void clinicdetails(DataTable dt);
        void Get_DoctorName(string dt);
        void getpatdetails(DataTable dt);
        void get_All_proceure(DataTable dt);
        void dt_appointment(DataTable dt);
        void get_all_doctorname(DataTable dt);
        void getdocid(DataTable dt);
        void getappointment(DataTable dt);
        void getdays(DataTable dt);
        void Patient_search(DataTable dt);
       // void smsreminder(DataTable dt);
        void setController(Add_Appointment_controller controller);
    }
}
