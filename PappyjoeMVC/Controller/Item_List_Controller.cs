using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Item_List_Controller
    {
        Item_List_Model _model = new Item_List_Model();
        Common_model cmdl = new Common_model();
        public DataTable Get_CompanyNAme()
        {
            DataTable dtb = cmdl.Get_CompanyNAme();
            return dtb;
        }
        public string Get_DoctorId(string doctor_id)
        {
            string dtb = cmdl.Get_DoctorId(doctor_id);
            return dtb;
        }
        public DataTable Fill_manufactureCombo()
        {
            DataTable dtb = _model.Fill_manufactureCombo();
            return dtb;
        }
        public DataTable Fill_Grid()
        {
            DataTable dtb = _model.Fill_Grid();
            return dtb;
        }
        public DataTable Get_manufacturename(string name)
        {
            DataTable dtb = _model.Get_manufacturename(name);
            return dtb;
        }
        public DataTable get_items_with_manufacture(int manufactr)
        {
            DataTable dtb = _model.get_items_with_manufacture(manufactr);
            return dtb;
        }
        public DataTable Search(string name)
        {
            DataTable dtb = _model.Search(name);
            return dtb;
        }
        public DataTable manufactureName(string name)
        {
            DataTable dtb = _model.Get_manufacturename(name);
            return dtb;
        }
        public DataTable Search_wit_manufacture(string name, string manufacture)
        {
            DataTable dtb = _model.Search_wit_manufacture(name, manufacture);
            return dtb;
        }
        public DataTable Get_itemDetails(string id)
        {
            DataTable dtb = _model.Get_itemDetails(id);
            return dtb;
        }
        public DataTable get_stock(string id)
        {
            DataTable dtb = _model.get_stock(id);
            return dtb;
        }
        public int delete(string id)
        {
            int i = _model.delete(id);
            return i;
        }
        public DataTable Patient_search(string patid)
        {
            DataTable dtb = cmdl.Patient_search(patid);
            return dtb;
        }
        public string privilge_for_inventory(string doctor_id)
        {
            string id = cmdl.privilge_for_inventory(doctor_id);
            return id;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string dtb = cmdl.doctr_privillage_for_addnewPatient(doctor_id);
            return dtb;
        }
        public string Get_DoctorName(string doctor_id)
        {
            string dctr = cmdl.Get_DoctorName(doctor_id);
            return dctr;
        }
        public string permission_for_settings(string doctor_id)
        {
            string dtb = cmdl.permission_for_settings(doctor_id);
            return dtb;
        }
    }
}
