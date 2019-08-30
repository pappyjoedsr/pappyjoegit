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
        Additem_model _Model =new Additem_model();
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
        public int Save_data(string _itemname, string _itemcode, string _manufacture, string _category, string _location, string _packing, string _isbatch, string _Sales1, string _SalesMin, string _SalesMax, string _Purch_Rate, string _punit, string _sUnit, int _unitmf, string _Purch_Rate2, string _Sales2, string _SalesMin1, string _SalesMax1, string _isOneUnitOnly, string _ReorderQty, string _CostBase, string _istax, string _MinimumStock)
        {
            int i = _Model.Save_data( _itemname,  _itemcode,  _manufacture,  _category,  _location,  _packing,  _isbatch,  _Sales1,  _SalesMin,  _SalesMax,  _Purch_Rate,  _punit,  _sUnit,  _unitmf,  _Purch_Rate2,  _Sales2,  _SalesMin1,  _SalesMax1,  _isOneUnitOnly,  _ReorderQty,  _CostBase,  _istax,  _MinimumStock);
            return i;
        }
       
        public int update_data(int id, string _itemname, string _itemcode, string _manufacture, string _category, string _location, string _packing, string _isbatch, string _Sales1, string _SalesMin, string _SalesMax, string _Purch_Rate, string _punit, string _sUnit, int _unitmf, string _Purch_Rate2, string _Sales2, string _SalesMin1, string _SalesMax1, string _isOneUnitOnly, string _ReorderQty, string _CostBase, string _istax, string _MinimumStock)
        {
            int i = _Model.update_data(id, _itemname, _itemcode, _manufacture, _category, _location, _packing, _isbatch, _Sales1, _SalesMin, _SalesMax, _Purch_Rate, _punit, _sUnit, _unitmf, _Purch_Rate2, _Sales2, _SalesMin1, _SalesMax1, _isOneUnitOnly, _ReorderQty, _CostBase, _istax, _MinimumStock);
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
       public string get_PurchNumber(string id)
        {
            string dtb = _Model.get_PurchNumber(id);
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
        public void savedrugtable(string itemid, string _itemname, string _type, string _strength, string _strength_gr, string _instructions)
        {
            _Model.savedrugtable(itemid,_itemname,_type,_strength,_strength_gr,_instructions);
        }
        public string get_drugid(string Item_Id)
        {
            string dtb = _Model.get_drugid(Item_Id);
            return dtb;
        }
        public void update_drug(string itemid, string _itemname, string _type, string _strength, string _strength_gr, string _instructions)
        {
            _Model.update_drug( itemid,  _itemname,  _type,  _strength,  _strength_gr,  _instructions);
        }
        public DataTable select_id_drug(string _itemname, string _type, string _strength, string _strength_gr, string _instructions)
        {
            DataTable dt= _Model.select_id_drug( _itemname,  _type,  _strength,  _strength_gr,  _instructions);
            return dt;
        }
        public void update(string Item_Id, string id, string _itemname, string _type, string _strength, string _strength_gr, string _instructions)
        {
            _Model.update(Item_Id,id, _itemname, _type, _strength, _strength_gr,_instructions);
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
