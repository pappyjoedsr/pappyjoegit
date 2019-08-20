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
        public Add_Appointment_controller(Add_Appointment_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
        public void clinicdetails()
        {
            DataTable dt = mdl.clinicdetails();
            intr.clinicdetails(dt);
        }
        public void Get_DoctorName(string id)
        {
            string dt = cmdl.Get_DoctorName(id);
            intr.Get_DoctorName(dt);
        }
        public void get_all_doctorname()
        {
            DataTable dt = cmdl.get_all_doctorname();
            intr.get_all_doctorname(dt);
        }
        public void get_All_proceure()
        {
            DataTable dt = mdl.get_All_proceure();
            intr.get_All_proceure(dt);
        }
        public void getdocid(string d)
        {
            DataTable dt = mdl.getdocid(d);
            intr.getdocid(dt);
        }
        public void dt_appointment(string apid)
        {
            DataTable dt = mdl.dt_appointment(apid);
            intr.dt_appointment(dt);
        }
        public void getpatdetails(string patid)
        {
            DataTable dt = mdl.getpatdetails(patid);
            intr.getpatdetails(dt);
        }
        public void getdays(string patid)
        {
            DataTable dt = mdl.getdays(patid);
            intr.getdays(dt);
        }
        public void getapid()
        {
            string k = mdl.getapid();
            intr.getapid(k);
        }
        public void getappointment()
        {
            mdl.dr_id = intr.dr_id;
            DataTable dt = mdl.getappointment();
            intr.getappointment(dt);
        }
        public void Patient_search(string txtbox)
        {
            DataTable dt = cmdl.Patient_search(txtbox);
            intr.Patient_search(dt);
        }
        public int update(string apid)
        {
            mdl.start_date= intr.start_date;
            mdl.duration= intr.duration;
            mdl.note = intr.note;
            mdl.dr_id= intr.dr_id;
            mdl.plan_new_procedure = intr.plan_new_procedure;
            mdl.booked_by = intr.booked_by;
            int i = mdl.update(apid);
            return i;
        }
        public int insappointment()
        {
            mdl.book_datetime = intr.book_datetime;
            mdl.start_date = intr.start_date;
            mdl.duration = intr.duration;
            mdl.note = intr.note;
            mdl.patient_id = intr.patient_id;
            mdl.pt_name=intr.pt_name;
            mdl.dr_id = intr.dr_id;
            mdl.pt_mobile = intr.pt_mobile;
            mdl.pt_email = intr.pt_email;
            mdl.plan_new_procedure = intr.plan_new_procedure;
            mdl.booked_by = intr.booked_by;
            int j = mdl.insappointment();
            return j;
        }
        public int inssms()
        {
            mdl.patient_id= intr.patient_id;
            mdl.message = intr.message;
            int j = mdl.inssms();
            return j;
        }
        public string permission_for_settings(string doctor_id)
        {
            string dtb = cmdl.permission_for_settings(doctor_id);
            return dtb;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string dtb = cmdl.doctr_privillage_for_addnewPatient(doctor_id);
            return dtb;
        }
    }
}
