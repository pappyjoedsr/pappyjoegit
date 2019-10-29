using System;
using System.Data;
namespace PappyjoeMVC.Model
{
    public class Patients_model
    {
        Connection db = new Connection();
        public DataTable Get_all_Patients()
        {
            DataTable sqlstr = db.table("select  id as Pid,pt_id As 'Id'  ,pt_name  as 'Patient Name',gender as Gender,age as Age , primary_mobile_number  as   Mobile,street_address as 'Street Address',locality  as Locality,DATE_FORMAT(date,'%d-%m-%y') as DATE,Opticket as 'File NO' from tbl_patient  where Profile_Status='Active' order by id desc ");
            return sqlstr; //= "SELECT id as Pid,pt_id as Id, pt_name as Name, gender as Gender,age as Age, primary_mobile_number as  Mobile,street_address as 'Street Address',Visited,Opticket FROM tbl_patient where Profile_Status='Active'  ORDER BY id DESC";
        }

        public DataTable group()
        {
            DataTable dt_gd = db.table("SELECT id,name FROM tbl_group ORDER BY id");
            return dt_gd;
        }
        public DataTable Get_appointment_data(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dt_pt5 = db.table("SELECT  tbl_patient.id,tbl_patient.pt_id,tbl_patient.pt_name, tbl_patient.gender,tbl_patient.age, tbl_patient.primary_mobile_number " +
",tbl_appointment.start_datetime,tbl_appointment.status,tbl_appointment.schedule,tbl_appointment.waiting,tbl_appointment.engaged,tbl_appointment.checkout,tbl_appointment.id as a_id,tbl_doctor.doctor_name FROM  tbl_appointment LEFT JOIN tbl_patient on tbl_appointment.pt_id=tbl_patient.ID LEFT JOIN tbl_doctor ON tbl_appointment.dr_id=tbl_doctor.id WHERE  tbl_appointment.start_datetime between  '" + startDateTime.ToString("yyyy-MM-dd HH:mm") + "' AND '" + startDateTime1.ToString("yyyy-MM-dd HH:mm") + "' and tbl_patient. Profile_Status='Active' order by tbl_appointment.id DESC");
            return dt_pt5;
        }
        public DataTable Get_vitalSigns(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dt_cf_main = db.table("SELECT v.ID,v.pt_id,v.dr_id,v.dr_name,v.pulse,v.temp,v.temp_type,v.bp_syst,v.bp_dia,v.bp_type,v.weight,v.resp,v.date,v.Height   FROM tbl_Vital_Signs v join tbl_doctor on v.dr_id=tbl_doctor.id  where v.date between  '" + startDateTime.ToString("yyyy-MM-dd") + "' AND '" + startDateTime1.ToString("yyyy-MM-dd") + "' ORDER BY v.date DESC");
            return dt_cf_main;
        }
        public DataTable Patient_details(string pt_id)
        {
            DataTable rs_patients = db.table("select pt_id,pt_name,gender from tbl_patient where id='" + pt_id + "'");
            return rs_patients;
        }
        public DataTable clinic_findings(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dt_pt_main = db.table("SELECT tbl_clinical_findings.id,tbl_clinical_findings.pt_id,tbl_clinical_findings.date,tbl_doctor.doctor_name FROM tbl_clinical_findings join tbl_doctor on tbl_clinical_findings.dr_id=tbl_doctor.id  where tbl_clinical_findings.date between  '" + startDateTime.ToString("yyyy-MM-dd") + "' AND '" + startDateTime1.ToString("yyyy-MM-dd") + "'  ORDER BY tbl_clinical_findings.date DESC");
            return dt_pt_main;
        }
        public DataTable complaints(string pt_id)
        {
            DataTable dt_cf_Complaints = db.table("SELECT tbl_pt_chief_compaints.complaint_id,tbl_clinical_findings.date FROM tbl_clinical_findings INNER JOIN tbl_pt_chief_compaints ON tbl_clinical_findings.id = tbl_pt_chief_compaints.clinical_finding_id where tbl_pt_chief_compaints.clinical_finding_id='" + pt_id + "'");
            return dt_cf_Complaints;
        }
        public DataTable observation(string pt_id)
        {
            System.Data.DataTable dt_cf_observe = db.table("SELECT tbl_clinical_findings.date, tbl_pt_observation.observation_id FROM tbl_pt_observation INNER JOIN tbl_clinical_findings ON tbl_pt_observation.clinical_finding_id = tbl_clinical_findings.id where tbl_pt_observation.clinical_finding_id='" + pt_id + "'");
            return dt_cf_observe;
        }
        public DataTable investgation(string pt_id)
        {
            System.Data.DataTable dt_cf_investigation = db.table("SELECT tbl_clinical_findings.date, tbl_pt_investigations.investigation_id FROM tbl_pt_investigations INNER JOIN tbl_clinical_findings ON tbl_pt_investigations.clinical_finding_id = tbl_clinical_findings.id where tbl_pt_investigations.clinical_finding_id='" + pt_id + "'");
            return dt_cf_investigation;
        }
        public DataTable diagnosis(string pt_id)
        {
            System.Data.DataTable dt_cf_diagnosis = db.table("SELECT tbl_pt_diagnosis.diagnosis_id, tbl_clinical_findings.date FROM  tbl_clinical_findings INNER JOIN tbl_pt_diagnosis ON tbl_clinical_findings.id = tbl_pt_diagnosis.clinical_finding_id where tbl_pt_diagnosis.clinical_finding_id='" + pt_id + "'");
            return dt_cf_diagnosis;
        }
        public DataTable notes(string pt_id)
        {
            System.Data.DataTable dt_cf_note = db.table("SELECT tbl_pt_note.note_name FROM tbl_clinical_findings INNER JOIN tbl_pt_note ON tbl_clinical_findings.id = tbl_pt_note.clinical_findings_id where tbl_pt_note.clinical_findings_id='" + pt_id + "'");
            return dt_cf_note;
        }
        public DataTable treatmentPlan(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dt_pt_main = db.table("SELECT id,date,dr_name,pt_id FROM tbl_treatment_plan_main where date between  '" + startDateTime.ToString("yyyy-MM-dd") + "' AND '" + startDateTime1.ToString("yyyy-MM-dd") + "' ORDER BY date DESC");
            return dt_pt_main;
        }
        public DataTable treatements_items(string id)
        {
            System.Data.DataTable dt_pt_sub = db.table("SELECT id,procedure_name,cost,discount_inrs,discount_type,discount,total,note,status,tooth,quantity FROM tbl_treatment_plan where plan_main_id='" + id + "' ORDER BY id");
            return dt_pt_sub;
        }
        public DataTable finishedprocedure(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dt_pt_main = db.table("SELECT id,completed_date,patient_id FROM tbl_completed_id where completed_date between  '" + startDateTime.ToString("yyyy-MM-dd") + "' AND '" + startDateTime1.ToString("yyyy-MM-dd") + "' ORDER BY completed_date DESC");
            return dt_pt_main;
        }
        public DataTable finished_sub(string id)
        {
            System.Data.DataTable dt_pt_sub = db.table("SELECT tbl_completed_procedures.id,tbl_completed_procedures.procedure_name,tbl_completed_procedures.cost,tbl_completed_procedures.discount_inrs,tbl_completed_procedures.discount_type,tbl_completed_procedures.discount,tbl_completed_procedures.total,tbl_completed_procedures.note,tbl_completed_procedures.status,tbl_completed_procedures.tooth,tbl_doctor.doctor_name,tbl_completed_procedures.quantity FROM tbl_completed_procedures join tbl_doctor on tbl_completed_procedures.dr_id=tbl_doctor.id  where tbl_completed_procedures.plan_main_id='" + id + "' ORDER BY tbl_completed_procedures.date");
            return dt_pt_sub;
        }
        public DataTable Prescription(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dt_pre_main = db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.pt_id,tbl_prescription_main.date,tbl_doctor.doctor_name FROM tbl_prescription_main left join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id  where tbl_prescription_main.date between  '" + startDateTime.ToString("yyyy-MM-dd") + "' AND '" + startDateTime1.ToString("yyyy-MM-dd") + "' ORDER BY tbl_prescription_main.date DESC");
            return dt_pre_main;
        }
        public DataTable prescription_details(string id)
        {
            System.Data.DataTable dt_prescription = db.table("SELECT drug_name,strength,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,strength_gr FROM tbl_prescription WHERE pres_id='" + id + "' ORDER BY id");
            return dt_prescription;
        }
        public DataTable invoice(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable dt_invoice_main = db.table("SELECT id,date,invoice,status,pt_name,pt_id FROM tbl_invoices_main where date between  '" + startDateTime.ToString("yyyy-MM-dd") + "' AND '" + startDateTime1.ToString("yyyy-MM-dd") + "' ORDER BY date DESC");
            return dt_invoice_main;
        }
        public DataTable invoice_sub(string id)
        {
            System.Data.DataTable dt_pt_sub = db.table("SELECT id,services,unit,cost,discount,discount_type,tax,total,notes,total_cost,total_discount,total_tax,discountin_rs,tax_inrs,dr_id FROM tbl_invoices where invoice_main_id='" + id + "' ORDER BY id");
            return dt_pt_sub;
        }
        public DataTable Payment(DateTime startDateTime, DateTime startDateTime1)
        {
            DataTable Payment_dt = db.table("select  distinct(payment_date),pt_id from tbl_payment where payment_date between  '" + startDateTime.ToString("yyyy-MM-dd") + "' AND '" + startDateTime1.ToString("yyyy-MM-dd") + "' order by payment_date desc");
            return Payment_dt;
        }
        public DataTable payment_sub(string date)
        {
            System.Data.DataTable Payments = db.table("select receipt_no,amount_paid,invoice_no,procedure_name from tbl_payment where payment_date='" + Convert.ToDateTime(date).ToString("yyyy-MM-dd") + "'");
            return Payments;
        }
        public DataTable recently_visited(DateTime d, DateTime todate)
        {
            DataTable dtb = db.table("SELECT  DISTINCT A.id AS Pid,P.pt_id as 'Patient Id',P.pt_name as 'Patient Name', P.gender as Gender,P.age as Age,P. primary_mobile_number as Mobile,P.street_address as 'Street Address',P.locality as Locality,P.Opticket as 'File No' FROM  tbl_appointment A LEFT JOIN tbl_patient P on  A.pt_id=P.ID  where start_datetime between '" + d.ToString("yyyy-MM-dd HH:mm") + "' and '" + todate.ToString("yyyy-MM-dd HH:mm") + "' and A.status<>'CANCELLED' and A.status <>'scheduled' ");
            return dtb;
        }
        public DataTable Recently_added(string d, string todate)
        {
            DataTable dtb = db.table("SELECT  id as Pid,pt_id as 'Patient Id',pt_name as 'Patient Name', gender as 'Gender',age as 'Age', primary_mobile_number as 'Mobile',street_address as 'Street Address',locality as Locality,Opticket as 'File No' FROM  tbl_patient  where Visited between '" + d + "' and '" + todate + "' and tbl_patient.Profile_Status='Active' order by tbl_patient.Date DESC limit 20");
            return dtb;
        }
        public DataTable upcomming_appointments(DateTime startDateTime)
        {
            DataTable dtb = db.table("SELECT  DISTINCT A.pt_id AS Pid,P.pt_id as 'Patient Id',P.pt_name as 'Patient Name', P.gender as Gender,P.age as Age,P. primary_mobile_number as Mobile,P.street_address as 'Street Address',P.locality as Locality,P.Opticket as 'File No' FROM  tbl_appointment A LEFT JOIN tbl_patient P on A.pt_id=P.ID WHERE  start_datetime >=  '" + startDateTime.ToString("yyyy-MM-dd") + "' and p.Profile_Status='Active' and  status !='Cancelled'");//  order by id desc";
            return dtb;
        }
        public DataTable birthday()
        {
            DataTable dtb = db.table("select id as Pid,pt_id as 'Patient Id',pt_name as 'Patient Name', gender as 'Gender',age as 'Age', primary_mobile_number as 'Mobile',street_address as 'Street Address',locality as Locality,Opticket as 'File No' from tbl_patient where MONTH(date_of_birth) ='" + DateTime.Now.Month + "' and DAY(date_of_birth)> '" + DateTime.Now.Day + "'  and date_of_birth !='" + "" + "' and tbl_patient.Profile_Status='Active' order by date_of_birth ASC");
            return dtb;
        }
        public DataTable cancelled_appointment()
        {
            DataTable dtb = db.table("select p.id as Pid,P.pt_id as 'Patient Id',P.pt_name as 'Patient Name',P.gender as Gender,P.age as Age,p.primary_mobile_number as Mobile,p.street_address as 'Street Address',p.locality as Locality,p.Opticket as 'File No' from  tbl_appointment A left join tbl_patient P on A.pt_id=P.id  where status='Cancelled' order by p.id");
            return dtb;
        }
        public DataTable innactive_patients()
        {
            DataTable dtb = db.table(" SELECT P.id as Pid,P.pt_id as 'Patient Id',P.pt_name as 'Patient Name', P.gender as Gender,P.age as Age,P. primary_mobile_number as Mobile,P.street_address as 'Street Address',P.locality as Locality,P.Opticket as 'File No' FROM tbl_patient P where  Profile_Status ='Cancelled' ORDER BY P.id DESC");            //}
            return dtb;
        }
        public DataTable patients_wit_group(string id4)
        {
            DataTable dtb = db.table(" SELECT P.id AS Pid,P.pt_id AS 'Patient Id',pt_name AS 'Patient Name', gender AS Gender,age AS Age, primary_mobile_number AS  Mobile,street_address AS 'Street Address',locality AS Locality,Opticket as 'File No' FROM tbl_patient P inner join tbl_pt_group G on P.id = G.pt_id where G.group_id='" + id4 + "' and Profile_Status='Active' ORDER BY P.id DESC");
            return dtb;
        }


