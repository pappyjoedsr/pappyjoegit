using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Reports_controller
    {
        Connection db = new Connection();
        Reports_model _model = new Reports_model();
        common_model cmodel = new common_model();
        public string doctor_id = "0";
        public string staff_id = "0";
        public string patient_id = "0";
        public string invoice_to_combo(string doctor_id)
        {
            string s = _model.invoice_to_combo(doctor_id);
            return s;
        }
        public string reciept_combo(string doctor_id)
        {
            string s = _model.reciept_combo(doctor_id);
            return s;
        }
        public string payment_combo(string doctor_id)
        {
            string s = _model.payment_combo(doctor_id);
            return s;
        }
        public string appoint_combo(string doctor_id)
        {
            string s = _model.appoint_combo(doctor_id);
            return s;
        }
        public string patient_combo(string doctor_id)
        {
            string s = _model.patient_combo(doctor_id);
            return s;
        }
        public string emr_combo(string doctor_id)
        {
            string s = _model.emr_combo(doctor_id);
            return s;
        }
        public string inventory_combo(string doctor_id)
        {
            string s = _model.inventory_combo(doctor_id);
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
        public DataTable inv_main(string date1, string date2)
        {
            DataTable dt = _model.invoice_main(date1, date2);
            return dt;
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
        public DataTable reciept(string date1, string date2)
        {
            DataTable dt = _model.reciept(date1, date2);
            return dt;
        }

        public DataTable reciept_invoice(string invMain)
        {
            DataTable dt = _model.reciept_invoice(invMain);
            return dt;
        }
        public DataTable patient_reciept(string date1, string date2)
        {
            DataTable dt = _model.patient_reciept(date1, date2);
            return dt;
        }
        public DataTable appointment_invMain(string date1, string date2)
        {
            DataTable dt = _model.Appointment_invMain(date1, date2);
            return dt;
        }
        public DataTable Appointment_grvShow(string date1, string date2)
        {
            DataTable dt = _model.Appointment_grvShow(date1, date2);
            return dt;
        }
        public DataTable Patient_invMain(string date1, string date2)
        {
            DataTable dt = _model.Patient_invMain(date1, date2);
            return dt;
        }
        public DataTable Patient_grv_Show(string date1, string date2)
        {
            DataTable dt = _model.Patient_grvShow(date1, date2);
            return dt;
        }
        public DataTable EMR_invMain(string date1, string date2)
        {
            DataTable dt = _model.EMR_invMain(date1, date2);
            return dt;
        }
        public DataTable EMR_grvShow(string date1, string date2)
        {
            DataTable dt = _model.EMR_grvShow(date1, date2);
            return dt;
        }
        public DataTable expence_checked(string date1, string date2, string type)
        {
            DataTable dt = _model.expence_checked(date1, date2, type);
            return dt;
        }
        public DataTable expense_income_notChecked(string date1, string date2)
        {
            DataTable dt = _model.expence_income_notChecked(date1, date2);
            return dt;
        }
        public DataTable Inventory_dt_stock()
        {
            DataTable dt = _model.Inventory_dt_stock();
            return dt;
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
        public DataTable Get_CompanyNAme()
        {
            DataTable d = cmodel.Get_CompanyNAme();
            return d;
        }
        public string Get_DoctorName(string doctor_id)
        {
            string dt = cmodel.Get_DoctorName(doctor_id);
            return dt;
        }
        public DataTable get_all_doctorname()
        {
            DataTable dt = cmodel.get_all_doctorname();
            return dt;
        }
        public DataTable Get_Practice_details()
        {
            DataTable dt = cmodel.Get_Practice_details();
            return dt;
        }
        public string Get_DoctorId(string name)
        {
            string dt = cmodel.Get_DoctorId(name);
            return dt;
        }
    }
}
