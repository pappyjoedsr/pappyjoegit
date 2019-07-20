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
        ItemList_inerface intr;
        ItemList_Model _model = new ItemList_Model();
        common_model cmdl = new common_model();
        public ItemList_Controller(ItemList_inerface inttr)
        {
            intr = inttr;
            intr.Setcontroller(this);
        }
        public DataTable Get_CompanyNAme()
        {
            DataTable dtb = cmdl.Get_CompanyNAme();
            return dtb;
        }
        public DataTable Get_DoctorId(string doctor_id)
        {
            DataTable dtb = cmdl.Get_DoctorId(doctor_id);
            return dtb;
        }
        public void Fill_manufactureCombo()
        {
            DataTable dtb = _model.Fill_manufactureCombo();
            intr.Fill_ManufactureCombo(dtb);
        }
        public void Fill_Grid()
        {
            DataTable dtb = _model.Fill_Grid();
            intr.Fill_Grid(dtb);
        }
        public void Get_manufacturename( string name)
        {
            DataTable dtb = _model.Get_manufacturename(name);
            intr.Get_manufacturename(dtb);
        }
        public void get_items_with_manufacture(int manufactr)
        {
            DataTable dtb = _model.get_items_with_manufacture(manufactr);
            intr.Fill_Grid(dtb);
        }
        public void Search(string name)
        {
            DataTable dtb = _model.Search(name);
            intr.Fill_Grid(dtb);
        }
        public DataTable manufactureName(string name)
        {
            DataTable dtb = _model.Get_manufacturename(name);
            return dtb;
        }
        public void Search_wit_manufacture(string name, string manufacture)
        {
            DataTable dtb = _model.Search_wit_manufacture(name, manufacture);
            intr.Fill_Grid(dtb);
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