        public DataTable allpatient_search(string name)
        {
            DataTable dtb = db.table("SELECT id Pid, pt_id 'Patient Id',pt_name 'Patient Name', gender Gender,age Age, primary_mobile_number Mobile,street_address 'Street Address',locality Locality,Visited, Opticket as 'File No' FROM tbl_patient where (pt_id like '%" + name + "%' or pt_name like '%" + name + "%' or primary_mobile_number like '%" + name + "%' or email_address like '%" + name + "%' or Opticket like '%" + name + "%' or street_address like '%" + name + "%') and  Profile_Status='Active' ORDER BY id DESC");
            return dtb;
        }
        public DataTable recently_visited_search(DateTime d, DateTime todate, string name)
        {
            DataTable dtb = db.table("SELECT  DISTINCT A.id AS Pid,P.pt_id 'Patient Id',P.pt_name 'Patient Name', P.gender Gender,P.age Age,P. primary_mobile_number Mobile ,P.street_address 'Street Address',P.locality Locality,P.Opticket as 'File No' FROM  tbl_appointment A LEFT JOIN tbl_patient P on  A.pt_id=P.ID  where start_datetime between '" + d + "' and '" + todate + "' and A.status<>'CANCELLED' and A.status <>'scheduled' and (P.pt_id like '%" + name + "%' or P.pt_name like '%" + name + "%' or primary_mobile_number like '%" + name + "%' or email_address like '%" + name + "%' or Opticket like '%" + name + "%' or street_address like '%" + name + "%') ");
            return dtb;
        }
        public DataTable recently_added_search(string d, string todate, string name)
        {
            DataTable dtb = db.table("SELECT  id Pid, pt_id 'Patient Id',pt_name 'Patient Name', gender Gender,age Age, primary_mobile_number Mobile,street_address 'Street Address',locality Locality, Opticket as 'File No' FROM  tbl_patient where Visited between '" + d + "' and '" + todate + "' and tbl_patient.Profile_Status='Active' and (pt_id like '%" + name + "%' or pt_name like '%" + name + "%' or primary_mobile_number like '%" + name + "%' or email_address like '%" + name + "%' or Opticket like '%" + name + "%' or street_address like '%" + name + "%') ORDER BY id DESC limit 30");
            return dtb;
        }
        public DataTable upcomming_appointments_search(DateTime startDateTime, string name)
        {
            DataTable dtb = db.table("SELECT  DISTINCT P.id AS Pid, P.pt_id AS 'Patient Id', P.pt_name as 'Patient Name', P.gender as Gender, P.age as Age, P.primary_mobile_number as Mobile, P.street_address as 'Street Address', P.locality as Locality, P.Opticket as 'File No' FROM  tbl_appointment A LEFT JOIN tbl_patient P on A.pt_id = P.ID WHERE(A.pt_id like '%" + name + "%' or P.pt_name like '%" + name + "%' or primary_mobile_number like '%" + name + "%' or email_address like '%" + name + "%' or Opticket like '%" + name + "%' or street_address like '%" + name + "%') and start_datetime >= '" + startDateTime.ToString("yyyy-MM-dd") + "' and p.Profile_Status = 'Active'");
            return dtb;
        }
        public DataTable birthday_search(string name)
        {
            DataTable dtb = db.table("select id as Pid,pt_id as 'Patient Id',pt_name as 'Patient Name', gender as Gender,age as Age, primary_mobile_number as 'Mobile',street_address as 'Street Address',locality as 'Locality',Opticket as 'File No' from tbl_patient where  tbl_patient.Profile_Status='Active' and (pt_id like '%" + name + "%' or pt_name like '%" + name + "%' or primary_mobile_number like '%" + name + "%' or email_address like '%" + name + "%' or Opticket like '%" + name + "%' or street_address like '%" + name + "%') and MONTH(date_of_birth) ='" + DateTime.Now.Month + "' and DAY(date_of_birth)> '" + DateTime.Now.Day + "'  and date_of_birth !='" + "" + "'  order by date_of_birth ASC");
            return dtb;
        }
        public DataTable cancelled_appointmnt_search(string name)
        {
            DataTable dtb = db.table("select p.id as Pid,P.pt_id as 'Patient Id',P.pt_name as 'Patient Name',P.gender as Gender,P.age as Age,p.primary_mobile_number as Mobile,p.street_address as 'Street Address',p.locality as Locality,p.Opticket as 'File No' from tbl_appointment A left join tbl_patient P on A.pt_id=P.id  where status='Cancelled' and (A.pt_id like '%" + name + "%' or A.pt_name like '%" + name + "%' or primary_mobile_number like '%" + name + "%' or email_address like '%" + name + "%' or Opticket like '%" + name + "%' or street_address like '%" + name + "%') order by p.id DESC");
            return dtb;
        }
        public DataTable innactive_patients_search(string name)
        {
            DataTable dtb = db.table("select id as Pid,pt_id as 'Patient Id',pt_name as 'Patient Name', gender as Gender,age as Age, primary_mobile_number as Mobile,street_address   as 'Street Address',locality as Locality,Opticket as 'File No' from tbl_patient where  tbl_patient.Profile_Status='Cancelled' and (pt_id like '%" + name + "%' or pt_name like '%" + name + "%' or primary_mobile_number like '%" + name + "%' or email_address like '%" + name + "%' or Opticket like '%" + name + "%' or street_address like '%" + name + "%')order by id DESC");
            return dtb;
        }
        public DataTable patients_wit_group_search(string id4, string name)
        {
            DataTable dtb = db.table(" SELECT p.id as Pid,P.pt_id as 'Patient Id',P.pt_name as 'Patient Name',P.gender as Gender,P.age as Age ,p.primary_mobile_number as Mobile,p.street_address as Street Address,p.locality as Locality,p.Opticket as 'File No' FROM tbl_patient P inner join tbl_pt_group G on P.id = G.pt_id where G.group_id='" + id4 + "' and Profile_Status='Active' and (P.pt_id like '%" + name + "%' or P.pt_name like '%" + name + "%' or primary_mobile_number like '%" + name + "%' or email_address like '%" + name + "%' or Opticket like '%" + name + "%' or street_address like '%" + name + "%') ORDER BY P.id DESC");
            return dtb;
        }
        public string inventry_prevlage(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='INVENTORY' and Permission='A'");
            return id;
        }
    }
}