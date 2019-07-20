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
        private string _itemcode = "";
        public string ItemCode
        {
            get { return _itemcode; }
            set { _itemcode = value; }
        }
        private string _itemname = "";
        public string ItemName
        {
            get { return _itemname; }
            set { _itemname = value; }
        }
        private string _packing = "";
        public string Packing
        {
            get { return _packing; }
            set { _packing = value; }
        }
        private string _location = "";
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        private string _category = "";
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        private string _manufacture = "";
        public string Manufacture
        {
            get { return _manufacture; }
            set { _manufacture = value; }
        }
        private string _punit = "";
        public string PUnit
        {
            get { return _punit; }
            set { _punit = value; }
        }
        private string _sUnit = "";
        public string SUnit
        {
            get { return _sUnit; }
            set { _sUnit = value; }
        }
        private int _unitmf = 0;
        public int UnitMF
        {
            get { return _unitmf; }
            set { _unitmf = value; }
        }
        private Decimal _Sales1 = 0;
        public Decimal Sales_Rate
        {
            get { return _Sales1; }
            set { _Sales1 = value; }
        }
        private Decimal _SalesMin = 0;
        public Decimal Sales_Rate_min
        {
            get { return _SalesMin; }
            set { _SalesMin = value; }
        }
        private Decimal _SalesMax = 0;
        public Decimal Sales_Rate_Max
        {
            get { return _SalesMax; }
            set { _SalesMax = value; }
        }
        private Decimal _Sales2 = 0;
        public Decimal Sales_Rate2
        {
            get { return _Sales2; }
            set { _Sales2 = value; }
        }
        private Decimal _SalesMin1 = 0;
        public Decimal Sales_Rate_min2
        {
            get { return _SalesMin1; }
            set { _SalesMin1 = value; }
        }

        private Decimal _SalesMax1 = 0;
        public Decimal Sales_Rate_Max2
        {
            get { return _SalesMax1; }
            set { _SalesMax1 = value; }
        }
        private int _ReorderQty = 0;
        public int ReorderQty
        {
            get { return _ReorderQty; }
            set { _ReorderQty = value; }
        }
        private int _MinimumStock = 0;
        public int MinimumStock
        {
            get { return _MinimumStock; }
            set { _MinimumStock = value; }
        }
        private Decimal _CostBase = 0;
        public Decimal CostBase
        {
            get { return _CostBase; }
            set { _CostBase = value; }
        }
        private Decimal _Purch_Rate2 = 0;
        public Decimal Purch_Rate2
        {
            get { return _Purch_Rate2; }
            set { _Purch_Rate2 = value; }
        }

        private Decimal _Purch_Rate = 0;
        public Decimal Purch_Rate
        {
            get { return _Purch_Rate; }
            set { _Purch_Rate = value; }
        }
        private bool _isbatch = true;
        public bool ISBAtch
        {
            get { return _isbatch; }
            set { _isbatch = value; }
        }
        private bool _istax = true;
        public bool ISTax
        {
            get { return _istax; }
            set { _istax = value; }
        }
        private string _isOneUnitOnly = "";
        public string isOneUnitOnly
        {
            get { return _isOneUnitOnly; }
            set { _isOneUnitOnly = value; }
        }
        private string _type = "";
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _strength = "";
        public string strength
        {
            get { return _strength; }
            set { _strength = value; }
        }
        private string _strength_gr = "";
        public string strength_gr
        {
            get { return _strength_gr; }
            set { _strength_gr = value; }
        }
        private string _instructions = "";
        public string instructions
        {
            get { return _instructions; }
            set { _instructions = value; }
        }  
       
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
       public int Save_data()
        {
            int i = db.execute("insert into tbl_ITEMS(item_name,item_code,manufacturer,Cat_Number,Location,Packing,Dep_Number,ISBatch,IsExpDate,IsSerial,Sales_Rate,Sales_Rate_min,Sales_Rate_Max,Open_Cost,Open_Stock,Current_Stock,FreeStock,LOWEST_COST,PurchRateType,Purch_Rate,Sup_Code,Unit1,Unit2,UnitMF,Purch_Rate2,Sales_Rate2,Sales_Rate_min2,Sales_Rate_Max2,OneUnitOnly,ReorderQty,CostBase,PayAfterSale,ItemGroup,Taxable,MinimumStock)values('" + _itemname + "','" +_itemcode + "','" + _manufacture + "','" + _category + "','" + _location + "','" + _packing + "','1','" + _isbatch + "','False','False','" + _Sales1 + "','" + _SalesMin + "','" + _SalesMax + "','0','0','0','0','0','0','" + _Purch_Rate + "','1','" + _punit + "','" + _sUnit + "','" + _unitmf + "','" + _Purch_Rate2 + "','" + _Sales2 + "','" + _SalesMin1 + "','" + _SalesMax1 + "','" + _isOneUnitOnly + "','" + _ReorderQty + "','" + _CostBase + "','False','False','" + _istax + "','" + _MinimumStock + "')");
            return i;
        }
        public int update_data(int Item_Id)
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
        public DataTable get_PurchNumber(string itemid)
        {
            DataTable bt_purNo = db.table("select MAX(PurchNumber)from tbl_PURCHIT where Item_Code='" + itemid + "'");
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
        public void  savedrugtable(string itemid)
        {
            db.execute("insert into tbl_adddrug(name,type,strength,strength_gr,instructions,display_status,inventory_id) values('" + _itemname + "','" + _type + "','" + _strength + "','" + _strength_gr+ "','" + _instructions + "','Yes','" + itemid + "')");
        }

        public DataTable get_drugid(string Item_Id)
        {
            DataTable rs_item = db.table("SELECT id FROM tbl_adddrug where inventory_id='" + Item_Id + "'");
            return rs_item;
        }
        public void update_drug(string itemid)
        {
            db.execute("update tbl_adddrug set name='" + _itemname + "',type='" + _type + "',strength='" + _strength + "',strength_gr='" + _strength_gr + "',instructions='" + _instructions + "' where inventory_id='" + itemid + "'");
        }
        public DataTable select_id_drug()
        {
            DataTable rs_additem = db.table("SELECT id FROM tbl_adddrug where name='" + _itemname + "' and type='" + _type + "' and strength='" + _strength + "' and strength_gr='" + _strength_gr + "'");
            return rs_additem;
        }
        public void update(string Item_Id,string id)
        {
            db.execute("update tbl_adddrug set name='" + _itemname + "',type='" + _type + "',strength='" + _strength + "',strength_gr='" + _strength_gr + "',instructions='" + _instructions + "', inventory_id='" + Item_Id + "'  where id='" + id + "'");
        }
        public void update_inventryid(string Item_Id)
        {
            db.execute("update tbl_adddrug set inventory_id='0' where inventory_id='" + Item_Id + "'");
        }
    }
}
 