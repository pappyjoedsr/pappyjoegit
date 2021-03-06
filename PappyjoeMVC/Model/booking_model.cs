﻿using System.Data;
using System;
namespace PappyjoeMVC.Model
{
    public class Booking_model
    {
        Connection db = new Connection();

        public DataTable patient_details(string txt_p_name)
        {
            DataTable dtpSearch = db.table("select * from tbl_patient where pt_name like '" + txt_p_name + "' order by pt_name");
            return dtpSearch;
        }
        public DataTable sms_details()
        {
            DataTable sms = db.table("select smsName,smsPass from tbl_SmsEmailConfig");
            return sms;
        }
        public string Add_privillege(string doctor_id)
        {
            string ss = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='APT' and Permission='AP'");
            return ss;
        }
        public DataTable doctor_name(string doctor_id)
        {
            DataTable dt = db.table("select DISTINCT id,doctor_name from tbl_doctor where (login_type='doctor' or login_type='admin')  and activate_login='yes' and id='" + doctor_id + "'");
            return dt;
        }
        public DataTable search_patient(string search)
        {
            DataTable dt = db.table("select CONCAT(pt_name, ', ', substring(gender,1,1), ', ',primary_mobile_number) pt_name,id from tbl_patient where (pt_name like '%" + search + "%'  or pt_id like '%" + search + "%' or primary_mobile_number like '%" + search + "%' or email_address like '%" + search + "%' or street_address  like '%" + search + "%' or locality like '%" + search + "%' or city like '%" + search + "%') and Profile_Status='Active'  order by pt_name");
            return dt;
        }
        public DataTable Getpat_MobNamme(string patient_id)
        {
            DataTable dt_p = db.table("select pt_name,pt_id,gender,primary_mobile_number,email_address from tbl_patient where  id=" + patient_id + " ORDER BY id");
            return dt_p;// intr.Fill_search_patient(dt_p);
        }
        public DataTable search_ptid(string search)
        {
            DataTable dt = db.table("select CONCAT (pt_name,' ', primary_mobile_number)  pt_name,id from tbl_patient where (pt_name like '%" + search + "%'  or pt_id like '%" + search + "%' or primary_mobile_number like '%" + search + "%' or email_address like '%" + search + "%')and Profile_Status='Active' order by pt_name");
            return dt;
        }
        public DataTable get_patientPrefix()
        {
            DataTable patidGeneration = db.table("select patient_prefix,patient_number from tbl_patient_automaticid where patient_automation='Yes'");
            return patidGeneration;
        }
        public DataTable get_max_patid()
        {
            DataTable rs_patient = db.table("SELECT MAX(id) FROM tbl_patient");
            return rs_patient;
        }
        public DataTable Get_calenderColor(string dr_id)
        {
            DataTable dt_d = db.table("select calendar_color,mobile_number,email_id from tbl_doctor where  id=" + dr_id + "  ");
            return dt_d;
        }
        public DataTable get_doctor_login(string id)
        {
            DataTable doctor = db.table("select doctor_name,mobile_number,login_type from tbl_doctor where id='" + id + "'");
            return doctor;
        }
        public DataTable appointmentId()
        {
            DataTable dt_a = db.table("select id from tbl_appointment ORDER BY id");
            return dt_a;
        }
        public DataTable Get_reminderSmS()
        {
            DataTable smsreminder = db.table("select * from tbl_appt_reminder_sms");
            return smsreminder;
        }
        public void save_Pt_SMS(string patient_id, string ptnaame, string procedure, string StartT, string cmbStartTime, string combodoctor)
        {
            db.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + patient_id + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm") + "','patient','sent','Dear " + ptnaame + " " + "Your appointment for " + procedure + " has been confirmed at " + StartT + " " + cmbStartTime + " with " + "Dr " + combodoctor + " Regards ')");
        }
        public void update_appointment(DateTime StartT, string diff1, string note,string procedure, string patient_id, string patient_name, string dr_id, string mobile_no, string email, string gpl_app_id)
        {
            int j = db.execute("update tbl_appointment set start_datetime='" + Convert.ToDateTime(StartT).ToString("yyyy-MM-dd HH:mm") + "',duration='" + diff1 + "',note='" + note + "',plan_new_procedure='"+procedure+"',pt_id='" + patient_id + "',pt_name='" + patient_name + "',dr_id='" + dr_id + "',mobile_no='" + mobile_no + "',email_id='" + email + "' where id='" + gpl_app_id + "'");
        }
        public DataTable get_appointment_procedure(string id)
        {
            DataTable dt_a = db.table("select pt_id,dr_id,note,plan_new_procedure from tbl_appointment where  id=" + id + " ORDER BY id");
            return dt_a;
        }
        public DataTable smstemplate_Appointmnt(string language,string patientname,string procedure,string date,string time,string docname,string clinic,string contactno)
        {
            DataTable dt = db.table("SELECT REPLACE( REPLACE( REPLACE( REPLACE( REPLACE( REPLACE( REPLACE( Template, 'contactno', '"+ contactno + ". ' ), 'clinic', '"+ clinic + ", ' ), 'doctorname', '"+ docname + ". ' ), 'time', '"+ time + "' ), 'date', '"+ date + "'), 'procedure', '"+ procedure + " ' ), 'patientname', '"+ patientname + ", ' )  as Template    FROM tbl_sms_language where Language = '"+ language + "' and Type = 'Appointment'");
            return dt;
        }
    }
}
