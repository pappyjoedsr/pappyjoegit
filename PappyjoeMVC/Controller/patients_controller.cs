using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public class patients_controller
    {
        patients_interface intr;
        patients_model _model = new patients_model();
        common_model cmodel = new common_model();
        public patients_controller(patients_interface inttr)
        {
            intr = inttr;
            intr.Setcontroller(this);
        }

        public void Get_all_Patients()
        {
            DataTable dtb = _model.Get_all_Patients();
            intr.Create_Datagrid(dtb);
        }
        public void group()
        {
            DataTable dtb = _model.group();
            intr.Load_Group(dtb);
        }
        public void Get_appointment_data(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = _model.Get_appointment_data(startDateTime, startDateTime1);
            intr.Appointment_Data(dtb);
        }
        public void Get_vitalSigns(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = _model.Get_vitalSigns(startDateTime, startDateTime1);
            intr.VitalSigns(dtb);
        }
        public DataTable Patient_details(string ptid)
        {
            DataTable rs_patients = _model.Patient_details(ptid);
            return rs_patients;
        }
        public void clinic_findings(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = _model.clinic_findings(startDateTime, startDateTime1);
            intr.ClinicFindings(dtb);
        }
         public DataTable complaints(string pt_id)
        {
            DataTable dtb = _model.complaints(pt_id);
            return dtb;
        }
        public DataTable observation(string pt_id)
        {
            DataTable dtb = _model.observation(pt_id);
            return dtb;
        }
        public DataTable investgation(string pt_id)
        {
            DataTable dtb = _model.investgation(pt_id);
            return dtb;
        }
        public DataTable diagnosis(string pt_id)
        {
            DataTable dtb = _model.diagnosis(pt_id);
            return dtb;
        }
        public DataTable notes(string pt_id)
        {
            DataTable dtb = _model.notes(pt_id);
            return dtb;
        }
        public void treatmentPlan(DateTime start,DateTime startDateTime1)
        {
            DataTable dtb = _model.treatmentPlan(start, startDateTime1);
            intr.TreatmentPlan(dtb);
        }
        public DataTable treatements_items(string id)
        {
            DataTable dtb = _model.treatements_items(id);
            return dtb;
        }
      public void finishedprocedure(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = _model.finishedprocedure(startDateTime, startDateTime1);
            intr.FinishedProcedure(dtb);
        }
        public DataTable finished_sub(string id)
        {
            DataTable dtb = _model.finished_sub(id);
            return dtb;
        }
        public void Prescription(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = _model.Prescription(startDateTime, startDateTime1);
            intr.Prescription(dtb);
        }
        public DataTable prescription_details(string id)
        {
            DataTable dtb = _model.prescription_details(id);
            return dtb;
        }
        public void invoice(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = _model.invoice(startDateTime, startDateTime1);
            intr.Invoice(dtb);
        }
        public DataTable invoice_sub(string id)
        {
            DataTable dtb = _model.invoice_sub(id);
            return dtb;
        }
        public void Payment(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = _model.Payment(startDateTime, startDateTime1);
            intr.Payments(dtb);
        }
        public DataTable payment_sub(string date)
        {
            DataTable dtb = _model.payment_sub(date);
            return dtb;
        }
        public void recently_visited(DateTime d, DateTime todate)
        {
            DataTable dtb = _model.recently_visited(d, todate);
            intr.Create_Datagrid(dtb);
        }
        public void  Recently_added(DateTime d, DateTime todate)
        {
            DataTable dtb = _model.Recently_added(d, todate);
            intr.Create_Datagrid(dtb);
        }
        public void upcomming_appointments(DateTime startDateTime)
        {
            DataTable dtb = _model.upcomming_appointments(startDateTime);
            intr.Create_Datagrid(dtb);
        }
        public void birthday()
        {
            DataTable dtb = _model.birthday();
            intr.Create_Datagrid(dtb);
        }
        public void cancelled_appointment()
        {
            DataTable dtb = _model.cancelled_appointment();
            intr.Create_Datagrid(dtb);
        }
        public void innactive_patients()
        {
            DataTable dtb = _model.innactive_patients();
            intr.Create_Datagrid(dtb);
        }
        public void patients_wit_group(string id4)
        {
            DataTable dtb = _model.innactive_patients();
            intr.Create_Datagrid(dtb);
        }
        public void allpatient_search(string name)
        {
            DataTable dtb = _model.allpatient_search(name);
            intr.Create_Datagrid(dtb);
        }
        public void recently_visited_search(DateTime d, DateTime todate, string name)
        {
            DataTable dtb = _model.recently_visited_search(d,todate,name);
            intr.Create_Datagrid(dtb);
        }
        public void recently_added_search(DateTime d, DateTime todate, string name)
        {
            DataTable dtb = _model.recently_added_search(d, todate, name);
            intr.Create_Datagrid(dtb);
        }
        public void upcomming_appointments_search(DateTime startDateTime, string name)
        {
            DataTable dtb = _model.upcomming_appointments_search(startDateTime, name);
            intr.Create_Datagrid(dtb);
        }
        public void birthday_search(string name)
        {
            DataTable dtb = _model.birthday_search(name);
            intr.Create_Datagrid(dtb);
        }
        public void cancelled_appointmnt_search(string name)
        {
            DataTable dtb = _model.cancelled_appointmnt_search(name);
            intr.Create_Datagrid(dtb);
        }
        public void innactive_patients_search(string name)
        {
            DataTable dtb = _model.innactive_patients_search(name);
            intr.Create_Datagrid(dtb);
        }
        public void patients_wit_group_search(string id4, string name)
        {
            DataTable dtb = _model.patients_wit_group_search(id4,name);
            intr.Create_Datagrid(dtb);
        }
        public DataTable Patient_search(string patid)
        {
            DataTable dtb = cmodel.Patient_search(patid);
            return dtb;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string dtb = cmodel.doctr_privillage_for_addnewPatient(doctor_id);
            return dtb;
        }
        public string permission_for_settings(string doctor_id)
        {
            string dtb = cmodel.permission_for_settings(doctor_id);
            return dtb;
        }

    }
}
