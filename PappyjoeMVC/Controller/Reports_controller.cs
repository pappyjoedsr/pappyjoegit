﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
    public class Reports_controller
    {
        Connection db = new Connection();
        Reports_interface intr;
        Reports_model _model = new Reports_model();
        common_model cmodel = new common_model();
        public string doctor_id = "0";
        public string staff_id = "0";
        public string patient_id = "0";

        public Reports_controller(Reports_interface inttr)
        {
            intr = inttr;
            intr.setcontroller(this);
        }

        public string invoice_to_combo(string doctor_id)
        {
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='RPTINC' and Permission='A'");
            //string s = _model.invoice_to_combo(doctor_id);
            return id;
        }
        public string reciept_combo(string doctor_id)
        {
            //string s = _model.reciept_combo(doctor_id);
            string s = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='RPTINCM' and Permission='A'");
            return s;
        }
        public string payment_combo(string doctor_id)
        {
            //string s = _model.payment_combo(doctor_id);
            string s = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='RPTPAY' and Permission='A'");
            return s;
        }
        public string appoint_combo(string doctor_id)
        {
            //string s = _model.appoint_combo(doctor_id);
            string id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='RPTAPT' and Permission='A'");
            return id;
        }
        public string patient_combo(string doctor_id)
        {
            //string s = _model.patient_combo(doctor_id);
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
            //string s = _model.inventory_combo(doctor_id);
            string s = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='RPTINV' and Permission='A'");
            return s;
        }
        public DataTable Patient_search(string patid)
        {
            DataTable dtb = cmodel.Patient_search(patid);
            return dtb;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string dtb = cmodel.doctr_privillage_for_addnewPatient(doctor_id);
            return dtb;
        }
        public string permission_for_settings(string doctor_id)
        {
            string dtb = cmodel.permission_for_settings(doctor_id);
            return dtb;
        }
        public void inv_main(string date1,string date2)
        {
            DataTable dt = _model.invoice_main(date1,date2);
            intr.Load_invoiceReport(dt);
        }
        public DataTable dr_invoice(string invoice, string dr_id)
        {
            DataTable dt = _model.dr_invoice(invoice, dr_id);
            return dt;
        }
        public DataTable invoice(string invMain)
        {
            DataTable dt = _model.invoice(invMain);
            return dt;
        }
        public void reciept(string date1, string date2)
        {
            DataTable dt = _model.reciept(date1, date2);
            intr.Load_recieptReport(dt);
        }
        
        public DataTable reciept_invoice(string invMain)
        {
            DataTable dt = _model.reciept_invoice(invMain);
            return dt;
        }  
        public DataTable patient_reciept(string date1,string date2)
        {
            DataTable dt = _model.patient_reciept(date1, date2);
            return dt;
        }
        public void appointment_invMain(string date1,string date2)
        {
            DataTable dt = _model.Appointment_invMain(date1,date2);
            intr.Load_appointmentReport(dt);
        }
        public DataTable Appointment_grvShow(string date1, string date2)
        {
            DataTable dt = _model.Appointment_grvShow(date1, date2);
            return dt;
        }
        public void Patient_invMain(string date1, string date2)
        {
            DataTable dt = _model.Patient_invMain(date1, date2);
            intr.Load_patientReport(dt);
        }
        public DataTable Patient_grv_Show(string date1, string date2)
        {
            DataTable dt = _model.Patient_grvShow(date1,date2);
            return dt;
        }
        public void EMR_invMain(string date1, string date2)
        {
            DataTable dt = _model.EMR_invMain(date1,date2);
            intr.Load_EMRReport(dt);
        }
        public DataTable EMR_grvShow(string date1, string date2)
        {
            DataTable dt = _model.EMR_grvShow(date1, date2);
            return dt;
        }
        public void expence_checked(string date1, string date2, string type)
        {
            DataTable dt = _model.expence_checked(date1,date2,type);
            intr.Load_expenseReport(dt);
        }
        public void expense_income_notChecked(string date1,string date2)
        {
            DataTable dt = _model.expence_income_notChecked(date1,date2);
            intr.Load_expenseReport(dt);
        }
        public void Inventory_dt_stock()
        {
            DataTable dt = _model.Inventory_dt_stock();
            intr.Load_inventoryReport(dt);
        }
        public DataTable inventory_gv_Show(string dr)
        {
            DataTable dt = _model.Inventory_gvShow(dr);
            return dt;
        }
        public DataTable GetDoctorId_byLogintype(string drid)
        {
            DataTable dt = _model.GetDoctorId_byLogintype(drid);
            return dt;
        }
    }
}