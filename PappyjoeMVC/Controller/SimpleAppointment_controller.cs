using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public class SimpleAppointment_controller
    {
        Common_model cmodel = new Common_model();
        SimpleAppointment_model model = new SimpleAppointment_model();
        Clinical_Notes_Add_model cn_model = new Clinical_Notes_Add_model();
        Add_Invoice_model Ainv_model = new Add_Invoice_model();
        public DataTable get_All_proceure()
        {
            DataTable dtb = cmodel.get_All_proceure();
            return dtb;
        }
        public DataTable get_drug_details()
        {
            DataTable dtb = model.get_drug_details();
            return dtb;
        }
        public DataTable get_all_doctorname()
        {
            DataTable dtb = cmodel.get_all_doctorname();
            return dtb;
        }
        public DataTable show_compl()
        {
            DataTable dtb = cn_model.show_compl();
            return dtb;
        }
        public DataTable show_diagno()
        {
            DataTable dtb = cn_model.show_diagno();
            return dtb;
        }
        public DataTable show_note()
        {
            DataTable dtb = cn_model.show_note();
            return dtb;
        }
        public DataTable Fill_unit_combo()
        {
            DataTable dtb = cmodel.Fill_unit_combo();
            return dtb;
        }
        public DataTable Fill_LoadTax()
        {
            DataTable dtb = cmodel.Fill_LoadTax();
            return dtb;
        }
        public DataTable Get_invoice_prefix()
        {
            DataTable dtb = Ainv_model.Get_invoice_prefix();
            return dtb;
        }
        public DataTable get_pt_details(string patient_id)
        {
            DataTable dtb = model.get_pt_details(patient_id);
            return dtb;
        }
        public DataTable get_EHR_details(string strApp_id)
        {
            DataTable dtb = model.get_EHR_details(strApp_id);
            return dtb;
        }
        public DataTable getComplaints(string id)
        {
            DataTable dtb = cn_model.getComplaints(id);
            return dtb;
        }
        public DataTable get_diagno(string id)
        {
            DataTable dtb = cn_model.get_diagno(id);
            return dtb;
        }
        public DataTable get_note(string id)
        {
            DataTable dtb = cn_model.get_note(id);
            return dtb;
        }
    }
}
