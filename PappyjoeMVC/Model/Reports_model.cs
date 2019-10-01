using System.Data;

namespace PappyjoeMVC.Model
{
    public class Reports_model
    {
        Connection db = new Connection();
        public string invoice_to_combo(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='RPTINC' and Permission='A'");
            return id;
        }
        public string reciept_combo(string doctor_id)
        {
            string s = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='RPTINCM' and Permission='A'");
            return s;
        }
        public string payment_combo(string doctor_id)
        {
            string s = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='RPTPAY' and Permission='A'");
            return s;
        }
        public string appoint_combo(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='RPTAPT' and Permission='A'");
            return id;
        }
        public string patient_combo(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='RPTPAT' and Permission='A'");
            return id;
        }
        public string emr_combo(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='RPTEMR' and Permission='A'");
            return id;
        }
        public string inventory_combo(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='RPTINV' and Permission='A'");
            return id;
        }
        //public DataTable docname(string doctor_id)  
        //{
        //    DataTable docnam = db.table("select doctor_name from tbl_doctor Where id='" + doctor_id + "'");
        //    return docnam;
        //}
        //public DataTable doc_combo()
        //{
        //    DataTable dt = db.table("select DISTINCT id,doctor_name from tbl_doctor  where login_type='doctor' or login_type='admin'  and activate_login='yes' order by doctor_name");
        //    return dt;
        //}
        public DataTable invoice_main(string date1, string date2)
        {
            DataTable invMain = db.table("select M.id,type from tbl_invoices_main M inner join tbl_patient P on P.id=M.pt_id  where M.date between '" + date1 + "' and '" + date2 + "'and P.Profile_Status!='Cancelled' order by M.date desc");
            return invMain;
        }
        public DataTable invoice(string invMain)
        {
            DataTable invoice = db.table("SELECT invoice_no, pt_name,cast(cost as decimal(17,2))*cast(unit as decimal(17,2)) as Cost,cast(total as decimal(17,2)) as total, date,completed_id,discountin_rs,Tax_inrs,d.doctor_name FROM  tbl_invoices inner join tbl_doctor d on tbl_invoices.dr_id=d.id  where tbl_invoices.invoice_main_id='" + invMain + "'");
            return invoice;
        }

