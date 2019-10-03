using System.Data;

namespace PappyjoeMVC.Model
{
    public class Patients_Report_model
    {
        Connection db = new Connection();
        public DataTable doctor_rs()
        {
            DataTable doctor_rs = db.table("select DISTINCT id,doctor_name from tbl_doctor where not login_type = 'staff' order by doctor_name");
            return doctor_rs;
        }
        public DataTable DailyNewPatient(string d1, string d2, string doctor)
        {
            string query;
            if (doctor != "All Doctor")
            {
                query = "select date_format(date,'%b%Y') as 'MONTH',COUNT(*) AS TOTAL from tbl_patient where doctorname='" + doctor + "' and date between '" + d1 + "' and '" + d2 + "' and Profile_Status ='Active' group by date_format(date,'%b%Y') ";
            }
            else
            {
                query = "select date_format(date,'%b%Y') as 'MONTH',COUNT(*) AS TOTAL from tbl_patient where date between '" + d1 + "' and '" + d2 + "' and Profile_Status ='Active' group by date_format(date,'%b%Y') ";
            }
            DataTable dfd = db.table(query);
            return dfd;
        }
        public DataTable Dailynewpatient(string d1, string d2, string doctor)
        {
            string query;
            if (doctor != "All Doctor")
            {
                query = "SELECT date As DATE,COUNT(*) As COUNT  FROM tbl_patient where doctorname='" + doctor + "' and date between '" + d1 + "' and '" + d2 + "' and Profile_Status ='Active' group by  date";
            }
            else
            {
                query = "SELECT date As DATE,COUNT(*) As COUNT  FROM tbl_patient where date between '" + d1 + "' and '" + d2 + "' and Profile_Status ='Active' group by  date";
            }
            DataTable dfd = db.table(query);
            return dfd;
        }
        public DataTable griddailytrreatmenttable(string doctor, string date1, string date2)
        {
            DataTable griddailytrreatmenttable = db.table("select DATE_FORMAT(date, '%d-%m-%Y') AS  'date' ,pt_id,pt_name,primary_mobile_number,email_address,doctorname from tbl_patient  WHERE tbl_patient.Profile_Status='Active' and doctorname='" + doctor + "' and date  between '" + date1 + "' and '" + date2 + "' GROUP BY id,pt_id,pt_name,date,primary_mobile_number,email_address,doctorname  having COUNT(pt_id)=1 ");
            return griddailytrreatmenttable;
        }
        public DataTable griddailytrreatmenttable11(string date1, string date2)
        {
            DataTable griddailytrreatmenttable = db.table("select DATE_FORMAT(date, '%d-%m-%Y') AS  'date',pt_id,pt_name,primary_mobile_number,email_address,doctorname from tbl_patient  WHERE tbl_patient.Profile_Status='Active' and date  between '" + date1 + "' and '" + date2 + "' GROUP BY id,pt_id,pt_name,date,primary_mobile_number,email_address,doctorname  having COUNT(pt_id)=1 ");
            return griddailytrreatmenttable;
        }
        public DataTable FirstAppointment(string dr_id, string d9, string d10)
        {
            string query;
            if (dr_id != "0")
            {
                query = "select p.pt_name AS 'PATIENT NAME',s.book_datetime AS 'BOOKING DATE' from tbl_appointment p inner join(select pt_id,book_datetime,pt_name from tbl_appointment) s on s.pt_name=p.pt_name where dr_id='" + dr_id + "' and s.book_datetime between '" + d9 + "' and '" + d10 + "' group by p.pt_name,s.book_datetime having COUNT(*)=1 ";
            }
            else
            {
                query = "select p.pt_name AS 'PATIENT NAME',s.book_datetime AS 'BOOKING DATE' from tbl_appointment p inner join(select pt_id,book_datetime,pt_name from tbl_appointment) s on s.pt_name=p.pt_name where s.book_datetime between '" + d9 + "' and '" + d10 + "' group by p.pt_name,s.book_datetime having COUNT(*)=1 ";
            }

            DataTable dfd = db.table(query);
            return dfd;
        }
        public DataTable MonthlyNewPatient(string d11, string d22, string doctor_id)
        {
            string query;
            if (doctor_id == "All Doctor")
            {
                query = "select date_format(date,'%b%Y') as 'MONTH',COUNT(*) AS TOTAL from tbl_patient where date >= '" + d11 + "' and date<= '" + d22 + "' and Profile_Status='Active' group by date_format(date,'%b%Y') ";
            }
            else
            {
                query = "select date_format(date,'%b%Y') as 'MONTH',COUNT(*) AS TOTAL from tbl_patient where doctorname='" + doctor_id + "' and date >= '" + d11 + "' and date<= '" + d22 + "' and Profile_Status='Active' group by date_format(date,'%b%Y') ";
            }
            DataTable dfd = db.table(query);
            return dfd;
        }
        public DataTable grdDailytrtmentTable(string doctor, string date1, string date2)
        {
            DataTable griddailytrreatmenttable = db.table("select  DATE_FORMAT(date, '%d-%m-%Y') AS  'date',pt_id,pt_name,primary_mobile_number,email_address,doctorname from tbl_patient  WHERE Profile_Status='Active' and  doctorname='" + doctor + "' and date  between '" + date1 + "' and '" + date2 + "' GROUP BY id,pt_id,pt_name,date,primary_mobile_number,email_address,doctorname  having COUNT(pt_id)=1 ");
            return griddailytrreatmenttable;
        }
        public DataTable grdDailyTtrtmn1TB(string date1, string date2)
        {
            DataTable griddailytrreatmenttable = db.table("select DATE_FORMAT(date, '%d-%m-%Y') AS  'date',pt_id,pt_name,primary_mobile_number,email_address,doctorname from tbl_patient  WHERE Profile_Status='Active' and  date  between '" + date1 + "' and '" + date2 + "' GROUP BY id,pt_id,pt_name,date,primary_mobile_number,email_address,doctorname  having COUNT(pt_id)=1 ");
            return griddailytrreatmenttable;
        }
        public DataTable dt_grp()
        {
            DataTable dtb = db.table("select * from tbl_group order by id");
            return dtb;
        }
        public DataTable dtb_group(string cmb,string d1,string d2)
        {
            DataTable dtb_group = db.table("select cast(date as date) AS  'date' ,a.pt_id,pt_name,primary_mobile_number,email_address,doctorname,b.group_id from tbl_patient a inner join tbl_pt_group b  on a.id=b.pt_id WHERE a.Profile_Status='Active' and b.group_id='" + cmb + "' and date  between '" + d1+ "' and '" + d2 + "' GROUP BY a.id,a.pt_id,pt_name,date,primary_mobile_number,email_address,doctorname,b.group_id");
            return dtb_group;
        }
        public DataTable dtb_procedure(string cmb,string d1,string d2)
        {
            DataTable dtb_procedure = db.table("SELECT  cast(A.date as date) as date,A.procedure_name,B.doctor_name,p.group_id FROM tbl_completed_procedures A INNER JOIN tbl_doctor B ON A.dr_id=B.id inner join tbl_patient P on p.id=A.pt_id WHERE group_id='" + cmb + "'and A.date between '" + d1 + "'and '" + d2 + "' and P.Profile_Status !='Cancelled' ");
            return dtb_procedure;
        }
        public DataTable dtb_invoice(string d1,string d2,string cmb)
        {
            DataTable dt1 = db.table("select tbl_invoices.pt_id,tbl_invoices.pt_name,invoice_no,services,unit,discount_type,tbl_invoices.date,tbl_doctor.doctor_name,total_discount,((cast(cost as decimal(17,1))* cast(unit as decimal(17,1)))+(CAST(total_tax as decimal(17,1)))-(CAST(total_discount as decimal(17,1))) ) as Cost,cost as Total_Cost,(((cast(cost as decimal(17,1))* cast(unit as decimal(17,1)))+(CAST(total_tax as decimal(17,1)))-(CAST(total_discount as decimal(17,1))))-(CAST(total as decimal(17,1))) ) as Payment,cast(total as decimal(17,1)) as due,group_id from tbl_invoices LEFT JOIN tbl_doctor on tbl_invoices.dr_id=tbl_doctor.id LEFT JOIN tbl_patient on tbl_invoices.pt_id=tbl_patient.id where  tbl_patient.Profile_Status='Active' and tbl_invoices.date between '" + d1 + "' and '" + d2 + "'and group_id='" + cmb + "' order by date desc");
            return dt1;
        }
        public DataTable dtb_receipt(string d1,string d2,string cmb)
        {
            DataTable dtp = db.table("SELECT distinct  A.pt_name,receipt_no ,A.invoice_no ,procedure_name, A.total ,A.amount_paid ,CAST((A.total-amount_paid) AS DECIMAL(17,2))  as 'DUE AFTER PAYMENT',payment_date, A.mode_of_payment ,d.doctor_name,group_id FROM tbl_payment A Left join tbl_doctor d on A.dr_id=d.id inner join tbl_patient P on p.id=A.pt_id  Where payment_date between '" + d1 + "' and '" + d2 + "' and P.group_id='" + cmb + "' and P.Profile_Status !='Cancelled'");
            return dtp;
        }
        public DataTable dt_inv(string dtp1,string dtp2)
        {
            DataTable dt_inv = db.table("SELECT distinct unit,CAST((C.unit*C.cost) AS DECIMAL(17,2)) as 'Total Cost',C.discountin_rs,C.tax_inrs ,CAST(((C.unit*C.cost)-C.discountin_rs) AS DECIMAL(17,2)) as 'Total Income',discount_type FROM  tbl_invoices C Where invoice_no='" + dtp1 + "' and  C.services='" + dtp2 + "'");
            return dt_inv;
        }
    }
}
