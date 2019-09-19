using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public class MainCalendar_Controller
    {
        MainCalendar_Model model = new MainCalendar_Model();
        Common_model cmodel = new Common_model();
        public string appoinmt_permission(string doctor_id)
        {
            string id = model.appoinmt_permission(doctor_id);
            return id;
        }
        public DataTable admin_appointments(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = model.admin_appointments(startDateTime, startDateTime1);
            return dtb;
        }
        public DataTable doctor_appointments(DateTime startDateTime, DateTime startDateTime1, string doctor_id)
        {
            DataTable dtb = model.doctor_appointments(startDateTime, startDateTime1, doctor_id);
            return dtb;
        }
        public DataTable all_dctr_appointment()
        {
            DataTable dtb = model.all_dctr_appointment();
            return dtb;
        }
        public DataTable get_dctr_wise_appointment(string doctor_id)
        {
            DataTable dtb = model.get_dctr_wise_appointment(doctor_id);
            return dtb;
        }
        public string get_calendar_color(string dr_id)
        {
            string id = model.get_calendar_color(dr_id);
            return id;
        }
        public DataTable get_doctr(string doctor_id)
        {
            DataTable dtb = model.get_doctr(doctor_id);
            return dtb;
        }
        public DataTable load_all_doctor()
        {
            DataTable dtb = model.load_all_doctor();
            return dtb;
        }
        public string Get_DoctorName(string doctor_id)
        {
            string id = cmodel.Get_DoctorName(doctor_id);
            return id;
        }
        public string Load_CompanyName()
        {
            string id = cmodel.Load_CompanyName();
            return id;
        }
        public string contactnumber()
        {
            string num = model.contactnumber();
            return num;
        }
        public string get_slot()
        {
            string num = model.get_slot();
            return num;
        }
        public string permission_for_add(string doctor_id)
        {
            string num = model.permission_for_add(doctor_id);
            return num;
        }
        public string permission_for_edit(string doctor_id)
        {
            string num = model.permission_for_edit(doctor_id);
            return num;
        }
        public string permission_for_delete(string doctor_id)
        {
            string num = model.permission_for_delete(doctor_id);
            return num;
        }
        public void delete_appointment(string ContextEvent)
        {
            model.delete_appointment(ContextEvent);
        }
        public void update_appointment_status(string ContextEvent)
        {
            model.update_appointment_status(ContextEvent);
        }
        public DataTable get_sms_details()
        {
            DataTable dtb = model.get_sms_details();
            return dtb;
        }
        public DataTable get_patient_details(string ContextEvent)
        {
            DataTable dtb = model.get_patient_details(ContextEvent);
            return dtb;
        }
        public DataTable Get_Patient_Details(string id)
        {
            DataTable dtb = cmodel.Get_Patient_Details(id);
            return dtb;
        }
        public void insert_sms(string pt_id,  string pt_name, string procedure, string doctor)
        {
            model.insert_sms( pt_id, pt_name,  procedure, doctor);
        }
        public DataTable get_appointment_details(string HitTest)
        {
            DataTable dtb = model.get_appointment_details(HitTest);
            return dtb;
        }
        public DataTable patient_details(string doctor_id)
        {
            DataTable dtb = model.patient_details(doctor_id);
            return dtb;
        }
        public void update_appointment_statrdatetime(string start_datetime, string totalTime, string id)
        {
            model.update_appointment_statrdatetime( start_datetime,  totalTime,  id);
        }
        public void update_appointment_status_checkin(string Timeonly, string id)
        {
            model.update_appointment_status_checkin(Timeonly,id);
        }
        public void update_appointment_status_engaged(string Timeonly, string id)
        {
            model.update_appointment_status_engaged(Timeonly, id);
        }
        public void update_appointment_status_checkout(string Timeonly, string id)
        {
            model.update_appointment_status_checkout(Timeonly, id);
        }
        public string inventory_privillage(string doctor_id)
        {
            string id = model.inventory_privillage(doctor_id);
            return id;
        }
        public DataTable Patient_search(string _Patientid)
        {
            DataTable dtb = cmodel.Patient_search(_Patientid);
            return dtb;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string id = cmodel.doctr_privillage_for_addnewPatient(doctor_id);
            return id;
        }
        public string permission_for_settings(string doctor_id)
        {
            string dtb = cmodel.permission_for_settings(doctor_id);
            return dtb;
        }
    }
}
 