        public DataTable dr_invoice(string invoice, string dr_id)
        {
            DataTable dr_invoice = db.table("SELECT id FROM  tbl_completed_procedures where id='" + invoice + "' and dr_id='" + dr_id + "'");
            return dr_invoice;
        }
        public DataTable reciept(string date1, string date2)
        {
            DataTable invMain = db.table("select M.id,type from tbl_invoices_main M inner join tbl_patient P on P.id=M.pt_id  where M.date between '" + date1 + "' and '" + date2 + "'and P.Profile_Status!='Cancelled' order by M.date desc");
            return invMain;
        }
        public DataTable reciept_invoice(string invMain)
        {
            DataTable invoice = db.table("SELECT invoice_no, pt_name,cast(cost as decimal(17,2))*cast(unit as decimal(17,2)) as Cost,cast(total as decimal(17,2)) as total, date,discountin_rs,Tax_inrs FROM  tbl_invoices where tbl_invoices.invoice_main_id='" + invMain + "'");
            return invoice;
        }
        public DataTable patient_reciept(string date1, string date2)
        {
            DataTable dt = db.table("SELECT tbl_payment.pt_name as 'PATIENT NAME',receipt_no as 'RECEIPT NO',invoice_no as 'INVOICE NO',procedure_name as 'TREATMENT',CAST(amount_paid as decimal(17,2)) as 'AMOUNT PAID',payment_date as 'PAYMENT DATE',CAST((total-amount_paid) AS DECIMAL(17,2)) as 'DUE AFTER PAYMENT',tbl_payment.dr_id ,d.doctor_name FROM tbl_payment inner join tbl_doctor d on tbl_payment.dr_id=d.id   inner join tbl_patient P on P.id= tbl_payment.pt_id where payment_date between '" + date1 + "' and '" + date2 + "' and p.Profile_Status!='Cancelled' order by tbl_payment.id desc");
            return dt;
        }
        public DataTable Appointment_invMain(string date1, string date2)
        {
            System.Data.DataTable invMain = db.table("select  A.id from tbl_appointment A inner join tbl_patient P on P.id=A.pt_id  where start_datetime between '" + date1 + " 00:01:00" + "' and '" + date2 + " 23:59:00" + "' and P.Profile_Status!='Cancelled' order by start_datetime desc");
            return invMain;
        }
        public DataTable Appointment_grvShow(string date1, string date2)
        {
            System.Data.DataTable dt_pt = db.table("SELECT  DISTINCT (tbl_appointment.pt_id) AS ID, tbl_patient.pt_id as 'PATIENT ID',tbl_patient.pt_name as 'PATIENT NAME', tbl_patient.primary_mobile_number as MOBILE,tbl_appointment.start_datetime as 'BOOK TIME',d.doctor_name,dr_id  FROM  tbl_appointment LEFT JOIN tbl_patient on tbl_appointment.pt_id=tbl_patient.ID left join tbl_doctor d on tbl_appointment.dr_id=d.id where tbl_appointment.start_datetime between '" + date1 + " 00:01:00" + "' and '" + date2 + " 23:59:00" + "' order by tbl_appointment.start_datetime desc ");
            return dt_pt;
        }
        public DataTable Patient_invMain(string date1, string date2)
        {
            System.Data.DataTable invMain = db.table("select id from tbl_patient where date between '" + date1 + "' and '" + date2 + "' and Profile_Status!='Cancelled' order by date desc");
            return invMain;
        }
        public DataTable Patient_grvShow(string date1, string date2)
        {
            DataTable dt = db.table("SELECT  id,pt_id as 'PATIENT ID',pt_name as 'PATIENT NAME',gender as 'GENDER',Age, primary_mobile_number as 'MOBILE',date as 'DATE',street_address FROM  tbl_patient where date between '" + date1 + "' and '" + date2 + "' and Profile_Status!='Cancelled' order by date desc");
            return dt;
        }
        public DataTable EMR_invMain(string date1, string date2)
        {
            System.Data.DataTable invMain = db.table("select M.id from tbl_invoices M  inner join tbl_patient P on P.id= M.pt_id where M.date between '" + date1 + "' and '" + date2 + "'and p.Profile_Status!='Cancelled' order by M.date desc");
            return invMain;
        }
        public DataTable EMR_grvShow(string date1, string date2)
        {
            DataTable dt = db.table("SELECT M.id,P.pt_id as 'PATIENT ID',M.pt_name as 'PATIENT NAME',services as 'SERVICES',M.date as 'DATE' FROM  tbl_invoices M inner join tbl_patient P on P.id= M.pt_id  where M.date between '" + date1 + "' and '" + date2 + "'and p.Profile_Status!='Cancelled' order by M.date desc");
            return dt;
        }
        public DataTable expence_checked(string date1, string date2, string type)
        {
            DataTable dt = new DataTable();
            if (type == "Expense")
            {
                dt = db.table("select id,date,Type,nameofperson,expense_type,cast(amount as decimal(17,2)) as 'amount',cast(amountincome as decimal(17,2)) as amountincome ,description from tbl_expense where date between '" + date1 + "' and '" + date2 + "' and Type='Expense' order by date desc");
            }
            else
            {
                dt = db.table("select id,date,Type,nameofperson,expense_type,cast(amount as decimal(17,2)) as 'amount',cast(amountincome as decimal(17,2)) as amountincome ,description from tbl_expense where date between '" + date1 + "' and '" + date2 + "' and Type='Income' order by date desc");

            }
            return dt;
        }
        public DataTable expence_income_notChecked(string date1, string date2)
        {
            DataTable dt = db.table("select id,date,Type,nameofperson,expense_type,cast(amount as decimal(17,2)) as 'amount',cast(amountincome as decimal(17,2)) as amountincome ,description from tbl_expense where date between '" + date1 + "' and '" + date2 + "' order by date desc");
            return dt;

        }
        public DataTable Inventory_dt_stock()
        {
            System.Data.DataTable dt_stock = db.table("  select item_code,(select item_name from tbl_ITEMS where id=B.Item_Code ) item_name , (select Unit1 from tbl_ITEMS where id=B.Item_Code ) unit,(select sum( qty) from tbl_batchnumber where Item_Code=B.Item_Code) qty  from tbl_batchnumber B group by item_code order by B.item_code ");
            return dt_stock;
        }
        public DataTable Inventory_gvShow(string dr)
        {
            System.Data.DataTable dtunit = db.table(" select OneUnitOnly,UnitMF,Unit1,Unit2 from tbl_ITEMS where id='" + dr + "'");
            return dtunit;
        }
        public DataTable GetDoctorId_byLogintype(string drid)
        {
            DataTable dt = db.table("SELECT id from tbl_doctor where doctor_name='" + drid + "' and login_type='doctor'");
            return dt;
        }
        //Expiry Report
        public DataTable datewiseexpiry(string dateFrom,string dateTo)
        {
            DataTable dt = db.table("select b.Item_Code,i.item_name,b.PurchNumber,b.PurchDate,b.BatchNumber,b.Qty,b.ExpDate,(select s.Supplier_Name from tbl_Supplier S where S.Supplier_Code=b.Sup_Code) Supplier_Name  from tbl_batchNumber b left join tbl_items i on i.item_code=b.Item_Code  where b.IsExpDate='Yes' and b.ExpDate between '" + dateFrom + "' and '" + dateTo + "'");
            return dt;
        }
    }
}
