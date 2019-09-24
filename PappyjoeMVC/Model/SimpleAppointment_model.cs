using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
    public class SimpleAppointment_model
    {
        Connection db = new Connection();
       public DataTable get_drug_details()
        {
            DataTable dt_prescription = db.table("select id,name, type, strength_gr, strength,inventory_id from tbl_adddrug ORDER BY id DESC");
            return dt_prescription;
        }
        public DataTable get_pt_details(string patient_id)
        {
            DataTable dtb = db.table("select id, pt_id,pt_name,primary_mobile_number,gender,age,street_address,locality,city,pincode from tbl_patient where id='" + patient_id + "'");
            return dtb;
        }
        public DataTable get_EHR_details(string strApp_id)
        {
            DataTable App_dtb = db.table("select EHR_status,EHR_clinicalfindings,EHR_treatment,EHR_prescription,EHR_invoice from tbl_appointment where id='" + strApp_id + "' AND EHR_status='YES'");
            return App_dtb;
        }
        public DataTable get_treatment_details(string plan_main_id)
        {
            DataTable Dt_Treatment = db.table("SELECT plan_main_id,pt_id,procedure_id,procedure_name,quantity,cost,discount_type,discount,total,discount_inrs,note,status,date,dr_id,completed_id,tooth FROM tbl_completed_procedures WHERE plan_main_id='" + plan_main_id + "'");
            return Dt_Treatment;
        }
        public string get_review_date(string id)
        {
            string Dt_Review = db.scalar("SELECT review,review_date  FROM tbl_completed_id WHERE id='" +id+ "' and review='YES'");
            return Dt_Review;
        }
        public DataTable get_proceduresettings()
        {
            DataTable dt_Procedure = db.table("select id,name,cost from tbl_addproceduresettings where  LOWER(name)='consultation'");
            return dt_Procedure;
        }
        public string get_doctorname(string strApp_id)
        {
            string App_dtb1 = db.scalar("select tbl_doctor.doctor_name from tbl_appointment  LEFT JOIN  tbl_doctor ON tbl_appointment.dr_id=tbl_doctor.id  where tbl_appointment.id='" + strApp_id + "'");
            return App_dtb1;
        }
        public DataTable get_patient_name(string patient_id)
        {
            DataTable dt_ptiantId = db.table("select id,pt_name from tbl_patient where id = '" + patient_id + "'");
            return dt_ptiantId;
        }//
        public DataTable  patient_id(string txtPatientID)
        {
         DataTable dtb= db.table("select id,pt_name from tbl_patient where pt_id = '" + txtPatientID + "'");
         return dtb;
        }
        public void save_invoice(string invoice_no, string pt_name,string pt_id,string service_id,string services,string unit,string cost, string discount,string discount_type,string total_cost,string total_discount,string dr_id,string discountin_rs, string invoice_main_id,string tax_inrs,string tax,string total_tax)
        {
            db.execute("insert into tbl_invoices(invoice_no,pt_name,pt_id,service_id,services,unit,cost,discount,discount_type,total,date,total_cost,total_discount,dr_id,discountin_rs,total_payment,invoice_main_id,tax_inrs,tax,total_tax) values('" + invoice_no + "','" + pt_name + "','" + pt_id + "','" + service_id + "','" + services + "','" + unit + "','" + cost + "','" + discount + "','" + discount_type + "','0','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + total_cost + "','" + total_discount + "','" + dr_id + "','" + discountin_rs + "','100','" + invoice_main_id + "','" + tax_inrs + "','" + tax + "','" + total_tax + "')");
        }
        public string get_invoicenumber()
        {
            string invoauto = db.scalar("select invoice_number from tbl_invoice_automaticid");
            return invoauto;
        }
        public void update_invnumber(string invoautoup)
        {
            db.execute("update tbl_invoice_automaticid set invoice_number='" + invoautoup + "'");
        }
        public void save_receipt(string receipt_no,string amount_paid,string invoice_no,string procedure_name,string pt_id,string dr_id,string total,string cost,string pt_name)
        {
            db.execute("insert into tbl_payment(receipt_no,advance,amount_paid,invoice_no,procedure_name,pt_id,payment_date,dr_id,total,cost,pt_name,mode_of_payment)values('" + receipt_no + "','0','" + amount_paid + "','" + invoice_no + "','" + procedure_name + "','" + pt_id + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + dr_id + "','" + total + "','" + cost + "','" + pt_name + "','Cash')");
        }
        public void save_appointmnt(string EHR_Clinical,string EHR_treat,string EHR_Pre,string EHR_invoice,string strApp_id)
        {
            db.execute("update tbl_appointment set EHR_status='YES',EHR_clinicalfindings='" + EHR_Clinical + "',EHR_treatment='" + EHR_treat + "',EHR_prescription='" + EHR_Pre + "',EHR_invoice='" + EHR_invoice + "' WHERE ID='" + strApp_id + "'");
        }
        public void save_patient(string pt_name, string pt_id, string primary_mobile_number, string gender, string age, string locality, string city, string Visited, string doctorname)
        {
            db.execute("insert into tbl_patient (pt_name,pt_id,primary_mobile_number,gender,age,locality,city,Visited,doctorname,Profile_Status) values('" + pt_name + "','" + pt_id + "','" + primary_mobile_number + "',' " + gender + " ','" + age + "','" + locality + "','" + city + "','" + Visited + "','" + doctorname + "','Active')");
        }
        public DataTable get_pres_details_wit_ptid(string patient_id,string EHR_Pre)
        {
            DataTable sqlstring = db.table( "SELECT drug_name,strength,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,strength_gr,date FROM tbl_prescription where pt_id='" + patient_id + "' and pres_id ='" + EHR_Pre + "' ORDER BY id");
            return sqlstring;
        }
        public DataTable load_template()
        {
            DataTable dt = db.table("select * from tbl_templates_main order by id");
            return dt;
        }
        public DataTable drug_search(string txt_Prescrptn)
        {
            DataTable dtb = db.table("select id,name, type, strength_gr, strength,inventory_id from tbl_adddrug where name like '%" + txt_Prescrptn + "%'  ORDER BY id DESC");
            return dtb;
        }
        public DataTable get_drug_strength(string idpres)
        {
            DataTable dt = db.table("select id,name,strength_gr from tbl_adddrug where id='" + idpres + "'");
            return dt;
        }
        public string drug_type(string Lab_DrugId)
        {
            string dt = db.scalar("select type from tbl_adddrug where id='" + Lab_DrugId + "'");
            return dt;
        }
        public DataTable template_main(string idpres)
        {
            DataTable dt = db.table("select * from tbl_templates_main where id='" + idpres + "' ");
            return dt;
        }
        public DataTable template_details(string idpres)
        {
            DataTable dt_template = db.table("select * from tbl_template where temp_id='" + idpres + "' ");
            return dt_template;
        }
    }
}
