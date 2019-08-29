using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class booking_controller
    {
        booking_interface intr;
        booking_model _model = new booking_model();
        Connection db = new Connection();
        common_model cmodel = new common_model();
        Add_Appointment_model addmodel = new Add_Appointment_model();
        addnew_patient_model pmodel  = new addnew_patient_model();
        public booking_controller(booking_interface intttr)
        {
            intr = intttr;
            intr.SetController(this);
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
            DataTable dt = db.table("select CONCAT (pt_name,' ', primary_mobile_number)  pt_name,id from tbl_patient where (pt_name like '%" + search + "%'  or pt_id like '%" + search + "%' or primary_mobile_number like '%" + search + "%' or email_address like '%" + search + "%' or street_address  like '%" + search + "%' or locality like '%" + search + "%' or city like '%" + search + "%') and Profile_Status='Active'  order by pt_name");
            return dt;
        }
        public void Getpat_MobNamme(string patient_id)
        {
            DataTable dt_p = db.table("select pt_name,pt_id,primary_mobile_number,email_address from tbl_patient where  id=" + patient_id + " ORDER BY id");
            intr.Fill_search_patient(dt_p);
        }
        public DataTable search_ptid(string search)
        {
            DataTable dt = db.table("select CONCAT (pt_name,' ', primary_mobile_number)  pt_name,id from tbl_patient where (pt_name like '%" + search + "%'  or pt_id like '%" + search + "%' or primary_mobile_number like '%" + search + "%' or email_address like '%" + search + "%')and Profile_Status='Active' order by pt_name");
            return dt;
        }
        public void patient_details(string txt_p_name)
        {
            DataTable dtb = _model.patient_details(txt_p_name);
            intr.Appointment_for_newPAtient(dtb);
        }
        public DataTable get_patientPrefix()
        {
            DataTable patidGeneration = db.table("select patient_prefix,patient_number from tbl_patient_automaticid where patient_automation='Yes'");
            return patidGeneration;
        }
        public void Save_patient(string PatientName, string Patient_Id, string aadhar_id, string gender, string date_of_birth, string age, string blood_group, string family, string relation, string primary_mobile_number, string secondary_mobile_number, string landline_number, string email_address, string street_address, string locality, string city, string pincode, string date, string group_id, string refferedby, string Opticket, string Visited, string doctorname, string Occupation)
        {
            pmodel.PatientName = PatientName;
            pmodel.PatientId = Patient_Id;
            pmodel.Aadhaar = aadhar_id;
            pmodel.Blood = blood_group;
            pmodel.Accompainedby = family;
            pmodel.Age = age;
            pmodel.DOB = date_of_birth;
            pmodel.Doctor = doctorname;
            pmodel.FileNo = Opticket;
            pmodel.Landline = landline_number;
            pmodel.Occupation = Occupation;
            pmodel.ReferredBy = refferedby;
            pmodel.PrimaryMob = primary_mobile_number;
            pmodel.SecondaryMob = secondary_mobile_number;
            pmodel.Street = street_address;
            pmodel.DateofAdmit = Visited;
            pmodel.Gender = gender;
            pmodel.Pincode = pincode;
            pmodel.City = city;
            pmodel.Email = email_address;
            pmodel.Locality = locality;
            pmodel.Save();
        }
        public DataTable get_max_patid()
        {
            DataTable rs_patient = db.table("SELECT MAX(id) FROM tbl_patient");
            return rs_patient;
        }
        public DataTable automaticid()
        {
          DataTable dtb= pmodel.automaticid();
          return dtb; 
        }
        public void update_autogenerateid(int n)
        {
            pmodel.update_autogenerateid(n);
        }
        public DataTable Get_calenderColor(string dr_id)
        {
            DataTable dt_d = db.table("select calendar_color,mobile_number,email_id from tbl_doctor where  id=" + dr_id + " ORDER BY ");
            return dt_d;
        }
        public DataTable get_doctor_login(string id)
        {
            DataTable doctor = db.table("select doctor_name,mobile_number,login_type from tbl_doctor where id='" + id + "'");
            return doctor;
        }
        public DataTable patient_details_byname(string txt_p_name)
        {
            DataTable dtb = _model.patient_details(txt_p_name);
            return dtb;
            //intr.Appointment_for_newPAtient(dtb);
        }
        public int insappointment(DateTime book_datetime, DateTime start_datetime, string duration, string note, string pt_id, string pt_name, string dr_id, string mobile_no, string email_id, string plan_new_procedure, string booked_by)
        {
            //addmodel.book_datetime = book_datetime;
            //addmodel.start_date = start_datetime;
            //addmodel.duration = duration;
            //addmodel.note = note;
            //addmodel.patient_id = pt_id;
            //addmodel.pt_name = pt_name;
            //addmodel.dr_id = dr_id;
            //addmodel.pt_mobile = mobile_no;
            //addmodel.pt_email = email_id;
            //addmodel.plan_new_procedure = plan_new_procedure;
            //addmodel.booked_by = booked_by;
            int i = addmodel.insappointment(book_datetime.ToString(), start_datetime.ToString(), duration, note, pt_id, pt_name, dr_id, mobile_no, email_id, plan_new_procedure, booked_by);
            return i;
        }
        public DataTable appointmentId()
        {
            DataTable dt_a = db.table("select id from tbl_appointment ORDER BY id");
            return dt_a;
        }
        public DataTable clinicdetails()
        {
            DataTable dtb = addmodel.clinicdetails();
            return dtb;
        }
        public DataTable Get_Patient_Details(string id)
        {
            DataTable dtb = cmodel.Get_Patient_Details(id);
            return dtb;
        }
        public DataTable Get_reminderSmS()
        {
            DataTable smsreminder = db.table("select * from tbl_appt_reminder_sms");
            return smsreminder;
        }
        public void save_Pt_SMS(string patient_id,string ptnaame,string procedure,string StartT,string cmbStartTime,string combodoctor)
        {
            db.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + patient_id + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm") + "','patient','sent','Dear " + ptnaame + " " + "Your appointment for " + procedure + " has been confirmed at " + StartT+ " " + cmbStartTime + " with " + "Dr " + combodoctor + " Regards ')");
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
        public void update_appointment(DateTime StartT,string diff1,string note,string patient_id,string patient_name,string dr_id,string mobile_no, string email,string gpl_app_id)
        {
            int j = db.execute("update tbl_appointment set start_datetime='" + Convert.ToDateTime(StartT).ToString("yyyy-MM-dd HH:mm") + "',duration='" + diff1 + "',note='" + note + "',pt_id='" + patient_id + "',pt_name='" + patient_name + "',dr_id='" + dr_id + "',mobile_no='" + mobile_no + "',email_id='" + email + "' where id='" + gpl_app_id + "'"); 
        }
    }
}
