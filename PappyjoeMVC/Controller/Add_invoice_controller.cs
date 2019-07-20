using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
    public class Add_invoice_controller
    {
        Add_invoice_interface intr;
        Connection db = new Connection();
        Add_invoice_model _model = new Add_invoice_model();
        addfinsed_treatment_model fmodel = new addfinsed_treatment_model();
        common_model cmodel = new common_model();
        public Add_invoice_controller(Add_invoice_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public DataTable get_adminid()
        {
            DataTable admin = db.table("select id from tbl_doctor where login_type='admin'");
            return admin;
        }
        public DataTable Get_invoice_prefix()
        {
            DataTable invno = db.table("select invoice_prefix,invoice_number,invoive_automation from tbl_invoice_automaticid where invoive_automation='Yes'");
            return invno;
        }
        public DataTable load_tax()
        {
            DataTable dtb = _model.load_tax();
            return dtb;
        }
        public void get_completed_procedure_details(string patient_id)
        {
            DataTable dtb = _model.get_completed_procedure_details(patient_id);
            intr.Load_procedureGrid(dtb);
        }
        public void get_planed_procedure(string patient_id)
        {
            DataTable dtb = _model.get_planed_procedure(patient_id);
            intr.Load_planed_procedure(dtb);
        }
        public void Get_invoice_deatils(string ptid, string invoiceid)
        {
            DataTable dtb = _model.Get_invoice_deatils(ptid,invoiceid);
            intr.load_invoice_details(dtb);
        }
        public DataTable load_completed_procedure(string id)
        {
            DataTable dtb = _model.load_completed_procedure(id);
            return dtb;
        }
        public void search_procedure_completed(string patient_id,string search)
        {
            DataTable dt_tp1 = db.table("SELECT id, procedure_name,procedure_id,cost from tbl_completed_procedures where pt_id='" + patient_id + "' and status='1' and procedure_name like'" + search + "%'");
            intr.Load_procedureGrid(dt_tp1);
        }
        public void Search_procedure_planed(string patient_id, string search)
        {
            DataTable dt_tp = db.table("SELECT id, plan_main_id,procedure_name,procedure_id,cost from tbl_treatment_plan where pt_id='" + patient_id + "' and status='1' and procedure_name like'" + search + "%'");
            intr.Load_planed_procedure(dt_tp);
        }
        public void search_procedures(string search)
        {
            DataTable dt_pt = db.table("SELECT id,name,cost FROM tbl_addproceduresettings where name like'" + search + "%' ORDER BY id");
            intr.Load_searchProcedures(dt_pt);
        }
        public void load_AllProcedures()
        {
            DataTable dtb= fmodel.load_proceduresgrid();
            intr.Load_searchProcedures(dtb);
        }
        public DataTable get_procedure_Name(string id)
        {
            DataTable dtb = fmodel.get_procedure_Name(id);
            return dtb;
        }
        public void Get_treatment_details(string plan_p_id)
        {
            DataTable dtb = fmodel.Get_treatment_details(plan_p_id);
            intr.Fill_Alltreatment_deatils(dtb);
        }
        public void Get_completed_table_details(string P_Completed_id)
        {
            DataTable dtb = _model.Get_completed_table_details(P_Completed_id);
            intr.Fill_Alltreatment_deatils(dtb);
        }
        public DataTable Get_quantiry_fromStock(string stock_id)
        {
            DataTable testQty = _model.Get_quantiry_fromStock(stock_id);

            return testQty;
        }
        public DataTable select_All_invoicedata(string billno)
        {
            DataTable dtb = _model.select_All_invoicedata(billno);
            return dtb;
        }
        public void save_invoice_main(string patient_id,string name,string billno)
        {
          db.execute("insert into tbl_invoices_main (date,pt_id,pt_name,invoice,status,type) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + patient_id + "','" + name + "','" + billno + "','1','service')");
        }
        public DataTable get_invoiceMain_maxid()
        {
            DataTable dt1 = db.table("select MAX(id) from tbl_invoices_main");
            return dt1;
        }
        public void save_completedid(string date,string patient_id)
        {
          db.execute("insert into tbl_completed_id (completed_date,patient_id) values('" + date + "','" + patient_id + "')");
        }
        public DataTable get_completed_procedure_maxid()
        {
            DataTable dt_procedure = db.table("select MAX(id) from tbl_completed_procedures");
            return dt_procedure;
        }
        public void save_invoice_details(string invoice_no,string pt_name, string patient_id,string service_id,string services,string unit,string cost,string discount,string discount_type,string tax,string total, string notes, string total_discount,string total_tax,string dr_id,string discountin_rs,string tax_inrs,int invoice_main_id, int completed_id)
        {
            db.execute("insert into tbl_invoices(invoice_no,pt_name,pt_id,service_id,services,unit,cost,discount,discount_type,tax,total,date,notes,total_cost,total_discount,total_tax,grant_total,dr_id,discountin_rs,tax_inrs,total_payment,invoice_main_id,plan_id,completed_id) values('" + invoice_no + "','" + pt_name + "','" + patient_id + "','" + service_id + "','" + services + "','" + unit + "','" + cost + "','" + discount + "','" + discount_type + "','" + tax + "','" + total + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + notes + "','100','" + total_discount + "','" + total_tax + "','100','" + dr_id + "','" + discountin_rs + "','" + tax_inrs + "','100','" + invoice_main_id + "','0','" + completed_id + "')");
        }
        public void Save_tbl_completed_procedures(int plan_main_id, string patient_id, string procedure_id, string procedure_name, string quantity, string cost, string discount_type, string discount, string total, string discount_inrs, string note, string dr_id,string completed_id, string tooth)
        {
           db.execute("insert into tbl_completed_procedures (plan_main_id,pt_id,procedure_id,procedure_name,quantity,cost,discount_type,discount,total,discount_inrs,note,status,date,dr_id,completed_id,tooth) values ('" + plan_main_id + "','" + patient_id + "','" + procedure_id + "','" + procedure_name + "','" + quantity + "','" + cost + "','" + discount_type + "','" + discount + "','" + total + "','" + discount_inrs + "','" + note + "','0','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + dr_id + "','"+ completed_id+"', '" + tooth + "')");
        }
        public void save_invoice_items(string invoice_no,string pt_name,string patient_id, string service_id,string services,string unit,string cost,string discount,string discount_type,string tax,string total,string notes, string total_discount,string total_tax,string dr_id,string discountin_rs,string tax_inrs,int  invoice_main_id,string plan_id,int completed_id)
        {
            db.execute("insert into tbl_invoices(invoice_no,pt_name,pt_id,service_id,services,unit,cost,discount,discount_type,tax,total,date,notes,total_cost,total_discount,total_tax,grant_total,dr_id,discountin_rs,tax_inrs,total_payment,invoice_main_id,plan_id,completed_id) values('" + invoice_no + "','" + pt_name + "','" + patient_id + "','" + service_id + "','" + services + "','" + unit + "','" + cost + "','" + discount + "','" + discount_type + "','" + tax + "','" + total + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + notes + "','100','" + total_discount + "','" + total_tax + "','100','" + dr_id + "','" + discountin_rs + "','" + tax_inrs + "','100','" + invoice_main_id + "','" + plan_id + "','" + completed_id + "')");
        }
        public void Set_completed_status0(string id)
        {
          db.execute("update  tbl_completed_procedures set status='0' where id= '" +id + "'");
        }
        public void update_invoice_autoid(int a)
        {
            db.execute("update tbl_invoice_automaticid set invoice_number='" + a + "'");
        }
        public DataTable Get_invoiceDate(string invno)
        {
            DataTable dt0 = db.table("Select date from tbl_invoices where invoice_no='" + invno + "'");
            return dt0;
        }
        public void delete_invoice(string billno)
        {
            db.execute("delete from tbl_invoices where invoice_no='" + billno + "'");
        }
        public DataTable  get_taxValue(string name)
        {
            DataTable dtb = _model.get_taxValue(name);
            return dtb;
        }
        public void save_incove_items(string invoice_no,string pt_name,string pt_id, string services, string unit, string cost, string discount, string discount_type, string tax, string total, string date, string notes, string total_cost, string total_discount, string total_tax, string grant_total, string dr_id, string discountin_rs, string tax_inrs, string total_payment)
        {
          db.execute("insert into tbl_invoices(invoice_no,pt_name,pt_id,services,unit,cost,discount,discount_type,tax,total,date,notes,total_cost,total_discount,total_tax,grant_total,dr_id,discountin_rs,tax_inrs,total_payment) values('" + invoice_no + "','" + pt_name + "','" + pt_id + "','" + services + "','" + unit + "','" + cost + "','" + discount + "','" + discount_type + "','" + tax + "','" + total + "','" + date + "','" + notes + "','" + total_cost + "','" + total_discount + "','" + total_tax + "','" + grant_total + "','" + dr_id + "','" + discountin_rs + "','" + tax_inrs + "','" + total_payment + "')");
        }
        public DataTable select_taxValue(string name)
        {
            DataTable dt = db.table("select tax_value from tbl_tax where id ='" + name + "'");
            return dt;
        }
        public DataTable Patient_search(string patid)
        {
            DataTable dtb = cmodel.Patient_search(patid);
            return dtb;
        }
        public string permission_for_settings(string doctor_id)
        {
            string dtb = cmodel.permission_for_settings(doctor_id);
            return dtb;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string dtb = cmodel.doctr_privillage_for_addnewPatient(doctor_id);
            return dtb;
        }
    }
}
