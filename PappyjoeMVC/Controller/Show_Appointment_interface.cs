using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public interface Show_Appointment_interface
    {
        string patient_id { get; set; }
        string apid { get; set; }
        void privilege_A(string doctor_id);
        void privilege_D(string doctor_id);
        void privilege_E(string doctor_id);
        void Get_CompanyNAme(DataTable dt);
        void Get_DoctorName(DataTable dt);
        void show(DataTable dt);
        void getdays(DataTable dt);
        void Patient_search(DataTable dt);
        void setController(Show_Appointment_controller controller);
    }
}
