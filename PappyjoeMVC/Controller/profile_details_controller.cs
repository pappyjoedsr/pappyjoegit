﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
  public  class Profile_Details_controller
    {
        profile_details_interface intr;
        profile_details_model _model =new profile_details_model();
        common_model mdl = new common_model();
        Connection db = new Connection();
        public Profile_Details_controller(profile_details_interface inttr)
        {
            intr = inttr;
            intr.Setcontroller(this);
        }
        public string get_dctr_privillage(string dr_id)
        {
            string privillage = _model.get_dctr_privillage(dr_id);
            return privillage;
        }
        public DataTable Get_Advance(string pt_id)
        {
            DataTable dtb = mdl.Get_Advance(pt_id);
            return dtb;
        } 
        public string Load_CompanyName()
        {
            string dtb = mdl.Load_CompanyName(); 
            return dtb;
        }
        public string Get_DoctorName(string doctor_id)
        {
            string dtb = mdl.Get_DoctorName(doctor_id);
            return dtb;
        }
        public void Get_Patient_details(string patient_id)
        {
            DataTable dtb = _model.Get_Patient_details(patient_id);
            intr.patientload(dtb);
        }
        public DataTable pt_medical(string pt_id)
        {
            DataTable dtb = _model.pt_medical(pt_id);
            return dtb;
        }
        public DataTable patrint_goup(string pt_id)
        {
            DataTable dtb = _model.patrint_goup(pt_id);
            return dtb;
        }
        public DataTable main_settings()
        {
            DataTable cunsultaionview = db.table("select name,status from Tbl_main_Settings where status='1' and name='Con'");
            return cunsultaionview;
        }
        public DataTable Patient_search(string patid)
        {
            DataTable dtb = mdl.Patient_search(patid);
            return dtb;
        }
        public string doctr_privillage_for_addnewPatient (string doctor_id)
        {
            string dtb = mdl.doctr_privillage_for_addnewPatient(doctor_id);
            return dtb;
        }
        public string permission_for_settings(string doctor_id)
        {
            string dtb = mdl.permission_for_settings(doctor_id);
            return dtb;
        }
        public string getserver()
        {
            string ret = db.server();
            return ret;
        }
    }
}
