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
        string SendSMS(string value);
        string SendSMS2(string value);
        void send_email(DataTable dt);
        void dt_appointment(DataTable dt);
        void getdoctrname(DataTable dt);
        void getpatdetails(DataTable dt);
        void Get_DoctorName(string doctrid);
        void getappointment(DataTable dt);
        void Patient_search(DataTable dt);
        void smsreminder(DataTable dt);
        void smsdetails(DataTable dt);
        void get_all_doctorname(DataTable dt);
        void settingsprivilage(string doctrid);
        void get_All_procedure(DataTable dt);
        void Get_Practice_details(DataTable dt);
        void Get_Patient_Details(DataTable dt);
        void doctr_privillage_for_addnewPatient(string doctor_id);
        void setController(Add_Appointment_controller controller);
    }
}
