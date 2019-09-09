using System;
using System.Data;

namespace PappyjoeMVC.Model
{
    public class Daily_Invoice_Report_model
    {
        Connection db = new Connection();
        public DataTable getdocname()
        {
            DataTable dt = db.table("select DISTINCT id,doctor_name from tbl_doctor where not login_type = 'staff' and activate_login='yes' order by doctor_name");
            return dt;
        }
        public DataTable practicedetails()
        {
            DataTable dt = db.table("select name,contact_no,street_address,email,website  from tbl_practice_details");
            return dt;
        }
        public DataTable getinvoice(string invdate)
        {
            DataTable dt = db.table("select tbl_invoices.pt_name,tbl_invoices.date,invoice_no,services,cost,unit,discount_type,discountin_rs,tax_inrs,tbl_doctor.doctor_name from tbl_invoices LEFT JOIN tbl_patient on tbl_invoices.pt_id=tbl_patient.id LEFT JOIN tbl_doctor on tbl_invoices.dr_id=tbl_doctor.id where tbl_patient.Profile_Status='Active' and tbl_invoices.date='" + Convert.ToDateTime(invdate).ToString("yyyy-MM-dd") + "' order by date desc");
            return dt;
        }
        public DataTable getinvoice2(string invdate, string doctrid)
        {
            DataTable dt = db.table("select tbl_invoices.pt_name,tbl_invoices.date,invoice_no,services,cost,unit,discount_type,discountin_rs,tax_inrs,tbl_doctor.doctor_name from tbl_invoices  LEFT JOIN tbl_patient on tbl_invoices.pt_id=tbl_patient.id LEFT JOIN tbl_doctor on tbl_invoices.dr_id=tbl_doctor.id where tbl_patient.Profile_Status='Active' and tbl_invoices.date ='" + Convert.ToDateTime(invdate).ToString("yyyy-MM-dd") + "' and dr_id='" + doctrid + "' order by date desc");
            return dt;
        }
        public DataTable getpay(string invdate)
        {
            DataTable dt = db.table("select  tbl_payment.receipt_no,tbl_payment.total,tbl_payment.payment_date,tbl_payment.procedure_name,tbl_payment.invoice_no,tbl_payment.amount_paid,tbl_patient.pt_name,tbl_patient.pt_id,tbl_doctor.doctor_name from tbl_payment LEFT JOIN tbl_patient on tbl_payment.pt_id=tbl_patient.id LEFT JOIN tbl_doctor on tbl_payment.dr_id=tbl_doctor.id where tbl_patient.Profile_Status='Active' and tbl_payment.payment_date='" + Convert.ToDateTime(invdate).ToString("yyyy-MM-dd") + "' order by tbl_payment.payment_date desc");
            return dt;
        }
        public DataTable getpay2(string invdate, string doctrid)
        {
            DataTable dt = db.table("select  tbl_payment.receipt_no,tbl_payment.total,tbl_payment.payment_date,tbl_payment.procedure_name,tbl_payment.invoice_no,tbl_payment.amount_paid,tbl_patient.pt_name,tbl_patient.pt_id,tbl_doctor.doctor_name from tbl_payment LEFT JOIN tbl_patient on tbl_payment.pt_id=tbl_patient.id LEFT JOIN tbl_doctor on tbl_payment.dr_id=tbl_doctor.id where tbl_patient.Profile_Status='Active' and tbl_payment.payment_date = '" + Convert.ToDateTime(invdate).ToString("yyyy-MM-dd") + "' and tbl_payment.dr_id='" + doctrid + "' order by tbl_payment.payment_date desc");
            return dt;
        }
        //Monthly Invoice Report
        public DataTable getdata(string invdate, string invdate2, int dr_id)
        {
            DataTable dt = db.table("select tbl_invoices.pt_id,tbl_invoices.pt_name,invoice_no,services,unit,discount_type,tbl_invoices.date,tbl_doctor.doctor_name,total_discount,((cast(cost as decimal(17,1))* cast(unit as decimal(17,1)))+(CAST(total_tax as decimal(17,1)))-(CAST(total_discount as decimal(17,1))) ) as Cost,cost as Total_Cost,(((cast(cost as decimal(17,1))* cast(unit as decimal(17,1)))+(CAST(total_tax as decimal(17,1)))-(CAST(total_discount as decimal(17,1))))-(CAST(total as decimal(17,1))) ) as Payment,cast(total as decimal(17,1)) as due from tbl_invoices LEFT JOIN tbl_doctor on tbl_invoices.dr_id=tbl_doctor.id LEFT JOIN tbl_patient on tbl_invoices.pt_id=tbl_patient.id where  tbl_patient.Profile_Status='Active' and tbl_invoices.date between '" + Convert.ToDateTime(invdate).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(invdate2).ToString("yyyy-MM-dd") + "'and dr_id='" + dr_id + "' order by date desc");
            return dt;
        }
        public DataTable getdata2(string invdate, string invdate2)
        {
            DataTable dt = db.table("select tbl_invoices.pt_id,tbl_invoices.pt_name,invoice_no,services,unit,discount_type,tbl_invoices.date,tbl_doctor.doctor_name,total_discount,((cast(cost as decimal(17,1))* cast(unit as decimal(17,1)))+(CAST(total_tax as decimal(17,1)))-(CAST(total_discount as decimal(17,1))) ) as Cost,cost as Total_Cost,(((cast(cost as decimal(17,1))* cast(unit as decimal(17,1)))+(CAST(total_tax as decimal(17,1)))-(CAST(total_discount as decimal(17,1))))-(CAST(total as decimal(17,1))) ) as Payment,cast(total as decimal(17,1)) as due from tbl_invoices LEFT JOIN tbl_doctor on tbl_invoices.dr_id=tbl_doctor.id LEFT JOIN tbl_patient on tbl_invoices.pt_id=tbl_patient.id where  tbl_patient.Profile_Status='Active' and tbl_invoices.date between '" + Convert.ToDateTime(invdate).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(invdate2).ToString("yyyy-MM-dd") + "' order by date desc");
            return dt;
        }
        //Doctor-Wise Invoice Report
        public DataTable getdata3(string invdate, string invdate2, int dr_id)
        {
            DataTable dt = db.table("select A.id,A.pt_id,A.pt_name,A.invoice_no,A.services,A.date,((cast(cost as decimal(17,1))* cast(unit as decimal(17,1)))+(CAST(total_tax as decimal(17,1)))-(CAST(total_discount as decimal(17,1))) ) as 'Cost',cost as 'Total_Cost',(((cast(cost as decimal(17,1))* cast(unit as decimal(17,1)))+(CAST(total_tax as decimal(17,1)))-(CAST(total_discount as decimal(17,1))))-(CAST(total as decimal(17,1))) ) as 'Payment',cast(total as decimal(17,1)) as 'due',B.doctor_name from tbl_invoices  A left join tbl_doctor B on A.dr_id=B.id  LEFT JOIN tbl_patient C on A.pt_id=C.id  where  C.Profile_Status='Active' and A.date between '" + Convert.ToDateTime(invdate).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(invdate2).ToString("yyyy-MM-dd") + "' and dr_id='" + dr_id + "'");
            return dt;
        }
        public DataTable getdata4(string invdate, string invdate2)
        {
            DataTable dt = db.table("select A.id,A.pt_id,A.pt_name,A.invoice_no,A.services,A.date,((cast(cost as decimal(17,1))* cast(unit as decimal(17,1)))+(CAST(total_tax as decimal(17,1)))-(CAST(total_discount as decimal(17,1))) ) as 'Cost',cost as 'Total_Cost',(((cast(cost as decimal(17,1))* cast(unit as decimal(17,1)))+(CAST(total_tax as decimal(17,1)))-(CAST(total_discount as decimal(17,1))))-(CAST(total as decimal(17,1))) ) as 'Payment',cast(total as decimal(17,1)) as 'due',B.doctor_name from tbl_invoices A left join tbl_doctor B on A.dr_id=B.id  LEFT JOIN tbl_patient C on A.pt_id=C.id  where C.Profile_Status='Active' and A.date between '" + Convert.ToDateTime(invdate).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(invdate2).ToString("yyyy-MM-dd") + "'");
            return dt;
        }
        //Day-Wise Receipt
        public DataTable getinvdata(string invno, string service)
        {
            DataTable dt = db.table("SELECT distinct CAST((C.unit*C.cost) AS DECIMAL(17,2)) as 'Total Cost',c.unit,c.discount_type,C.discountin_rs,C.tax_inrs ,CAST(((C.unit*C.cost)-C.discountin_rs) AS DECIMAL(17,2)) as 'Total Income' FROM  tbl_invoices C Where invoice_no='" + invno + "' and  C.services='" + service + "'");
            return dt;
        }
        public DataTable ReceiptReceivedPerDay(string d1, string d2)
        {
            DataTable dfd = db.table("select distinct A.pt_name,receipt_no ,procedure_name,A.invoice_no ,A.total ,A.amount_paid,CAST((A.total-amount_paid) AS DECIMAL(17,2))  as 'Total Amount Due',d.doctor_name,A.mode_of_payment,A.dr_id,payment_date  from  tbl_payment A left join tbl_doctor d on A.dr_id=d.id inner join tbl_patient P on p.id=A.pt_id  where payment_date between '" + d1 + "' and '" + d2 + "'and P.Profile_Status !='Cancelled' ");
            return dfd;
        }
        public DataTable ReceiptReceivedPerDay_DoctrWise(string d1, string d2, string dr)
        {
            DataTable dfd = db.table("select distinct A.pt_name,receipt_no,procedure_name,A.invoice_no ,A.total ,A.amount_paid,CAST((A.total-amount_paid) AS DECIMAL(17,2))  as 'Total Amount Due',d.doctor_name,A.mode_of_payment,A.dr_id,payment_date   from  tbl_payment A left join tbl_doctor d on A.dr_id=d.id inner join tbl_patient P on p.id=A.pt_id   where payment_date between '" + d1 + "' and '" + d2 + "' and doctor_name='" + dr + "' and P.Profile_Status !='Cancelled'");
            return dfd;
        }
        //Month-Wise Receipt
        public DataTable mnthrcpt(string rcdte, string rcdte2)
        {
            DataTable dt = db.table("SELECT distinct  A.pt_name,receipt_no ,A.invoice_no ,procedure_name, A.total ,A.amount_paid ,CAST((A.total-amount_paid) AS DECIMAL(17,2))  as 'DUE AFTER PAYMENT',payment_date, A.mode_of_payment ,d.doctor_name FROM tbl_payment A Left join tbl_doctor d on A.dr_id=d.id inner join tbl_patient P on p.id=A.pt_id Where payment_date between '" + rcdte + "' and '" + rcdte2 + "' and P.Profile_Status !='Cancelled' ");
            return dt;
        }
        public DataTable mnthrcpt2(string rcdte, string rcdte2, string dr_id)
        {
            DataTable dt = db.table("SELECT distinct  A.pt_name,receipt_no ,A.invoice_no ,procedure_name, A.total ,A.amount_paid ,CAST((A.total-amount_paid) AS DECIMAL(17,2))  as 'DUE AFTER PAYMENT',payment_date, A.mode_of_payment ,d.doctor_name FROM tbl_payment A Left join tbl_doctor d on A.dr_id=d.id inner join tbl_patient P on p.id=A.pt_id  Where payment_date between '" + rcdte + "' and '" + rcdte2 + "'and A.dr_id='" + dr_id + "' and P.Profile_Status !='Cancelled'");
            return dt;
        }
        //Doctor-Wise Receipt
        public string getdocid(string drname)
        {
            string e = db.scalar("Select id from tbl_doctor where doctor_name='" + drname + "' and login_type='doctor'");
            return e;
        }
        //paymode wise receipt report
        public DataTable ReceiptReceivedModeofPayment_Both(string d1, string d2, string dr, string mode)
        {
            DataTable dtb = db.table("select distinct A.pt_name,receipt_no ,procedure_name,A.invoice_no ,A.total ,A.amount_paid,A.BankName,A.Number,A.CardNo,A.fourDigitNo,A.DDNumber ,CAST((A.total-amount_paid) AS DECIMAL(17,2))  as 'Total Amount Due',d.doctor_name,A.mode_of_payment,A.dr_id,payment_date from  tbl_payment A left join tbl_doctor d on A.dr_id=d.id inner join tbl_patient P on p.id=A.pt_id  where payment_date between '" + d1 + "' and '" + d2 + "' and doctor_name='" + dr + "' and  A.mode_of_payment='" + mode + "' and P.Profile_Status !='Cancelled' ");
            return dtb;
        }
        public DataTable ReceiptReceivedModeofPayment(string d1, string d2)
        {
            DataTable dfd = db.table("select distinct A.pt_name,receipt_no ,procedure_name,A.invoice_no ,A.total ,A.amount_paid,A.BankName,A.Number,A.CardNo,A.fourDigitNo,A.DDNumber ,CAST((A.total-amount_paid) AS DECIMAL(17,2))  as 'Total Amount Due',d.doctor_name,A.mode_of_payment,A.dr_id,payment_date from  tbl_payment A left join tbl_doctor d on A.dr_id=d.id inner join tbl_patient P on p.id=A.pt_id  where payment_date between '" + d1 + "' and '" + d2 + "'and P.Profile_Status !='Cancelled' ");
            return dfd;
        }
        public DataTable ReceiptReceivedModeofPayment_Mode(string d1, string d2, string mode)
        {
            DataTable dfd = db.table("select distinct A.pt_name,receipt_no ,procedure_name,A.invoice_no ,A.total ,A.amount_paid,A.BankName,A.Number,A.CardNo,A.fourDigitNo,A.DDNumber ,CAST((A.total-amount_paid) AS DECIMAL(17,2))  as 'Total Amount Due',d.doctor_name,A.mode_of_payment,A.dr_id,payment_date from  tbl_payment A left join tbl_doctor d on A.dr_id=d.id  inner join tbl_patient P on p.id=A.pt_id  where payment_date between '" + d1 + "' and '" + d2 + "'  and  A.mode_of_payment='" + mode + "'  and P.Profile_Status !='Cancelled' ");
            return dfd;
        }
        public DataTable ReceiptReceivedModeofPayment_Doctor(string d1, string d2, string dr)
        {
            DataTable dfd = db.table("select distinct A.pt_name,receipt_no ,procedure_name,A.invoice_no ,A.total ,A.amount_paid,A.BankName,A.Number,A.CardNo,A.fourDigitNo,A.DDNumber ,CAST((A.total-amount_paid) AS DECIMAL(17,2))  as 'Total Amount Due',d.doctor_name,A.mode_of_payment,A.dr_id,payment_date from  tbl_payment A left join tbl_doctor d on A.dr_id=d.id inner join tbl_patient P on p.id=A.pt_id  where payment_date between '" + d1 + "' and '" + d2 + "' and doctor_name='" + dr + "'  and P.Profile_Status !='Cancelled'");
            return dfd;
        }
    }
}
