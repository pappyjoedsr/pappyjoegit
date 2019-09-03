﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public  class Autoid_Generation_controller
    {
        autoid_generation_model _model=new autoid_generation_model();
        public DataTable load_patientid()
        {
            DataTable dtb = _model.load_patientid();
            return dtb;
        }
        public DataTable load_Invoiceid()
        {
            DataTable dtb = _model.load_Invoiceid();
            return dtb;
        }
        public DataTable load_receiptid()
        {
            DataTable dtb = _model.load_receiptid();
            return dtb;
        }
        public string patient_prefix()
        {
            string dtb = _model.patient_prefix();
            return dtb;
        }
        public int save_patientid(string _pt_num, string _pt_prefix, string Check)
        {
            int i = _model.save_patientid( _pt_num,_pt_prefix, Check);
            return i;
        }
        public int update_patientid(string _pt_num, string _pt_prefix,string Check)
        {
            int i = _model.update_patientid(_pt_num, _pt_prefix, Check);
            return i;
        }
        public DataTable Invoice_prefix()
        {
            DataTable dtb = _model.load_Invoiceid();
            return dtb;
        }
        public int save_invoice(string InvNumber, string InvPrefix, string check)
        {
            int i = _model.save_invoice(InvNumber, InvPrefix, check);
            return i;
        }
        public int update_invoice(string InvNumber, string InvPrefix, string check)
        {
            int i = _model.update_invoice(InvNumber, InvPrefix, check);
            return i;
        }
        public DataTable Recipt_prefix()
        {
            DataTable dtb = _model.load_receiptid();
            return dtb;
        }
        public int save_receipt(string ReciptNumber, string ReciptPrefix, string check)
        {
            int i = _model.save_receipt(ReciptNumber, ReciptPrefix, check);
            return i;
        }
        public int update_receipt(string ReciptNumber, string ReciptPrefix, string check)
        {
            int i = _model.update_receipt(ReciptNumber, ReciptPrefix, check);
            return i;
        }
    }
}
