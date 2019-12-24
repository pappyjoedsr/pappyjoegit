using PappyjoeMVC.Model;
using System;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Prescription_Show_controller
    {
       
        Prescription_model _model = new Prescription_model();
        Connection db = new Connection();
        Common_model cmodel = new Common_model();
        Booking_model bmodel = new Booking_model();

        public string privilge_for_inventory(string doctor_id)
        {
            string s = cmodel.privilge_for_inventory(doctor_id);
            return s;
        }
        public string add_privillege(string doctor_id)
        {
            string privid = _model.add_privillege(doctor_id);
            return privid;
        }
        public string edit_privillege(string doctor_id)
        {
            string privid = _model.edit_privillege(doctor_id);
            return privid;
        }
        public string delete_privillege(string doctor_id)
        {
            string privid = _model.delete_privillege(doctor_id);
            return privid;
        }
        public DataTable Get_CompanyNAme()
        {
            DataTable dtb = cmodel.Get_CompanyNAme();
            return dtb;
        }
        public string server()
        {
            string server = db.server();
            return server;
        }
        public string Get_DoctorName(string doctor_id)
        {
            string dtb = cmodel.Get_DoctorName(doctor_id);
            return dtb;
        }
      
        public DataTable Get_pat_iDName(string patient_id)
        {
            DataTable dtb = cmodel.Get_pat_iDName(patient_id);
            return dtb;
        }
        public DataTable Get_maindtails(string patient_id)
        {
            System.Data.DataTable dt_pre_main = _model.Get_maindtails(patient_id);
            return dt_pre_main;
        }
        public DataTable Get_maindta(string patient_id)
        {
            System.Data.DataTable dt_pre_main = _model.Get_maindta(patient_id);
            return dt_pre_main;
        }

        public DataTable prescription_details(string id)
        {
            System.Data.DataTable dt_prescription = _model.prescription_details(id);
            return dt_prescription;
        }
        public DataTable printsettings()
        {
            DataTable print = _model.printsettings();
            return print;
        }
        public DataTable clinicpath()
        {
            DataTable dtp = _model.clinicpath();
            return dtp;
        }
        public DataTable patient_details(string patient_id)
        {
            System.Data.DataTable dt1 = _model.patient_details(patient_id);
            return dt1;
        }

        public DataTable patient_prescptn(string prescription_id, string patient_id)
        {
            System.Data.DataTable dt_cf = _model.patient_prescptn(prescription_id, patient_id);
            return dt_cf;
        }
        public void delete_prescription(string prescription_id)
        {
            _model.delete_allprescription(prescription_id); 
        }
        public DataTable get_presctnMain(string prescription_id)
        {
            System.Data.DataTable td_prescription_main = _model.get_presctnMain(prescription_id);
            return td_prescription_main;
        }
        public void save_prescriptionmain(string pt_id, string dr_id, string notes)
        {
            _model.save_prescriptionmain(pt_id, dr_id, notes); 
        }
        public string Maxid()
        {
            string dtb = _model.Maxid();
            return dtb;
        }
        public DataTable get_allprescription(string prescription_id)
        {
            DataTable td_prescription_Sub = _model.get_allprescription(prescription_id);
            return td_prescription_Sub;
        }
        public void save_prescription(int pres_id, string pt_id, string dr_name, string dr_id, string date, string drug_name, string strength, string strength_gr, string duration_unit, string duration_period, string morning, string noon, string night, string food, string add_instruction, string drug_type, string status, string drug_id)
        {
            _model.save_prescription(pres_id, pt_id, dr_name, dr_id, date, drug_name, strength, strength_gr, duration_unit, duration_period, morning, noon, night, food, add_instruction, drug_type, status, drug_id);
        }
        public DataTable get_emailpatientdetails(string patient_id)
        {
            DataTable dtb = cmodel.get_emailpatientdetails(patient_id);
            return dtb;
        }
        public DataTable Get_companynameNo()
        {
            DataTable dtp = _model.Get_companynameNo();
            return dtp;
        }
        public DataTable printsettings_details()
        {
            DataTable print = _model.printsettings_details();
            return print;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable dtb = cmodel.Get_practiceDlNumber();
            return dtb;
        }
        public DataTable table_details(string prescription_id, string patient_id)
        {
            DataTable dt_cf = _model.table_details(prescription_id, patient_id); 
            return dt_cf;
        }
        public DataTable sms_details()
        {
            DataTable sms = bmodel.sms_details();
            return sms;
        }
        public DataTable get_patientnumber(string patient_id)
        {
            DataTable pat = _model.get_patientnumber(patient_id);
            return pat;
        }
        public DataTable remindersms()
        {
            DataTable smsreminder = _model.remindersms();
            return smsreminder;
        }
        public void savecommunication(string patient_id, string text)
        {
            _model.savecommunication(patient_id, text);
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
