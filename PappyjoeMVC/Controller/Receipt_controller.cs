using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
    public class Receipt_controller
    {
        Receipt_interface intr;
        Connection db = new Connection();
        Receipt_Model Model = new Receipt_Model();
        common_model cmodel =new common_model();
        public Receipt_controller(Receipt_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public string check_add_privillege(string doctor_id)
        {
          string  id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='PMT' and Permission='A'");
          return id;
        }
        public DataTable Get_CompanyNAme()
        {
            DataTable dtb = cmodel.Get_CompanyNAme();
            return dtb;
        }
        public string Get_DoctorName(string doctor_id)
        {
            string dtb = cmodel.Get_DoctorName(doctor_id);
            return dtb;
        }
        public DataTable get_total_payment(string ptid)
        {
            DataTable dtb = cmodel.get_total_payment(ptid);
            return dtb;
        }
        public DataTable Get_pat_iDName(string patient_id)
        {
            DataTable dtb = cmodel.Get_pat_iDName(patient_id);
            return dtb;
        }
        public DataTable get_paymentDate(string patient_id)
        {
          DataTable Payment = db.table("select  distinct(payment_date) from tbl_payment where pt_id='" + patient_id + "'AND payment_date!='' order by payment_date desc");
          return Payment;
        }
        public DataTable payment_details(string date, string patient_id)
        {
            DataTable dtb = Model.payment_details(date,patient_id);
            return dtb;
        }
        public DataTable get_printSettings()
        {
           DataTable print = db.table("select * from tbl_receipt_printsettings");
           return print;
        }
        public DataTable get_company_details()
        {
            DataTable dtb = cmodel.get_company_details();
            return dtb;
        }
        public DataTable Get_Patient_Details(string id)
        {
            DataTable dtb = cmodel.Get_Patient_Details(id);
            return dtb;
        }
        public DataTable receipt_printSettings()
        {
            DataTable print = db.table("select header,left_text,right_text,fullwidth_context,left_sign,right_sign from  tbl_receipt_printsettings");
            return print;
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
    }
}
