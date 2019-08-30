using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
  public  class Additem_model
    {
        Connection db = new Connection();
        public DataTable fill_category()
        {
            DataTable dt_Category = db.table("select * from tbl_Category order by id");
            return dt_Category;
        }
        public DataTable fill_manufacture()
        {
            DataTable dt_manufact = db.table("select * from tbl_manufacturer order by id");
            return dt_manufact;
        }
        public DataTable fill_unit()
        {
            DataTable dt_Units = db.table("select * from tbl_unit order by id");
            return dt_Units;
        }
       public int Save_data( string _itemname , string _itemcode , string _manufacture , string _category, string _location , string _packing , string _isbatch , string _Sales1 , string _SalesMin, string _SalesMax , string _Purch_Rate , string _punit , string _sUnit , int _unitmf , string _Purch_Rate2 , string _Sales2 , string _SalesMin1 , string _SalesMax1 , string _isOneUnitOnly , string _ReorderQty , string _CostBase , string _istax , string _MinimumStock)
        {
            int i = db.execute("insert into tbl_ITEMS(item_name,item_code,manufacturer,Cat_Number,Location,Packing,Dep_Number,ISBatch,IsExpDate,IsSerial,Sales_Rate,Sales_Rate_min,Sales_Rate_Max,Open_Cost,Open_Stock,Current_Stock,FreeStock,LOWEST_COST,PurchRateType,Purch_Rate,Sup_Code,Unit1,Unit2,UnitMF,Purch_Rate2,Sales_Rate2,Sales_Rate_min2,Sales_Rate_Max2,OneUnitOnly,ReorderQty,CostBase,PayAfterSale,ItemGroup,Taxable,MinimumStock)values('" + _itemname + "','" +_itemcode + "','" + _manufacture + "','" + _category + "','" + _location + "','" + _packing + "','1','" + _isbatch + "','False','False','" + _Sales1 + "','" + _SalesMin + "','" + _SalesMax + "','0','0','0','0','0','0','" + _Purch_Rate + "','1','" + _punit + "','" + _sUnit + "','" + _unitmf + "','" + _Purch_Rate2 + "','" + _Sales2 + "','" + _SalesMin1 + "','" + _SalesMax1 + "','" + _isOneUnitOnly + "','" + _ReorderQty + "','" + _CostBase + "','False','False','" + _istax + "','" + _MinimumStock + "')");
            return i;
        }
        public int update_data(int Item_Id, string _itemname, string _itemcode, string _manufacture, string _category, string _location, string _packing, string _isbatch, string _Sales1, string _SalesMin, string _SalesMax, string _Purch_Rate, string _punit, string _sUnit, int _unitmf, string _Purch_Rate2, string _Sales2, string _SalesMin1, string _SalesMax1, string _isOneUnitOnly, string _ReorderQty, string _CostBase, string _istax, string _MinimumStock)
        {
            int i = db.execute("update tbl_ITEMS set item_name='" + _itemname + "' ,item_code='" + _itemcode + "',manufacturer='" + _manufacture + "',Cat_Number='" + _category + "',Location='" + _location + "',Packing='" + _packing + "',Dep_Number='1',ISBatch='" + _isbatch + "',IsExpDate='False',IsSerial='True',Sales_Rate='" + _Sales1 + "',Sales_Rate_min='" + _SalesMin + "',Sales_Rate_Max='" + _SalesMax + "',Open_Cost='0',Open_Stock='0',Current_Stock='0',FreeStock='0',LOWEST_COST='0',PurchRateType='0',Purch_Rate='" + _Purch_Rate + "',Sup_Code='1',Unit1='" + _punit + "',Unit2='" + _sUnit + "',UnitMF='" + _unitmf + "',Purch_Rate2='" + _Purch_Rate2 + "',Sales_Rate2='" + _Sales2 + "',Sales_Rate_min2='" + _SalesMin1 + "',Sales_Rate_Max2='" + _SalesMax1 + "',OneUnitOnly='" + _isOneUnitOnly + "',ReorderQty='" + _ReorderQty + "',CostBase='" + _CostBase + "',PayAfterSale='False',ItemGroup='False',Taxable='" + _istax + "',MinimumStock='" + _MinimumStock + "' where id='" + Item_Id + "'");
            return i;
        }
        public DataTable load_itemcode()
        {
            DataTable dt_Units = db.table("select item_code from tbl_ITEMS");
            return dt_Units;
        }
        public DataTable Get_Item_unitmf(string id)
        {
            DataTable dt = db.table("select id,item_code,UnitMF from tbl_ITEMS where id='" + id + "' ");
            return dt;
        }
        public string get_PurchNumber(string itemid)
        {
            string bt_purNo = db.scalar("select MAX(PurchNumber)from tbl_PURCHIT where Item_Code='" + itemid + "'");
            return bt_purNo;
        }
        public DataTable get_tbl_PURCHIT_details(string PurchNumber)
        {
            DataTable dt_purch = db.table("select Rate,Unit,UNIT2 from tbl_PURCHIT where PurchNumber='" + PurchNumber + "'");
            return dt_purch;
        }
        public DataTable Get_PURCHIT_wit_itemid(string itemid)
        {
            DataTable dtb_Avg = db.table("select Qty,Rate,Unit,UNIT2,UnitMF from tbl_PURCHIT where Item_Code='" + itemid + "'");
            return dtb_Avg;
        }
       public string get_max_itemid()
        {
            string rs_item = db.scalar("SELECT MAX(id) FROM tbl_ITEMS order by id");
            return rs_item;
        }
        public void  savedrugtable(string itemid, string _itemname , string _type , string _strength , string _strength_gr, string _instructions)
        {
            db.execute("insert into tbl_adddrug(name,type,strength,strength_gr,instructions,display_status,inventory_id) values('" + _itemname + "','" + _type + "','" + _strength + "','" + _strength_gr+ "','" + _instructions + "','Yes','" + itemid + "')");
        }
        public string get_drugid(string Item_Id)
        {
            string rs_item = db.scalar("SELECT id FROM tbl_adddrug where inventory_id='" + Item_Id + "'");
            return rs_item;
        }
        public void update_drug(string itemid, string _itemname, string _type, string _strength, string _strength_gr, string _instructions)
        {
            db.execute("update tbl_adddrug set name='" + _itemname + "',type='" + _type + "',strength='" + _strength + "',strength_gr='" + _strength_gr + "',instructions='" + _instructions + "' where inventory_id='" + itemid + "'");
        }
        public DataTable select_id_drug(string _itemname, string _type, string _strength, string _strength_gr, string _instructions)
        {
            DataTable rs_additem = db.table("SELECT id FROM tbl_adddrug where name='" + _itemname + "' and type='" + _type + "' and strength='" + _strength + "' and strength_gr='" + _strength_gr + "'");
            return rs_additem;
        }
        public void update(string Item_Id,string id, string _itemname, string _type, string _strength, string _strength_gr, string _instructions)
        {
            db.execute("update tbl_adddrug set name='" + _itemname + "',type='" + _type + "',strength='" + _strength + "',strength_gr='" + _strength_gr + "',instructions='" + _instructions + "', inventory_id='" + Item_Id + "'  where id='" + id + "'");
        }
        public void update_inventryid(string Item_Id)
        {
            db.execute("update tbl_adddrug set inventory_id='0' where inventory_id='" + Item_Id + "'");
        }
        public DataTable get_drugdetails(int Item_Id)
        {
            DataTable dtb_item = db.table("select type,	strength,strength_gr,instructions,inventory_id from tbl_adddrug where inventory_id='" + Item_Id + "'");
            return dtb_item;
        }
        public DataTable fill_drugtype()
        {
            DataTable dt2 = db.table("SELECT * FROM tbl_drug_type WHERE id IN (SELECT MAX(id) FROM tbl_drug_type GROUP BY dr_type)");
            return dt2;
        }
    }
}
 