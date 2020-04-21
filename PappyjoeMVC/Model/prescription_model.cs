using System.Data;
using System;
namespace PappyjoeMVC.Model
{
    public class Prescription_model
    {
        Connection db = new Connection();
        public DataTable getPrescriptionMain(string prescription_id, string ptid)
        {
            DataTable dt_prescription_main = db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.date,tbl_doctor.doctor_name,tbl_prescription_main.notes FROM tbl_prescription_main join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id where tbl_prescription_main.id='" + prescription_id + "' and pt_id='" + ptid + "'");
            return dt_prescription_main;
        }
        public DataTable get_prescription_Data(string prescription_id, string ptid)
        {
            DataTable dt1 = db.table("select * from tbl_prescription where pres_id='" + prescription_id + "' and pt_id='" + ptid + "'");
            return dt1;
        }
        public DataTable drug_load()
        {
            DataTable dt4 = db.table("select id,CONCAT(name,' ', type ) as name, CONCAT(strength_gr ,' ' , strength ) as type,inventory_id from tbl_adddrug ORDER BY id DESC");
            return dt4;
        }
        public DataTable drug_instock(string id)
        {
            DataTable dtstock = db.table("Select A.item_code,A.item_name,(select sum(Qty) from tbl_BatchNumber where item_code= A.id) 'Stock' from tbl_ITEMS A WHERE A.ID='" + id + "' order by item_name");
            return dtstock;
        }
        public DataTable load_template()
        {
            DataTable dt2 = db.table("select id,templates from tbl_templates_main ORDER BY id DESC");
            return dt2;
        }
        public DataTable drug_search(string search)
        {
            DataTable dt4 = db.table("select id,CONCAT(name,' ', type ) as name, CONCAT(strength_gr, ' ', strength ) as type,inventory_id from tbl_adddrug where name like'" + search + "%' ORDER BY id DESC");
            return dt4;
        }
        public DataTable search_template(string searchtext2)
        {
            DataTable dt2 = db.table("select id,templates from tbl_templates_main where templates like'%" + searchtext2 + "%'");
            return dt2;
        }
        public DataTable ge_drug(string id1)
        {
            DataTable dt = db.table("select name,strength,strength_gr,type,instructions,id from tbl_adddrug where id ='" + id1 + "'");
            return dt;
        }
        public DataTable get_template(string idtemp)
        {
            DataTable dt = db.table("select drug_name,strength,strength_gr,duration,duration_period,morning,noon,night,add_instruction,food,drug_id,drug_type,status from tbl_template where temp_id ='" + idtemp + "'");
            return dt;
        }
        public DataTable get_inventoryid(string id)
        {
            DataTable dt4 = db.table("select id,inventory_id from tbl_adddrug where id='" + id + "' and inventory_id<>0 ORDER BY id DESC");
            return dt4;
        }
        public void save_prescriptionmain(string ptid, string d_id, string date, string prescription_bill_status, string note)
        {
            db.table("insert into tbl_prescription_main (pt_id,dr_id,date,pay_status,notes) values('" + ptid + "','" + d_id + "','" + date + "','" + prescription_bill_status + "','" + note + "')");
        }
        public string Maxid()
        {
            string dt = db.scalar("select MAX(id) from tbl_prescription_main");
            return dt;
        }
        public void save_prescription(int pres_id, string pt_id, string dr_name, string dr_id, string date, string drug_name, string strength, string strength_gr, string duration_unit, string duration_period, string morning, string noon, string night, string food, string add_instruction, string drug_type, string status, string drug_id)
        {
            db.table("insert into tbl_prescription (pres_id,pt_id,dr_name,dr_id,date,drug_name,strength,strength_gr,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,status,drug_id) values('" + pres_id + "','" + pt_id + "','" + dr_name + "','" + dr_id + "','" + date + "','" + drug_name + "','" + strength + "','" + strength_gr + "','  " + duration_unit + "','" + duration_period + "','" + morning + "','" + noon + "','" + night + "','" + food + "','" + add_instruction + "','" + drug_type + "'," + status + ",'" + drug_id + "')");
        }
        public void update_prescription_review(string date, int presid)
        {
            db.execute("UPDATE tbl_prescription_main SET review='YES',Review_date='" + date + "' WHERE id='" + presid + "'");
        }
       
