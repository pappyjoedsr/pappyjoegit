using PappyjoeMVC.Model;
using System;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Prescription_Show_controller
    {
        prescriptionshow_interface intr;
        Prescription_model _model = new Prescription_model();
        Connection db = new Connection();
        Common_model cmodel = new Common_model();
        Booking_model bmodel = new Booking_model();
        public Prescription_Show_controller(prescriptionshow_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
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
            System.Data.DataTable dt_pre_main = _model.Get_maindtails(patient_id);// db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.date,tbl_doctor.doctor_name  FROM tbl_prescription_main join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id  where tbl_prescription_main.pt_id='" + patient_id + "' ORDER BY tbl_prescription_main.date DESC");
            //intr.Load_MainGrid(dt_pre_main);
            return dt_pre_main;
        }
        public DataTable Get_maindta(string patient_id)
        {
            System.Data.DataTable dt_pre_main = db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.date,tbl_doctor.doctor_name  FROM tbl_prescription_main join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id  where tbl_prescription_main.pt_id='" + patient_id + "' ORDER BY tbl_prescription_main.date DESC");
            return dt_pre_main;
        }

        public DataTable prescription_details(string id)
        {
            System.Data.DataTable dt_prescription = db.table("SELECT drug_name,strength,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,strength_gr,status FROM tbl_prescription WHERE pres_id='" + id + "' ORDER BY id");
            return dt_prescription;
        }
        public DataTable printsettings()
        {
            DataTable print = db.table("select header,left_text,right_text,fullwidth_context,left_sign,right_sign from tbl_presciption_printsettings");
            return print;
        }
        public DataTable clinicpath()
        {
            DataTable dtp = db.table("select path from tbl_practice_details");
            return dtp;
        }
        public DataTable patient_details(string patient_id)
        {
            System.Data.DataTable dt1 = db.table("select pt_id,pt_name,gender,age,street_address,city,primary_mobile_number,locality,email_address,pincode from tbl_patient where id='" + patient_id + "'");
            return dt1;
        }

        public DataTable patient_prescptn(string prescription_id, string patient_id)
        {
            System.Data.DataTable dt_cf = db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.date,tbl_doctor.doctor_name,tbl_prescription_main.notes FROM tbl_prescription_main join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id where tbl_prescription_main.id='" + prescription_id + "' and tbl_prescription_main.pt_id='" + patient_id + "'");
            return dt_cf;
        }
        public void delete_prescription(string prescription_id)
        {
            db.execute("delete from tbl_prescription_main where id='" + prescription_id + "'");
            db.execute("delete from tbl_prescription where pres_id='" + prescription_id + "'");
        }
        public DataTable get_presctnMain(string prescription_id)
        {
            System.Data.DataTable td_prescription_main = db.table("SELECT id,pt_id,dr_id,date,notes FROM tbl_prescription_main WHERE id='" + prescription_id + "' ORDER BY id");
            return td_prescription_main;
        }
        public void save_prescriptionmain(string pt_id, string dr_id, string notes)
        {
            db.table("insert into tbl_prescription_main (pt_id,dr_id,date,notes) values('" + pt_id + "','" + dr_id + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + notes + "')");
        }
        public DataTable Maxid()
        {
            DataTable dtb = _model.Maxid();
            return dtb;
        }
        public DataTable get_allprescription(string prescription_id)
        {
            DataTable td_prescription_Sub = db.table("SELECT pres_id,pt_id,dr_name,dr_id,date,drug_name,strength,strength_gr,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,status,drug_id FROM tbl_prescription  WHERE pres_id= '" + prescription_id + "' ORDER BY id");
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
            DataTable dtp = db.table("select name,contact_no from tbl_practice_details");
            return dtp;
        }
        public DataTable printsettings_details()
        {
            DataTable print = db.table("select * from tbl_presciption_printsettings");
            return print;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable dtb = cmodel.Get_practiceDlNumber();
            return dtb;
        }
        public DataTable table_details(string prescription_id, string patient_id)
        {
            DataTable dt_cf = db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.date,tbl_doctor.doctor_name,tbl_prescription_main.notes,tbl_prescription_main.review,tbl_prescription_main.Review_date FROM tbl_prescription_main join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id where tbl_prescription_main.id='" + prescription_id + "' and tbl_prescription_main.pt_id='" + patient_id + "'");
            return dt_cf;
        }
        public DataTable sms_details()
        {
            DataTable sms = bmodel.sms_details();// db.table("select smsName,smsPass from tbl_SmsEmailConfig");
            return sms;
        }
        public DataTable get_patientnumber(string patient_id)
        {
            DataTable pat = db.table("select pt_name,primary_mobile_number from tbl_patient where id='" + patient_id + "'");
            return pat;
        }
        public DataTable remindersms()
        {
            DataTable smsreminder = db.table("select * from tbl_appt_reminder_sms");
            return smsreminder;
        }
        public void savecommunication(string patient_id, string text)
        {
            db.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + patient_id + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','patient','sent','" + text + "')");
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
