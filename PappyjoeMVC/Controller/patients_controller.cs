using PappyjoeMVC.Model;
using System;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Patients_controller
    {
        //patients_interface intr;
        Patients_model _model = new Patients_model();
        Common_model cmodel = new Common_model();
        //public Patients_controller(patients_interface inttr)
        //{
        //    intr = inttr;
        //    intr.Setcontroller(this);
        //}

        public DataTable Get_all_Patients()
        {
            DataTable dtb = _model.Get_all_Patients();
            return dtb;// intr.Create_Datagrid(dtb);
        }
        public DataTable group()
        {
            DataTable dtb = _model.group();
            return dtb;// intr.Load_Group(dtb);
        }
        public DataTable Get_appointment_data(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = _model.Get_appointment_data(startDateTime, startDateTime1);
            return dtb;// intr.Appointment_Data(dtb);
        }
        public DataTable Get_vitalSigns(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = _model.Get_vitalSigns(startDateTime, startDateTime1);
            return dtb;// intr.VitalSigns(dtb);
        }
        public DataTable Patient_details(string ptid)
        {
            DataTable rs_patients = _model.Patient_details(ptid);
            return rs_patients;
        }
        public DataTable clinic_findings(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = _model.clinic_findings(startDateTime, startDateTime1);
            return dtb;// intr.ClinicFindings(dtb);
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
        public DataTable treatmentPlan(DateTime start, DateTime startDateTime1)
        {
            DataTable dtb = _model.treatmentPlan(start, startDateTime1);
            return dtb;// intr.TreatmentPlan(dtb);
        }
        public DataTable treatements_items(string id)
        {
            DataTable dtb = _model.treatements_items(id);
            return dtb;
        }
        public DataTable finishedprocedure(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = _model.finishedprocedure(startDateTime, startDateTime1);
            return dtb;// intr.FinishedProcedure(dtb);
        }
        public DataTable finished_sub(string id)
        {
            DataTable dtb = _model.finished_sub(id);
            return dtb;
        }
        public DataTable Prescription(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = _model.Prescription(startDateTime, startDateTime1);
            return dtb;// intr.Prescription(dtb);
        }
        public DataTable prescription_details(string id)
        {
            DataTable dtb = _model.prescription_details(id);
            return dtb;
        }
        public DataTable invoice(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = _model.invoice(startDateTime, startDateTime1);
            return dtb;// intr.Invoice(dtb);
        }
        public DataTable invoice_sub(string id)
        {
            DataTable dtb = _model.invoice_sub(id);
            return dtb;
        }
        public DataTable Payment(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dtb = _model.Payment(startDateTime, startDateTime1);
            return dtb;// intr.Payments(dtb);
        }
        public DataTable payment_sub(string date)
        {
            DataTable dtb = _model.payment_sub(date);
            return dtb;
        }
        public DataTable recently_visited(DateTime d, DateTime todate)
        {
            DataTable dtb = _model.recently_visited(d, todate);
            return dtb;// intr.Create_Datagrid(dtb);
        }
        public DataTable Recently_added(DateTime d, DateTime todate)
        {
            DataTable dtb = _model.Recently_added(d, todate);
            return dtb;// intr.Create_Datagrid(dtb);
        }
        public DataTable upcomming_appointments(DateTime startDateTime)
        {
            DataTable dtb = _model.upcomming_appointments(startDateTime);
            return dtb;// intr.Create_Datagrid(dtb);
        }
        public DataTable birthday()
        {
            DataTable dtb = _model.birthday();
            return dtb;// intr.Create_Datagrid(dtb);
        }
        public DataTable cancelled_appointment()
        {
            DataTable dtb = _model.cancelled_appointment();
            return dtb;// intr.Create_Datagrid(dtb);
        }
        public DataTable innactive_patients()
        {
            DataTable dtb = _model.innactive_patients();
            return dtb;//  intr.Create_Datagrid(dtb);
        }
        public DataTable patients_wit_group(string id4)
        {
            DataTable dtb = _model.innactive_patients();
            return dtb;//  intr.Create_Datagrid(dtb);
        }
        public DataTable allpatient_search(string name)
        {
            DataTable dtb = _model.allpatient_search(name);
            return dtb;// intr.Create_Datagrid(dtb);
        }
        public DataTable recently_visited_search(DateTime d, DateTime todate, string name)
        {
            DataTable dtb = _model.recently_visited_search(d, todate, name);
            return dtb;// intr.Create_Datagrid(dtb);
        }
        public DataTable  recently_added_search(DateTime d, DateTime todate, string name)
        {
            DataTable dtb = _model.recently_added_search(d, todate, name);
            return dtb;// intr.Create_Datagrid(dtb);
        }
        public DataTable  upcomming_appointments_search(DateTime startDateTime, string name)
        {
            DataTable dtb = _model.upcomming_appointments_search(startDateTime, name);
            return dtb;// intr.Create_Datagrid(dtb);
        }
        public DataTable birthday_search(string name)
        {
            DataTable dtb = _model.birthday_search(name);
            return dtb;// intr.Create_Datagrid(dtb);
        }
        public DataTable  cancelled_appointmnt_search(string name)
        {
            DataTable dtb = _model.cancelled_appointmnt_search(name);
            return dtb;// intr.Create_Datagrid(dtb);
        }
        public DataTable innactive_patients_search(string name)
        {
            DataTable dtb = _model.innactive_patients_search(name);
            return dtb;//  intr.Create_Datagrid(dtb);
        }
        public DataTable patients_wit_group_search(string id4, string name)
        {
            DataTable dtb = _model.patients_wit_group_search(id4, name);
            return dtb;// intr.Create_Datagrid(dtb);
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
        public string inventry_prevlage(string doctor_id)
        {
            string id = _model.inventry_prevlage(doctor_id);
            return id;
        }
    }
}
