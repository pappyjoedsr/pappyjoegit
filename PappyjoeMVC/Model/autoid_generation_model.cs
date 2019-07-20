using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
  public class autoid_generation_model
    {
        Connection db = new Connection();
        private string _pt_num = "";
        public string patient_Number
        {
            get { return _pt_num; }
            set
            { _pt_num = value;}
        }
        private string _pt_prefix = "";
        public string patient_Prefix
        {
            get { return _pt_prefix; }
            set
            { _pt_prefix = value; }
        }
        private string _ptCheck = "";
        public string patient_Check
        {
            get { return _ptCheck; }
            set
            { _ptCheck = value; }
        }
        private string _InvNumber = "";
        public string InvNumber
        {
            get { return _InvNumber; }
            set
            { _InvNumber = value; }
        }
        private string _InvPrefix = "";
        public string InvPrefix
        {
            get { return _InvPrefix; }
            set { _InvPrefix = value; }
        }
        private string _invCheck = "";
        public string Inv_Check
        {
            get { return _invCheck; }
            set { _invCheck = value; }
        }

        private string _reciptNumber = "";
        public string ReciptNumber
        {
            get { return _reciptNumber; }
            set
            { _reciptNumber = value; }
        }
        private string _reciptPrefix = "";
        public string ReciptPrefix
        {
            get { return _reciptPrefix; }
            set { _reciptPrefix = value; }
        }
        private string _reciptCheck = "";
        public string Recipt_Check
        {
            get { return _reciptCheck; }
            set { _reciptCheck = value; }
        }
        public DataTable load_patientid()
        {
            DataTable patient = db.table("select * from tbl_patient_automaticid");
            return patient;
        }
        public DataTable load_Invoiceid()
        {
            DataTable invoice = db.table("select * from tbl_invoice_automaticid");
            return invoice;
        }
        public DataTable load_receiptid()
        {
            DataTable receipt = db.table("select * from tbl_receipt_automationid");
            return receipt;
        }
        public DataTable patient_prefix()
        {
            DataTable cmd = db.table("select patient_prefix from tbl_patient_automaticid");
            return cmd;
        }
        public int save_patientid()
        {
            int i = db.execute("insert into tbl_patient_automaticid (patient_number,patient_prefix,patient_automation) values ('" + _pt_num + "','" + _pt_prefix + "','"+ _ptCheck + "')");
            return i;
        }
        public int update_patientid()
        {
            int i = db.execute("update tbl_patient_automaticid set patient_number='" + _pt_num + "', patient_prefix='" + _pt_prefix + "',patient_automation='" + _ptCheck + "'");
            return i;
        }
        public int save_invoice()
        {
           int i = db.execute("insert into tbl_invoice_automaticid (invoice_number,invoice_prefix,invoive_automation) values('" + _InvNumber + "','" + _InvPrefix + "','"+ _invCheck + "')");
           return i;
        }
        public int update_invoice()
        {
            int i = db.execute("update tbl_invoice_automaticid set invoice_number='" + _InvNumber + "',invoice_prefix='" + _InvPrefix + "',invoive_automation='" + _invCheck + "'");
            return i;
        }
        public int save_receipt()
        {
            int i = db.execute("insert into tbl_receipt_automationid (receipt_number,receipt_prefix,receipt_automation) values ('" +_reciptNumber + "','" +_reciptPrefix + "','"+_reciptCheck+"')");
            return i;
        }
        public int update_receipt()
        {
            int i = db.execute("update tbl_receipt_automationid set receipt_number='" + _reciptNumber + "',receipt_prefix='" + _reciptPrefix + "',receipt_automation='" + _reciptCheck + "'");
            return i;
        }
    }
}
