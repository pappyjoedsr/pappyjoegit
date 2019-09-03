using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
    public class Booking_model
    {
        Connection db = new Connection();
       
        public DataTable patient_details(string txt_p_name)
        {
            DataTable dtpSearch = db.table("select * from tbl_patient where pt_name like '" + txt_p_name + "' order by pt_name");
            return dtpSearch;
        }
        public DataTable sms_details()
        {
            DataTable sms = db.table("select smsName,smsPass from tbl_SmsEmailConfig");
            return sms;
        }
    }
}
