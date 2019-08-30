using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public class ItemList_Controller
    {
        ItemList_Model _model = new ItemList_Model();
        common_model cmdl = new common_model();
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
        public DataTable  Fill_manufactureCombo()
        {
            DataTable dtb = _model.Fill_manufactureCombo();
            return dtb;
        }
        public DataTable Fill_Grid()
        {
            DataTable dtb = _model.Fill_Grid();
            return dtb;
        }
        public DataTable Get_manufacturename( string name)
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
    }
}
