using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public class stock_controller
    {
        Common_model cmodel = new Common_model();
        Connection db = new Connection();
        StockItem_model model = new StockItem_model();
        public string Load_CompanyName()
        {
            string clinicname = cmodel.Load_CompanyName();
            return clinicname;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable dt = cmodel.Get_practiceDlNumber();
            return dt;
        }
        public string Get_DoctorName(string doctor_id)
        {
            string dtb = cmodel.Get_DoctorName(doctor_id);
            return dtb;
        }
        public DataTable LoadSupplier()
        {
            DataTable gp_rs = model.LoadSupplier();
            return gp_rs;
        }
        public DataTable load_stock()
        {
            DataTable dt_stock = model.load_stock();
            return dt_stock;
        }
        public DataTable minimumStock(string item_code)
        {
            DataTable dtb_Min = model. minimumStock(item_code);
            return dtb_Min;
        }
        public DataTable itemdetails(string item_code)
        {
            DataTable dtunit = model.itemdetails(item_code);
            return dtunit;
        }
        public DataTable search_minimum()
        {
            DataTable sqlstr = model.search_minimum();
            return sqlstr;
        }
        public DataTable search_minium_wit_itemname(string search)
        {
            DataTable sqlstr = model.search_minium_wit_itemname(search);
            return sqlstr;
        }
        public DataTable get_supcode(string sup)
        {
            DataTable dt_sup = model.get_supcode(sup);
            return dt_sup;
        }
        public DataTable Load_supplier_items(string Sup_Code)
        {
            DataTable dtb = model.Load_supplier_items(Sup_Code);
            return dtb;
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
        public DataTable get_company_details()
        {
            DataTable dtb = cmodel.get_company_details();
            return dtb;
        }
    }
}
