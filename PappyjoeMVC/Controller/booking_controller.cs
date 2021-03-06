﻿using PappyjoeMVC.Model;
using System;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Booking_controller
    {
        Booking_model _model = new Booking_model();
        Connection db = new Connection();
        Common_model cmodel = new Common_model();
        Add_Appointment_model addmodel = new Add_Appointment_model();
        Add_New_Patient_model pmodel = new Add_New_Patient_model();
        public string Add_privillege(string doctor_id)
        {
            string ss = _model.Add_privillege(doctor_id);
            return ss;
        }
        public DataTable doctor_name(string doctor_id)
        {
            DataTable dt = _model.doctor_name(doctor_id);
            return dt;
        }
        public DataTable get_all_doctorname()
        {
            DataTable dtb = cmodel.get_all_doctorname();
            return dtb;
        }
        public DataTable get_All_proceure()
        {
            DataTable dtb = addmodel.get_All_procedure();
            return dtb;
        }
        public string getdocid(string d)
        {
            string dtb = addmodel.getdoctrname(d);
            return dtb;
        }
        public DataTable search_patient(string search)
        {
            DataTable dt = _model.search_patient(search);
            return dt;
        }
        public DataTable Getpat_MobNamme(string patient_id)
        {
            DataTable dt_p = _model.Getpat_MobNamme(patient_id);
            return dt_p;
        }
        public DataTable search_ptid(string search)
        {
            DataTable dt = _model.search_ptid(search);
            return dt;
        }
        public DataTable patient_details(string txt_p_name)
        {
            DataTable dtb = _model.patient_details(txt_p_name);
            return dtb;
        }
        public DataTable get_patientPrefix()
        {
            DataTable patidGeneration = _model.get_patientPrefix();
            return patidGeneration;
        }
        public void Save_patient(string PatientName, string Patient_Id, string aadhar_id, string gender, string date_of_birth, string age, string blood_group, string family,  string primary_mobile_number, string secondary_mobile_number, string landline_number, string email_address, string street_address, string locality, string city, string pincode,  string refferedby, string Opticket, string Visited, string doctorname, string Occupation,string nationality,string passportno)
        {
            pmodel. Save( PatientName,  Patient_Id,  aadhar_id,  gender,  date_of_birth,  age,  blood_group,  family,    primary_mobile_number,  secondary_mobile_number,  landline_number,  email_address,  street_address,  locality,  city,  pincode,    refferedby,  Opticket,  Visited,  doctorname,  Occupation,nationality,passportno);
        }
        public DataTable get_max_patid()
        {
            DataTable rs_patient = _model.get_max_patid();
            return rs_patient;
        }
        public DataTable automaticid()
        {
            DataTable dtb = pmodel.automaticid();
            return dtb;
        }
        public void update_autogenerateid(int n)
        {
            pmodel.update_autogenerateid(n);
        }
        public DataTable Get_calenderColor(string dr_id)
        {
            DataTable dt_d = _model.Get_calenderColor(dr_id);
            return dt_d;
        }
        public DataTable get_doctor_login(string id)
        {
            DataTable doctor = _model.get_doctor_login(id);
            return doctor;
        }
        public DataTable patient_details_byname(string txt_p_name)
        {
            DataTable dtb = _model.patient_details(txt_p_name);
            return dtb;
        }
        public int insappointment(string book_datetime, string start_datetime, string duration, string note, string pt_id, string pt_name, string dr_id, string mobile_no, string email_id, string plan_new_procedure, string booked_by)
        {
            int i = addmodel.insappointment(book_datetime.ToString(), start_datetime.ToString(), duration, note, pt_id, pt_name, dr_id, mobile_no, email_id, plan_new_procedure, booked_by);
            return i;
        }
        public int save_log(string log_usrid, string log_type, string log_descriptn, string log_stage)
        {
            int j = addmodel.save_log(log_usrid, log_type, log_descriptn, log_stage);
            return j;
        }
        public DataTable appointmentId()
        {
            DataTable dt_a = _model.appointmentId();
            return dt_a;
        }
        public DataTable clinicdetails()
        {
            DataTable dtb = cmodel.clinicdetails();
            return dtb;
        }
        public DataTable smsdetails()
        {
            DataTable dtb = cmodel.smsdetails();
            return dtb;
        }
        public DataTable Get_Patient_Details(string id)
        {
            DataTable dtb = cmodel.Get_Patient_Details(id);
            return dtb;
        }
        public DataTable Get_reminderSmS()
        {
            DataTable smsreminder = _model.Get_reminderSmS();
            return smsreminder;
        }
        public void save_Pt_SMS(string patient_id, string ptnaame, string procedure, string StartT, string cmbStartTime, string combodoctor)
        {
            _model.save_Pt_SMS( patient_id,  ptnaame,  procedure,  StartT,  cmbStartTime,  combodoctor);
        }
        public DataTable getpatemail(string patient_id)
        {
            DataTable dtb = cmodel.getpatemail(patient_id);
            return dtb;
        }
        public DataTable send_email()
        {
            DataTable dtb = cmodel.send_email();
            return dtb;
        }
        public void update_appointment(DateTime StartT, string diff1, string note,string procedure, string patient_id, string patient_name, string dr_id, string mobile_no, string email, string gpl_app_id)
        {
            _model.update_appointment( StartT,  diff1,  note, procedure, patient_id,  patient_name,  dr_id,  mobile_no,  email,  gpl_app_id);
        }
        public DataTable get_appointment_procedure(string id)
        {
            DataTable dtb = _model.get_appointment_procedure(id);
            return dtb;
        }
        public DataTable sms_lang()
        {
            DataTable dt = cmodel.sms_language();
            return dt;
        }
        public DataTable smstemplate(string language, string patientname, string procedure, string date, string time, string docname, string clinic, string contactno)
        {
            DataTable dt = _model.smstemplate_Appointmnt(language, patientname, procedure, date, time, docname, clinic, contactno);
            return dt;
        }
    }
}