        public void update_prescription_review_NO(string date, int presid)
        {
            db.execute("UPDATE tbl_prescription_main SET review='NO',Review_date='" + date + "'  WHERE id='" + presid + "'");
        }
        public void update_prescription_main(string note, string Prescription_bill_status, string prescription_id)
        {
            db.execute("update tbl_prescription_main set notes='" + note + "',pay_status='" + Prescription_bill_status + "' where id='" + prescription_id + "'");
        }
        public void delete_prescription(string prescription_id)
        {
            db.execute("delete from tbl_prescription where pres_id='" + prescription_id + "'");
        }
        public void save_template(string template)
        {
            db.execute("insert into tbl_templates_main(templates) values('" + template + "')");
        }
        public string get_templateid(string tempnametext)
        {
            string dt = db.scalar("select id from tbl_templates_main where templates='" + tempnametext + "'");
            return dt;
        }
        public void save_template(string temp_id, string pt_id, string pt_name, string dr_id, string dr_name, string date, string drug_name, string strength, string strength_gr, string duration, string morning, string noon, string night, string food, string add_instruction, string drug_type, string drug_id, string pres_id, string duration_period, string status)
        {
            db.execute("insert into tbl_template (temp_id,pt_id,pt_name,dr_id,dr_name,date,drug_name,strength,strength_gr,duration,morning,noon,night,food,add_instruction,drug_type,drug_id,pres_id,duration_period,status) values('" + temp_id + "','" + pt_id + "','" + pt_name + "','" + dr_id + "','" + dr_name + "','" + date + "','" + drug_name + "','" + strength + "','" + strength_gr + "','" + duration + "','" + morning + "','" + noon + "','" + night + "','" + food + "','" + add_instruction + "','" + drug_type + "','" + drug_id + "','" + pres_id + "','" + duration_period + "','" + status + "')");
        }
        //prescription show
        public DataTable clinicpath()
        {
            DataTable dtp = db.table("select path from tbl_practice_details");
            return dtp;
        }
        public string add_privillege(string doctor_id)
        {
            string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRP' and Permission='A'");
            return privid;
        }
        public string edit_privillege(string doctor_id)
        {
            string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRP' and Permission='E'");
            return privid;
        }
        public string delete_privillege(string doctor_id)
        {
            string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRP' and Permission='D'");
            return privid;
        }
        public DataTable Get_maindtails(string patient_id)
        {
            System.Data.DataTable dt_pre_main = db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.date,tbl_doctor.doctor_name  FROM tbl_prescription_main join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id  where tbl_prescription_main.pt_id='" + patient_id + "' ORDER BY tbl_prescription_main.date DESC");
            return dt_pre_main;
        }
        public DataTable Get_maindta(string patient_id)
        {
            System.Data.DataTable dt_pre_main = db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.date,tbl_doctor.doctor_name  FROM tbl_prescription_main join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id  where tbl_prescription_main.pt_id='" + patient_id + "' ORDER BY tbl_prescription_main.date DESC");
            return dt_pre_main;
        }
      
        public DataTable prescription_detoails(string id)
        {
            System.Data.DataTable dt_prescription = db.table("SELECT drug_name,strength,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,strength_gr,status FROM tbl_prescription WHERE pres_id='" + id + "' ORDER BY id");
            return dt_prescription;
        }
        public DataTable printsettings()
        {
            DataTable print = db.table("select header,left_text,right_text,fullwidth_context,left_sign,right_sign,include_logo from tbl_presciption_printsettings");
            return print;
        }
        public DataTable get_allprescription(string prescription_id)
        {
            DataTable td_prescription_Sub = db.table("SELECT pres_id,pt_id,dr_name,dr_id,date,drug_name,strength,strength_gr,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,status,drug_id FROM tbl_prescription  WHERE pres_id= '" + prescription_id + "' ORDER BY id");
            return td_prescription_Sub;
        }
        public DataTable patient_details(string patient_id)
        {
            System.Data.DataTable dt1 = db.table("select pt_id,pt_name,gender,age,street_address,city,primary_mobile_number,locality,email_address,pincode,doctorname from tbl_patient where id='" + patient_id + "'");
            return dt1;
        }
        public DataTable patient_prescptn(string prescription_id, string patient_id)
        {
            System.Data.DataTable dt_cf = db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.date,tbl_doctor.doctor_name,tbl_prescription_main.notes FROM tbl_prescription_main join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id where tbl_prescription_main.id='" + prescription_id + "' and tbl_prescription_main.pt_id='" + patient_id + "'");
            return dt_cf;
        }
        public void delete_allprescription(string prescription_id)
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
        public DataTable table_details(string prescription_id, string patient_id)
        {
            DataTable dt_cf = db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.date,tbl_doctor.doctor_name,tbl_prescription_main.notes,tbl_prescription_main.review,tbl_prescription_main.Review_date FROM tbl_prescription_main join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id where tbl_prescription_main.id='" + prescription_id + "' and tbl_prescription_main.pt_id='" + patient_id + "'");
            return dt_cf;
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
        //simple appointment template
        public DataTable get_drug_name()
        {
            DataTable dt_prescription = db.table("select id,name from tbl_adddrug");
            return dt_prescription;
        }
        public string get_patientname(string ptid)
        {
            string dt_patient = db.scalar("select Pt_name from tbl_patient where id='" + ptid + "'");
            return dt_patient;
        }
        public DataTable sms_details()
        {
            DataTable sms = db.table("select smsName,smsPass from tbl_SmsEmailConfig");
            return sms;
        }
    }
}
