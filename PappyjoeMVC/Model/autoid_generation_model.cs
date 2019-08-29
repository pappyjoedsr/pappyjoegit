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
        public string patient_prefix()
        {
            string cmd = db.scalar("select patient_prefix from tbl_patient_automaticid");
            return cmd;
        }
        public int save_patientid(string _pt_num , string  _pt_prefix ,string _ptCheck)
        {
            int i = db.execute("insert into tbl_patient_automaticid (patient_number,patient_prefix,patient_automation) values ('" + _pt_num + "','" + _pt_prefix + "','"+ _ptCheck + "')");
            return i;
        }
        public int update_patientid(string _pt_num, string _pt_prefix, string _ptCheck)
        {
            int i = db.execute("update tbl_patient_automaticid set patient_number='" + _pt_num + "', patient_prefix='" + _pt_prefix + "',patient_automation='" + _ptCheck + "'");
            return i;
        }
        public int save_invoice(string _InvNumber, string _InvPrefix, string _invCheck)
        {
           int i = db.execute("insert into tbl_invoice_automaticid (invoice_number,invoice_prefix,invoive_automation) values('" + _InvNumber + "','" + _InvPrefix + "','"+ _invCheck + "')");
           return i;
        }
        public int update_invoice(string _InvNumber, string _InvPrefix, string _invCheck)
        {
            int i = db.execute("update tbl_invoice_automaticid set invoice_number='" + _InvNumber + "',invoice_prefix='" + _InvPrefix + "',invoive_automation='" + _invCheck + "'");
            return i;
        }
        public int save_receipt(string _reciptNumber, string _reciptPrefix, string _reciptCheck)
        {
            int i = db.execute("insert into tbl_receipt_automationid (receipt_number,receipt_prefix,receipt_automation) values ('" +_reciptNumber + "','" +_reciptPrefix + "','"+_reciptCheck+"')");
            return i;
        }
        public int update_receipt(string _reciptNumber, string _reciptPrefix, string _reciptCheck)
        {
            int i = db.execute("update tbl_receipt_automationid set receipt_number='" + _reciptNumber + "',receipt_prefix='" + _reciptPrefix + "',receipt_automation='" + _reciptCheck + "'");
            return i;
        }
    }
}
