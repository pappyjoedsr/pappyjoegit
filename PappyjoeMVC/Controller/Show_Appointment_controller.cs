using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Show_Appointment_controller
    {
        Show_Appointment_interface intr;
        Show_Appointment_model mdl = new Show_Appointment_model();
        common_model cmdl = new common_model();
        Add_Appointment_model am = new Add_Appointment_model();
        public Show_Appointment_controller(Show_Appointment_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void privilege_A(string doctor_id)
        {
            string e= mdl.privilege_A(doctor_id);
            intr.privilege_A(e);
        }
        public void privilege_D(string doctor_id)
        {
            string e = mdl.privilege_D(doctor_id);
            intr.privilege_D(e);
        }
        public void privilege_E(string doctor_id)
        {
            string e = mdl.privilege_E(doctor_id);
            intr.privilege_E(e);
        }
        public void Get_CompanyNAme()
        {
            DataTable dt = cmdl.Get_CompanyNAme();
            intr.Get_CompanyNAme(dt);
        }
        public void Get_DoctorName(string id)
        {
            string dt = cmdl.Get_DoctorName(id);
            intr.Get_DoctorName(dt);
        }
        public void show(string patid)
        {
            DataTable dt = mdl.show(patid);
            intr.show(dt);
        }
        public void getdays(string patid)
        {
            DataTable dt = am.getdays(patid);
            intr.getdays(dt);
        }
        public void Patient_search(string txtbox)
        {
            DataTable dt = cmdl.Patient_search(txtbox);
            intr.Patient_search(dt);
        }
        public int delete()
        {
            mdl.apid = intr.apid;
            int j = mdl.delete();
            return j;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string dtb = cmdl.doctr_privillage_for_addnewPatient(doctor_id);
            return dtb;
        }
        public string permission_for_settings(string doctor_id)
        {
            string dtb = cmdl.permission_for_settings(doctor_id);
            return dtb;
        }
    }
}
