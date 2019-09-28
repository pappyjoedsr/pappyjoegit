using System;
using System.Data;
namespace PappyjoeMVC.Model
{
    public class Export_model
    {
        Connection db = new Connection();
        public DataTable Get_AllDoctor()
        {
            DataTable dt_dr = db.table("select * from tbl_doctor order by id");
            return dt_dr;
        }
        public DataTable Get_addProcedure()
        {
            DataTable procedure = db.table("select name,cost,notes from tbl_addproceduresettings");
            return procedure;
        }
        public DataTable patient_details(DateTime from, DateTime to)
        {
            DataTable contact = db.table("SELECT tbl_patient.date,tbl_patient.pt_name, tbl_patient.pt_id, tbl_patient.gender, tbl_patient.date_of_birth, tbl_patient.blood_group, tbl_patient.primary_mobile_number, tbl_patient.email_address, tbl_patient.street_address, tbl_patient.locality, tbl_patient.city, tbl_patient.pincode  FROM tbl_patient where tbl_patient.date between '" + Convert.ToDateTime(from).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(to).ToString("yyyy-MM-dd") + "'");
            return contact;
        }
        public DataTable doctor_wise_appointment(string doctor, DateTime datefrom, DateTime dateto)
        {
            DataTable appt = db.table("SELECT tbl_patient.pt_name,tbl_patient.pt_id,tbl_patient.email_address,tbl_patient.primary_mobile_number, tbl_appointment.start_datetime,tbl_appointment.plan_new_procedure,tbl_doctor.doctor_name,tbl_appointment.note FROM tbl_appointment  INNER JOIN tbl_doctor ON tbl_appointment.dr_id = tbl_doctor.id INNER JOIN tbl_patient ON tbl_appointment.pt_id = tbl_patient.id where tbl_doctor.doctor_name='" + doctor + "'and tbl_patient.date between '" + Convert.ToDateTime(datefrom).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(dateto).ToString("yyyy-MM-dd") + "'");
            return appt;
        }
        public DataTable get_all_appointments(DateTime from, DateTime to)
        {
            DataTable appt = db.table("SELECT tbl_patient.pt_name,tbl_patient.pt_id,tbl_patient.email_address,tbl_patient.primary_mobile_number, tbl_appointment.start_datetime,tbl_appointment.plan_new_procedure,tbl_doctor.doctor_name,tbl_appointment.note FROM tbl_appointment  INNER JOIN tbl_doctor ON tbl_appointment.dr_id = tbl_doctor.id INNER JOIN tbl_patient ON tbl_appointment.pt_id = tbl_patient.id where tbl_patient.date between '" + from + "' and '" + to + "'");
            return appt;
        }
        public DataTable doctor_wise_treatment(string doctor, DateTime datefrom, DateTime dateto)
        {
            DataTable treat = db.table("SELECT tbl_treatment_plan_main.date,tbl_patient.pt_id,tbl_patient.pt_name,tbl_doctor.doctor_name, tbl_treatment_plan.procedure_name, tbl_treatment_plan.note, tbl_treatment_plan.discount, tbl_treatment_plan.cost FROM  tbl_treatment_plan INNER JOIN tbl_treatment_plan_main ON tbl_treatment_plan.plan_main_id = tbl_treatment_plan_main.id INNER JOIN tbl_patient ON tbl_treatment_plan.pt_id = tbl_patient.id INNER JOIN tbl_doctor ON tbl_treatment_plan_main.dr_id= tbl_doctor.id where tbl_doctor.doctor_name='" + doctor + "' and tbl_treatment_plan_main.date between '" + Convert.ToDateTime(datefrom).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(dateto).ToString("yyyy-MM-dd") + "'");
            return treat;
        }
        public DataTable all_tratment(DateTime from, DateTime to)
        {
            DataTable treat = db.table("SELECT tbl_treatment_plan_main.date,tbl_patient.pt_id,tbl_patient.pt_name,tbl_doctor.doctor_name, tbl_treatment_plan.procedure_name, tbl_treatment_plan.note, tbl_treatment_plan.discount, tbl_treatment_plan.cost FROM  tbl_treatment_plan INNER JOIN tbl_treatment_plan_main ON tbl_treatment_plan.plan_main_id = tbl_treatment_plan_main.id INNER JOIN tbl_patient ON tbl_treatment_plan.pt_id = tbl_patient.id INNER JOIN tbl_doctor ON tbl_treatment_plan_main.dr_id= tbl_doctor.id where tbl_treatment_plan_main.date between '" + Convert.ToDateTime(from).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(to).ToString("yyyy-MM-dd") + "'");
            return treat;
        }
        public DataTable expense(DateTime from, DateTime to)
        {
            DataTable expense = db.table("select date,expense_type,description,amount from tbl_expense where date between '" + Convert.ToDateTime(from).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(to).ToString("yyyy-MM-dd") + "'");
            return expense;
        }
        public DataTable doctor_wise_prescription(string doctor, DateTime datefrom, DateTime dateto)
        {
            DataTable prescription = db.table("select tbl_prescription.date,tbl_prescription.dr_name,tbl_patient.pt_id,tbl_patient.pt_name,tbl_prescription.drug_name,tbl_prescription.drug_type,tbl_prescription.strength,tbl_prescription.strength_gr,tbl_prescription.food,tbl_prescription.morning,tbl_prescription.noon,tbl_prescription.night,tbl_prescription.add_instruction,((tbl_prescription.duration_unit  + ' '+ tbl_prescription.duration_period)) as duration_period1  from tbl_prescription INNER JOIN tbl_patient ON tbl_patient.id=tbl_prescription.pt_id INNER JOIN tbl_doctor ON tbl_prescription.dr_id= tbl_doctor.id where tbl_doctor.doctor_name='" + doctor + "' where tbl_prescription.date between '" + Convert.ToDateTime(datefrom).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(dateto).ToString("yyyy-MM-dd") + "'");
            return prescription;
        }
        public DataTable All_prescription(DateTime from, DateTime to)
        {
            DataTable prescription = db.table("select tbl_prescription.date,tbl_prescription.dr_name,tbl_patient.pt_id,tbl_patient.pt_name,tbl_prescription.drug_name,tbl_prescription.drug_type,tbl_prescription.strength,tbl_prescription.strength_gr,tbl_prescription.food,tbl_prescription.morning,tbl_prescription.noon,tbl_prescription.night,tbl_prescription.add_instruction,(tbl_prescription.duration_unit  + ' '+ tbl_prescription.duration_period) as duration_period1   from tbl_prescription INNER JOIN tbl_patient ON tbl_patient.id=tbl_prescription.pt_id where tbl_prescription.date between '" + Convert.ToDateTime(from).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(to).ToString("yyyy-MM-dd") + "'");
            return prescription;
        }
    }
}
