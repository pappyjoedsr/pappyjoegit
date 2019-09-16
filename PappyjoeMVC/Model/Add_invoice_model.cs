using System.Data;
using System;
namespace PappyjoeMVC.Model
{
    public class Add_Invoice_model
    {
        Connection db = new Connection();
        public DataTable load_tax()
        {
            DataTable dt5 = db.table("select id,tax_name from tbl_tax");
            return dt5;
        }
        public DataTable get_completed_procedure_details(string patient_id)
        {
            DataTable dt_tp1 = db.table("SELECT id, procedure_name,procedure_id,cost from tbl_completed_procedures where pt_id='" + patient_id + "' and status='1'");
            return dt_tp1;
        }
        public DataTable get_planed_procedure(string patient_id)
        {
            DataTable dt_tp = db.table("SELECT id, plan_main_id,procedure_name,procedure_id,cost from tbl_treatment_plan where pt_id='" + patient_id + "' and status='1'");
            return dt_tp;
        }
        public DataTable Get_invoice_deatils(string ptid, string invoiceid)
        {
            DataTable dt2 = db.table("select * from tbl_invoices where pt_id='" + ptid + "' and invoice_no='" + invoiceid + "'");
            return dt2;
        }
        public DataTable load_completed_procedure(string id)
        {
            System.Data.DataTable rs_plan = db.table("select A.procedure_id,A.procedure_name,A.quantity,A.cost,A.discount_type,A.discount,A.total," +
                    "A.discount_inrs,A.note,A.date,A.dr_id,A.tooth,B.doctor_name,A.completed_id from tbl_completed_procedures as A join tbl_doctor as B on B.id=A.dr_id where A.id='" + id + "'");
            return rs_plan;
        }
        public DataTable Get_completed_table_details(string P_Completed_id)
        {
            DataTable dt_treatment = db.table("select procedure_name,quantity,cost,discount_type,discount,discount_inrs,note,tooth,total from tbl_completed_procedures where id ='" + P_Completed_id + "'");
            return dt_treatment;
        }
        public DataTable select_All_invoicedata(string billno)
        {
            DataTable receipt = db.table("select * from tbl_invoices_main where invoice='" + billno + "'");
            return receipt;
        }
        public DataTable get_taxValue(string name)
        {
            DataTable dt = db.table("select tax_value from tbl_tax where tax_name ='" + name + "'");
            return dt;
        }
        public DataTable Get_quantiry_fromStock(string stock_id)
        {
            DataTable testQty = db.table("select quantity from tbl_add_stock where id='" + stock_id + "'");
            return testQty;
        }
        public DataTable Load_invoice_mainDetails(string patient_id)
        {
            DataTable dt_invoice_main = db.table("SELECT id,date,invoice,status FROM tbl_invoices_main where pt_id='" + patient_id + "' ORDER BY date DESC");
            return dt_invoice_main;
        }
        public DataTable get_invoice_doctorname(string patient_id)
        {
            DataTable dt_cf = db.table("SELECT tbl_doctor.doctor_name, tbl_invoices_main.date,tbl_invoices.invoice_no FROM tbl_invoices INNER JOIN tbl_doctor ON tbl_invoices.dr_id = tbl_doctor.id INNER JOIN tbl_invoices_main ON tbl_invoices.invoice_main_id = tbl_invoices_main.id WHERE tbl_invoices_main.pt_id = '" + patient_id + "'");
            return dt_cf;
        }
        public DataTable Get_invoice_prefix()
        {
            DataTable invno = db.table("select invoice_prefix,invoice_number,invoive_automation from tbl_invoice_automaticid where invoive_automation='Yes'");
            return invno;
        }
        public DataTable search_procedure_completed(string patient_id, string search)
        {
            DataTable dt_tp1 = db.table("SELECT id, procedure_name,procedure_id,cost from tbl_completed_procedures where pt_id='" + patient_id + "' and status='1' and procedure_name like'" + search + "%'");
            return dt_tp1;
        }
        public DataTable Search_procedure_planed(string patient_id, string search)
        {
            DataTable dt_tp = db.table("SELECT id, plan_main_id,procedure_name,procedure_id,cost from tbl_treatment_plan where pt_id='" + patient_id + "' and status='1' and procedure_name like'" + search + "%'");
            return dt_tp;
        }
        public DataTable search_procedures(string search)
        {
            DataTable dt_pt = db.table("SELECT id,name,cost FROM tbl_addproceduresettings where name like'" + search + "%' ORDER BY id");
            return dt_pt;
        }
        public void save_invoice_main(string patient_id, string name, string billno)
        {
            db.execute("insert into tbl_invoices_main (date,pt_id,pt_name,invoice,status,type) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + patient_id + "','" + name + "','" + billno + "','1','service')");
        }
        public string get_invoiceMain_maxid()
        {
            string dt1 = db.scalar("select MAX(id) from tbl_invoices_main");
            return dt1;
        }
        public void save_completedid(string date, string patient_id)
        {
            db.execute("insert into tbl_completed_id (completed_date,patient_id) values('" + date + "','" + patient_id + "')");
        }
        public string get_completed_procedure_maxid()
        {
            string dt_procedure = db.scalar("select MAX(id) from tbl_completed_procedures");
            return dt_procedure;
        }
        public void save_invoice_details(string invoice_no, string pt_name, string patient_id, string service_id, string services, string unit, string cost, string discount, string discount_type, string tax, string total, string notes, string total_discount, string total_tax, string dr_id, string discountin_rs, string tax_inrs, int invoice_main_id, int completed_id)
        {
            db.execute("insert into tbl_invoices(invoice_no,pt_name,pt_id,service_id,services,unit,cost,discount,discount_type,tax,total,date,notes,total_cost,total_discount,total_tax,grant_total,dr_id,discountin_rs,tax_inrs,total_payment,invoice_main_id,plan_id,completed_id) values('" + invoice_no + "','" + pt_name + "','" + patient_id + "','" + service_id + "','" + services + "','" + unit + "','" + cost + "','" + discount + "','" + discount_type + "','" + tax + "','" + total + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + notes + "','100','" + total_discount + "','" + total_tax + "','100','" + dr_id + "','" + discountin_rs + "','" + tax_inrs + "','100','" + invoice_main_id + "','0','" + completed_id + "')");
        }
        public void Save_tbl_completed_procedures(int plan_main_id, string patient_id, string procedure_id, string procedure_name, string quantity, string cost, string discount_type, string discount, string total, string discount_inrs, string note, string dr_id, string completed_id, string tooth)
        {
            db.execute("insert into tbl_completed_procedures (plan_main_id,pt_id,procedure_id,procedure_name,quantity,cost,discount_type,discount,total,discount_inrs,note,status,date,dr_id,completed_id,tooth) values ('" + plan_main_id + "','" + patient_id + "','" + procedure_id + "','" + procedure_name + "','" + quantity + "','" + cost + "','" + discount_type + "','" + discount + "','" + total + "','" + discount_inrs + "','" + note + "','0','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + dr_id + "','" + completed_id + "', '" + tooth + "')");
        }
        public void save_invoice_items(string invoice_no, string pt_name, string patient_id, string service_id, string services, string unit, string cost, string discount, string discount_type, string tax, string total, string notes, string total_discount, string total_tax, string dr_id, string discountin_rs, string tax_inrs, int invoice_main_id, string plan_id, int completed_id)
        {
            db.execute("insert into tbl_invoices(invoice_no,pt_name,pt_id,service_id,services,unit,cost,discount,discount_type,tax,total,date,notes,total_cost,total_discount,total_tax,grant_total,dr_id,discountin_rs,tax_inrs,total_payment,invoice_main_id,plan_id,completed_id) values('" + invoice_no + "','" + pt_name + "','" + patient_id + "','" + service_id + "','" + services + "','" + unit + "','" + cost + "','" + discount + "','" + discount_type + "','" + tax + "','" + total + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + notes + "','100','" + total_discount + "','" + total_tax + "','100','" + dr_id + "','" + discountin_rs + "','" + tax_inrs + "','100','" + invoice_main_id + "','" + plan_id + "','" + completed_id + "')");
        }
        public void Set_completed_status0(string id)
        {
            db.execute("update  tbl_completed_procedures set status='0' where id= '" + id + "'");
        }
        public void update_invoice_autoid(int a)
        {
            db.execute("update tbl_invoice_automaticid set invoice_number='" + a + "'");
        }
        public string Get_invoiceDate(string invno)
        {
            string dt0 = db.scalar("Select date from tbl_invoices where invoice_no='" + invno + "'");
            return dt0;
        }
        public void delete_invoice(string billno)
        {
            db.execute("delete from tbl_invoices where invoice_no='" + billno + "'");
        }
        public void save_incove_items(string invoice_no, string pt_name, string pt_id, string services, string unit, string cost, string discount, string discount_type, string tax, string total, string date, string notes, string total_cost, string total_discount, string total_tax, string grant_total, string dr_id, string discountin_rs, string tax_inrs, string total_payment)
        {
            db.execute("insert into tbl_invoices(invoice_no,pt_name,pt_id,services,unit,cost,discount,discount_type,tax,total,date,notes,total_cost,total_discount,total_tax,grant_total,dr_id,discountin_rs,tax_inrs,total_payment) values('" + invoice_no + "','" + pt_name + "','" + pt_id + "','" + services + "','" + unit + "','" + cost + "','" + discount + "','" + discount_type + "','" + tax + "','" + total + "','" + date + "','" + notes + "','" + total_cost + "','" + total_discount + "','" + total_tax + "','" + grant_total + "','" + dr_id + "','" + discountin_rs + "','" + tax_inrs + "','" + total_payment + "')");
        }
        public string select_taxValue(string name)
        {
            string dt = db.scalar("select tax_value from tbl_tax where id ='" + name + "'");
            return dt;
        }
        //invoice
        public string check_addprivillege(string doctor_id)
        {
            string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRI' and Permission='A'");
            return privid;
        }
        public string check_delete_privillege(string doctor_id)
        {
            string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRI' and Permission='D'");
            return privid;
        }
        public string addpayment_privillege(string doctor_id)
        {
            string privid = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='PMT' and Permission='A'");
            return privid;
        }
        public DataTable get_invoiceDetails(string mainid)
        {
            DataTable dt_pt_sub = db.table("SELECT id,services,unit,cost,discount,discount_type,tax,total,notes,total_cost,total_discount,total_tax,discountin_rs,tax_inrs,dr_id,invoice_no FROM tbl_invoices where invoice_main_id='" + mainid + "' ORDER BY id");
            return dt_pt_sub;
        }
        public string Get_type(string invoice_plan_id)
        {
            string invoice_type = db.scalar("SELECT type FROM tbl_invoices_main where id='" + invoice_plan_id + "' ");
            return invoice_type;
        }
        public DataTable InvoiceDetails(string invoice_plan_id)
        {
            DataTable dt_in_main = db.table("SELECT * FROM tbl_invoices where invoice_main_id='" + invoice_plan_id + "' ");
            return dt_in_main;
        }
        public void set_completeProcedure_status1(string completed_id)
        {
            db.execute("update tbl_completed_procedures set status='1' where id= '" + completed_id + "'");
        }
        public void delete_from_invoice(string invoice_plan_id)
        {
            db.execute("delete from tbl_invoices_main where id='" + invoice_plan_id + "'");
            db.execute("delete from tbl_invoices where invoice_main_id='" + invoice_plan_id + "'");
        }
        public string Get_paymentid(string invno)
        {
            string dt_pay = db.scalar("SELECT id FROM tbl_payment where invoice_no='" + invno + "' ");
            return dt_pay;
        }
        public DataTable Get_invoicePrintsettings()
        {
            DataTable print = db.table("select * from  tbl_invoice_printsettings");
            return print;
        }
        //public DataTable get_invoice_doctorname(string patient_id)
        //{
        //    DataTable dtb = Add_inv_model.get_invoice_doctorname(patient_id);
        //    return dtb;
        //}
        public DataTable Get_date(string invoice_plan_id)
        {
            DataTable dt_invo = db.table("SELECT invoice,date FROM tbl_invoices_main WHERE id = '" + invoice_plan_id + "'");
            return dt_invo;
        }
        public string Get_TotalSum(string invoice_plan_id)
        {
            string num = db.scalar("SELECT sum(total) FROM tbl_invoices WHERE invoice_main_id ='" + invoice_plan_id + "'");
            return num;
        }
    }
}