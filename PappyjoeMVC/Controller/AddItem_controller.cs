using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
  public class AddItem_controller
    {
        AddItemInterface intr;
        Additem_model _Model =new Additem_model();
        public AddItem_controller(AddItemInterface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public DataTable fill_category()
        {
            DataTable dtb = _Model.fill_category();
            return dtb;
        }
        public DataTable fill_manufacture()
        {
            DataTable dtb = _Model.fill_manufacture();
            return dtb;
        }
        public DataTable fill_unit()
        {
            DataTable dtb = _Model.fill_unit();
            return dtb;
        }
        public int Save_data(string isOneUnitOnly)
        {
            Put_data_to_model(isOneUnitOnly);
            int i = _Model.Save_data();
            return i;
        }
        public void Put_data_to_model(string isOneUnitOnly)
        {
            _Model.ItemCode = intr.ItemCode;
            _Model.ItemName = intr.ItemName;
            _Model.Packing = intr.Packing;
            _Model.Location = intr.Location;
            _Model.Category = intr.Category;
            _Model.Manufacture = intr.Manufacture;
            _Model.PUnit = intr.PUnit;
            _Model.SUnit = intr.SUnit;
            _Model.UnitMF = intr.UnitMF;
            _Model.Sales_Rate = intr.Sales_Rate;
            _Model.Sales_Rate_min = intr.Sales_Rate_min;
            _Model.Sales_Rate_Max = intr.Sales_Rate_Max;
            _Model.Sales_Rate2 = intr.Sales_Rate2;
            _Model.Sales_Rate_min2 = intr.Sales_Rate_min2;
            _Model.Sales_Rate_Max2 = intr.Sales_Rate_Max2;
            _Model.Purch_Rate = intr.Purch_Rate;
            _Model.Purch_Rate2 = intr.Purch_Rate2;
            _Model.ISBAtch = intr.ISBatch;
            _Model.ISTax = intr.ISTax;
            _Model.CostBase = intr.CostBase;
            _Model.ReorderQty = intr.ReorderQty;
            _Model.MinimumStock = intr.MinimumStock;
            _Model.isOneUnitOnly = isOneUnitOnly;

        }
        public int update_data(string isOneUnitOnly,int id)
        {
            Put_data_to_model(isOneUnitOnly);
            int i = _Model.update_data(id);
            return i;
        }
        public DataTable load_itemcode()
        {
            DataTable dtb = _Model.load_itemcode();
            return dtb;
        }
        public DataTable Get_Item_unitmf(string id)
        {
            DataTable dtb = _Model.Get_Item_unitmf(id);
            return dtb;
        }
        
       public DataTable get_PurchNumber(string id)
        {
            DataTable dtb = _Model.get_PurchNumber(id);
            return dtb;
        }
        public DataTable get_tbl_PURCHIT_details(string id)
        {
            DataTable dtb = _Model.get_tbl_PURCHIT_details(id);
            return dtb;
        }
        public DataTable Get_PURCHIT_wit_itemid(string id)
        {
            DataTable dtb = _Model.get_tbl_PURCHIT_details(id);
            return dtb;
        }
        public string get_max_itemid()
        {
            string maxId = _Model.get_max_itemid();
            return maxId;
        }
        public void savedrugtable(string itemid)
        {
            add_drugdatas();
            _Model.savedrugtable(itemid);
        }
        public DataTable get_drugid(string Item_Id)
        {
            DataTable dtb = _Model.get_drugid(Item_Id);
            return dtb;
        }
        public void update_drug(string itemid)
        {
            add_drugdatas();
            _Model.update_drug(itemid);
        }
        public DataTable select_id_drug()
        {
            add_drugdatas();
            DataTable dt= _Model.select_id_drug();
            return dt;
        }
        public void update(string Item_Id, string id)
        {
            add_drugdatas();
            _Model.update(Item_Id,id);
        }
        public void add_drugdatas()
        {
            _Model.type = intr.type;
            _Model.ItemName = intr.ItemName;
            _Model.strength = intr.strength;
            _Model.strength_gr = intr.strength_gr;
            _Model.instructions = intr.instructions;
        }
        public void update_inventryid(string Item_Id)
        {
            _Model.update_inventryid(Item_Id);
        }
        public DataTable get_drugdetails(int Item_Id)
        {
            DataTable dtb = _Model.get_drugdetails(Item_Id);
            return dtb;
        }
        public DataTable fill_drugtype()
        {
            DataTable dtb = _Model.fill_drugtype();
            return dtb;
        }
    }
}
