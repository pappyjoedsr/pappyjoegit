using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
  public class Consultation_model
  {
        Connection db = new Connection();
        public DataTable search_patient(string search)
        {
            DataTable dtdr = db.table("select id,pt_name from tbl_patient where pt_name like '%" + search + "%'  ");
            return dtdr;
        }
        public DataTable srch_patient(string ptname,string mobno)
        {
            DataTable dtdr = db.table("select id,pt_name from tbl_patient where pt_name like '%" + ptname + "%'  or primary_mobile_number like '%" + mobno + "%'");
            return dtdr;
        }
        public DataTable get_tmplates()
        {
            DataTable dt2 = db.table("select id,templates from tbl_templates_main ORDER BY id DESC");
            return dt2;
        }
        public DataTable patient_details(string value)
        {
            DataTable patient = db.table("select id, pt_name,pt_id from tbl_patient where id='" + value + "'");
            return patient;
        }
        public DataTable get_prescriptn()
        {
            DataTable dt_prescription = db.table("select id,CONCAT(name,' ', type ) as name, CONCAT(strength_gr ,' ' , strength ) as type,inventory_id from tbl_adddrug ORDER BY id DESC limit 30");
            return dt_prescription;
        }
        public DataTable get_prescriptnwthname(string pescrptn)
        {
            DataTable dt_prescription = db.table("select id,CONCAT(name,' ', type ) as name, CONCAT(strength_gr ,' ' , strength ) as type,inventory_id from tbl_adddrug where name like '%" + pescrptn + "%'  ORDER BY id DESC Limit 30");
            return dt_prescription;
        }
        public DataTable get_unit()
        {
            DataTable unt = db.table("select * from tbl_unit");
            return unt;
        }
        public DataTable search_procedure(string search)
        {
            DataTable dtdr = db.table("select id,name from tbl_addproceduresettings where name like '%" + search + "%'  ");
            return dtdr;
        }
        public DataTable procedure_details(string value)
        {
            DataTable procedure = db.table("select id,name,cost from tbl_addproceduresettings where  id='" + value + "'");
            return procedure;
        }
        public DataTable Load_temlate()
        {
            DataTable dtb_prescription = db.table("select * from tbl_templates_main order by id");
            return dtb_prescription;
        }
        public DataTable Load_doctor()
        {
            DataTable dt = db.table("select DISTINCT id,doctor_name from tbl_doctor  where login_type='doctor' or login_type='admin' order by doctor_name");
            return dt;
        }
        public DataTable Load_dctrname(string doctor_id)
        {
            DataTable dt_doctor = db.table("select id,doctor_name from tbl_doctor  where id='" + doctor_id + "'");
            return dt_doctor;
        }
        public DataTable get_procedure()
        {
            DataTable procedure = db.table("select id,name,cost from tbl_addproceduresettings where  LOWER(name)='consultation'");
            return procedure;  
        }
        public DataTable get_tempid(string pres_id)
        {
            DataTable dtb_prescription = db.table("select * from tbl_templates_main where id='" + pres_id + "'");
            return dtb_prescription;
        }
        public DataTable get_templateid(string presid)
        {
            DataTable dt_prs = db.table("select * from tbl_template where temp_id='" + presid + "'");
            return dt_prs;
        }
        public DataTable get_invid(string drugid)
        {
            DataTable dt4 = db.table("select id,inventory_id from tbl_adddrug where id='" + drugid + "' and inventory_id<>0 ORDER BY id DESC");
            return dt4;
        }
        public void save_prescriptionMain(string patient_id, int d_id, string Prescription_bill_status, string notes)
        {
            db.execute("insert into tbl_prescription_main (pt_id,dr_id,date,pay_status,notes) values('" + patient_id + "','" + d_id + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + Prescription_bill_status + "','" + notes + "')");
        }
        public string max_presid()
        {
            string dt = db.scalar("select MAX(id) from tbl_prescription_main");
            return dt;
        }
        public void save_prescription(int presid, string patient_id, string dr_name, string dr_id,  string drug_name, string strength, string strength_gr, string duration_period, string morning, string noon, string night, string food, string add_instruction, string drug_type, string status, string drug_id)
        {
            db.execute("insert into tbl_prescription (pres_id,pt_id,dr_name,dr_id,date,drug_name,strength,strength_gr,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,status,drug_id) values('" + presid + "','" + patient_id + "','" + dr_name + "','" + dr_id + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + drug_name + "','" + strength + "','" + strength_gr + "','','" + duration_period + "','" + morning + "','" + noon + "','" + night + "','" + food + "','" + add_instruction + "','" + drug_type + "'," + status + ",'" + drug_id + "')");
        }
        public void save_completedid(string patient_id)
        {
            db.execute("insert into tbl_completed_id (completed_date,patient_id,review) values('" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + patient_id + "','NO')");
        }
        public DataTable get_invoice_data()
        {
            DataTable dtb = db.table("select invoice_prefix,invoice_number from tbl_invoice_automaticid where invoive_automation='Yes' ");
            return dtb;
        }
        public string max_completedid()
        {
            string dt_CMain = db.scalar("select MAX(id) from tbl_completed_id");
            return dt_CMain;
        }
        public void save_completed_details(int plan_main_id,string pt_id, string procedure_id, string procedure_name,  string cost,  string total,  string note,  string dr_id)
        {
            int d = db.execute("insert into tbl_completed_procedures (plan_main_id,pt_id,procedure_id,procedure_name,quantity,cost,discount_type,discount,total,discount_inrs,note,status,date,dr_id,completed_id,tooth) values('" + plan_main_id + "','" + pt_id + "','" + procedure_id + "','" + procedure_name + "','1','" + cost + "','INR','0','" + total + "','0','" + note + "','0','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + dr_id + "','0','')");
        }
        public string max_completeProcedure()
        {
            string dt_Compl_proce = db.scalar("select MAX(id) from tbl_completed_procedures");
            return dt_Compl_proce;
        }
        public void save_invoice_main(string patient_id,string pt_name,string invoice)
        {
            db.execute("insert into tbl_invoices_main (date,pt_id,pt_name,invoice,status,type) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + patient_id + "','" + pt_name + "','" + invoice + "','0','service')");
        }
        public void save_invoice_details(string invoice,string pt_name,string patient_id,string service_id,string services,string cost,string total,string dr_id, long Invoice_main_id, long completed_procedures_id)
        {
            db.execute("insert into tbl_invoices(invoice_no,pt_name,pt_id,service_id,services,unit,cost,discount,discount_type,total,date,total_cost,total_discount,dr_id,discountin_rs,total_payment,invoice_main_id,tax_inrs,tax,total_tax,grant_total,plan_id,completed_id,notes) values('" + invoice + "','" + pt_name + "','" + patient_id + "','" + service_id + "','" + services + "','1','" + cost + "','0','INR','" + total + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','100','','" + dr_id + "','','100','" + Invoice_main_id + "','0','NA','0','100','0','" +completed_procedures_id + "','')");
        }
        public void save_receipt(string receipt,decimal advance,string amount_paid,string invoice,string procedure_name, string patient_id,string dr_id,string total,string cost,string pt_name,long Invoice_main_id)
        {
            db.execute("insert into tbl_payment(receipt_no,advance,amount_paid,invoice_no,procedure_name,pt_id,payment_date,dr_id,total,cost,pt_name,mode_of_payment,payment_due)values('" + receipt + "','" + advance + "','" + amount_paid + "','" + invoice + "','" + procedure_name + "','" + patient_id + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + dr_id + "','" + total + "','" + total + "','" + pt_name + "','Cash','" + Invoice_main_id + "')");
        }
        public DataTable get_receipt_details(string payment_date,string patient_id,string receipt)
        {
           DataTable  strsql =db.table( "select receipt_no,amount_paid,invoice_no,procedure_name,payment_date from tbl_payment where payment_date='" + payment_date + "' and pt_id='" + patient_id + "' and receipt_no='" + receipt + "' order by payment_date");
            return strsql;
        }
        public DataTable get_payment_details(string payment_date,string patient_id,string receipt)
        {
            DataTable strsql =db.table( "select * from tbl_payment where payment_date='" + payment_date + "' and pt_id='" + patient_id + "' and receipt_no='" + receipt + "'");
            return strsql;
        }
        public DataTable get_receipt_print_setting()
        {
            DataTable dtb= db.table("select header,left_text,right_text,fullwidth_context,left_sign,right_sign,include_header,include_logo from  tbl_receipt_printsettings");
            return dtb;
        }
        // consultation new patient
        public int save_patient(string pt_name,string pt_id,string gender,string primary_mobile_number)
        {
          int i=  db.execute("insert into tbl_patient (pt_name,pt_id,gender,primary_mobile_number,Visited,date,Profile_Status)values('" + pt_name + "','" + pt_id + "','" + gender + "','" + primary_mobile_number + "','"+ DateTime.Now.Date.ToString("yyyy/MM/dd")+ "','" + DateTime.Now.Date.ToString("yyyy/MM/dd") + "','Active')");
            return i;
        }
        public string patient_maxid()
        {
            string pid = db.scalar("SELECT MAX(id) from tbl_patient");
            return pid;
        }
        public DataTable get_practice_details()
        {
            DataTable clinicname = db.table("select name,contact_no from tbl_practice_details");
            return clinicname;
        }
        public DataTable get_patient_details(string newptid)
        {
            DataTable dtb = db.table("select id,pt_id,pt_name,primary_mobile_number from tbl_patient where id='" + newptid + "'");
            return dtb;
        }
        public DataTable patient_data(string newptid)
        {
            DataTable dtb = db.table("select pt_id,pt_name,gender,age,street_address,locality,city,pincode,primary_mobile_number,email_address from tbl_patient where id='" + newptid + "'");
            return dtb;
        }
        public DataTable get_practicedtls()
        {
            DataTable dt = db.table("select name,street_address,locality,pincode,contact_no,email,website from tbl_practice_details");
            return dt;
        }
        public DataTable pt_details(string ptid)
        {
            DataTable dt = db.table("select id,pt_id,pt_name,doctorname,primary_mobile_number from tbl_patient where id='" + ptid + "'"); ;
            return dt;
        }
        public DataTable drug_dtls(string id)
        {
            DataTable dt = db.table("select name,strength,strength_gr,type,instructions from tbl_adddrug where id ='" + id + "'");
            return dt;
        }
    }
}
