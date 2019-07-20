using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public  class autoid_generation_controller
    {
        autoid_generation_interface intr;
        autoid_generation_model _model=new autoid_generation_model();
            
        public autoid_generation_controller(autoid_generation_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public void load_patientid()
        {
            DataTable dtb = _model.load_patientid();
            intr.LoadPatientId(dtb);
        }
        public void load_Invoiceid()
        {
            DataTable dtb = _model.load_Invoiceid();
            intr.LoadInvoiceId(dtb);
        }
        public void load_receiptid()
        {
            DataTable dtb = _model.load_receiptid();
            intr.LoadReceiptId(dtb);
        }
        public DataTable patient_prefix()
        {
            DataTable dtb = _model.patient_prefix();
            return dtb;
        }
        public int save_patientid( string Check)
        {
            _model.patient_Check = Check;
            _model.patient_Number = intr.PtNumber;
            _model.patient_Prefix = intr.ptPrefix;
            int i = _model.save_patientid();
            return i;
        }
        public int update_patientid(string Check)
        {
            _model.patient_Check = Check;
            _model.patient_Number = intr.PtNumber;
            _model.patient_Prefix = intr.ptPrefix;
            int i = _model.update_patientid();
            return i;
        }
        public DataTable Invoice_prefix()
        {
            DataTable dtb = _model.load_Invoiceid();
            return dtb;
        }
        public int save_invoice(string check)
        {
            _model.InvNumber = intr.InvNumber;
            _model.InvPrefix = intr.InvPrefix;
            _model.Inv_Check = check;
            int i = _model.save_invoice();
            return i;
        }
        public int update_invoice(string check)
        {
            _model.InvNumber = intr.InvNumber;
            _model.InvPrefix = intr.InvPrefix;
            _model.Inv_Check = check;
            int i = _model.update_invoice();
            return i;
        }
        public DataTable Recipt_prefix()
        {
            DataTable dtb = _model.load_receiptid();
            return dtb;
        }
        public int save_receipt(string check)
        {
            _model.ReciptNumber = intr.ReciptNumber;
            _model.ReciptPrefix = intr.ReciptPrefix;
            _model.Recipt_Check = check;
            int i = _model.save_receipt();
            return i;
        }
        public int update_receipt(string check)
        {
            _model.ReciptNumber = intr.ReciptNumber;
            _model.ReciptPrefix = intr.ReciptPrefix;
            _model.Recipt_Check = check;
            int i = _model.update_receipt();
            return i;
        }
    }
}
