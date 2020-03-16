using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Receipt_controller
    {
        Connection db = new Connection();
        Receipt_Model Model = new Receipt_Model();
        Common_model cmodel = new Common_model();
        public string check_add_privillege(string doctor_id)
        {
            string id = Model.check_add_privillege(doctor_id);
            return id;
        }
        public string privilge_for_inventory(string doctor_id)
        {
            string s = cmodel.privilge_for_inventory(doctor_id);
            return s;
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
        public string server()
        {
            string server = db.server();
            return server;
        }
        public DataTable get_total_payment(string ptid)
        {
            DataTable dtb = cmodel.get_total_payment(ptid);
            return dtb;
        }
        public DataTable Get_Advance(string pt_id)
        {
            DataTable dtb = cmodel.Get_Advance(pt_id);
            return dtb;
        }
        public DataTable getall_advance(string pt_id)
        {
            DataTable dtb = Model.getall_advance(pt_id);
            return dtb;
        }
        public void update_advance(decimal adv, string patient_id)
        {
            Model.update_advance(adv, patient_id);
        }
        public void Save_advancetable(string Pt_id, string Date, string Amount, string PaymentMethod, string Credit_Debit)
        {
            Model.Save_advancetable(Pt_id, Date, Amount, PaymentMethod, Credit_Debit);
        }
        public DataTable gt_pt_advance(string pt_id)
        {
            DataTable dtb = Model.gt_pt_advance(pt_id);
            return dtb;
        }
        public DataTable Get_pat_iDName(string patient_id)
        {
            DataTable dtb = cmodel.Get_pat_iDName(patient_id);
            return dtb;
        }
        public DataTable get_paymentDate(string patient_id)
        {
            DataTable Payment = Model.get_paymentDate(patient_id);
            return Payment;
        }
        public DataTable payment_details(string date, string patient_id)
        {
            DataTable dtb = Model.payment_details(date, patient_id);
            return dtb;
        }
        public DataTable get_printSettings()
        {
            DataTable print = Model.get_printSettings();
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
            DataTable print = Model.receipt_printSettings();
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
