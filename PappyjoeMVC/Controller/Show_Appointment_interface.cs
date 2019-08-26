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
        void show(DataTable dt);
        void privilege_A(string doctor_id);
        void privilege_D(string doctor_id);
        void privilege_E(string doctor_id);
        void Get_CompanyNAme(DataTable dt);
        void Get_DoctorName(string dt);
        void Get_Patient_Details(DataTable dt);
        void Patient_search(DataTable dt);
        void settingsprivilage(string doctrid);
        void doctr_privillage_for_addnewPatient(string doctor_id);
        void setController(Show_Appointment_controller controller);
    }
}
